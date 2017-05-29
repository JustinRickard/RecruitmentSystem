import React from 'react';
import PropTypes from 'prop-types';
import {Link} from 'react-router';
import {connect} from 'react-redux';
import {bindActionCreators} from 'redux';
import * as workflowActions from '../../actions/workflowActions';
import * as api from '../../api/workflow/mockWorkflowApi';
// import * as api from '../../api/workflow/workflowApi';
import PanelTable from '../../../common/components/PanelTable';
import WorkflowTableHead from './WorkflowTableHead';
import WorkflowTableBody from './WorkflowTableBody';
import icons from '../../../common/icons';

class WorkflowPage extends React.Component {

    constructor(props, context) {
        super(props, context)

        this.state = {
            workflow: {
                title: ""
            }
        }

        this.onCreateClick = this.onCreateClick.bind(this);
        this.onDeleteClick = this.onDeleteClick.bind(this);
        this.onEditClick = this.onEditClick.bind(this);
    }    

    onCreateClick() {
        this.props.actions.createWorkflow(this.state.workflow);
    }

    onDeleteClick() {
        this.props.actions.deleteWorkflow(this.state.workflow);
    }

    onEditClick() {
        this.props.actions.editWorkflow(this.state.workflow);
    }

    render() {

        const workflows = api.getWorkflows();

        return (
            <div>
                <div className="col-md-3"></div>
                <div className="col-md-6">
                    <ol className="breadcrumb">
                        <li className="breadcrumb-item"><a href="">Home</a></li>
                        <li className="breadcrumb-item active">Workflows</li>
                    </ol>
                   
                    <PanelTable
                        panelClass="panel-info"
                        iconClass={icons.Workflow}
                        panelHeaderText="Workflows"
                        panelBodyText="Below is a list of all the Workflows within your control. You can search for Workflows using the search filter. Use the buttons to view further details and update Workflows."
                        headerButtonText="New Workflow"
                        headerButtonClass="btn-success panel-header-button"
                        headerButtonIconClass="fa-plus"
                        onHeaderButtonClick={this.onCreateClick}
                    >
                        <WorkflowTableHead />
                        <WorkflowTableBody rows={workflows} />
                    </PanelTable>

                </div>
                <div className="col-md-3"></div>
            </div>
        );
    }
}

WorkflowPage.propTypes = {
    workflows: PropTypes.array.isRequired,
    workflowSteps: PropTypes.array.isRequired,
    actions: PropTypes.object.isRequired
}

function mapStateToProps(state, ownProps) {
    return {
        workflows: state.workflows
    };
}

function mapDispatchToProps(dispatch) {
    return {
        actions: bindActionCreators(workflowActions, dispatch)
    };
}

export default connect(mapStateToProps, mapDispatchToProps)(WorkflowPage);