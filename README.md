# Composable UI PoC

This repository demonstrates a solution to composing multiple Blazor WebAssembly project into one single app.

The solution has been configured with Entra ID as authentication mechanism.

## Components

- [Downstream API](https://github.com/ondfisk/ComposableUI.DownstreamApi): Downstream API component
- [Component 1](https://github.com/ondfisk/ComposableUI.Component1): Example component (Counter)
- [Component 2](https://github.com/ondfisk/ComposableUI.Component1): Example component (Fetch data from downstream API)
- [Root](https://github.com/ondfisk/ComposableUI.Root): `this` composable root

## Setup

Rename `nuget.config.sample` to `nuget.config` and supply info.

### App Registrations

1. **ComposableUI.DownstreamApi**

    - Authentication:

        - Platform: `Web`
        - Redirect URIs: `https://localhost/signin-oidc`

    - Expose an API:

        - Application ID URI: `api://<ClientId>`
        - Scopes:

            - Scope name: `access_as_user`
            - Who can consent? `Admins and users`
            - Admin consent display name: `Access the API on behalf of a user`
            - Admin consent description: `Allows the app to access the web API on behalf of the signed-in user`
            - User consent display name: `Access the API on your behalf`
            - User consent description: `Allows this app to access the web API on your behalf`
            - State: `Enabled`

2. **ComposableUI.Client**

    - Authentication:

        - Platform: `Single-page application`
        - Redirect URIs: `https://localhost/authentication/login-callback`

    - API permissions:

        - `ComposableUI.DownstreamApi`:

            - `access_as_user`

        - `Microsoft Graph`:

            - `offline_access`
            - `openid`
            - `profile`

**Note**: Update all `appsettings.json` across all four repositories.

## Run

- Start the downstream API.
- Ensure downstream API is configured correctly in `ComposableUI.Root/wwwroot/appsettings.json`.
- Run the app.
