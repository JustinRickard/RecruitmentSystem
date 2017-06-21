import actionTypes from '../common/actionTypes';
import workflowApi from '../api/workflow/mockWorkflowApi';
// import workflowApi from '../api/workflow/workflowApi';

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

export function loadWorkflowsSuccess(workflows) {
    return {
        type: actionTypes.WorkflowLoadSuccess, workflows
    };
}

export function loadWorkflows() {
    return function(dispatch) {
        return workflowApi.getWorkflows()
        .then(workflows => {
            dispatch(loadWorkflowsSuccess(workflows));
        })
        .catch(error => {
            throw(error); // TODO: Add error handler
        });
    }
}