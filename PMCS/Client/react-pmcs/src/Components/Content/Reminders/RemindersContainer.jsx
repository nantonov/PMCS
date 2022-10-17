import { connect } from 'react-redux';
import withAuthRedirect from '../../Shared/Hocs/WithAuthRedirect';
import Reminders from './Reminders';

let authRedirectComponent = withAuthRedirect(Reminders);

const RemindersContainer = connect()(authRedirectComponent);

export default RemindersContainer;