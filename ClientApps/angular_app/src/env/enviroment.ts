export const environment = {    
    apiUrl: (window as any)["env"]["apiUrl"] || "http://localhost:6001/",    
    identityAuthority: (window as any)["env"]["identityAuthority"] || "http://localhost:5000/",    
    identityRedirectUri: (window as any)["env"]["identityRedirectUri"] || "http://localhost:4200/auth-callback",    
    identityPostLogoutRedirectUri: (window as any)["env"]["identityPostLogoutRedirectUri"] || "http://localhost:4200/logout",    
    identityScopes: (window as any)["env"]["identityScopes"] || "opdenid profile",    
    identitySecret: (window as any)["env"]["identitySecret"] || "opdenid profile",    
    identityClientId: (window as any)["env"]["identityClientId"] || "angular_app",    
};

