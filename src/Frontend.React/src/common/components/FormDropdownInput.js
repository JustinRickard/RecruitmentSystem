import React from 'react';
import text from '../text';

class FormDropdownInput extends React.Component {

    render() {

        const options = [];
        options.push(<option key={-1} value={"none"}>{text("generic.pleaseSelectBrackets")}</option>)

        for(var i=0; i < this.props.options.length; i++) {
            const o = this.props.options[i];
            options.push(<option key={i} value={o.value}>{o.text}</option>);
        }        

        return (

            <div className="form-group">
                <label for={this.props.id}>{this.props.label}</label>
                <select className="form-control" id={this.props.id}>
                    {options}
                </select>
            </div>
        );
    }
}

export default FormDropdownInput;