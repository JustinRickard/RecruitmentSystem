import React from 'react';
import PropTypes from 'prop-types';
import {Link} from 'react-router';
import {connect} from 'react-redux';
import {bindActionCreators} from 'redux';
import * as userActions from '../../actions/userActions';
import * as UserApi from '../../api/user/mockUserApi';
// import * as api from '../../api/user/userApi';
import PanelTable from '../../../common/components/PanelTable';
import UserTableHead from './UserTableHead';
import UserTableBody from './UserTableBody';
import icons from '../../../common/icons';
import text from '../../../common/text';

class UserPage extends React.Component {

    constructor(props, context) {
        super(props, context)

        this.state = {
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

    componentDidMount() {
        this.props.actions.loadUsers();
    }

    render() {

        return (
            <div>
                <div className="col-md-2"></div>

                <div className="col-md-8">

                    <ol className="breadcrumb">
                        <li className="breadcrumb-item"><a href="">{text("generic.home")}</a></li>
                        <li className="breadcrumb-item active">{text("user.users")}</li>
                    </ol>

                    <PanelTable
                        panelClass="panel-primary"
                        iconClass={icons.User}
                        panelHeaderText={text("user.users")}
                        panelBodyText={text("user.intro")}
                        headerButtonText={text("user.new")}
                        headerButtonClass="btn-success panel-header-button"
                        headerButtonIconClass="fa-plus"
                        onHeaderButtonClick={this.onCreateClick}
                    >
                        <UserTableHead />
                        <UserTableBody rows={this.props.users} />
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