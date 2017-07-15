import React from 'react';
import FormDropdownInput from '../../../common/components/FormDropdownInput';
import FormTextInput from '../../../common/components/FormTextInput';
import FormBoolInput from '../../../common/components/FormBoolInput';
import text from '../../../common/text';

class ClientForm extends React.Component {

    render() {
        return (
            <div>
            <FormDropdownInput 
                id="parentId"
                label={text("client.parentAccount")}
                options={this.props.clients.map(function(c) { return { value: c.id, text: c.Name }})}
            />

            <FormTextInput 
                id="name"
                label={text("generic.name")}
            />

            <FormTextInput 
                id="code"
                label={text("generic.code")}
            />

            </div>
        );
    }

}

export default ClientForm;