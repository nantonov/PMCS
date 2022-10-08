import React, { useEffect } from "react";
import { Navigate } from "react-router-dom";
import { useAuthContext } from "./AuthProvider";

const withAuthRedirect = Component => ({ ...props }) => {
    const { isAuth } = useAuthContext();

    if (!isAuth) return (
        <div>
            <Navigate to="/" />
        </div>
    );
    return (
        <Component {...props} />
    );
}

export default withAuthRedirect;