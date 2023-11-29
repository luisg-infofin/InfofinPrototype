import { Action } from "@ngrx/store";
import { User } from "../../shared/interfaces/user.interface";

export const SET_USER = 'SET_USER';
export const RESET_USER = 'RESET_USER';


export class SetUser implements Action {
    type: string = SET_USER;

    constructor(public payload: User) { }

}

export class ResetUser implements Action {
    type: string = SET_USER;

    constructor() { }
}

export type All
    = SetUser |
    ResetUser;