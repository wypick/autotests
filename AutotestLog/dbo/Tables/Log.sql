﻿CREATE TABLE [dbo].[Log]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [TimeLog] DATETIME NOT NULL, 
    [Name] VARCHAR(50) NOT NULL, 
    [Step] VARCHAR(50) NOT NULL, 
    [Result] VARCHAR(50) NOT NULL, 
    [Error] VARCHAR(50) NULL
)
