import React, { useEffect } from "react";
import { Navigate } from "react-router-dom";
import { useAuthContext } from "./AuthProvider";

const withAuthRedirect = Component => ({ ...props }) => {
    console.log('Auth redirect hoc',props);
    const { isAuth } = useAuthContext();

    return (
        <div>
            {!isAuth && <Navigate to='/' />}
            {<Component {...props} />}
        </div>
    );
}

export default withAuthRedirect;