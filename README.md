# Product Management App
This application is a simple RESTful API that performs CRUD (Create, Read, Update, Delete) operations for product management. The application includes basic functionality such as listing products, viewing product details, adding new products, updating existing products, deleting products, and sorting asc or desc by product name.

### Technologies Used
**ASP.NET Core:** The application is built on the ASP.NET Core framework.

**Dependency Injection:** Service and repository classes such as `IProductRepository` and `IProductService` use ASP.NET Core's built-in dependency injection mechanism to manage dependencies.

**RESTful API:** The application is designed in accordance with the principles of RESTful API, which supports CRUD operations.

**Model Binding:** HTTP requests and query parameters are processed by binding to the corresponding model classes. For example, the `Product` model is used with model binding for the CreateProduct method.

**Routing:** Controller classes can be accessed through routes specified by Route attributes.

**Exception Handling:** `Try-catch` blocks are used to handle errors properly. For example, if a product cannot be found during the process of updating or deleting a product, an exception is thrown and this exception is communicated to the client with an appropriate `HTTP status code`.

**Linq and LINQ to Objects:** LINQ (Language Integrated Query) is used for data filtering and sorting.


## Project Structure

- **Controllers:** The controller classes that manage API endpoints are located here.
- - **ProductController:** Controller class containing API endpoints related to products.
- **Models:** Directory containing data modeling classes.
- - **Product**: Class representing the product model.
- **Services:** Directory containing business logic services and service classes.
- - **IProductService:** Interface defining business logic services related to the product.
- - **ProductService:** The class that implements the business logic services related to the product.
- **Repositories:** Directory that manages database operations and data access.
- - **IProductRepository:** Interface defining basic operations related to product data.
- - **ProductRepository:** Class that performs basic operations related to product data.



## API Endpoints
- **GET `/api/products`:** Lists all products.
- **GET `/api/products/{id}`:** Gets the details of a specific product.
- **POST `/api/products`:** Adds a new product.
- **PUT `/api/products/{id}`:** Updates a specific product.
- **DELETE `/api/products/{id}`:** Deletes a specific product.
- **GET `/api/products/list?name={name}`:** Filters products by name.
- **GET `/api/products/list-sorted?name={name}&sort={asc/desc}`:** Filters and sorts products by name.

### SOLID Principles

In order to ensure that the code is open, flexible and maintainable, this project tries to follow SOLID principles. The principles applied are explained below with examples:

- **Single Responsibility Principle (SRP):** Each class or method has only one responsibility. For example, `ProductRepository` only handles database operations.
- **Open/Closed Principle (OCP):** Code is designed to be closed to changes but open to extensions. There is no need to modify existing code when adding new features.
- **Liskov Substitution Principle (LSP):** `ProductRepository` and `ProductService` classes are mutually substitutable.
- **Interface Segregation Principle (ISP):** Interfaces such as `IProductRepository` and `IProductService` are segregated according to client needs. This allows clients to use only the methods they need.
- **Dependency Inversion Principle (DIP):** High-level modules should not depend on low-level modules. The dependency between `ProductService` and `ProductRepositor`y is provided through `IProductRepository`, an abstraction.