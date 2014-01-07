BDD Browser Testing - a solution for employing the same automated browser tests during development and testing.
This can help ensure that browser tests stay relevant and up to date, even if development has ceased.

This solution has two parts:
-A C# solution containing a MSTest project. This project is set up to run feature files as test cases.
-A Python 2.7 standalone installation bundled with the required Python files for BDD automated browser testing, plus batch files to install it and run the tests. The .feature files located at BrowserTests/tests will be copied into this standalone when the C# solution builds. This standalone can then be distributed to end users.

Packages used in this solution::
NBehave


To get started:

1. Download the solution code and copy the BrowserTests project into your solution. Copy the BrowserTestingStandalone folder alongside it as well - a build event copies the test files into it.
2. Within Visual Studio, run the sample test and verify that a web browser launches and completes the test.
3. To run any more feature files you create, you'll need to create additional test cases that use the ExecuteFile extension method.

To distribute the standalone version:
1. Create an archive of the BrowserTestingStandalone folder. Instruct users to do the following:
  a. Extract the archive
  b. Run 'install.bat' and follow instructions
  c. Run 'runtests.bat' to run the browser tests.
