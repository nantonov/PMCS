import React from 'react';
import { IPet } from '../../../../../common/models/IPet';
import s from './PetInfo.module.css'

type PetInfoProps = {
    pet: IPet
}

const PetInfo: React.FC<PetInfoProps> = ({ pet }) => {
    return (<article className={s.wrapper}>
        <div className={s.info}>
            {!pet.info && <div>No description provided.</div>}
            {pet.info}
        </div>
        <div className={s.numeralInfo}>
            <div className={s.birth}>
                Birth Date: {pet.birthDate}
            </div>
            <div className={s.weight}>
                Weight: {pet.weight}kg
            </div>
        </div>
    </article>
    );
}

export default PetInfo;

