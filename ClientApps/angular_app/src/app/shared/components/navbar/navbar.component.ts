import { Component } from '@angular/core';
import { StoreService } from '../../../store/store.service';
import { MenuService } from '../../../persons/services/menu.service';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { SetUser } from '../../../store/actions/user.actions';
import { AuthService } from '../../../auth/services/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {
  user = this.storeService.getState(state => state.appUser);
  isAuthenticated$ = this.authService.isAuthenticated$;

  constructor(private menuService: MenuService,
    public authService: AuthService,
    private storeService: StoreService) {
  }

  openSideNav() {
    this.menuService.toggle();
  }

}
