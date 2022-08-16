# Statiq boilerplate for Kontent

![Build and publish](https://github.com/kontent-ai/boilerplate-statiq-net/workflows/Publish/badge.svg)
[![Live Demo](https://img.shields.io/badge/Live-DEMO-brightgreen.svg?logo=github&logoColor=white)](https://kontent-ai.github.io/boilerplate-statiq-net)

Boilerplate utilizing [Statiq](https://statiq.dev/) and [Kontent.ai](https://kontent.ai) to provide a starting point in the Jamstack world for .NET developers.

![Screenshot](./screenshot.png)

## Get started

### Requirements

- [.NET 5](https://dotnet.microsoft.com/download)

### Clone the codebase

1. Click the ["Use this template"](https://github.com/petrsvihlik/statiq-starter-kontent-lumen/generate) button to [create your own repository from this template](https://help.github.com/en/github/creating-cloning-and-archiving-repositories/creating-a-repository-from-a-template).

### Running locally

```sh
dotnet run -- preview
```

🎊🎉 **Visit <http://localhost:5080> and start exploring the code base!**

> By default, the content is loaded from a shared Kontent.ai project. If you want to use your own clone of the project so that you can customize it and experiment with Kontent, continue to the next section.

### Create a content source

Application itself is configured to use shared alvawys avalable Kontent-ai project.

If you want to generate the clone of the project in order to be able to edit the content, use [Sample site generator](https://app.kontent.ai/sample-site-configuration).

1. Use "CREATE A NEW SAMPLE PROJECT" for generating the project.
2. Access [the project listing on Kontent.ai application]
3. Select newly generated project (its name is about to be Sample Project M/DD/YYYY, H:MM:SS AM/PM).
4. Enter Project settings -> API keys and copy the Project ID.
5. Adjust `appsettings.json`, `Tools/GenerateModels.ps1`, and `Tools/GenerateModels.sh` by using your project ID.
6. Rebuild the project and run `dotnet run -- preview`.

🚀 **You are now ready to use the site with your own Kontent.ai project as data source on <http://localhost:5080>!** 🚀

## Features

- [Kontent.ai Model Generator](https://github.com/kontent-ai/generators-net) for generating strongly-typed models from Kontent.ai model.
- [Kontent.Statiq](https://www.nuget.org/packages/Kontent.Statiq) module for simple data loading from Kontent.ai to strongly-typed models
- [Sass](https://sass-lang.com/) initial styles for easier style including [reset.css](http://meyerweb.com/eric/tools/css/reset/)
- Razor template engine setup with simple layout

## How it's build

All of the information about boilerplate creation and the content modeling in Kontent.ai have been written up on the blog post [Jamstack on .NET - From zero to hero with Statiq and Kontent](https://ondrej.chrastina.tech/journal/jamstack-on-net-from-zero-to-hero-with-statiq-and-kontent).
