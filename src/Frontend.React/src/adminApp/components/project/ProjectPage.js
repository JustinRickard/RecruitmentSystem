import React from 'react';
import PropTypes from 'prop-types';
import {Link} from 'react-router';
import {connect} from 'react-redux';
import {bindActionCreators} from 'redux';
import * as projectActions from '../../actions/projectActions';
import * as ProjectApi from '../../api/project/mockProjectApi';
// import * as api from '../../api/project/projectApi';
import PanelTable from '../../../common/components/PanelTable';
import ProjectTableHead from './ProjectTableHead';
import ProjectTableBody from './ProjectTableBody';
import icons from '../../../common/icons';

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

    componentDidMount() {
        this.props.actions.loadProjects();
    }

    render() {

        return (
            <div>
                <div className="col-md-2"></div>
                <div className="col-md-8">
                    <ol className="breadcrumb">
                        <li className="breadcrumb-item"><a href="">Home</a></li>
                        <li className="breadcrumb-item active">Projects</li>
                    </ol>
                    
                    <PanelTable
                        panelClass="panel-primary"
                        iconClass={icons.Project}
                        panelHeaderText="Projects"
                        panelBodyText="Below is a list of all the projects within your control. You can search for projects using the search filter. Use the buttons to view further details and update projects."
                        headerButtonText="New Project"
                        headerButtonClass="btn-success panel-header-button"
                        headerButtonIconClass="fa-plus"
                        onHeaderButtonClick={this.onCreateClick}
                    >
                        <ProjectTableHead />
                        <ProjectTableBody rows={this.props.projects} />
                    </PanelTable>

                </div>
                <div className="col-md-2"></div>
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