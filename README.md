# Developer Evaluation Project

`READ CAREFULLY`

## Instructions
**The test below will have up to 7 calendar days to be delivered from the date of receipt of this manual.**

- The code must be versioned in a public Github repository and a link must be sent for evaluation once completed
- Upload this template to your repository and start working from it
- Read the instructions carefully and make sure all requirements are being addressed
- The repository must provide instructions on how to configure, execute and test the project
- Documentation and overall organization will also be taken into consideration

## Use Case
**You are a developer on the DeveloperStore team. Now we need to implement the API prototypes.**

As we work with `DDD`, to reference entities from other domains, we use the `External Identities` pattern with denormalization of entity descriptions.

Therefore, you will write an API (complete CRUD) that handles sales records. The API needs to be able to inform:

* Sale number
* Date when the sale was made
* Customer
* Total sale amount
* Branch where the sale was made
* Products
* Quantities
* Unit prices
* Discounts
* Total amount for each item
* Cancelled/Not Cancelled

It's not mandatory, but it would be a differential to build code for publishing events of:
* SaleCreated
* SaleModified
* SaleCancelled
* ItemCancelled

If you write the code, **it's not required** to actually publish to any Message Broker. You can log a message in the application log or however you find most convenient.

### Business Rules

* Purchases above 4 identical items have a 10% discount
* Purchases between 10 and 20 identical items have a 20% discount
* It's not possible to sell above 20 identical items
* Purchases below 4 items cannot have a discount

These business rules define quantity-based discounting tiers and limitations:

1. Discount Tiers:
   - 4+ items: 10% discount
   - 10-20 items: 20% discount

2. Restrictions:
   - Maximum limit: 20 items per product
   - No discounts allowed for quantities below 4 items

## Overview
This section provides a high-level overview of the project and the various skills and competencies it aims to assess for developer candidates. 

See [Overview](/.doc/overview.md)

## Tech Stack
This section lists the key technologies used in the project, including the backend, testing, frontend, and database components. 

See [Tech Stack](/.doc/tech-stack.md)

## Frameworks
This section outlines the frameworks and libraries that are leveraged in the project to enhance development productivity and maintainability. 

See [Frameworks](/.doc/frameworks.md)

<!-- 
## API Structure
This section includes links to the detailed documentation for the different API resources:
- [API General](./docs/general-api.md)
- [Products API](/.doc/products-api.md)
- [Carts API](/.doc/carts-api.md)
- [Users API](/.doc/users-api.md)
- [Auth API](/.doc/auth-api.md)
-->

## Project Structure
This section describes the overall structure and organization of the project files and directories. 

See [Project Structure](/.doc/project-structure.md)

# 🚀 Getting Started
This guide will help you set up, run, and test the Sales Management API locally.

## 📦 Prerequisites
Before running the project, ensure you have the following installed:

- **.NET 8 SDK**
- **Docker** (for running the database in a container)
- Any **IDE** like Visual Studio or Rider

## 🔧 Setup Instructions

1. **Clone the Repository**:
    ```bash
    git clone https://github.com/your-username/developer-evaluation-sales-api.git
    cd developer-evaluation-sales-api
    ```

2. **Use Docker Compose**:
    If you want to run the SQL Server in a container using Docker, you can use the `docker-compose` file provided.

    **Start the services**:
    ```bash
    docker-compose up -d
    docker ps
    ```

    This will spin up both the SQL Server container and the application container.

    > 💡 **Note**: If you haven't installed Docker yet, [download Docker](https://www.docker.com/products/docker-desktop).

3. **Configure the Database**:
    Update the connection string in `appsettings.Development.json` to use the Docker container:
    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=sqlserver;Database=SalesDb;User Id=sa;Password=yourStrong(!)Password;"
    }
    ```
    > 💡 **Explanation**:  
    - `Server=sqlserver`: Refers to the `sqlserver` service defined in the `docker-compose.yml`. Docker automatically resolves this name to the correct container.
    - `Database=SalesDb`: The name of the database.
    - `User Id=sa` and `Password=yourStrong(!)Password`: The credentials for the SQL Server container as defined in the `docker-compose.yml`.

4. **Apply Migrations**:
    Once the containers are running, apply the migrations to set up the database:
    ```bash
    cd src/Ambev.DeveloperEvaluation.API
    dotnet ef database update
    ```

5. **Run the API**:
    You can now run the API locally:
    ```bash
    dotnet run
    ```
    The API will be available at: `https://localhost:5001/swagger`

---

## 🧪 Running Tests
Unit tests are located in the `tests/Ambev.DeveloperEvaluation.Unit` project.

To run all tests, execute:
```bash
dotnet test
