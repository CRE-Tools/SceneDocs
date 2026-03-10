# Contributing

 ### First off, thanks for taking the time to contribute!

 All types of contributions are encouraged and valued. See the [Table of Contents](#table-of-contents) for different ways to help and details about how this project handles them. Please make sure to read the relevant section before making your contribution. It will make it a lot easier for us maintainers and smooth out the experience for all involved. The community looks forward to your contributions.

> [!TIP]
> And if you like the project, but just don't have time to contribute, that's fine. There are other easy ways to support the project and show your appreciation, which we would also be very happy about:
> - Star the project
> - Refer this project in your project's readme
> - Mention the project at local meetups and tell your friends/colleagues

## Table of Contents

1. [I Have a Question](#i-have-a-question)
2. [I Want To Contribute](#i-want-to-contribute)
    - [Reporting Bugs](#reporting-bugs)
        - [Before Submitting a Bug Report](#before-submitting-a-bug-report)
        - [How Do I Submit a Good Bug Report?](#how-do-i-submit-a-good-bug-report)
    - [Suggesting Enhancements](#suggesting-enhancements)
        - [Before Submitting an Enhancement](#before-submitting-an-enhancement)
        - [How Do I Submit a Good Enhancement Suggestion?](#how-do-i-submit-a-good-enhancement-suggestion)
    - [Your First Code Contribution](#your-first-code-contribution)
    - [Improving The Documentation](#improving-the-documentation)
3. [Styleguides](#styleguides)
    - [C# Code Style](#c-code-style)
    - [Unity-Specific Guidelines](#unity-specific-guidelines)
    - [Project Organization](#project-organization)
4. [Commit Messages](#commit-messages)
    - [Commit Types](#commit-types)
    - [Commit Body](#commit-body)

#
## I Have a Question

> [!IMPORTANT]
> If you want to ask a question, we assume that you have read the available <a href="/Documentation~/UserManual.md">Documentation</a>.

Before you ask a question, it is best to search for existing [Issues](/issues) that might help you. In case you have found a suitable issue and still need clarification, you can write your question in this issue.

If you then still feel the need to ask a question and need clarification, we recommend the following:

- Open an [Issue](/issues/new).
- Provide as much context as you can about what you're running into.
- Provide Unity version and plataform target (2022.3.41f1 - Desktop), depending on what seems relevant.

We will then take care of the issue as soon as possible.

## I Want To Contribute

> [!WARNING]
> ### Legal Notice 
> When contributing to this project, you must agree that you have authored 100% of the content, that you have the necessary rights to the content and that the content you contribute may be provided under the [project license](/LICENSE.md).


### Reporting Bugs

#### Before Submitting a Bug Report

A good bug report shouldn't leave others needing to chase you up for more information. Therefore, we ask you to investigate carefully, collect information and describe the issue in detail in your report. Please complete the following steps in advance to help us fix any potential bug as fast as possible.

- Make sure that you are using the latest version.
- Determine if your bug is really a bug and not an error on your side e.g. using incompatible environment components/versions (Make sure that you have read the <a href="/Documentation~/UserManual.md">Documentation</a>. If you are looking for support, you might want to check [this section](#i-have-a-question)).
- To see if other users have experienced (and potentially already solved) the same issue you are having, check if there is not already a bug report existing for your bug or error in the [bug tracker](issues?q=label%3Abug).
- Also make sure to search the internet (including Stack Overflow) to see if users outside of the GitHub community have discussed the issue.
- Collect information about the bug:
- Debug Log
- OS, Platform and Version (Windows, Linux, macOS, x86, ARM)
- Unity Version, IDE, depending on what seems relevant.
- Possibly your input and the output
- Screenshots
- Can you reliably reproduce the issue? And can you also reproduce it with older versions?

#### How Do I Submit a Good Bug Report?

> You must never report security related issues, vulnerabilities or bugs including sensitive information to the issue tracker, or elsewhere in public. Instead sensitive bugs must be sent by email direct to any @PUCPR team member.

We use GitHub issues to track bugs and errors. If you run into an issue with the project:

- Open an [Issue](/issues/new). Select <i><b>Bug Report</b></i> issue template and complete the suggestions (We ask you not to label the issue.).
- Explain the behavior you would expect and the actual behavior.
- Please provide as much context as possible and describe the *reproduction steps* that someone else can follow to recreate the issue on their own. This usually includes your code. For good bug reports you should isolate the problem and create a reduced test case.
- Provide the information you collected in the previous section.

Once it's filed:

- The project team will evaluate and properly label the issue accordingly.
- A team member will try to reproduce the issue with your provided steps. If there are no reproduction steps or no obvious way to reproduce the issue, the team will ask you for those steps and mark the issue as `needs-repro`. Bugs with the `needs-repro` tag will not be addressed until they are reproduced.
- If the team is able to reproduce the issue, it will be marked `needs-fix`, as well as possibly other tags (such as `critical`), and the issue will be left to be [implemented by someone](#your-first-code-contribution).

### Suggesting Enhancements

This section guides you through submitting an enhancement suggestion for CONTRIBUTING.md, **including completely new features and minor improvements to existing functionality**. Following these guidelines will help maintainers and the community to understand your suggestion and find related suggestions.

#### Before Submitting an Enhancement

- Make sure that you are using the latest version.
- Read the <a href="/Documentation~/UserManual.md">Documentation</a> carefully and find out if the functionality is already covered, maybe by an individual configuration.
- Perform a [search](/issues) to see if the enhancement has already been suggested. If it has, add a comment to the existing issue instead of opening a new one.
- Find out whether your idea fits with the scope and aims of the project. It's up to you to make a strong case to convince the project's developers of the merits of this feature. Keep in mind that we prioritize features that will be useful to the majority of our users.

#### How Do I Submit a Good Enhancement Suggestion?

Enhancement suggestions are tracked as [GitHub issues](/issues).

- Use a **clear and descriptive title** for the issue to identify the suggestion.
- Provide a **step-by-step description of the suggested enhancement** in as many details as possible.
- **Describe the current behavior** and **explain which behavior you expected to see instead** and why. At this point you can also tell which alternatives do not work for you.
- You may want to **include screenshots and animated GIFs** which help you demonstrate the steps or point out the part which the suggestion is related to.
- **Explain why this enhancement would be useful** to most CONTRIBUTING.md users. You may also want to point out the other projects that solved it better and which could serve as inspiration.


### Your First Code Contribution
To contribute to this project, follow these steps:

1. Fork the repository to your GitHub account
2. Clone your fork locally
3. Create a new branch from `develop` for your feature
   > [!IMPORTANT]
   > All development must be done on the `develop` branch. Changes or merges directly to `main` will not be accepted.
4. Make your changes following our [Styleguides](#styleguides)
5. Update documentation and CHANGELOG.md if necessary
6. Commit your changes following our [Commit Messages](#commit-messages) guidelines
7. Push to your fork
8. Open a Pull Request (PR) to our `develop` branch
   - Clearly describe your changes
   - Link any related issues
   - Include screenshots or GIFs for UI changes

After submitting your PR:
1. Our team will review your contribution
2. We may request changes or improvements
3. Once approved, your code will be merged into `develop`
4. Your contribution will be included in the next release

> [!TIP]
> Need help? Check our [I Have a Question](#i-have-a-question) section.

## Styleguides
Following consistent coding standards helps maintain code quality and readability. Our project follows Unity and C# best practices.

### C# Code Style
- Use PascalCase for:
  - Class names
  - Method names
  - Properties
  - Public fields
- Use camelCase for:
  - Private fields (prefix with `_`)
  - Parameters
  - Local variables
- Use UPPER_CASE for constants
- Add XML documentation comments to public APIs
- Keep methods focused and under 50 lines when possible
- Use meaningful variable names that describe their purpose

### Unity-Specific Guidelines
- Organize components in the inspector:
  - Use `[SerializeField]` for private fields that need exposure
  - Use `[Header("...")]` to group related fields
  - Use `[Tooltip("...")]` for field descriptions
- Prefab structure:
  - Keep prefabs modular and reusable
  - Use clear naming conventions
  - Document required components

### Project Organization
- Place scripts in appropriate folders:
  ```
  #ROOT#/
  ├── Assets/
  ├── Documentation~/
  ├── Scripts/
  │   ├── Editor/
  │   └── Runtime/
  └── Settings/
  ```
- Use and respect assembly definitions to organize code into `Editor` and `Runtime`
- Use `Assets` folder for any asset that the final user might use
> [!TIP]
> Use subfolders to organize contexts
- use `Settings` folder for any global tool configuration
- `Documentation~` folder is reserved for documentation

> [!NOTE]
> These guidelines are meant to help maintain consistency. If you have suggestions for improvements, please open a discussion.

### Improving The Documentation
To help improve the documentation, follow the steps in [Your First Code Contribution](#your-first-code-contribution) and modify the documentation files in your fork. The editable documentation files are:
- `README.md`
- `CONTRIBUTING.md`
- `UserManual.md`

> [!NOTE]
> Changes to `UserManual.pdf` will be applied during release, using `UserManual.md` as the source of truth. Therefore, direct modifications to `UserManual.pdf` will not be accepted.

When committing documentation changes:
1. Use the `docs:` prefix in your commit message
2. Follow the standard [commit message rules](#commit-messages)

To suggest modifications to the `LICENSE.md` file, please contact a @PUCPR team member directly.

## Commit Messages
Commit messages should be clear, concise, and descriptive. Follow this structure:

```
[type]: "brief description"

[body]
```

### Commit Types
The type prefix indicates the kind of change being made. Use one of the following types:

- `test`: Adding or modifying test code
- `feat`: Developing a new feature
- `refactor`: Code changes that neither fix a bug nor add a feature
- `style`: Changes to code formatting that don't affect the meaning
- `fix`: Bug fixes
- `chore`: Changes to the build process or auxiliary tools
- `docs`: Documentation only changes
- `build`: Changes affecting build system or external dependencies
- `perf`: Performance improvements
- `revert`: Reverting a previous commit

### Commit Body
The commit body should list the affected files categorized by the type of change:

- `added`
- `modified`
- `removed`


```
feat: example feature implementation

added:
- new_file.cs
- another_file.txt

modified:
- existing_file.txt

removed:
- old_file.cs
```

> [!TIP]
> Keep your commits focused and organized. Each commit should represent a single logical change to the codebase.

## Attribution
This guide is based on the **contributing.md**. [Make your own](https://contributing.md/)!
