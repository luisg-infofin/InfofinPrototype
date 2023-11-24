import { Component } from '@angular/core';
import { OidAuthenticationService } from '../../services/oid-authentication.service';
import { User } from '../../interfaces/user.interface';
import { Observable } from 'rxjs';
import { Store } from '@ngrx/store';
import { AppState } from '../../interfaces/appState.interface';
import { MenuService } from '../../services/menu.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {

  user: Observable<User>
  constructor(public oidService: OidAuthenticationService, private store: Store<AppState>, private menuService: MenuService) {
    this.user = this.store.select('appUser');
  }

  openSideNav() {    
    this.menuService.toggle();
  }

}
