import { Component } from '@angular/core';
import { OidAuthenticationService } from '../../services/oid-authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-auth-callback',
  templateUrl: './auth-callback.component.html',
  styleUrl: './auth-callback.component.css'
})
export class AuthCallbackComponent {

  constructor(private oidService: OidAuthenticationService, private router: Router) {    
    this.oidService.completeAuthentication().then(_ => {      
      this.router.navigate(['/']);
    });
  }
}
