import React from 'react';
import s from './Reminders.module.css'

const Reminders = ({content}) => {
    return (
        <article className={s.wrapper}>
            {content}
        </article>
    );
}

export default Reminders;