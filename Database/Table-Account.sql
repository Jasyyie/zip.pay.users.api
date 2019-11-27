CREATE TABLE [dbo].[Account]
(
    [Id] INT IDENTITY (1, 1) NOT NULL,
    [UserId] INT NOT NULL,
    [Credit] decimal(9,3) NOT NULL,


    CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Account_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])

);




