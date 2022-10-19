import React from 'react';
import s from './Reminder.module.css'

const Reminder = ({ reminder }) => {

    let statusTaskSign = reminder.status === 0 ? 'To do ' + String.fromCharCode(9998) : 'Done! ' + String.fromCharCode(128504);

    return (
        <article className={s.item}>
            <div className={s.description}>{reminder.description}</div>
            <div className={s.info}>
                <div>Notify: {reminder.triggerDateTime}</div>
                <div>Last modified: {reminder.lastModified}</div>
                <div>Status: {statusTaskSign}</div>
            </div>
        </article>
    );
}

export default Reminder;