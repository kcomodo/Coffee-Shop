using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using POS_Folders.Repository;
using POS_Folders.Services;
using System.Text.RegularExpressions;
using System;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Http;
namespace CoffeeShopWebsiteAngular.Server.Controllers
{
    //Create a new controller for customer
    //Call the repository
    //Call the CRUD operations

    public class CustomerController : Controller
    {

        //call the repository and services
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerServices _customerServices;
        public IActionResult Index()
        {
            return View();
        }
        public CustomerController(ICustomerRepository customerRepository, ICustomerServices customerServices) 
        {
            _customerRepository = customerRepository;
            _customerServices = customerServices;

        }
        //backend part just to get information from the database
        [HttpGet("GetCustomerByEmail")]
        public IActionResult GetCustomerByEmail(string email)
        {
            var customer = _customerRepository.getCustomerByEmail(email);
            return Ok(customer);
        }
        //service side for customers
        [HttpPost("CustomerValidateLogin")]
        public IActionResult ValidateLogin(string email, string password)
        {
            bool isValid = _customerServices.validateCustomerLogin(email, password);
            //when this value is true, we will create a token for the user
            //create a new method to generate a token
            if (isValid)
            {
                var token = GenerateJwtToken(email);
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true, // Set to true if using HTTPS
                    Expires = DateTime.UtcNow.AddHours(1),
                    SameSite = SameSiteMode.Strict
                };
                Response.Cookies.Append("auth_token", token, cookieOptions); //Store the token in a cookie, can now access the cookie from the client side

                // For testing purposes, you can also return the token directly
                return Ok(new { Token = token });
                //return Ok(token); // Just the token string
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost("RegisterCustomer")]
        public IActionResult RegisterCustomer(string firstname, string lastname, string email, string phone, string password)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (!regex.IsMatch(email))
            {
                return BadRequest("Invalid email");
            }
            else
            {
                _customerRepository.addCustomer(firstname, lastname, email, phone, password);
                return Ok();
            }
        
        }
        [HttpDelete("DeleteCustomer")]
        public IActionResult DeleteCustomer(string email)
        {
            _customerRepository.deleteCustomerByEmail(email);
            return Ok();
        }
        [HttpPut("UpdateCustomer")]
        public IActionResult UpdateCustomer(string firstname, string lastname, string email, string phone, string password)
        {
            _customerRepository.updateCustomerByEmail(firstname, lastname, email, phone, password);
            return Ok();
        }
        [HttpGet("GetCustomerIdUsingEmail")]
        public IActionResult GetCustomerIdUsingEmail(string email)
        {
            int id = _customerRepository.getCustomerIdUsingEmail(email);
            return Ok(id);
        }
        private string GenerateJwtToken(string email)
        {
            //Steps:
            //Create a new token handler
            //Ensure your key is at least 32 bytes (256 bits) long
            //create a new token descriptor
            //assign the subject as a value in this case the email, make a claimidentity for it
            //the new claim is JwtRegisteredClaimNames.Sub, is for the email
            //set the expiration time for the token
            //sign the credentials to ensures the tokens authenticity and integrity
            //close out of the token descriptor
            //create the token
            //write the token and return it

            //create a new token handler
            var tokenHandler = new JwtSecurityTokenHandler();

            // Ensure your key is at least 32 bytes (256 bits) long
            //Encoding will convert the string to byte array
            //ASCII represents each character in the string as a single byte

           // var key = Encoding.ASCII.GetBytes("YourSuperSecureKeyHereThatIsAtLeast32BytesLong"); // Update this key to be at least 32 bytes
            var key = Encoding.UTF8.GetBytes("YourSuperSecureKeyHereThatIsAtLeast32BytesLong");

            //ClaimsIdentity represents the pieces of information about the user
            //Subject is the email
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, email) // Used to identify the user
                }),
                Expires = DateTime.UtcNow.AddHours(1), // Gives an expiration time for the token
                //SigningCredentials ensures the tokens authenticity and integrity
                //SymmetricSecurityKey creates a shared secret key between the server and the client, used for signing the token
                //SecurityAlgorithms.HmacSha256Signature is the algorithm used to sign the token
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature) 
            };

            var token = tokenHandler.CreateToken(tokenDescriptor); // Create token
            return tokenHandler.WriteToken(token); // Write token and return it
        }

    }
}

