import { User } from "../../shared/interfaces/user.interface";


const INIT_STATE: User = {
    username: '',
    test: ''
}

export function userReducer(state: User = INIT_STATE, action: any) {
    switch (action.type) {
        case 'SET_USER':
            return Object.assign({}, state, action.payload);
        case 'RESET_USER':
            return Object.assign({}, state, INIT_STATE);
        default:
            return Object.assign({}, state);
    }
}

