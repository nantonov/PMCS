import { connect } from 'react-redux';
import Pets from './Pets';
import { deletePetActionCreator, editPetActionCreator, setPetsActionCreator, addPetActionCreator} from '../../../redux/reducers/petsReducer/petsReducer';

function mapStateToProps(state) {
    return { pets: state.petsPage.pets }
}

function mapDispatchToProps(dispatch) {
    return {
        editPet: (pet) => {
            let action = editPetActionCreator(pet);
            dispatch(action);
        },
        deletePet: (id) => {
            let action = deletePetActionCreator(id);
            dispatch(action);
        },
        setPets: (pets) => {
            let action = setPetsActionCreator(pets);
            dispatch(action);
        },
        addPet: (pet) => {
            let action = addPetActionCreator(pet);
            dispatch(action);
        }
    }
}

const PetsContainer = connect(mapStateToProps, mapDispatchToProps)(Pets);

export default PetsContainer;