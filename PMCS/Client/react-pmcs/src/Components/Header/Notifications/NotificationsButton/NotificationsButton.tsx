import React from 'react';
import IconButton from '@mui/material/IconButton'
import CircleNotificationsIcon from '@mui/icons-material/CircleNotifications';
import s from './NotificationsButton.module.css';

type NotificationsButtonProps = {
    onToggleNotificationsList: () => void;
    isUserNotified: boolean;
}

const NotificationsButton: React.FC<NotificationsButtonProps> = ({ onToggleNotificationsList, isUserNotified }) => {

    const buttonColor = isUserNotified ? 'success' : 'default';

    return (
        <div className={s.button}>
            <IconButton onClick={onToggleNotificationsList} color={buttonColor}>
                <CircleNotificationsIcon />
            </IconButton>
        </div>
    );
}

export default NotificationsButton;