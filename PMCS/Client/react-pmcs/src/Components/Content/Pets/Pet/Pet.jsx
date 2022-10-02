import React, {useState} from 'react';
import s from './Pet.module.css'
import LastActivityList from './LastActivityList/LastActivityList';
import PetHeader from './Header/PetHeader';
import PetInfo from './Info/PetInfo';
import EditPetModal from './../Pet/Modal/EditPetModal';

const Pet = (props) => {
    const [isEditModalOpened, setEditModalOpen] = useState(false);

    return (
        <article className={s.item}>
            {isEditModalOpened ? <EditPetModal pet={props.pet} editPet={props.editPet} setEditModalOpen = {setEditModalOpen}/> : null}
            <PetHeader pet={props.pet} 
            deletePet={props.deletePet}
            setEditModalOpen = {setEditModalOpen}/>
            <PetInfo pet={props.pet} />
            <LastActivityList pet={props.pet} />
        </article>
    );
}

export default Pet;