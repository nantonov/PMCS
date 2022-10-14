import React from 'react';
import s from './LastActivity.module.css';

const LastActivity = ({ activity }) => {

    return (
        <div className={s.item}>
            <div className={s.date}>
                on {activity.dateTime}
            </div>
        </div >
    );
}

export default LastActivity;