import { useEffect, FC } from 'react';
import Header from './Components/Header/Header'
import Nav from './Components/Nav/Nav';
import PetsContainer from './Components/Content/Pets/PetsContainer';
import './App.css';
import { Route, Routes} from 'react-router-dom';
import Callback from './Components/Auth/Callback';
import Refresh from './Components/Auth/Refresh';
import Logout from './Components/Auth/Logout';
import Home from './Components/Home/Home';
import RemindersContainer from './Components/Content/Reminders/RemindersContainer';
import ActivitiesContainer from './Components/Content/Activities/ActivitiesContainer';
import { connect, ConnectedProps } from 'react-redux';
import { compose } from 'redux';
import { initializeApp } from './redux/App/actionCreators';
import Preloader from './Components/Preloader/Preloader';
import { getIsInitialized } from './redux/App/selectors';
import { RootState } from './redux/types';
import Walkings from './Components/Content/Activities/Walkings';
import Meals from './Components/Content/Activities/Meals';
import Vaccines from './Components/Content/Activities/Vaccines';

const mapStateToProps = (state: RootState) => {
  return {
    isInitialized: getIsInitialized(state)
  }
}

const connector = compose(connect(mapStateToProps, { initializeApp }));

type Props = ConnectedProps<typeof connector>;

const App: FC<Props> = ({ isInitialized, initializeApp }) => {

  useEffect(() => {
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
          <Route path='/pets/*' element={<PetsContainer />} />
          <Route path='/activities' element={<ActivitiesContainer />} >
            <Route path='/activities/walkings/*' element={<Walkings />} />
            <Route path='/activities/meals/*' element={<Meals />} />
            <Route path='/activities/vaccines/*' element={<Vaccines />} />
          </Route >
          <Route path='/reminders/*' element={<RemindersContainer />} />
          <Route path='/callback' element={<Callback />} />
          <Route path='/refresh' element={<Refresh />} />
          <Route path='/logout' element={<Logout />} />
          <Route path='/' element={<Home />} />
        </Routes>
      </main>
    </div>
  );
}

export default connector(App);
