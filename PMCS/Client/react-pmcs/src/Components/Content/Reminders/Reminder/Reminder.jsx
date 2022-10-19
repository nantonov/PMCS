import React, { useState } from 'react';
import s from './Reminder.module.css'
import { IconButton, Stack } from '@mui/material';
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';
import EditReminderModal from '../Modals/EditReminderModal';
import Button from '@mui/material/Button';
import DoneAllIcon from '@mui/icons-material/DoneAll';
import { Status } from '../../../../Enums/reminderEnums.ts'
import AlarmIcon from '@mui/icons-material/AlarmOn';

const Reminder = ({ reminder, editReminder, deleteReminder, setIsReminderDeleted, setReminderStatusAsDone, resetReminderStatus }) => {

    const [isEditModalOpened, setEditModalOpen] = useState(false);

    const statusTaskSign = reminder.status === Status.ToDo ? 'In progress... ' + String.fromCharCode(9998) : 'Completed ' + String.fromCharCode(9745);
    const notificationSentIcon = reminder.isTriggered ? <AlarmIcon color="action"/> : null;

    const onDeleteButtonClick = () => {
        let id = reminder.id;
        deleteReminder(id);
        setIsReminderDeleted(true);
    }

    const onEditButtonClick = () => {
        setEditModalOpen(true);
    }

    const onCompleteButtonClick = () => {
        let id = reminder.id;
        setReminderStatusAsDone(id);
    }

    return (
        <article className={s.item}>
            {isEditModalOpened ? <EditReminderModal reminder={reminder} editReminder={editReminder} setEditModalOpen={setEditModalOpen} /> : null}
            <header>
                <div className={s.description}>{reminder.description} {notificationSentIcon}</div>
                <div className={s.buttons}>
                    {
                        !reminder.isTriggered &&
                        <Stack direction="row" spacing={1}> <IconButton aria-label="edit" size="small" onClick={onEditButtonClick}>
                            <EditIcon fontSize='small' />
                        </IconButton>
                            <IconButton aria-label="delete" size="small" onClick={onDeleteButtonClick}>
                                <DeleteIcon />
                            </IconButton>
                        </Stack>
                    }
                </div>
            </header>
            <div className={s.info}>
                <div>Notify: {reminder.triggerDateTime}</div>
                <div>Message: {reminder.notificationMessage}</div>
                <div>Last modified: {reminder.lastModified}</div>
                <div>Status: {statusTaskSign}</div>
            </div>
            {
                reminder.status === Status.ToDo ? <Button color='success' startIcon={<DoneAllIcon />} className={s.statusButton} onClick={onCompleteButtonClick}>
                    <span>Complete</span></Button> : null
            }
            {
                reminder.status === Status.Done ? <Button color='error' startIcon={<DeleteIcon />} className={s.deleteButton} onClick={onDeleteButtonClick}>
                    <span>Delete</span></Button> : null
            }
        </article>
    );
}

export default Reminder;