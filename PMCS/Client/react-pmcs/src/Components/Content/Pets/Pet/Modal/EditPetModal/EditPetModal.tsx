import React, { useEffect, SetStateAction, useCallback } from 'react';
import s from '../../../../../Shared/Modal/Modal.module.css';
import { toServerFormatDate } from '../../../../../../utils/dateFormatitng';
import EditPetForm from '../../../../../Forms/EditPetForm';
import { IPet } from '../../../../../../common/models/IPet'
import { editPet } from '../../../../../../redux/Pets/actionCreators'
import { IUpdatePetRequest } from '../../../../../../common/requests/Pet/IUpdatePetRequest';

type EditPetModalProps = {
    pet: IPet,
    setEditModalOpen: React.Dispatch<SetStateAction<boolean>>,
    editPet: typeof editPet
}

const EditPetModal: React.FC<EditPetModalProps> = ({ pet, setEditModalOpen, editPet }) => {

    const escFunction = useCallback<(event: KeyboardEvent) => void>((event) => {
        if (event.key === "Escape") {
            setEditModalOpen(false);
        }
    }, []);

    useEffect(() => {
        document.addEventListener("keydown", escFunction, false);

        return () => {
            document.removeEventListener("keydown", escFunction, false);
        };
    });

    const updatePetData = (values: IUpdatePetRequest): void => {
        editPet({
            name: values.name,
            weight: values.weight,
            id: pet.id,
            birthDate: toServerFormatDate(pet.birthDate),
            info: values.info
        });

        setEditModalOpen(false);
    }

    return (
        <div className={s.modal}>
            <EditPetForm
                onSubmit={updatePetData}
                pet={pet} />
        </div>);
}

export default EditPetModal;