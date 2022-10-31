import { ReactJSXIntrinsicAttributes } from "@emotion/react/types/jsx-namespace";
import React from "react";
import { Navigate } from "react-router-dom";
import { useAuthContext } from "../../Auth/AuthProvider";

function withAuthRedirect<WP extends ReactJSXIntrinsicAttributes>(WrappedComponent: React.ComponentType<WP>) {
    return ({ ...props }: WP) => {
        const { isAuth } = useAuthContext();

        return (
            <div>
                {!isAuth && <Navigate to='/' />}
                {<WrappedComponent {...props} />}
            </div>
        );
    }
}
export default withAuthRedirect;