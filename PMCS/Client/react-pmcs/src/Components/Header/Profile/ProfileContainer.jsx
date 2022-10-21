import { connect } from 'react-redux';
import Profile from './Profile';
import { fetchOwner, editOwner, createOwner } from '../../../redux/Owner/actionCreators';
import { getErrors, getOwner } from '../../../redux/Owner/selectors';

function mapStateToProps(state) {
    return {
        owner: getOwner(state),
        errors: getErrors(state)
    };
}

const ProfileContainer = connect(mapStateToProps, { fetchOwner, editOwner, createOwner })(Profile);

export default ProfileContainer;