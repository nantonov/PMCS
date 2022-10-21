import React, { useState, useEffect } from 'react';
import IconButton from '@mui/material/IconButton'
import CircleNotificationsIcon from '@mui/icons-material/CircleNotifications';
import s from './NotificationsButton.module.css';
import { HubConnectionBuilder, HttpTransportType } from '@microsoft/signalr';
import { useAuthContext } from '../../Auth/AuthProvider';

const NotificationsButton = () => {
    const [connection, setConnection] = useState(null);
    const [messages, setMesages] = useState([]);
    const [isNotificationsModalOpened, setNotificationsModalOpened] = useState(false);

    const { isAuth, user } = useAuthContext();

    const onButtonClick = async () => {
        await startRecievingMessages();
        setNotificationsModalOpened(!isNotificationsModalOpened);
    }

    const startRecievingMessages = async () => {
        if (!isAuth) return;

        try {
            const connection = new HubConnectionBuilder().
                withUrl('https://localhost:44340/notificationHub', {
                    transport: HttpTransportType.WebSockets,
                    skipNegotiation: true,
                    accessTokenFactory: () => user.access_token
                }).
                withAutomaticReconnect().
                build();

            connection.on("ReceiveNotification", (message) => {
                setMesages(messages.push(message));
                console.log('new message: ', message);
            });

            await connection.start();
            setConnection(connection);
        }
        catch (e) {
            console.log(e);
        }
    }

    return (
        <div className={s.button}>
            <IconButton onClick={onButtonClick}>
                <CircleNotificationsIcon />
            </IconButton>
            {isNotificationsModalOpened && <div className={s.notifications}>
                <div>
                    Messages:
                </div>
               {messages.map((message, index) => <div key={index} className={s.notification}>{message}</div>)}
            </div>}
        </div>
    );
}

export default NotificationsButton;