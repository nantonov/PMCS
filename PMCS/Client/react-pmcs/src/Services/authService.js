import { UserManager } from 'oidc-client';
import authConfig from '../configuration/authConfig';
import { useState, useEffect } from 'react';

const signInManager = new UserManager(authConfig);

export const useUser = () => {
    const [user, setUser] = useState(null);
    const [isAuth, setAuth] = useState(false);

    useEffect(() => {
        authService.getUser().then(user => {
            console.log('loaded');
            setUser(u=> u = user);
            setAuth(isAuth => isAuth = user !== null);
        });

    }, []);

    return [user, isAuth];
};

const authService = {

    getUser: async () => {
        return await signInManager.getUser();
    },
    signIn: async () => {
        await signInManager.signinRedirect();
    },
    signOut: async () => {
        await signInManager.signoutRedirect();
    },
    signOutCallback: async () => {
        signInManager.signoutRedirectCallback();
    },
    signInCallback: async () => {
        await signInManager.signinRedirectCallback();
    },
    signInSilentCallback: async () => {
        await signInManager.signinSilentCallback();
    }
}

signInManager.events.addAccessTokenExpired(async function () {
    console.log('access token expired');
    await signInManager.signinSilent();
});

export default authService;


