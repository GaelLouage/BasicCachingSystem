# Basic Caching System API

This is a simple caching system API built using ASP.NET Core. It allows for adding, retrieving, removing, and cleaning up cache items with expiration times. The API provides the ability to interact with a cache through HTTP requests.

## Features

- **Get Cache Item**: Retrieve a cached item by its key.
- **Add Cache Item**: Add a new item to the cache with an expiration time.
- **Remove Cache Item**: Remove an item from the cache by its key.
- **Clean Up Cache**: Clear all expired cache items.

## Prerequisites

- .NET 6 or higher
- Visual Studio Code or Visual Studio (optional)
- Postman or any HTTP client for testing the API (optional)

## Setup

1. Clone the repository:
    ```bash
    git clone https://github.com/yourusername/BasicCachingSystem.git
    ```

2. Navigate to the project folder:
    ```bash
    cd BasicCachingSystem
    ```

3. Restore the required packages:
    ```bash
    dotnet restore
    ```

4. Build the project:
    ```bash
    dotnet build
    ```

5. Run the application:
    ```bash
    dotnet run
    ```

   The API will be available at `http://localhost:5000`.

## API Endpoints

### 1. Get Cache Item

**Endpoint**: `GET /CachingSystem/Get?key={key}`  
**Description**: Retrieve a cache item by its key.  
**Response**:  
- `200 OK` with the cached item if found.
- `404 Not Found` if the item doesn't exist in the cache.

Example:
```bash
GET http://localhost:5000/CachingSystem/Get?key=myKey
