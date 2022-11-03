import { connect } from 'react-redux';
import { getMeals, getVaccines, getWalkings, isFetching } from '../../../redux/Activities/selectors';
import { RootState } from '../../../redux/types';
import withAuthRedirect from '../../Shared/Hocs/WithAuthRedirect';
import * as mealActionCreators from '../../../redux/Activities/mealActionCreators';
import * as vaccineActionCreators from '../../../redux/Activities/vaccineActionCreators';
import * as walkingActionCreators from '../../../redux/Activities/walkingActionCreators';
import { bindActionCreators, Dispatch } from 'redux';
import s from './Activities.module.css';
import React from 'react';
import { ReactJSXIntrinsicAttributes } from '@emotion/react/types/jsx-namespace';

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

type ActivitiesProps = ReturnType<typeof mapStateToProps> & ReturnType<typeof mapDispatchToProps> & ReactJSXIntrinsicAttributes;
const ActivitiesContainer: React.FC<ActivitiesProps> = (props) => {
    return (
        <div className={s.wrapper}>
            Here will be activities
        </div>
    );
}

const ComponentWithRedirect = withAuthRedirect<ActivitiesProps>(ActivitiesContainer);

export default connect(mapStateToProps, mapDispatchToProps)(ComponentWithRedirect);