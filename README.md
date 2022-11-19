# clean-arch-csharp

A clean arch project to learn more about many archtecture concepts

## Important

- all commits from [@devone-software-solutions](https://github.com/devone-software-solutions) was created by me, i just forgot to change my `user.name` and `user.email` from my git config
- **this app is not focused on web UI. The UI is just to have a way to manually test the methods, so please don't judge the web application**
- CQRS is implemented for study purposes only, an application of this size has no need to implement the CQRS pattern

## Repository pattern

separate the reponsability to handle with selects, inserts, updates, deletes to the repository

## DDD

It is a set of principles focusing on mastery, exploring models in creative ways, and defining and speaking the Ubiquitous language, based on the bounded context. *[Fullcycle denifition](https://fullcycle.com.br/domain-driven-design/)*

- D `Domain`
- D `Driven`
- D `Design`

## CQRS

CQRS stands for Command and Query Responsibility Segregation, a pattern that separates read and update operations for a data store. Implementing CQRS in your application can maximize its performance, scalability, and security. The flexibility created by migrating to CQRS allows a system to better evolve over time and prevents update commands from causing merge conflicts at the domain level. *[Microsoft denifition](https://learn.microsoft.com/en-us/azure/architecture/patterns/cqrs)*

- C `command`
- Q `query`
- R `reponsibility`
- S `segregation`

## MediatR

An object that encapsulates how a set of objects interact. The Mediator promotes loose coupling by preventing objects from referring to each other explicitly and allowing you to vary their interactions independently. *[treinaweb denifition](https://www.treinaweb.com.br/blog/mediator-pattern-com-mediatr-no-asp-net-core)*

