import { createSelector } from "reselect";

const selectMessages = (state) => state.notifications.messages;

export const getMessages = createSelector(selectMessages, (messages) => {
    return messages.filter((value, index, self) => self.indexOf(value) === index);
});