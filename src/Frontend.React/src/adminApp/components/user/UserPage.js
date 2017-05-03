import React, {PropTypes} from 'react';
import {Link} from 'react-router';
import {connect} from 'react-redux';
import {bindActionCreators} from 'redux';
import * as userActions from '../../actions/userActions';

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