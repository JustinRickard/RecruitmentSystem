import React from 'react';

class UserTableRow extends React.Component {
    render() {

        return (
            <tr>
                <td>{this.props.row.email}</td>
                <td>{this.props.row.username}</td>
                <td>{this.props.row.forename}</td>
                <td>{this.props.row.surname}</td>
                <td><button className="btn btn-default">Details</button></td>
                <td><button className="btn btn-primary">Edit</button></td>
                <td><button className="btn btn-danger">Delete</button></td>
            </tr>
        );
    }
}

export default UserTableRow;