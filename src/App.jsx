import { useState } from 'react';
import './App.css';
import Header from './components/Header/Header';
import { Routes, Route } from 'react-router-dom';
import Register from './components/Register/Register';
import Login from './components/Login/Login';

function App() {
  const [count, setCount] = useState(0)

  return (
    <div className="App-container">
      <Register/>
    
    </div>
  )
}

export default App
