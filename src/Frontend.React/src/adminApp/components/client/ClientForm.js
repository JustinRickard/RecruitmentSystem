import React from 'react';
import FormDropdownInput from '../../../common/components/FormDropdownInput';
import FormTextInput from '../../../common/components/FormTextInput';
import FormBoolInput from '../../../common/components/FormBoolInput';


class ClientForm extends React.Component {

    render() {
        return (
            <div>
            <FormDropdownInput 
                id="parentId"
                label="Parent account"
                options={this.props.clients.map(function(c) { return { value: c.id, text: c.Name }})}
            />

            <FormTextInput 
                id="name"
                label="Name"
            />

            <FormTextInput 
                id="code"
                label="Code"
            />

            </div>
        );
    }

}

export default ClientForm;