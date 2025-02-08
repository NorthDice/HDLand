export const fetchTrendingMovies = async () => {
    try {
      const response = await fetch("https://localhost:60222/Movies/trending?timeWindow=day");
      if (!response.ok) {
        throw new Error("Failed to fetch movies");
      }
      return await response.json();
    } catch (error) {
      console.error("Error fetching movies:", error);
      return [];
    }
  };
  
  export const fetchMovieByName = async (query) => {
    try{
      const response = await fetch(`https://localhost:60222/Movies/${query}`);
      if (!response.ok) {
        throw new Error("Failed to find movie");
      }
      return await response.json();
    } catch (error) {
      console.error("Error ti find movie:", error);
      return [];
    }
  };
  
  export const fetchMovieBySearch = async (query, page = 1, pageSize = 20) => {
    try {
      const response = await fetch(
        `https://localhost:60222/Movies/search?query=${encodeURIComponent(query)}&page=${page}&pageSize=${pageSize}`
      );
      if (!response.ok) {
        throw new Error("Failed to find movies");
      }
      return await response.json();
    } catch (error) {
      console.error("Error fetching movies by name:", error);
      return { results: [], totalPages: 0 };  
    }
  };
  