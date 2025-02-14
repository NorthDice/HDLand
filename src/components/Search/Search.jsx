import React, { useEffect, useState } from 'react';
import './Search.css';
import { fetchMovieBySearch } from '../../api';
import MovieCard from '../MovieCard/MovieCard';

const Search = () => {
  const [query, setQuery] = useState('');
  const [movies, setMovies] = useState([]);
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    if (!query.trim()) {
      setMovies([]);
      return;
    }

    const delayDebounce = setTimeout(() => {
      setLoading(true);
      fetchMovieBySearch(query, 1) 
        .then((data) => {
          console.log("Fetched data:", data);

          if (data && data.results) {
            setMovies(data.results);
          } else {
            setMovies([]);
          }
        })
        .catch((error) => {
          console.error("Error fetching movies:", error);
          setMovies([]);
        })
        .finally(() => {
          setLoading(false);
        });
    }, 300);

    return () => clearTimeout(delayDebounce);
  }, [query]);

  const handleChange = (e) => {
    setQuery(e.target.value);
  };

  return (
    <>
      <div className="search-container">
        <h1 className="search-title">Search</h1>
        <form className="search-form" onSubmit={(e) => e.preventDefault()}>
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
        </form>

        {loading && <p className="loading-text">Loading...</p>}
      </div>

      <div className="search-results">
        {movies.length > 0 ? (
          movies.map((movie) => (
            <MovieCard key={movie.id} movie={movie} />
          ))
        ) : (
          query && 
          <div className="no-results-container">
            <p className="no-results">No movies found.</p>
          </div>
        )}
      </div>
    </>
  );
};

export default Search;
