import React from 'react';
import s from './Pets.module.css'
import Pet from './Pet/Pet'

//Temporary test data just to see how the page will look like with real data
let pets = [{ name: "Johny", info: "Very funny pet.", birthdate: "12/05/2012", weight: "5.0kg" },
            { name: "Alberto", info: "Doggy who is so happy.", birthdate: "28/09/2020", weight: "14.7kg" },
            { name: "Monica", info: "Old and beautiful cat.", birthdate: "28/10/2013", weight: "13.2kg" }];

let petsElements = pets.map(petItem => <Pet pet = {petItem}/>);

const Pets = (props) => {
    return (
        <section className={s.wrapper}>
            {petsElements}
        </section>
    );
}

export default Pets;