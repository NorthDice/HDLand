import React, { useState } from 'react';
import './Search.css'; 

const Search = () => {
  const [query, setQuery] = useState('');

  const handleChange = (e) => {
    setQuery(e.target.value);
  };

  const handleSearch = (e) => {
    e.preventDefault();
    console.log('Searching for:', query);
  };

  return (
    <div className="search-container">
      <h1 className="search-title">Search</h1>
      <form className="search-form" onSubmit={handleSearch}>
        <div className="form-group">
          <label htmlFor="searchQuery" className="form-group__label">Search Query</label>
          <input
            type="text"
            id="searchQuery"
            name="searchQuery"
            className="form-group__input"
            placeholder="Enter your search"
            value={query}
            onChange={handleChange}
            required
          />
        </div>
        <button type="submit" className="form-button">Search</button>
      </form>
    </div>
  );
};

export default Search;
