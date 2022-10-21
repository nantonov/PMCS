import React, { useEffect } from 'react';
import Header from './Components/Header/Header'
import Nav from './Components/Nav/Nav';
import PetsContainer from './Components/Content/Pets/PetsContainer';
import './App.css';
import { Route, Routes } from 'react-router-dom';
import Callback from './Components/Auth/Callback';
import Refresh from './Components/Auth/Refresh';
import Logout from './Components/Auth/Logout';
import Home from './Components/Home/Home';
import RemindersContainer from './Components/Content/Reminders/RemindersContainer';
import ActivitiesContainer from './Components/Content/Activities/ActivitiesContainer';
import { connect } from 'react-redux';
import { compose } from 'redux';
import { initializeApp } from './redux/App/actionCreators';
import Preloader from './Components/Preloader/Preloader';

const App = ({ isInitialized, initializeApp }) => {

  useEffect(() => {
    console.log('Initialized');
    initializeApp();
  }, []);

  if (!isInitialized) {
    return <div><Preloader /></div>
  }

  return (
    <div className='app-wrapper'>
      <Header />
      <Nav />
      <main className='app-content-wrapper'>
        <Routes>
          <Route path='/pets/*' element={<PetsContainer />}></Route>
          <Route path='/activities/*' element={<ActivitiesContainer />}></Route>
          <Route path='/reminders/*' element={<RemindersContainer />}></Route>
          <Route path='/callback' element={<Callback />}></Route>
          <Route path='/refresh' element={<Refresh />}></Route>
          <Route path='/logout' element={<Logout />}></Route>
          <Route path='/' element={<Home />}></Route>
        </Routes>
      </main>
    </div>

  );
}

const mapStateToProps = (state) => {
  return {
    isInitialized: state.app.isInitialized
  }
}

export default compose(connect(mapStateToProps, { initializeApp }))(App);
