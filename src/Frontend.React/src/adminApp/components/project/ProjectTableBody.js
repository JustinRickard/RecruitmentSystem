import React from 'react';
import ProjectTableRow from './ProjectTableRow';

class ProjectTableBody extends React.Component {

    render() {

        const rows=[];
        for(var i=0; i < this.props.rows.length; i++) {
            rows.push(<ProjectTableRow row={this.props.rows[i]} key={i} />);
        }

        return (
            <tbody>
               {rows} 
            </tbody>
        );
    }
}

export default ProjectTableBody;