
USE solar
GO
 IF NOT EXISTS(SELECT * FROM sys.schemas WHERE [name] = N'solar')      
     EXEC (N'CREATE SCHEMA solar')                                   
 GO                                                               

USE solar
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'alerta'  AND sc.name = N'solar'  AND type in (N'U'))
BEGIN

  DECLARE @drop_statement nvarchar(500)

  DECLARE drop_cursor CURSOR FOR
      SELECT 'alter table '+quotename(schema_name(ob.schema_id))+
      '.'+quotename(object_name(ob.object_id))+ ' drop constraint ' + quotename(fk.name) 
      FROM sys.objects ob INNER JOIN sys.foreign_keys fk ON fk.parent_object_id = ob.object_id
      WHERE fk.referenced_object_id = 
          (
             SELECT so.object_id 
             FROM sys.objects so JOIN sys.schemas sc
             ON so.schema_id = sc.schema_id
             WHERE so.name = N'alerta'  AND sc.name = N'solar'  AND type in (N'U')
           )

  OPEN drop_cursor

  FETCH NEXT FROM drop_cursor
  INTO @drop_statement

  WHILE @@FETCH_STATUS = 0
  BEGIN
     EXEC (@drop_statement)

     FETCH NEXT FROM drop_cursor
     INTO @drop_statement
  END

  CLOSE drop_cursor
  DEALLOCATE drop_cursor

  DROP TABLE [solar].[alerta]
END 
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE 
[solar].[alerta]
(
   [idAlerta] int  NOT NULL,
   [dataHora] datetime2(0)  NOT NULL,
   [descricao] nvarchar(max)  NOT NULL,
   [sugestoes] nvarchar(max)  NOT NULL,
   [TIPO] int  NOT NULL
)
WITH (DATA_COMPRESSION = NONE)
GO
BEGIN TRY
    EXEC sp_addextendedproperty
        N'MS_SSMA_SOURCE', N'solar.alerta',
        N'SCHEMA', N'solar',
        N'TABLE', N'alerta'
END TRY
BEGIN CATCH
    IF (@@TRANCOUNT > 0) ROLLBACK
    PRINT ERROR_MESSAGE()
END CATCH
GO

USE solar
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'alertasutilizador'  AND sc.name = N'solar'  AND type in (N'U'))
BEGIN

  DECLARE @drop_statement nvarchar(500)

  DECLARE drop_cursor CURSOR FOR
      SELECT 'alter table '+quotename(schema_name(ob.schema_id))+
      '.'+quotename(object_name(ob.object_id))+ ' drop constraint ' + quotename(fk.name) 
      FROM sys.objects ob INNER JOIN sys.foreign_keys fk ON fk.parent_object_id = ob.object_id
      WHERE fk.referenced_object_id = 
          (
             SELECT so.object_id 
             FROM sys.objects so JOIN sys.schemas sc
             ON so.schema_id = sc.schema_id
             WHERE so.name = N'alertasutilizador'  AND sc.name = N'solar'  AND type in (N'U')
           )

  OPEN drop_cursor

  FETCH NEXT FROM drop_cursor
  INTO @drop_statement

  WHILE @@FETCH_STATUS = 0
  BEGIN
     EXEC (@drop_statement)

     FETCH NEXT FROM drop_cursor
     INTO @drop_statement
  END

  CLOSE drop_cursor
  DEALLOCATE drop_cursor

  DROP TABLE [solar].[alertasutilizador]
END 
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE 
[solar].[alertasutilizador]
(
   [Tipo] int  NOT NULL,
   [Utilizador_username] nvarchar(45)  NOT NULL
)
WITH (DATA_COMPRESSION = NONE)
GO
BEGIN TRY
    EXEC sp_addextendedproperty
        N'MS_SSMA_SOURCE', N'solar.alertasutilizador',
        N'SCHEMA', N'solar',
        N'TABLE', N'alertasutilizador'
END TRY
BEGIN CATCH
    IF (@@TRANCOUNT > 0) ROLLBACK
    PRINT ERROR_MESSAGE()
END CATCH
GO

USE solar
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'avaria'  AND sc.name = N'solar'  AND type in (N'U'))
BEGIN

  DECLARE @drop_statement nvarchar(500)

  DECLARE drop_cursor CURSOR FOR
      SELECT 'alter table '+quotename(schema_name(ob.schema_id))+
      '.'+quotename(object_name(ob.object_id))+ ' drop constraint ' + quotename(fk.name) 
      FROM sys.objects ob INNER JOIN sys.foreign_keys fk ON fk.parent_object_id = ob.object_id
      WHERE fk.referenced_object_id = 
          (
             SELECT so.object_id 
             FROM sys.objects so JOIN sys.schemas sc
             ON so.schema_id = sc.schema_id
             WHERE so.name = N'avaria'  AND sc.name = N'solar'  AND type in (N'U')
           )

  OPEN drop_cursor

  FETCH NEXT FROM drop_cursor
  INTO @drop_statement

  WHILE @@FETCH_STATUS = 0
  BEGIN
     EXEC (@drop_statement)

     FETCH NEXT FROM drop_cursor
     INTO @drop_statement
  END

  CLOSE drop_cursor
  DEALLOCATE drop_cursor

  DROP TABLE [solar].[avaria]
END 
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE 
[solar].[avaria]
(
   [Habitacao_idHabitacao] int  NOT NULL,
   [dataHora] datetime2(0)  NOT NULL
)
WITH (DATA_COMPRESSION = NONE)
GO
BEGIN TRY
    EXEC sp_addextendedproperty
        N'MS_SSMA_SOURCE', N'solar.avaria',
        N'SCHEMA', N'solar',
        N'TABLE', N'avaria'
END TRY
BEGIN CATCH
    IF (@@TRANCOUNT > 0) ROLLBACK
    PRINT ERROR_MESSAGE()
END CATCH
GO

USE solar
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'consumoenergetico'  AND sc.name = N'solar'  AND type in (N'U'))
BEGIN

  DECLARE @drop_statement nvarchar(500)

  DECLARE drop_cursor CURSOR FOR
      SELECT 'alter table '+quotename(schema_name(ob.schema_id))+
      '.'+quotename(object_name(ob.object_id))+ ' drop constraint ' + quotename(fk.name) 
      FROM sys.objects ob INNER JOIN sys.foreign_keys fk ON fk.parent_object_id = ob.object_id
      WHERE fk.referenced_object_id = 
          (
             SELECT so.object_id 
             FROM sys.objects so JOIN sys.schemas sc
             ON so.schema_id = sc.schema_id
             WHERE so.name = N'consumoenergetico'  AND sc.name = N'solar'  AND type in (N'U')
           )

  OPEN drop_cursor

  FETCH NEXT FROM drop_cursor
  INTO @drop_statement

  WHILE @@FETCH_STATUS = 0
  BEGIN
     EXEC (@drop_statement)

     FETCH NEXT FROM drop_cursor
     INTO @drop_statement
  END

  CLOSE drop_cursor
  DEALLOCATE drop_cursor

  DROP TABLE [solar].[consumoenergetico]
END 
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE 
[solar].[consumoenergetico]
(
   [data] date  NOT NULL,
   [Habitacao_idHabitacao] int  NOT NULL,
   [consumo] float(53)  NOT NULL
)
WITH (DATA_COMPRESSION = NONE)
GO
BEGIN TRY
    EXEC sp_addextendedproperty
        N'MS_SSMA_SOURCE', N'solar.consumoenergetico',
        N'SCHEMA', N'solar',
        N'TABLE', N'consumoenergetico'
END TRY
BEGIN CATCH
    IF (@@TRANCOUNT > 0) ROLLBACK
    PRINT ERROR_MESSAGE()
END CATCH
GO

USE solar
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'evento'  AND sc.name = N'solar'  AND type in (N'U'))
BEGIN

  DECLARE @drop_statement nvarchar(500)

  DECLARE drop_cursor CURSOR FOR
      SELECT 'alter table '+quotename(schema_name(ob.schema_id))+
      '.'+quotename(object_name(ob.object_id))+ ' drop constraint ' + quotename(fk.name) 
      FROM sys.objects ob INNER JOIN sys.foreign_keys fk ON fk.parent_object_id = ob.object_id
      WHERE fk.referenced_object_id = 
          (
             SELECT so.object_id 
             FROM sys.objects so JOIN sys.schemas sc
             ON so.schema_id = sc.schema_id
             WHERE so.name = N'evento'  AND sc.name = N'solar'  AND type in (N'U')
           )

  OPEN drop_cursor

  FETCH NEXT FROM drop_cursor
  INTO @drop_statement

  WHILE @@FETCH_STATUS = 0
  BEGIN
     EXEC (@drop_statement)

     FETCH NEXT FROM drop_cursor
     INTO @drop_statement
  END

  CLOSE drop_cursor
  DEALLOCATE drop_cursor

  DROP TABLE [solar].[evento]
END 
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE 
[solar].[evento]
(
   [idEvento] int  NOT NULL,
   [data] datetime2(0)  NOT NULL,
   [descricao] nvarchar(max)  NOT NULL,
   [dataFinal] datetime2(0)  NOT NULL
)
WITH (DATA_COMPRESSION = NONE)
GO
BEGIN TRY
    EXEC sp_addextendedproperty
        N'MS_SSMA_SOURCE', N'solar.evento',
        N'SCHEMA', N'solar',
        N'TABLE', N'evento'
END TRY
BEGIN CATCH
    IF (@@TRANCOUNT > 0) ROLLBACK
    PRINT ERROR_MESSAGE()
END CATCH
GO

USE solar
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'funcionario'  AND sc.name = N'solar'  AND type in (N'U'))
BEGIN

  DECLARE @drop_statement nvarchar(500)

  DECLARE drop_cursor CURSOR FOR
      SELECT 'alter table '+quotename(schema_name(ob.schema_id))+
      '.'+quotename(object_name(ob.object_id))+ ' drop constraint ' + quotename(fk.name) 
      FROM sys.objects ob INNER JOIN sys.foreign_keys fk ON fk.parent_object_id = ob.object_id
      WHERE fk.referenced_object_id = 
          (
             SELECT so.object_id 
             FROM sys.objects so JOIN sys.schemas sc
             ON so.schema_id = sc.schema_id
             WHERE so.name = N'funcionario'  AND sc.name = N'solar'  AND type in (N'U')
           )

  OPEN drop_cursor

  FETCH NEXT FROM drop_cursor
  INTO @drop_statement

  WHILE @@FETCH_STATUS = 0
  BEGIN
     EXEC (@drop_statement)

     FETCH NEXT FROM drop_cursor
     INTO @drop_statement
  END

  CLOSE drop_cursor
  DEALLOCATE drop_cursor

  DROP TABLE [solar].[funcionario]
END 
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE 
[solar].[funcionario]
(
   [Utilizador_username] nvarchar(45)  NOT NULL
)
WITH (DATA_COMPRESSION = NONE)
GO
BEGIN TRY
    EXEC sp_addextendedproperty
        N'MS_SSMA_SOURCE', N'solar.funcionario',
        N'SCHEMA', N'solar',
        N'TABLE', N'funcionario'
END TRY
BEGIN CATCH
    IF (@@TRANCOUNT > 0) ROLLBACK
    PRINT ERROR_MESSAGE()
END CATCH
GO

USE solar
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'habitacao'  AND sc.name = N'solar'  AND type in (N'U'))
BEGIN

  DECLARE @drop_statement nvarchar(500)

  DECLARE drop_cursor CURSOR FOR
      SELECT 'alter table '+quotename(schema_name(ob.schema_id))+
      '.'+quotename(object_name(ob.object_id))+ ' drop constraint ' + quotename(fk.name) 
      FROM sys.objects ob INNER JOIN sys.foreign_keys fk ON fk.parent_object_id = ob.object_id
      WHERE fk.referenced_object_id = 
          (
             SELECT so.object_id 
             FROM sys.objects so JOIN sys.schemas sc
             ON so.schema_id = sc.schema_id
             WHERE so.name = N'habitacao'  AND sc.name = N'solar'  AND type in (N'U')
           )

  OPEN drop_cursor

  FETCH NEXT FROM drop_cursor
  INTO @drop_statement

  WHILE @@FETCH_STATUS = 0
  BEGIN
     EXEC (@drop_statement)

     FETCH NEXT FROM drop_cursor
     INTO @drop_statement
  END

  CLOSE drop_cursor
  DEALLOCATE drop_cursor

  DROP TABLE [solar].[habitacao]
END 
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE 
[solar].[habitacao]
(
   [idHabitacao] int  NOT NULL,
   [morada] nvarchar(150)  NOT NULL,
   [latitude] float(53)  NOT NULL,
   [longitude] float(53)  NOT NULL,
   [bateria] float(53)  NOT NULL,
   [capacidade] float(53)  NOT NULL,
   [Localidade_idLocalidade] int  NOT NULL,
   [Utilizador_username] nvarchar(45)  NOT NULL
)
WITH (DATA_COMPRESSION = NONE)
GO
BEGIN TRY
    EXEC sp_addextendedproperty
        N'MS_SSMA_SOURCE', N'solar.habitacao',
        N'SCHEMA', N'solar',
        N'TABLE', N'habitacao'
END TRY
BEGIN CATCH
    IF (@@TRANCOUNT > 0) ROLLBACK
    PRINT ERROR_MESSAGE()
END CATCH
GO

USE solar
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'lembrete'  AND sc.name = N'solar'  AND type in (N'U'))
BEGIN

  DECLARE @drop_statement nvarchar(500)

  DECLARE drop_cursor CURSOR FOR
      SELECT 'alter table '+quotename(schema_name(ob.schema_id))+
      '.'+quotename(object_name(ob.object_id))+ ' drop constraint ' + quotename(fk.name) 
      FROM sys.objects ob INNER JOIN sys.foreign_keys fk ON fk.parent_object_id = ob.object_id
      WHERE fk.referenced_object_id = 
          (
             SELECT so.object_id 
             FROM sys.objects so JOIN sys.schemas sc
             ON so.schema_id = sc.schema_id
             WHERE so.name = N'lembrete'  AND sc.name = N'solar'  AND type in (N'U')
           )

  OPEN drop_cursor

  FETCH NEXT FROM drop_cursor
  INTO @drop_statement

  WHILE @@FETCH_STATUS = 0
  BEGIN
     EXEC (@drop_statement)

     FETCH NEXT FROM drop_cursor
     INTO @drop_statement
  END

  CLOSE drop_cursor
  DEALLOCATE drop_cursor

  DROP TABLE [solar].[lembrete]
END 
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE 
[solar].[lembrete]
(
   [idLembrete] int  NOT NULL,
   [dataHora] datetime2(0)  NOT NULL,
   [Utilizador_username] nvarchar(45)  NOT NULL,
   [Evento_idEvento] int  NOT NULL
)
WITH (DATA_COMPRESSION = NONE)
GO
BEGIN TRY
    EXEC sp_addextendedproperty
        N'MS_SSMA_SOURCE', N'solar.lembrete',
        N'SCHEMA', N'solar',
        N'TABLE', N'lembrete'
END TRY
BEGIN CATCH
    IF (@@TRANCOUNT > 0) ROLLBACK
    PRINT ERROR_MESSAGE()
END CATCH
GO

USE solar
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'localidade'  AND sc.name = N'solar'  AND type in (N'U'))
BEGIN

  DECLARE @drop_statement nvarchar(500)

  DECLARE drop_cursor CURSOR FOR
      SELECT 'alter table '+quotename(schema_name(ob.schema_id))+
      '.'+quotename(object_name(ob.object_id))+ ' drop constraint ' + quotename(fk.name) 
      FROM sys.objects ob INNER JOIN sys.foreign_keys fk ON fk.parent_object_id = ob.object_id
      WHERE fk.referenced_object_id = 
          (
             SELECT so.object_id 
             FROM sys.objects so JOIN sys.schemas sc
             ON so.schema_id = sc.schema_id
             WHERE so.name = N'localidade'  AND sc.name = N'solar'  AND type in (N'U')
           )

  OPEN drop_cursor

  FETCH NEXT FROM drop_cursor
  INTO @drop_statement

  WHILE @@FETCH_STATUS = 0
  BEGIN
     EXEC (@drop_statement)

     FETCH NEXT FROM drop_cursor
     INTO @drop_statement
  END

  CLOSE drop_cursor
  DEALLOCATE drop_cursor

  DROP TABLE [solar].[localidade]
END 
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE 
[solar].[localidade]
(
   [idLocalidade] int  NOT NULL,
   [latitude] float(53)  NOT NULL,
   [longitude] float(53)  NOT NULL,
   [Nome] nvarchar(100)  NOT NULL,
   [Distrito] nvarchar(45)  NOT NULL,
   [Concelho] nvarchar(100)  NOT NULL
)
WITH (DATA_COMPRESSION = NONE)
GO
BEGIN TRY
    EXEC sp_addextendedproperty
        N'MS_SSMA_SOURCE', N'solar.localidade',
        N'SCHEMA', N'solar',
        N'TABLE', N'localidade'
END TRY
BEGIN CATCH
    IF (@@TRANCOUNT > 0) ROLLBACK
    PRINT ERROR_MESSAGE()
END CATCH
GO

USE solar
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'manutencao'  AND sc.name = N'solar'  AND type in (N'U'))
BEGIN

  DECLARE @drop_statement nvarchar(500)

  DECLARE drop_cursor CURSOR FOR
      SELECT 'alter table '+quotename(schema_name(ob.schema_id))+
      '.'+quotename(object_name(ob.object_id))+ ' drop constraint ' + quotename(fk.name) 
      FROM sys.objects ob INNER JOIN sys.foreign_keys fk ON fk.parent_object_id = ob.object_id
      WHERE fk.referenced_object_id = 
          (
             SELECT so.object_id 
             FROM sys.objects so JOIN sys.schemas sc
             ON so.schema_id = sc.schema_id
             WHERE so.name = N'manutencao'  AND sc.name = N'solar'  AND type in (N'U')
           )

  OPEN drop_cursor

  FETCH NEXT FROM drop_cursor
  INTO @drop_statement

  WHILE @@FETCH_STATUS = 0
  BEGIN
     EXEC (@drop_statement)

     FETCH NEXT FROM drop_cursor
     INTO @drop_statement
  END

  CLOSE drop_cursor
  DEALLOCATE drop_cursor

  DROP TABLE [solar].[manutencao]
END 
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE 
[solar].[manutencao]
(
   [Funcionario_username] nvarchar(45)  NOT NULL,
   [Habitacao_idHabitacao] int  NOT NULL,
   [data] datetime2(0)  NOT NULL
)
WITH (DATA_COMPRESSION = NONE)
GO
BEGIN TRY
    EXEC sp_addextendedproperty
        N'MS_SSMA_SOURCE', N'solar.manutencao',
        N'SCHEMA', N'solar',
        N'TABLE', N'manutencao'
END TRY
BEGIN CATCH
    IF (@@TRANCOUNT > 0) ROLLBACK
    PRINT ERROR_MESSAGE()
END CATCH
GO

USE solar
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'meteorologia'  AND sc.name = N'solar'  AND type in (N'U'))
BEGIN

  DECLARE @drop_statement nvarchar(500)

  DECLARE drop_cursor CURSOR FOR
      SELECT 'alter table '+quotename(schema_name(ob.schema_id))+
      '.'+quotename(object_name(ob.object_id))+ ' drop constraint ' + quotename(fk.name) 
      FROM sys.objects ob INNER JOIN sys.foreign_keys fk ON fk.parent_object_id = ob.object_id
      WHERE fk.referenced_object_id = 
          (
             SELECT so.object_id 
             FROM sys.objects so JOIN sys.schemas sc
             ON so.schema_id = sc.schema_id
             WHERE so.name = N'meteorologia'  AND sc.name = N'solar'  AND type in (N'U')
           )

  OPEN drop_cursor

  FETCH NEXT FROM drop_cursor
  INTO @drop_statement

  WHILE @@FETCH_STATUS = 0
  BEGIN
     EXEC (@drop_statement)

     FETCH NEXT FROM drop_cursor
     INTO @drop_statement
  END

  CLOSE drop_cursor
  DEALLOCATE drop_cursor

  DROP TABLE [solar].[meteorologia]
END 
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE 
[solar].[meteorologia]
(
   [data] date  NOT NULL,
   [idLocalidade] int  NOT NULL,
   [weatherType] nvarchar(8)  NOT NULL,
   [skyCondition] nvarchar(10)  NOT NULL,
   [probPrecipitacao] float(53)  NOT NULL,
   [sunrise] time  NOT NULL,
   [sunset] time  NOT NULL
)
WITH (DATA_COMPRESSION = NONE)
GO
BEGIN TRY
    EXEC sp_addextendedproperty
        N'MS_SSMA_SOURCE', N'solar.meteorologia',
        N'SCHEMA', N'solar',
        N'TABLE', N'meteorologia'
END TRY
BEGIN CATCH
    IF (@@TRANCOUNT > 0) ROLLBACK
    PRINT ERROR_MESSAGE()
END CATCH
GO

USE solar
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'painel'  AND sc.name = N'solar'  AND type in (N'U'))
BEGIN

  DECLARE @drop_statement nvarchar(500)

  DECLARE drop_cursor CURSOR FOR
      SELECT 'alter table '+quotename(schema_name(ob.schema_id))+
      '.'+quotename(object_name(ob.object_id))+ ' drop constraint ' + quotename(fk.name) 
      FROM sys.objects ob INNER JOIN sys.foreign_keys fk ON fk.parent_object_id = ob.object_id
      WHERE fk.referenced_object_id = 
          (
             SELECT so.object_id 
             FROM sys.objects so JOIN sys.schemas sc
             ON so.schema_id = sc.schema_id
             WHERE so.name = N'painel'  AND sc.name = N'solar'  AND type in (N'U')
           )

  OPEN drop_cursor

  FETCH NEXT FROM drop_cursor
  INTO @drop_statement

  WHILE @@FETCH_STATUS = 0
  BEGIN
     EXEC (@drop_statement)

     FETCH NEXT FROM drop_cursor
     INTO @drop_statement
  END

  CLOSE drop_cursor
  DEALLOCATE drop_cursor

  DROP TABLE [solar].[painel]
END 
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE 
[solar].[painel]
(
   [idPainel] int  NOT NULL,
   [Habitacao_idHabitacao] int  NOT NULL,
   [producaoPrevistaHora] float(53)  NOT NULL,
   [modelo] nvarchar(45)  NOT NULL,
   [estado] int  NOT NULL
)
WITH (DATA_COMPRESSION = NONE)
GO
BEGIN TRY
    EXEC sp_addextendedproperty
        N'MS_SSMA_SOURCE', N'solar.painel',
        N'SCHEMA', N'solar',
        N'TABLE', N'painel'
END TRY
BEGIN CATCH
    IF (@@TRANCOUNT > 0) ROLLBACK
    PRINT ERROR_MESSAGE()
END CATCH
GO

USE solar
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'producaoenergetica'  AND sc.name = N'solar'  AND type in (N'U'))
BEGIN

  DECLARE @drop_statement nvarchar(500)

  DECLARE drop_cursor CURSOR FOR
      SELECT 'alter table '+quotename(schema_name(ob.schema_id))+
      '.'+quotename(object_name(ob.object_id))+ ' drop constraint ' + quotename(fk.name) 
      FROM sys.objects ob INNER JOIN sys.foreign_keys fk ON fk.parent_object_id = ob.object_id
      WHERE fk.referenced_object_id = 
          (
             SELECT so.object_id 
             FROM sys.objects so JOIN sys.schemas sc
             ON so.schema_id = sc.schema_id
             WHERE so.name = N'producaoenergetica'  AND sc.name = N'solar'  AND type in (N'U')
           )

  OPEN drop_cursor

  FETCH NEXT FROM drop_cursor
  INTO @drop_statement

  WHILE @@FETCH_STATUS = 0
  BEGIN
     EXEC (@drop_statement)

     FETCH NEXT FROM drop_cursor
     INTO @drop_statement
  END

  CLOSE drop_cursor
  DEALLOCATE drop_cursor

  DROP TABLE [solar].[producaoenergetica]
END 
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE 
[solar].[producaoenergetica]
(
   [data] date  NOT NULL,
   [producao] float(53)  NOT NULL,
   [ID] int  NOT NULL,
   [Painel_idPainel] int  NOT NULL,
   [Painel_Habitacao_idHabitacao] int  NOT NULL
)
WITH (DATA_COMPRESSION = NONE)
GO
BEGIN TRY
    EXEC sp_addextendedproperty
        N'MS_SSMA_SOURCE', N'solar.producaoenergetica',
        N'SCHEMA', N'solar',
        N'TABLE', N'producaoenergetica'
END TRY
BEGIN CATCH
    IF (@@TRANCOUNT > 0) ROLLBACK
    PRINT ERROR_MESSAGE()
END CATCH
GO

USE solar
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'utilizador'  AND sc.name = N'solar'  AND type in (N'U'))
BEGIN

  DECLARE @drop_statement nvarchar(500)

  DECLARE drop_cursor CURSOR FOR
      SELECT 'alter table '+quotename(schema_name(ob.schema_id))+
      '.'+quotename(object_name(ob.object_id))+ ' drop constraint ' + quotename(fk.name) 
      FROM sys.objects ob INNER JOIN sys.foreign_keys fk ON fk.parent_object_id = ob.object_id
      WHERE fk.referenced_object_id = 
          (
             SELECT so.object_id 
             FROM sys.objects so JOIN sys.schemas sc
             ON so.schema_id = sc.schema_id
             WHERE so.name = N'utilizador'  AND sc.name = N'solar'  AND type in (N'U')
           )

  OPEN drop_cursor

  FETCH NEXT FROM drop_cursor
  INTO @drop_statement

  WHILE @@FETCH_STATUS = 0
  BEGIN
     EXEC (@drop_statement)

     FETCH NEXT FROM drop_cursor
     INTO @drop_statement
  END

  CLOSE drop_cursor
  DEALLOCATE drop_cursor

  DROP TABLE [solar].[utilizador]
END 
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE 
[solar].[utilizador]
(
   [username] nvarchar(45)  NOT NULL,
   [nome] nvarchar(100)  NOT NULL,
   [password] nvarchar(45)  NOT NULL,
   [email] nvarchar(100)  NOT NULL,
   [lastTimeOnline] datetime2(0)  NOT NULL
)
WITH (DATA_COMPRESSION = NONE)
GO
BEGIN TRY
    EXEC sp_addextendedproperty
        N'MS_SSMA_SOURCE', N'solar.utilizador',
        N'SCHEMA', N'solar',
        N'TABLE', N'utilizador'
END TRY
BEGIN CATCH
    IF (@@TRANCOUNT > 0) ROLLBACK
    PRINT ERROR_MESSAGE()
END CATCH
GO

USE solar
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'PK_alerta_idAlerta'  AND sc.name = N'solar'  AND type in (N'PK'))
ALTER TABLE [solar].[alerta] DROP CONSTRAINT [PK_alerta_idAlerta]
 GO



ALTER TABLE [solar].[alerta]
 ADD CONSTRAINT [PK_alerta_idAlerta]
   PRIMARY KEY
   CLUSTERED ([idAlerta] ASC)

GO


USE solar
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'PK_alertasutilizador_Utilizador_username'  AND sc.name = N'solar'  AND type in (N'PK'))
ALTER TABLE [solar].[alertasutilizador] DROP CONSTRAINT [PK_alertasutilizador_Utilizador_username]
 GO



ALTER TABLE [solar].[alertasutilizador]
 ADD CONSTRAINT [PK_alertasutilizador_Utilizador_username]
   PRIMARY KEY
   CLUSTERED ([Utilizador_username] ASC, [Tipo] ASC)

GO


USE solar
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'PK_avaria_dataHora'  AND sc.name = N'solar'  AND type in (N'PK'))
ALTER TABLE [solar].[avaria] DROP CONSTRAINT [PK_avaria_dataHora]
 GO



ALTER TABLE [solar].[avaria]
 ADD CONSTRAINT [PK_avaria_dataHora]
   PRIMARY KEY
   CLUSTERED ([dataHora] ASC)

GO


USE solar
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'PK_consumoenergetico_data'  AND sc.name = N'solar'  AND type in (N'PK'))
ALTER TABLE [solar].[consumoenergetico] DROP CONSTRAINT [PK_consumoenergetico_data]
 GO



ALTER TABLE [solar].[consumoenergetico]
 ADD CONSTRAINT [PK_consumoenergetico_data]
   PRIMARY KEY
   CLUSTERED ([data] ASC, [Habitacao_idHabitacao] ASC)

GO


USE solar
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'PK_evento_idEvento'  AND sc.name = N'solar'  AND type in (N'PK'))
ALTER TABLE [solar].[evento] DROP CONSTRAINT [PK_evento_idEvento]
 GO



ALTER TABLE [solar].[evento]
 ADD CONSTRAINT [PK_evento_idEvento]
   PRIMARY KEY
   CLUSTERED ([idEvento] ASC)

GO


USE solar
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'PK_funcionario_Utilizador_username'  AND sc.name = N'solar'  AND type in (N'PK'))
ALTER TABLE [solar].[funcionario] DROP CONSTRAINT [PK_funcionario_Utilizador_username]
 GO



ALTER TABLE [solar].[funcionario]
 ADD CONSTRAINT [PK_funcionario_Utilizador_username]
   PRIMARY KEY
   CLUSTERED ([Utilizador_username] ASC)

GO


USE solar
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'PK_habitacao_idHabitacao'  AND sc.name = N'solar'  AND type in (N'PK'))
ALTER TABLE [solar].[habitacao] DROP CONSTRAINT [PK_habitacao_idHabitacao]
 GO



ALTER TABLE [solar].[habitacao]
 ADD CONSTRAINT [PK_habitacao_idHabitacao]
   PRIMARY KEY
   CLUSTERED ([idHabitacao] ASC)

GO


USE solar
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'PK_lembrete_idLembrete'  AND sc.name = N'solar'  AND type in (N'PK'))
ALTER TABLE [solar].[lembrete] DROP CONSTRAINT [PK_lembrete_idLembrete]
 GO



ALTER TABLE [solar].[lembrete]
 ADD CONSTRAINT [PK_lembrete_idLembrete]
   PRIMARY KEY
   CLUSTERED ([idLembrete] ASC)

GO


USE solar
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'PK_localidade_idLocalidade'  AND sc.name = N'solar'  AND type in (N'PK'))
ALTER TABLE [solar].[localidade] DROP CONSTRAINT [PK_localidade_idLocalidade]
 GO



ALTER TABLE [solar].[localidade]
 ADD CONSTRAINT [PK_localidade_idLocalidade]
   PRIMARY KEY
   CLUSTERED ([idLocalidade] ASC)

GO


USE solar
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'PK_manutencao_Funcionario_username'  AND sc.name = N'solar'  AND type in (N'PK'))
ALTER TABLE [solar].[manutencao] DROP CONSTRAINT [PK_manutencao_Funcionario_username]
 GO



ALTER TABLE [solar].[manutencao]
 ADD CONSTRAINT [PK_manutencao_Funcionario_username]
   PRIMARY KEY
   CLUSTERED ([Funcionario_username] ASC)

GO


USE solar
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'PK_meteorologia_data'  AND sc.name = N'solar'  AND type in (N'PK'))
ALTER TABLE [solar].[meteorologia] DROP CONSTRAINT [PK_meteorologia_data]
 GO



ALTER TABLE [solar].[meteorologia]
 ADD CONSTRAINT [PK_meteorologia_data]
   PRIMARY KEY
   CLUSTERED ([data] ASC, [idLocalidade] ASC)

GO


USE solar
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'PK_painel_idPainel'  AND sc.name = N'solar'  AND type in (N'PK'))
ALTER TABLE [solar].[painel] DROP CONSTRAINT [PK_painel_idPainel]
 GO



ALTER TABLE [solar].[painel]
 ADD CONSTRAINT [PK_painel_idPainel]
   PRIMARY KEY
   CLUSTERED ([idPainel] ASC, [Habitacao_idHabitacao] ASC)

GO


USE solar
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'PK_producaoenergetica_ID'  AND sc.name = N'solar'  AND type in (N'PK'))
ALTER TABLE [solar].[producaoenergetica] DROP CONSTRAINT [PK_producaoenergetica_ID]
 GO



ALTER TABLE [solar].[producaoenergetica]
 ADD CONSTRAINT [PK_producaoenergetica_ID]
   PRIMARY KEY
   CLUSTERED ([ID] ASC, [Painel_idPainel] ASC, [Painel_Habitacao_idHabitacao] ASC)

GO


USE solar
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'PK_utilizador_username'  AND sc.name = N'solar'  AND type in (N'PK'))
ALTER TABLE [solar].[utilizador] DROP CONSTRAINT [PK_utilizador_username]
 GO



ALTER TABLE [solar].[utilizador]
 ADD CONSTRAINT [PK_utilizador_username]
   PRIMARY KEY
   CLUSTERED ([username] ASC)

GO


USE solar
GO
IF EXISTS (
       SELECT * FROM sys.objects  so JOIN sys.indexes si
       ON so.object_id = si.object_id
       JOIN sys.schemas sc
       ON so.schema_id = sc.schema_id
       WHERE so.name = N'avaria'  AND sc.name = N'solar'  AND si.name = N'fk_Avaria_Habitacao1_idx' AND so.type in (N'U'))
   DROP INDEX [fk_Avaria_Habitacao1_idx] ON [solar].[avaria] 
GO
CREATE NONCLUSTERED INDEX [fk_Avaria_Habitacao1_idx] ON [solar].[avaria]
(
   [Habitacao_idHabitacao] ASC
)
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY] 
GO
GO

USE solar
GO
IF EXISTS (
       SELECT * FROM sys.objects  so JOIN sys.indexes si
       ON so.object_id = si.object_id
       JOIN sys.schemas sc
       ON so.schema_id = sc.schema_id
       WHERE so.name = N'consumoenergetico'  AND sc.name = N'solar'  AND si.name = N'fk_ConsumoEnergetico_Habitacao1_idx' AND so.type in (N'U'))
   DROP INDEX [fk_ConsumoEnergetico_Habitacao1_idx] ON [solar].[consumoenergetico] 
GO
CREATE NONCLUSTERED INDEX [fk_ConsumoEnergetico_Habitacao1_idx] ON [solar].[consumoenergetico]
(
   [Habitacao_idHabitacao] ASC
)
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY] 
GO
GO

USE solar
GO
IF EXISTS (
       SELECT * FROM sys.objects  so JOIN sys.indexes si
       ON so.object_id = si.object_id
       JOIN sys.schemas sc
       ON so.schema_id = sc.schema_id
       WHERE so.name = N'habitacao'  AND sc.name = N'solar'  AND si.name = N'fk_Habitacao_Localidade1_idx' AND so.type in (N'U'))
   DROP INDEX [fk_Habitacao_Localidade1_idx] ON [solar].[habitacao] 
GO
CREATE NONCLUSTERED INDEX [fk_Habitacao_Localidade1_idx] ON [solar].[habitacao]
(
   [Localidade_idLocalidade] ASC
)
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY] 
GO
GO

USE solar
GO
IF EXISTS (
       SELECT * FROM sys.objects  so JOIN sys.indexes si
       ON so.object_id = si.object_id
       JOIN sys.schemas sc
       ON so.schema_id = sc.schema_id
       WHERE so.name = N'habitacao'  AND sc.name = N'solar'  AND si.name = N'fk_Habitacao_Utilizador1_idx' AND so.type in (N'U'))
   DROP INDEX [fk_Habitacao_Utilizador1_idx] ON [solar].[habitacao] 
GO
CREATE NONCLUSTERED INDEX [fk_Habitacao_Utilizador1_idx] ON [solar].[habitacao]
(
   [Utilizador_username] ASC
)
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY] 
GO
GO

USE solar
GO
IF EXISTS (
       SELECT * FROM sys.objects  so JOIN sys.indexes si
       ON so.object_id = si.object_id
       JOIN sys.schemas sc
       ON so.schema_id = sc.schema_id
       WHERE so.name = N'lembrete'  AND sc.name = N'solar'  AND si.name = N'fk_Lembrete_Evento1_idx' AND so.type in (N'U'))
   DROP INDEX [fk_Lembrete_Evento1_idx] ON [solar].[lembrete] 
GO
CREATE NONCLUSTERED INDEX [fk_Lembrete_Evento1_idx] ON [solar].[lembrete]
(
   [Evento_idEvento] ASC
)
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY] 
GO
GO

USE solar
GO
IF EXISTS (
       SELECT * FROM sys.objects  so JOIN sys.indexes si
       ON so.object_id = si.object_id
       JOIN sys.schemas sc
       ON so.schema_id = sc.schema_id
       WHERE so.name = N'lembrete'  AND sc.name = N'solar'  AND si.name = N'fk_Lembrete_Utilizador1_idx' AND so.type in (N'U'))
   DROP INDEX [fk_Lembrete_Utilizador1_idx] ON [solar].[lembrete] 
GO
CREATE NONCLUSTERED INDEX [fk_Lembrete_Utilizador1_idx] ON [solar].[lembrete]
(
   [Utilizador_username] ASC
)
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY] 
GO
GO

USE solar
GO
IF EXISTS (
       SELECT * FROM sys.objects  so JOIN sys.indexes si
       ON so.object_id = si.object_id
       JOIN sys.schemas sc
       ON so.schema_id = sc.schema_id
       WHERE so.name = N'manutencao'  AND sc.name = N'solar'  AND si.name = N'fk_Manutencao_Habitacao1_idx' AND so.type in (N'U'))
   DROP INDEX [fk_Manutencao_Habitacao1_idx] ON [solar].[manutencao] 
GO
CREATE NONCLUSTERED INDEX [fk_Manutencao_Habitacao1_idx] ON [solar].[manutencao]
(
   [Habitacao_idHabitacao] ASC
)
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY] 
GO
GO

USE solar
GO
IF EXISTS (
       SELECT * FROM sys.objects  so JOIN sys.indexes si
       ON so.object_id = si.object_id
       JOIN sys.schemas sc
       ON so.schema_id = sc.schema_id
       WHERE so.name = N'meteorologia'  AND sc.name = N'solar'  AND si.name = N'fk_Meteorologia_Localidade_idx' AND so.type in (N'U'))
   DROP INDEX [fk_Meteorologia_Localidade_idx] ON [solar].[meteorologia] 
GO
CREATE NONCLUSTERED INDEX [fk_Meteorologia_Localidade_idx] ON [solar].[meteorologia]
(
   [idLocalidade] ASC
)
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY] 
GO
GO

USE solar
GO
IF EXISTS (
       SELECT * FROM sys.objects  so JOIN sys.indexes si
       ON so.object_id = si.object_id
       JOIN sys.schemas sc
       ON so.schema_id = sc.schema_id
       WHERE so.name = N'painel'  AND sc.name = N'solar'  AND si.name = N'fk_Painel_Habitacao1_idx' AND so.type in (N'U'))
   DROP INDEX [fk_Painel_Habitacao1_idx] ON [solar].[painel] 
GO
CREATE NONCLUSTERED INDEX [fk_Painel_Habitacao1_idx] ON [solar].[painel]
(
   [Habitacao_idHabitacao] ASC
)
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY] 
GO
GO

USE solar
GO
IF EXISTS (
       SELECT * FROM sys.objects  so JOIN sys.indexes si
       ON so.object_id = si.object_id
       JOIN sys.schemas sc
       ON so.schema_id = sc.schema_id
       WHERE so.name = N'producaoenergetica'  AND sc.name = N'solar'  AND si.name = N'fk_ProducaoEnergetica_Painel1_idx' AND so.type in (N'U'))
   DROP INDEX [fk_ProducaoEnergetica_Painel1_idx] ON [solar].[producaoenergetica] 
GO
CREATE NONCLUSTERED INDEX [fk_ProducaoEnergetica_Painel1_idx] ON [solar].[producaoenergetica]
(
   [Painel_idPainel] ASC,
   [Painel_Habitacao_idHabitacao] ASC
)
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY] 
GO
GO

USE solar
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'alertasutilizador$fk_table1_Utilizador2'  AND sc.name = N'solar'  AND type in (N'F'))
ALTER TABLE [solar].[alertasutilizador] DROP CONSTRAINT [alertasutilizador$fk_table1_Utilizador2]
 GO



ALTER TABLE [solar].[alertasutilizador]
 ADD CONSTRAINT [alertasutilizador$fk_table1_Utilizador2]
 FOREIGN KEY 
   ([Utilizador_username])
 REFERENCES 
   [solar].[solar].[utilizador]     ([username])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION

GO


USE solar
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'avaria$fk_Avaria_Habitacao1'  AND sc.name = N'solar'  AND type in (N'F'))
ALTER TABLE [solar].[avaria] DROP CONSTRAINT [avaria$fk_Avaria_Habitacao1]
 GO



ALTER TABLE [solar].[avaria]
 ADD CONSTRAINT [avaria$fk_Avaria_Habitacao1]
 FOREIGN KEY 
   ([Habitacao_idHabitacao])
 REFERENCES 
   [solar].[solar].[habitacao]     ([idHabitacao])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION

GO


USE solar
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'consumoenergetico$fk_ConsumoEnergetico_Habitacao1'  AND sc.name = N'solar'  AND type in (N'F'))
ALTER TABLE [solar].[consumoenergetico] DROP CONSTRAINT [consumoenergetico$fk_ConsumoEnergetico_Habitacao1]
 GO



ALTER TABLE [solar].[consumoenergetico]
 ADD CONSTRAINT [consumoenergetico$fk_ConsumoEnergetico_Habitacao1]
 FOREIGN KEY 
   ([Habitacao_idHabitacao])
 REFERENCES 
   [solar].[solar].[habitacao]     ([idHabitacao])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION

GO


USE solar
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'funcionario$fk_table1_Utilizador1'  AND sc.name = N'solar'  AND type in (N'F'))
ALTER TABLE [solar].[funcionario] DROP CONSTRAINT [funcionario$fk_table1_Utilizador1]
 GO



ALTER TABLE [solar].[funcionario]
 ADD CONSTRAINT [funcionario$fk_table1_Utilizador1]
 FOREIGN KEY 
   ([Utilizador_username])
 REFERENCES 
   [solar].[solar].[utilizador]     ([username])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION

GO


USE solar
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'habitacao$fk_Habitacao_Localidade1'  AND sc.name = N'solar'  AND type in (N'F'))
ALTER TABLE [solar].[habitacao] DROP CONSTRAINT [habitacao$fk_Habitacao_Localidade1]
 GO



ALTER TABLE [solar].[habitacao]
 ADD CONSTRAINT [habitacao$fk_Habitacao_Localidade1]
 FOREIGN KEY 
   ([Localidade_idLocalidade])
 REFERENCES 
   [solar].[solar].[localidade]     ([idLocalidade])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION

GO

IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'habitacao$fk_Habitacao_Utilizador1'  AND sc.name = N'solar'  AND type in (N'F'))
ALTER TABLE [solar].[habitacao] DROP CONSTRAINT [habitacao$fk_Habitacao_Utilizador1]
 GO



ALTER TABLE [solar].[habitacao]
 ADD CONSTRAINT [habitacao$fk_Habitacao_Utilizador1]
 FOREIGN KEY 
   ([Utilizador_username])
 REFERENCES 
   [solar].[solar].[utilizador]     ([username])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION

GO


USE solar
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'lembrete$fk_Lembrete_Evento1'  AND sc.name = N'solar'  AND type in (N'F'))
ALTER TABLE [solar].[lembrete] DROP CONSTRAINT [lembrete$fk_Lembrete_Evento1]
 GO



ALTER TABLE [solar].[lembrete]
 ADD CONSTRAINT [lembrete$fk_Lembrete_Evento1]
 FOREIGN KEY 
   ([Evento_idEvento])
 REFERENCES 
   [solar].[solar].[evento]     ([idEvento])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION

GO

IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'lembrete$fk_Lembrete_Utilizador1'  AND sc.name = N'solar'  AND type in (N'F'))
ALTER TABLE [solar].[lembrete] DROP CONSTRAINT [lembrete$fk_Lembrete_Utilizador1]
 GO



ALTER TABLE [solar].[lembrete]
 ADD CONSTRAINT [lembrete$fk_Lembrete_Utilizador1]
 FOREIGN KEY 
   ([Utilizador_username])
 REFERENCES 
   [solar].[solar].[utilizador]     ([username])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION

GO


USE solar
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'manutencao$fk_Manutencao_Funcionario1'  AND sc.name = N'solar'  AND type in (N'F'))
ALTER TABLE [solar].[manutencao] DROP CONSTRAINT [manutencao$fk_Manutencao_Funcionario1]
 GO



ALTER TABLE [solar].[manutencao]
 ADD CONSTRAINT [manutencao$fk_Manutencao_Funcionario1]
 FOREIGN KEY 
   ([Funcionario_username])
 REFERENCES 
   [solar].[solar].[funcionario]     ([Utilizador_username])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION

GO

IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'manutencao$fk_Manutencao_Habitacao1'  AND sc.name = N'solar'  AND type in (N'F'))
ALTER TABLE [solar].[manutencao] DROP CONSTRAINT [manutencao$fk_Manutencao_Habitacao1]
 GO



ALTER TABLE [solar].[manutencao]
 ADD CONSTRAINT [manutencao$fk_Manutencao_Habitacao1]
 FOREIGN KEY 
   ([Habitacao_idHabitacao])
 REFERENCES 
   [solar].[solar].[habitacao]     ([idHabitacao])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION

GO


USE solar
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'meteorologia$fk_Meteorologia_Localidade'  AND sc.name = N'solar'  AND type in (N'F'))
ALTER TABLE [solar].[meteorologia] DROP CONSTRAINT [meteorologia$fk_Meteorologia_Localidade]
 GO



ALTER TABLE [solar].[meteorologia]
 ADD CONSTRAINT [meteorologia$fk_Meteorologia_Localidade]
 FOREIGN KEY 
   ([idLocalidade])
 REFERENCES 
   [solar].[solar].[localidade]     ([idLocalidade])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION

GO


USE solar
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'painel$fk_Painel_Habitacao1'  AND sc.name = N'solar'  AND type in (N'F'))
ALTER TABLE [solar].[painel] DROP CONSTRAINT [painel$fk_Painel_Habitacao1]
 GO



ALTER TABLE [solar].[painel]
 ADD CONSTRAINT [painel$fk_Painel_Habitacao1]
 FOREIGN KEY 
   ([Habitacao_idHabitacao])
 REFERENCES 
   [solar].[solar].[habitacao]     ([idHabitacao])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION

GO


USE solar
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'producaoenergetica$fk_ProducaoEnergetica_Painel1'  AND sc.name = N'solar'  AND type in (N'F'))
ALTER TABLE [solar].[producaoenergetica] DROP CONSTRAINT [producaoenergetica$fk_ProducaoEnergetica_Painel1]
 GO



ALTER TABLE [solar].[producaoenergetica]
 ADD CONSTRAINT [producaoenergetica$fk_ProducaoEnergetica_Painel1]
 FOREIGN KEY 
   ([Painel_idPainel], [Painel_Habitacao_idHabitacao])
 REFERENCES 
   [solar].[solar].[painel]     ([idPainel], [Habitacao_idHabitacao])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION

GO

