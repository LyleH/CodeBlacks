#THE BLACK SPOT - Finding the guilty one

##Synopsis
A web based Development Operations tool to inspect, bisect and to narrow down portion of code that has caused a particular integration test to fail by comparing the failed code coverage report with the successful report. We endevour to improve a developer's investigation and diagnostic time on broken tests by 50%.

##Motivation
Integration testing covers many layers/modules of the application in a single run. It is far more complex when compared to the simplistic unit test. Developers spends a large amount of time diagnosing why integration tests have broken. Sometimes this can be days. A large chuck is spent identifying portion of code where the code coverage of the failed run differs from the passing run. 

##Tools used
- Visual Studio 2015 RC
- Azure Web Apps
- Azure Web Jobs
- Azure Storage
- Azure Queues

##Installation
This is a cloud solution so installation should only need to be done once. Because of this, it is a reasonably manual process.

- Create an Azure storage account
- Create an Azure blob container called testzips
- Create an Azure queue called run-and-compare-tests
- Create an Azure blob container called testcomparisons
- Create connectionstrings.config and add it to the CodeBlacks.Web directory. It must contain the connection string of the created Azure storage account with the name "TestComparisonStorage". The file should look something like this:
```xml
<connectionStrings>
    <add name="TestComparisonStorage" value="[connection string to Azure storage account]"/>
</connectionStrings>
```
The connection string can be found in the properties of the storage account in Visual Studio.
- Open Visual Studio and rebuild it.
- Right-click CodeBlacks.Web and select Publish
- Select Azure WebApps TODO: Finish this
- Right-click CodeBlacks.WebJob and select Publish to an Azure WebJob TODO: Check this
- TODO: Finish this.
Provide code examples and explanations of how to get the project.

##Outside code
- OpenCover (Code coverage for .Net)
- Report Generator (Converts xml to output from code coverage to a readable format)
- Diffplex (Generates textual differences between files)
- MSBuild 14
- AngularJS
- Bootstrap
- Bootstrap cyborg
- JQuery

List outside code for example a bootstrap theme that was used

##Contributors
- Alven Lee
- Jeremy Beavon
- Andrew Hawken
- Chris Flores
- Lyle Henkeman

##API Reference
POST api/testcomparison

GET api/testcomparison/requestId
Returns JSON of the comparison results. 

