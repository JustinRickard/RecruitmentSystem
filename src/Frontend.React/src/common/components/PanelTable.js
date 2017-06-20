import React from 'react'
import IconButton from './IconButton';

class PanelTable extends React.Component {
    render() {

        const panelClass = 'panel ' + this.props.panelClass;
        const iconClass = 'fa ' + this.props.iconClass + ' fa-2x fa-fw';

        console.log(this.props.children);
        let content = null;

        // TODO: Replace children[1] with an enum
        if (this.props.children[1].props.rows.length > 0) {
            content =
                 <table className="table table-striped table-responsive table-hover">
                    {this.props.children}
                </table>
        } else {
            content = 
                <div>
                    <i className="spinner fa fa-refresh fa-spin fa-5x fa-fw"></i>
                    <span className="sr-only">Loading...</span>
                </div>
        }

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
                {content}                
            </div>
        );
    }
}

export default PanelTable