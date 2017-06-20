import React from 'react';
import delay from '../delay';

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