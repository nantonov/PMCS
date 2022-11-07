import React from 'react';
import s from './Activities.module.css';

type ActivitiesProps = {
    children: React.ReactNode | React.ReactNode[];
}

const Activities: React.FC<ActivitiesProps> = ({ children }) => {
    return (
        <div className={s.wrapper}>
            {children}
        </div>
    );
}

export default Activities;