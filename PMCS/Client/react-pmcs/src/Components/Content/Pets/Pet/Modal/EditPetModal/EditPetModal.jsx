import React, { useEffect, useState, useCallback } from 'react';
import s from '../PetModal.module.css';
import { toServerFormatDate } from '../../../../../../utils/dateFormatitng';
import EditPetForm from '../../../../../Forms/EditPetForm';

const EditPetModal = ({ pet, setEditModalOpen, editPet, errors }) => {
    const [isSuccess, setIsSuccess] = useState(false);

    useEffect(() => {
        if (errors.length > 0) {
            setIsSuccess(false);
        }
    }, [errors]);

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

        setIsSuccess(true);
    }

    return (
        <div className={s.modal}>
            <EditPetForm isSuccess={isSuccess}
                onSubmit={updatePetData}
                errors={errors}
                pet={pet} />
        </div>);
}

export default EditPetModal;