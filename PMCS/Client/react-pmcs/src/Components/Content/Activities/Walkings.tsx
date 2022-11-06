import React, { useEffect, useState } from 'react';
import * as walkingActionCreators from '../../../redux/Activities/walkingActionCreators';
import { RootState } from '../../../redux/types';
import { getWalkings, isFetching } from '../../../redux/Activities/selectors';
import { Dispatch, bindActionCreators } from 'redux';
import WalkingActivity from './Activity/WalkingActivity';
import Preloader from '../../Preloader/Preloader';
import { connect } from 'react-redux';
import s from './Activities.module.css';
import Activities from './Activities';
import withAuthRedirect from '../../Shared/Hocs/WithAuthRedirect';
import { ReactJSXIntrinsicAttributes } from '@emotion/react/types/jsx-namespace';

function mapStateToProps(state: RootState) {
    return {
        walkings: getWalkings(state),
        isFetching: isFetching(state)
    };
}

const mapDispatchToProps = (dispatch: Dispatch) =>
    bindActionCreators(
        {
            fetchWalkings: walkingActionCreators.fetchWalkings,
            deleteWalking: walkingActionCreators.deleteWalking,
        },
        dispatch
    );

type WalkingProps = ReturnType<typeof mapDispatchToProps> & ReturnType<typeof mapStateToProps> & ReactJSXIntrinsicAttributes;

const Walkings: React.FC<WalkingProps> = (props) => {
    const [isWalkingDeleted, setWalkingDeleted] = useState<boolean>(false);

    useEffect(() => {
        props.fetchWalkings();
    }, [isWalkingDeleted]);

    const vaccineItems = props.walkings.map(walking => <WalkingActivity
        title={walking.title}
        description={walking.description}
        stared={walking.stared}
        finished={walking.finished}
        pet={walking.pet}
        deleteWalking={props.deleteWalking}
        id={walking.id}
        setWalkingDeleted={setWalkingDeleted} />);

    return (
        <section>
            {props.isFetching ? <Preloader /> : null}
            <article>
                <span className={s.subTitle}>Walkings</span>
                <Activities children={vaccineItems} />
            </article>
        </section>
    );
}

const ComponentWithRedirect = withAuthRedirect<WalkingProps>(Walkings);

export default connect(mapStateToProps, mapDispatchToProps)(ComponentWithRedirect);