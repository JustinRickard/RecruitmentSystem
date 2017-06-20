import actionTypes from '../common/actionTypes';
import clientApi from '../api/client/mockClientApi';
// import clientApi from '../api/client/clientApi';

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

export function loadClientsSuccess(clients) {
    return {
        type: actionTypes.ClientLoadSuccess, clients
    };
}

export function loadClients() {
    return function(dispatch) {
        return clientApi.getAllClients()
        .then(clients => {
            dispatch(loadClientsSuccess(clients));
        })
        .catch(error => {
            throw(error); // TODO: Add error handler
        });
    }
}