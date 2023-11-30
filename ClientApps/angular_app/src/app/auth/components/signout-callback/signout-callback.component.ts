import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signout-callback',
  templateUrl: './signout-callback.component.html',
  styleUrl: './signout-callback.component.css'
})
export class SignoutCallbackComponent {
  constructor(private router: Router) {
    this.router.navigate(['/'], { replaceUrl: true });;
  }
}
