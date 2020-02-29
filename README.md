# MicroFrontend-Blazor-React
[![Netlify Status](https://api.netlify.com/api/v1/badges/25c18438-e903-46f0-bc1e-de6a9cdf6abb/deploy-status)](https://app.netlify.com/sites/awesome-swirles-33a9a7/deploys)

Project that implements the MicroFrontends architecture using Blazor and React

Demo: [https://awesome-swirles-33a9a7.netlify.com/](https://awesome-swirles-33a9a7.netlify.com/)

## Timestamp
Published on: 28/02/2020

Deployed on: 28/02/2020

## Motivation

It is known that with WebAssembly you can make great tools.

But other SPA like React have more tools to improve development and UX with javascript.

So I wanted to get the best out of the 2 worlds and create a tool worthy of WebAssembly with a Micro Frotends architecture.

## Scope

With Blazor I managed to run Roslyn in the browser.

So I made a simple C # compiler.

Apart is the dashboard made with React that contains a graph showing the time it takes Roslyn each time she compiles.

Micro Frotends communicate through events. This is how the compiler made with Blazor sends the compilation time to the dashboard made with React.

## List of features

 - C# Compiler
 - My user profile
 - Graph with the compilation times of Roslyn
 - Cute code editor
 - UX
 - **No server needed, only browser**
 - **Independent css styles**
 - **Blazor and React's project can be developed independently of each other**

## Technologies

 - WebAssembly
 - Blazor
 - React
 - Micro Frontends
 - Roslyn
 - JS CustomEvents
 - Bootstrap
 - Node 10
 - WebPack

## Lessons learned

By doing this project I learned a lot about how Blazor works internally.

I also learned to create a site with the Micro Frontends architecture as indicated by https://micro-frontends.org/ .

I saw on my own the benefits of being able to run C # in the browser.

## Wish list
In a future version I would like to add the following features:
 - Save compilation times in a state.
 - Be able to add a VB.NET and F# compiler.
 - Be able to develop the entire project together in development mode and be able to debug

## How To Run?
### React And Blazor ( / )

    Production: npm run build

 ### Only React ( src/react )
	
    Folder:      cd src/react
    Development: npm start
    Production:  npm run build

### Only Blazor ( src/blazor )

    Folder:      cd src/blazor/BlazorCompiler
    Development: dotnet run
    Production:  dotnet publish

## Credits

 - [https://github.com/Suchiman/Runny](https://github.com/Suchiman/Runny)
 -  [https://demos.creative-tim.com/black-dashboard-react/](https://demos.creative-tim.com/black-dashboard-react/)
 - [https://micro-frontends.org/](https://micro-frontends.org/)



[<img src="https://avatars0.githubusercontent.com/u/28534415?v=4" width="100px;"/><br /><sub><b>Lautaro</b></sub>](https://github.com/lauchacarro)<br />[🐦](https://twitter.com/LauchaCarro)  [💻](https://github.com/lauchacarro/MicroFrontend-Blazor-React/commits?author=lauchacarro)|
| :---: |
