import React, { useCallback, useEffect } from 'react';
import s from '../../../Shared/Modal/Modal.module.css';
import EditReminderForm from '../../../Forms/EditReminderForm';

const EditReminderModal = ({ setEditModalOpen, editReminder, reminder }) => {

    const escFunction = useCallback((event) => {
        if (event.key === "Escape") {
            setEditModalOpen(false);
        }
    });

    useEffect(() => {
        document.addEventListener("keydown", escFunction, false);

        return () => {
            document.removeEventListener("keydown", escFunction, false);
        };
    });

    const onSubmit = (values) => {
        editReminder({
            id: reminder.id,
            triggerDateTime: values.triggerDateTime,
            notificationMessage: values.notificationMessage,
            notificationType: values.notificationType,
            actionToRemindType: values.actionToRemindType,
        });
    }

    return (
        <div className={s.modal}>
            <EditReminderForm reminder={reminder} onSubmit={onSubmit} />
        </div>
    );
}

export default EditReminderModal;