import actionTypes from '../common/actionTypes';

export function createClient(client) {
    return {
        type: actionTypes.ClientCreate,
        client
    }
}

export function editClient(client) {
    return {
        type: actionTypes.ClientEdit,
        client
    }
}

export function deleteClient(client) {
    return {
        type: actionTypes.ClientDelete,
        client
    }
}

export function obliterateClient(client) {
    return {
        type: actionTypes.ClientObliterate,
        client
    }
}