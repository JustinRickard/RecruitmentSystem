import React from 'react'

class FormTextInput extends React.Component {
    render() {
        return (
            <div class="form-group">
                <label for={this.props.id}>{this.props.label}</label>
                <input type="text" class="form-control" id={this.props.id} placeholder={this.props.placeholder} />
            </div>
        );
    }
}

export default FormTextInput