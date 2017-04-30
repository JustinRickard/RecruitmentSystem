import React from 'react';
import {Link} from 'react-router';

class HomePage extends React.Component {

    render() {
        return (
            <div>
                <div className="col-md-3"></div>
                <div className="col-md-6">
                        <ol className="breadcrumb">
                            <li className="breadcrumb-item active"><a href="">Home</a></li>
                        </ol>
                        <h1>Home</h1>
                </div>
                <div className="col-md-3"></div>
            </div>
        );
    }
}

export default HomePage;