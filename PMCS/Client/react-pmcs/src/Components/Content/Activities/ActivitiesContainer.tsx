import { connect } from 'react-redux';
import { getMeals, getVaccines, getWalkings, isFetching } from '../../../redux/Activities/selectors';
import { RootState } from '../../../redux/types';
import withAuthRedirect from '../../Shared/Hocs/WithAuthRedirect';
import * as mealActionCreators from '../../../redux/Activities/mealActionCreators';
import * as vaccineActionCreators from '../../../redux/Activities/vaccineActionCreators';
import * as walkingActionCreators from '../../../redux/Activities/walkingActionCreators';
import { bindActionCreators, Dispatch } from 'redux';
import s from './Activities.module.css';
import React, { useState, useEffect } from 'react';
import { ReactJSXIntrinsicAttributes } from '@emotion/react/types/jsx-namespace';
import WalkingActivity from './Activity/WalkingActivity';
import MealActivity from './Activity/MealActivity';
import VaccineActivity from './Activity/VaccineActivity';
import Activities from './Activities';
import Preloader from '../../Preloader/Preloader';
import IconButton from '@mui/material/IconButton';
import AddCircleIcon from '@mui/icons-material/AddCircle';
import AddActivityModal from './Activity/Modal/AddActivityModal';

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
    const [isAddModalOpened, setAddModalOpened] = useState<boolean>(false);

    function handleClick(): void {
        setAddModalOpened(true);
    };

    useEffect(() => {
        props.fetchMeals();
    }, []);

    const walkingActivities = props.walkings.map(walkingItem => <WalkingActivity
        title={walkingItem.title}
        description={walkingItem.description}
        stared={walkingItem.stared}
        finished={walkingItem.finished}
        pet={walkingItem.pet} />);

    const mealActivities = props.meals.map(mealItem => <MealActivity
        title={mealItem.title}
        description={mealItem.description}
        dateTime={mealItem.dateTime}
        pet={mealItem.pet} />);


    const vaccineActivities = props.vaccines.map(vaccineItem => <VaccineActivity
        title={vaccineItem.title}
        description={vaccineItem.description}
        dateTime={vaccineItem.dateTime}
        pet={vaccineItem.pet} />);

    return (
        <section className={s.wrapper}>
            {props.isFetching ? <Preloader /> : null}
            {isAddModalOpened ? <AddActivityModal
                addVaccine={props.addVaccine}
                addMeal={props.addMeal}
                addWalking={props.addWalking}
                setAddModalOpened={setAddModalOpened} /> : null}
            <article className={s.activityItem}>
                <span className={s.title}>Walkings</span>
                <Activities children={walkingActivities} />
            </article>
            <article className={s.activityItem}>
                <span className={s.title}>Vaccines</span>
                <Activities children={vaccineActivities} />
            </article>
            <article className={s.activityItem}>
                <span className={s.title}>Meals</span>
                <Activities children={mealActivities} />
            </article>
            <IconButton onClick={handleClick}>
                <AddCircleIcon />
            </IconButton>
        </section>
    );
}

const ComponentWithRedirect = withAuthRedirect<ActivitiesProps>(ActivitiesContainer);

export default connect(mapStateToProps, mapDispatchToProps)(ComponentWithRedirect);