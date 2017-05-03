import {combineReducers} from 'redux'
import clients from './clientReducer';
import users from './userReducer';
import projects from './projectReducer';
import workflows from './workflowReducer';
import workflowSteps from './workflowStepReducer';

const rootReducer = combineReducers({
    clients,
    users,
    projects,
    workflows,
    workflowSteps
});

export default rootReducer;