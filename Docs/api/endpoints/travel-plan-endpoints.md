# Travel Plan Endpoints

## Overview
The Travel Plan API provides endpoints for managing travel plans and their assignments to destinations.

## Base URL
    `/api/TravelPlan`

## Endpoints

### Create Travel Plan
Creates a new travel plan.

``POST``: /api/TravelPlan/createTravelPlan

Headers:
    ``Authorization``: Bearer Token (Admin only)
    ``Content-Type``: application/json

```json
Request Body:
{
  "name": "Plan Playa del Carmen",
  "description": "Un plan increíble para visitar Playa del Carmen",
  "destinationName": "Playa del Carmen",
  "image": "https://content.r9cdn.net/rimg/dimg/78/70/001b704a-city-15939-1629b33a69c.jpg?crop=true&width=1020&height=498",
  "transportOptions": [
    {
        "name": "Avianca",
        "description": "Avianca, una aerolínea Colombiana de categoría premium, con más de 104 años de trayectoria, volando a más de 104 destinos.",
        "imageUrl": "https://www.agenciapi.co/sites/default/files/2023-10/avianca%20nuevo%20logo.png",
        "url": "https://www.avianca.com"
      },
      {
        "name": "Aeromexico",
        "description": "Aeromexico, una aerolínea Mexicana de categoría premium, con más de 90 años de trayectoria, volando a más de 104 destinos.",
        "imageUrl": "https://www.dedinero.com.mx/resizer/v2/GYI3URCNDBBUFFWOIKGU4ZONWI.jpg?auth=0a18a5f353e6743d4f2196c963cdb7f5acf58dc4a7d28391a728585dcb108d04&smart=true&width=1100&height=666",
        "url": "https://www.aeromexico.com"
      }
  ],
  "accommodationOptions": [
    {
        "name": "TRS Coral Hotel",
        "description": "Se sitúa en Cancún, playa del carmen, cuenta con zona privada de playa, piscina al aire libre, wifi gratis en todo el hotel y 13 restaurantes con diferentes menús.",
        "imageUrl": "https://www.palladiumhotelgroup.com/content/dam/palladium/images/hoteles/mexico/costa-mujeres/hotel/piscinas/trs-coral-hotel/TRS-Coral-Hotel-header-home.jpg.transform/rendition-md/image.jpg",
        "url": "https://www.palladiumhotelgroup.com/"
      },
      {
        "name": "Riu Palace Hotel",
        "description": "Se sitúa en Cancún, playa del carmen, cuenta con zona privada de playa, piscina al aire libre, wifi gratis en todo el hotel y 13 restaurantes con diferentes menús.",
        "imageUrl": "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/14/7b/73/78/panoramic-view.jpg?w=700&h=-1&s=1",
        "url": "https://www.riu.com/es/hotel/mexico/playa-del-carmen/"
      }
  ]
}
```

### Create Multiple Travel Plans

Creates multiple travel plans in a single request.

POST : /api/TravelPlan/createTravelPlans

Headers: 
    ``Authorization``: Bearer Token (Admin only)
    ``Content-Type``: application/json

```json
Request Body:
[
    {
    "name": "Plan Playa del Carmen",
    "description": "Un plan increíble para visitar Playa del Carmen",
    "destinationName": "Playa del Carmen",
    "image": "",
    "transportOptions": [
      {
        "name": "Avianca",
        "description": "Avianca, una aerolínea Colombiana de categoría premium, con más de 104 años de trayectoria, volando a más de 104 destinos.",
        "imageUrl": "https://www.agenciapi.co/sites/default/files/2023-10/avianca%20nuevo%20logo.png",
        "url": "https://www.avianca.com"
      },
      {
        "name": "Aeromexico",
        "description": "Aeromexico, una aerolínea Mexicana de categoría premium, con más de 90 años de trayectoria, volando a más de 104 destinos.",
        "imageUrl": "https://www.dedinero.com.mx/resizer/v2/GYI3URCNDBBUFFWOIKGU4ZONWI.jpg?auth=0a18a5f353e6743d4f2196c963cdb7f5acf58dc4a7d28391a728585dcb108d04&smart=true&width=1100&height=666",
        "url": "https://www.aeromexico.com"
      }
    ],
    "accommodationOptions": [
      {
        "name": "TRS Coral Hotel",
        "description": "Se sitúa en Cancún, playa del carmen, cuenta con zona privada de playa, piscina al aire libre, wifi gratis en todo el hotel y 13 restaurantes con diferentes menús.",
        "imageUrl": "https://www.palladiumhotelgroup.com/content/dam/palladium/images/hoteles/mexico/costa-mujeres/hotel/piscinas/trs-coral-hotel/TRS-Coral-Hotel-header-home.jpg.transform/rendition-md/image.jpg",
        "url": "https://www.palladiumhotelgroup.com/"
      },
      {
        "name": "Riu Palace Hotel",
        "description": "Se sitúa en Cancún, playa del carmen, cuenta con zona privada de playa, piscina al aire libre, wifi gratis en todo el hotel y 13 restaurantes con diferentes menús.",
        "imageUrl": "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/14/7b/73/78/panoramic-view.jpg?w=700&h=-1&s=1",
        "url": "https://www.riu.com/es/hotel/mexico/playa-del-carmen/"
      }
    ]
  },
  {
    "name": "Plan Cartagena",
    "description": "Un plan increíble para visitar Cartagena",
    "destinationName": "Cartagena",
    "image": "https://static-uat.cambiocolombia.com/s3fs-public/styles/style_aspect_16_9_large/public/2023-01/cartagena_torre_reloj.jpg.webp?itok=9pm9rwbQ",
    "transportOptions": [
      {
        "name": "Avianca",
        "description": "Avianca, una aerolínea Colombiana de categoría premium, con más de 104 años de trayectoria, volando a más de 104 destinos.",
        "imageUrl": "https://www.agenciapi.co/sites/default/files/2023-10/avianca%20nuevo%20logo.png",
        "url": "https://www.avianca.com"
      },
      {
        "name": "LATAM Airlines",
        "description": "LATAM Airlines, líder en viajes en América Latina, con conexiones a destinos internacionales y locales.",
        "imageUrl": "https://www.expreso.info/files/2021-08/LATAM_Airlines.jpg",
        "url": "https://www.latam.com"
      }
    ],
    "accommodationOptions": [
      {
        "name": "Hotel Las Américas",
        "description": "Ubicado en la zona norte de Cartagena, cuenta con acceso directo a la playa, piscinas al aire libre y restaurantes especializados en cocina caribeña.",
        "imageUrl": "https://cf.bstatic.com/xdata/images/hotel/max1024x768/151591076.jpg?k=6278eddc1edf5b4c2bd00088b9250e71032c111769e4145e8d9dc5f2d2ae62a9&o=&hp=1",
        "url": "https://www.hotellasamericas.com.co"
      },
      {
        "name": "Hotel Charleston Santa Teresa",
        "description": "Situado en la Ciudad Amurallada, ofrece una combinación de historia y lujo con habitaciones exclusivas, spa y vistas al mar Caribe.",
        "imageUrl": "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/2b/e4/be/fd/facade-charleston-santa.jpg?w=700&h=-1&s=1",
        "url": "https://www.hotelcharlestonsantateresa.com/es"
      }
    ]
  }
]
```

### Get Travel Plan by Destination Name
Retrieves a travel plan for a specific destination.

``GET``: /api/TravelPlan/getTravelPlanByDestinationName/{destinationName}

Headers:
    ``Authorization``: Bearer Token (Admin only)

Parameters:
    ``destinationName`` (path): Name of the destination


### Get All Travel Plans
Retrieves all travel plans.

``GET``: /api/TravelPlan/getAllTravelPlans

Headers:
    ``Authorization``: Bearer Token (Admin only)


### Update Travel Plan
Updates an existing travel plan.

``PUT``: /api/TravelPlan/updateTravelPlan/{id}

Headers:
    ``Authorization``: Bearer Token (Admin only)
    ``Content-Type``: application/json

Parameters:
    ``id`` (path): ID of the travel plan to update

```json	
Request Body:
{
    "name": "Updated Paris Adventure",
    "description": "Updated 4-day cultural experience",
    "destinationName": "Paris",
    "image": "updated-paris-plan.jpg",
    "transportOptions": ["Train", "Bus", "Metro"],
    "accommodationOptions": ["Hotel", "Apartment"]
}
```

### Assign to City
Assigns a travel plan to a specific city.

``PUT``: /api/TravelPlan/assignToCity/{travelPlanId}/{cityId}

Headers: 
    ``Authorization``: Bearer Token (Admin only)

Parameters: 
    ``travelPlanId`` (path): ID of the travel plan 
    ``cityId`` (path): ID of the city


### Delete Travel Plan
Deletes a specific travel plan.

``DELETE``: /api/TravelPlan/deleteTravelPlan/{id}

Headers: 
    ``Authorization``: Bearer Token (Admin only)

Parameters: 
    ``id`` (path): ID of the travel plan to delete


### Send Travel Plan Email
Sends a travel plan via email.

``POST``: /api/TravelPlan/send-email

Headers: 
    ``Authorization``: Bearer Token (Admin, User, TestUser)
    ``Content-Type``: application/json

```json
Request Body:
{
    "userEmail": "user@example.com",
    "htmlContent": "<html>Travel plan details...</html>"
}
```

### Error Responses
- ``200 OK``: Successful response
- ``400 Bad Request``: Invalid input or business rule violation
- ``401 Unauthorized``: Authentication required
- ``403 Forbidden``: Insufficient permissions
- ``404 Not Found``: Resource not found
- ``500 Internal Server Error``: Server error