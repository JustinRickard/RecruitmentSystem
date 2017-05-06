import React from 'react';

class ClientTableRow extends React.Component {
    render() {

        return (
            <tr>
                <td>{this.props.row.name}</td>
                <td>{this.props.row.parentName}</td>
                <td><button className="btn btn-default">Details</button></td>
                <td><button className="btn btn-primary">Edit</button></td>
                <td><button className="btn btn-danger">Delete</button></td>
            </tr>
        );
    }
}

export default ClientTableRow;