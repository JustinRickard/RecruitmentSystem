import { push } from 'react-router-redux';

class Router {
    static navigateTo(page) {

        console.log("Navigating to page: " + page)

        push(page);
    }
}

export default Router