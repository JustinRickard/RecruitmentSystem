import actionTypes from '../common/actionTypes';

export default function workflowStepReducer(state = [], action) {
    switch(action.type) {
        case actionTypes.WorkflowStepCreate:
            return [...state,
                Object.assign({}, action.workflowStep)
            ];
        
        case actionTypes.WorkflowStepLoadSuccess:
            return action.workflowSteps;        

        default: 
            return state;
    }
}