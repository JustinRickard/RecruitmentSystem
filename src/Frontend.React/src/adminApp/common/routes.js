import React from 'react';
import { Route, IndexRoute }  from 'react-router';
import App from '../components/App'
import HomePage from '../components/HomePage';
import UserPage from '../components/UserPage';
import ClientPage from '../components/ClientPage';
import ProjectPage from '../components/ProjectPage';
import WorkflowPage from '../components/WorkflowPage';
import AuditPage from '../components/AuditPage';
import LogoutPage from '../components/LogoutPage';

export default (
        <Route path="/" component={App}>
            <IndexRoute component={HomePage} />
            <Route path="/users" component={UserPage} />
            <Route path="/clients" component={ClientPage} />
            <Route path="/projects" component={ProjectPage} />
            <Route path="/workflows" component={WorkflowPage} />
            <Route path="/audits" component={AuditPage} />
            <Route path="/logout" component={LogoutPage} />
        </Route>
);