Upgrade version of the MSSQL Profiler

Why: When MSSQL servers are upgraded, previously saved templates are no longer a choice when runng the profiler. 
This code allows to upgrade the version of the file so it's compatible with new version of SQL server one is connecting.

Existing templates for "Microsoft SL Server 14.0" are to be located at %APPDATA%\Microsoft\SQL Profiler\15.0\Templates\Microsoft SQL Server\140
To upgrade the template: ProfilerTemplateUpgrade <template.tdf> <version>

Example: 
Microsoft SQL Server 14.0 will have version 14. 
Microsoft SQL Server "2019" will have version 15.
  
ProfilerTemplateUpgrade "some-template-file.tdf" 15
  
Note: it will attempt to upgrade and create a file "some-template-file-15.tdf" in the same folder. Move that file to appropriate template folder.
