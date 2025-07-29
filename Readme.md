# Grandeur Backend API

A DotNet API backend for the Grandeur car marketplace application.

## Requirements

- C#
- DotNet 8.0.411
- MySQL (development)

## Setup

1. Clone the repository
2. Install dependencies:

```bash
dotnet build
```

3. Setup database:

```bash
dotnet ef database update
```

4. Start the server:

```bash
dotnet watch
```

OR

```bash
dotnet run
```

## API Endpoints

### Users

- `POST /users/sign_up` - Register a new user
- `GET /users/verify_email` - Verify user email
- `POST /users/login` - User login

### Cars

- `POST /cars/new` - Create a new car listing
- `GET /cars/all` - Get all car listings
- `GET /cars/search` - Search cars by name, brand, or model
- `DELETE /cars/delete` - Delete car listings

<!-- ## Admin Panel

Access the admin panel at `/admin`. Features include:
- User management
- Car listings management
- Analytics dashboard
- Email verification status -->

<!-- ## Dependencies

- Active Admin - Admin interface
- Devise - Authentication for admin
- Mailgun - Email service
- JWT - Token authentication
- Active Model Serializers - JSON serialization
- Rack CORS - Cross-Origin Resource Sharing -->

<!-- ## Testing

Run the test suite:
```bash
rails test
``` -->

## API Documentation

Full API documentation available at:


<!-- ## Development

For local development, emails are sent to letter_opener at:
http://localhost:3000/letter_opener -->
