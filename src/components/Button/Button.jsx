import React from 'react';
import star from "../../assets/star.png";
import './Button.css';
const Button = ({ onClick }) => {
  return (
    <div>
      <button onClick={onClick} className="favorites__button">
        <img 
          src={star} 
          alt="Add to favorites" 
          className="favorites__icon"  
        />
      </button>
    </div>
  );
}

export default Button;
