import React from 'react';
import s from './PetInfo.module.css'

const PetInfo = (props) => {
    return (<article className={s.wrapper}>
        <div className={s.info}>
            {props.pet.info}
        </div>
        <div className={s.numeralInfo}>
            <div className={s.birth}>
                Birth Date: {props.pet.birthDate}
            </div>
            <div className={s.weight}>
                Weight: {props.pet.weight}
            </div>
        </div>
    </article>
    );
}

export default PetInfo;

