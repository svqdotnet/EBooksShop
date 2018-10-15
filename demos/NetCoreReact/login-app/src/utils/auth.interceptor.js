import axios from 'axios';
import cookie from 'react-cookies';

// Add a request/response interceptor
const initInterceptor = () => {
    setRequestHeader();
    setResponseHeader();
}

const setResponseHeader = () => {
    axios.interceptors.response.use(function (response) {
        if (response.headers.authorization) {
            cookie.save('tkn', response.headers.authorization, { maxAge: (20 * 60) });
        }
        return response;
    }, function (error) {
        console.log(error);
        if (error != null && error.response != null && error.response.status === 401) {
            cookie.remove('tkn');
            if (error.request != null && error.request.responseURL !== "http://localhost:5000/api/user/authenticate") {
                window.location.href = '/';
            }
        }
        return Promise.reject(error);
    });
}

const setRequestHeader = () => {
    axios.interceptors.request.use(function (request) {
        if (request != null && request.url !== "http://localhost:5000/api/user/authenticate") {
            const token = cookie.load('tkn');
            if (token) {
                request.headers.Authorization = token;
            }
        }
        return request;
    }, function (error) {
        console.log(error);
        return Promise.reject(error);
    });
}

export { initInterceptor };