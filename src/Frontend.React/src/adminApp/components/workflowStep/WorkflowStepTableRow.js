import React from 'react';

class WorkflowStepTableRow extends React.Component {
    render() {

        return (
            <tr>
                <td className="align-middle">{this.props.row.name}</td>
                <td>{this.props.row.type}</td>
                <td>{this.props.row.createdDate.toLocaleString()}</td>
                <td><button className="btn btn-default">Details</button></td>
                <td><button className="btn btn-primary">Edit</button></td>
                <td><button className="btn btn-danger">Delete</button></td>
            </tr>
        );
    }
}

export default WorkflowStepTableRow;