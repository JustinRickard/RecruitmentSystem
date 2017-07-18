import React from 'react';
import IconButton from './IconButton';
import text from '../../text';

class CancelButton extends React.Component {
    render() {

        const iconClass = 'fa-arrow-left';
        const buttonClass = 'btn-default';

        return (
            <IconButton
                iconClass={iconClass}
                text={ text("generic.button.cancel") }
                buttonClass={buttonClass}
                onClick={this.props.onClick}
            />
        )
    }
}

export default CancelButton