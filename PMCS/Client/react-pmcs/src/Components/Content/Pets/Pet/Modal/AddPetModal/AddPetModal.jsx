import React, { useState, useCallback, useEffect } from 'react';
import AddPetForm from '../../../../../Forms/AddPetForm';
import s from '../PetModal.module.css'

const AddPetModal = ({ setAddModalOpen, addPet, errors }) => {
    const [isSuccess, setIsSuccess] = useState(false);

    useEffect(() => {
        if (errors.length > 0) {
            setIsSuccess(false);
        }
    }, [errors]);

    const escFunction = useCallback((event) => {
        if (event.key === "Escape") {
            setAddModalOpen(false);
        }
    });

    useEffect(() => {
        document.addEventListener("keydown", escFunction, false);

        return () => {
            document.removeEventListener("keydown", escFunction, false);
        };
    });

    const addNewPet = (values) => {
        addPet({
            name: values.name,
            weight: values.weight,
            birthDate: values.birthDate,
            info: values.info,
        });

        setIsSuccess(true);
    }

    return (
        <div className={s.modal}>
            <AddPetForm isSuccess={isSuccess}
                onSubmit={addNewPet}
                errors={errors} />
        </div>
    );
}

export default AddPetModal;