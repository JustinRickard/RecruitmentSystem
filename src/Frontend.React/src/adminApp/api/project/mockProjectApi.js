import React from 'react';
import delay from '../delay';

const projects = [
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

class ProjectApi {
    static getProjects() {
        return new Promise((resolve, reject) => {
            setTimeout(() => {
                resolve(Object.assign([], projects))
            }, delay);
        });
    }
}

export default ProjectApi;