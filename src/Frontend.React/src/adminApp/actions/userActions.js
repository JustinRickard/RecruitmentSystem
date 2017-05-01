import actionTypes from '../common/actionTypes';

export function createUser(user) {
    return {
        type: actionTypes.UserCreate,
        user
    }
}

export function editUser(user) {
    return {
        type: actionTypes.UserEdit,
        user
    }
}

export function deleteUser(user) {
    return {
        type: actionTypes.UserDelete,
        user
    }
}

export function obliterateUser(user) {
    return {
        type: actionTypes.UserObliterate,
        user
    }
}