USE [ef_skoleni]
GO
SET IDENTITY_INSERT [dbo].[Brands] ON 

INSERT [dbo].[Brands] ([BrandId], [BrandIdentifier], [Title], [LastUpdated]) VALUES (2, N'apple', N'Apple', CAST(N'2018-05-20T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Brands] ([BrandId], [BrandIdentifier], [Title], [LastUpdated]) VALUES (3, N'samsung', N'Samsung', CAST(N'2018-05-21T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Brands] ([BrandId], [BrandIdentifier], [Title], [LastUpdated]) VALUES (4, N'nokia', N'Nokia', CAST(N'2018-05-20T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Brands] ([BrandId], [BrandIdentifier], [Title], [LastUpdated]) VALUES (5, N'sony', N'Sony', CAST(N'2018-05-19T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Brands] ([BrandId], [BrandIdentifier], [Title], [LastUpdated]) VALUES (6, N'huawei', N'Huawei', CAST(N'2018-05-20T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Brands] ([BrandId], [BrandIdentifier], [Title], [LastUpdated]) VALUES (7, N'xiaomi', N'Xiaomi', CAST(N'2018-05-20T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Brands] ([BrandId], [BrandIdentifier], [Title], [LastUpdated]) VALUES (8, N'honor', N'Honor', CAST(N'2018-05-17T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Brands] OFF
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductId], [BrandIdentifier], [Title], [SeoLink], [Price_BasePrice], [Price_VatRate], [ProductType], [RssDescritpion]) VALUES (7, N'samsung', N'Samsung Galaxy S7 Edge - 32GB', N'samsung-galaxy-s7-edge-32-gb', CAST(14990.00 AS Decimal(10, 2)), CAST(0.210 AS Decimal(4, 3)), 0, NULL)
INSERT [dbo].[Products] ([ProductId], [BrandIdentifier], [Title], [SeoLink], [Price_BasePrice], [Price_VatRate], [ProductType], [RssDescritpion]) VALUES (8, N'apple', N'Apple IPhone 7 - 128GB', N'apple-iphone-7-128-gb', CAST(17690.00 AS Decimal(10, 2)), CAST(0.210 AS Decimal(4, 3)), 0, NULL)
INSERT [dbo].[Products] ([ProductId], [BrandIdentifier], [Title], [SeoLink], [Price_BasePrice], [Price_VatRate], [ProductType], [RssDescritpion]) VALUES (11, N'huawei', N'Huawei Y7 Prime 2018', N'huawei-y7-prime-2018', CAST(4898.00 AS Decimal(10, 2)), CAST(0.210 AS Decimal(4, 3)), 0, NULL)
INSERT [dbo].[Products] ([ProductId], [BrandIdentifier], [Title], [SeoLink], [Price_BasePrice], [Price_VatRate], [ProductType], [RssDescritpion]) VALUES (12, N'huawei', N'Huawei Y6 2017, Dual SIM', N'huawei-y6-2017', CAST(3201.00 AS Decimal(10, 2)), CAST(0.210 AS Decimal(4, 3)), 0, NULL)
INSERT [dbo].[Products] ([ProductId], [BrandIdentifier], [Title], [SeoLink], [Price_BasePrice], [Price_VatRate], [ProductType], [RssDescritpion]) VALUES (13, N'nokia', N'Nokia 6 2018', N'nokia-6-2018', CAST(6999.00 AS Decimal(10, 2)), CAST(0.210 AS Decimal(4, 3)), 0, NULL)
INSERT [dbo].[Products] ([ProductId], [BrandIdentifier], [Title], [SeoLink], [Price_BasePrice], [Price_VatRate], [ProductType], [RssDescritpion]) VALUES (14, N'nokia', N'Nokia 7 Plus', N'nokia-7-plus', CAST(9999.00 AS Decimal(10, 2)), CAST(0.210 AS Decimal(4, 3)), 0, NULL)
INSERT [dbo].[Products] ([ProductId], [BrandIdentifier], [Title], [SeoLink], [Price_BasePrice], [Price_VatRate], [ProductType], [RssDescritpion]) VALUES (15, N'nokia', N'Nokia 3310', N'nokia-3310', CAST(1599.00 AS Decimal(10, 2)), CAST(0.210 AS Decimal(4, 3)), 0, NULL)
INSERT [dbo].[Products] ([ProductId], [BrandIdentifier], [Title], [SeoLink], [Price_BasePrice], [Price_VatRate], [ProductType], [RssDescritpion]) VALUES (16, N'samsung', N'Samsung Galaxy S8 64GB', N'samsung-galaxy-s8-65-gb', CAST(17991.00 AS Decimal(10, 2)), CAST(0.210 AS Decimal(4, 3)), 0, NULL)
INSERT [dbo].[Products] ([ProductId], [BrandIdentifier], [Title], [SeoLink], [Price_BasePrice], [Price_VatRate], [ProductType], [RssDescritpion]) VALUES (17, N'apple', N'Apple iPhone X, 64GB', N'apple-iphone-x-64-gb', CAST(29989.00 AS Decimal(10, 2)), CAST(0.210 AS Decimal(4, 3)), 0, NULL)
SET IDENTITY_INSERT [dbo].[Products] OFF
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryId], [Title], [SeoLink], [Extras], [Url]) VALUES (1, N'Dotykové', N'dotykove', NULL, N'/tel/dotykove')
INSERT [dbo].[Categories] ([CategoryId], [Title], [SeoLink], [Extras], [Url]) VALUES (2, N'Dual SIM', N'dual-sim', NULL, N'/tel/dual')
INSERT [dbo].[Categories] ([CategoryId], [Title], [SeoLink], [Extras], [Url]) VALUES (3, N'Odolné', N'odolne', NULL, N'/tel/odolne')
INSERT [dbo].[Categories] ([CategoryId], [Title], [SeoLink], [Extras], [Url]) VALUES (4, N'Klasické', N'klasicke', NULL, N'/tel/klasicke')
INSERT [dbo].[Categories] ([CategoryId], [Title], [SeoLink], [Extras], [Url]) VALUES (5, N'Pro seniory', N'pro-seniory', NULL, N'/tel/senior')
SET IDENTITY_INSERT [dbo].[Categories] OFF
INSERT [dbo].[ProductCategories] ([ProductId], [CategoryId]) VALUES (7, 1)
INSERT [dbo].[ProductCategories] ([ProductId], [CategoryId]) VALUES (8, 1)
INSERT [dbo].[ProductCategories] ([ProductId], [CategoryId]) VALUES (11, 1)
INSERT [dbo].[ProductCategories] ([ProductId], [CategoryId]) VALUES (12, 1)
INSERT [dbo].[ProductCategories] ([ProductId], [CategoryId]) VALUES (13, 1)
INSERT [dbo].[ProductCategories] ([ProductId], [CategoryId]) VALUES (14, 1)
INSERT [dbo].[ProductCategories] ([ProductId], [CategoryId]) VALUES (16, 1)
INSERT [dbo].[ProductCategories] ([ProductId], [CategoryId]) VALUES (17, 1)
INSERT [dbo].[ProductCategories] ([ProductId], [CategoryId]) VALUES (12, 2)
INSERT [dbo].[ProductCategories] ([ProductId], [CategoryId]) VALUES (15, 4)
INSERT [dbo].[ProductCategories] ([ProductId], [CategoryId]) VALUES (15, 5)
SET IDENTITY_INSERT [dbo].[Images] ON 

INSERT [dbo].[Images] ([ImageId], [ProductId], [Title], [Url]) VALUES (2, 17, N'iPhone X', N'https://iczc.cz/6n840grc64h2ab3qh9252utus8_1/obrazek')
INSERT [dbo].[Images] ([ImageId], [ProductId], [Title], [Url]) VALUES (3, 16, N'Samsung Galaxy S8', N'https://iczc.cz/5ihkii1be8gimar4rdguhpbkp5_1/obrazek')
INSERT [dbo].[Images] ([ImageId], [ProductId], [Title], [Url]) VALUES (4, 15, N'Nokia 3310', N'https://iczc.cz/4qt4t7vvaoiigbq6m31oj3b71f_1/obrazek')
SET IDENTITY_INSERT [dbo].[Images] OFF
INSERT [dbo].[Persons] ([DepartmentIdentifier], [DepartmentEmployeeIdentifier]) VALUES (1000, 5000001)
INSERT [dbo].[Persons] ([DepartmentIdentifier], [DepartmentEmployeeIdentifier]) VALUES (3000, 5000001)
INSERT [dbo].[Persons] ([DepartmentIdentifier], [DepartmentEmployeeIdentifier]) VALUES (1000, 5000002)
INSERT [dbo].[Persons] ([DepartmentIdentifier], [DepartmentEmployeeIdentifier]) VALUES (1000, 5000003)
INSERT [dbo].[Persons] ([DepartmentIdentifier], [DepartmentEmployeeIdentifier]) VALUES (1000, 5000004)
