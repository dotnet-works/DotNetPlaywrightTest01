# Installation
## Steps


##### Getting Error On Powershell

PS E:\JenkinsGitDemo\dotnet\DotNetPlaywrightTest01\DotNetPlaywrightTest01\bin\Debug\net8.0> playwright.ps1 install
playwright.ps1 : File C:\Users\Arrav1\AppData\Roaming\npm\playwright.ps1 cannot be loaded because running scripts is disabled on this system. 
For more information, see about_Execution_Policies at https:/go.microsoft.com/fwlink/?LinkID=135170.

Solution:
Open Powershell in Admin Mode
Set-ExecutionPolicy -Scope CurrentUser -ExecutionPolicy Unrestricted

>dotnet test -- NUnit.Parallelize.Workers=2




Usefull Url And Solution:
https://github.com/microsoft/playwright-dotnet/issues/2454
https://github.com/microsoft/playwright-dotnet/issues/2006


StackOverflow Solutions:
https://stackoverflow.com/questions/71937343/playwright-how-to-wait-until-there-is-no-animation-on-the-page
https://stackoverflow.com/questions/2797091/css-and-and-or
