import React from 'react';
import WorkflowTableRow from './WorkflowTableRow';

class WorkflowTableBody extends React.Component {

    render() {

        const rows=[];
        for(var i=0; i < this.props.rows.length; i++) {
            rows.push(<WorkflowTableRow row={this.props.rows[i]} key={i} />);
        }

        return (
            <tbody>
               {rows} 
            </tbody>
        );
    }
}

export default WorkflowTableBody;