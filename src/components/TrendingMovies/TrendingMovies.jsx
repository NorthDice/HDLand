import React, { useEffect, useState } from 'react';
import { fetchTrendingMovies } from '../../api'; 
import MovieCard from '../MovieCard/MovieCard';
import './TrendingMovies.css';

const TrendingMovies = () => {
    const [movies, setMovies] = useState([]); 

    useEffect(() => {
        const loadMovies = async () => {
            const data = await fetchTrendingMovies();
            console.log(data); 
            setMovies(data); 
        };
        loadMovies();
    }, []); 

    if (movies.length === 0) {
        return <div className="loading">Loading...</div>; 
    }

    const mainMovie = movies[0]; 
    const otherMovies = movies.slice(1); 
    console.log('Main Movie:', mainMovie);
    console.log('Other Movies:', otherMovies);


    return (
        <div className="trending-container">
            <div
                className="main-movie"
                style={{
                    backgroundImage: `url(https://image.tmdb.org/t/p/original${mainMovie.posterPath})`,
                }}
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
                    <MovieCard key={movie.id} movie={movie} /> 
                ))}
            </div>
        </div>
    );
};

export default TrendingMovies;
