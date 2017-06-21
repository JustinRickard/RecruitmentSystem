import actionTypes from '../common/actionTypes';

export default function userReducer(state = [], action) {
    switch(action.type) {
        case actionTypes.UserCreate:
            return [...state,
                Object.assign({}, action.user)
            ];
        
        case actionTypes.UserLoadSuccess:
            return action.users;        

        default: 
            return state;
    }
}