# HDLand – Full-Stack Movie Discovery Application
HDLand is a full-stack web application designed to provide users with a seamless experience for discovering, exploring, and managing their favorite movies. Leveraging the TMDB API for movie data, HDLand offers a rich and interactive platform for movie enthusiasts. The application features a containerized backend, a robust database, and a modern React-based frontend for an intuitive and responsive user interface.

## Features
- Movie Discovery: Search for movies by title or find similar movies based on your preferences.

- Favorites Management: Authenticated users can add movies to their favorites list for quick access.

- User Authentication: Secure authentication and authorization using JWT tokens and cookies, ensuring that only authorized users can access restricted features.

- Responsive UI: A visually appealing and user-friendly interface built with reusable React components.

- RESTful API: A clean and well-structured backend API following RESTful principles for seamless integration with the frontend.

## Tech Stack
### Frontend
React: For building reusable and modular UI components.

JavaScript & JSX: For dynamic and interactive frontend development.

CSS: For styling and responsive design.

### Backend
ASP.NET Core: For building a robust and scalable backend.

C#: The primary programming language for the backend logic.

Entity Framework: For database configuration and management.

### Database
PostgreSQL: A powerful relational database for storing application data.

### Authentication
JWT Tokens: For secure user authentication and authorization.

Cookies: For managing user sessions.

API Documentation & Testing
### Swagger: For API documentation and testing.

### Containerization & Deployment
Docker: For containerizing the application.

Docker Compose: For managing multi-container Docker applications.

### External API
TMDB API: For fetching movie data, including titles, descriptions, and related information.

### Architecture
#### Backend
The backend follows Clean Architecture, ensuring modularity, maintainability, and ease of extension. Built with ASP.NET Core, it utilizes Entity Framework for database configuration and management. The API adheres to RESTful principles, providing a clear and consistent structure for frontend integration

#### Frontend
The frontend is built with React, leveraging its component-based architecture to create reusable and maintainable UI components. The application interacts with both its own backend API and the TMDB API to deliver a smooth and engaging user experience.
