import React, {PropTypes} from 'react';
import {Link} from 'react-router';
import {connect} from 'react-redux';

class ClientPage extends React.Component {

    render() {
        return (
            <div>
                <div className="col-md-3"></div>
                <div className="col-md-6">
                        <ol className="breadcrumb">
                            <li className="breadcrumb-item"><a href="">Home</a></li>
                            <li className="breadcrumb-item active">Clients</li>
                        </ol>
                        <h1>Clients</h1>
                </div>
                <div className="col-md-3"></div>
            </div>
        );
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(ClientPage);