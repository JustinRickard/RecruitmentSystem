import React from 'react';
import {Link} from 'react-router';

class ProjectPage extends React.Component {

    render() {
        return (
            <div>
                <div className="col-md-3"></div>
                <div className="col-md-6">
                        <ol className="breadcrumb">
                            <li className="breadcrumb-item"><a href="">Home</a></li>
                            <li className="breadcrumb-item active">Projects</li>
                        </ol>
                        <h1>Projects</h1>
                </div>
                <div className="col-md-3"></div>
            </div>
        );
    }
}

export default ProjectPage;