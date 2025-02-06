import React, { useEffect, useState } from 'react';
import { fetchTrendingMovies } from '../../api';
import "./TrendingMovies.css";

const TrendingMovies = () => {
    const [movies, setMovies] = useState([]);

    useEffect(() => {
        const loadMovies = async () => {
            const data = await fetchTrendingMovies();
            setMovies(data);
        };
        loadMovies();
    }, []);

    if (movies.length === 0) {
        return <div className="loading">Loading...</div>;
    }

    const mainMovie = movies[0];
    const otherMovies = movies.slice(1);

    return (
        <div className="trending-container">
            <div 
                className="main-movie" 
                style={{ backgroundImage: `url(https://image.tmdb.org/t/p/original${mainMovie.posterPath})` }}
            >
                <div className="main-movie__overlay">
                    <h1 className="main-movie__title">{mainMovie.title}</h1>
                    <p className="main-movie__overview">{mainMovie.overview}</p>
                    <p className="main-movie__rating">⭐ {mainMovie.voteAverage} / 10</p>
                    <p className="main-movie__release">📅 {mainMovie.releaseDate}</p>
                </div>
            </div>

            <div className="other-movies">
                {otherMovies.map((movie) => (
                    <div key={movie.id} className="movie-card">
                        <div 
                            className="movie-card__img" 
                            style={{ backgroundImage: `url(https://image.tmdb.org/t/p/w500${movie.posterPath})` }}
                        >
                            <div className="movie-card__overlay">
                                <p className="movie-card__title">{movie.title}</p>
                                <p className="movie-card__rating">⭐ {movie.voteAverage}</p>
                                <p className="movie-card__release">📅 {movie.releaseDate}</p>
                                <p className="movie-card__description">{movie.overview}</p> {/* Описание фильма */}
                            </div>
                        </div>
                    </div>
                ))}
            </div>
        </div>
    );
};

export default TrendingMovies;
