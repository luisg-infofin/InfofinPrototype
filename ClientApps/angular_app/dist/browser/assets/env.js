(function (window) {
    window["env"] = window["env"] || {};

    // Environment variables
    window["env"]["apiUrl"] = "http://localhost:6001";        
    window["env"]["identityAuthority"] = "http://localhost:5000";        
    window["env"]["identityRedirectUri"] = "http://localhost:4200/auth-callback";        
    window["env"]["identityPostLogoutRedirectUri"] = "http://localhost:4200/logout-callback";  
    window["env"]["identityScopes"] = "openid profile";  
    window["env"]["identitySecret"] = "511536EF-F270-4058-80CA-1C89C192F69A";  
    window["env"]["identityClientId"] = "511536EF-F270-4058-80CA-1C89C192F69A";  
})(this);