# Part 11: Reusable Prompt Files

Prompt files are a powerful way to create standardized, reusable prompts that can be shared across your team. They help ensure consistency in how you interact with GitHub Copilot and can encode best practices for common tasks like code generation, testing, and documentation.

In this part, you'll create a reusable prompt file for generating unit tests and use it to add tests to the existing TinyShop.Tests project.

## Understanding Prompt Files

Prompt files are markdown files stored in the `.github/prompts` folder of your repository. They:
- Can be invoked by name in Copilot Chat
- Are shared with your entire team through source control
- Can include placeholders for dynamic content
- Help standardize common development tasks

## Exploring the Test Project

The solution already includes a **TinyShop.Tests** project with MSTest configured. Let's take a look at what's there.

1. [] In **Solution Explorer**, expand the **TinyShop.Tests** project.
1. [] Open **ProductTests.cs** to see the existing reference test.
1. [] Notice the test follows the Arrange-Act-Assert pattern and verifies default values for a new Product instance.

## Creating a Unit Test Prompt File

Now let's create a prompt file that helps generate additional unit tests using MSTest.

1. [] In **Solution Explorer**, right-click on the solution and select **Add -> New Folder** and name it `.github` if it doesn't already exist.
1. [] Right-click on the `.github` folder and select **Add -> New Folder** and name it `prompts`.
1. [] Right-click on the `prompts` folder and select **Add -> New Item**.
1. [] Create a new file named `unit-test.prompt.md` with the following content:

   ```markdown
   ---
   mode: agent
   description: Generate comprehensive unit tests using MSTest
   ---

   # Unit Test Generator

   Generate unit tests for the selected code using the MSTest framework.

   ## Requirements

   - Use MSTest attributes ([TestClass], [TestMethod], [DataRow])
   - Follow the Arrange-Act-Assert pattern
   - Include both positive and negative test cases
   - Test edge cases and boundary conditions
   - Use descriptive test method names that explain what is being tested
   - Mock dependencies where appropriate

   ## Test Structure

   Each test should:
   1. Have a clear name following the pattern: `MethodName_Scenario_ExpectedBehavior`
   2. Include a brief comment explaining the test purpose
   3. Use proper assertions with meaningful failure messages

   ## Context

   Generate tests for: ${input:Describe what you want to test}
   ```

1. [] Save the file.

## Using the Reusable Prompt

Now let's use our new prompt file to generate additional unit tests for the Product class.

1. [] In Copilot Chat, type `/` to see available prompt files.
1. [] Select `unit-test` from the list of available prompts.
1. [] When prompted for input, type: `the Product class in DataEntities, including tests for setting and getting each property, and tests using DataRow for multiple values`

   ![Using a prompt file](./images/11-prompt-file.png)

1. [] Review the generated tests. They should include:
   - Tests for each property (Name, Description, Price, ImageUrl)
   - Tests using DataRow for parameterized testing
   - Proper test method naming following the pattern
   - Comments explaining test purposes

## Example Generated Tests

The generated tests should look similar to:

```csharp
[TestMethod]
public void Name_SetValue_ReturnsExpectedValue()
{
    // Arrange
    var product = new Product();
    var expectedName = "Test Product";

    // Act
    product.Name = expectedName;

    // Assert
    Assert.AreEqual(expectedName, product.Name);
}

[TestMethod]
[DataRow(19.99)]
[DataRow(0)]
[DataRow(999.99)]
public void Price_SetValue_ReturnsExpectedValue(double price)
{
    // Arrange
    var product = new Product();
    var expectedPrice = (decimal)price;

    // Act
    product.Price = expectedPrice;

    // Assert
    Assert.AreEqual(expectedPrice, product.Price);
}

[TestMethod]
[DataRow("product1.png")]
[DataRow("product2.png")]
[DataRow("")]
public void ImageUrl_SetValue_ReturnsExpectedValue(string imageUrl)
{
    // Arrange
    var product = new Product();

    // Act
    product.ImageUrl = imageUrl;

    // Assert
    Assert.AreEqual(imageUrl, product.ImageUrl);
}
```

## Running the Tests

1. [] Open **Test Explorer** from **Test -> Test Explorer**.
1. [] Build the solution to discover the tests.
1. [] Click **Run All** to run all tests including the new generated tests.
1. [] Verify that all tests pass.

**Key Takeaway**: Reusable prompt files help standardize how your team uses GitHub Copilot. By creating prompts for common tasks like unit testing, you ensure consistency and encode best practices that everyone on the team can benefit from.
