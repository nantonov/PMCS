import React from 'react';
import { Navigate } from "react-router-dom";
import authService from "../../Services/authService";

const Callback = () => {
    const win: Window = window;
    authService.signInCallback().then(() => {
        window.history.replaceState({},
            window.document.title,
            window.location.origin + window.location.pathname);
        win.location = "http://localhost:3000/";
    });
    return (
        <div>
            <Navigate to="/" replace={true} />
        </div>
    );
}

export default Callback;