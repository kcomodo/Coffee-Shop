import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { BreakpointObserver, Breakpoints, BreakpointState } from '@angular/cdk/layout';
import { OnInit } from '@angular/core';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit{
  constructor(private authService: AuthService, private breakpointObserver: BreakpointObserver) { }
  ngOnInit() {
    const customBreakpoints = ['(max-width: 600px)', '(min-width: 601px) and (max-width: 960px)', '(min-width: 961px)'];

    this.breakpointObserver.observe(customBreakpoints).subscribe((state: BreakpointState) => {
      if (state.breakpoints[customBreakpoints[0]]) {
       // console.log('Mobile view');
      } else if (state.breakpoints[customBreakpoints[1]]) {
      //  console.log('Tablet View');
      } else if (state.breakpoints[customBreakpoints[2]]) {
     //   console.log('Desktop View');
      }
    });

  }
}
