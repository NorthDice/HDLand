import React from 'react';
import './App.css';
import Header from './components/Header/Header';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Register from './components/Register/Register';
import Login from './components/Login/Login';
import Search from './components/Search/Search';
import TrendingMovies from './components/TrendingMovies/TrendingMovies';
import Footer from './components/Footer/Footer';
import About from './components/About/About';
import Contacts from './components/Contacts/Contacts';
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import Favorites from './components/Favorites/Favorites';

function App() {
  return (
    <div className="App-container">
      <Header />
      <Routes>
        <Route path="/register" element={<Register />} />
        <Route path="/login" element={<Login />} />
        <Route path="/search" element={<Search />} />
        <Route path="/" element={<TrendingMovies />} />
        <Route path="/about" element={<About />} />
        <Route path="/contact" element={<Contacts />} />
        <Route path="/favourites" element={<Favorites/>} />
      </Routes>
      <Footer />
      <ToastContainer /> 
    </div>
  );
}

export default App;