# Question Option Endpoints

## Overview
The Question Option API provides endpoints for managing options associated with questions in the travel recommendation system.

## Base URL
    `/api/QuestionOption`

## Endpoints

### Create Option
Creates a new option for a specific question.

``POST``: /api/QuestionOption/createOption/{questionId}

Headers:
    ``Authorization``: Bearer Token (Admin)
    ``Content-Type``: application/json

Parameters:
    ``questionId`` (path): The ID of the question to add the option to

```json
Request Body:
{
    "description": "Playa",
    "image": "https://example.com/beach-image.jpg",
    "fact": "Las playas son perfectas para relajarse y disfrutar del sol"
}

Response:
{
    "id": 1,
    "description": "Playa",
    "image": "https://example.com/beach-image.jpg",
    "fact": "Las playas son perfectas para relajarse y disfrutar del sol",
    "success": true,
    "message": "Question option created successfully"
}
```


### Get Option by ID
Retrieves a specific option.

``GET``: /api/QuestionOption/getOptionById/{id}

Headers: 
    ``Authorization``: Bearer Token (Admin, User, TestUser)

Parameters: 
    ``id`` (path): The ID of the option to retrieve


### Get Options by Question ID
Retrieves all options for a specific question.

``GET ``: /api/QuestionOption/getQuestionOptionById/{questionId}

Headers: 
    ``Authorization``: Bearer Token (Admin, User, TestUser)

Parameters: 
    ``questionId`` (path): The ID of the question


### Update Option
Updates an existing option.

``PUT``: /api/QuestionOption/updateOptionById/{id}

Headers: 
    ``Authorization``: Bearer Token (Admin) 
    ``Content-Type``: application/json

Parameters: 
    ``id`` (path): The ID of the option to update

```json
Request Body:
{
    "description": "Playa paradisíaca",
    "image": "https://example.com/updated-beach-image.jpg",
    "fact": "Las playas tropicales tienen arena blanca y aguas cristalinas"
}
```

### Delete Option
Deletes a specific option.

``DELETE``: /api/QuestionOption/deleteOptionById/{id}

Headers: 
    ``Authorization``: Bearer Token (Admin)

Parameters: 
    ``id`` (path): The ID of the option to delete