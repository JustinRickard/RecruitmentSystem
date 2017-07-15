import React from 'react';
import PropTypes from 'prop-types';
import {Link} from 'react-router';
import {connect} from 'react-redux';
import {bindActionCreators} from 'redux';
import * as workflowStepActions from '../../actions/workflowStepActions';
import * as api from '../../api/workflow/mockWorkflowApi';
// import * as api from '../../api/workflow/workflowApi';
import PanelTable from '../../../common/components/PanelTable';
import WorkflowStepTableHead from './WorkflowStepTableHead';
import WorkflowStepTableBody from './WorkflowStepTableBody';
import icons from '../../../common/icons';
import text from '../../../common/text';
import urlPaths from '../../common/urlPaths';

class WorkflowStepPage extends React.Component {

    constructor(props, context) {
        super(props, context)

        this.state = {
            workflowStep: {
                title: "",
                cultureCode: "",
                type: ""                
            }
        }

        this.onCreateClick = this.onCreateClick.bind(this);
        this.onDeleteClick = this.onDeleteClick.bind(this);
        this.onEditClick = this.onEditClick.bind(this);
    }    

    onCreateClick() {
        this.props.actions.createWorkflowStep(this.state.workflowStep);
    }

    onDeleteClick() {
        this.props.actions.deleteWorkflowStep(this.state.workflowStep);
    }

    onEditClick() {
        this.props.actions.editWorkflowStep(this.state.workflowStep);
    }

    componentDidMount() {
        this.props.actions.loadWorkflowSteps();
    }

    render() {

        return (
            <div>
                <div className="col-md-2"></div>
                <div className="col-md-8">
                    <ol className="breadcrumb">
                        <li className="breadcrumb-item"><a href="">{text("generic.home")}</a></li>
                        <li className="breadcrumb-item"><a href={urlPaths.workflow.main}>{text("workflow.workflows")}</a></li>
                        <li className="breadcrumb-item active">{text("workflowStep.workflowSteps")}</li>
                    </ol>
                    
                    <PanelTable
                        panelClass="panel-info"
                        iconClass={icons.WorkflowStep}
                        panelHeaderText={text("workflowStep.workflowSteps")}
                        panelBodyText={text("workflowStep.intro")}
                        headerButtonText={text("workflowStep.new")}
                        headerButtonClass="btn-success panel-header-button"
                        headerButtonIconClass="fa-plus"
                        onHeaderButtonClick={this.onCreateClick}
                    >
                        <WorkflowStepTableHead />
                        <WorkflowStepTableBody rows={this.props.workflowSteps} />
                    </PanelTable>

                </div>
                <div className="col-md-2"></div>
            </div>
        );
    }
}

WorkflowStepPage.propTypes = {
    workflowSteps: PropTypes.array.isRequired,
    actions: PropTypes.object.isRequired
}

function mapStateToProps(state, ownProps) {
    return {
        workflowSteps: state.workflowSteps
    };
}

function mapDispatchToProps(dispatch) {
    return {
        actions: bindActionCreators(workflowStepActions, dispatch)
    };
}

export default connect(mapStateToProps, mapDispatchToProps)(WorkflowStepPage);