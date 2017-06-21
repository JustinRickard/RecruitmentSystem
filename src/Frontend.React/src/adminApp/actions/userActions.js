import actionTypes from '../common/actionTypes';
import userApi from '../api/user/mockUserApi';
// import userApi from '../api/user/userApi';

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

export function loadUsersSuccess(users) {
    return {
        type: actionTypes.UserLoadSuccess, users
    };
}

export function loadUsers() {
    return function(dispatch) {
        return userApi.getUsers()
        .then(users => {
            dispatch(loadUsersSuccess(users));
        })
        .catch(error => {
            throw(error); // TODO: Add error handler
        });
    }
}