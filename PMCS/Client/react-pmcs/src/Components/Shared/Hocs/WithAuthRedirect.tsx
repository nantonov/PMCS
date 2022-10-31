import React from "react";
import { Navigate } from "react-router-dom";
import { useAuthContext } from "../../Auth/AuthProvider";

const withAuthRedirect = (Component : React.ComponentType<React.PropsWithChildren>) => ({ ...props }) => {
    const { isAuth } = useAuthContext();

    return (
        <div>
            {!isAuth && <Navigate to='/' />}
            {<Component {...props as React.PropsWithChildren} />}
        </div>
    );
}

export default withAuthRedirect;