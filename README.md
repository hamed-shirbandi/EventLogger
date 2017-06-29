# What is this ?

EventLogger is a simple way to log everything in Asp.Net Mvc projects that use Entity Framework Code First.

By using this library you will have the following features in your project:
- Automatically logging all of the events such as viewing an item, deleting an item, logging in, etc.
- Automatically logging all of the errors for each request, even when customErrors mode is on
- Logging all types of errors over the ASP.NET HTTP Request Process Pipeline.
- Automatically adding  a log table to your database.
- Manually log anything in the application code.
- Url to see logs, with search and filtering capabilities.
- Authorizing users by roles to see log page.

# How to use?

To use EventLogger in your mvc application first you need to get this source and build it, then refrence bellow library inside your project:

```code
  EventLogger
  EventLogger.Mvc
```
Now you need to add bellow code lines to your global.asax:

```code

  EventLoggerConfig.Init();
  GlobalFilters.Filters.Add(new EventLogFilter());
  GlobalFilters.Filters.Add(new ErrorLogFilter());
```
And add the following lines to your application web.config:

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
Thats all we need to do!
Now if run your project you should see that a table called EventLogs is created in your database.
Click on your application menu links and do some activity and see logs in EventLogs table.
Try to throw errors and see their logs in the EventLogs table.
![EventLogger](https://github.com/hamed-shirbandi/EventLogger/blob/master/EventLogger.Mvc.Example/Content/img/1.png)


# View Logs Page
To view list of logs and search and filter them enter the following url in your browser : /EventLogs

And you should see logs page that allow us to filter by Event or Error types.

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
