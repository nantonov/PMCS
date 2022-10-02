import { connect } from 'react-redux';
import Pets from './Pets';
import { deletePetActionCreator, editPetActionCreator } from '../../../redux/petsReducer';

function mapStateToProps(state) {
    return { petsPage: state.petsPage }
}

function mapDispatchToProps(dispatch) {
    return {
        onEditButtonClick: (pet) => {
            let action = editPetActionCreator(pet);
            dispatch(action);
        },
        onDeleteButtonClick: (id) => {
            let action = deletePetActionCreator(id);
            dispatch(action);
        }
    }
}

const PetsContainer = connect(mapStateToProps, mapDispatchToProps)(Pets);

export default PetsContainer;