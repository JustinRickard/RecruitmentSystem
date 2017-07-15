import React from 'react';
import delay from '../delay';

const workflows = [
    {
        id: "WF_001",
        name: "Workflow 1",
        steps: 5,
        createdDate: new Date("2017-11-01")
    },
    {
        id: "WF_002",
        name: "Workflow 2",
        steps: 3,
        createdDate: new Date("2017-07-21")
    },
    {
        id: "WF_003",
        name: "Workflow 3",
        steps: 10,
        createdDate: new Date("2017-03-11")
    },
    {
        id: "WF_004",
        name: "Workflow 4",
        steps: 1,
        createdDate: new Date("2017-01-01")
    },
];

const workflowSteps = [
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

export function getWorkflows() {
    return workflows;
}

export function getWorkflowSteps() {
    return workflowSteps;
}

class WorkflowApi {
    static getWorkflows() {
        return new Promise((resolve, reject) => {
            setTimeout(() => {
                resolve(Object.assign([], workflows))
            }, delay);
        });
    }

    static getWorkflowSteps() {
        return new Promise((resolve, reject) => {
            setTimeout(() => {
                resolve(Object.assign([], workflowSteps))
            }, delay);
        });
    }
}

export default WorkflowApi;