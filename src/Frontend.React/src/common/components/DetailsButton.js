import React from 'react';
import IconButton from './IconButton';

class DetailsButton extends React.Component {
    render() {

        const iconClass = 'fa-info-circle';
        const buttonClass = 'btn-default';
        const text = 'Details'; // TODO: Translate with i18n

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

export default DetailsButton