import React, { SetStateAction, useCallback, useEffect } from 'react';
import AddPetForm from '../../../../../Forms/AddPetForm';
import s from '../../../../../Shared/Modal/Modal.module.css';
import { createPet } from '../../../../../../redux/Pets/actionCreators'
import { ICreatePetRequest } from '../../../../../../common/requests/Pet/ICreatePetRequest';

type AddPetModalProps = {
    setAddModalOpen: React.Dispatch<SetStateAction<boolean>>,
    addPet: typeof createPet
}

const AddPetModal : React.FC<AddPetModalProps> = ({ setAddModalOpen, addPet}) => {

    const escFunction = useCallback((event : KeyboardEvent) => {
        if (event.key === "Escape") {
            setAddModalOpen(false);
        }
    }, []);

    useEffect(() => {
        document.addEventListener("keydown", escFunction, false);

        return () => {
            document.removeEventListener("keydown", escFunction, false);
        };
    });

    const addNewPet = (values : ICreatePetRequest) => {
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