# What is this ?
very useful event logger to log any event such as errors. this automaticaly add 2 table with names ErrorLogs and EventLogs to your databas.
in your Mvc project just by define global filter and set your database connectionString name in appSetting, log enabled and all information about errors or other events saved in related tables.

# How to use ?
first need to add some setting in your app config file:
```xml
  <appSettings>
    <add key="EventLoggerConnectionStringName" value="YourAppConnectionStringName" />
	.
	.
	.

  </appSettings>
```
replace your database connection name with YourAppConnectionStringName.
then call event loger AppStart and define following filters globaly in your project appStart

```c#
  EventLogger.Config.AppStart();
  GlobalFilters.Filters.Add(new ErrorLoger());  
  GlobalFilters.Filters.Add(new EventLogger());
```

thats all we need to do.
run your mvc project and see your database !
2 tabale added in your database. now open EventLogs table and you should see some log in it.

# screenshots

