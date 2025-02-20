export const registerUser = async (username, email, password) => {
    const response = await fetch("https://localhost:8081/Auth/register", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({ username, email, password })
    });

    if (response.ok) {
        console.log("User registered successfully");
    } else {
        console.error("Registration failed");
    }
};

export const loginUser = async (email, password) => {
    const response = await fetch("https://localhost:8081/Auth/login", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({ email, password }),
        credentials: 'include' 
    });

    if (response.ok) {
        console.log("Login successful");
    } else {
        console.error("Login failed");
    }
};