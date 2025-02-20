import React, { useState } from 'react'
import './Login.css'
import { loginUser } from '../../accountApi'
import { toast } from "react-toastify";
import { useNavigate } from 'react-router-dom';
const Login = () => {
  const [formData, setFormData] = useState({
    email: '',
    password: ''
  });

  const handleChange = (e) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value
    });
  };

  const handleSubmit = async (e) => {
    e.preventDefault(); 
    
    const { email, password } = formData;

    try {
      await loginUser(email, password); 
      navigate("/");
      toast.success("Login successful");

    } catch (error) {
      console.error("Login failed:", error);
      toast.error("Login failed");
    }
  };

  return (
    <div className="login-form-container">
      <h1 className="form-title">Login to Your Account</h1>
      <form className="login-form" onSubmit={handleSubmit}>
        <div className="form-group">
          <label htmlFor="email">Email</label>
          <input
            type="email"
            id="email"
            name="email"
            className="form-group__input"
            placeholder="Enter your email"
            value={formData.email}
            onChange={handleChange}
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
            value={formData.password}
            onChange={handleChange}
            required
          />
        </div>
        <button type="submit" className="form-button">Login</button>
      </form>
    </div>
  )
}

export default Login;
