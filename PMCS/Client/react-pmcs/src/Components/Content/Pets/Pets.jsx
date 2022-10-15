import React, { useEffect, useState } from 'react';
import s from './Pets.module.css';
import AddPetCell from './Pet/AddPetCell';
import AddPetModal from './Pet/Modal/AddPetModal/AddPetModal';

const Pets = ({ content, createPet, errors, cleanErrors }) => {

    const [isAddModalOpened, setAddModalOpen] = useState(false);
    return (
        <section className={s.wrapper}>
            {isAddModalOpened ? <AddPetModal errors={errors} addPet={createPet} setAddModalOpen={setAddModalOpen} /> : null}
            {content}
            <AddPetCell setAddModalOpen={setAddModalOpen} cleanErrors={cleanErrors} />
        </section>
    );
}

export default Pets;