import { connect } from 'react-redux';
import { getMeals, getVaccines, getWalkings, isFetching } from '../../../redux/Activities/selectors';
import { RootState } from '../../../redux/types';
import withAuthRedirect from '../../Shared/Hocs/WithAuthRedirect';
import { ConnectedProps } from 'react-redux';
import { compose } from 'redux';
import * as mealActionCreators from '../../../redux/Activities/mealActionCreators';
import * as vaccineActionCreators from '../../../redux/Activities/vaccineActionCreators';
import * as walkingActionCreators from '../../../redux/Activities/walkingActionCreators';
import { bindActionCreators, Dispatch } from 'redux';
import s from './ActivitiesContainer.module.css';

function mapStateToProps(state: RootState) {
    return {
        vaccines: getVaccines(state),
        walkings: getWalkings(state),
        meals: getMeals(state),
        isFetching: isFetching(state)
    };
}

const mapDispatchToProps = (dispatch: Dispatch) =>
    bindActionCreators(
        {
            fetchMeals: mealActionCreators.fetchMeals,
            fetchVaccines: vaccineActionCreators.fetchVaccines,
            fetchWalkings: walkingActionCreators.fetchWalkings,

            deleteMeal: mealActionCreators.deleteMeal,
            deleteVaccine: vaccineActionCreators.deleteVaccine,
            deleteWalking: walkingActionCreators.deleteWalking,

            addMeal: mealActionCreators.createMeal,
            addVaccine: vaccineActionCreators.createVaccine,
            addWalking: walkingActionCreators.createWalking,

            updateMeal: mealActionCreators.editMeal,
            updateVaccine: vaccineActionCreators.editVaccine,
            updateWalking: walkingActionCreators.editWalking
        },
        dispatch
    );


const connector = compose(connect(mapStateToProps, mapDispatchToProps), withAuthRedirect);

export type ActivitiesProps = ConnectedProps<typeof connector>;

const ActivitiesContainer: React.FC<ActivitiesProps> = ({ }) => {
    return (
        <div className={s.wrapper}>
            Here will be activities
        </div>
    );
}

export default connector(ActivitiesContainer);