# Blogging Platform Microservices

A containerized microservices application for a simple blogging platform, built with .NET and Docker.

## Project Overview

This project demonstrates a microservices architecture with two services:

1. **PostService** - Manages blog posts
2. **CommentService** - Manages comments for blog posts

The services communicate with each other and use Docker for containerization and Docker Compose for orchestration.

## Architecture

- **Shared Library** - Contains common DTOs for both services
- **PostService** - .NET Web API for blog post management
- **CommentService** - .NET Web API for comment management
- **Docker** - Each service is containerized
- **Docker Compose** - Orchestrates the containers

## Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) or later
- [Docker](https://www.docker.com/products/docker-desktop/)
- [Docker Compose](https://docs.docker.com/compose/install/) (typically included with Docker Desktop)

## Getting Started

### Clone the Repository

```bash
git clone <repository-url>
cd BloggingPlatform
```

### Build and Run with Docker Compose

```bash
docker-compose build
docker-compose up
```

This will start both services:
- PostService on http://localhost:6001
- CommentService on http://localhost:6002

### API Endpoints

#### PostService

- **Create a new post**
  - URL: POST http://localhost:6001/api/posts
  - Body:
    ```json
    {
      "title": "Getting Started with .NET",
      "content": "This is a sample blog post."
    }
    ```
  - Response:
    ```json
    {
      "id": "guid_here",
      "title": "Getting Started with .NET",
      "content": "This is a sample blog post."
    }
    ```

- **Get all posts**
  - URL: GET http://localhost:6001/api/posts
  - Response: List of all posts

#### CommentService

- **Add a comment to a post**
  - URL: POST http://localhost:6002/api/comments
  - Body:
    ```json
    {
      "postId": "guid_here",
      "author": "Jane Doe",
      "text": "Great article!"
    }
    ```

- **Get all comments for a post**
  - URL: GET http://localhost:6002/api/comments/{postId}
  - Response: List of comments for the specified post

### Testing with Swagger

Both services have Swagger UI enabled for easy API testing:

- PostService Swagger UI: http://localhost:6001/
- CommentService Swagger UI: http://localhost:6002/

## Project Structure

```
BloggingPlatform/
├── PostService/              # Blog post microservice
│   ├── Controllers/          # API controllers
│   ├── Repositories/         # In-memory data access
│   └── Dockerfile            # Docker configuration
│
├── CommentService/           # Comments microservice
│   ├── Controllers/          # API controllers
│   ├── Repositories/         # In-memory data access
│   ├── Clients/              # HTTP clients for service communication
│   └── Dockerfile            # Docker configuration
│
├── Shared/                   # Shared class library
│   └── Dtos/                 # Data Transfer Objects
│
└── docker-compose.yml        # Docker Compose configuration
```

## Troubleshooting

### Services Not Starting

Check Docker logs:
```bash
docker-compose logs post-service
docker-compose logs comment-service
```

### API Endpoints Not Responding

Ensure the containers are running:
```bash
docker-compose ps
```

Try the health check endpoints:
```bash
curl -X GET http://localhost:6001/health
curl -X GET http://localhost:6002/health
```

### Stopping the Services

```bash
docker-compose down
```

## Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## License

This project is licensed under the MIT License - see the LICENSE file for details.
