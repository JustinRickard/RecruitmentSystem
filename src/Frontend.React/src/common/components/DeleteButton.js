import React from 'react';
import IconButton from './IconButton';
import T from 'i18n-react';

class DeleteButton extends React.Component {
    render() {

        const iconClass = 'fa-trash';
        const buttonClass = 'btn-danger';

        return (
            <IconButton
                iconClass={iconClass}
                text={ T.translate("generic.button.delete") }
                buttonClass={buttonClass}
                onClick={this.props.onClick}
            />
        )
    }
}

export default DeleteButton