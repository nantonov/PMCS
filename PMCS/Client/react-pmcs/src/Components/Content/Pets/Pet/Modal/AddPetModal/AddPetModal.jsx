import React, { useState, useCallback, useEffect } from 'react';
import AddPetForm from '../../../../../Forms/AddPetForm';
import s from '../PetModal.module.css'

const AddPetModal = ({ setAddModalOpen, addPet}) => {

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
    }

    return (
        <div className={s.modal}>
            <AddPetForm onSubmit={addNewPet}/>
        </div>
    );
}

export default AddPetModal;