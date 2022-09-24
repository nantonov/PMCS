import React from 'react';
import s from './Activities.module.css'
import Activity from './Activity/Activity';

const Activities = (props) => {
    return (
        <article className={s.wrapper}>
            <Activity />
        </article>
    );
}

export default Activities;