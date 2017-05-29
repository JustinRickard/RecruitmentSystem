import React from 'react';

export function getClients() {
    
    return [
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
}