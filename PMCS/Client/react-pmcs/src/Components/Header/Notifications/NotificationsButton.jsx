import React from 'react';
import IconButton from '@mui/material/IconButton'
import CircleNotificationsIcon from '@mui/icons-material/CircleNotifications';
import s from './NotificationsButton.module.css';

const NotificationsButton = () => {
    return (
        <div>
             <IconButton>
        <CircleNotificationsIcon />
            </IconButton>
        </div>
    );
}

export default NotificationsButton;