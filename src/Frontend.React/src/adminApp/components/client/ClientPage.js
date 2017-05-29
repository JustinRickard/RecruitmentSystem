import React from 'react';
import PropTypes from 'prop-types';
import {Link} from 'react-router';
import {connect} from 'react-redux';
import {bindActionCreators} from 'redux';
import * as clientActions from '../../actions/clientActions';
import * as api from '../../api/client/mockClientApi';
// import * as api from '../../api/client/clientApi';
import PanelTable from '../../../common/components/PanelTable';
import ClientTableHead from './ClientTableHead';
import ClientTableBody from './ClientTableBody';
import icons from '../../../common/icons';

class ClientPage extends React.Component {

    constructor(props, context) {
        super(props, context)

        this.state = {
            client: {
                name: "",
                settings: {}
            }
        }

        this.onCreateClick = this.onCreateClick.bind(this);
        this.onDeleteClick = this.onDeleteClick.bind(this);
        this.onEditClick = this.onEditClick.bind(this);
    }    

    onCreateClick() {
        this.props.actions.createClient(this.state.client);
    }

    onDeleteClick() {
        this.props.actions.deleteClient(this.state.client);
    }

    onEditClick() {
        this.props.actions.editClient(this.state.client);
    }

    render() {

        const clients = api.getClients();

        return (
            <div>
                <div className="col-md-2"></div>

                <div className="col-md-8">

                    <ol className="breadcrumb">
                        <li className="breadcrumb-item"><a href="">Home</a></li>
                        <li className="breadcrumb-item active">Clients</li>
                    </ol>

                    <PanelTable
                        panelClass="panel-primary"
                        iconClass={icons.Client}
                        panelHeaderText="Clients"
                        panelBodyText="Below is a list of all the client accounts within your control. You can search for clients using the search filter. Use the buttons to view further details and update details."
                        headerButtonText="New Client"
                        headerButtonClass="btn-success panel-header-button"
                        headerButtonIconClass="fa-plus"
                        onHeaderButtonClick={this.onCreateClick}
                    >
                        <ClientTableHead />
                        <ClientTableBody rows={clients} />
                    </PanelTable>
                </div>

                <div className="col-md-2"></div>
            </div>
        );
    }
}

ClientPage.propTypes = {
    clients: PropTypes.array.isRequired,
    actions: PropTypes.object.isRequired
}

function mapStateToProps(state, ownProps) {
    return {
        clients: state.clients
    };
}

function mapDispatchToProps(dispatch) {
    return {
        actions: bindActionCreators(clientActions, dispatch)
    };
}

export default connect(mapStateToProps, mapDispatchToProps)(ClientPage);