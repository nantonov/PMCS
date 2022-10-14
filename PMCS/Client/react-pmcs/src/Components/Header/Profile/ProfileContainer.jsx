import { connect } from 'react-redux';
import Profile from './Profile';
import {fetchOwner, editOwner, createOwner} from '../../../redux/Owner/actionCreators';

function mapStateToProps(state) {
    return { owner: state.profile.owner }
}

const ProfileContainer = connect(mapStateToProps, {fetchOwner, editOwner, createOwner})(Profile);

export default ProfileContainer;