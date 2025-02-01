import './Header.css'
import { Link } from "react-router-dom";
import land from '../assets/land.png'
import bookmark from '../assets/bookmark.png'
import search from '../assets/search.png'
import person from '../assets/person.png'
import pers from '../assets/pers.png'
import React, { useState } from 'react';


const Header = () => {
  const [menuOpen, setMenuOpen] = useState(false);

  const toggleMenu = () => {
    setMenuOpen(!menuOpen);
  };

  return (
    <header className="header">

        <div className="header-logo">
            <a className="header-logo__link">
                <img
                  src={land}
                  alt="lendLogo"
                  className="header-logo__img"
                />
            </a>
            <p className="logo-container__title">HDLand</p>
        </div>

        <nav className="header-nav">
            <ul className="header-nav__list">
                <li className="header-nav__item"><Link to="/" className="header-nav__link">Home</Link></li>
                <li className="header-nav__item"><Link to="/about" className="header-nav__link">About</Link></li>
                <li className="header-nav__item"><Link to="/contact" className="header-nav__link">Contact</Link></li>
            </ul>
        </nav>

        <div className="header-actions">
          <Link className="header-actions__link" to="/search">
              <img
                src={search}
                alt="search"
                className="header-actions__img"
              />
          </Link>

          <Link className="header-actions__link" to="/favourites">
            <img
              src={bookmark}
              alt="favourites"
              className="header-actions__img"
            />
          </Link>

          <button 
            onClick={toggleMenu}
            className="header-actions__button">
              <img
                src={pers}
                alt="authorization"
                className="header-actions__img"
              />
          </button>
        </div>

        {menuOpen && (
          <div className="auth-menu">
            <ul className="auth-menu__list">
              <li><Link to="/login" className="auth-menu__link">Login</Link></li>
              <li><Link to="/register" className="auth-menu__link">Register</Link></li>
            </ul>
          </div>
        )}

    </header>
  )
}

export default Header
