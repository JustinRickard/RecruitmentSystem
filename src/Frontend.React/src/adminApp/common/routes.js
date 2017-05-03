import React from 'react';
import { Route, IndexRoute }  from 'react-router';
import App from '../components/App'
import HomePage from '../components/home/HomePage';
import UserPage from '../components/user/UserPage';
import ClientPage from '../components/client/ClientPage';
import ProjectPage from '../components/project/ProjectPage';
import WorkflowPage from '../components/workflow/WorkflowPage';
import AuditPage from '../components/audit/AuditPage';
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