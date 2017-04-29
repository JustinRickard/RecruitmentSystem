import React from 'react';
import PropTypes from 'prop-types';
import Header from './Header';

class App extends React.Component {
    render() {
        return  (
            <div className="container-fluid">
                <Header text="Assessment site" />
                {this.props.children}
            </div>
        );
    }
}

App.propTypes = {
    children: PropTypes.object.isRequired
}

export default App;