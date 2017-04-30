import React from 'react';

class AssessmentPage extends React.Component {
    render() {
        return (
            <div>
                <div className="col-md-3"></div>
                <div className="col-md-6">
                    <h1>Assessment page</h1>
                    <p>Temporary assessment page text</p>
                    <div className="btn-toolbar text-center">
                        <button className="btn btn-lg" onClick={this.onBack.bind(this)}>Back</button>
                        <button className="btn btn-primary btn-lg" onClick={this.onNext.bind(this)}>Next</button>
                    </div>
                </div>
                <div className="col-md-3"></div>
            </div>
        );
    }

    onBack() {
        alert("Button back clicked")
    }

    onNext() {
        alert("Button next clicked")
    }
}

export default AssessmentPage;