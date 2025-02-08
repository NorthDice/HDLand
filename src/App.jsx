import './App.css';
import Header from './components/Header/Header';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Register from './components/Register/Register';
import Login from './components/Login/Login';
import Search from './components/Search/Search';
import TrendingMovies from './components/TrendingMovies/TrendingMovies';
import Footer from './components/Footer/Footer';
import MovieCard from './components/MovieCard/MovieCard';

function App() {
  return (
    <div className="App-container">      
      <Header />
      <Routes>
        <Route path="/register" element={<Register />} />
        <Route path="/login" element={<Login />} />
        <Route path="/search" element={<Search />} />
        <Route path="/" element={<TrendingMovies />} />
      </Routes>

      <Footer />
      
    </div>
  );
}

export default App;
