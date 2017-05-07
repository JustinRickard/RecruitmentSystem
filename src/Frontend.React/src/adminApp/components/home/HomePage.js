import React from 'react';
import {Link} from 'react-router';
import {connect} from 'react-redux';
import PanelLink from './PanelLink';
import icons from '../../../common/icons';

class HomePage extends React.Component {

    render() {
        return (
            <div>
                <div className="col-md-2"></div>
                <div className="col-xs-12 col-sm-12 col-md-8">

                    <PanelLink
                        link="/clients"
                        headerClass="panel-primary"
                        headerText="Clients" 
                        footerText="Manage clients, create new ones, etc..."
                        iconClass={icons.Client}
                    />

                    <PanelLink
                        link="/users"
                        headerClass="panel-primary"
                        headerText="Users" 
                        footerText="Manage users, create new ones, etc..."
                        iconClass={icons.User}
                    />

                    <PanelLink
                        link="/projects"
                        headerClass="panel-primary"
                        headerText="Projects" 
                        footerText="Administer projects, add participants, etc..."
                        iconClass={icons.Project}
                    />

                    <PanelLink
                        link="/audits"
                        headerClass="panel-warning"
                        headerText="Audit Logs" 
                        footerText="View audit logs of recent activity and filter by various criteria."
                        iconClass={icons.Audit}
                    />

                    <PanelLink
                        link="/workflows"
                        headerClass="panel-info"
                        headerText="Workflows" 
                        footerText="Create new workflows and modify existing ones, etc..."
                        iconClass={icons.Workflow}
                    />

                    <PanelLink
                        link="/workflowSteps"
                        headerClass="panel-info"
                        headerText="Workflow Steps" 
                        footerText="Create new workflow steps, modify existing ones, etc"
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