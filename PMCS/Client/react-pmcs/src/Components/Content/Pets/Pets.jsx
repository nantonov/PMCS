import React, { useEffect, useState } from 'react';
import s from './Pets.module.css';
import AddPetCell from './Pet/AddPetCell';
import AddPetModal from './Pet/Modal/AddPetModal';

const Pets = ({ content, createPet }) => {
    
    const [isAddModalOpened, setAddModalOpen] = useState(false);
    return (
        <section className={s.wrapper}>
            {isAddModalOpened ? <AddPetModal addPet={createPet} setAddModalOpen={setAddModalOpen} /> : null}
            {content}
            <AddPetCell setAddModalOpen={setAddModalOpen} />
        </section>
    );
}

export default Pets;