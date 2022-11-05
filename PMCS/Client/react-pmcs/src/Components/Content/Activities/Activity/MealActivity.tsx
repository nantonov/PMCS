import React from 'react';
import s from './Activity.module.css'
import { IMeal } from '../../../../common/models/IMeal';

type MealProps = Omit<IMeal, "id">;

const MealActivity: React.FC<MealProps> = ({ dateTime, title, description, pet }) => {
    return (
        <article className={s.item}>
            <div>
                Title: {title}
            </div>
            <div>
                Description: {description}
            </div>
            <div>
                DateTime: {dateTime}
            </div>
            <div>
                Pet name: {pet?.name}
            </div>
        </article>
    );
}

export default MealActivity;