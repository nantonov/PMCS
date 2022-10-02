import React from 'react';
import s from './Pets.module.css';
import Pet from './Pet/Pet';
import NoContent from './NoContent';

const Pets = (props) => {

    let petsElements = props.pets.map(petItem =>
        <Pet key={petItem.id} 
        pet={petItem} 
        editPet={props.editPet} 
        deletePet={props.deletePet} />);

    let content = props.pets.length === 0 ? <NoContent/> : petsElements;

    return (
        <section className={s.wrapper}>
           {content}
        </section>
    );
}

export default Pets;