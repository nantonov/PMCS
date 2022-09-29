import React from 'react';
import s from './Pet.module.css'
import LastActivityList from './LastActivityList/LastActivityList';
import PetHeader from './Header/PetHeader';
import PetInfo from './Info/PetInfo';

const Pet = (props) => {
    return (
        <article className={s.item}>
            <PetHeader pet={props.pet} dispatch={props.dispatch}/>
            <PetInfo pet={props.pet} />
            <LastActivityList pet={props.pet} />
        </article>
    );
}

export default Pet;