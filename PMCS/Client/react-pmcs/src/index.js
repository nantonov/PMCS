import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import store from './redux/store';
import { BrowserRouter } from 'react-router-dom';

const root = ReactDOM.createRoot(document.getElementById('root'));
let RerenderTree = () => {
  root.render(
    <BrowserRouter>
      <React.StrictMode>
        <App state={store.state} dispatch={store.dispatch.bind(store)} />
      </React.StrictMode>
    </BrowserRouter>
  );
}

RerenderTree(store.state);

store.subscribe(RerenderTree);

reportWebVitals();
