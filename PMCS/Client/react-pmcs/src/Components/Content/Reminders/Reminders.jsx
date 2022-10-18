import React from 'react';
import s from './Reminders.module.css'
import AddCircleIcon from '@mui/icons-material/AddCircle';
import { IconButton } from '@mui/material';
import { useState } from 'react';
import AddReminderModal from './Modals/AddReminderModal';

const Reminders = ({ content, createReminder }) => {
    const [isAddModalOpened, setAddModalOpen] = useState(false);

    function handleClick() {
        setAddModalOpen(true);
    };

    return (
        <article className={s.wrapper}>
          {isAddModalOpened ? <AddReminderModal createReminder={createReminder} setAddModalOpen={setAddModalOpen} /> : null}
            <div className={s.items}>
                <div className={s.addReminderButton}>
                    <IconButton onClick={handleClick}>
                        <AddCircleIcon className={s.icon} />
                    </IconButton>
                </div>
                {content}
            </div>
        </article>
    );
}

export default Reminders;