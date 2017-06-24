import React from 'react';

class Breadcrumb2Items extends React.Component {

    render() {
        return (
            <ol className="breadcrumb">
                <li className="breadcrumb-item"><a href="">Home</a></li>
                <li className="breadcrumb-item active"><a href={this.props.href}>{this.props.label}</a></li>
            </ol>
        );
    }

}

export default Breadcrumb2Items