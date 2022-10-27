import { UserManager } from 'oidc-client';
import authConfig from '../configuration/authConfig';
import { useState, useEffect } from 'react';
import { Nullable } from '../utils/types/Nullable';

const signInManager = new UserManager(authConfig);

type User = Awaited<ReturnType<typeof signInManager.getUser>>;

export class AuthService {

    public static async getUser(): Promise<Nullable<User>> {
        return signInManager.getUser();
    }

    public static async signIn(): Promise<void> {
        await signInManager.signinRedirect();
    }

    public static async signOut(): Promise<void> {
        await signInManager.signoutRedirect();
    }

    public static async signInCallback(): Promise<void> {
        await signInManager.signinRedirectCallback();
    }

    public static async signOutCallback(): Promise<void> {
        await signInManager.signoutRedirectCallback();
    }

    public static async signInSilentCallback(): Promise<void> {
        await signInManager.signinSilentCallback();
    }

    public static async signInSilent(): Promise<void> {
        await signInManager.signinSilentCallback();
    }
}

signInManager.events.addAccessTokenExpired(async function () {
    console.log('access token expired');
    await AuthService.signInSilent();
});

export const useUser = () => {
    const [user, setUser] = useState<User>(null);
    const [isAuth, setAuth] = useState(false);

    useEffect(() => {
        AuthService.getUser().then(user => {
            setUser(user);
            setAuth(user !== null);
        });
    }, []);

    return { user, isAuth };
};


export default AuthService;