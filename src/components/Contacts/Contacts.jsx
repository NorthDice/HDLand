import React, { useState } from 'react';
import './Contacts.css';

const Contacts = () => {
  const [formData, setFormData] = useState({
    name: '',
    email: '',
    message: ''
  });

  const handleChange = (e) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault(); 
    console.log('Form Submitted:', formData);
    
    alert("Your message has been submitted. (but no data sent anywhere)");
  };

  return (
    <div className="contacts">
      <h1 className="contacts__title">Contact Us</h1>
      <form className="contacts__form" onSubmit={handleSubmit}>
        <div className="contacts__form-group">
          <label htmlFor="name" className="contacts__label">Your Name</label>
          <input
            type="text"
            id="name"
            name="name"
            className="contacts__input"
            placeholder="Enter your name"
            value={formData.name}
            onChange={handleChange}
            required
          />
        </div>

        <div className="contacts__form-group">
          <label htmlFor="email" className="contacts__label">Your Email</label>
          <input
            type="email"
            id="email"
            name="email"
            className="contacts__input"
            placeholder="Enter your email"
            value={formData.email}
            onChange={handleChange}
            required
          />
        </div>

        <div className="contacts__form-group">
          <label htmlFor="message" className="contacts__label">Your Message</label>
          <textarea
            id="message"
            name="message"
            className="contacts__textarea"
            placeholder="Enter your message"
            value={formData.message}
            onChange={handleChange}
            required
          ></textarea>
        </div>

        <button type="submit" className="contacts__button">Send Message</button>
      </form>
    </div>
  );
}

export default Contacts;
