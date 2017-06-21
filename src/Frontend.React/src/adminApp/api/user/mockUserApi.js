import React from 'react';
import delay from '../delay';

const users = [
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
];

class UserApi {
    static getUsers() {
        return new Promise((resolve, reject) => {
            setTimeout(() => {
                resolve(Object.assign([], users))
            }, delay);
        });
    }
}

export default UserApi;