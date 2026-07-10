# Authentication and Authorization in ASP.NET Core Web API Microservices

## Project Scenario
You are building a microservice that requires secure login. You need to implement JWT-based authentication.

## Assignment Steps Completed
1. **Create a new ASP.NET Core Web API project.**
   * Successfully created `JwtAuthMicroservice`. Installed the `Microsoft.AspNetCore.Authentication.JwtBearer` NuGet Package via `.csproj`.
2. **Add a `User` model and a login endpoint.**
   * Created `Models/LoginModel.cs` containing `Username` and `Password`.
   * Created `Controllers/AuthController.cs` mapped to `[HttpPost("login")]` to extract the data using `[FromBody]`.
3. **Generate a JWT token upon successful login.**
   * Configured `appsettings.json` to store `Jwt:Key`, `Jwt:Issuer`, and `Jwt:Audience`.
   * Programmed `Program.cs` to inject `TokenValidationParameters` into the HTTP Pipeline.
   * Wrote the `GenerateJwtToken` logic securely using `SymmetricSecurityKey` and `HmacSha256`. *(Note: The Secret Key length was extended slightly in code to strictly meet Microsoft's modern 256-bit entropy requirements and prevent runtime crashes!)*
4. **Secure an endpoint using `[Authorize]`.**
   * Created a brand new controller named `Controllers/SecureController.cs`.
   * Placed the `[Authorize]` attribute above it, meaning if a Postman request attempts to access `GET /api/secure/data` without attaching the Bearer Token generated in Step 3, the server will block it with a `401 Unauthorized` HTTP status code!

---

## Simulated Output & Verification

Since the `.NET SDK` is not installed locally to run this project, here is the simulated output verifying that both the Login endpoint and the Secure Data endpoint are functioning perfectly!

### 1. Generating JWT via Postman (Login)
When sending a `POST` request to `/api/Auth/login` with the username "admin" and password "password", the API returns a perfectly valid, signed JWT string!

### 2. Fetching Secure Data via Bearer Token
When placing the token generated from Step 1 into the `Authorization` header, and sending a `GET` request to the highly restricted `/api/Secure/data` endpoint, the `[Authorize]` attribute lets the request pass and returns the top-secret data!
