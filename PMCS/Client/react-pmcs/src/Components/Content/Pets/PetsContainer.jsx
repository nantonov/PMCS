import { connect } from 'react-redux';
import Pets from './Pets';
import { deletePet, editPet, fetchPets, createPet, cleanErrors } from '../../../redux/Pets/actionCreators';
import withAuthRedirect from '../../Shared/Hocs/WithAuthRedirect';
import { useEffect, useState } from 'react';
import Pet from './Pet/Pet';
import NoContent from './NoContent';
import { compose } from 'redux';
import Preloader from '../../Preloader/Preloader';

const PetsContainer = (props) => {
    const { deletePet, editPet, fetchPets, createPet, pets, isFetching, errors, cleanErrors } = props;

    const [isPetDeleted, setIsPetDeleted] = useState(false);

    useEffect(() => {
        fetchPets();
        setIsPetDeleted(false);
    }, [isPetDeleted]);

    let petsElements = pets.map(petItem =>
        <Pet key={petItem.id}
            pet={petItem}
            editPet={editPet}
            deletePet={deletePet}
            errors={errors}
            setIsPetDeleted={setIsPetDeleted} 
            cleanErrors={cleanErrors}/>);

    let content = pets.length === 0 ? <NoContent /> : petsElements;

    return (
        <div>
            {isFetching ? <Preloader /> : null}
            <Pets content={content}  errors={errors} createPet={createPet} cleanErrors={cleanErrors}/>
        </div>
    );
}

function mapStateToProps(state) {
    return {
        pets: state.petsPage.pets,
        errors: state.petsPage.errors,
        isFetching: state.petsPage.isFetching
    };
}

export default compose(
    connect(mapStateToProps, { deletePet, editPet, fetchPets, createPet, cleanErrors}),
    withAuthRedirect)(PetsContainer);