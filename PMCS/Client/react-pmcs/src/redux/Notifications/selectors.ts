import { createSelector } from "reselect";
import { RootState } from "../types";

const selectMessages = (state : RootState) : Array<string> => state.notifications.messages;

export const getMessages = createSelector(selectMessages, (messages : Array<string>) => {
    return messages.filter((value : string, index : number, self : typeof messages) => self.indexOf(value) === index);
});