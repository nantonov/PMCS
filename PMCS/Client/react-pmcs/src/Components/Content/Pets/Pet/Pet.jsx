import React from 'react';
import s from './Pet.module.css'
import LastActivityList from './LastActivityList/LastActivityList';
import PetHeader from './Header/PetHeader';
import PetInfo from './Info/PetInfo';

const Pet = (props) => {
    return (
        <article className={s.item}>
            <PetHeader pet={props.pet} />
            <PetInfo pet={props.pet} />
            <LastActivityList activities={props.pet.activities} />
        </article>
    );
}

export default Pet;