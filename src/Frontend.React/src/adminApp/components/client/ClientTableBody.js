import React from 'react';
import ClientTableRow from './ClientTableRow';

class ClientTableBody extends React.Component {

    render() {

        const rows=[];
        for(var i=0; i < this.props.rows.length; i++) {
            rows.push(<ClientTableRow row={this.props.rows[i]} key={i} />);
        }

        return (
            <tbody>
               {rows} 
            </tbody>
        );
    }
}

export default ClientTableBody;