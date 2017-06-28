# What is this ?

EventLogger is a simple way to log everything in Asp.Net Mvc projects that use Entity Framework Code First.

By using this library you will have the following features in your project:
- Automatically logging all of the events such as viewing an item, deleting an item, logging in, etc.
- Automatically logging all of the errors for each request, even when customErrors mode is on
- Logging all types of errors over the ASP.NET HTTP Request Process Pipeline.
- Automatically adding  a log table to your database.
- Manually log anything in the application code.
- Url to see logs, with search and filtering capabilities.
- Authorize log page Url by your Application Roles.

# Setting Up

To use EventLogger in your mvc application first need to get this source and build it, then refrence bellow library to your project :

```code
  EventLogger
  EventLogger.Mvc
```
Now you need to add bellow code lines to your global.asax :

```code

  EventLoggerConfig.Init();
  GlobalFilters.Filters.Add(new EventLogFilter());
  GlobalFilters.Filters.Add(new ErrorLogFilter());
```
And add following lines to your application web.config :

```code

  <appSettings>
   <add key="EventLoggerConnectionStringName" value="YourConnectionStringName" />
   .
   .
   .
  </appSettings>
  
  <modules>
    <add name="ErrorLogModule" type="EventLogger.Mvc.ErrorLogModule" />
  </modules>
  
```
Thats all of we need to do !
Now if run your project you should see the table with name EventLogs to your database.
Click on your application menu links and do some activity and see logs in EventLogs table.
Try to throw error and see its logs in related table.
![EventLogger](https://github.com/hamed-shirbandi/EventLogger/blob/master/EventLogger.Mvc.Example/Content/img/1.png)


# View Log Page
To view list of logs and search and filter them enter following url in your browser : /EventLogs

And you should see log page that allow us to filter by Event or Error types.

Error Logs
-----------
![EventLogger](https://github.com/hamed-shirbandi/EventLogger/blob/master/EventLogger.Mvc.Example/Content/img/2.png)

Event Logs
-----------
![EventLogger](https://github.com/hamed-shirbandi/EventLogger/blob/master/EventLogger.Mvc.Example/Content/img/3.png)

Log Detailes
-----------
![EventLogger](https://github.com/hamed-shirbandi/EventLogger/blob/master/EventLogger.Mvc.Example/Content/img/4.png)

I hope it helps.
Have fun.
