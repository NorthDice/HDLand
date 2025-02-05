import React from 'react'
import './Register.css'

const Register = () => {
  return (
    <div className="registration-form-container">
      <h1 className="form-title">Create a New Account</h1>
      <form className="registration-form">
        <div className="form-group">
          <label htmlFor="username">Username</label>
          <input
            type="text"
            id="username"
            name="username"
            className="form-group__input"
            placeholder="Enter your username"
            required
          />
        </div>
        <div className="form-group">
          <label htmlFor="email">Email</label>
          <input
            type="email"
            id="email"
            name="email"
            className="form-group__input"
            placeholder="Enter your email"
            required
          />
        </div>
        <div className="form-group">
          <label htmlFor="password">Password</label>
          <input
            type="password"
            id="password"
            name="password"
            className="form-group__input"
            placeholder="Enter your password"
            required
          />
        </div>
        <div className="form-group">
          <label htmlFor="confirmPassword">Confirm Password</label>
          <input
            type="password"
            id="confirmPassword"
            name="confirmPassword"
            className="form-group__input"
            placeholder="Confirm your password"
            required
          />
        </div>
        <button type="submit" className="form-button">Register</button>
      </form>
    </div>
  )
}

export default Register
