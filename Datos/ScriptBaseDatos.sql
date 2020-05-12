CREATE DATABASE [Evaluaciones];
USE  [Evaluaciones]

CREATE TABLE [dbo].[Restaurantes](
    [IDueño] [nvarchar] (10)  NULL,
	[NombreRestaurante] [nvarchar](50) NULL,
	[Direccion] [nvarchar](20) NULL,
	[Evaluacion] [nvarchar] (15)NULL,
	[Estado] [nvarchar] (15)NULL,
	[Nit] [nvarchar](30) NOT NULL PRIMARY KEY,
	CONSTRAINT fk_Dueño FOREIGN KEY (IDueño) REFERENCES Dueños (ID)
) 
GO
CREATE TABLE [dbo].[Dueños](	
	[Nombre] [nvarchar](30)  NULL,
	[Apellido] [nvarchar](30)  NULL,
    [ID] [nvarchar] (10) NOT NULL PRIMARY KEY,

) 

COMMIT