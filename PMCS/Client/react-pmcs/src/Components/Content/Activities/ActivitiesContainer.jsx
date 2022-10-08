import { connect } from 'react-redux';
import withAuthRedirect from '../../Auth/WithAuthRedirect';
import Activities from './Activities';

let authRedirectComponent = withAuthRedirect(Activities);

const ActivitiesContainer = connect()(authRedirectComponent);

export default ActivitiesContainer;