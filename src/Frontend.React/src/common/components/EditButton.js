import React from 'react';
import IconButton from './IconButton';
import T from 'i18n-react';

class EditButton extends React.Component {
    render() {

        const iconClass = 'fa-edit';
        const buttonClass = 'btn-primary';

        return (
            <IconButton
                iconClass={iconClass}
                text={ T.translate("generic.button.edit") }
                buttonClass={buttonClass}
                onClick={this.props.onClick}
            />
        )
    }
}

export default EditButton