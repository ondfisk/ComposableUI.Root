# Composable UI PoC

This repository demonstrates a solution to composing multiple Blazor WebAssembly project into one single app.

The solution has been configured with Entra ID as authentication mechanism (documentation missing)

## Components

- [Downstream API](https://github.com/ondfisk/ComposableUI.DownstreamApi): Downstream API component
- [Component 1](https://github.com/ondfisk/ComposableUI.Component1): Example component (Counter)
- [Component 2](https://github.com/ondfisk/ComposableUI.Component1): Example component (Fetch data from downstream API)
- [Root](https://github.com/ondfisk/ComposableUI.Root): `this` composable root

## Setup

Rename `nuget.config.sample` to `nuget.config` and supply info.

## Run

- Start the downstream API.
- Ensure downstream API is configured correctly in `ComposableUI.Root/wwwroot/appsettings.json`.
- Run the app.
