import { connect } from 'react-redux';
import Profile from './Profile';
import {editOwner, setOwner, addOwner } from '../../../redux/reducers/ownersReducer';

function mapStateToProps(state) {
    return { owner: state.profile.owner }
}

const ProfileContainer = connect(mapStateToProps, {editOwner, addOwner, setOwner})(Profile);

export default ProfileContainer;