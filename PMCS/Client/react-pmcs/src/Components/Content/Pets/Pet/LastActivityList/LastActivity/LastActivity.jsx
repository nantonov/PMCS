import React from 'react';
import s from './LastActivity.module.css';

const LastActivity = (props) => {
    return (
        <div className={s.item}>
            <div className={s.name}>
                {props.name}
            </div>
            <div className={s.date}>
                on {props.date}
            </div>
        </div >
    );
}

export default LastActivity;