import { Injectable } from "@angular/core";
import { AuthService } from "../../auth/services/auth.service";

@Injectable({ providedIn: 'root' })
export class AuthorizationGuard {

    constructor(private authService: AuthService) { }

    canActivate() {
        return this.authService.guardCheckUserLogin();
    }

}