# Lightmare Studios - Programming Test - News Article Streaming
Your task will be to implement front-end and back-end systems for retreving News Articles using the existing systems within this package.

Please use the Unity `6` (`6000.x.xxf1`), you can download older Unity Versions here: https://unity.com/releases/editor/archive

If you aren't able to complete the task fully, try to plan it out at least - jot down in pseudo-code or comments how you might tackle the problem with more time.

## What skills will be required?
- Understanding of Unity UI (uGUI or UIToolkit preferred).
- Understanding of Asynchronous C# programming (Async / Await).
  - You will not lose points for using `async void` for UI event handles.

## Details
The UI should display and work following these conditions:
- Each article should be able to be clicked, where it will take the user to the source of the article in their browser.
- Upon interaction with a UI Button, your system will downloads 3 news articles using an instance of `NewsClient`, the following 3 elements should be visible:
  - The Article Title, displayed using a TextMeshPro UI Text Element.
  - The Contents, displayed using a TextMeshPro UI Text Element.
  - The Image, which can be streamed on a single `INewsArticle` basis after recieving the `INewsResponse` payload from `NewsClient`.

As a starting point, you should make use of the following script(s): `NewsClient.cs`.

## Test Scenarios
- A UI Element (E.g. a button) is used to load in the news articles.
- All 3 news articles are loaded in successfully, displaying image and contexts.
- All 3 news articles can be interacted with to redirect the user to the source of the article.
- The solution is mostly bug free.
  
## Bonus Points:
- The package was imported using the package manager (See below).
- The solution has error handling.
- The solution has code that is clear to read and understand.
- The UI is flexible and fits different aspect ratios (16:9, 16:10, 4:3, etc).
- The solution effectively uses Assembly Definitions to manage scripts. (See more: https://docs.unity3d.com/6000.2/Documentation/Manual/assembly-definition-files.html)

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
