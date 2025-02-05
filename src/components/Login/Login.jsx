import React from 'react'
import './Login.css' 

const Login = () => {
  return (
    <div className="login-form-container">
      <h1 className="form-title">Login to Your Account</h1>
      <form className="login-form">
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
        <button type="submit" className="form-button">Login</button>
      </form>
    </div>
  )
}

export default Login
