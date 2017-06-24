import React from 'react';
import ClientApi from '../../api/client/mockClientApi';
// import ClientApi from '../../api/client/clientApi';
import FormPanel from '../../../common/components/FormPanel';
import Breadcrumb3Items from '../../../common/components/Breadcrumb3Item';
import ClientForm from './ClientForm';
import icons from '../../../common/icons';

class ClientPage extends React.Component {

    constructor(props, context) {
        super(props, context)

        this.state = {
            client: {
                name: "",
                parentId: null,
                settings: {}
            }
        }
    }

    onCreateClick() {
        this.props.actions.createClient(this.state.client);
    }

    onCancelClick() {
        // route back to clients page
    }

    render() {
        return (
            <div>
                <div className="col-md-2"></div>

                <div className="col-md-8">
                    <Breadcrumb3Items href1="Clients" label1="Clients" label2="Add" />

                    <FormPanel
                        headerClass="panel-primary"
                        iconClass={icons.Client}
                        headerText="Add Client">
                        <ClientForm />
                    </FormPanel>
                </div>

                <div className="col-md-2"></div>
            </div>
        );
    }
}