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

export function getUsers() {
    return [
        {
            email: "example1@example.org",
            username: "example1",
            forename: "Andrew",
            surname: "Da Silva",
            roles: ["SUPER_ADMIN"],
            client: { name: "Main Client" }
        },
        {
            email: "example2@example.org",
            username: "example2",
            forename: "Badadini",
            surname: "Rocha",
            roles: ["CLIENT_ADMIN"],
            client: { name: "Main Client" }
        },
        {
            email: "example3@example.org",
            username: "example3",
            forename: "Charles",
            surname: "Finklestein",
            roles: ["PARTICIPANT"],
            client: { name: "Main Client" }
        },
        {
            email: "example4@example.org",
            username: "example4",
            forename: "Doris",
            surname: "Delaggio",
            roles: ["CLIENT_ADMIN"],
             client: { name: "Client 1" }
        }
    ]
}