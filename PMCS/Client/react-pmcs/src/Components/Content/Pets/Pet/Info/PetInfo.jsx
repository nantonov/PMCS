import React from 'react';
import s from './PetInfo.module.css'

const PetInfo = (props) => {
    const { pet } = props;

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

