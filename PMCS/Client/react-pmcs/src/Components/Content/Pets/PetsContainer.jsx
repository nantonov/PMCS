import { connect } from 'react-redux';
import Pets from './Pets';
import { deletePet, editPet, fetchPets, createPet} from '../../../redux/Pets/actionCreators';
import withAuthRedirect from '../../Auth/WithAuthRedirect';

let authRedirectComponent = withAuthRedirect(Pets);

function mapStateToProps(state) {
    return { pets: state.petsPage.pets }
}

const PetsContainer = connect(mapStateToProps, {deletePet, editPet, fetchPets, createPet})(authRedirectComponent);

export default PetsContainer;