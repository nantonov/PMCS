import React from 'react';
import { Navigate } from "react-router-dom";
import authService from "../../Services/authService";

const Refresh = () => {
    authService.signInSilentCallback();
    return (
        <div>
            <Navigate to="/" replace={true} />
        </div>
    );
}

export default Refresh;