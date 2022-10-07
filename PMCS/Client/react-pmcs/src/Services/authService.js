import { UserManager } from 'oidc-client';
import authConfig from '../configuration/authConfig';
import { useState, useEffect } from 'react';

const signInManager = new UserManager(authConfig);

export const useUser = () => {
    const [user, setUser] = useState(null);

    useEffect(() => {
        signInManager.getUser().then(user => {
            setUser(user);
            console.log('set user');
        });
    }, [user]);

    return { user };
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
    },
    isAuthenticated: async () => {
        return await signInManager.getUser() !== null;
    }
}

signInManager.events.addUserSignedOut(function () {
    console.log('user signed out');
});

signInManager.events.addUserSignedIn(function () {
    console.log('user signed in');
});

signInManager.events.addAccessTokenExpired(async function () {
    console.log('access token expired');
    await signInManager.signinSilent();
});


export default authService;


