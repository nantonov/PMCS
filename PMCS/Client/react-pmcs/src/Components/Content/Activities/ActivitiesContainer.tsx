import { connect } from 'react-redux';
import { getMeals, getVaccines, getWalkings, isFetching } from '../../../redux/Activities/selectors';
import { RootState } from '../../../redux/types';
import withAuthRedirect from '../../Shared/Hocs/WithAuthRedirect';
import Activities from './Activities';
import { compose } from 'redux';  

let authRedirectComponent = withAuthRedirect(Activities);

const ActivitiesContainer = connect()(authRedirectComponent);

function mapStateToProps(state : RootState) {
    return {
        vaccines: getVaccines(state),
        walkings: getWalkings(state),
        meals: getMeals(state),
        isFetching: isFetching(state)
    };
}

export default compose(connect(mapStateToProps, { }), withAuthRedirect)(ActivitiesContainer);