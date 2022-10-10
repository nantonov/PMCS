import { connect } from 'react-redux';
import withAuthRedirect from '../../Auth/WithAuthRedirect';
import Reminders from './Reminders';

let authRedirectComponent = withAuthRedirect(Reminders);

const RemindersContainer = connect()(authRedirectComponent);

export default RemindersContainer;