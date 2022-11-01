import React, { createContext, useContext } from 'react'
import { useUser } from '../../Services/authService'

export type AuthProps = ReturnType<typeof useUser>;

interface AuthProviderProps {
    children: React.ReactNode;
}

const AuthContext = createContext<AuthProps>({
    user: null,
    isAuth: false
});

const useAuthContext = () => useContext(AuthContext)

const AuthProvider : React.FC<AuthProviderProps> = ({ children }) => {

    const auth = useUser()

    return <AuthContext.Provider value={auth}>
        {children}
    </AuthContext.Provider>
}

export { useAuthContext, AuthProvider }