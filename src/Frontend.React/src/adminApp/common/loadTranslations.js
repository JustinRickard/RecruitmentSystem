import React from 'react';
import T from 'i18n-react';
import translationApi from '../api/translation/mockTranslationApi';

export function getTranslations(cultureCode) {
    return translationApi.getTranslations(cultureCode);
}

export function loadTranslations(text) {
    T.setTexts(text)
}