import React, { useCallback, useEffect } from 'react';
import s from './InfoPetModal.module.css'

const InfoPetModal = props => {
    const { pet, setInfoModalOpen } = props;

    const escFunction = useCallback((event) => {
        if (event.key === "Escape") {
            setInfoModalOpen(false);
        }
    }, []);

    useEffect(() => {
        document.addEventListener("keydown", escFunction, false);

        return () => {
            document.removeEventListener("keydown", escFunction, false);
        };
    }, []);

    let walking = pet.walkings.map(item => <div className={s.walkingsWrapper}>
        <div className={s.title}>{item.title}</div>
        <div className={s.description}>{item.description}</div>
        <div>Started: {item.stared}</div>
        <div>Finished: {item.finished}</div>
    </div>);

    return (
        <div className={s.modal}>
            <div className={s.wrapper}>
                <div className={s.petName}>{pet.name}</div>
                <h3>Walkings</h3>
                <div>
                    {walking}
                </div>
                <h3>Meals</h3>
                <div>
                    {walking}
                </div>
                <h3>Vaccines</h3>
                <div>
                    {walking}
                </div>
            </div>
        </div>);
}

export default InfoPetModal;