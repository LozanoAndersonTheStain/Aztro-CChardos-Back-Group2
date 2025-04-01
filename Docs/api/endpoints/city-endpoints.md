# City Endpoints

## Overview
The City API provides endpoints for managing cities in the travel recommendation system.

## Base URL
    `/api/City`

## Endpoints

### Create City
Creates a new city in the system.

``POST``: /api/City/createCity

Headers:
    ``Authorization``: Bearer Token (Admin)
    ``Content-Type``: application/json

```json
Request Body:
{
    "name": "Paris",
    "description": "City of Light",
    "country": "France",
    "lenguage": "French",
    "unmissablePlace": "Eiffel Tower",
    "food": "Croissants",
    "image": "paris-image-url.jpg",
    "continent": "Europe"
}

Response:
{
    "id": 1,
    "name": "Paris",
    "description": "City of Light",
    "country": "France",
    "lenguage": "French",
    "unmissablePlace": "Eiffel Tower",
    "food": "Croissants",
    "image": "paris-image-url.jpg",
    "continent": "Europe",
    "success": true,
    "message": "City created successfully"
}
```

### Create Multiple Cities
Creates multiple cities in a single request.

``POST``: /api/City/createCities

Headers:
    ``Authorization``: Bearer Token (Admin)
    ``Content-Type``: application/json

```json
Request Body:
[
    {
        "name": "Paris",
        "description": "City of Light",
        "country": "France",
        "lenguage": "French",
        "unmissablePlace": "Eiffel Tower",
        "food": "Croissants",
        "image": "paris-image-url.jpg",
        "continent": "Europe"
    },
    {
        "name": "Rome",
        "description": "Eternal City",
        "country": "Italy",
        "lenguage": "Italian",
        "unmissablePlace": "Colosseum",
        "food": "Pizza",
        "image": "rome-image-url.jpg",
        "continent": "Europe"
    }
]
```

### Get City by ID
Retrieves a city by its ID.

``GET``: /api/City/getCityById/{id}

Headers: 
    ``Authorization`` : Bearer Token (Admin)

Parameters: 
``id`` (path): The ID of the city to retrieve

### Get All Cities
Retrieves all cities in the system.

``GET``: /api/City/getAllCities

Headers:
    ``Authorization`` : Bearer Token (Admin)

### Get City by Name
Retrieves a city by its name.

``GET``: /api/City/getCityByName/{name}

Headers:
    ``Authorization`` : Bearer Token (Admin)

Parameters:
    ``name`` (path): The name of the city to retrieve


### Update City
Updates a city by its ID.

``PUT``: /api/City/updateCity/{id}

Headers:
    ``Authorization``: Bearer Token (Admin)
    ``Content-Type``: application/json

Parameters:
    ``id`` (path): The ID of the city to update

```json
Request Body:
{
    "name": "Updated Paris",
    "description": "Updated description",
    "country": "France",
    "lenguage": "French",
    "unmissablePlace": "Updated place",
    "food": "Updated food",
    "image": "updated-image-url.jpg",
    "continent": "Europe"
}
```

### Delete City
Deletes a city by its ID.

``DELETE``: /api/City/deleteCity/{id}

Headers:
    ``Authorization``: Bearer Token (Admin)

Parameters:
    ``id`` (path): The ID of the city to delete


### Error Responses

- ``200 OK``: Successful response
- ``201 Created``: Resource created successfully
- ``400 Bad Request``: Invalid input or business rule violation
- ``401 Unauthorized``: Authentication required
- ``403 Forbidden``: Insufficient permissions
- ``404 Not Found``: Resource not found
- ``500 Internal Server Error``: Server error
