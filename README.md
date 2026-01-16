# eShopOnContainers

A reference project based on the now-archived [eShopOnContainers](https://github.com/dotnet-architecture/eShopOnContainers) sample by Microsoft. Some pieces of this project may also take some inspiration from the related [eShop](https://github.com/dotnet/eShop) and [eShopOnWeb](https://github.com/dotnet-architecture/eShopOnWeb) samples, but the majority focus will remain on the original eShopOnContainers project. 

This repository aims to be a more in-depth guide to the original project, with some adjustments made to better reflect current best practices, as well as to suit my own tastes and needs.

- I know that the original project was built and organized around DDD patterns, but I'm not going to be following that here. I'll be organizing the project in a way that makes sense to me, and learn about software design/architecture some other time.

The core of this project will be based on the eShopOnContainers [6.0.0 release](https://github.com/dotnet-architecture/eShopOnContainers/tree/6.0.0) since the latest version on the [dev](https://github.com/dotnet-architecture/eShopOnContainers/tree/dev) branch is missing some features (eg. user registration). I'll do my best to keep this project up to date with the latest .NET releases though.

- The corresponding reference e-book for this version of eShopOnContainers is version [5.0.2](https://github.com/dotnet-architecture/eBooks/blob/9af5228f0a435456c99c56b7f8cd6fed678f1b51/archives/microservices/NET-Microservices-Architecture-for-Containerized-NET-Applications-v5.0.2.pdf). Note that there may be differences in content compared to the [live e-book](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/).

## Related Reading

[eShopOnContainers: A reference application for .NET and microservices deployed using containers](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/multi-container-microservice-net-applications/microservice-application-design#eshoponcontainers-a-reference-application-for-net-and-microservices-deployed-using-containers)

[Everything wrong with eShopOnContainers](https://medium.com/@iamprovidence/everything-wrong-with-eshoponcontainers-ce9319a7a601)

## Update 2026-01-15

It's been a while since I last worked on this repo, so I'm gonna try my hand at this again. It's been long enough for .NET 10 to come out, so it's a good a time as ever to try and re-implement this. All work done before this point has been archived to a dedicated `net8/` directory which will no longer be maintained. Moving forward, the `net10/` directory will contain my current progress.
