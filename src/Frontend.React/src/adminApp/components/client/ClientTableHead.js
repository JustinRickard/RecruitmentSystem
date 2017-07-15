import React from 'react';
import text from '../../../common/text';

class ClientTableHead extends React.Component {
    render() {
        return (
            <thead>
                <tr>
                    <th>{text("generic.name")}</th>
                    <th>{text("client.fields.parentAccount")}</th>
                    <th></th>
                    <th></th>
                    <th></th>
                </tr>
            </thead>
        );
    }
}

export default ClientTableHead;