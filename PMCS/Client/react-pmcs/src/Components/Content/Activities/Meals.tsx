import React, { useEffect, useState } from 'react';
import * as mealActionCreators from '../../../redux/Activities/mealActionCreators';
import { RootState } from '../../../redux/types';
import { getMeals, isFetching } from '../../../redux/Activities/selectors';
import { Dispatch, bindActionCreators } from 'redux';
import MealActivity from './Activity/MealActivity';
import Preloader from '../../Preloader/Preloader';
import { connect } from 'react-redux';
import s from './Activities.module.css';
import Activities from './Activities';
import withAuthRedirect from '../../Shared/Hocs/WithAuthRedirect';
import { ReactJSXIntrinsicAttributes } from '@emotion/react/types/jsx-namespace';

function mapStateToProps(state: RootState) {
    return {
        meals: getMeals(state),
        isFetching: isFetching(state)
    };
}

const mapDispatchToProps = (dispatch: Dispatch) =>
    bindActionCreators(
        {
            fetchMeals: mealActionCreators.fetchMeals,
            deleteMeal: mealActionCreators.deleteMeal,
        },
        dispatch
    );

type MealsProps = ReturnType<typeof mapDispatchToProps> & ReturnType<typeof mapStateToProps> & ReactJSXIntrinsicAttributes;


const Meals: React.FC<MealsProps> = (props) => {
    const [isMealDeleted, setMealDeleted] = useState<boolean>(false);

    useEffect(() => {
        props.fetchMeals();
    }, [isMealDeleted]);

    const mealActivities = props.meals.map(mealItem => <MealActivity
        title={mealItem.title}
        description={mealItem.description}
        dateTime={mealItem.dateTime}
        pet={mealItem.pet}
        deleteMeal={props.deleteMeal}
        id={mealItem.id}
        setMealDeleted={setMealDeleted} />);

    return (
        <section>
            {props.isFetching ? <Preloader /> : null}
            <article>
                <div className={s.subTitle}>Meals</div>
                <Activities children={mealActivities} />
            </article>
        </section>
    );
}

const ComponentWithRedirect = withAuthRedirect<MealsProps>(Meals);

export default connect(mapStateToProps, mapDispatchToProps)(ComponentWithRedirect);