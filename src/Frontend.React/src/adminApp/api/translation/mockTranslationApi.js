import React from 'react';
import delay from '../delay';

const en_gb = {
    generic: {
        button: {
            back: "Back",                     
            cancel: "Cancel",
            create: "Create",
            delete: "Delete",
            details: "Details",
            edit: "Edit",
            next: "Next",
            save: "Save",
            submit: "Submit",
        },
        code: "Code",
        createdDate: "Create date",
        home: "Home",
        name: "Name",
        pleaseSelectBrackets: "(Please select)"        
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
        intro: "Below is a list of all the Workflows within your control. You can search for Workflows using the search filter. Use the buttons to view further details and update Workflows.",
        new: "New Workflow",        
        summary: "Create new workflows and modify existing ones, etc...",        
        workflow: "Workflow",
        workflows: "Workflows"
    },
    workflowStep: {
        intro: "Below is a list of all the workflow steps within your control. You can search for Workflows using the search filter. Use the buttons to view further details and update workflow steps.",
        new: "New Workflow Step",
        summary: "Create new workflow steps, modify existing ones, etc",
        workflowSteps: "Workflow Steps",
        steps: "Steps"     
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