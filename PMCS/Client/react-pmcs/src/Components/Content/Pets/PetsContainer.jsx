import { connect } from 'react-redux';
import Pets from './Pets';
import { deletePet, editPet, fetchPets, createPet } from '../../../redux/Pets/actionCreators';
import withAuthRedirect from '../../Auth/WithAuthRedirect';
import { useEffect } from 'react';
import Pet from './Pet/Pet';
import NoContent from './NoContent';
import {compose} from 'redux';

const PetsContainer = (props) => {
    const {deletePet, editPet, fetchPets, createPet, pets} = props;
    useEffect(() => {
        fetchPets();
    }, []);

    let petsElements = pets.map(petItem =>
        <Pet key={petItem.id}
            pet={petItem}
            editPet={editPet}
            deletePet={deletePet} />);

    let content = pets.length === 0 ? <NoContent /> : petsElements;

    return (
        <div>
            <Pets content={content} createPet={createPet} />
        </div>
    );
}

function mapStateToProps(state) {
    return { pets: state.petsPage.pets }
}

export default compose(
    connect(mapStateToProps, { deletePet, editPet, fetchPets, createPet }),
            withAuthRedirect)(PetsContainer);