import { Component, Input, ViewChild } from '@angular/core';
import { OidAuthenticationService } from '../../services/oid-authentication.service';
import { Router } from '@angular/router';

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
