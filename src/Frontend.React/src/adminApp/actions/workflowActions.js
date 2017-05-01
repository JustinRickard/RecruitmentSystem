import actionTypes from '../common/actionTypes';

export function createWorkflow(workflow) {
    return {
        type: actionTypes.WorkflowCreate,
        workflow
    }
}

export function editWorkflow(workflow) {
    return {
        type: actionTypes.WorkflowEdit,
        workflow
    }
}

export function deleteWorkflow(workflow) {
    return {
        type: actionTypes.WorkflowDelete,
        workflow
    }
}

export function obliterateWorkflow(workflow) {
    return {
        type: actionTypes.WorkflowObliterate,
        workflow
    }
}