import React from 'react';
import delay from '../delay';

const en_gb = {
    generic: {
        button: {
            back: "Back",                     
            create: "Create",
            delete: "Delete",
            details: "Details",
            edit: "Edit",
            next: "Next",
            save: "Save",
            submit: "Submit",
        },
        code: "Code",
        home: "Home",
        name: "Name"
        
    },
    client: {
        clients: "Clients",
        fields: {
            parentAccount: "Parent account"
        },
        intro: "Below is a list of all the client accounts within your control. You can search for clients using the search filter. Use the buttons to view further details and update details.",
        new: "New Client",        
        summary: "Manage clients, create new ones, etc..."
    },
    project: {
        closeTime: "Close time",
        intro: "Below is a list of all the projects within your control. You can search for projects using the search filter. Use the buttons to view further details and update projects.",
        new: "New Project",
        projects: "Projects",
        summary: "Administer projects, add participants, etc..."
    },
    user: {
        intro: "Below is a list of all users within your control. You can search for users using the search filter. Use the buttons to view further details and update user records.",
        new: "New User",
        summary: "Manage users, create new ones, etc...",
        users: "Users"
    },
    workflow: {
        new: "New Workflow",        
        summary: "Create new workflows and modify existing ones, etc...",        
        workflow: "Workflow",
        workflows: "Workflows"
    },
    workflowStep: {
        new: "New Workflow Step",
        summary: "Create new workflow steps, modify existing ones, etc",
        workflowSteps: "Workflow Steps"        
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