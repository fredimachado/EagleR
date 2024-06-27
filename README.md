# EagleR

I use Eagle (https://eagle.cool/) to collect, search, and organize bookmarks and images.
It's a very handy tool, but it lacks a feature that I really need. Since Eagle is a desktop app, and I use my phone a lot,
I need a way to add URLs to Eagle from my phone. That's why I created this simple app.

![Animation](https://github.com/fredimachado/EagleR/assets/29800/21dd7d3a-ca8d-42b8-88d5-7ac0fef07892)

## How it works

The mobile app (.NET MAUI) serves the purpose of pushing messages to a queue (Azure Storage Queue).
It's an Android-only app that takes advantage of the `ActionSend` Intent. With this, I can share any URL and choose EagleR.
The app will then push a message to the queue with the URL.

The desktop app is a Windows Forms (.NET 8) app that receives messages from the queue.
It uses PuppeteerSharp to take a screenshot of the page and then makes a request to add the URL and image to Eagle.
It acts like the Eagle browser extension, but automated.
