CREATE TABLE [dbo].[Role] (
    [Id]   INT          IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Meat] (
    [Id]   INT          IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[User] (
    [Id]       INT          IDENTITY (1, 1) NOT NULL,
    [RoleId]   INT          NOT NULL,
    [Username] VARCHAR (50) NOT NULL,
    [Email]    VARCHAR (50) NOT NULL,
    [Gender]   VARCHAR (50) NOT NULL,
    [Password] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UQ_users_email] UNIQUE NONCLUSTERED ([Email] ASC),
    CONSTRAINT [FK_User_ToRole] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([Id])
);



CREATE TABLE [dbo].[Header] (
    [Id]         INT  IDENTITY (1, 1) NOT NULL,
    [CustomerId] INT  NOT NULL,
    [StaffId]    INT  NOT NULL,
    [Date]       DATE NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Header_ToUser] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[User] ([Id])
);

CREATE TABLE [dbo].[Ramen] (
    [Id]     INT          IDENTITY (1, 1) NOT NULL,
    [MeatId] INT          NOT NULL,
    [Name]   VARCHAR (50) NULL,
    [Borth]  VARCHAR (50) NULL,
    [Price]  VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Ramen_ToMeat] FOREIGN KEY ([MeatId]) REFERENCES [dbo].[Meat] ([Id])
);

CREATE TABLE [dbo].[Detail] (
    [HeaderId] INT NOT NULL,
    [RamenId]  INT NOT NULL,
    [Quantity] INT NOT NULL,
    CONSTRAINT [PK_Detail] PRIMARY KEY CLUSTERED ([HeaderId] ASC, [RamenId] ASC),
    CONSTRAINT [FK_Detail_ToHeader] FOREIGN KEY ([HeaderId]) REFERENCES [dbo].[Header] ([Id]),
    CONSTRAINT [FK_Detail_ToRamen] FOREIGN KEY ([RamenId]) REFERENCES [dbo].[Ramen] ([Id])
); 

INSERT INTO [Role] VALUES ('Admin')
INSERT INTO [Role] VALUES ('Staff')
INSERT INTO [Role] VALUES ('Customer')
INSERT INTO [User] VALUES (1, 'admin', 'admin@gmail.com', 'man', 'admin')
INSERT INTO [User] VALUES (2, 'staff', 'staff@gmail.com', 'man', 'staff')
INSERT INTO [User] VALUES (3, 'customer', 'customer@gmail.com', 'man', 'customer')