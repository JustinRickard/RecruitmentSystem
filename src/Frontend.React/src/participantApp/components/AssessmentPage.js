import React from 'react';

class AssessmentPage extends React.Component {
    render() {
        return (
            <div>
                <h1>Assessment page</h1>
                <p>Temporary assessment page text</p>
                <Button text="Back" />
                <Button text="Next" />
            </div>
        );
    }

    onNext() {
        alert("Button next clicked")
    }
}

export default AssessmentPage;