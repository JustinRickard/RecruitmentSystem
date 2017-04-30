import React from 'react';
import {Link} from 'react-router';

class WorkflowPage extends React.Component {

    render() {
        return (
            <div>
                <div className="col-md-3"></div>
                <div className="col-md-6">
                    <ol className="breadcrumb">
                        <li className="breadcrumb-item"><a href="">Home</a></li>
                        <li className="breadcrumb-item active">Workflows</li>
                    </ol>
                    <h1>Workflows</h1>
                </div>
                <div className="col-md-3"></div>
            </div>
        );
    }
}

export default WorkflowPage;