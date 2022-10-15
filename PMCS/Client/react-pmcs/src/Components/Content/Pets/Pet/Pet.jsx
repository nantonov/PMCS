import React, {useState} from 'react';
import s from './Pet.module.css'
import LastActivityList from './LastActivityList/LastActivityList';
import PetHeader from './Header/PetHeader';
import PetInfo from './Info/PetInfo';
import EditPetModal from './Modal/EditPetModal/EditPetModal';
import InfoPetModal from './Modal/InfoPetModal/InfoPetModal';


const Pet = ({pet, editPet, deletePet,  setIsPetDeleted, errors, cleanErrors}) => {
    const [isEditModalOpened, setEditModalOpen] = useState(false);
    const [isInfoModalOpened, setInfoModalOpen] = useState(false);

    return (
        <article className={s.item}>
            {isEditModalOpened ? <EditPetModal errors={errors} pet={pet} editPet={editPet} setEditModalOpen = {setEditModalOpen}/> : null}
            {isInfoModalOpened ? <InfoPetModal pet={pet} setInfoModalOpen = {setInfoModalOpen}/> : null}
            <PetHeader pet={pet} 
            deletePet={deletePet}
            setIsPetDeleted={setIsPetDeleted}
            setEditModalOpen = {setEditModalOpen}
            cleanErrors={cleanErrors}/>
            <PetInfo pet={pet} />
            <LastActivityList pet={pet} setInfoModalOpened={setInfoModalOpen}/>
        </article>
    );
}

export default Pet;