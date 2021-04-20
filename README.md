# MVVM-Light-Toolkit-Fundamentals-In-WPF
This is a code example in WPF of reference [course](https://www.pluralsight.com/courses/mvvm-light-toolkit-fundamentals "Link of course in Pluralsight") in Pluralsight
about MVVM Light by Laurent Bugnion, the popular toolkit to build client applications in XAML.


## Structure of solution

- **1-Introduction** - Simple application without MVVM
  - Use events in Code-Behind
- **2-Refactoring**  - Refactoring a non MVVM app to MVVM 
  - Making observable
  - Creating ViewModel
  - Creating View Services
  - Adding design time data
  - Binding the View and the ViewModel
- **3-Core** - Using MVVM Light 
  - Using ObservableObject and the ViewModelBase
  - Simplyfying Commands with RelayCommand
  - Sending messages with Messenger
  - Dispatching to the UI thread with the DispatcherHelper
- **4-Extras** - Using SimpleIOC and EventToCommand
  - Managing dependencies with SimpleIoc
  - Handling events and commands with EventToCommand
- **5-Additional** - Installing the MVVM Light Toolkit and Additional Components
  - Using the assemblies from Nuget
  - Installing the whole package in Visual Studio
  - Using the code snippets
- **6-Scenarios** - Advanced Examples with MVVM Light
  - Using MVVM Light in a plug-in based application
  - Building an expandable list with the Messenger
  - Unit tests scenarios for MVVM Light applications
- **PublicApi** - Simple Web Api used in some projects
  > This project uses an InMemory database so that it can be run by everyone. :+1:
  
  
## Versions

- .NET 4.7.2 for WPF projects
- MVVM Light 5.4.1.0
- ASP.NET Core 3.1 for Web Api project
  
  
## Get started

After cloning or downloading the repository:, 
- Reinstall the NugGet packages (if it not already installed) with this command: "*Update-Package -reinstall*"
- To change the startup project from the Solution Explorer, right-click the desired project and choose "Set as StartUp Project" 
from the context-sensitive menu that is displayed. You can also choose this menu item from the Project menu. 
In some situations a solution will require that multiple projects are executing simultaneously. 
To do so, right-click the name of the solution in the Solution Explorer and choose "Set StartUp Projects". 
The solution's property page for startup projects, will be displayed. To indicate that you wish to have more than one startup project, 
first choose the "Multiple Startup Projects" radio button. You will can then set the startup action for each project individually.
  
  
## More Information

Reference of Course: https://www.pluralsight.com/courses/mvvm-light-toolkit-fundamentals

More information about the MVVM Light Toolkit can be found on http://www.mvvmlight.net.

Documentation: See http://www.mvvmlight.net/doc

Repository of MVVM Light: https://github.com/lbugnion/mvvmlight


## Give a Star! :star:

If you like or are using this project please give it a star. Thanks!

## Support this project! :pray:
If you want to help me to maintain this project or add improvements, it would be a pleasure! 

- - - -

## Many thanks to Laurent Bugnion for this awesome toolkit and this [course](https://www.pluralsight.com/courses/mvvm-light-toolkit-fundamentals "Link of course in Pluralsight"). :clap:
