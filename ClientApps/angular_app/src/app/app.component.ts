import { Component, OnInit, ViewChild } from '@angular/core';
import { MenuService } from './persons/services/menu.service';
import { Observable } from 'rxjs';
import { MatDrawer } from '@angular/material/sidenav';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { StoreService } from './store/store.service';
import { SetUser } from './store/actions/user.actions';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {

  @ViewChild('drawer', { static: true }) drawer!: MatDrawer;
  title = 'angular_app';
  isSideNavOpen: Observable<boolean>;

  constructor(private menuService: MenuService,
    private oidcSecurityService: OidcSecurityService,
    private storeService: StoreService,) {
    this.isSideNavOpen = this.menuService.asObservable();

    this.oidcSecurityService.checkAuth().subscribe(({ isAuthenticated, userData, accessToken }) => {
      if (isAuthenticated) {
        const appUser: any = { username: userData.username, test: userData.test };
        this.storeService.executeAction(new SetUser(appUser));
      }
    });

  }

  ngOnInit(): void {
    this.drawer.closedStart.subscribe((_) => {
      this.menuService.closeSideNav();
    });
  }


}


