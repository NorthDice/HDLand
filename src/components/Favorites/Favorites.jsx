import React, { useEffect, useState } from 'react';
import { getFavoriteMovies, getUserEmailFromCookie } from '../../favoriteMovieapi';
import { useNavigate } from 'react-router-dom';
import { toast } from 'react-toastify';
import MovieCard from '../MovieCard/MovieCard';
import "./Favorites.css";

const Favorites = () => {
  const [movies, setMovies] = useState([]);
  const navigate = useNavigate();

  useEffect(() => {
    const fetchFavorites = async () => {
      console.log("Fetching favorites...");

      const userData = getUserEmailFromCookie();

      if (!userData) {
        console.log("User not logged in");
        toast.error("You must be logged in to view favorites");
        navigate("/login");
        return;
      }

      try {
        const favoriteMovies = await getFavoriteMovies();
        setMovies(favoriteMovies);
        console.log("Favorite movies:", favoriteMovies);
      } catch (error) {
        console.error(error);
        toast.error("Error fetching favorite movies");
      }
    };

    fetchFavorites();
  }, [navigate]);

  return (
    <div>
      <h2>Favorites</h2>
      <div className="favourite-movies">
        {movies.length > 0 ? (
          movies.map((movie) => <MovieCard key={movie.id} movie={movie} /> )
        ) : (
          <p>No favorite movies yet.</p>
        )}
      </div>
    </div>
  );
};

export default Favorites;