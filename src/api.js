export const fetchTrendingMovies = async () => {
    try {
      const response = await fetch("https://localhost:63787/Movies/trending?timeWindow=day");
      if (!response.ok) {
        throw new Error("Failed to fetch movies");
      }
      return await response.json();
    } catch (error) {
      console.error("Error fetching movies:", error);
      return [];
    }
  };
  