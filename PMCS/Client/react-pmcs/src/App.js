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

const App = (props) => {
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

export default App;
