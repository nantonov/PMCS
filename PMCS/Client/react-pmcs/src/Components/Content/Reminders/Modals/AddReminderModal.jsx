import React, { useCallback, useEffect } from 'react';
import s from '../../../Shared/Modal/Modal.module.css';
import AddReminderForm from '../../../Forms/AddReminderForm';
import { connect } from 'react-redux';
import { fetchPets } from '../../../../redux/Pets/actionCreators';

const AddReminderModal = ({ setAddModalOpen, createReminder, pets, fetchPets }) => {

    useEffect(() => {
        fetchPets();
    }, [pets]);

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

    const onSubmit = (values) => {
        createReminder({
            petId: values.petId,
            triggerDateTime: values.triggerDateTime,
            notificationMessage: values.notificationMessage,
            notificationType: values.notificationType,
            actionToRemindType: values.actionToRemindType,
        });
    }

    return (
        <div className={s.modal}>
            <AddReminderForm onSubmit={onSubmit} pets={pets}/>
        </div>
    );
}

function mapStateToProps(state) {
    return {
        pets: state.petsPage.pets,
    };
}

export default connect(mapStateToProps, {fetchPets})(AddReminderModal);