import 'babel-polyfill';
import React from 'react';
import { createStore } from 'redux';
import { Provider } from 'react-redux';
import { render } from 'react-dom';
import { Router, hashHistory, browserHistory } from 'react-router';
import routes from './common/routes';
import configureStore from './store/configureStore';
import loadTranslations from './common/loadTranslations';

const store = configureStore();
loadTranslations('en_gb');


// Use browserHistory for production. Use hashHistory for initial development
render (
    <Provider store={store}>
        <Router history={hashHistory} routes={routes} />
    </Provider>,
    document.getElementById('app')  
);