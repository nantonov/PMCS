import logo from './logo.svg';
import Header from './Components/Header/Header'
import Footer from './Components/Footer/Footer';
import SideBar from './Components/SideBar/SideBar';
import Content from './Components/Content/Content';
import './App.css'

const App = () => {
  return (
    <div className='app-wrapper'>
      <Header />
      <SideBar />
      <Content />
      <Footer />
    </div>
  );
}

export default App;
