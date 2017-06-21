import actionTypes from '../common/actionTypes';
import projectApi from '../api/project/mockProjectApi';
// import projectApi from '../api/project/projectApi';

export function createProject(project) {
    return {
        type: actionTypes.ProjectCreate,
        project
    }
}

export function editProject(project) {
    return {
        type: actionTypes.ProjectEdit,
        project
    }
}

export function deleteProject(project) {
    return {
        type: actionTypes.ProjectDelete,
        project
    }
}

export function obliterateProject(project) {
    return {
        type: actionTypes.ProjectObliterate,
        project
    }
}

export function addUsersToProject(project, users) {
    return {
        type: actionTypes.ProjectAddUsers,
        project,
        users
    }
}

export function removeUsersFromProject(project, users) {
    return {
        type: actionTypes.ProjecAddUser,
        project,
        users
    }
}

export function loadProjectsSuccess(projects) {
    return {
        type: actionTypes.ProjectLoadSuccess, projects
    };
}

export function loadProjects() {
    return function(dispatch) {
        return projectApi.getProjects()
        .then(projects => {
            dispatch(loadProjectsSuccess(projects));
        })
        .catch(error => {
            throw(error); // TODO: Add error handler
        });
    }
}