import React from 'react';
import {Link} from 'react-router';
import {connect} from 'react-redux';

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

HomePage.propTypes = {
}

function mapStateToProps(state, ownProps) {
    return {
    };
}

function mapDispatchToProps(dispatch) {
    return {
    };
}

export default connect(mapStateToProps, mapDispatchToProps)(HomePage);