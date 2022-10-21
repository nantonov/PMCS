import React, { useState, useEffect } from 'react';
import s from './MessagesList.module.css';
import { Button } from '@mui/material';
import ClearIcon from '@mui/icons-material/Clear';

const MessagesList = ({ messages, clearMessages, isUserNotified }) => {

    const messagesElements = messages.map((message, index) => <div key={index} className={s.notification}>{message}</div>);
    const content = isUserNotified ? messagesElements : <div className={s.noContent}>No notifications yet...</div>;

    return (
        <div className={s.wrapper}>
            <div className={s.title}>
                Messages
            </div>
            {content}
            {isUserNotified ? <Button className={s.clearButton} color='error' startIcon={<ClearIcon />} onClick={clearMessages}>Clear</Button> : null}
        </div>
    );
}

export default MessagesList;