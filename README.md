СОЗДАНИЕ И ЗАПОЛНЕНИЕ БД

CREATE DATABASE [Test_DEPO_DB];
GO
CREATE TABLE [Test_DEPO_DB].[dbo].[Company](

                [Company_ID] int IDENTITY (1,1) NOT NULL PRIMARY KEY CLUSTERED,

                [Company_Name] nvarchar(30) NOT NULL,

                [Company_INN] nvarchar(30) NOT NULL,

                [Company_Legal_Address] nvarchar(255) NOT NULL,

                [Company_Actual_Address] nvarchar(255) NOT NULL

);
GO
CREATE TABLE [Test_DEPO_DB].[dbo].[Employee](

                [Employe_ID] int IDENTITY (1,1) NOT NULL PRIMARY KEY CLUSTERED,

                [Employee_Company_ID] int NOT NULL,

                FOREIGN KEY ([Employee_Company_ID]) REFERENCES [Test_DEPO_DB].[dbo].[Company]([Company_ID]),

                [Employee_Surname] nvarchar(255) NOT NULL,

                [Employee_Name] nvarchar(255) NOT NULL,

                [Employee_Patronymic] nvarchar(255),

                [Employee_Date_Of_Birth] date NOT NULL,

                [Employee_Passport_Series] nvarchar(255) NOT NULL,

                [Employee_Passport_Number] nvarchar(255) NOT NULL

);
GO
INSERT INTO [Test_DEPO_DB].[dbo].[Company]

(

                Company_Name,

                Company_INN,

                Company_Legal_Address,

                Company_Actual_Address

)
VALUES
(

                N'DEPO',

                N'5024096727',

                N'143402, Московская Область, г. Красногорск, тер Коммунальная Зона Красногорск-митино, д. 12',

                N'ул. Зенитчиков, 12, Москва'

);
GO
INSERT INTO [Test_DEPO_DB].[dbo].[Employee]

(

                Employee_Company_ID,

                Employee_Surname,

                Employee_Name,

                Employee_Patronymic,

                Employee_Date_Of_Birth,

                Employee_Passport_Series,

                Employee_Passport_Number

)
VALUES
(

                1,

                N'Блохин',

                N'Максим',

                N'Романович',

                N'2000.06.09',

                N'1122',

                N'333444'

);
