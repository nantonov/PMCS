import Header from './Components/Header/Header'
import Reminder from './Components/Content/Reminder/Reminder';
import Nav from './Components/Nav/Nav';
import Pet from './Components/Content/Pet/Pet';
import Activity from './Components/Content/Activity/Activity';
import './App.css';
import { BrowserRouter, Route, Routes } from 'react-router-dom';

let pet = { name: "Johny", info: "Very funny pet.", birthdate: "12/05/2012", weight: "5kg" };

const App = () => {
  return (
    <BrowserRouter>
      <div className='app-wrapper'>
        <Header />
        <Nav />
        <main className='app-content-wrapper'>
          <Routes>
            <Route path='/pets' element={<Pet pet={pet} />}></Route>
            <Route path='/activities' element={<Activity />}></Route>
            <Route path='/reminders' element={<Reminder />}></Route>
          </Routes>
        </main>
      </div>
    </BrowserRouter>
  );
}

export default App;
