import React, { createContext, useContext } from 'react'
import { useUser } from '../../Services/authService'

export type AuthProps = ReturnType<typeof useUser>;

const AuthContext = createContext<AuthProps>({
    user: null,
    isAuth: false
});

const useAuthContext = () => useContext(AuthContext)

const AuthProvider : React.FC<React.ReactNode> = (children) => {

    const auth = useUser()

    return <AuthContext.Provider value={auth}>
        {children}
    </AuthContext.Provider>
}

export { useAuthContext, AuthProvider }