import React, { useEffect, useState } from 'react';
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
import NoContent from '../NoContent/NoContent';

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
    const [isVaccineDeleted, setVaccineDeleted] = useState<boolean>(false);

    useEffect(() => {
        props.fetchVaccines();
    }, [isVaccineDeleted]);

    const vaccineItems = props.vaccines.map(vaccineItem => <VaccineActivity
        title={vaccineItem.title}
        description={vaccineItem.description}
        dateTime={vaccineItem.dateTime}
        pet={vaccineItem.pet}
        deleteVaccine={props.deleteVaccine}
        id={vaccineItem.id}
        setVaccineDeleted={setVaccineDeleted} />);

    const content = vaccineItems.length > 0 ? <Activities children={vaccineItems} /> : <NoContent />;

    return (
        <section>
            {props.isFetching ? <Preloader /> : null}
            <article>
                <span className={s.subTitle}>Vaccines</span>
                {content}
            </article>
        </section>
    );
}

const ComponentWithRedirect = withAuthRedirect<VaccineProps>(Vaccines);

export default connect(mapStateToProps, mapDispatchToProps)(ComponentWithRedirect);