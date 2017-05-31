
define follwig filtes globaly in your project web.config and appStart


  <appSettings>
    <add key="EventLoggerConnectionStringName" value="YourAppConnectionStringName" />
	.
	.
	.

  </appSettings>

  EventLogger.Config.AppStart();

  GlobalFilters.Filters.Add(new ErrorLog());  
  GlobalFilters.Filters.Add(new EventLog());
