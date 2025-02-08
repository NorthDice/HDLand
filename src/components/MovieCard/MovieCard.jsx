import React from 'react';
import './MovieCard.css'; 

const MovieCard = ({ movie }) => {
    return (
        <div className="movie-card">
            <div
                className="movie-card__img"
                style={{
                    backgroundImage: `url(https://image.tmdb.org/t/p/w500${movie.posterPath})`,
                }}
            >
                <div className="movie-card__overlay">
                    <p className="movie-card__title">{movie.title}</p>
                    <p className="movie-card__rating">⭐ {movie.voteAverage}</p>
                    <p className="movie-card__release">📅 {movie.releaseDate}</p>
                    <p className="movie-card__description">{movie.overview}</p>
                </div>
            </div>
        </div>
    );
};

export default MovieCard;