USE [master]
GO
/****** Object:  Database [NGEcommerce_v2]    Script Date: 12/17/2021 3:30:11 PM ******/
CREATE DATABASE [NGEcommerce_v2]

GO
ALTER DATABASE [NGEcommerce_v2] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NGEcommerce_v2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NGEcommerce_v2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NGEcommerce_v2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NGEcommerce_v2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NGEcommerce_v2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NGEcommerce_v2] SET ARITHABORT OFF 
GO
ALTER DATABASE [NGEcommerce_v2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NGEcommerce_v2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NGEcommerce_v2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NGEcommerce_v2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NGEcommerce_v2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NGEcommerce_v2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NGEcommerce_v2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NGEcommerce_v2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NGEcommerce_v2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NGEcommerce_v2] SET  ENABLE_BROKER 
GO
ALTER DATABASE [NGEcommerce_v2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NGEcommerce_v2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NGEcommerce_v2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NGEcommerce_v2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NGEcommerce_v2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NGEcommerce_v2] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [NGEcommerce_v2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NGEcommerce_v2] SET RECOVERY FULL 
GO
ALTER DATABASE [NGEcommerce_v2] SET  MULTI_USER 
GO
ALTER DATABASE [NGEcommerce_v2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NGEcommerce_v2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NGEcommerce_v2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NGEcommerce_v2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [NGEcommerce_v2] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [NGEcommerce_v2] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'NGEcommerce_v2', N'ON'
GO
ALTER DATABASE [NGEcommerce_v2] SET QUERY_STORE = OFF
GO
USE [NGEcommerce_v2]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 12/17/2021 3:30:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 12/17/2021 3:30:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 12/17/2021 3:30:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 12/17/2021 3:30:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 12/17/2021 3:30:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 12/17/2021 3:30:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [uniqueidentifier] NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 12/17/2021 3:30:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [uniqueidentifier] NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerOrder]    Script Date: 12/17/2021 3:30:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerOrder](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[TotalCost] [decimal](13, 2) NOT NULL,
	[Createdby] [nchar](255) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[LastModifiedBy] [nchar](255) NULL,
	[DateLastModified] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerOrderDetail]    Script Date: 12/17/2021 3:30:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerOrderDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerOrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [decimal](13, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmailLog]    Script Date: 12/17/2021 3:30:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmailLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmailTo] [nchar](255) NULL,
	[EmailCC] [nvarchar](max) NULL,
	[EmailStatus] [int] NOT NULL,
	[EmailContent] [nvarchar](max) NULL,
	[ExceptionIssue] [nvarchar](max) NULL,
	[Createdby] [nchar](255) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[LastModifiedBy] [nchar](255) NULL,
	[DateLastModified] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmailTemplate]    Script Date: 12/17/2021 3:30:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmailTemplate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TemplateType] [int] NOT NULL,
	[Name] [nchar](255) NOT NULL,
	[Description] [nchar](255) NULL,
	[Subject] [nvarchar](max) NULL,
	[EmailBody] [nvarchar](max) NULL,
	[Createdby] [nchar](255) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[LastModifiedBy] [nchar](255) NULL,
	[DateLastModified] [datetime] NULL,
	[PurchasedItems] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 12/17/2021 3:30:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductTags] [nchar](255) NULL,
	[ProductCategoryId] [int] NULL,
	[Name] [nchar](255) NOT NULL,
	[Description] [nchar](255) NULL,
	[ImageUrl] [nchar](255) NULL,
	[PricePerItem] [decimal](13, 2) NOT NULL,
	[Quantity] [decimal](13, 2) NOT NULL,
	[Createdby] [nchar](255) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[LastModifiedBy] [nchar](255) NULL,
	[DateLastModified] [datetime] NULL,
 CONSTRAINT [PK__Product__3214EC0760944A30] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 12/17/2021 3:30:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](255) NOT NULL,
	[Description] [nchar](255) NULL,
	[Createdby] [nchar](255) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[LastModifiedBy] [nchar](255) NULL,
	[DateLastModified] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductTag]    Script Date: 12/17/2021 3:30:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductTag](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](255) NOT NULL,
	[Description] [nchar](255) NULL,
	[Createdby] [nchar](255) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[LastModifiedBy] [nchar](255) NULL,
	[DateLastModified] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemParameters]    Script Date: 12/17/2021 3:30:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemParameters](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ParameterName] [nvarchar](250) NOT NULL,
	[ParameterValue] [nvarchar](max) NOT NULL,
	[ParameterType] [nvarchar](max) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[LastModifiedBy] [nvarchar](max) NULL,
	[DateLastModified] [datetime2](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'd643d2f9-4872-4c9e-ca84-08d9bcf202ba', N'Admin', N'ADMIN', N'12/12/2021 1:03:00 AM')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'aef20b8c-f308-49bc-ca85-08d9bcf202ba', N'BasicUser', N'BASICUSER', N'12/12/2021 1:03:02 AM')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4a28083d-a71b-4a58-6ad3-08d9bcf2062c', N'd643d2f9-4872-4c9e-ca84-08d9bcf202ba')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'4a28083d-a71b-4a58-6ad3-08d9bcf2062c', N'kibuika@gmail.com', N'KIBUIKA@GMAIL.COM', N'kibuika@gmail.com', N'KIBUIKA@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEFW5sAPORCfveB8mNCBayRQj/fHgaB/Yukmhx667J8OXua9JwyJIGCt5I4RXuUpkXA==', N'KTOXFX6AS3CHTUC3QYYZDNNAHTQOUWF3', N'7071f72f-cff8-493a-8f38-cf313e23617f', NULL, 0, 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[EmailTemplate] ON 
GO
INSERT [dbo].[EmailTemplate] ([Id], [TemplateType], [Name], [Description], [Subject], [EmailBody], [Createdby], [DateCreated], [LastModifiedBy], [DateLastModified], [PurchasedItems]) VALUES (3, 0, N'Register                                                                                                                                                                                                                                                       ', N'Register                                                                                                                                                                                                                                                       ', N'Thank You For Joining Us', N'
Thank you for registering please click the link below to activate your account.
You can only use the account after confirmation.

Thanks,
NG-Ecommerce', N'Admin                                                                                                                                                                                                                                                          ', CAST(N'2021-12-12T00:00:00.000' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[EmailTemplate] ([Id], [TemplateType], [Name], [Description], [Subject], [EmailBody], [Createdby], [DateCreated], [LastModifiedBy], [DateLastModified], [PurchasedItems]) VALUES (6, 1, N'Forgot Password                                                                                                                                                                                                                                                ', N'Forgot Password                                                                                                                                                                                                                                                ', N'Password Reset', N'Your password has been reset. Please use the below password to login.', N'Admin                                                                                                                                                                                                                                                          ', CAST(N'2021-12-12T00:00:00.000' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[EmailTemplate] ([Id], [TemplateType], [Name], [Description], [Subject], [EmailBody], [Createdby], [DateCreated], [LastModifiedBy], [DateLastModified], [PurchasedItems]) VALUES (7, 2, N'CheckOut                                                                                                                                                                                                                                                       ', NULL, N'Order #', N'<h2 style="text-align: left;"><strong>Order #: @@ORDERNUMBER@@ &nbsp; &nbsp;Date: @@ORDERDATE@@ </strong></h2>
<table style="border-collapse: collapse; height: 36px;" width="430">
<tbody>
<tr style="height: 18px;">
<td style="width: 140px; height: 18px;"><strong>Name</strong></td>
<td style="width: 140px; height: 18px;"><strong>Quantity</strong></td>
<td style="width: 140px; height: 18px;"><strong>Price&nbsp;</strong></td>
</tr>
@@PURCHASEDITEMS@@
</tbody>
</table>
<p><span style="text-decoration: underline;"><strong>Total Cost : $ @@TOTALCOST@@ </strong></span></p>
<p><span style="text-decoration: underline;"><strong>Thank you.</strong></span></p>
<p><span style="text-decoration: underline;"><strong>NG-eCommerce.</strong></span></p>', N'Admin                                                                                                                                                                                                                                                          ', CAST(N'2021-12-12T00:00:00.000' AS DateTime), NULL, NULL, N'<tr style="height: 18px;">
<td style="width: 140px; height: 18px;">{0}</td>
<td style="width: 140px; height: 18px;">{1}</td>
<td style="width: 140px; height: 18px;">{2}</td>
</tr>')
GO
INSERT [dbo].[EmailTemplate] ([Id], [TemplateType], [Name], [Description], [Subject], [EmailBody], [Createdby], [DateCreated], [LastModifiedBy], [DateLastModified], [PurchasedItems]) VALUES (9, 3, N'Promotion                                                                                                                                                                                                                                                      ', NULL, N'Mega Deals', N'Hello Please see the mega deals we have at the moment', N'Admin                                                                                                                                                                                                                                                          ', CAST(N'2021-12-12T00:00:00.000' AS DateTime), NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[EmailTemplate] OFF
GO
SET IDENTITY_INSERT [dbo].[SystemParameters] ON 
GO
INSERT [dbo].[SystemParameters] ([Id], [ParameterName], [ParameterValue], [ParameterType], [CreatedBy], [DateCreated], [LastModifiedBy], [DateLastModified]) VALUES (1, N'emailsmtpAddress', N'smtp.gmail.com', N'Email', N'2020-12-31 00:00:00.000', CAST(N'2021-01-07T07:31:22.0300000' AS DateTime2), NULL, NULL)
GO
INSERT [dbo].[SystemParameters] ([Id], [ParameterName], [ParameterValue], [ParameterType], [CreatedBy], [DateCreated], [LastModifiedBy], [DateLastModified]) VALUES (2, N'emailportNumber', N'587', N'Email', N'2020-12-31 00:00:00.000', CAST(N'2021-01-07T07:31:22.3430000' AS DateTime2), NULL, NULL)
GO
INSERT [dbo].[SystemParameters] ([Id], [ParameterName], [ParameterValue], [ParameterType], [CreatedBy], [DateCreated], [LastModifiedBy], [DateLastModified]) VALUES (3, N'emailpassword', N'udrdapugrluyhlxo', N'Email', N'2020-12-31 00:00:00.000', CAST(N'2021-01-07T07:31:22.5570000' AS DateTime2), NULL, NULL)
GO
INSERT [dbo].[SystemParameters] ([Id], [ParameterName], [ParameterValue], [ParameterType], [CreatedBy], [DateCreated], [LastModifiedBy], [DateLastModified]) VALUES (4, N'emailenableSSl', N'true', N'Email', N'2020-12-31 00:00:00.000', CAST(N'2021-01-07T07:31:22.7230000' AS DateTime2), NULL, NULL)
GO
INSERT [dbo].[SystemParameters] ([Id], [ParameterName], [ParameterValue], [ParameterType], [CreatedBy], [DateCreated], [LastModifiedBy], [DateLastModified]) VALUES (5, N'emailSender', N'zookepersystems@gmail.com', N'Email', N'2020-12-31 00:00:00.000', CAST(N'2021-01-07T07:31:22.7230000' AS DateTime2), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[SystemParameters] OFF
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 12/17/2021 3:30:11 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 12/17/2021 3:30:11 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 12/17/2021 3:30:11 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 12/17/2021 3:30:11 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 12/17/2021 3:30:11 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 12/17/2021 3:30:11 PM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 12/17/2021 3:30:11 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[CustomerOrder]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[CustomerOrderDetail]  WITH CHECK ADD FOREIGN KEY([CustomerOrderId])
REFERENCES [dbo].[CustomerOrder] ([Id])
GO
ALTER TABLE [dbo].[CustomerOrderDetail]  WITH CHECK ADD  CONSTRAINT [FK__CustomerO__Produ__5BE2A6F2] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[CustomerOrderDetail] CHECK CONSTRAINT [FK__CustomerO__Produ__5BE2A6F2]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK__Product__Product__5165187F] FOREIGN KEY([ProductCategoryId])
REFERENCES [dbo].[ProductCategory] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK__Product__Product__5165187F]
GO
USE [master]
GO
ALTER DATABASE [NGEcommerce_v2] SET  READ_WRITE 
GO
