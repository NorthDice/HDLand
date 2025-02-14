import React from 'react';
import './About.css';

const About = () => {
  return (
    <div className="about">
      <h1 className="about__title">About This Application</h1>
      <section className="about__section">
        <h2 className="about__subtitle">Technologies Used</h2>
        <p className="about__text">
          This application uses the <strong>MBDB API</strong> to retrieve movie data. It is a modern web application that leverages various technologies and principles to provide a smooth user experience.
        </p>
        <p className="about__text">
          The main application and frontend are containerized using <strong>Docker</strong>. The database is a PostgreSQL database, ensuring efficient and reliable data management.
        </p>
        <p className="about__text">
          The entire system is orchestrated using <strong>Docker Compose</strong> for easy setup and deployment.
        </p>
      </section>
      
      <section className="about__section">
        <h2 className="about__subtitle">Frontend</h2>
        <p className="about__text">
          The frontend of this application is built using <strong>React</strong>, utilizing reusable components that allow for a modular and maintainable codebase. React allows for a dynamic, fast, and responsive user interface.
        </p>
        <p className="about__text">
          With the use of reusable components, the application ensures that changes in one part of the UI can be easily reflected across multiple areas of the app without code duplication.
        </p>
      </section>

      <section className="about__section">
        <h2 className="about__subtitle">Backend</h2>
        <p className="about__text">
          The backend is developed using <strong>.NET</strong>, following <strong>SOLID principles</strong> to ensure clean, scalable, and maintainable code. This architecture enables easy extension and reduces the risk of bugs as the application grows.
        </p>
        <p className="about__text">
          The backend also interacts with the <strong>MBDB API</strong> to retrieve movie data and serves it to the frontend through a RESTful interface.
        </p>
      </section>

      <section className="about__section">
        <h2 className="about__subtitle">Swagger and Open API</h2>
        <p className="about__text">
          The backend API is documented using <strong>Swagger</strong>, providing an interactive API documentation interface that follows the <strong>Open API</strong> specification.
        </p>
        <p className="about__text">
          Swagger allows developers to interact with the API directly from the documentation, making it easier to test and understand how the API works.
        </p>
      </section>
    </div>
  );
}

export default About;
