import React from 'react';

class Header extends React.Component{
    render() {
        
        return (
            <div className="navbar navbar-default">
                <div className="container-fluid">
                    <div className="navbar-header">
                        <div>
                            <h2>{this.props.text}</h2>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}

export default Header