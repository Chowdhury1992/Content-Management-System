﻿CREATE TABLE [dbo].[AdminLogIn] (
    [Id]       VARCHAR (50) NOT NULL,
    [Password] VARCHAR (50) NOT NULL,
    [Name]     VARCHAR (50) NOT NULL,
    [Role] VARCHAR(50) NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

