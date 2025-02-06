import './App.css';
import Header from './components/Header/Header';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Register from './components/Register/Register';
import Login from './components/Login/Login';
import Search from './components/Search/Search';

function App() {
  return (
    <div className="App-container">
      <Header />
      
      <Routes>
        <Route path="/register" element={<Register />} />
        <Route path="/login" element={<Login />} />
        <Route path="/search" element={<Search />} />
      </Routes>
    </div>
  );
}

export default App;
