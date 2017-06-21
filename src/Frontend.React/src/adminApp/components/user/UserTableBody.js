import React from 'react';
import UserTableRow from './UserTableRow';

class UserTableBody extends React.Component {

    render() {

        const rows=[];
        for(var i=0; i < this.props.rows.length; i++) {
            rows.push(<UserTableRow row={this.props.rows[i]} key={i} />);
        }

        return (
            <tbody>
               {rows} 
            </tbody>
        );
    }
}

export default UserTableBody;