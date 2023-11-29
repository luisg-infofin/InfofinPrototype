import { Component } from '@angular/core';
import { OidAuthenticationService } from '../../../auth/services/oid-authentication.service';
import { User } from '../../../shared/interfaces/user.interface';
import { Observable } from 'rxjs';
import { StoreService } from '../../../store/store.service';
import { MenuService } from '../../../persons/services/menu.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {
  user: Observable<User>

  constructor(public oidService: OidAuthenticationService, private menuService: MenuService, private storeService: StoreService) {
    this.user = this.storeService.getState(state => state.appUser);
  }

  openSideNav() {
    this.menuService.toggle();
  }

}
