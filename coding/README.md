## SaaS Products Import

We update our inventory of SaaS products from several sources.  Each source provides its content to us in a different format.  Write a command line tool in C# to import the products.

Input/output should be something like this:
 
````bash
$ import capterra feed-products/capterra.yaml

importing: Name: "GitHub";  Categories: Bugs & Issue Tracking, Development Tools; Twitter: @github
importing: Name: "Slack"; Categories: Instant Messaging & Chat, Web Collaboration, Productivity; Twitter: @slackhq
````

Considerations:

- It's not an iteractive application, use the command line arguments to pass the parameters to the application.
- Currently, we are importing products from 2 sites: capterra and softwareadvice.  They send us their weekly feed via email.  This weeks files are in /feed-products
- We plan to add a third provider soon who will make their feed available via csv output online via a url (you don't need to implement this, just keep it mind)
- Do not implement any data persistence code, just provide some dummy classes that echo what they are doing.  Keep in mind that the company is planning to switch from MySQL to MongoDB in 3 months.
- Please provide at least some unit tests (it is not required to write them for every class). Functional tests are also a plus.
- Please provide a short summary detailing anything you think is relevant, for example:
  - Installation steps
  - How to run your code / tests
  - Where to find your code
  - Was it your first time writing a unit test, using a particular framework, etc?
  - What would you have done differently if you had had more time
  - Etc.
* * * 

## Code Submission

As a result of this assignment we expect to recieve a link to your shared git repository (i.e. Bitbucket or Gitlab offer free private repos).
Having full commit history is optional but would be considered as a plus.


## Installation Steps

- Open the ProductCLITool.sln in VS.
- ProductCLITool is the main project containing all the code and is developed on DotNetCore 3.1.
- ProductCLITool.Testing is the Unit Test Project.

- Set Startup project to ProductCLITool.

## Directly Running CLITool
<!-- Initial steps to execute. -->

- Open CMD, change directory to the project folder. i.e. ProjectCLITool folder and execute the following commands.

    dotnet tool uninstall --global ProductCLITool
    dotnet pack
    dotnet tool install --global --add-source ./nupkg ProductCLITool

- Execute the import command but need to pass the full path of file.

Example input:
import capterra "C:\Users\shugupta25\Desktop\Take Home Assignment\software engineer\coding\feed-products\capterra.yaml"
Example Output:
importing: Name: "GitGHub"; Categories: Bugs & Issue Tracking,Development Tools; Twitter: github
importing: Name: "Slack"; Categories: Instant Messaging & Chat,Web Collaboration,Productivity; Twitter: slackhq
importing: Name: "JIRA Software"; Categories: Project Management,Project Collaboration,Development Tools; Twitter: jira