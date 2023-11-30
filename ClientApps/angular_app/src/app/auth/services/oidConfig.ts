
import { environment } from "../../../env/enviroment";
import { OpenIdConfiguration } from "angular-auth-oidc-client";

export const oidConfig: OpenIdConfiguration = {
    authority: environment.identityAuthority,
    clientId: environment.identityClientId,
    redirectUrl: environment.identityRedirectUri,
    postLogoutRedirectUri: environment.identityPostLogoutRedirectUri,
    responseType: "code",
    scope: environment.identityScopes,
}
