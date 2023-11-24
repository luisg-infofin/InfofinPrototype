import { Injectable } from '@angular/core';
import { User, UserManager } from 'oidc-client';
import { oidConfig } from './oidConfig';
import { Observable, Subject } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Store } from '@ngrx/store';
import { AppState } from '../interfaces/appState.interface';
import { SetUser } from '../stores/actions/user.actions';

@Injectable({
  providedIn: 'root'
})
export class OidAuthenticationService {

  private manager = new UserManager(oidConfig);
  private user: User | null = null;
  private loginChangedSubject$ = new Subject<boolean>();
  isUserLoggedIn$ = this.loginChangedSubject$.asObservable();

  constructor(private store: Store<AppState>) {
    this.manager.getUser().then(user => {
      this.user = user;
      this.setAppStateUser();
      this.loginChangedSubject$.next(this.isAuthenticated());
    });
  }

  isAuthenticated(): boolean {
    return this.user != null && !this.user.expired;
  }

  signIn(): Promise<void> {
    return this.manager.signinRedirect();
  }

  logOut(): Promise<void> {
    return this.manager.signoutRedirect();
  }

  completeAuthentication(): Promise<void> {
    return this.manager.signinRedirectCallback().then(user => {
      this.user = user;
      this.setAppStateUser();
      this.loginChangedSubject$.next(this.isAuthenticated());
    });
  }

  completeLogout(): Promise<void> {
    return this.manager.signoutRedirectCallback().then((_) => {
      this.user = null;
      this.loginChangedSubject$.next(this.isAuthenticated());
    });
  }

  getUserLoggedInEvents(): Observable<boolean> {
    return this.loginChangedSubject$.asObservable();
  }

  setAppStateUser() {
    const helper = new JwtHelperService();
    if (this.user != null) {
      const decodedToken = helper.decodeToken(this.user.id_token);
      const appUser: any = { username: decodedToken.username, test: decodedToken.test };
      this.store.dispatch(new SetUser(appUser));
    }
  }
}
