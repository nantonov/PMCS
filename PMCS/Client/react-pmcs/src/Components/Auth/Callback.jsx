import React from 'react';
import { Navigate } from "react-router-dom";
import authService from "../../Services/authService";

const Callback = () => {
    authService.signInCallback().then(() => {
        window.history.replaceState({},
            window.document.title,
            window.location.origin + window.location.pathname);
        window.location = "http://localhost:3000/";
    });
    return (
        <div>
            <Navigate to="/" replace={true} />
        </div>
    );
}

export default Callback;