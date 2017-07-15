import React from 'react';
import text from '../../../common/text';

class WorkflowTableHead extends React.Component {
    render() {
        return (
            <thead>
                <tr>
                    <th>{text("generic.name")}</th>
                    <th>{text("workflow.steps")}</th>
                    <th>{text("generic.createdDate")}</th>
                    <th></th>
                    <th></th>
                    <th></th>
                </tr>
            </thead>
        );
    }
}

export default WorkflowTableHead;