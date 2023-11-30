import { Injectable } from '@angular/core';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { StoreService } from '../../store/store.service';
import { SetUser } from '../../store/actions/user.actions';
import { Observable, map, take } from 'rxjs';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  isAuthenticated$ = this.oidcSecurityService.isAuthenticated$;

  constructor(private oidcSecurityService: OidcSecurityService,
    private storeService: StoreService,
    private router: Router) { }

  login() {
    const somePopupOptions = { width: 500, height: 600, left: 50, top: 50 };
    const authOptionsOrNull = null;
    this.oidcSecurityService.authorizeWithPopUp()
      .subscribe(({ isAuthenticated, userData, accessToken, errorMessage }) => {
        console.log(isAuthenticated);
        const appUser: any = { username: userData.username, test: userData.test };
        this.storeService.executeAction(new SetUser(appUser));
      });
  }

  guardCheckUserLogin(): Observable<boolean> {
    return this.oidcSecurityService.isAuthenticated$.pipe(
      take(1),
      map(({ isAuthenticated }) => {
        if (isAuthenticated) {
          this.checkUserLogin();
          return true;
        } else {
          this.login();
          this.router.navigate(['/']);
          return false;
        }
      }));
  }

  checkUserLogin() {
    this.oidcSecurityService.checkAuth().subscribe(({ isAuthenticated, userData, accessToken }) => {
      if (isAuthenticated) {
        const appUser: any = { username: userData.username, test: userData.test };
        this.storeService.executeAction(new SetUser(appUser));
      }
    });
  }

  logOut() {
    this.oidcSecurityService.logoff().subscribe((result) => console.log(result));
  }

}
