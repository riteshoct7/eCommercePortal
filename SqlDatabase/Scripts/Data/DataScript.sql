GO
SET IDENTITY_INSERT [Categories] ON 
INSERT [Categories] ([CategoryId], [CategoryName], [CategoryDescription], [CreatedDate], [ModifiedDate], [Enabled]) VALUES (26, N'Shirts', N'Shirts', CAST(N'2021-12-27T09:39:31.7646425' AS DateTime2), CAST(N'2021-12-27T09:39:31.7647411' AS DateTime2), 1);
INSERT [Categories] ([CategoryId], [CategoryName], [CategoryDescription], [CreatedDate], [ModifiedDate], [Enabled]) VALUES (27, N'Shoes', N'Shoes', CAST(N'2021-12-27T09:40:05.1596727' AS DateTime2), CAST(N'2021-12-27T09:40:05.1596734' AS DateTime2), 1);
INSERT [Categories] ([CategoryId], [CategoryName], [CategoryDescription], [CreatedDate], [ModifiedDate], [Enabled]) VALUES (28, N'Jeans', N'Jeans', CAST(N'2021-12-27T09:40:12.5715861' AS DateTime2), CAST(N'2021-12-27T09:40:12.5715867' AS DateTime2), 1);
INSERT [Categories] ([CategoryId], [CategoryName], [CategoryDescription], [CreatedDate], [ModifiedDate], [Enabled]) VALUES (29, N'Trousers', N'Trousers', CAST(N'2021-12-27T09:40:21.2687896' AS DateTime2), CAST(N'2021-12-27T09:40:21.2687917' AS DateTime2), 1);
INSERT [Categories] ([CategoryId], [CategoryName], [CategoryDescription], [CreatedDate], [ModifiedDate], [Enabled]) VALUES (30, N'Electronics', N'Electronics', CAST(N'2021-12-27T09:40:27.0395645' AS DateTime2), CAST(N'2021-12-27T09:40:27.0395649' AS DateTime2), 1);
INSERT [Categories] ([CategoryId], [CategoryName], [CategoryDescription], [CreatedDate], [ModifiedDate], [Enabled]) VALUES (31, N'Slippers', N'Slippers', CAST(N'2021-12-27T09:40:32.7428743' AS DateTime2), CAST(N'2021-12-27T09:40:32.7428748' AS DateTime2), 1);
INSERT [Categories] ([CategoryId], [CategoryName], [CategoryDescription], [CreatedDate], [ModifiedDate], [Enabled]) VALUES (32, N'Supplements', N'Supplements', CAST(N'2021-12-27T09:40:38.5397003' AS DateTime2), CAST(N'2021-12-27T09:40:38.5397007' AS DateTime2), 1);
INSERT [Categories] ([CategoryId], [CategoryName], [CategoryDescription], [CreatedDate], [ModifiedDate], [Enabled]) VALUES (33, N'Furniture', N'Furniture', CAST(N'2021-12-27T09:40:44.1423256' AS DateTime2), CAST(N'2021-12-27T09:40:44.1423280' AS DateTime2), 1);
INSERT [Categories] ([CategoryId], [CategoryName], [CategoryDescription], [CreatedDate], [ModifiedDate], [Enabled]) VALUES (34, N'Grocery', N'Grocery', CAST(N'2021-12-27T09:40:50.0597730' AS DateTime2), CAST(N'2021-12-27T09:40:50.0597738' AS DateTime2), 1);
INSERT [Categories] ([CategoryId], [CategoryName], [CategoryDescription], [CreatedDate], [ModifiedDate], [Enabled]) VALUES (35, N'Cosmetic', N'Cosmetic', CAST(N'2021-12-27T09:40:55.8566426' AS DateTime2), CAST(N'2021-12-27T09:40:55.8566431' AS DateTime2), 1);
INSERT [Categories] ([CategoryId], [CategoryName], [CategoryDescription], [CreatedDate], [ModifiedDate], [Enabled]) VALUES (36, N'Baby Care', N'Baby Care', CAST(N'2021-12-27T09:41:03.7576038' AS DateTime2), CAST(N'2021-12-27T09:41:03.7576048' AS DateTime2), 1);
SET IDENTITY_INSERT [Categories] OFF
GO
SET IDENTITY_INSERT [AspNetRoles] ON 

INSERT [AspNetRoles] ([Id], [Description], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (2, N'Customer', N'Customer', N'CUSTOMER', N'5bb6acd5-7705-4836-ae14-37f313d29526');
INSERT [AspNetRoles] ([Id], [Description], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (3, N'Admin', N'Admin', N'ADMIN', N'358f527b-9191-47f8-8a4b-bee5072c53a3');
SET IDENTITY_INSERT [AspNetRoles] OFF
GO
SET IDENTITY_INSERT [AspNetUsers] ON 

INSERT [AspNetUsers] ([Id], [FirstName], [LastName], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (3, N'Ritesh', N'Parekh', N'riteshoct7@gmail.com', N'RITESHOCT7@GMAIL.COM', N'riteshoct7@gmail.com', N'RITESHOCT7@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEHKawAaR2cF0ZDVngXbNM8J0zuDVm/oxFYG2sUvm+zH0rATxVew5nbCaZdn6sA14/A==', N'ZNS5LNTCR5EPKUWCYPFCNM45EORHK4P4', N'17a407cc-a5aa-4dff-82d2-10df3589a8d4', NULL, 0, 0, NULL, 1, 0);
INSERT [AspNetUsers] ([Id], [FirstName], [LastName], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (5, N'Parth', N'Parekh', N'admin@gmail.com', N'ADMIN@GMAIL.COM', N'admin@gmail.com', N'ADMIN@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEGz7nKKL9MG55SRdPXnMOZoyD+Gp8DUkDBvzD9qlH3jpR/OQgtTDqXHCKyz4dFjmKw==', N'XJJFHEZ347BOLDVQOTJODIYRBIAR5X4K', N'615f0764-4b54-4cc1-b9d5-3a0fd8a51832', NULL, 0, 0, NULL, 1, 0);
SET IDENTITY_INSERT [AspNetUsers] OFF
GO
INSERT [AspNetUserRoles] ([UserId], [RoleId]) VALUES (3, 2);
INSERT [AspNetUserRoles] ([UserId], [RoleId]) VALUES (5, 3);
GO
SET IDENTITY_INSERT [dbo].[Countries] ON 
INSERT [dbo].[Countries] ([CountryId], [CountryName], [CountryDescription], [ISDCode], [CreatedDate], [ModifiedDate], [Enabled]) VALUES (2, N'India', N'India', N'+91', CAST(N'2021-12-27T10:34:47.2764612' AS DateTime2), CAST(N'2021-12-27T10:34:47.2765468' AS DateTime2), 1)
INSERT [dbo].[Countries] ([CountryId], [CountryName], [CountryDescription], [ISDCode], [CreatedDate], [ModifiedDate], [Enabled]) VALUES (9, N'Canada', N'Canada', N'+1', CAST(N'2021-12-27T11:11:41.0000000' AS DateTime2), CAST(N'2021-12-27T11:18:23.6129071' AS DateTime2), 1)
INSERT [dbo].[Countries] ([CountryId], [CountryName], [CountryDescription], [ISDCode], [CreatedDate], [ModifiedDate], [Enabled]) VALUES (10, N'Australia', N'Australia', N'+61', CAST(N'2021-12-27T11:18:58.0710552' AS DateTime2), CAST(N'2021-12-27T11:18:58.0710559' AS DateTime2), 1)
INSERT [dbo].[Countries] ([CountryId], [CountryName], [CountryDescription], [ISDCode], [CreatedDate], [ModifiedDate], [Enabled]) VALUES (11, N'United States', N'U.S', N'+1', CAST(N'2021-12-27T11:19:41.1240381' AS DateTime2), CAST(N'2021-12-27T11:19:41.1240397' AS DateTime2), 1)
INSERT [dbo].[Countries] ([CountryId], [CountryName], [CountryDescription], [ISDCode], [CreatedDate], [ModifiedDate], [Enabled]) VALUES (12, N'United Kingdom', N'UK', N'+44', CAST(N'2021-12-27T11:20:00.5630032' AS DateTime2), CAST(N'2021-12-27T11:20:00.5630040' AS DateTime2), 1)
INSERT [dbo].[Countries] ([CountryId], [CountryName], [CountryDescription], [ISDCode], [CreatedDate], [ModifiedDate], [Enabled]) VALUES (13, N'Myanmar ', N'Burma', N'+95', CAST(N'2021-12-27T11:20:29.8314833' AS DateTime2), CAST(N'2021-12-27T11:20:29.8314837' AS DateTime2), 1)
INSERT [dbo].[Countries] ([CountryId], [CountryName], [CountryDescription], [ISDCode], [CreatedDate], [ModifiedDate], [Enabled]) VALUES (14, N'Gemany', N'Germany', N'+49', CAST(N'2021-12-27T11:20:50.7195377' AS DateTime2), CAST(N'2021-12-27T11:20:50.7195386' AS DateTime2), 1)
INSERT [dbo].[Countries] ([CountryId], [CountryName], [CountryDescription], [ISDCode], [CreatedDate], [ModifiedDate], [Enabled]) VALUES (15, N'Dubai', N'Dubai', N'+971', CAST(N'2021-12-27T11:21:11.4841449' AS DateTime2), CAST(N'2021-12-27T11:21:11.4841455' AS DateTime2), 1)
INSERT [dbo].[Countries] ([CountryId], [CountryName], [CountryDescription], [ISDCode], [CreatedDate], [ModifiedDate], [Enabled]) VALUES (16, N'Italy', N'Italy', N'+39', CAST(N'2021-12-27T11:21:39.4273906' AS DateTime2), CAST(N'2021-12-27T11:21:39.4273913' AS DateTime2), 1)
INSERT [dbo].[Countries] ([CountryId], [CountryName], [CountryDescription], [ISDCode], [CreatedDate], [ModifiedDate], [Enabled]) VALUES (17, N'Netherlands', N'Netherlands', N'+31', CAST(N'2021-12-27T11:22:04.9543202' AS DateTime2), CAST(N'2021-12-27T11:22:04.9543207' AS DateTime2), 1)
INSERT [dbo].[Countries] ([CountryId], [CountryName], [CountryDescription], [ISDCode], [CreatedDate], [ModifiedDate], [Enabled]) VALUES (18, N'Russia', N'Russia', N'+7', CAST(N'2021-12-27T11:22:31.9747470' AS DateTime2), CAST(N'2021-12-27T11:22:31.9747479' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[Countries] OFF
GO

