import React from 'react'

class IconPanel extends React.Component {
    render() {

        const headerClass = 'panel ' + this.props.headerClass
        const iconClass = 'fa ' + this.props.iconClass + ' fa-5x'

        return (
            <div className={headerClass}>
                <div className="panel-heading">{this.props.headerText}</div>
                <div className="panel-body">
                    <i className={iconClass}></i>
                </div>
                <div className="panel-footer">
                    {this.props.footerText}
                </div>
            </div>
        );
    }
}

export default IconPanel