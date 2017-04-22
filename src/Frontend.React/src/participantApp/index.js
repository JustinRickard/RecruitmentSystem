import 'babel-polyfill';
import React from 'react';
import {render} from 'react-dom'
import { Router, hashHistory, browserHistory } from 'react-router';
import routes from './routes';

// Use browserHistory for production. Use hashHistory for initial development
render (
    <Router history={hashHistory} routes={routes} />,
    document.getElementById('app')
);