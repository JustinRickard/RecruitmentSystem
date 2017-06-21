import actionTypes from '../common/actionTypes';

export default function projectReducer(state = [], action) {
    switch(action.type) {
        case actionTypes.ProjectCreate:
            return [...state,
                Object.assign({}, action.project)
            ];
        
        case actionTypes.ProjectLoadSuccess:
            return action.projects;        

        default: 
            return state;
    }
}