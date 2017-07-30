import React from 'react';
import PropTypes from 'prop-types';
import {Link} from 'react-router';
import {connect} from 'react-redux';
import {bindActionCreators} from 'redux';
import * as clientActions from '../../actions/clientActions';
import ClientApi from '../../api/client/mockClientApi';
// import ClientApi from '../../api/client/clientApi';
import PanelTable from '../../../common/components/PanelTable';
import ClientTableHead from './ClientTableHead';
import ClientTableBody from './ClientTableBody';
import icons from '../../../common/icons';
import text from '../../../common/text';
import Router from '../../../common/router';
import urlPaths from '../../common/urlPaths';

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
        console.log("Clicked onCreateClick");
        // Router.navigateTo(urlPaths.client.new);
        // this.props.dispatch(Router.navigateTo(urlPaths.client.new));
        dispatch(Router.navigateTo(urlPaths.client.new));
    }

    onDeleteClick() {
        this.props.actions.deleteClient(this.state.client);
    }

    onEditClick() {
        this.props.actions.editClient(this.state.client);
    }

    componentDidMount() {
        this.props.actions.loadClients();
    }

    render() {

        return (
            <div>
                <div className="col-md-2"></div>

                <div className="col-md-8">

                    <ol className="breadcrumb">
                        <li className="breadcrumb-item"><a href="">{text("generic.home")}</a></li>
                        <li className="breadcrumb-item active">{text("client.clients")}</li>
                    </ol>

                    <PanelTable
                        panelClass="panel-primary"
                        iconClass={icons.Client}
                        panelHeaderText={text("client.clients")}
                        panelBodyText={text("client.intro")}
                        headerButtonText={text("client.new")}
                        headerButtonClass="btn-success panel-header-button"
                        headerButtonIconClass="fa-plus"
                        onHeaderButtonClick={this.onCreateClick}
                    >
                        <ClientTableHead />
                        <ClientTableBody rows={this.props.clients} />
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