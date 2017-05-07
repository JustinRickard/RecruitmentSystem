import React from 'react'

class PanelTable extends React.Component {
    render() {

        const panelClass = 'panel ' + this.props.panelClass;
        const iconClass = 'fa ' + this.props.iconClass + ' fa-2x fa-fw';

        return (
            <div className={panelClass}>
                <div className="panel-heading">
                    <i className={iconClass} style={{'margin-right':'10px'}}></i>
                    <h3 style={{display:'inline'}}>{this.props.panelHeaderText}</h3>
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