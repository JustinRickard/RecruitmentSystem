import React from 'react'
import IconButton from './IconButton';

class PanelTable extends React.Component {
    render() {

        const panelClass = 'panel ' + this.props.panelClass;
        const iconClass = 'fa ' + this.props.iconClass + ' fa-2x fa-fw';

        return (
            <div className={panelClass}>
                <div className="panel-heading">
                    <i className={iconClass}></i>
                    <h3>{this.props.panelHeaderText}</h3>
                    {this.props.headerButtonText &&
                        <IconButton buttonClass={this.props.headerButtonClass} iconClass={this.props.headerButtonIconClass} text={this.props.headerButtonText} onClick={this.props.onHeaderButonClick}  />
                    }
                    </div>                    
                <div className="panel-body">
                    <p>{this.props.panelBodyText}</p>
                </div>

                <table className="table table-striped table-responsive table-hover">
                    {this.props.children}
                </table>
            </div>
        );
    }
}

export default PanelTable