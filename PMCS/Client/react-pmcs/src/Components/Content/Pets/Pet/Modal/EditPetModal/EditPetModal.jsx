import React, { useEffect, useState, useCallback } from 'react';
import s from '../../../../../Shared/Modal/Modal.module.css';
import { toServerFormatDate } from '../../../../../../utils/dateFormatitng';
import EditPetForm from '../../../../../Forms/EditPetForm';

const EditPetModal = ({ pet, setEditModalOpen, editPet }) => {
    const escFunction = useCallback((event) => {
        if (event.key === "Escape") {
            setEditModalOpen(false);
        }
    });

    useEffect(() => {
        document.addEventListener("keydown", escFunction, false);

        return () => {
            document.removeEventListener("keydown", escFunction, false);
        };
    });

    const updatePetData = (values) => {
        editPet({
            name: values.name,
            weight: values.weight,
            id: pet.id,
            birthDate: toServerFormatDate(pet.birthDate),
            info: values.info
        });
    }

    return (
        <div className={s.modal}>
            <EditPetForm
                onSubmit={updatePetData}
                pet={pet} />
        </div>);
}

export default EditPetModal;