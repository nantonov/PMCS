import { connect } from 'react-redux';
import Pets from './Pets';
import { deletePet, editPet, setPets, addPet} from '../../../redux/reducers/petsReducer/petsReducer';

function mapStateToProps(state) {
    return { pets: state.petsPage.pets }
}

const PetsContainer = connect(mapStateToProps, {deletePet, editPet, setPets, addPet})(Pets);

export default PetsContainer;