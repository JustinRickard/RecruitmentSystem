import React from 'react';
import delay from '../delay';

const clients = 
[
    {
        id: "CL_M001",
        name: "Main Client account",
        parentName: "-"
    },
    {
        id: "CL_S001",
        name: "Client 1",
        parentName: "Main Client account"
    },
    {
        id: "CL_S002",
        name: "Client 2",
        parentName: "Main Client account"
    },
    {
        id: "CL_S001",
        name: "Client 3",
        parentName: "Main Client account"
    },
];

class ClientApi {
    static getAllClients() {
        return new Promise((resolve, reject) => {
            setTimeout(() => {
                resolve(Object.assign([], clients))
            }, delay);
        });
    }
}

export default ClientApi;