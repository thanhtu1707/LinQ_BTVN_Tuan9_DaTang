USE [DBGHIDANH]
GO
/****** Object:  Table [dbo].[GhiDanh]    Script Date: 05/07/2020 9:12:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GhiDanh](
	[maGhiDanh] [nvarchar](100) NOT NULL,
	[hoVaTen] [nvarchar](100) NULL,
	[ngaySinh] [date] NULL,
	[gioiTinh] [nvarchar](5) NULL,
	[dienThoai] [char](10) NULL,
	[email] [nvarchar](100) NULL,
	[maMonHoc] [nvarchar](100) NULL,
	[buoiHoc] [int] NULL,
	[thiXepLoai] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[maGhiDanh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MonHoc]    Script Date: 05/07/2020 9:12:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonHoc](
	[maMonHoc] [nvarchar](100) NOT NULL,
	[tenMonHoc] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[maMonHoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[GhiDanh] ([maGhiDanh], [hoVaTen], [ngaySinh], [gioiTinh], [dienThoai], [email], [maMonHoc], [buoiHoc], [thiXepLoai]) VALUES (N'ABC12345', N'Nguyễn Thị  Nhi', CAST(N'1999-07-17' AS Date), N'Nữ', N'0123456788', N'thinhi@gmail.com', N'MH002', 3, 1)
INSERT [dbo].[GhiDanh] ([maGhiDanh], [hoVaTen], [ngaySinh], [gioiTinh], [dienThoai], [email], [maMonHoc], [buoiHoc], [thiXepLoai]) VALUES (N'ABC23456', N'Trần A', CAST(N'1999-11-20' AS Date), N'Nam', N'0321456788', N'trana@gmail.com', N'MH004', 2, 1)
INSERT [dbo].[GhiDanh] ([maGhiDanh], [hoVaTen], [ngaySinh], [gioiTinh], [dienThoai], [email], [maMonHoc], [buoiHoc], [thiXepLoai]) VALUES (N'GD001', N'Nguyễn Thị Thanh Tú', CAST(N'1999-07-17' AS Date), N'Nữ', N'0764233325', N'thanhtu@gmail.com', N'MH001', 1, 1)
INSERT [dbo].[GhiDanh] ([maGhiDanh], [hoVaTen], [ngaySinh], [gioiTinh], [dienThoai], [email], [maMonHoc], [buoiHoc], [thiXepLoai]) VALUES (N'GD002', N'Quỳnh Như', CAST(N'1999-01-01' AS Date), N'Nữ', N'0123456789', N'quynhnhu@gmail.com', N'MH002', 2, 1)
INSERT [dbo].[GhiDanh] ([maGhiDanh], [hoVaTen], [ngaySinh], [gioiTinh], [dienThoai], [email], [maMonHoc], [buoiHoc], [thiXepLoai]) VALUES (N'GD003', N'Khánh Hà', CAST(N'1999-08-06' AS Date), N'Nữ', N'0542369715', N'khanhha@gmail.com', N'MH003', 3, 1)
INSERT [dbo].[MonHoc] ([maMonHoc], [tenMonHoc]) VALUES (N'MH001', N'Toán')
INSERT [dbo].[MonHoc] ([maMonHoc], [tenMonHoc]) VALUES (N'MH002', N'Anh Văn')
INSERT [dbo].[MonHoc] ([maMonHoc], [tenMonHoc]) VALUES (N'MH003', N'Ngữ Văn')
INSERT [dbo].[MonHoc] ([maMonHoc], [tenMonHoc]) VALUES (N'MH004', N'Hóa Học')
INSERT [dbo].[MonHoc] ([maMonHoc], [tenMonHoc]) VALUES (N'MH005', N'Vật lý')
ALTER TABLE [dbo].[GhiDanh]  WITH CHECK ADD  CONSTRAINT [fk_ghidanh_monhoc] FOREIGN KEY([maMonHoc])
REFERENCES [dbo].[MonHoc] ([maMonHoc])
GO
ALTER TABLE [dbo].[GhiDanh] CHECK CONSTRAINT [fk_ghidanh_monhoc]
GO
