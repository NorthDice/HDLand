import { jwtDecode } from "jwt-decode";
import { toast } from "react-toastify";

export const getUserEmailFromCookie = () => {
  console.log("Cookies:", document.cookie);

  const token = document.cookie
    .split("; ")
    .find((row) => row.startsWith("HDLand="))
    ?.split("=")[1];

  if (!token) {
    
    return null;
  }

  console.log("Token read from cookie:", token);

  try {
    const decodedToken = jwtDecode(token);
    return { email: decodedToken.email, token };
  } catch (error) {
    console.error("Error decoding token:", error);
    toast.error("Invalid token");
    return null;
  }
};


export const addToFavorites = async (movieId) => {
  try {
    const userData = getUserEmailFromCookie();
    if (!userData) {
      toast.error("You must be logged in");
      return;
    }

    const { email, token } = userData;

    const response = await fetch("https://localhost:8081/FavoriteMovies/add-to-favorites", { 
      method: "POST",
      headers: {
        "Content-Type": "application/json",
        "Authorization": `Bearer ${token}`,
      },
      body: JSON.stringify({
        Email: email,
        MovieId: movieId,
      }),
    });

    if (!response.ok) {
      const errorText = await response.text();
      console.error("Response status:", response.status);
      console.error("Response text:", errorText);
      throw new Error("Failed to add movie to favorites");
    }

    toast.success("Movie added to favorites");
  } catch (error) {
    console.error("Error adding to favorites:", error);
  }
};

export const getFavoriteMovies = async () => {
  try {
    const userData = getUserEmailFromCookie();
    if (!userData){
      toast.error("You must be logged in");
      return [];
    }

    const { email, token } = userData;

    const response = await fetch(`https://localhost:8081/FavoriteMovies/get-favorites?email=${encodeURIComponent(email)}`, {
      method: "GET",
      headers: {
        "Authorization": `Bearer ${token}`,
      },
    });

    if (!response.ok) {
      const errorText = await response.text();
      console.error("Response status:", response.status);
      console.error("Response text:", errorText);
      throw new Error("Failed to fetch favorite movies");
    }

    const favoriteMovies = await response.json();
    console.log("Favorite movies:", favoriteMovies);
    return favoriteMovies;
  } catch (error) {
    console.error("Error fetching favorite movies:", error);
    return [];
  }
};
