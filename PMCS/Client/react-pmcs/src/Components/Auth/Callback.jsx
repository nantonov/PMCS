import React from 'react';
import { Navigate } from "react-router-dom";
import authService from "../../Services/authService";

const Callback = () => {
    authService.signInCallback();
    return (
        <div>
            <Navigate to="/pets" replace={true} />
        </div>
    );
}

export default Callback;