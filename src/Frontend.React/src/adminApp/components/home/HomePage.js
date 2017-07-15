import React from 'react';
import {Link} from 'react-router';
import {connect} from 'react-redux';
import PanelLink from './PanelLink';
import icons from '../../../common/icons';
import text from '../../../common/text';
import urlPaths from '../../common/urlPaths';

class HomePage extends React.Component {

    render() {
        return (
            <div>
                <div className="col-md-2"></div>
                <div className="col-xs-12 col-sm-12 col-md-8">

                    <PanelLink
                        link={urlPaths.client.main}
                        headerClass="panel-primary"
                        headerText={text("client.clients")}
                        footerText={text("client.summary")}
                        iconClass={icons.Client}
                    />

                    <PanelLink
                        link={urlPaths.user.main}
                        headerClass="panel-primary"
                        headerText={text("user.users")}
                        footerText={text("user.summary")}
                        iconClass={icons.User}
                    />

                    <PanelLink
                        link={urlPaths.project.main}
                        headerClass="panel-primary"
                        headerText={text("project.projects")}
                        footerText={text("project.summary")}
                        iconClass={icons.Project}
                    />

                    <PanelLink
                        link={urlPaths.audit.main}
                        headerClass="panel-warning"
                        headerText={text("audit.audits")}
                        footerText={text("audit.summary")}
                        iconClass={icons.Audit}
                    />

                    <PanelLink
                        link={urlPaths.workflow.main}
                        headerClass="panel-info"
                        headerText={text("workflow.workflows")}
                        footerText={text("workflow.summary")}
                        iconClass={icons.Workflow}
                    />

                    <PanelLink
                        link={urlPaths.workflowStep.main}
                        headerClass="panel-info"
                        headerText={text("workflowStep.workflowSteps")}
                        footerText={text("workflowStep.summary")}
                        iconClass={icons.WorkflowStep}
                    />

                </div>               
                <div className="col-md-2"></div>
            </div>
        );
    }
}

HomePage.propTypes = {
}

function mapStateToProps(state, ownProps) {
    return {
    };
}

function mapDispatchToProps(dispatch) {
    return {
    };
}

export default connect(mapStateToProps, mapDispatchToProps)(HomePage);