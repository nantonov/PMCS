import React from 'react';
import s from './LastActivity.module.css';

const LastActivity = (props) => {
    return (
        <div className={s.item}>
            <div className={s.name}>
                {props.item.name}
            </div>
            <div className={s.date}>
                on {props.item.date}
            </div>
        </div >
    );
}

export default LastActivity;