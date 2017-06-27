# What is this ?

EventLogger is an simple way to log every thing in Asp.net Mvc projects that use Entity Framework Code First.

By use this library you have following feature in your project:
- Automatic log all of event such as view item, delete item, login and ...
- Automatic log all of errors during request even customErrors mode is on
- Log all type of errors over the asp pipeline.
- Automatic add log table to your database.
- Manual log in over the application code.
- Url to see Logs by search and filtering.
- Authorize log page Url by your Application Roles.

# How to use ?

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

I hope it helps.
Have fun.

# Screenshots

![EventLogger](https://github.com/hamed-shirbandi/EventLogger/blob/master/EventLogger.Mvc.Example/Content/img/1.png)
