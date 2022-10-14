import React, { useState } from 'react';
import s from './PetModal.module.css'

const EditPetModal = props => {

    const { pet, setEditModalOpen, editPet } = props;
    const [inputs, setInputs] = useState({name: pet.name, weight: pet.weight, info: pet.info, id: pet.id, birthDate: pet.birthDate});

    const handleChange = (event) => {
        const name = event.target.name;
        const value = event.target.value;
        setInputs(values => ({ ...values, [name]: value }))
    }

    const handleSubmit = (event) => {
        event.preventDefault();

        editPet({ name: inputs.name, weight: inputs.weight, id: pet.id, birthDate: pet.birthDate, info: inputs.info });
        setEditModalOpen(false);
    }

    const onCancelled = () => {
        setEditModalOpen(false);
    }

    return (
        <div className={s.modal}>
            <form className={s.formBox} onSubmit={handleSubmit}>
                <header>Edit pet</header>
                <label>Name</label>
                    <input
                        type="text"
                        name="name"
                        required
                        value={inputs.name}
                        onChange={handleChange}
                    />
                <label>Info</label>
                <textarea className={s.info}
                    type="text"
                    name="info"
                    value={inputs.info}
                    onChange={handleChange}
                ></textarea>
                <label>Weight</label>
                    <input
                        min="0.1"
                        type="number"
                        step="0.1"
                        name="weight"
                        value={inputs.weight}
                        required
                        onChange={handleChange}
                    />
                <button type="submit">Submit</button>
                <button onClick={onCancelled}>Cancel</button>
            </form>
        </div>);
}

export default EditPetModal;