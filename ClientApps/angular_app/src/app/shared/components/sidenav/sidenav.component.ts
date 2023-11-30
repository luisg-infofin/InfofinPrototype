import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../../auth/services/auth.service';

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrl: './sidenav.component.css'
})
export class SidenavComponent {

  isAuthenticated$ = this.authService.isAuthenticated$;
  constructor(private router: Router, public authService: AuthService) { }

  goToPage(page: string) {
    this.router.navigate([page]);
  }

}
