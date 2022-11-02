import { connect, ConnectedProps } from 'react-redux';
import Profile from './Profile';
import { fetchOwner, editOwner, createOwner } from '../../../redux/Owner/actionCreators';
import { getErrors, getOwner } from '../../../redux/Owner/selectors';
import { RootState } from '../../../redux/types';
import { compose } from 'redux';

function mapStateToProps(state: RootState) {
    return {
        owner: getOwner(state),
        errors: getErrors(state)
    };
}

const connector = compose(connect(mapStateToProps, { fetchOwner, editOwner, createOwner }));

export type ProfileProps = ConnectedProps<typeof connector>;

const ProfileContainer = connector(Profile);

export default ProfileContainer;