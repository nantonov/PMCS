import { connect } from 'react-redux';
import Pets from './Pets';
import { deletePet, editPet, setPets, addPet} from '../../../redux/reducers/petsReducer';
import withAuthRedirect from '../../Auth/WithAuthRedirect';

let authRedirectComponent = withAuthRedirect(Pets);

function mapStateToProps(state) {
    return { pets: state.petsPage.pets }
}

const PetsContainer = connect(mapStateToProps, {deletePet, editPet, setPets, addPet})(authRedirectComponent);

export default PetsContainer;