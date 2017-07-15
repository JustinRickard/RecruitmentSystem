import React from 'react';
import text from '../../../common/text';

class ProjectTableHead extends React.Component {
    render() {
        return (
            <thead>
                <tr>
                    <th>{text("generic.name")}</th>
                    <th>{text("workflow.workflow")}</th>
                    <th>{text("project.closeTime")}</th>
                    <th></th>
                    <th></th>
                    <th></th>
                </tr>
            </thead>
        );
    }
}

export default ProjectTableHead;