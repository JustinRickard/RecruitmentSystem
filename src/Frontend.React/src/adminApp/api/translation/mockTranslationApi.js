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
        intro: "Below is a list of all the client accounts within your control. You can search for clients using the search filter. Use the buttons to view further details and update details.",
        new: "New Client",
        fields: {
            parentAccount: "Parent account"
        }
        
    },
    project: {
        projects: "Projects",
        new: "New Project"
    },
    user: {
        users: "Users",
        new: "New User"
    },
    workflow: {
        workflows: "workflows",
        new: "New Workflow"
    },
    workflowStep: {
        clients: "Workflow Steps",
        new: "New Workflow Step"
    },
    audit: {
        audits: "Audit Logs"
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