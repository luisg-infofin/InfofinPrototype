import { User } from "../../interfaces/user.interface";

const INIT_STATE: User = {
    username: '',
    test: ''
}

const newState = (state: any, newData: any) => {
    return Object.assign({}, state, newData)
}


export function userReducer(state: User = INIT_STATE, action: any) {
    switch (action.type) {
        case 'SET_USER':
            return { ...state, ...action.payload }
        case 'RESET_USER':
            return INIT_STATE;
        default:
            return state;
    }
}

