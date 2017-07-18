import React from 'react'
import SaveButton from './buttons/SaveButton';
import CancelButton from './buttons/CancelButton';

class FormPanel extends React.Component {
    render() {

        const headerClass = 'panel ' + this.props.headerClass
        const iconClass = 'fa ' + this.props.iconClass + ' fa-2x fa-fw';

        return (
            <div className={headerClass}>
                <div className="panel-heading">
                    <i className={iconClass}></i>
                    <h3>{this.props.headerText}</h3>
                    </div>
                <div className="panel-body">
                    {this.props.children}
                    <hr />
                    <div className="btn-toolbar">              
                        <CancelButton onClick={this.props.onCancelClick} />
                        <SaveButton onClick={this.props.onSaveClick} />
                    </div>
                </div>
            </div>
        );
    }
}

export default FormPanel