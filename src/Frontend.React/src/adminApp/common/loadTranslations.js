import React from 'react';
import T from 'i18n-react';
import translationApi from '../api/translation/mockTranslationApi';

export default function loadTranslations(cultureCode) {

    let translations = translationApi.getTranslations(cultureCode)
        .then(text => {
            T.setTexts(text);
        })
        .catch(error => {
            throw(error); // TODO: Add error handler
        });
}