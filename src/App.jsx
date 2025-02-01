import { useState } from 'react';
import './App.css';
import Header from './components/Header';
import { Routes, Route } from 'react-router-dom';

function App() {
  const [count, setCount] = useState(0)

  return (
    <div className="App-container">
      <Header/>
      <Routes>

      </Routes>
    
    </div>
  )
}

export default App
