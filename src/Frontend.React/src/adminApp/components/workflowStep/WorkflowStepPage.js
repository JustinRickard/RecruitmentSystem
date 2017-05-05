import React from 'react';
import PropTypes from 'prop-types';
import {Link} from 'react-router';
import {connect} from 'react-redux';
import {bindActionCreators} from 'redux';
import * as workflowStepActions from '../../actions/workflowStepActions';

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

    render() {
        return (
            <div>
                <div className="col-md-3"></div>
                <div className="col-md-6">
                    <ol className="breadcrumb">
                        <li className="breadcrumb-item"><a href="">Home</a></li>
                        <li className="breadcrumb-item"><a href="/workflows">Workflows</a></li>
                        <li className="breadcrumb-item active">Workflow Steps</li>
                    </ol>
                    <h1>Workflows</h1>
                </div>
                <div className="col-md-3"></div>
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