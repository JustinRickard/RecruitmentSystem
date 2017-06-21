import actionTypes from '../common/actionTypes';
import workflowApi from '../api/workflow/mockWorkflowApi';
// import workflowApi from '../api/workflow/workflowApi';

export function createWorkflowStep(workflowStep) {
    return {
        type: actionTypes.WorkflowStepCreate,
        workflowStep
    }
}

export function editWorkflowStep(workflowStep) {
    return {
        type: actionTypes.workflowStepEdit,
        workflowStep
    }
}

export function deleteWorkflowStep(workflowStep) {
    return {
        type: actionTypes.workflowStepDelete,
        workflowStep
    }
}

export function obliterateWorkflowStep(workflowStep) {
    return {
        type: actionTypes.workflowStepObliterate,
        workflowStep
    }
}

export function loadWorkflowStepsSuccess(workflowSteps) {
    return {
        type: actionTypes.WorkflowStepLoadSuccess, workflowSteps
    };
}

export function loadWorkflowSteps() {
    return function(dispatch) {
        return workflowApi.getWorkflowSteps()
        .then(workflowSteps => {
            dispatch(loadWorkflowStepsSuccess(workflowSteps));
        })
        .catch(error => {
            throw(error); // TODO: Add error handler
        });
    }
}