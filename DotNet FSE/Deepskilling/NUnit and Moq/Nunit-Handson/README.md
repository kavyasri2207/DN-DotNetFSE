# NUnit Testing Concepts & Objectives

## 1. Unit Testing vs Functional Testing
*   **Unit Testing**: The practice of testing the *smallest* testable parts of an application (like a single method or function) independently. Dependencies are usually "mocked" (faked) to isolate the unit. It ensures the internal logic works perfectly.
*   **Functional Testing**: Testing the complete software application against the user requirements. It tests the system as a whole, from the user interface down to the database, ensuring the entire workflow functions correctly.

## 2. Types of Testing
*   **Unit Testing**: Testing individual functions in isolation.
*   **Functional Testing**: Testing business workflows end-to-end.
*   **Automated Testing**: Using scripts and software tools (like NUnit) to execute tests automatically rather than a human clicking through screens manually.
*   **Performance Testing**: Testing how the system behaves under heavy load or stress.

## 3. Benefits of Automated Testing
1.  **Speed**: Tests run in milliseconds compared to slow manual human testing.
2.  **Reliability**: Automated tests never make human errors or forget steps.
3.  **Regression Prevention**: When you add new features, running automated tests guarantees you didn't accidentally break old features.
4.  **Documentation**: Tests act as living documentation of how the code is supposed to work.

## 4. Loosely Coupled & Testable Design
A "loosely coupled" design means classes are not heavily dependent on each other. If `Class A` needs data, it shouldn't hardcode a connection to `Class B`. Instead, it should use **Interfaces** or **Dependency Injection**. 
*   **Why it's testable**: If code is loosely coupled, we can easily inject "Mock" data or fake classes during Unit Testing. This allows us to write code that is NOT dependent on another class for data.

## 5. Attributes in NUnit
*   `[TestFixture]`: Marks a class that contains tests.
*   `[Test]`: Marks a specific method inside a TestFixture as a runnable test.
*   `[SetUp]`: Runs *before* every single test. Used for declaring and initializing objects.
*   `[TearDown]`: Runs *after* every single test. Used for cleaning up memory.
*   `[Ignore]`: Tells the test runner to skip this test.

## 6. Benefit of Parameterized Test Cases (`[TestCase]`)
Using `[TestCase]` allows you to run the **exact same test logic** multiple times with different inputs. 
*   **Benefit**: Instead of writing 10 separate methods to test adding positive numbers, negative numbers, and zeroes, you just write *one* single method and pass 10 `[TestCase]` attributes above it. It drastically reduces duplicate code!

---

## Simulated Test Execution Output

Since the testing relies on NUnit Framework runner, here is the exact simulated output you would see in your Visual Studio Test Explorer when running `CalculatorTests.cs`:

```text
NUnit Adapter: Test execution started
Running all tests in CalculatorTests.dll

  Passed Addition_WhenCalled_ReturnsSum [14 ms]
  Passed Addition_MultipleInputs_ReturnsExpectedSum(10,20,30) [2 ms]
  Passed Addition_MultipleInputs_ReturnsExpectedSum(-5,-5,-10) [1 ms]
  Passed Addition_MultipleInputs_ReturnsExpectedSum(100,0,100) [1 ms]
  Passed Addition_MultipleInputs_ReturnsExpectedSum(-50,50,0) [1 ms]
  Ignored Addition_IgnoredTest
    => This test is intentionally ignored to demonstrate the [Ignore] attribute functionality.

Test Run Successful.
Total tests: 6
     Passed: 5
     Ignored: 1
 Total time: 0.8400 Seconds
```
