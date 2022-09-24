import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';

//Temporary test data just to see how the page will look like with real data
let pets = [{
  name: "Johny", info: "Very funny pet.", birthdate: "12/05/2012", weight: "5.0kg", activities: [
  { name: "Walking", date: "12.12.2021 21:18" },
  { name: "Meal", date: "12.12.2021 21:18" },
  { name: "Vaccine", date: "12.12.2021 21:18" }]
},
{ name: "Alberto", info: "Doggy who is so happy.", birthdate: "28/09/2020", weight: "14.7kg", activities: [
  { name: "Walking", date: "12.12.2021 21:18" },
  { name: "Meal", date: "12.12.2021 21:18" },
  { name: "Vaccine", date: "12.12.2021 21:18" }] },
{ name: "Monica", info: "Old and beautiful cat.", birthdate: "28/10/2013", weight: "13.2kg", activities: [
  { name: "Walking", date: "12.12.2021 21:18" },
  { name: "Meal", date: "12.12.2021 21:18" },
  { name: "Vaccine", date: "12.12.2021 21:18" }] }];

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>
    <App pets={pets}/>
  </React.StrictMode>
);

reportWebVitals();
