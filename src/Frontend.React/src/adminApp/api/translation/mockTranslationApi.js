import React from 'react';
import delay from '../delay';

const en_gb = {
    generic: {
        button: {
            next: "Next",
            back: "Back",
            submit: "Submit",
            save: "Save",
            create: "Create",
            details: "Details",
            edit: "Edit",
            delete: "Delete"            
        },
        home: "Home",
        name: "Name",
        code: "Code"
    },
    client: {
        clients: "Clients",
        summary: "Manage clients, create new ones, etc...",
        intro: "Below is a list of all the client accounts within your control. You can search for clients using the search filter. Use the buttons to view further details and update details.",
        new: "New Client",
        fields: {
            parentAccount: "Parent account"
        }       
    },
    project: {
        closeTime: "Close time",
        projects: "Projects",
        summary: "Administer projects, add participants, etc...",
        intro: "Below is a list of all the projects within your control. You can search for projects using the search filter. Use the buttons to view further details and update projects.",
        new: "New Project",
                
    },
    user: {
        intro: "Below is a list of all users within your control. You can search for users using the search filter. Use the buttons to view further details and update user records.",
        users: "Users",
        summary: "Manage users, create new ones, etc...",
        new: "New User"
    },
    workflow: {
        workflows: "Workflows",
        workflow: "Workflow",
        summary: "Create new workflows and modify existing ones, etc...",
        new: "New Workflow"
    },
    workflowStep: {
        workflowSteps: "Workflow Steps",
        summary: "Create new workflow steps, modify existing ones, etc",
        new: "New Workflow Step"
    },
    audit: {
        audits: "Audit Logs",
        summary: "View audit logs of recent activity and filter by various criteria."
    }
};

class TranslationApi {
    static getTranslations(cultureCode) {

        switch(cultureCode) {

            default:           
                return new Promise((resolve, reject) => {
                    setTimeout(() => {
                        resolve(en_gb)
                    }, 0);
                });
        }
    }
}

export default TranslationApi;