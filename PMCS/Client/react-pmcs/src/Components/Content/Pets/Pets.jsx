import React from 'react';
import s from './Pets.module.css';
import Pet from './Pet/Pet';
import NoContent from './NoContent';

const Pets = props => {

    const { pets, editPet, deletePet } = props;

    let petsElements = props.pets.map(petItem =>
        <Pet key={petItem.id}
            pet={petItem}
            editPet={editPet}
            deletePet={deletePet} />);

    let content = pets.length === 0 ? <NoContent /> : petsElements;

    return (
        <section className={s.wrapper}>
            {content}
        </section>
    );
}

export default Pets;