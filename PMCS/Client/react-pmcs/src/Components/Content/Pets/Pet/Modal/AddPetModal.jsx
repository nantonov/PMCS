import React, { useState, useCallback, useEffect } from 'react';
import s from './EditPetModal.module.css'

const AddPetModal = props => {
    const {setAddModalOpen} = props;
    const [inputs, setInputs] = useState({});

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

        setAddModalOpen(false);
    }

    return (
        <div className={s.modal}>
            <form className={s.formBox} onSubmit={handleSubmit}>
                <header>Add pet</header>
                <label>Name:   
                    <input
                        type="text"
                        name="name"
                        required
                        value={inputs.name || ""}
                        onChange={handleChange}
                    />
                </label>
                <label>Info:   
                    <textarea
                        type="text"
                        name="name"
                        required
                        value={inputs.info || ""}
                        onChange={handleChange}
                    />
                </label>
                <label>Weight:
                    <input
                        type="number"
                        step="0.1"
                        name="weight"
                        required
                        value={inputs.weight || ""}
                        onChange={handleChange}
                    />
                </label>
                <label>Birth Date:   
                    <input
                        type="date"
                        name="birthDate"
                        required
                        value={inputs.birthDate || ""}
                        max={Date.now()}
                        onChange={handleChange}
                    />
                </label>
                <button type="submit">Submit</button>
            </form>
        </div>);
}

export default AddPetModal;