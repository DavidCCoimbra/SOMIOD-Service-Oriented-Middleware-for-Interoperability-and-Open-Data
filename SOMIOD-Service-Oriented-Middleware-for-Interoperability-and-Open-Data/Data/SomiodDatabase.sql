/* Table Creation */

CREATE TABLE [dbo].[Applications] (
    [id]          INT           IDENTITY (1, 1) NOT NULL,
    [name]        NVARCHAR (50) NOT NULL,
    [creation_dt] DATETIME      DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    UNIQUE NONCLUSTERED ([name] ASC)
);

CREATE TABLE [dbo].[Modules] (
    [id]          INT           IDENTITY (1, 1) NOT NULL,
    [name]        NVARCHAR (50) NOT NULL,
    [creation_dt] DATETIME      DEFAULT (getdate()) NOT NULL,
    [parent]      INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    UNIQUE NONCLUSTERED ([name] ASC),
    CONSTRAINT [fk_module_parent] FOREIGN KEY ([parent]) REFERENCES [dbo].[Applications] ([id])
);

CREATE TABLE [dbo].[Data] (
    [id]          INT            IDENTITY (1, 1) NOT NULL,
    [content]     NVARCHAR (MAX) NOT NULL,
    [creation_dt] DATETIME       DEFAULT (getdate()) NOT NULL,
    [parent]      INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [fk_data_parent] FOREIGN KEY ([parent]) REFERENCES [dbo].[Modules] ([id])
);

CREATE TABLE [dbo].[Subscriptions] (
    [id]          INT            IDENTITY (1, 1) NOT NULL,
    [name]        NVARCHAR (50)  NOT NULL,
    [creationdt] DATETIME       DEFAULT (getdate()) NOT NULL,
    [parent]      INT            NOT NULL,
    [event]      NVARCHAR (255) NOT NULL,
    [endpoint]    NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    UNIQUE NONCLUSTERED ([name] ASC),
    CONSTRAINT [fk_subscriptionparent] FOREIGN KEY ([parent]) REFERENCES [dbo].[Modules] ([id]),
    CHECK ([event]='Deletion' OR [event]='Creation' OR [event]='Both')
);

/*  
		-- Records already in the database --

Table Applications:

	id	name	creation_dt
	1	App1	03/01/2023 23:08:30
	2	App2	03/01/2023 23:09:04
	3	App3	03/01/2023 23:09:11
	
Table Modules:

	id	name	creation_dt				parent
	1	Mod1	03/01/2023 23:10:09		1
	2	Mod2	03/01/2023 23:10:22		2
	3	Mod3	03/01/2023 23:10:36		3
	
Table Data:

	id	content	creation_dt				parent
	1	On		03/01/2023 23:13:28		1
	2	On		03/01/2023 23:14:13		2
	3	Off		03/01/2023 23:14:25		3

Table Subscriptions:
	
	id	content	creation_dt				parent	event		endpoint
	1	Sub1	03/01/2023 23:12:41		1		Both		127.0.0.1
	2	Sub2	03/01/2023 23:12:58		2		Creation	127.0.0.1
	3	Sub3	03/01/2023 23:13:11		3		Deletion	127.0.0.1
*/



/* Clear Tables */

--DELETE FROM Subscriptions;
--DELETE FROM Data;
--DELETE FROM Modules;
--DELETE FROM Applications;

/* Reset Table Auto-Increment */

--DBCC CHECKIDENT (Subscriptions, RESEED, 0)
--DBCC CHECKIDENT (Data, RESEED, 0)
--DBCC CHECKIDENT (Modules, RESEED, 0)
--DBCC CHECKIDENT (Applications, RESEED, 0)

