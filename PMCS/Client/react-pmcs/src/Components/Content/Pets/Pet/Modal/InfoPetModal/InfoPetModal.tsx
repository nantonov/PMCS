import React, { useCallback, useEffect, SetStateAction } from 'react';
import s from './InfoPetModal.module.css'
import { IPet } from '../../../../../../common/models/IPet'

type InfoPetModalProps = {
    pet: IPet,
    setInfoModalOpen: React.Dispatch<SetStateAction<boolean>>
}

const InfoPetModal: React.FC<InfoPetModalProps> = props => {
    const { pet, setInfoModalOpen } = props;

    const escFunction = useCallback<(event: KeyboardEvent) => void>((event) => {
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

    let walking = pet.walkings?.map(item => <div className={s.itemWrapper}>
        <div className={s.title}>{item.title}</div>
        <div className={s.description}>{item.description}</div>
        <div>Started: {item.stared}</div>
        <div>Finished: {item.finished}</div>
    </div>);

    let meal = pet.meals?.map(item => <div className={s.itemWrapper}>
        <div className={s.title}>{item.title}</div>
        <div className={s.description}>{item.description}</div>
        <div>Date: {item.dateTime}</div>
    </div>);

    let vaccine = pet.vaccines?.map(item => <div className={s.itemWrapper}>
        <div className={s.title}>{item.title}</div>
        <div className={s.description}>{item.description}</div>
        <div>Date: {item.dateTime}</div>
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
                    {meal}
                </div>
                <h3>Vaccines</h3>
                <div>
                    {vaccine}
                </div>
            </div>
        </div>);
}

export default InfoPetModal;