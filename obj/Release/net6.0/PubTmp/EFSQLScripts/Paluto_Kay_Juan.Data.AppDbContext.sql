IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220706061426_CreateDb')
BEGIN
    CREATE TABLE [Menus] (
        [Id] int NOT NULL IDENTITY,
        [DishName] nvarchar(50) NOT NULL,
        [DishCategory] nvarchar(50) NOT NULL,
        [AmtPerOrder] int NOT NULL,
        [Price] decimal(18,2) NOT NULL,
        CONSTRAINT [PK_Menus] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220706061426_CreateDb')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220706061426_CreateDb', N'6.0.6');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220706061745_addImageUrl')
BEGIN
    ALTER TABLE [Menus] ADD [FoodImgUrl] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220706061745_addImageUrl')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220706061745_addImageUrl', N'6.0.6');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220711123430_PKJUsersDb')
BEGIN
    CREATE TABLE [UserAcc] (
        [userId] int NOT NULL IDENTITY,
        [Username] nvarchar(50) NOT NULL,
        [Password] nvarchar(16) NOT NULL,
        [CPassword] nvarchar(16) NOT NULL,
        [Email] nvarchar(50) NOT NULL,
        [ContactNum] nvarchar(11) NOT NULL,
        [FName] nvarchar(50) NOT NULL,
        [LName] nvarchar(50) NOT NULL,
        [isAdmin] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_UserAcc] PRIMARY KEY ([userId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220711123430_PKJUsersDb')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220711123430_PKJUsersDb', N'6.0.6');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220716134124_ContactMsgs')
BEGIN
    CREATE TABLE [Contact] (
        [MsgID] int NOT NULL IDENTITY,
        [FName] nvarchar(75) NOT NULL,
        [Email] nvarchar(50) NOT NULL,
        [Message] nvarchar(1000) NOT NULL,
        CONSTRAINT [PK_Contact] PRIMARY KEY ([MsgID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220716134124_ContactMsgs')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220716134124_ContactMsgs', N'6.0.6');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220720051643_UserOrders')
BEGIN
    CREATE TABLE [Orders] (
        [OrderId] int NOT NULL IDENTITY,
        [CustomerName] nvarchar(100) NOT NULL,
        [CustomerContact] nvarchar(11) NOT NULL,
        [PaymentStatus] nvarchar(max) NOT NULL,
        [MainDishOrder] nvarchar(max) NOT NULL,
        [AppetizersOrder] nvarchar(max) NOT NULL,
        [DessertOrder] nvarchar(max) NOT NULL,
        [DrinksOrder] nvarchar(max) NOT NULL,
        [VenueLocation] nvarchar(100) NOT NULL,
        [CateringDate] datetime2 NOT NULL,
        [Total] decimal(18,2) NOT NULL,
        [OrderDate] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_Orders] PRIMARY KEY ([OrderId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220720051643_UserOrders')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220720051643_UserOrders', N'6.0.6');
END;
GO

COMMIT;
GO

