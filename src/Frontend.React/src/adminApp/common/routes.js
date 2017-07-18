import React from 'react';
import { Route, IndexRoute }  from 'react-router';
import App from '../components/App'
import HomePage from '../components/home/HomePage';
import UserPage from '../components/user/UserPage';
import ClientPage from '../components/client/ClientPage';
import ClientAddPage from '../components/client/ClientAddPage';
import ProjectPage from '../components/project/ProjectPage';
import WorkflowPage from '../components/workflow/WorkflowPage';
import WorkflowStepPage from '../components/workflowStep/WorkflowStepPage';
import AuditPage from '../components/audit/AuditPage';
import LogoutPage from '../components/LogoutPage';
import urlPaths from '../common/urlPaths';

export default (
        <Route path="/" component={App}>
            <IndexRoute component={HomePage} />
            <Route path={urlPaths.client.main} component={ClientPage} />
            <Route path={urlPaths.client.new} component={ClientAddPage} />
            <Route path={urlPaths.user.main} component={UserPage} />            
            <Route path={urlPaths.project.main} component={ProjectPage} />
            <Route path={urlPaths.workflow.main} component={WorkflowPage} />
            <Route path={urlPaths.workflowStep.main} component={WorkflowStepPage} />
            <Route path={urlPaths.audit.main} component={AuditPage} />
            <Route path={urlPaths.logout} component={LogoutPage} />
        </Route>
);