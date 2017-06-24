import React from 'react';
import IconPanel from '../../../common/components/IconPanel';
import {Link} from 'react-router';

class PanelLink extends React.Component {
    render() {

        const headerClass = this.props.headerClass + ' text-center'

        return (
            <div className="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                <Link to={this.props.link}>
                    <IconPanel 
                        headerClass={headerClass}
                        headerText={this.props.headerText} 
                        footerText={this.props.footerText}
                        iconClass={this.props.iconClass}
                    />
                </Link>
            </div>
        );
    }
}

export default PanelLink