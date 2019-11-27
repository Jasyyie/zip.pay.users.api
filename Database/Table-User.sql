CREATE TABLE [dbo].[User]
(
    [Id] INT IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (200) NOT NULL,
    [Email] NVARCHAR (200) NOT NULL,
    [MonthlySalary] decimal(9,3) NOT NULL,
    [MonthlyExpense] decimal(9,3) NOT NULL,

    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC),


);
