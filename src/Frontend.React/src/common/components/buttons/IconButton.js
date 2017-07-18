import React from 'react'

class IconButton extends React.Component {
    render() {

        const buttonClass = 'btn ' + this.props.buttonClass;
        const iconClass = 'fa ' + this.props.iconClass

        return (
            <button className={buttonClass} onClick={this.props.onClick}>
                <i className={iconClass}></i>
                {this.props.text}
            </button>
        );
    }
}

export default IconButton