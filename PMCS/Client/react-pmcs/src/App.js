import Header from './Components/Header/Header'
import Reminders from './Components/Content/Reminders/Reminders';
import Nav from './Components/Nav/Nav';
import PetsContainer from './Components/Content/Pets/PetsContainer';
import Activities from './Components/Content/Activities/Activities';
import './App.css';
import { Route, Routes } from 'react-router-dom';

const App = (props) => {
  return (

    <div className='app-wrapper'>
      <Header />
      <Nav />
      <main className='app-content-wrapper'>
        <Routes>
          <Route path='/pets/*' element={<PetsContainer />}></Route>
          <Route path='/activities/*' element={<Activities />}></Route>
          <Route path='/reminders/*' element={<Reminders />}></Route>
        </Routes>
      </main>
    </div>

  );
}

export default App;
