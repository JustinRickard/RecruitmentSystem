import React from 'react';
import {Link} from 'react-router';
import {connect} from 'react-redux';
import Panel from '../../../common/components/panel';

class HomePage extends React.Component {

    render() {
        return (
            <div>
                <div className="col-md-3"></div>
                <div className="col-md-6">

                    <div className="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                        <Link to="/clients">
                            <Panel 
                                headerClass="panel-primary text-center"
                                headerText="Clients" 
                                footerText="Manage clients, create new ones, etc..."
                                iconClass="fa-address-card"
                            />
                        </Link>
                    </div>
                    <div className="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                        <Link to="/users">
                            <Panel 
                                headerClass="panel-info text-center"
                                headerText="Users" 
                                footerText="Manage users, create new ones, etc..."
                                iconClass="fa-user-circle"
                            />
                        </Link>
                    </div>
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