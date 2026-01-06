# Part 07: Debugging with Copilot

In this section, you'll learn how to use Copilot to debug an exception in your application.

1. [] Debug the **AppHost** project if it isn't yet, and open the **store** from teh .NET Aspire dashboard.
1. [] Click on the **Go to About** button in the navigation menu.
1. [] Observe that an exception occurs, and the application crashes.
1. [] Press the **Ask Copilot** option in the pop up.

    ![Pop up for exception with Ask Copilot option](./images/7-ask-copilot-exception.png)

1. [] Review how Copilot brings in debugger information, including stack traces and variable states.
1. [] Note how Copilot recommends a fix for the issue or provides code suggestions to resolve it.

**Key Takeaway**: Copilot can assist in diagnosing and fixing exceptions by analyzing debugger information and providing actionable recommendations.

## Using Watch Windows and Visualizers

In this subsection, you'll learn how to use Copilot to analyze variables using watch windows and visualizers.

1. [] Open the **Products.razor** file again from the **Products** projet.
1. [] Add a breakpoint at the end of the **OnInitializedAsync** method.
1. [] Debug the **TinyShop.AppHost** and open the **store** from the .NET Aspire dashboard, and navigate to the **Products** page.
1. [] When the breakpoint is hit, hover over the **imagePrefix** variable.
1. [] Press the **Copilot** button to analyze the **imagePrefix** variable.

    ![Copilot button on variable](./images/7-inspect-variable.png)

    >Note: you can also see these in the Locals or watch windows

1. [] Observe how Copilot provides detailed information about the variable, including its value and potential issues.
1. [] Hover over the **products** collection and click the **View** button with the magnifier icon.

    ![View button on products](./images/7-view-products.png)

1. [] Use the visualizer to inspect the contents of the **products** collection.
1. [] Click the sparkle button and, in natural language, type:  `Products that have the name outdoor in them and are under 40 dollars`
1. [] Observe how Copilot generates the appropriate expression automatically.

    ![Sparkle icon for visualizer](./images/7-visualizer-sparkle.png)

1. [] Click **Continue in Chat** to have Copilot provide the equivalent LINQ query for the same filter criteria.

**Key Takeaway**: Copilot can enhance debugging by providing detailed insights into variables through watch windows and visualizers. Copilot can simplify complex debugging tasks by generating expressions and LINQ queries based on natural language input.

---

[Back: Part 06 - Using Copilot Vision](./part06-copilot-vision.md) ? | [Next: Part 08 - Commit Summary Descriptions](./part08-commit-summary-descriptions.md) ?
