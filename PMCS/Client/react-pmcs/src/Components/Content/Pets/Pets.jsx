import React from 'react';
import s from './Pets.module.css'
import Pet from './Pet/Pet'

const Pets = (props) => {
    let petsElements = props.petsPage.pets.map(petItem => <Pet pet = {petItem}/>);
    
    return (
        <section className={s.wrapper}>
            {petsElements}
        </section>
    );
}

export default Pets;