# Part 02: Enhancing UI with Inline Chat

Now, you'll improve the loading experience using Copilot's inline chat.

> NOTE: This exercise does supply specific prompts to type, but as part of the learning experience we encourage you to discover how to interact with Copilot. Feel free to talk in natural language, describing what you're looking for or need to accomplish.

1. [] In the **Solution explorer** under the **Store** project open **Components/Pages/Products.razor**.
1. [] Find the "Loading..." text in the code.
1. [] Select this text and right-click.
1. [] Choose "Ask Copilot" or press `Alt+/`.
1. [] In the inline chat, type: `Update this to have a loading progress spinner`

    ![Screenshot of VS with inline chat](./images/2-inline-code.png)

1. [] Select **Tab** to accept the changes, and it should look similar to:  

    ```html
    <div class="spinner-border text-primary" role="status">
        <span class="visually-hidden">Loading...</span>
    </div>
    ```

1. [] Run the application to see your new loading spinner in action.

1. [] Stop debugging and close the application

**Key Takeaway**: Inline chat allows you to make targeted improvements to your code without leaving your editor context.

---

[Back: Part 01 - Code Completion with Ghost Text](./part01-code-completion.md) ? | [Next: Part 03 - Referencing Code Files in Chat](./part03-referencing-files.md) ?
