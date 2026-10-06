CREATE TABLE dbo.Tareas (
    Id            INT IDENTITY(1,1) PRIMARY KEY,
    Titulo        NVARCHAR(100) NOT NULL,
    Descripcion   NVARCHAR(500) NULL,
    Estado        NVARCHAR(20)  NOT NULL DEFAULT 'Pendiente',
    FechaCreacion DATETIME      NOT NULL DEFAULT GETDATE(),
    CONSTRAINT CK_Tareas_Estado CHECK (Estado IN ('Pendiente','Completada'))
);
