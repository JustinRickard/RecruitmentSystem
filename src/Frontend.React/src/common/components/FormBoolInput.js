import React from 'react'

class FormBoolInput extends React.Component {
    render() {
        return (
            <div class="form-check">
                <label class="form-check-label">
                <input type="checkbox" class="form-check-input" id={this.props.id} />
                    {this.props.label}
                </label>
            </div>
        );
    }
}

export default FormBoolInput