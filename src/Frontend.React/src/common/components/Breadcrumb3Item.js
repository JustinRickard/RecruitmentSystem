import React from 'react';

class Breadcrumb3Items extends React.Component {

    render() {
        return (
            <ol className="breadcrumb">
                <li className="breadcrumb-item"><a href="">Home</a></li>
                <li className="breadcrumb-item"><a href={this.props.href1}>{this.props.label1}</a></li>
                <li className="breadcrumb-item active">{this.props.label2}</li>
            </ol>
        );
    }

}

export default Breadcrumb3Items