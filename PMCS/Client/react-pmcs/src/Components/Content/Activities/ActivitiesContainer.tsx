import { connect } from 'react-redux';
import { getMeals, getVaccines, getWalkings, isFetching } from '../../../redux/Activities/selectors';
import { RootState } from '../../../redux/types';
import withAuthRedirect from '../../Shared/Hocs/WithAuthRedirect';
import * as mealActionCreators from '../../../redux/Activities/mealActionCreators';
import * as vaccineActionCreators from '../../../redux/Activities/vaccineActionCreators';
import * as walkingActionCreators from '../../../redux/Activities/walkingActionCreators';
import { bindActionCreators, Dispatch } from 'redux';
import s from './Activities.module.css';
import React, { useState } from 'react';
import { ReactJSXIntrinsicAttributes } from '@emotion/react/types/jsx-namespace';
import { Navigate, Outlet, useLocation, NavLink } from 'react-router-dom';
import Button from '@mui/material/Button';
import AddIcon from '@mui/icons-material/Add';
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
            addMeal: mealActionCreators.createMeal,
            addVaccine: vaccineActionCreators.createVaccine,
            addWalking: walkingActionCreators.createWalking,
        },
        dispatch
    );

type ActivitiesProps = ReturnType<typeof mapStateToProps> & ReturnType<typeof mapDispatchToProps> & ReactJSXIntrinsicAttributes;
const ActivitiesContainer: React.FC<ActivitiesProps> = (props) => {
    const [isAddModalOpened, setAddModalOpened] = useState<boolean>(false);

    function handleClick(): void {
        setAddModalOpened(true);
    };

    const location = useLocation();
    const content = location.pathname === '/activities' ? <Navigate to='/activities/meals' /> : <Outlet />;

    return (
        <section className={s.wrapper}>
            {isAddModalOpened ? <AddActivityModal
                addVaccine={props.addVaccine}
                addMeal={props.addMeal}
                addWalking={props.addWalking}
                setAddModalOpened={setAddModalOpened} /> : null}
            <nav>
                <NavLink to='/activities/meals' className={s.link}>Meals</NavLink>
                <NavLink to='/activities/vaccines' className={s.link}>Vaccines</NavLink>
                <NavLink to='/activities/walkings' className={s.link}>Walkings</NavLink>
            </nav>
            <div className={s.header}>
                <span className={s.title}>Activities</span>
                <Button className={s.addButton} onClick={handleClick} startIcon={<AddIcon />} color="success">
                    New activity
                </Button>
            </div>
            {content}
        </section>
    );
}

const ComponentWithRedirect = withAuthRedirect<ActivitiesProps>(ActivitiesContainer);

export default connect(mapStateToProps, mapDispatchToProps)(ComponentWithRedirect);