import React from 'react';

class UserTableHead extends React.Component {
    render() {
        return (
            <thead>
                <tr>
                    <th>Email</th>
                    <th>Username</th>
                    <th>Forename</th>
                    <th>Surname</th>
                    <th></th>
                    <th></th>
                    <th></th>
                </tr>
            </thead>
        );
    }
}

export default UserTableHead;