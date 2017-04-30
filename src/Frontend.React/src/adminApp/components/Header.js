import React from 'react';

class Header extends React.Component{
    render() {
        
        return (
            <nav className="navbar navbar-inverse">
                <div className="container">
                    <div className="navbar-header">
                        <a className="navbar-brand">Admin site</a>
                        <button type="button" className="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                            <span className="sr-only">Toggle navigation</span>
                            <span className="icon-bar"></span>
                            <span className="icon-bar"></span>
                            <span className="icon-bar"></span>
                        </button>
                    </div>
                    <div className="navbar-collapse collapse">
                        <ul className="nav navbar-nav">
                            <li><a href="./#/">Home</a></li>
                            <li><a href="./#/Client">Clients</a></li>
                            <li><a href="./#/User">Users</a></li>
                            <li><a href="./#/Project">Projects</a></li>
                            <li><a href="./#/Workflow">Workflows</a></li>
                            <li><a href="./#/Audit">Audit</a></li>
                            <li><a href="./#/Logout">Log out</a></li>
                        </ul>
                    </div>
                </div>
            </nav>

            /*
            <div className="navbar navbar-default">
                <div className="container-fluid">
                    <div className="navbar-header">
                        <div>
                            <h2>{this.props.text}</h2>
                        </div>
                    </div>
                </div>
            </div>
            */
        );
    }
}

export default Header