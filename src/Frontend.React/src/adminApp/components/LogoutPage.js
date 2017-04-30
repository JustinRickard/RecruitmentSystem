import React from 'react';
import {Link} from 'react-router';

class LogoutPage extends React.Component {

    render() {
        return (
            <div>
                <div className="col-md-3"></div>
                <div className="col-md-6">
                    <ol className="breadcrumb">
                        <li className="breadcrumb-item"><a href="">Home</a></li>
                        <li className="breadcrumb-item active">Logout</li>
                    </ol>
                    <h1>You are now logged out</h1>
                </div>
                <div className="col-md-3"></div>
            </div>
        );
    }
}

export default LogoutPage;