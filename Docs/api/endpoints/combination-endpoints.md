# Combination Endpoints

## Overview
The Combination API provides endpoints for managing destination combinations based on user preferences and answers.

## Base URL
    `/api/Combination`

## Endpoints

### Create Combination
Creates a new combination of destination options.

``POST``: /api/Combination/createCombination

Headers:
    ``Authorization``: Bearer Token (Admin)
    ``Content-Type``: application/json

```json
Request Body:
{
    "destinationOptionId": 1,
    "climateOptionId": 4,
    "activityOptionId": 9,
    "accommodationOptionId": 10,
    "durationOptionId": 14,
    "ageOptionId": 16,
    "firstCityId": 1,
    "secondCityId": 20
}

Response:
{
    "id": 1,
    "destinationOptionId": 1,
    "climateOptionId": 4,
    "activityOptionId": 9,
    "accommodationOptionId": 10,
    "durationOptionId": 14,
    "ageOptionId": 16,
    "firstCityId": 1,
    "secondCityId": 20,
    "success": true,
    "message": "Combination created successfully"
}
```

### Create Multiple Combinations

Creates multiple combinations in a single request.

``POST``: /api/Combination/createCombinations

Headers:
    ``Authorization``: Bearer Token (Admin)
    ``Content-Type``: application/json

```json
Request Body:
[
    {
        "destinationOptionId": 1,
        "climateOptionId": 4,
        "activityOptionId": 9,
        "accommodationOptionId": 10,
        "durationOptionId": 14,
        "ageOptionId": 16,
        "firstCityId": 1,
        "secondCityId": 20
    },
    {
        "destinationOptionId": 2,
        "climateOptionId": 6,
        "activityOptionId": 7,
        "accommodationOptionId": 11,
        "durationOptionId": 14,
        "ageOptionId": 16,
        "firstCityId": 4,
        "secondCityId": 23 
    }
]
```

### Get Combination by ID
Retrieves a specific combination by its ID.

``GET``: /api/Combination/getCombinationById/{id}

Headers:
    ``Authorization``: Bearer Token (Admin)

Parameters:
    ``id`` (path): The ID of the combination to retrieve


### Get All Combinations
Retrieves all combinations.

``GET``: /api/Combination/getAllCombinations

Headers:
    ``Authorization``: Bearer Token (Admin)

### Get Default Destinations
Retrieves a list of default destination combinations when no specific user preferences are available.

``GET``: /api/Combination/getDefaultDestinations

Headers:
    ``Authorization``: Bearer Token (Admin, User, TestUser)

```json
Response:
{
    "firstCity": {
        "id": 1,
        "name": "Default City 1",
        "description": "Description of default city 1",
        "country": "Country 1",
        "lenguage": "Language 1",
        "unmissablePlace": "Must visit place 1",
        "food": "Traditional food 1",
        "image": "city1-image-url.jpg",
        "continent": "Continent 1"
    },
    "secondCity": {
        "id": 2,
        "name": "Default City 2",
        "description": "Description of default city 2",
        "country": "Country 2",
        "lenguage": "Language 2",
        "unmissablePlace": "Must visit place 2",
        "food": "Traditional food 2",
        "image": "city2-image-url.jpg",
        "continent": "Continent 2"
    },
    "firstCityTravelPlan": {
        "id": 1,
        "name": "Travel Plan 1",
        "description": "Default travel plan for city 1",
        "destinationName": "Default City 1",
        "image": "plan1-image-url.jpg",
        "transportOptions": [...],
        "accommodationOptions": [...]
    },
    "secondCityTravelPlan": {
        "id": 2,
        "name": "Travel Plan 2",
        "description": "Default travel plan for city 2",
        "destinationName": "Default City 2",
        "image": "plan2-image-url.jpg",
        "transportOptions": [...],
        "accommodationOptions": [...]
    },
    "success": true,
    "message": "Default destinations retrieved successfully"
}
```

### Update Combination
### Update Combination
Updates an existing combination by its ID.

``PUT``: /api/Combination/updateCombination/{id}

Headers:
    ``Authorization``: Bearer Token (Admin)
    ``Content-Type``: application/json

Parameters:
    ``id`` (path): The ID of the combination to update

```json
Request Body:
{
    "destinationOptionId": 2,
    "climateOptionId": 6,
    "activityOptionId": 7,
    "accommodationOptionId": 11,
    "durationOptionId": 14,
    "ageOptionId": 16,
    "firstCityId": 4,
    "secondCityId": 23 
}

Response:
{
    "id": 1,
    "destinationOptionId": 2,
    "climateOptionId": 6,
    "activityOptionId": 7,
    "accommodationOptionId": 11,
    "durationOptionId": 14,
    "ageOptionId": 16,
    "firstCityId": 4,
    "secondCityId": 23,
    "success": true,
    "message": "Combination updated successfully"
}
```

### Delete Combination 
Deletes a specific combination.

``DELETE``: /api/Combination/deleteCombination/{id}

Headers:
    ``Authorization``: Bearer Token (Admin)

Parameters:
    ``id`` (path): The ID of the combination to delete


### Error Responses
- ``200 OK``: Successful response
- ``201 Created``: Resource created successfully
- ``400 Bad Request``: Invalid input or business rule violation
- ``401 Unauthorized``: Authentication required
- ``403 Forbidden``: Insufficient permissions
- ``404 Not Found``: Resource not found
- ``500 Internal Server Error``: Server error