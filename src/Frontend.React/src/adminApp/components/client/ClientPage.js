import React from 'react';
import PropTypes from 'prop-types';
import {Link} from 'react-router';
import {connect} from 'react-redux';
import {bindActionCreators} from 'redux';
import * as clientActions from '../../actions/clientActions';
import ClientTable from './ClientTable';
import * as api from '../../common/stubApi';
import PanelTable from '../../../common/components/PanelTable';
import ClientTableHead from './ClientTableHead';
import ClientTableBody from './ClientTableBody';

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
                    <PanelTable
                        panelClass="panel-primary"
                        panelHeaderText="Clients"
                        panelBodyText="Below is a list of all the client accounts within your control. You can search for clients using the search filter. Use the buttons to view further details and update details."
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