import React from 'react';
import s from './Reminders.module.css'
import AddCircleIcon from '@mui/icons-material/AddCircle';
import { IconButton } from '@mui/material';
import { useState } from 'react';
import AddReminderModal from './Modals/AddReminderModal';
import { createReminder } from '../../../redux/Reminders/actionCreators';

type RemindersProps = {
    createReminder: typeof createReminder;
    content: JSX.Element | Array<JSX.Element>
}

const Reminders : React.FC<RemindersProps> = ({ content, createReminder }) => {
    const [isAddModalOpened, setAddModalOpen] = useState<boolean>(false);

    function handleClick() : void {
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