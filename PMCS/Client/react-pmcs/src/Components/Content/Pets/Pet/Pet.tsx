import React, { SetStateAction, useState } from 'react';
import s from './Pet.module.css'
import LastActivityList from './LastActivityList/LastActivityList';
import PetHeader from './Header/PetHeader';
import PetInfo from './Info/PetInfo';
import EditPetModal from './Modal/EditPetModal/EditPetModal';
import InfoPetModal from './Modal/InfoPetModal/InfoPetModal';
import { IPet } from '../../../../common/models/IPet'
import * as petsActionsCreators from '../../../../redux/Pets/actionCreators'

type PetProps = {
    pet: IPet,
    editPet: typeof petsActionsCreators.editPet,
    deletePet: typeof petsActionsCreators.deletePet,
    setIsPetDeleted: React.Dispatch<SetStateAction<boolean>>

}

const Pet: React.FC<PetProps> = ({ pet, editPet, deletePet, setIsPetDeleted }) => {
    const [isEditModalOpened, setEditModalOpen] = useState<boolean>(false);
    const [isInfoModalOpened, setInfoModalOpen] = useState<boolean>(false);

    return (
        <article className={s.item}>
            {isEditModalOpened ? <EditPetModal pet={pet} editPet={editPet} setEditModalOpen={setEditModalOpen} /> : null}
            {isInfoModalOpened ? <InfoPetModal pet={pet} setInfoModalOpen={setInfoModalOpen} /> : null}
            <PetHeader pet={pet}
                deletePet={deletePet}
                setIsPetDeleted={setIsPetDeleted}
                setEditModalOpen={setEditModalOpen} />
            <PetInfo pet={pet} />
            <LastActivityList pet={pet} setInfoModalOpened={setInfoModalOpen} />
        </article>
    );
}

export default Pet;