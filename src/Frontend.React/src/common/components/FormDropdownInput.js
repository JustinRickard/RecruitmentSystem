import React from 'react';

class FormDropdownInput extends React.Component {

    render() {
        return (

            <div class="form-group">
                <label for={this.props.id}>{this.props.label}</label>
                <select class="form-control" id={this.props.id}>
                    {this.props.options.map(function (o) {
                        return <option value={o.value}>{o.text}</option>;
                    })}
                </select>
            </div>
        );
    }
}

export default FormDropdownInput;