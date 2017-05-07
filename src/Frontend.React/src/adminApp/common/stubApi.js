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
    ];
}

export function getProjects() {
    return [
        {
            name: "Project 1",
            workflowName: "Workflow 1",
            closeTime: new Date()
        },
        {
            name: "Project 2",
            workflowName: "Workflow 2",
            closeTime: new Date()
        },
        {
            name: "Project 3",
            workflowName: "Workflow 3",
            closeTime: new Date()
        },
        {
            name: "Project 4",
            workflowName: "Workflow 4",
            closeTime: new Date()
        },
        {
            name: "Project 5",
            workflowName: "Workflow 5",
            closeTime: new Date()
        },
    ];
}

export function getWorkflows() {
    return [
      {
          name: "Workflow 1",
          steps: 5,
          createdDate: new Date("2017-01-01")
      },
      {
          name: "Workflow 2",
          steps: 3,
          createdDate: new Date("2017-01-01")
      },
      {
          name: "Workflow 3",
          steps: 10,
          createdDate: new Date("2017-01-01")
      },
      {
          name: "Workflow 4",
          steps: 1,
          createdDate: new Date("2017-01-01")
      },
    ];
}

export function getWorkflowSteps() {
    return [
        {
            name: "Workflow step 1",
            type: "Simple text multiple choice",
            createdDate: new Date(),
            data: {
                title: "Simple text multiple choice step",
                questions: []
            }
        },
        {
            name: "Workflow step 2",
            type: "Scenario text multiple choice",
            createdDate: new Date(),
            data: {
                title: "scenario text multiple choice step",
                questions: []
            }
        },
        {
            name: "Workflow step 3",
            type: "User input form",
            createdDate: new Date(),
            data: {
                title: "Registration form",
                questions: []
            }
        },
        {
            name: "Workflow step 4",
            type: "Eligibility check",
            createdDate: new Date(),
            data: {
                title: "Eligiblity example",
                questions: []
            }
        },
    ];
}