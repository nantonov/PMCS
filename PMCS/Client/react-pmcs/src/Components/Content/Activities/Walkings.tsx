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
import NoContent from '../NoContent/NoContent';

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
        setWalkingDeleted(false);
    }, [isWalkingDeleted]);

    const walkingItems = props.walkings.map(walking => <WalkingActivity
        key={walking.id}
        walking={walking}
        deleteWalking={props.deleteWalking}
        setWalkingDeleted={setWalkingDeleted} />);

    const content = walkingItems.length > 0 ? <Activities children={walkingItems} /> : <NoContent />;

    return (
        <section>
            {props.isFetching ? <Preloader /> : null}
            <article>
                <span className={s.subTitle}>Walkings</span>
                <div className={s.annotation}>*Be careful, when you add new walking: finished date time is automatically set as current date time.</div>
                {content}
            </article>
        </section>
    );
}

const ComponentWithRedirect = withAuthRedirect<WalkingProps>(Walkings);

export default connect(mapStateToProps, mapDispatchToProps)(ComponentWithRedirect);