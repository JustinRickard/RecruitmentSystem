import React from 'react';
import { Route, IndexRoute }  from 'react-router';
import App from './components/App'
import HomePage from './components/HomePage';
import AssessmentPage from './components/AssessmentPage';

export default (
    <Route path="/" component={App}>
        <IndexRoute component={HomePage} />
        <Route path="/assessment" component={AssessmentPage} />
    </Route>
);