import actionTypes from '../common/actionTypes';

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