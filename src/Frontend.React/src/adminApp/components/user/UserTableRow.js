import React from 'react';
import DetailsButton from '../../../common/components/DetailsButton';
import EditButton from '../../../common/components/EditButton';
import DeleteButton from '../../../common/components/DeleteButton';

class UserTableRow extends React.Component {

    tempOnClick() {

    }

    render() {

        return (
            <tr>
                <td>{this.props.row.email}</td>
                <td>{this.props.row.username}</td>
                <td>{this.props.row.forename}</td>
                <td>{this.props.row.surname}</td>
                <td><DetailsButton onClick={this.tempOnClick} /></td>
                <td><EditButton onClick={this.tempOnClick} /></td>
                <td><DeleteButton onClick={this.tempOnClick} /></td>  
            </tr>
        );
    }
}

export default UserTableRow;