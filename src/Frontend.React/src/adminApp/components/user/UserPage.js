import React from 'react';
import PropTypes from 'prop-types';
import {Link} from 'react-router';
import {connect} from 'react-redux';
import {bindActionCreators} from 'redux';
import * as userActions from '../../actions/userActions';
import * as api from '../../common/stubApi';
import PanelTable from '../../../common/components/PanelTable';
import UserTableHead from './UserTableHead';
import UserTableBody from './UserTableBody';

class UserPage extends React.Component {

    constructor(props, context) {
        super(props, context)

        this.state = {
            user: {
                firstName: "",
                surname: "",
                email: "",
                useEmailAsLogin: true
            }
        }

        this.onCreateClick = this.onCreateClick.bind(this);
        this.onDeleteClick = this.onDeleteClick.bind(this);
        this.onEditClick = this.onEditClick.bind(this);
    }    

    onCreateClick() {
        this.props.actions.createUser(this.state.user);
    }

    onDeleteClick() {
        this.props.actions.deleteUser(this.state.user);
    }

    onEditClick() {
        this.props.actions.editUser(this.state.user);
    }

    render() {

        const users = api.getUsers();

        return (
            <div>
                <div className="col-md-2"></div>

                <div className="col-md-8">
                    <PanelTable
                        panelClass="panel-primary"
                        panelHeaderText="Users"
                        panelBodyText="Below is a list of all users within your control. You can search for users using the search filter. Use the buttons to view further details and update user records."
                    >
                        <UserTableHead />
                        <UserTableBody rows={users} />
                    </PanelTable>
                </div>

                <div className="col-md-2"></div>
            </div>
        );
    }
}

UserPage.propTypes = {
    users: PropTypes.array.isRequired,
    actions: PropTypes.object.isRequired
}

function mapStateToProps(state, ownProps) {
    return {
        users: state.users
    };
}

function mapDispatchToProps(dispatch) {
    return {
        actions: bindActionCreators(userActions, dispatch)
    };
}

export default connect(mapStateToProps, mapDispatchToProps)(UserPage);