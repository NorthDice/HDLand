import React from 'react'
import './Header.css'
import { Link } from "react-router-dom";
import { FaSearch, FaHeart, FaBars } from "react-icons/fa";

const Header = () => {
  return (
    <header className="header">

        <div className="header-logo">
            <a className="header-logo__link">
                <img
                  src="https://img.icons8.com/?size=64&id=104374&format=png"
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
                src="https://img.icons8.com/?size=50&id=132&format=png"
                alt="search"
                className="header-actions__img"
              />
          </Link>

          <Link className="header-actions__link" to="/favourites">
            <img
              src="https://img.icons8.com/?size=50&id=25157&format=png"
              alt="favourites"
              className="header-actions__img"
            />
          </Link>

          <button className="header-actions__button">
            <img
              src="https://img.icons8.com/?size=80&id=111473&format=png"
              alt="authorization"
              className="header-actions__img"
            />
          </button>
        </div>

    </header>
  )
}

export default Header
