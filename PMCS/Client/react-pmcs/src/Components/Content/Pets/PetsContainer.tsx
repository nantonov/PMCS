import { connect } from 'react-redux';
import Pets from './Pets';
import withAuthRedirect from '../../Shared/Hocs/WithAuthRedirect';
import { useEffect, useState } from 'react';
import Pet from './Pet/Pet';
import NoContent from '../NoContent/NoContent';
import { bindActionCreators, Dispatch } from 'redux';
import Preloader from '../../Preloader/Preloader';
import { isFetching, getPets } from '../../../redux/Pets/selectors';
import { RootState } from '../../../redux/types';
import * as petsActionsCreators from '../../../redux/Pets/actionCreators'
import { ReactJSXIntrinsicAttributes } from '@emotion/react/types/jsx-namespace';

function mapStateToProps(state: RootState) {
    return {
        pets: getPets(state),
        isFetching: isFetching(state)
    };
}

const mapDispatchToProps = (dispatch: Dispatch) => bindActionCreators({
    deletePet: petsActionsCreators.deletePet,
    createPet: petsActionsCreators.createPet,
    editPet: petsActionsCreators.editPet,
    fetchPets: petsActionsCreators.fetchPets
}, dispatch);

type PetsContainerProps = ReturnType<typeof mapStateToProps> & ReturnType<typeof mapDispatchToProps> & ReactJSXIntrinsicAttributes;

const PetsContainer: React.FC<PetsContainerProps> = ({ deletePet, editPet, fetchPets, createPet, pets, isFetching }) => {

    const [isPetDeleted, setIsPetDeleted] = useState<boolean>(false);

    useEffect(() => {
        fetchPets();
        setIsPetDeleted(false);
    }, [isPetDeleted]);

    let petsElements = pets.map(petItem =>
        <Pet key={petItem.id}
            pet={petItem}
            editPet={editPet}
            deletePet={deletePet}
            setIsPetDeleted={setIsPetDeleted} />);

    let content = pets.length === 0 ? <NoContent /> : petsElements;

    return (
        <div>
            {isFetching ? <Preloader /> : null}
            <Pets content={content} createPet={createPet} />
        </div>
    );
}

const ComponentWithRedirect = withAuthRedirect<PetsContainerProps>(PetsContainer);

export default connect(mapStateToProps, mapDispatchToProps)(ComponentWithRedirect);