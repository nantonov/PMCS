import React from 'react';
import s from './Pet.module.css'
import LastActivityList from './LastActivityList/LastActivityList';
import PetHeader from './Header/PetHeader';
import PetInfo from './Info/PetInfo';

//Temporary test data just to see how the page will look like with real data
let activities = [{ name: "Walking", date: "12.12.2021 21:18" },
{ name: "Meal", date: "12.12.2021 21:18" },
{ name: "Vaccine", date: "12.12.2021 21:18" }];

const Pet = (props) => {
    return (
        <article className={s.item}>
            <PetHeader pet={props.pet} />
            <PetInfo pet={props.pet} />
            <LastActivityList activities={activities} />
        </article>
    );
}

export default Pet;