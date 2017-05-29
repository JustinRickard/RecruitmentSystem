import React from 'react';
import IconButton from './IconButton';

class EditButton extends React.Component {
    render() {

        const iconClass = 'fa-edit';
        const buttonClass = 'btn-primary';
        const text = 'Edit'; // TODO: Translate with i18n

        return (
            <IconButton
                iconClass={iconClass}
                text={text}
                buttonClass={buttonClass}
                onClick={this.props.onClick}
            />
        )
    }
}

export default EditButton