import React from 'react';
import delay from '../delay';

const clients = 
[
    {
        name: "Main Client account",
        parentName: "-"
    },
    {
        name: "Client 1",
        parentName: "Main Client account"
    },
    {
        name: "Client 2",
        parentName: "Main Client account"
    },
    {
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