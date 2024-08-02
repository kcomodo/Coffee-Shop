import { Component } from '@angular/core';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrl: './menu.component.css'
})
export class MenuComponent {
  coffees = [
    { name: 'Espresso', description: 'Strong and bold', price: 2.5, image: 'espresso.jpg' },
    { name: 'Latte', description: 'Smooth and creamy', price: 3.0, image: 'latte.jpg' },
    { name: 'Test', description: 'Testing and testing', price: 5.0, image: 'testing.jpg' },
    { name: 'Test2', description: 'Testing and testing', price: 5.0, image: 'testing.jpg' },
  ];
  foods = [
    { name: 'Burger', description: 'Strong and bold', price: 2.5, image: 'espresso.jpg' },
    { name: 'Stuff', description: 'Smooth and creamy', price: 3.0, image: 'latte.jpg' },
    { name: 'Yes', description: 'Testing and testing', price: 5.0, image: 'testing.jpg' },
    { name: 'Okay', description: 'Testing and testing', price: 5.0, image: 'testing.jpg' },

  ];

  snacks = [
    { name: 'snack1', description: 'Strong and bold', price: 2.5, image: 'espresso.jpg' },
    { name: 'snack2', description: 'Smooth and creamy', price: 3.0, image: 'latte.jpg' },
    { name: 'Cheetos', description: 'Testing and testing', price: 5.0, image: 'testing.jpg' },
    { name: 'Test3', description: 'Testing and testing', price: 5.0, image: 'testing.jpg' },
  ];
}
