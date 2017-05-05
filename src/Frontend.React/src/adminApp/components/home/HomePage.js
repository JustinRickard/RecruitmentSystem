import React from 'react';
import {Link} from 'react-router';
import {connect} from 'react-redux';
import PanelLink from './PanelLink';

class HomePage extends React.Component {

    render() {
        return (
            <div>
                <div className="col-md-3"></div>
                <div className="col-xs-12 col-sm-12 col-md-8">

                    <PanelLink
                        link="/clients"
                        headerClass="panel-primary"
                        headerText="Clients" 
                        footerText="Manage clients, create new ones, etc..."
                        iconClass="fa-address-card"
                    />

                    <PanelLink
                        link="/users"
                        headerClass="panel-primary"
                        headerText="Users" 
                        footerText="Manage users, create new ones, etc..."
                        iconClass="fa-user-circle"
                    />

                    <PanelLink
                        link="/projects"
                        headerClass="panel-primary"
                        headerText="Projects" 
                        footerText="Administer projects, add participants, etc..."
                        iconClass="fa-tasks"
                    />

                    <PanelLink
                        link="/audits"
                        headerClass="panel-warning"
                        headerText="Audit Logs" 
                        footerText="View audit logs of recent activity and filter by various criteria."
                        iconClass="fa-history"
                    />

                    <PanelLink
                        link="/workflows"
                        headerClass="panel-info"
                        headerText="Workflows" 
                        footerText="Create new workflows and modify existing ones, etc..."
                        iconClass="fa-briefcase"
                    />

                    <PanelLink
                        link="/workflowSteps"
                        headerClass="panel-info"
                        headerText="Workflow Steps" 
                        footerText="Create new workflow steps, modify existing ones, etc"
                        iconClass="fa-code-fork"
                    />


                </div>               
                <div className="col-md-3"></div>
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