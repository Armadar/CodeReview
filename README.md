# CodeReview

Feedback / Errors
-----------------

The original class JobLogger handle 3 different responsibilities breaking the "Single Responsibility" principle from SOLID
There is a duplicated parameter name called "message" in the LogMessage method

The message variable is being used as a boolean with the operator "!"
The "t" variable does not have an initial assigned value
The "l" variable does not have an initial assigned value
the _initialized is not being used
use using System.Data.SqlClient and System.IO; instead of declare them in the beginiing of the files

The Sql connection is not being closed and is not being used in the command creation
The command is receiving a raw query, that is a bad practice that promotes the SQL inyection
A better option to getting the conn string would be ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString instead of ConfigurationManager.AppSettings["ConnectionString"]
The use of the ConfigurationManager.AppSettings["LogFileDirectory"] is missing the .ToString() whe we want to get info from the AppSettings
In the File.WriteAllText method, the DateTime.Now.ToShortDateString() is breaking the file creation because it has backslash characteres, invalid for a filename

The Belatrix.Logger project was created using refactoring and redesign the solution, The Logger.Tests project was added for cover some unit testing
