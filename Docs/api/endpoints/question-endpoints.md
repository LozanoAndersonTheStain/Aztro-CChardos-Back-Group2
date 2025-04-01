# Question Endpoints

## Overview
The Question API provides endpoints for managing questions in the travel recommendation system.

## Base URL
    `/api/Question`

## Endpoints

### Create Question
Creates a new question.

``POST``: /api/Question/createQuestion

Headers:
    ``Authorization``: Bearer Token (Admin)
    ``Content-Type``: application/json

```json
Request Body:
{
    "category": "Preferencia de destino",
    "questionText": "¿Qué tipo de entorno prefieres para tus vacaciones?",
    "supplementaryText": "Piensa en el ambiente donde te sientes más relajado. ¿Te gusta el mar, la naturaleza o la vida urbana?",
    "options": [
        {
            "description": "Playa",
            "image": "https://images.unsplash.com/photo-1590523741831-ab7e8b8f9c7f?fm=jpg&q=60&w=3000&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8cGxheWFzfGVufDB8fDB8fHww",
            "fact": "Las playas son perfectas para relajarse y disfrutar del sol"
        },
        {
            "description": "Montaña",
            "image": "https://i0.wp.com/travelandleisure-es.com/wp-content/uploads/2024/01/senderismo-colombia-trekking-caminata-vacaciones-turismo.jpg?resize=1000%2C670&ssl=1",
            "fact": "Las montañas ofrecen aventuras y vistas espectaculares"
        },
        {
            "description": "Ciudad",
            "image": "https://images.unsplash.com/photo-1477959858617-67f85cf4f1df?fm=jpg&q=60&w=3000&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8Y2l1ZGFkfGVufDB8fDB8fHww",
            "fact": "Las ciudades están llenas de cultura y entretenimiento"
        }
    ]
}

Response:
{
    {
        "id": 1,
        "category": "Preferencia de destino",
        "questionText": "¿Qué tipo de entorno prefieres para tus vacaciones?",
        "supplementaryText": "Piensa en el ambiente donde te sientes más relajado. ¿Te gusta el mar, la naturaleza o la vida urbana?",
        "options": [
            {
        
                "id": 1,
                "description": "Playa",
                "image": "https://images.unsplash.com/photo-1590523741831-ab7e8b8f9c7f?fm=jpg&q=60&w=3000&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8cGxheWFzfGVufDB8fDB8fHww",
                "fact": "Las playas son perfectas para relajarse y disfrutar del sol"
            },
            {
                "id": 2,
                "description": "Montaña",
                "image": "https://i0.wp.com/travelandleisure-es.com/wp-content/uploads/2024/01/senderismo-colombia-trekking-caminata-vacaciones-turismo.jpg?resize=1000%2C670&ssl=1",
                "fact": "Las montañas ofrecen aventuras y vistas espectaculares"
            },
            {
                "id": 3,
                "description": "Ciudad",
                "image": "https://images.unsplash.com/photo-1477959858617-67f85cf4f1df?fm=jpg&q=60&w=3000&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8Y2l1ZGFkfGVufDB8fDB8fHww",
                "fact": "Las ciudades están llenas de cultura y entretenimiento"
            }
        ]
    }
    "success": true,
    "message": "Question created successfully"
}
```


### Create Multiple Questions
Creates multiple questions in a single request.

``POST``: /api/Question/createMultipleQuestions

Headers:
    ``Authorization``: Bearer Token (Admin)
    ``Content-Type``: application/json

```json
Request Body:
{
    "questionTexts": [
        {
            "category": "Preferencia de destino",
            "questionText": "¿Qué tipo de entorno prefieres para tus vacaciones?",
            "supplementaryText": "Piensa en el ambiente donde te sientes más relajado. ¿Te gusta el mar, la naturaleza o la vida urbana?",
            "options": [
                {
                    "description": "Playa",
                    "image": "https://images.unsplash.com/photo-1590523741831-ab7e8b8f9c7f?fm=jpg&q=60&w=3000&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8cGxheWFzfGVufDB8fDB8fHww",
                    "fact": "Las playas son perfectas para relajarse y disfrutar del sol"
                },
                {
                    "description": "Montaña",
                    "image": "https://i0.wp.com/travelandleisure-es.com/wp-content/uploads/2024/01/senderismo-colombia-trekking-caminata-vacaciones-turismo.jpg?resize=1000%2C670&ssl=1",
                    "fact": "Las montañas ofrecen aventuras y vistas espectaculares"
                },
                {
                    "description": "Ciudad",
                    "image": "https://images.unsplash.com/photo-1477959858617-67f85cf4f1df?fm=jpg&q=60&w=3000&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8Y2l1ZGFkfGVufDB8fDB8fHww",
                    "fact": "Las ciudades están llenas de cultura y entretenimiento"
                }
            ]
        },
        {
            "category": "Preferencia de clima",
            "questionText": "¿Qué clima prefieres durante tus vacaciones?",
            "supplementaryText": "Imagina el clima ideal para tus días de descanso. ¿Prefieres calor, frío o algo intermedio?",
            "options": [
                {
                  "description": "Caluroso",
                  "image": "https://www.wradio.com.co/resizer/v2/AD4XTVSSZBCELFUMO77SZRI2RY.jpg?auth=bf4c9cfc8645ac2f8a9bb58e81e53deb06160bdc20974df3a75deff10e50d792&width=650&height=488&quality=70&smart=true",
                  "fact": "El clima cálido es perfecto para actividades al aire libre"
                }, 
                {
                  "description": "Templado",
                  "image": "https://upload.wikimedia.org/wikipedia/commons/5/50/Tamshiyacu_Tahuayo_Regional_Conservation_Area_Iquitos_Amazon_Rainforest_Peru.jpg",
                  "fact": "El clima templado es ideal para explorar todo el día"
                }, 
                {
                  "description": "Frío",
                  "image": "https://img.freepik.com/fotos-premium/vista-ciudad-clima-nevado-calles-ciudad-invierno_215924-1594.jpg",
                  "fact": "El clima frío es perfecto para deportes de invierno"
                }
            ]
        }
    ]
}
```


### Get Question by ID
Retrieves a specific question.

``GET``: /api/Question/getQuestionById/{id}

Headers:
    ``Authorization``: Bearer Token (Admin)

Parameters:
    ``id`` (path): The ID of the question to retrieve.


### Get All Questions
Retrieves all questions.

``GET``: /api/Question/getAllQuestions

Headers:
    ``Authorization``: Bearer Token (Admin)


### Get Questions Paginated
Retrieves questions with pagination.

``GET`` : /api/Question/getQuestionsByPaginated

Headers: 
    ``Authorization``: Bearer Token (Admin)

Parameters: 
    ``page`` (query): Page number (default: 1) 
    ``pageSize`` (query): Number of items per page (default: 10)


### Update Question
Updates a specific question.

``PUT``: /api/Question/updateQuestionById/{id}

Headers: 
    ``Authorization``: Bearer Token (Admin) 
    ``Content-Type``: application/json

Parameters: 
    ``id`` (path): The ID of the question to update

```json
Request Body:
{
    "category": "Preferencia de alojamiento",
    "questionText": "¿Qué tipo de alojamiento prefieres?",
    "supplementaryText": "Imagina el lugar donde te gustaría descansar después de un día de actividades. ¿Lujo, comodidad o algo más económico?",
    "options": [
      {
        "description": "Hotel de lujo",
        "image": "https://www.lafincaresort.com/sites/default/files/inline-images/timthumb%20%282%29.jpeg",
        "fact": "Los hoteles ofrecen comodidad y servicios completos"
      },
      {
        "description": "Hostal o Albergue",
        "image": "https://albergue-casa-jurado-el-paso.hotelmix.es/data/Photos/OriginalPhoto/16006/1600664/1600664512/Casa-Jurado-Hostel-El-Paso-Exterior.JPEG",
        "fact": "Las cabañas te conectan con la naturaleza"
      },
      {
        "description": "Airbnb o Apartamento",
        "image": "https://ba.scene7.com/is/image/ba/airbnb-mountain-house-sunset:16-9?ts=1740587057838&dpr=off",
        "fact": "Los apartamentos te dan más independencia"
      }
   ]
}
```

### Delete Question
Deletes a specific question.

``DELETE``: /api/Question/deleteQuestionById/{id}

Headers: 
    ``Authorization``: Bearer Token (Admin)

Parameters: 
    ``id`` (path): The ID of the question to delete


### Error Responses
- ``200 OK``: Successful response
- ``201 Created``: Resource created successfully
- ``400 Bad Request``: Invalid input or business rule violation
- ``401 Unauthorized``: Authentication required
- ``403 Forbidden``: Insufficient permissions
- ``404 Not Found``: Resource not found
- ``500 Internal Server Error``: Server error