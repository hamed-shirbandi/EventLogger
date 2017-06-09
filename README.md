# What is this ?
very useful event logger to log any event such as errors. this automaticaly add 2 table with names ErrorLogs and EventLogs to your databas.
in your Mvc project just by define global filter and set your database connectionString name in appSetting, logging enabled and all information about errors or other events saved in related tables.


# How to use ?

first refrence to following dll in your project:
```code
EventLogger
EventLogger.Mvc
```
now you need to add some setting in your app config file:
```xml
  <appSettings>
    <add key="EventLoggerConnectionStringName" value="YourAppConnectionStringName" />
	.
	.
	.

  </appSettings>
```
replace your database connection name with YourAppConnectionStringName.
then add the following line to the Application_Start method of the Global.asax.cs file

```c#
    EventLoggerConfig.Init();
    GlobalFilters.Filters.Add(new EventLogFilter());
    GlobalFilters.Filters.Add(new ErrorLogFilter());
```
if you need to see error log id in costum error page, you can add cshtml view with name ErrorLogView to views/shared like bellow and get LogId
```code
@model long

@{
    ViewBag.Title = "Error";
    Layout = "~/Views/Shared/_Layout.cshtml";
}

<h2>log id = @Model</h2>
```
thats all we need to do.
run your mvc project and see your database !
2 tabale added in your database. now open EventLogs table and you should see some log in it.

# screenshots
![eventlogger](https://github.com/hamed-shirbandi/EventLogger.Mvc/blob/master/EventLogger.Mvc/Content/img/1.png)
![eventlogger](https://github.com/hamed-shirbandi/EventLogger.Mvc/blob/master/EventLogger.Mvc/Content/img/2.png)
