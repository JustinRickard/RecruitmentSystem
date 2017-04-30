import React from 'react';
import { Route, IndexRoute }  from 'react-router';
import App from './components/App'
import HomePage from './components/HomePage';
import UserPage from './components/UserPage';
import ClientPage from './components/ClientPage';
import ProjectPage from './components/ProjectPage';
import WorkflowPage from './components/WorkflowPage';
import AuditPage from './components/AuditPage';

export default (
    <Route path="/" component={App}>
        <IndexRoute component={HomePage} />
        <Route path="/user" component={UserPage} />
        <Route path="/client" component={ClientPage} />
        <Route path="/project" component={ProjectPage} />
        <Route path="/workflow" component={WorkflowPage} />
        <Route path="/audit" component={AuditPage} />
    </Route>
);