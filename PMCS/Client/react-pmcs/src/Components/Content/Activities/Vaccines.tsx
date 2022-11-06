import React, { useEffect } from 'react';
import * as vaccineActionCreators from '../../../redux/Activities/vaccineActionCreators';
import { RootState } from '../../../redux/types';
import { getVaccines, isFetching } from '../../../redux/Activities/selectors';
import { Dispatch, bindActionCreators } from 'redux';
import VaccineActivity from './Activity/VaccineActivity';
import Preloader from '../../Preloader/Preloader';
import { connect } from 'react-redux';
import s from './Activities.module.css';
import Activities from './Activities';
import withAuthRedirect from '../../Shared/Hocs/WithAuthRedirect';
import { ReactJSXIntrinsicAttributes } from '@emotion/react/types/jsx-namespace';

function mapStateToProps(state: RootState) {
    return {
        vaccines: getVaccines(state),
        isFetching: isFetching(state)
    };
}

const mapDispatchToProps = (dispatch: Dispatch) =>
    bindActionCreators(
        {
            fetchVaccines: vaccineActionCreators.fetchVaccines,
            deleteVaccine: vaccineActionCreators.deleteVaccine,
        },
        dispatch
    );

type VaccineProps = ReturnType<typeof mapDispatchToProps> & ReturnType<typeof mapStateToProps> & ReactJSXIntrinsicAttributes;


const Vaccines: React.FC<VaccineProps> = (props) => {
    useEffect(() => {
        props.fetchVaccines();
    }, []);

    const vaccineItems = props.vaccines.map(vaccineItem => <VaccineActivity
        title={vaccineItem.title}
        description={vaccineItem.description}
        dateTime={vaccineItem.dateTime}
        pet={vaccineItem.pet}
        deleteVaccine={props.deleteVaccine}
        id={vaccineItem.id} />);

    return (
        <section>
            {props.isFetching ? <Preloader /> : null}
            <article>
                <span className={s.title}>Vaccines</span>
                <Activities children={vaccineItems} />
            </article>
        </section>
    );
}

const ComponentWithRedirect = withAuthRedirect<VaccineProps>(Vaccines);

export default connect(mapStateToProps, mapDispatchToProps)(ComponentWithRedirect);