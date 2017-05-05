import React from 'react';
import {Link} from 'react-router';
import {connect} from 'react-redux';
import PanelLink from './PanelLink';

class HomePage extends React.Component {

    render() {
        return (
            <div>
                <div className="col-md-3"></div>
                <div className="col-md-6">

                    <PanelLink
                        link="/clients"
                        headerClass="panel-primary text-center"
                        headerText="Clients" 
                        footerText="Manage clients, create new ones, etc..."
                        iconClass="fa-address-card"
                    />

                    <PanelLink
                        link="/users"
                        headerClass="panel-info text-center"
                        headerText="Users" 
                        footerText="Manage users, create new ones, etc..."
                        iconClass="fa-user-circle"
                    />
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