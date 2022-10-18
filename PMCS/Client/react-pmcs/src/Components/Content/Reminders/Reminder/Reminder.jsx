import React from 'react';
import s from './Reminder.module.css'


const Reminder = ({ reminder }) => {
    return (
        <article className={s.item}>
            <div>{reminder.description}</div>
            <div>Last modified: {reminder.lastModified}</div>
            <div>Notify: {reminder.triggerDateTime}</div>
            <div>Status: {reminder.status === 0 ? 'To do' : 'Done!'}</div>
        </article>
    );
}

export default Reminder;