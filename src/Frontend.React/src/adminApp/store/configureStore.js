import { createStore, applyMiddleware } from 'redux';
import rootReducer from '../reducers';
import thunk from 'redux-thunk';

// applyMiddleware(middleware) can be added as a third parameter to createStore()

var initialState = {
    users: [],
    projects: [],
    workflows: [],
    workflowSteps: []
}

export default function configureStore(initialState) {
    return createStore(
        rootReducer,
        initialState,
        applyMiddleware(thunk)
    );
}