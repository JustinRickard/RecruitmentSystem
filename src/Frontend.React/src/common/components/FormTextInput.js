import React from 'react'

class FormTextInput extends React.Component {
    render() {
        return (
            <div className="form-group">
                <label for={this.props.id}>{this.props.label}</label>
                <input type="text" className="form-control" id={this.props.id} placeholder={this.props.placeholder} />
            </div>
        );
    }
}

export default FormTextInput