import React from 'react';
import './Footer.css';

export default function Footer() {
  return (
    <footer className="footer">
      <section className="footer__top-section">
        <div className="footer__connect-text">
          <span>Get connected with us on social networks:</span>
        </div>

        <div className="footer__social-links">
          <a href='' className="footer__social-link">
            <i className="fab fa-facebook-f" />
          </a>
          <a href='' className="footer__social-link">
            <i className="fab fa-twitter" />
          </a>
          <a href='' className="footer__social-link">
            <i className="fab fa-google" />
          </a>
          <a href='' className="footer__social-link">
            <i className="fab fa-instagram" />
          </a>
          <a href='' className="footer__social-link">
            <i className="fab fa-linkedin" />
          </a>
          <a href='' className="footer__social-link">
            <i className="fab fa-github" />
          </a>
        </div>
      </section>

      <section className="footer__main-content">
        <div className="footer__container">
          <div className="footer__column">
            <h6 className="footer__column-title">
              <i className="fas fa-gem footer__icon" />
              Company name
            </h6>
            <p className="footer__paragraph">
              HDLand - the best platform for movies.
            </p>
          </div>

          <div className="footer__column">
            <h6 className="footer__column-title">Products</h6>
            <p><a href='#!' className="footer__link">Docker</a></p>
            <p><a href='#!' className="footer__link">React</a></p>
            <p><a href='#!' className="footer__link">Vue</a></p>
            <p><a href='#!' className="footer__link">ASP .NET</a></p>
          </div>

          <div className="footer__column">
            <h6 className="footer__column-title">Useful links</h6>
            <p><a href='#!' className="footer__link">Pricing</a></p>
            <p><a href='#!' className="footer__link">Settings</a></p>
            <p><a href='#!' className="footer__link">Orders</a></p>
            <p><a href='#!' className="footer__link">Help</a></p>
          </div>

          <div className="footer__column">
            <h6 className="footer__column-title">Contact</h6>
            <p><i className="fas fa-home footer__icon" /> New York, NY 10012, US</p>
            <p><i className="fas fa-envelope footer__icon" /> info@example.com</p>
            <p><i className="fas fa-phone footer__icon" /> + 01 234 567 88</p>
            <p><i className="fas fa-print footer__icon" /> + 01 234 567 89</p>
          </div>
        </div>
      </section>

      <div className="footer__bottom-text">
        © 2025 Copyright:
        <a href="#" className="footer__bottom-link">HDLand.com</a>
      </div>
    </footer>
  );
}
