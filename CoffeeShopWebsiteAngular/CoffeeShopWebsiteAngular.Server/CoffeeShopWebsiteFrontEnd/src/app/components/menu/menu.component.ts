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
    { name: 'Egg Sandwich', description: 'Chicken, Egg, and Mapple Butter', price: 2.5, image: 'espresso.jpg' },
    { name: 'Sausage & Egg Wrap', description: 'Sausage, Chedder, and Egg', price: 3.0, image: 'latte.jpg' },
    { name: 'Bacon & Egg Sandwich', description: 'Bacon, Gouda, and Egg', price: 5.0, image: 'testing.jpg' },
    { name: 'Turkey Bacon Sandwich', description: 'Bacon, Egg and Chedder', price: 5.0, image: 'testing.jpg' },

  ];
    
  snacks = [
    { name: 'snack1', description: 'Strong and bold', price: 2.5, image: 'espresso.jpg' },
    { name: 'snack2', description: 'Smooth and creamy', price: 3.0, image: 'latte.jpg' },
    { name: 'Cheetos', description: 'Testing and testing', price: 5.0, image: 'testing.jpg' },
    { name: 'Test3', description: 'Testing and testing', price: 5.0, image: 'testing.jpg' },
  ];
}
