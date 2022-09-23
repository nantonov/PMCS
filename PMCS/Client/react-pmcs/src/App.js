import logo from './logo.svg';
import Header from './Components/Header/Header'
import Footer from './Components/Footer/Footer';
import Nav from './Components/Nav/Nav';
import Content from './Components/Content/Content';
import './App.css'

const App = () => {
  return (
    <div className='app-wrapper'>
      <Header />
      <Nav />
      <Content />
      <Footer />
    </div>
  );
}

export default App;
