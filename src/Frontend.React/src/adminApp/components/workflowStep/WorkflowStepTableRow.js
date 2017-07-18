import React from 'react';
import DetailsButton from '../../../common/components/buttons/DetailsButton';
import EditButton from '../../../common/components/buttons/EditButton';
import DeleteButton from '../../../common/components/buttons/DeleteButton';

class WorkflowStepTableRow extends React.Component {

    tempOnClick() {

    }

    render() {

        return (
            <tr>
                <td className="align-middle">{this.props.row.name}</td>
                <td>{this.props.row.type}</td>
                <td>{this.props.row.createdDate.toLocaleString()}</td>
                <td><DetailsButton onClick={this.tempOnClick} /></td>
                <td><EditButton onClick={this.tempOnClick} /></td>
                <td><DeleteButton onClick={this.tempOnClick} /></td>  
            </tr>
        );
    }
}

export default WorkflowStepTableRow;