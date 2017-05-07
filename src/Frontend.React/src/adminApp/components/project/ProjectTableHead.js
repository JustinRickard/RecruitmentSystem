import React from 'react';

class ProjectTableHead extends React.Component {
    render() {
        return (
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Workflow</th>
                    <th>Close time</th>
                    <th></th>
                    <th></th>
                    <th></th>
                </tr>
            </thead>
        );
    }
}

export default ProjectTableHead;