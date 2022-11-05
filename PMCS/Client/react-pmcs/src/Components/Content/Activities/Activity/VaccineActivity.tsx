import React from 'react';
import s from './Activity.module.css'
import { IVaccine } from '../../../../common/models/IVaccine';

type VaccineProps = Omit<IVaccine, "id">;

const VaccineActivity: React.FC<VaccineProps> = ({ dateTime, title, description, pet }) => {
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

export default VaccineActivity;