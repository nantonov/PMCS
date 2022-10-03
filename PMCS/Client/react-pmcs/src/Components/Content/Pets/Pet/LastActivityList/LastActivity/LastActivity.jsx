import React from 'react';
import s from './LastActivity.module.css';

const LastActivity = (props) => {
    const { date, name } = props;

    return (
        <div className={s.item}>
            <div className={s.name}>
                {name}
            </div>
            <div className={s.date}>
                on {date}
            </div>
        </div >
    );
}

export default LastActivity;