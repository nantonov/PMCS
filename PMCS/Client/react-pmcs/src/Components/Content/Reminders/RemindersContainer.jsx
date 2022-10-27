import { connect } from 'react-redux';
import { compose } from 'redux';
import { useState, useEffect } from 'react';
import withAuthRedirect from '../../Shared/Hocs/WithAuthRedirect';
import NoContent from '../NoContent/NoContent';
import Preloader from '../../Preloader/Preloader';
import Reminder from './Reminder/Reminder';
import Reminders from './Reminders';
import { fetchReminders, createReminder, editReminder, deleteReminder, setReminderStatusAsDone } from '../../../redux/Reminders/actionCreators';
import { getIsFetching, getReminders } from '../../../redux/Reminders/selectors';

const RemindersContainer = ({ fetchReminders, createReminder, editReminder, deleteReminder, setReminderStatusAsDone, reminders, isFetching }) => {

    const [isReminderDeleted, setIsReminderDeleted] = useState(false);

    useEffect(() => {
        fetchReminders();
        setIsReminderDeleted(false);
    }, [isReminderDeleted]);

    let remindersElements = reminders.map(item =>
        <Reminder key={item.id}
            reminder={item}
            editReminder={editReminder}
            deleteReminder={deleteReminder}
            setIsReminderDeleted={setIsReminderDeleted}
            setReminderStatusAsDone={setReminderStatusAsDone} />);

    let content = reminders.length === 0 ? <NoContent /> : remindersElements;

    return (
        <div>
            {isFetching ? <Preloader /> : null}
            <Reminders content={content}
                createReminder={createReminder} />
        </div>
    );
}

function mapStateToProps(state) {
    return {
        reminders: getReminders(state),
        isFetching: getIsFetching(state)
    };
}

export default compose(
    connect(mapStateToProps, { fetchReminders, createReminder, editReminder, deleteReminder, setReminderStatusAsDone }),
    withAuthRedirect)(RemindersContainer);
