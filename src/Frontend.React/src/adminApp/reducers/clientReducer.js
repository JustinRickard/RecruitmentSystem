import actionTypes from '../common/actionTypes';

export default function clientReducer(state = [], action) {
    switch(action.type) {
        case actionTypes.ClientCreate:
            return [...state,
                Object.assign({}, action.client)
            ];
        
        case actionTypes.ClientDelete:
            // Filter list?
        

        default:
            return state;
    }
}