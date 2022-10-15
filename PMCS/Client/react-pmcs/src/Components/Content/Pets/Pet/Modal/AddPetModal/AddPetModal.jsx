import React, { useState, useCallback, useEffect } from 'react';
import s from '../PetModal.module.css'

const AddPetModal = ({ setAddModalOpen, addPet, errors }) => {
    const [inputs, setInputs] = useState({});
    const [isSuccess, setIsSuccess] = useState(false);

    const escFunction = useCallback((event) => {
        if (event.key === "Escape") {
            setAddModalOpen(false);
        }
    });

    useEffect(() => {
        if (errors.length > 0) {
            setIsSuccess(false);
        }
    }, [errors.length]);

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

        setInputs({});
        setIsSuccess(true);
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
                        min="0.1"
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
                    {!isSuccess ? <div className={s.error}>{errors}</div> : null}
                    {isSuccess ? <div className={s.success}>You added pet successfully!</div> : null}
                    <button type="submit">Submit</button>
                </form>
            </div>
        </div>);
}

export default AddPetModal;