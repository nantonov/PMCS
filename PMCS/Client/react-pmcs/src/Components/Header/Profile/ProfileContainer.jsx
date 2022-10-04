import { connect } from 'react-redux';
import Profile from './Profile';
import { deleteOwnerActionCreator, editOwnerActionCreator, setOwnerActionCreator, addOwnerActionCreator } from '../../../redux/reducers/ownersReducer/ownersReducer';

function mapStateToProps(state) {
    return { owner: state.profile.owner }
}

function mapDispatchToProps(dispatch) {
    return {
        editOwner: (owner) => {
            let action = editOwnerActionCreator(owner);
            dispatch(action);
        },
        deleteOwner: (id) => {
            let action = deleteOwnerActionCreator(id);
            dispatch(action);
        },
        setOwner: (owner) => {
            let action = setOwnerActionCreator(owner);
            dispatch(action);
        },
        addOwner: (owner) => {
            let action = addOwnerActionCreator(owner);
            dispatch(action);
        },
    }
}

const ProfileContainer = connect(mapStateToProps, mapDispatchToProps)(Profile);

export default ProfileContainer;