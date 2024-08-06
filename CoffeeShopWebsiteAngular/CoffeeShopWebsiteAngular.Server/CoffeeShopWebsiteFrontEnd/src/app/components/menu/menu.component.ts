import { Component } from '@angular/core';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrl: './menu.component.css'
})
export class MenuComponent {
  coffees = [
    { name: 'Espresso', description: 'Strong and bold', price: 2.5, image: '../assets/images/expresso.jpg' },
    { name: 'Latte', description: 'Smooth and creamy', price: 3.0, image: '../assets/images/latte2.png' },
    { name: 'Frappuccino', description: 'Creamy and cold', price: 5.0, image: '../assets/images/frappuccino.png' },
    { name: 'cappuccino', description: 'Smooth and bold', price: 3, image: '../assets/images/cappuccino.png' },
  ];
  foods = [
    { name: 'Egg Sandwich', description: 'Chicken, Egg, and Mapple Butter', price: 2.5, image: '../assets/images/egg_sandwich2.jpg' },
    { name: 'Sausage & Egg Wrap', description: 'Sausage, Chedder, and Egg', price: 3.0, image: '../assets/images/sausage_cheese.png' },
    { name: 'Bacon & Egg Sandwich', description: 'Bacon, Gouda, and Egg', price: 5.0, image: '../assets/images/bacon_sandwich.jpg' },
    { name: 'Turkey Bacon Sandwich', description: 'Bacon, Egg and Chedder', price: 5.0, image: '../assets/images/turkey_bacon.jpg' },

  ];
    
  snacks = [
    { name: 'Madeleines', description: 'Snacks', price: 2.5, image: '../assets/images/Madeleines.jpg' },
    { name: 'Cookies', description: 'Sweets', price: 3.0, image: '../assets/images/Cookies.jpg' },
    { name: 'String Cheese', description: 'Cheese', price: 5.0, image: '../assets/images/string_cheese.jpg' },
    { name: 'Perfect Bar', description: 'Snack bar', price: 5.0, image: '../assets/images/PerfectBar.jpg' },
  ];
}
