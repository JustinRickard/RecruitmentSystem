import React from 'react';
import { Link, IndexLink } from 'react-router';

class Header extends React.Component{

    componentDidMount() {
        // Fix bug with mobile menu not collapsing after selecting page
        $(".navbar-nav").find("li").on("click", function() {
            if ($( window ).width() <= 767) {
                $(".navbar").find(".navbar-toggle").click(); 
            }
        }); 
    }

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
                            <li><IndexLink to="/"><i className="fa fa-home fa-2x"></i></IndexLink></li>
                            <li><Link to="Clients">Clients</Link></li>
                            <li><Link to="Users">Users</Link></li>
                            <li><Link to="Projects">Projects</Link></li>
                            <li><Link to="Workflows">Workflows</Link></li>
                            <li><Link to="WorkflowSteps">Workflow Steps</Link></li>
                            <li><Link to="Audits">Audit</Link></li>
                            <li><Link to="Logout">Log out</Link></li>
                        </ul>
                    </div>
                </div>
            </nav>
        );
    }
}

export default Header