import React from 'react';
import DetailsButton from '../../../common/components/DetailsButton';
import EditButton from '../../../common/components/EditButton';
import DeleteButton from '../../../common/components/DeleteButton';

class ClientTableRow extends React.Component {

    tempOnClick() {
    }

    render() {

        return (
            <tr>
                <td className="align-middle">{this.props.row.name}</td>
                <td>{this.props.row.parentName}</td>
                <td><DetailsButton onClick={this.tempOnClick} /></td>
                <td><EditButton onClick={this.tempOnClick} /></td>
                <td><DeleteButton onClick={this.tempOnClick} /></td>                
            </tr>
        );
    }

    
}

export default ClientTableRow;