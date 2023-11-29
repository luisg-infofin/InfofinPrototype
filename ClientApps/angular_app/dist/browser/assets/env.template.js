(function (window) {
    window.env = window.env || {};

    // Environment variables
    window["env"]["apiUrl"] = "${API_URL}";
    window["env"]["identityAuthority"] = "${IDENTITY_AUTHORITY}";
    window["env"]["identityRedirectUri"] = "${IDENTITY_REDIRECT_URI}";
    window["env"]["identityPostLogoutRedirectUri"] = "${IDENTITY_POST_LOGOUT_REDIRECT_URI}";
    window["env"]["identityScopes"] = "${IDENTITY_SCOPES}";    
    window["env"]["identityClientId"] = "${IDENTITY_CLIENT_ID}";  
})(this);