import actionTypes from '../common/actionTypes';

export default function workflowReducer(state = [], action) {
    switch(action.type) {
        case actionTypes.WorkflowCreate:
            return [...state,
                Object.assign({}, action.workflow)
            ];
        
        case actionTypes.WorkflowLoadSuccess:
            return action.workflows;        

        default: 
            return state;
    }
}