import React from 'react';
import s from './LastActivity.module.css';

interface ILastActivity {
    dateTime: string;
}

type LastActivityProps = {
    activity: ILastActivity
}

const LastActivity: React.FC<LastActivityProps> = ({ activity }) => {

    return (
        <div className={s.item}>
            <div className={s.date}>
                on {activity.dateTime}
            </div>
        </div >
    );
}

export default LastActivity;