import React, { useState } from 'react';
import s from './EditPetModal.module.css'

const EditPetModal = props => {

    const { pet, setEditModalOpen, editPet } = props;
    const [inputs, setInputs] = useState({});

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
                <label>Name:
                    <input
                        type="text"
                        name="name"
                        required
                        value={inputs.name || pet.name}
                        onChange={handleChange}
                        placeholder={pet.name}
                    />
                </label>
                <label>Info</label>
                <textarea className={s.info}
                    type="text"
                    name="info"
                    value={inputs.info || pet.info}
                    onChange={handleChange}
                ></textarea>
                <label>Weight:
                    <input
                        type="number"
                        step="0.1"
                        name="weight"
                        required
                        value={inputs.weight || pet.weight}
                        onChange={handleChange}
                        placeholder={pet.weight}
                    />
                </label>
                <button type="submit">Submit</button>
                <button onClick={onCancelled}>Cancel</button>
            </form>
        </div>);
}

export default EditPetModal;