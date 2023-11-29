import { Component, Input, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { OidAuthenticationService } from '../../../auth/services/oid-authentication.service';

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrl: './sidenav.component.css'
})
export class SidenavComponent {


  constructor(public oidService: OidAuthenticationService, private router: Router) { }

  goToPage(page: string) {
    this.router.navigate([page]);
  }

}
