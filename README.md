## Installation

```sh
pnpm i
```

### Running the Frontend (Next.js)

```sh
pnpm dev
```

### Running the Backend (.Net Core 8)

```sh
dotnet run --project backend/JobApplicationTracker/JobApplicationTracker.csproj
```

## Frontend:

- <img src="images/next.png" alt="" width="28"/> `Next.js`

   The new go-to framework for React. It has a lot of features like server-side rendering, static site generation.

- <img src="images/react-query.png" alt="" width="28"/> `react-query`

    It solves the problem of data fetching, race condition and caching in React applications.

- <img src="images/react-hook-form.png" alt="" width="28"/> `react-hook-form`
    
    It helps to manage form state and validation.

- <img src="images/turbo.png" alt="" width="28"/> `turbo repo`

    Turbo repo makes it easier to share code between different apps

- <img src="images/mui.png" alt="" width="28"/> `Material UI`

    It looks sleek. And it's good if we don't have UI designer.

- <img src="images/axios.png" alt="" width="28"/> `axios`


## Backend:
- Code Coverage: `97%`

  I wrote integration tests for the API one endpoint at a time. Used `FluentAssertions` for assertions.

<img src="images/coverage.png" alt="" width="480"/>

- `Repository Pattern`.

  We can mock the implementation if needed. (for now, I just used in-memory database for testing)

<img src="images/repository.png" alt="" width="480"/>

- `MediatR` along with `FluentValidation` for validation.

<img src="images/mediatr.png" alt="" width="480"/>
<img src="images/validation.png" alt="" width="480"/>

- `swagger`

<img src="images/swagger.png" alt="" width="480"/>

- Screenshots
<img src="images/ui1.png" alt="" width="480"/>
<img src="images/ui2.png" alt="" width="480"/>
<img src="images/ui3.png" alt="" width="480"/>

### Folder structure

```bash
├── backend                   
│   ├── JobApplicationTracker                   # .Net Core API
│   └── JobApplicationTracker.IntegrationTests  # Backend Integration Tests
|   └── JobApplicationTracker.Repository        # Repository Folder
├── apps                                        # Frontend Apps
│   ├── web
│   │   ├── app
│   │       └── job                             # The Add Job Application Page
│   │           └── [id]                        # The Edit Job Application Page
├── packages                                    # Shared Packages
│   ├── ui                                      # Shared UI Components
```
