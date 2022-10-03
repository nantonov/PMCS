import React, {useState} from 'react';
import s from './Pet.module.css'
import LastActivityList from './LastActivityList/LastActivityList';
import PetHeader from './Header/PetHeader';
import PetInfo from './Info/PetInfo';
import EditPetModal from './../Pet/Modal/EditPetModal';
import InfoPetModal from './../Pet/Modal/InfoPetModal';


const Pet = props => {

    const {pet, editPet, deletePet} = props;
    const [isEditModalOpened, setEditModalOpen] = useState(false);
    const [isInfoModalOpened, setInfoModalOpen] = useState(false);

    return (
        <article className={s.item}>
            {isEditModalOpened ? <EditPetModal pet={pet} editPet={editPet} setEditModalOpen = {setEditModalOpen}/> : null}
            {isInfoModalOpened ? <InfoPetModal pet={pet} setInfoModalOpen = {setInfoModalOpen}/> : null}
            <PetHeader pet={pet} 
            deletePet={deletePet}
            setEditModalOpen = {setEditModalOpen}/>
            <PetInfo pet={pet} />
            <LastActivityList pet={pet} setInfoModalOpened={setInfoModalOpen}/>
        </article>
    );
}

export default Pet;