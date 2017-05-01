import React from 'react';
import {Link} from 'react-router';

class UserPage extends React.Component {

    render() {
        return (
            <div>
                <div className="col-md-3"></div>
                <div className="col-md-6">
                    <ol className="breadcrumb">
                        <li className="breadcrumb-item"><a href="">Home</a></li>
                        <li className="breadcrumb-item active">Users</li>
                    </ol>
                    <h1>Users</h1>
                </div>
                <div className="col-md-3"></div>
            </div>
        );
    }
}

export default UserPage;