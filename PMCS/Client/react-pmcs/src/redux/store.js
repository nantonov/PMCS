import petsReducer from "./reducers/petsReducer";

let store = {
    _state: {
        petsPage: {
            pets: [{
                id: 1,
                name: "Johny", info: "Very funny pet.", birthdate: "12/05/2012", weight: "5.0kg",
                meals: [{ id: 1, title: "Yummy", description: "Very yummy food.", dateTime: "12.05.2012 21.58" }],
                vaccines: [{ id: 1, title: "Yummy", description: "Very yummy food.", dateTime: "12.05.2012 21.58" }],
                walkings: [{ id: 1, title: "Yummy", description: "Very yummy food.", started: "12.05.2012 21.58", finished: "12.05.2012 22.17" }],
                owner: { id: 1, name: "John" }
            }]
        }
    },

    get state() {
        return this._state;
    },
    subscribe(observer) {
        this._callSubscriber = observer;
    },
    _callSubscriber() {
        console.log('State changed');
    },

    dispatch(action) {
        this._state.petsPage = petsReducer(this._state.petsPage, action);

        this._callSubscriber(this._state);
    }
}

export default store;
