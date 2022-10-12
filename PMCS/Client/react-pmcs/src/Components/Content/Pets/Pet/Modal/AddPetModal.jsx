import React, { useState, useCallback, useEffect } from 'react';
import s from './AddPetModal.module.css'

const AddPetModal = props => {
    const [inputs, setInputs] = useState({});

    const { setAddModalOpen, addPet } = props;

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

    const handleChange = (event) => {
        const name = event.target.name;
        const value = event.target.value;
        setInputs(values => ({ ...values, [name]: value }))
    }

    const handleSubmit = (event) => {
        event.preventDefault();

        addPet({
            name: inputs.name,
            weight: inputs.weight,
            birthDate: inputs.birthDate,
            info: inputs.info,
        });
        setAddModalOpen(false);
    }

    return (
        <div className={s.wrapper}>
            <div className={s.modal}>
                <form className={s.formBox} onSubmit={handleSubmit}>
                    <header>Add pet</header>
                    <label>Name   </label>
                    <input
                        type="text"
                        name="name"
                        required
                        value={inputs.name || ""}
                        onChange={handleChange}
                    />
                    <label>Info</label>
                    <textarea className={s.info}
                        type="text"
                        name="info"
                        value={inputs.info || ""}
                        onChange={handleChange}
                    ></textarea>
                    <label>Weight</label>
                    <input
                        type="number"
                        step="0.1"
                        name="weight"
                        required
                        value={inputs.weight || ""}
                        onChange={handleChange}
                    />
                    <label>Birth Date</label>
                    <input
                        type="date"
                        name="birthDate"
                        required
                        value={inputs.birthDate || ""}
                        max={Date.now()}
                        onChange={handleChange}
                    />
                    <button type="submit">Submit</button>
                </form>
            </div>
        </div>);
}

export default AddPetModal;