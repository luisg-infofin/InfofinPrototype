import { Component } from '@angular/core';
import { OidAuthenticationService } from '../../services/oid-authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signout-callback',
  templateUrl: './signout-callback.component.html',
  styleUrl: './signout-callback.component.css'
})
export class SignoutCallbackComponent {
  constructor(private oidService: OidAuthenticationService, private router: Router) {
    this.oidService.completeLogout().then(_ => {
      this.router.navigate(['/persons/home'], { replaceUrl: true });
    });
  }
}
