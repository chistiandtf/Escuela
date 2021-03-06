USE [master]
GO
/****** Object:  Database [Escolar]    Script Date: 31-03-2021 11:27:50 a.m. ******/
CREATE DATABASE [Escolar]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'School', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\School.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'School_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\School_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Escolar] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Escolar].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Escolar] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Escolar] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Escolar] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Escolar] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Escolar] SET ARITHABORT OFF 
GO
ALTER DATABASE [Escolar] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Escolar] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Escolar] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Escolar] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Escolar] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Escolar] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Escolar] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Escolar] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Escolar] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Escolar] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Escolar] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Escolar] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Escolar] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Escolar] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Escolar] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Escolar] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Escolar] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Escolar] SET RECOVERY FULL 
GO
ALTER DATABASE [Escolar] SET  MULTI_USER 
GO
ALTER DATABASE [Escolar] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Escolar] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Escolar] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Escolar] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Escolar] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Escolar]
GO
/****** Object:  Table [dbo].[Calificaciones]    Script Date: 31-03-2021 11:27:51 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Calificaciones](
	[idcalificacion] [int] IDENTITY(1,1) NOT NULL,
	[Estudiante] [int] NOT NULL,
	[Periodo] [int] NOT NULL,
	[Materia] [int] NOT NULL,
	[Notas] [int] NOT NULL,
	[Grado] [int] NOT NULL,
 CONSTRAINT [PK_Calificaciones] PRIMARY KEY CLUSTERED 
(
	[idcalificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Clase]    Script Date: 31-03-2021 11:27:51 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clase](
	[idclase] [int] IDENTITY(1,1) NOT NULL,
	[Grado] [int] NOT NULL,
	[Materia] [nchar](10) NULL,
	[Periodo] [int] NOT NULL,
	[profesor] [int] NOT NULL,
	[Horario] [int] NOT NULL,
 CONSTRAINT [PK__clase__3213E83F5F2879A0] PRIMARY KEY CLUSTERED 
(
	[idclase] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Clasealumno]    Script Date: 31-03-2021 11:27:51 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clasealumno](
	[idEstudiante] [int] IDENTITY(1,1) NOT NULL,
	[Estudiante] [int] NOT NULL,
	[Clase] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idEstudiante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Estudiantes]    Script Date: 31-03-2021 11:27:51 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Estudiantes](
	[idEstudiante] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Cedula] [int] NOT NULL,
	[Fechanacimiento] [date] NOT NULL,
	[Representantes] [int] NOT NULL,
	[estado] [bit] NOT NULL,
	[fechaingreso] [date] NOT NULL,
	[fechaegreso] [date] NULL,
 CONSTRAINT [PK__Estudian__AEFFDBC53E1C0AC6] PRIMARY KEY CLUSTERED 
(
	[idEstudiante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Grado]    Script Date: 31-03-2021 11:27:51 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Grado](
	[idgrado] [int] IDENTITY(1,1) NOT NULL,
	[Grado] [varchar](50) NOT NULL,
 CONSTRAINT [PK__grado__3213E83FF364EF56] PRIMARY KEY CLUSTERED 
(
	[idgrado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[horario]    Script Date: 31-03-2021 11:27:51 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[horario](
	[idhorario] [int] IDENTITY(1,1) NOT NULL,
	[Diasemana] [varchar](50) NOT NULL,
	[Horainicio] [varchar](50) NOT NULL,
	[HoraFin] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idhorario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[InscripcionEstudiante]    Script Date: 31-03-2021 11:27:51 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InscripcionEstudiante](
	[idinscripcion] [int] NOT NULL,
	[Grado] [int] NOT NULL,
	[Periodo] [int] NOT NULL,
	[Estudiante] [int] NOT NULL,
	[Fecha] [date] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Materia]    Script Date: 31-03-2021 11:27:51 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Materia](
	[idmateria] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idmateria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Matricula]    Script Date: 31-03-2021 11:27:51 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Matricula](
	[idmatricula] [int] IDENTITY(1,1) NOT NULL,
	[Grado] [int] NOT NULL,
	[Periodo] [int] NOT NULL,
	[Estudiante] [int] NOT NULL,
 CONSTRAINT [PK_Matricula] PRIMARY KEY CLUSTERED 
(
	[idmatricula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Nota]    Script Date: 31-03-2021 11:27:51 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nota](
	[idnota] [int] IDENTITY(1,1) NOT NULL,
	[nota1] [decimal](4, 2) NOT NULL,
	[nota2] [decimal](4, 2) NOT NULL,
	[nota3] [decimal](4, 2) NOT NULL,
	[notafinal] [decimal](4, 2) NOT NULL,
 CONSTRAINT [PK_Nota] PRIMARY KEY CLUSTERED 
(
	[idnota] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Periodo]    Script Date: 31-03-2021 11:27:51 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Periodo](
	[Idperiodo] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[Estado] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Idperiodo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Profesor]    Script Date: 31-03-2021 11:27:51 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Profesor](
	[idProfesor] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Cedula] [int] NOT NULL,
	[Fechanacimiento] [date] NOT NULL,
	[Celular] [varchar](50) NULL,
	[Fechaingreso] [date] NOT NULL,
	[Fechaegreso] [date] NULL,
	[Descripcion] [varchar](50) NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK__profesor__3213E83F6862E79A] PRIMARY KEY CLUSTERED 
(
	[idProfesor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Representantes]    Script Date: 31-03-2021 11:27:51 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Representantes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Nombremadre] [varchar](50) NOT NULL,
	[Apellidomadre] [varchar](50) NOT NULL,
	[Nombrepadre] [varchar](50) NOT NULL,
	[Apellidopadre] [varchar](50) NOT NULL,
	[Celular] [varchar](50) NULL,
	[telefono] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Grado] ON 

INSERT [dbo].[Grado] ([idgrado], [Grado]) VALUES (1, N'4to grado')
SET IDENTITY_INSERT [dbo].[Grado] OFF
SET IDENTITY_INSERT [dbo].[Materia] ON 

INSERT [dbo].[Materia] ([idmateria], [Nombre]) VALUES (1, N'Biologia')
INSERT [dbo].[Materia] ([idmateria], [Nombre]) VALUES (2, N'Artistica')
INSERT [dbo].[Materia] ([idmateria], [Nombre]) VALUES (3, N'Dibujo')
SET IDENTITY_INSERT [dbo].[Materia] OFF
SET IDENTITY_INSERT [dbo].[Profesor] ON 

INSERT [dbo].[Profesor] ([idProfesor], [Nombre], [Apellido], [Cedula], [Fechanacimiento], [Celular], [Fechaingreso], [Fechaegreso], [Descripcion], [Estado]) VALUES (1, N'Juan', N'Chacon', 234234, CAST(N'2001-03-17' AS Date), N'34234', CAST(N'2021-04-16' AS Date), NULL, N'Profesor Sistemas informacion gerencial', 1)
SET IDENTITY_INSERT [dbo].[Profesor] OFF
ALTER TABLE [dbo].[Calificaciones]  WITH CHECK ADD  CONSTRAINT [FK_Calificaciones_Estudiantes] FOREIGN KEY([Estudiante])
REFERENCES [dbo].[Estudiantes] ([idEstudiante])
GO
ALTER TABLE [dbo].[Calificaciones] CHECK CONSTRAINT [FK_Calificaciones_Estudiantes]
GO
ALTER TABLE [dbo].[Calificaciones]  WITH CHECK ADD  CONSTRAINT [FK_Calificaciones_grado] FOREIGN KEY([Grado])
REFERENCES [dbo].[Grado] ([idgrado])
GO
ALTER TABLE [dbo].[Calificaciones] CHECK CONSTRAINT [FK_Calificaciones_grado]
GO
ALTER TABLE [dbo].[Calificaciones]  WITH CHECK ADD  CONSTRAINT [FK_Calificaciones_Materia] FOREIGN KEY([Materia])
REFERENCES [dbo].[Materia] ([idmateria])
GO
ALTER TABLE [dbo].[Calificaciones] CHECK CONSTRAINT [FK_Calificaciones_Materia]
GO
ALTER TABLE [dbo].[Calificaciones]  WITH CHECK ADD  CONSTRAINT [FK_Calificaciones_Nota] FOREIGN KEY([Notas])
REFERENCES [dbo].[Nota] ([idnota])
GO
ALTER TABLE [dbo].[Calificaciones] CHECK CONSTRAINT [FK_Calificaciones_Nota]
GO
ALTER TABLE [dbo].[Calificaciones]  WITH CHECK ADD  CONSTRAINT [FK_Calificaciones_periodo] FOREIGN KEY([Periodo])
REFERENCES [dbo].[Periodo] ([Idperiodo])
GO
ALTER TABLE [dbo].[Calificaciones] CHECK CONSTRAINT [FK_Calificaciones_periodo]
GO
ALTER TABLE [dbo].[Clase]  WITH CHECK ADD  CONSTRAINT [FK_clase_grado] FOREIGN KEY([Grado])
REFERENCES [dbo].[Grado] ([idgrado])
GO
ALTER TABLE [dbo].[Clase] CHECK CONSTRAINT [FK_clase_grado]
GO
ALTER TABLE [dbo].[Clase]  WITH CHECK ADD  CONSTRAINT [FK_clase_horario] FOREIGN KEY([Horario])
REFERENCES [dbo].[horario] ([idhorario])
GO
ALTER TABLE [dbo].[Clase] CHECK CONSTRAINT [FK_clase_horario]
GO
ALTER TABLE [dbo].[Clase]  WITH CHECK ADD  CONSTRAINT [FK_clase_Materia] FOREIGN KEY([Periodo])
REFERENCES [dbo].[Materia] ([idmateria])
GO
ALTER TABLE [dbo].[Clase] CHECK CONSTRAINT [FK_clase_Materia]
GO
ALTER TABLE [dbo].[Clase]  WITH CHECK ADD  CONSTRAINT [FK_clase_periodo] FOREIGN KEY([Periodo])
REFERENCES [dbo].[Periodo] ([Idperiodo])
GO
ALTER TABLE [dbo].[Clase] CHECK CONSTRAINT [FK_clase_periodo]
GO
ALTER TABLE [dbo].[Clase]  WITH CHECK ADD  CONSTRAINT [FK_clase_profesor] FOREIGN KEY([profesor])
REFERENCES [dbo].[Profesor] ([idProfesor])
GO
ALTER TABLE [dbo].[Clase] CHECK CONSTRAINT [FK_clase_profesor]
GO
ALTER TABLE [dbo].[Clasealumno]  WITH CHECK ADD  CONSTRAINT [FK_clasealumno_clase] FOREIGN KEY([Clase])
REFERENCES [dbo].[Clase] ([idclase])
GO
ALTER TABLE [dbo].[Clasealumno] CHECK CONSTRAINT [FK_clasealumno_clase]
GO
ALTER TABLE [dbo].[Clasealumno]  WITH CHECK ADD  CONSTRAINT [FK_clasealumno_Estudiantes] FOREIGN KEY([Estudiante])
REFERENCES [dbo].[Estudiantes] ([idEstudiante])
GO
ALTER TABLE [dbo].[Clasealumno] CHECK CONSTRAINT [FK_clasealumno_Estudiantes]
GO
ALTER TABLE [dbo].[Estudiantes]  WITH CHECK ADD  CONSTRAINT [FK_Estudiantes_Representantes] FOREIGN KEY([Representantes])
REFERENCES [dbo].[Representantes] ([id])
GO
ALTER TABLE [dbo].[Estudiantes] CHECK CONSTRAINT [FK_Estudiantes_Representantes]
GO
ALTER TABLE [dbo].[InscripcionEstudiante]  WITH CHECK ADD  CONSTRAINT [FK_inscripcionEstudiante_Estudiantes] FOREIGN KEY([Estudiante])
REFERENCES [dbo].[Estudiantes] ([idEstudiante])
GO
ALTER TABLE [dbo].[InscripcionEstudiante] CHECK CONSTRAINT [FK_inscripcionEstudiante_Estudiantes]
GO
ALTER TABLE [dbo].[InscripcionEstudiante]  WITH CHECK ADD  CONSTRAINT [FK_inscripcionEstudiante_grado] FOREIGN KEY([Grado])
REFERENCES [dbo].[Grado] ([idgrado])
GO
ALTER TABLE [dbo].[InscripcionEstudiante] CHECK CONSTRAINT [FK_inscripcionEstudiante_grado]
GO
ALTER TABLE [dbo].[InscripcionEstudiante]  WITH CHECK ADD  CONSTRAINT [FK_inscripcionEstudiante_periodo] FOREIGN KEY([Periodo])
REFERENCES [dbo].[Periodo] ([Idperiodo])
GO
ALTER TABLE [dbo].[InscripcionEstudiante] CHECK CONSTRAINT [FK_inscripcionEstudiante_periodo]
GO
ALTER TABLE [dbo].[Matricula]  WITH CHECK ADD  CONSTRAINT [FK_Matricula_Estudiantes] FOREIGN KEY([Estudiante])
REFERENCES [dbo].[Estudiantes] ([idEstudiante])
GO
ALTER TABLE [dbo].[Matricula] CHECK CONSTRAINT [FK_Matricula_Estudiantes]
GO
ALTER TABLE [dbo].[Matricula]  WITH CHECK ADD  CONSTRAINT [FK_Matricula_grado] FOREIGN KEY([Grado])
REFERENCES [dbo].[Grado] ([idgrado])
GO
ALTER TABLE [dbo].[Matricula] CHECK CONSTRAINT [FK_Matricula_grado]
GO
ALTER TABLE [dbo].[Matricula]  WITH CHECK ADD  CONSTRAINT [FK_Matricula_periodo] FOREIGN KEY([Periodo])
REFERENCES [dbo].[Periodo] ([Idperiodo])
GO
ALTER TABLE [dbo].[Matricula] CHECK CONSTRAINT [FK_Matricula_periodo]
GO
USE [master]
GO
ALTER DATABASE [Escolar] SET  READ_WRITE 
GO
