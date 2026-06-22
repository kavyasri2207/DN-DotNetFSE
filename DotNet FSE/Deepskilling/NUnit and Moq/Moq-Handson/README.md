# Moq and NUnit Testing Objectives

## 1. Mocking and Test-Driven Development (TDD)
*   **Key advantages of TDD**: Writing tests before the actual code ensures the code is highly testable, meets requirements immediately, and heavily reduces long-term bugs.
*   **Mocking & Isolation**: In TDD, you want to test a specific class without triggering real-world side effects (like sending an actual email or charging a real credit card). Mocking allows you to completely isolate the unit of work.
*   **Mock Vs Fake Vs Stub**: 
    *   *Stub*: A dummy object that just returns hardcoded data when called.
    *   *Fake*: A working implementation that takes shortcuts (like an in-memory list instead of a real SQL database).
    *   *Mock*: A smart object where you can set strict expectations (e.g., "Verify this method was called exactly 1 time with these exact parameters").

## 2. Mocking in Unit Testing
Mocking simply means replacing a real object with a simulated "Mock" object. We use mocks in unit testing because we only want to test our specific code logic, not the external dependencies. If an SMTP email server is down, our unit test shouldn't fail—it should only fail if our own code logic breaks!

## 3. Dependency Injection (DI)
Dependency Injection is passing an object's dependencies from the outside rather than the object creating them itself using the `new` keyword. 
*   **Constructor Injection**: Passing the dependency through the constructor (e.g., `public CustomerComm(IMailSender mailSender)`). This is the most common and robust approach.
*   **Method Injection**: Passing the dependency directly into a specific method as a parameter when called.
*   *Why it helps*: By injecting the `IMailSender` interface into `CustomerComm`, we can inject a real email server in Production, but seamlessly swap it out and inject a `Mock<IMailSender>` during Testing!

## 4. Demonstrating Testable Code with Moq
To make code testable:
1. Extract external dependencies into **Interfaces** (e.g., `IMailSender`, `IDatabase`, `IFileSystem`).
2. Inject those interfaces via Constructor Injection.
3. In your Test Project, use `new Mock<IMyInterface>()`.
4. Use `.Setup(m => m.Method()).Returns(true)` to force the mock to return whatever fake data you want without executing real code.

### Mocking Databases & File Systems
*   **Mock Database for Unit Tests**: Never hit a real SQL database in a unit test. Instead, mock an `IUserRepository` interface so that `mockRepo.Setup(x => x.GetUser(1)).Returns(new User { Name = "John" })`. The test runs instantly in memory without a database connection string.
*   **Mock Files for Unit Tests**: Never read real files off the hard drive in a unit test. Instead, mock an `IFileReader` interface so that `mockFile.Setup(x => x.ReadText("C:\\test.txt")).Returns("Fake text data")`. This avoids file permission errors and hard drive delays.
