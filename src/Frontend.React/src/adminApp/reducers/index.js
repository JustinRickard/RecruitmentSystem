import {combineReducers} from 'redux'
import clientReducer from './clientReducer';
import userReducer from './userReducer';
import projectReducer from './projectReducer';
import workflowReducer from './workflowReducer';
import workflowStepReducer from './workflowStepReducer';

const rootReducer = combineReducers({
    clientReducer,
    userReducer,
    projectReducer,
    workflowReducer,
    workflowStepReducer
});

export default rootReducer;