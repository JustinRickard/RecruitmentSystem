import React from 'react';
import text from '../../../common/text';

class WorkflowStepTableHead extends React.Component {
    render() {
        return (
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Type</th>
                    <th>Created date</th>
                    <th></th>
                    <th></th>
                    <th></th>
                </tr>
            </thead>
        );
    }
}

export default WorkflowStepTableHead;