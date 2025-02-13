# Lightmare Programming Test - News Article Streaming
Your task will be to implement front-end and back-end systems for retreving News Articles using the existing systems within this package.

Please use the Unity Version: `2021.3.38f1`, you can download older Unity Versions here: https://unity.com/releases/editor/archive

If you aren't able to complete the task fully, try to plan it out at least - jot down in pseudo-code or comments how you might tackle the problem with more time.

## Details

The UI should display and work following these conditions:
- Upon interaction with a UI Button, your system will downloads 3 news articles using an instance of `NewsClient`.
- The Image, which you can stream using the packaged `TextureStreamer` static helper class.
- The Contents, displayed using a TextMeshPro UI Text Element
- Each article should be able to be clicked, where it will take the user to the source of the article in their browser.

As a starting point, you should make use of the following scripts: `TextureStreamer.cs`, `NewsClient.cs`

## Test Scenarios
- A UI Element (E.g. a button) is used to load in the news articles.
- All 3 news articles are loaded in successfully, displaying image and contexts.
- All 3 news articles can be interacted with to redirect the user to the source of the article.

## Bonus Points:
- The package was imported using the package manager.
- The solution has error handling.
- The solution has code that is clear to read and understand.
- The UI is flexible and fits different aspect ratios. (16:9, 16:10, 4:3, etc)

## Delivery:
- Your solution can either be uploaded to git, or sent to your reviewer in a `.zip` file.

## How to add to your Unity Project via Package Manager

To add this your package to your Unity project via the Package Manager, follow these steps:

1. Open your Unity project.
2. Open the Package Manager window by going to `Window > Package Manager`.
3. Click on the `+` button in the top left corner of the Package Manager window.
4. Select "Add package from git URL...".
5. In the text field that appears, enter the URL of your repository, adding `.git` to the end of the url. (Example: `https://github.com/ShadowIgnition/LM-Programming-Test.git`)
6. Click the `Add` button.

The package will now be added to your project!
