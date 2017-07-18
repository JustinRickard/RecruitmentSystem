import React from 'react';
import IconButton from './IconButton';
import text from '../../text';

class SaveButton extends React.Component {
    render() {

        const iconClass = 'fa-save';
        const buttonClass = 'btn-primary';

        return (
            <IconButton
                iconClass={iconClass}
                text={ text("generic.button.save") }
                buttonClass={buttonClass}
                onClick={this.props.onClick}
            />
        )
    }
}

export default SaveButton