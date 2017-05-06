import React from 'react'

class PanelTable extends React.Component {
    render() {

        const panelClass = 'panel ' + this.props.panelClass;

        return (
            <div className={panelClass}>
                <div className="panel-heading">{this.props.panelHeaderText}</div>
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