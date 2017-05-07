import React from 'react';
import WorkflowStepTableRow from './WorkflowStepTableRow';

class WorkflowStepTableBody extends React.Component {

    render() {

        const rows=[];
        for(var i=0; i < this.props.rows.length; i++) {
            rows.push(<WorkflowStepTableRow row={this.props.rows[i]} />);
        }

        return (
            <tbody>
               {rows} 
            </tbody>
        );
    }
}

export default WorkflowStepTableBody;