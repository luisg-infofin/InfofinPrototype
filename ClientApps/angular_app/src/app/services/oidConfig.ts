import { UserManagerSettings } from "oidc-client";

export const oidConfig : UserManagerSettings = {
    authority: 'http://localhost:5000',
    client_id: 'angular_app',
    redirect_uri: 'http://localhost:4200/auth-callback',
    post_logout_redirect_uri: 'http://localhost:4200/logout-callback',
    response_type:"id_token",
    scope:"openid profile",
    filterProtocolClaims: true,
    loadUserInfo: true,
    client_secret: '511536EF-F270-4058-80CA-1C89C192F69A'
}
