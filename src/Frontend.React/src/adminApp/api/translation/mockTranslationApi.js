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
        home: "Home"
    },
    client: {
        clients: "Clients",
        new: "New Client"
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