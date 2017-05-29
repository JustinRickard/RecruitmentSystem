import React from 'react';
import IconButton from './IconButton';

class DeleteButton extends React.Component {
    render() {

        const iconClass = 'fa-trash';
        const buttonClass = 'btn-danger';
        const text = 'Delete'; // TODO: Translate with i18n

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

export default DeleteButton