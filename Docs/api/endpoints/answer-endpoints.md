# Answer Endpoints

## Overview
The Answer API provides endpoints for managing user answers to questions in the travel recommendation system.

## Base URL
    `/api/Answer`

## Endpoints

### Create Answer
Creates a new answer for a user's question response.

``POST``: /api/Answer/createAnswer

Headers:
    ``Authorization``: Bearer Token (Admin, User, TestUser)
    ``Content-Type``: application/json

```json
Request Body:
{
    "userId": 1,
    "questionId": 1,
    "questionOptionId": 1
}

Response: 
{
    "id": 1,
    "userId": 1,
    "questionId": 1,
    "questionOptionId": 1,
    "utcDate": "2024-02-20T15:30:00Z",
    "localDate": "20/02/2024 10:30:00",
    "success": true,
    "message": "Answer created successfully"
}
```
### Get Answer by ID
Retrieves an answer by its ID.

``GET``: /api/Answer/getAnswerById/{id}

Headers:
    ``Authorization``: Bearer Token (Admin)

Parameters:
    ``id`` (path): The ID of the answer to retrieve

````json
Response:
{
    "id": 1,
    "userId": 1,
    "questionId": 1,
    "questionOptionId": 1,
    "utcDate": "2024-02-20T15:30:00Z",
    "localDate": "20/02/2024 10:30:00",
    "success": true,
    "message": "Answer retrieved successfully"
}
````

### Get User Answers

Retrieves all answers for a specific user.

``GET``: /api/Answer/getUserAnswerId/{userId}

Headers:
    ``Authorization``: Bearer Token (Admin)

Parameters:
    ``userId`` (path): The ID of the user for which answers are retrieved

### Get Answers by Question

Retrieves all answers for a specific question.

``GET``: /api/Answer/getAnswerByQuestion/{questionId}

Headers:
    ``Authorization``: Bearer Token (Admin)

Parameters:
    ``questionId`` (path): The ID of the question for which answers are retrieved

```json
Response:
[

    {
        "id": 1,
        "userId": 1,
        "questionId": 1,
        "questionOptionId": 1,
        "utcDate": "2024-02-20T15:30:00Z",
        "localDate": "20/02/2024 10:30:00",
        "success": true,
        "message": "Answers retrieved successfully"
    },
    ...
]
```

### Get Matching Destinations

Retrieves matching destinations based on a list of answer IDs.

``POST``: /api/Answer/getMatchingDestinations

Headers:
    ``Authorization``: Bearer Token (Admin, User, TestUser)
    ``Content-Type``: application/json

```json
Request Body:
    [1, 4, 9, 10, 14, 16]

Response:
    {
    "firstCity": {
        "id": 1,
        "name": "Playa del Carmen",
        "description": "Modern meets traditional",
        "country": "México",
        "lenguage": "Español",
        "unmissablePlace": "Parque Xcaret",
        "food": "Tacos al pastor",
        "image": "https://content.r9cdn.net/rimg/dimg/78/70/001b704a-city-15939-1629b33a69c.jpg?crop=true&width=1020&height=498",
        "continent": "América",
        "success": true,
        "message": "City updated successfully"
    },
    "secondCity": {
        "id": 20,
        "name": "Santorini",
        "description": "Modern meets traditional",
        "country": "Grecia",
        "lenguage": "Griego",
        "unmissablePlace": "Puesta de sol en Oia",
        "food": "Moussaka",
        "image": "https://www.ekorna.net/wp-content/uploads/2024/01/414910297_966762124816119_4617582216780976935_n.png",
        "continent": "Europa",
        "success": true,
        "message": "City updated successfully"
    },
    "firstCityTravelPlan": {
        "id": 1,
        "name": "Plan Playa del Carmen",
        "description": "Un plan increíble para visitar Playa del Carmen",
        "destinationName": "Playa del Carmen",
        "image": "https://res.cloudinary.com/dy6jglszo/image/upload/v1743272304/Amadeus/Playa_del_Carmen_2_jkjkf0.webp",
        "transportOptions": [
            {
                "id": 1,
                "name": "Avianca",
                "description": "Avianca, una aerolínea Colombiana de categoría premium, con más de 104 años de trayectoria, volando a más de 104 destinos.",
                "imageUrl": "https://www.agenciapi.co/sites/default/files/2023-10/avianca%20nuevo%20logo.png",
                "url": "https://www.avianca.com"
            },
            {
                "id": 2,
                "name": "Aeromexico",
                "description": "Aeromexico, una aerolínea Mexicana de categoría premium, con más de 90 años de trayectoria, volando a más de 104 destinos.",
                "imageUrl": "https://www.dedinero.com.mx/resizer/v2/GYI3URCNDBBUFFWOIKGU4ZONWI.jpg?auth=0a18a5f353e6743d4f2196c963cdb7f5acf58dc4a7d28391a728585dcb108d04&smart=true&width=1100&height=666",
                "url": "https://www.aeromexico.com"
            }
        ],
        "accommodationOptions": [
            {
                "id": 2,
                "name": "Riu Palace Hotel",
                "description": "Se sitúa en Cancún, playa del carmen, cuenta con zona privada de playa, piscina al aire libre, wifi gratis en todo el hotel y 13 restaurantes con diferentes menús.",
                "imageUrl": "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/14/7b/73/78/panoramic-view.jpg?w=700&h=-1&s=1",
                "url": "https://www.riu.com/es/hotel/mexico/playa-del-carmen/"
            },
            {
                "id": 1,
                "name": "TRS Coral Hotel",
                "description": "Se sitúa en Cancún, playa del carmen, cuenta con zona privada de playa, piscina al aire libre, wifi gratis en todo el hotel y 13 restaurantes con diferentes menús.",
                "imageUrl": "https://www.palladiumhotelgroup.com/content/dam/palladium/images/hoteles/mexico/costa-mujeres/hotel/piscinas/trs-coral-hotel/TRS-Coral-Hotel-header-home.jpg.transform/rendition-md/image.jpg",
                "url": "https://www.palladiumhotelgroup.com/"
            }
        ]
    },
    "secondCityTravelPlan": {
        "id": 20,
        "name": "Plan Santorini",
        "description": "Descubre la belleza incomparable de Santorini, famosa por sus impresionantes vistas al mar Egeo y sus encantadoras casas blancas. Vive la experiencia única de Oia y disfruta de un delicioso plato de Moussaka.",
        "destinationName": "Santorini",
        "image": "https://www.ekorna.net/wp-content/uploads/2024/01/414910297_966762124816119_4617582216780976935_n.png",
        "transportOptions": [
            {
                "id": 39,
                "name": "Aegean Airlines",
                "description": "Aegean Airlines ofrece vuelos directos a Santorini, con un servicio excelente y comodidad en cada tramo del viaje.",
                "imageUrl": "https://static.hosteltur.com/app/public/uploads/img/articles/2020/02/14/L_165005_aegean-livery2hh2.jpg",
                "url": "https://www.aegeanair.com"
            },
            {
                "id": 40,
                "name": "Ryanair",
                "description": "Ryanair ofrece vuelos económicos hacia Santorini desde las principales ciudades europeas, ideal para aquellos que buscan una opción asequible.",
                "imageUrl": "https://www.shutterstock.com/image-illustration/marseille-provence-airport-france-april-600nw-617482946.jpg",
                "url": "https://www.ryanair.com"
            }
        ],
        "accommodationOptions": [
            {
                "id": 40,
                "name": "Katikies Hotel",
                "description": "Conocido por su arquitectura única y hermosas vistas al mar Egeo, Katikies Hotel es una opción excelente para una estancia tranquila y lujosa.",
                "imageUrl": "https://i.pinimg.com/originals/90/51/5d/90515df06c47d21e7c8e2a95a4566607.jpg",
                "url": "https://www.katikies.com"
            },
            {
                "id": 39,
                "name": "Canaves Oia Suites & Spa",
                "description": "Un hotel de lujo en Oia con vistas panorámicas al mar, ofreciendo un servicio exclusivo y unas instalaciones de primer nivel.",
                "imageUrl": "https://images2.bovpg.net/r/media/1/1/2/3/6/123600.jpg",
                "url": "https://www.canaves.com"
            }
        ]
    },
    "success": true,
    "message": ""
}
```

### Delete Answer 

Deletes a specific answer.

``DELETE``: /api/Answer/deleteAnswer/{id}

Headers:
    ``Authorization``: Bearer Token (Admin)

Parameters:
    ``id`` (path): The ID of the answer to delete



## Error Responses
All endpoints can return the following error responses:

- ``400 Bad Request``: Invalid input or business rule violation
- ``401 Unauthorized``: Authentication required
- ``403 Forbidden``: Insufficient permissions
- ``404 Not Found``: Resource not found
- ``500 Internal Server Error``: Server error
