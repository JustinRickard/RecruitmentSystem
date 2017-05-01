import actionTypes from '../common/actionTypes';

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