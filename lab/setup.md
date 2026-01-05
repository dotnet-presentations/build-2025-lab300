# Workshop setup

To complete this workshop you will need to clone a repository with a copy of the contents of this repository

> [!Hint]
> Under regular conditions you would need to ensure all prequirements, but don't worry. We have ensured this environment as all you need.

## Configure GitHub Copilot

> [!IMPORTANT]
> For your convenience we have the username and password on the instructions, but you can also see their values in the Resources tab

<!--For this lab you need a [GitHub account](https://docs.github.com/get-started/learning-about-github/types-of-github-accounts), if you don't have one no worries, you can create a personal account for free. Create your account in the [GitHub sign up page](https://github.com/signup).-->

1. [] Open **Edge** and go to `https://github.com/Microsoft-Build-2025`
1. [] Select **Continue** for Single sign-on to **Skillable Events**
1. [] Enter +++@lab.CloudPortalCredential(User1).Username+++ on the Email, phone, or Skype input box and click on **Next**
1. [] Enter +++@lab.CloudPortalCredential(User1).Password+++ on the password field and click on **Sign in**
1. [] Click on **Yes** when prompted to **Stay signed in**, you will be redirect to the main organization page, you can close the tab.
1. [] Open Visual Studio 2026
1. [] Select **Continue without code**, if prompted to sign-in, you can click Close.
1. [] Click on Copilot icon on top bar (left side next to the search input box)
    ![Copilot icon](./images/0-copilot-icon.png)
1. [] Click on **Sign in to use Copilot** option
1. [] A browser will automatically open, you should already be signed in, click **Continue** for the signed in user.
10. [] Authorize Visual Studio access to user by clicking on the green **Authorize github* button at the bottom of the page.
1. [] Click **open**  browser asks for the confirmation (**This site is trying to open Microsoft Visual Studio.**)
1. [] After Copilot is setup you should now have a **Walkthrough: GitHub Copilot Chat** open tab in Visual Studio and the GitHub Copilot button should be green.

You can close the Walkthrough, we are now ready to start working on our code with the help of Copilot.

## Clone lab repository

Let's clone the repository you'll use for the lab.

1. [] Click on **File -> Clone Repository** button.
2. [] Type `https://github.com/dotnet-presentations/build-2025-lab300` and press **Clone**. 

The code is now opened in Visual Studio, feel free to take a look at it or skip to the next section to start the app.

## Start the app

1. [] Open the **Solution Explorer** from teh **View -> Solution Explorer** menu.
1. [] Set the **TinyShop.AppHost** as the startup project if it isn't by right clicking on the **TinyShop.AppHost** and selecting **Set as startup project**  and start the project with F5 or Debug -> Start Debugging from the menu.

    The .NET Aspire AppHost will start two applications and the .NET Aspire Dashboard:

    - The backend .NET app on **https://localhost:7130**. 
    - The frontend Blazor app on **http://localhost:7085**. You can see the app by opening that URL from the dashboard

1. [] Stop debugging and close the application.

## Summary and next steps

You've now cloned the repository you'll use for this for the rest of the workshop.
