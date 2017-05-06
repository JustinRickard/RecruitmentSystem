import React from 'react';

class ClientTableHead extends React.Component {
    render() {
        return (
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Parent account</th>
                    <th></th>
                    <th></th>
                    <th></th>
                </tr>
            </thead>
        );
    }
}

export default ClientTableHead;