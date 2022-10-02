import { connect } from 'react-redux';
import Pets from './Pets';
import { deletePetActionCreator, editPetActionCreator, setPetsActionCreator} from '../../../redux/reducers/petsReducer/petsReducer';

function mapStateToProps(state) {
    return { pets: state.petsPage.pets }
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
        },
        setPets: (pets) => {
            let action = setPetsActionCreator(pets);
            dispatch(action);
        },
    }
}

const PetsContainer = connect(mapStateToProps, mapDispatchToProps)(Pets);

export default PetsContainer;