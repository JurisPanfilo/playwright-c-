# Playwright c# UI Test automation

Playwright c# NUnit Allure test automation boilerplate for cross browser UI automation. 
## Running Tests Locally

To run tests, run the following command

```bash
  dotnet test --settings:msedge.runsettings
```
or 
```bash
  dotnet test --settings:chromium.runsetting
```
 Alure report generation

```bash
  npx allure-commandline serve
```

## Test run on GithubAction
- chromium, msedge as parameters for test run
- Alure report (including history) is published n GitHub Pages


