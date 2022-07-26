import React, { SetStateAction, useCallback, useEffect } from 'react';
import { ICreateActivityRequest } from '../../../../../common/requests/Activities/ICreateActivityRequest';
import s from '../../../../Shared/Modal/Modal.module.css'
import AddActivityForm from '../../../../Forms/AddActivityForm';
import * as mealActionCreators from '../../../../../redux/Activities/mealActionCreators';
import * as vaccineActionCreators from '../../../../../redux/Activities/vaccineActionCreators';
import * as walkingActionCreators from '../../../../../redux/Activities/walkingActionCreators';
import { ActivityType } from '../../../../../Enums/activityEnums';
import { RootState } from '../../../../../redux/types';
import { getPets } from '../../../../../redux/Pets/selectors';
import { connect } from 'react-redux';
import { fetchPets } from '../../../../../redux/Pets/actionCreators';
import { toUtcDateTime } from '../../../../../utils/dateFormatitng';
import { bindActionCreators, Dispatch } from 'redux';

function mapStateToProps(state: RootState) {
    return {
        pets: getPets(state)
    };
}

const mapDispatchToProps = (dispatch: Dispatch) =>
    bindActionCreators(
        {
            fetchPets: fetchPets,
        },
        dispatch
    );

type ExternalProps = {
    setAddModalOpened: React.Dispatch<SetStateAction<boolean>>,
    addMeal: typeof mealActionCreators.createMeal;
    addVaccine: typeof vaccineActionCreators.createVaccine,
    addWalking: typeof walkingActionCreators.createWalking,
}

type AddActivityModalProps = ExternalProps & ReturnType<typeof mapDispatchToProps> & ReturnType<typeof mapStateToProps>;

const AddActivityModal: React.FC<AddActivityModalProps> = ({ setAddModalOpened, addMeal, addVaccine, addWalking, fetchPets, pets }) => {
    const escFunction = useCallback((event: KeyboardEvent) => {
        if (event.key === "Escape") {
            setAddModalOpened(false);
        }
    }, []);

    useEffect(() => {
        document.addEventListener("keydown", escFunction, false);

        return () => {
            document.removeEventListener("keydown", escFunction, false);
        };
    });

    const addActivity = (values: ICreateActivityRequest) => {
        switch (values.activityType) {
            case ActivityType.Meal:
                values.dateTime = toUtcDateTime(values.dateTime as string);
                addMeal(values);
                break;
            case ActivityType.Vaccine:
                values.dateTime = toUtcDateTime(values.dateTime as string);
                addVaccine(values);
                break;
            case ActivityType.Walking:
                values.stared = toUtcDateTime(values.dateTime as string);
                values.finished = new Date().toISOString();
                addWalking(values);
                break;
        }
    }

    return (
        <div className={s.modal}>
            <AddActivityForm onSubmit={addActivity} pets={pets} fetchPets={fetchPets} />
        </div>
    );
}

export default connect(mapStateToProps, mapDispatchToProps)(AddActivityModal);