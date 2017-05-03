import React from 'react';
import {Link} from 'react-router';
import {connect} from 'react-redux';
import {bindActionCreators} from 'redux';
import * as projectActions from '../../actions/projectActions';

class ProjectPage extends React.Component {

    constructor(props, context) {
        super(props, context)

        this.state = {
            project: {
                title: "",
                workflowId: null,
                loginMethod: "",
                openTime: null,
                closeTime: null,
                participants: []
            }
        }

        this.onCreateClick = this.onCreateClick.bind(this);
        this.onDeleteClick = this.onDeleteClick.bind(this);
        this.onEditClick = this.onEditClick.bind(this);
    }    

    onCreateClick() {
        this.props.actions.createProject(this.state.project);
    }

    onDeleteClick() {
        this.props.actions.deleteProject(this.state.project);
    }

    onEditClick() {
        this.props.actions.editProject(this.state.project);
    }

    render() {
        return (
            <div>
                <div className="col-md-3"></div>
                <div className="col-md-6">
                        <ol className="breadcrumb">
                            <li className="breadcrumb-item"><a href="">Home</a></li>
                            <li className="breadcrumb-item active">Projects</li>
                        </ol>
                        <h1>Projects</h1>
                </div>
                <div className="col-md-3"></div>
            </div>
        );
    }
}

ProjectPage.propTypes = {
    projects: PropTypes.array.isRequired,
    actions: PropTypes.object.isRequired
}

function mapStateToProps(state, ownProps) {
    return {
        projects: state.projects
    };
}

function mapDispatchToProps(dispatch) {
    return {
        actions: bindActionCreators(projectActions, dispatch)
    };
}


export default connect(mapStateToProps, mapDispatchToProps)(ProjectPage);