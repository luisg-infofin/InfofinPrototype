import { UserManagerSettings } from "oidc-client";
import { environment } from "../../../env/enviroment";

export const oidConfig: UserManagerSettings = {
    authority: environment.identityAuthority,
    client_id: environment.identityClientId,
    redirect_uri: environment.identityRedirectUri,
    post_logout_redirect_uri: environment.identityPostLogoutRedirectUri,
    response_type: "id_token",
    scope: environment.identityScopes,
    filterProtocolClaims: true,
    loadUserInfo: true,
}
