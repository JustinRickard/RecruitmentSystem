import React from 'react';
import IconButton from './IconButton';
import T from 'i18n-react';

class DetailsButton extends React.Component {
    render() {

        const iconClass = 'fa-info-circle';
        const buttonClass = 'btn-default';

        return (
            <IconButton
                iconClass={iconClass}
                text={ T.translate("generic.button.details") }
                buttonClass={buttonClass}
                onClick={this.props.onClick}
            />
        )
    }
}

export default DetailsButton