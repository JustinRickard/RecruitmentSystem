import React from 'react';

class WorkflowTableHead extends React.Component {
    render() {
        return (
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Steps</th>
                    <th>Created date</th>
                    <th></th>
                    <th></th>
                    <th></th>
                </tr>
            </thead>
        );
    }
}

export default WorkflowTableHead;