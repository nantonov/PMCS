import React from 'react';
import { Navigate } from "react-router-dom";
import authService from "../../Services/authService";

const Logout : React.FC = () => {
    authService.signOutCallback();
    return (
        <div>
            <Navigate to="/" replace={true} />
        </div>
    );
}

export default Logout;