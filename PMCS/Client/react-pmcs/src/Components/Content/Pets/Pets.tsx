import React, { useState } from 'react';
import s from './Pets.module.css';
import AddPetCell from './Pet/AddPetCell';
import AddPetModal from './Pet/Modal/AddPetModal/AddPetModal';
import {createPet} from '../../../redux/Pets/actionCreators'

type PetsProps = {
    createPet: typeof createPet;
    content: JSX.Element | Array<JSX.Element>
}

const Pets : React.FC<PetsProps> = ({ content, createPet }) => {

    const [isAddModalOpened, setAddModalOpen] = useState<boolean>(false);
    return (
        <section className={s.wrapper}>
            {isAddModalOpened ? <AddPetModal addPet={createPet} setAddModalOpen={setAddModalOpen} /> : null}
            {content}
            <AddPetCell setAddModalOpen={setAddModalOpen}/>
        </section>
    );
}

export default Pets;