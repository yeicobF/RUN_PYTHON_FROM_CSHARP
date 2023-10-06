# HOW TO RUN C# FROM TERMINAL?

> Author: Francisco Jacob Flores Rodríguez
> Tuesday, January 12th, 2021 [06:43 PM - 06:53 PM]


In this text I will explain how to create and run a C# project from terminal.

## OPTION 1: You will not create a solution

1.- Open the terminal of your preference. In this case I used Windows Powershell.
2.- Go to the desired directory where you will have your project.
3.- Write the next command once you are in the desired folder:
    
    `dotnet new console``

4.- After you write the previous command, some folders and files will be created.
5.- You will see a file named "Program.cs". That file will contain a C# script
    which contains the basics to run a C# program, incluiding the "Main" method.
6.- After this, you can start working in the Main from the "Program.cs" file, or
    you can work from another file. Remember that the code that will run is the
    "Main" one. This means that when you run your program, the only one to
    execute will be "Program.cs". If you want this to happen from another file,
    then you must delete the "Main" from "Program.cs", or ultimately delete
    "Program.cs", and create a "Main" from another file.
7.- Once you have taken all the said before into consideration and your code is
    error free, write the next command in the terminal:

        `dotnet run``
    
    This will run the code that you have created (if it does not have any
    syntax errors).

8.- And that is all you need to run a C# script.

## OPTION 2: You created a solution
    
> Wednesday, January 13th, 2021 [04:00 AM]

1.- If you created a solution, then you will first have to compile your program.
    This is achieved by using the next command:

        `dotnet build solution_name.sln``
    
2.- After you builded / compile your solution with no errors, you will be able
    to run your program / solution. This not guarantee that it will not occur an
    exception. This is achieved by using the next command:

        `dotnet run solution_name.sln``
    
3.- If you make any changes, you will have to repeat the last 2 steps again.
