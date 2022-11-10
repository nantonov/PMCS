import { connect } from 'react-redux';
import { useState, useEffect } from 'react';
import withAuthRedirect from '../../Shared/Hocs/WithAuthRedirect';
import NoContent from '../NoContent/NoContent';
import Preloader from '../../Preloader/Preloader';
import Reminder from './Reminder/Reminder';
import Reminders from './Reminders';
import { fetchReminders, createReminder, editReminder, deleteReminder, setReminderStatusAsDone } from '../../../redux/Reminders/actionCreators';
import { getIsFetching, getReminders } from '../../../redux/Reminders/selectors';
import { RootState } from '../../../redux/types';
import { Dispatch, bindActionCreators } from 'redux';
import { ReactJSXIntrinsicAttributes } from '@emotion/react/types/jsx-namespace';

const mapDispatchToProps = (dispatch: Dispatch) => bindActionCreators({
    deleteReminder: deleteReminder,
    fetchReminders: fetchReminders,
    createReminder: createReminder,
    setReminderStatusAsDone: setReminderStatusAsDone,
    editReminder: editReminder,
}, dispatch);

function mapStateToProps(state: RootState) {
    return {
        reminders: getReminders(state),
        isFetching: getIsFetching(state)
    };
}

type RemindersContainerProps = ReturnType<typeof mapStateToProps> & ReturnType<typeof mapDispatchToProps> & ReactJSXIntrinsicAttributes;

const RemindersContainer: React.FC<RemindersContainerProps> = ({ fetchReminders, createReminder, editReminder, deleteReminder, setReminderStatusAsDone, reminders, isFetching }) => {

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
const ComponentWithRedirect = withAuthRedirect<RemindersContainerProps>(RemindersContainer);

export default connect(mapStateToProps, mapDispatchToProps)(ComponentWithRedirect);
