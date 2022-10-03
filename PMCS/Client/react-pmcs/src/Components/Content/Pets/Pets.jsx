import React, {useState} from 'react';
import s from './Pets.module.css';
import Pet from './Pet/Pet';
import NoContent from './NoContent';
import AddPetCell from './Pet/AddPetCell';
import AddPetModal from './Pet/Modal/AddPetModal';


const Pets = props => {
    const [isAddModalOpened, setAddModalOpen] = useState(false);
    const { pets, editPet, deletePet, addPet } = props;

    let petsElements = props.pets.map(petItem =>
        <Pet key={petItem.id}
            pet={petItem}
            editPet={editPet}
            deletePet={deletePet} />);

    let content = pets.length === 0 ? <NoContent /> : petsElements;

    return (
        <section className={s.wrapper}>
            {isAddModalOpened ? <AddPetModal addPet={addPet} setAddModalOpen = {setAddModalOpen}/> : null}
            {content}
            <AddPetCell setAddModalOpen={setAddModalOpen}/>
        </section>
    );
}

export default Pets;