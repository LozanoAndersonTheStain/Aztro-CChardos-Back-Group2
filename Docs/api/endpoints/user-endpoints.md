# User Endpoints

## Overview
The User API provides endpoints for user management, authentication, and authorization.

## Base URL
    `/api/User`

## Endpoints

### Register User
Registers a new user in the system.

``POST``: /api/User/register

Headers:
    ``Content-Type``: application/json

```json
Request Body:
{
    "email": "user@example.com",
    "password": "SecurePassword123!",
    "firstName": "John",
    "lastName": "Doe"
}
```

### Login User
Authenticates a user and returns an access token.

``POST``: /api/User/login

Headers: 
    ``Content-Type``: application/json

```json
Request Body:
{
    "email": "user@example.com",
    "password": "SecurePassword123!"
}

Response:
{
    "id": 1,
    "email": "user@example.com",
    "firstName": "John",
    "lastName": "Doe",
    "role": "User",
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
    "success": true,
    "message": "Login successful"
}
```

### Create User
Creates a new user (Admin only).

``POST``: /api/User/createUser

Headers: 
    ``Authorization``: Bearer Token (Admin)
    ``Content-Type``: application/json


```json
Request Body:
{
    "email": "newuser@example.com",
    "password": "SecurePassword123!",
    "firstName": "Jane",
    "lastName": "Smith",
    "role": "User"
}
```

### Logout
Logs out the current user.

``POST``: /api/User/logout

Headers:
    ``Authorization``: Bearer Token


### Get User by ID
Retrieves user information by ID.

``GET``: /api/User/GetUserById/{id}

Headers:
    ``Authorization`` : Bearer Token

Parameters: 
    ``id`` (path): User ID


### Get All Users
Retrieves all users (Admin only).

``GET``: /api/User/GetAllUsers

Headers:
    ``Authorization``: Bearer Token (Admin)


### Get User by Email
Retrieves user information by email (Admin only).

``GET``: /api/User/GetUserByEmail?email={email}

Headers:
    ``Authorization``: Bearer Token (Admin)

Parameters: 
    ``email`` (query): User email


### Get Users Paginated
Retrieves paginated list of users.

``GET``: /api/User/paginated

Headers: 
    ``Authorization``: Bearer Token

Parameters: 
    ``page`` (query): Page number (default: 1) 
    ``pageSize`` (query): Items per page (default: 10)


### Update User
Updates user information (Admin only).

``PUT``: /api/User/updateUser/{id}

Headers: 
    ``Authorization``: Bearer Token (Admin) 
    ``Content-Type``: application/json

Parameters: 
    ``id`` (path): User ID

```json
Request Body:
{
    "name": "Jane Doe Updated",
    "email": "jane.doe@example.com",
    "password": "newpassword123",
    "role": "Admin"
}
```

### Delete User
Deletes a user (Admin only).

``DELETE``: /api/User/deleteUser/{id}

Headers: 
    ``Authorization``: Bearer Token (Admin)

Parameters: 
    ``id`` (path): User ID


### Login Test User
Creates and logs in a test user account.

``POST``: /api/User/login-test

```json
Response:
{
    "id": 999,
    "email": "testuser@example.com",
    "firstName": "Test",
    "lastName": "User",
    "role": "TestUser",
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
    "success": true,
    "message": "Test user login successful"
}
```

### Error Responses
- ``200 OK``: Successful response
- ``201 Created``: Resource created successfully
- ``400 Bad Request``: Invalid input or business rule violation
- ``401 Unauthorized``: Authentication required
- ``403 Forbidden``: Insufficient permissions
- ``404 Not Found``: Resource not found
- ``500 Internal Server Error``: Server error