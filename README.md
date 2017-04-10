# SqlServerTableReader
App made in windows forms for personal usage.

Application is used to read content from tables in DB stored on Sql Server instance.
It helps to track changes made during work on another app, which manipulates data in tables.

App works only on local instances of Sql Server, and uses only "windows authentication" to connect to chosen instance.

App contains 
- SqlTableReaderProvider used for connecting to Sql Server instance and reads DB, tables names and table content.
- SqlServerTableReaderApplication used for displaying information about chosen tables from SqlTableReaderProvider.Broker class.
