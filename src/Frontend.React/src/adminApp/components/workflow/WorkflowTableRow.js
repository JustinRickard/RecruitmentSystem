import React from 'react';

class WorkflowTableRow extends React.Component {
    render() {

        return (
            <tr>
                <td className="align-middle">{this.props.row.name}</td>
                <td>{this.props.row.steps}</td>
                <td>{this.props.row.createdDate.toLocaleString()}</td>
                <td><button className="btn btn-default">Details</button></td>
                <td><button className="btn btn-primary">Edit</button></td>
                <td><button className="btn btn-danger">Delete</button></td>
            </tr>
        );
    }
}

export default WorkflowTableRow;