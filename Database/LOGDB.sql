USE [LOGDB]
GO
/****** Object:  Synonym [dbo].[fnGetDateList]    Script Date: 2024-08-19 오후 7:09:28 ******/
CREATE SYNONYM [dbo].[fnGetDateList] FOR [METADB].[dbo].[fnGetDateList]
GO
/****** Object:  Synonym [dbo].[fnGetDateString]    Script Date: 2024-08-19 오후 7:09:28 ******/
CREATE SYNONYM [dbo].[fnGetDateString] FOR [METADB].[dbo].[fnGetDateString]
GO
/****** Object:  Synonym [dbo].[fnGetListParam]    Script Date: 2024-08-19 오후 7:09:28 ******/
CREATE SYNONYM [dbo].[fnGetListParam] FOR [METADB].[dbo].[fnGetListParam]
GO
/****** Object:  Synonym [dbo].[fnGetUserName]    Script Date: 2024-08-19 오후 7:09:28 ******/
CREATE SYNONYM [dbo].[fnGetUserName] FOR [METADB].[dbo].[fnGetUserName]
GO
/****** Object:  Synonym [dbo].[LPAD]    Script Date: 2024-08-19 오후 7:09:28 ******/
CREATE SYNONYM [dbo].[LPAD] FOR [METADB].[dbo].[LPAD]
GO
/****** Object:  Synonym [dbo].[MenuMaster]    Script Date: 2024-08-19 오후 7:09:28 ******/
CREATE SYNONYM [dbo].[MenuMaster] FOR [METADB].[dbo].[MenuMaster]
GO
/****** Object:  Synonym [dbo].[Plants]    Script Date: 2024-08-19 오후 7:09:28 ******/
CREATE SYNONYM [dbo].[Plants] FOR [METADB].[dbo].[Plants]
GO
/****** Object:  Synonym [dbo].[UserInfo]    Script Date: 2024-08-19 오후 7:09:28 ******/
CREATE SYNONYM [dbo].[UserInfo] FOR [METADB].[dbo].[UserInfo]
GO
/****** Object:  Table [dbo].[DatabaseLog]    Script Date: 2024-08-19 오후 7:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DatabaseLog](
	[DatabaseLogID] [bigint] IDENTITY(1,1) NOT NULL,
	[PostTime] [smalldatetime] NOT NULL,
	[DatabaseUser] [sysname] NOT NULL,
	[Event] [sysname] NOT NULL,
	[Database] [varchar](30) NULL,
	[Schema] [sysname] NULL,
	[Object] [sysname] NULL,
	[ObjectType] [nvarchar](50) NULL,
	[TSQL] [varchar](max) NOT NULL,
 CONSTRAINT [PK_DatabaseLog_DatabaseLogID] PRIMARY KEY NONCLUSTERED 
(
	[DatabaseLogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MenuExecuteLog]    Script Date: 2024-08-19 오후 7:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuExecuteLog](
	[SEQ] [bigint] IDENTITY(1,1) NOT NULL,
	[VENDORCODE] [varchar](10) NULL,
	[PLANTCODE] [varchar](4) NULL,
	[MENUID] [varchar](40) NOT NULL,
	[EXETIME] [datetime] NOT NULL,
	[SIGNINSEQ] [bigint] NOT NULL,
 CONSTRAINT [PK_MenuExecuteLog] PRIMARY KEY CLUSTERED 
(
	[SEQ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OperationLog]    Script Date: 2024-08-19 오후 7:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OperationLog](
	[SEQ] [bigint] IDENTITY(1,1) NOT NULL,
	[MENUID] [nvarchar](20) NULL,
	[POPNAME] [varchar](50) NULL,
	[OPERATION] [nvarchar](50) NULL,
	[SIGNINSEQ] [int] NULL,
	[STARTDTTM] [datetime] NULL,
	[ENDDTTM] [datetime] NULL,
 CONSTRAINT [PK_OperationLog] PRIMARY KEY CLUSTERED 
(
	[SEQ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SignLog]    Script Date: 2024-08-19 오후 7:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SignLog](
	[SIGNINSEQ] [bigint] IDENTITY(1,1) NOT NULL,
	[VENDORCODE] [nvarchar](10) NOT NULL,
	[PLANTCODE] [varchar](20) NOT NULL,
	[USERID] [nvarchar](50) NOT NULL,
	[SIGNINTIME] [datetime] NOT NULL,
	[SIGNOFFTIME] [datetime] NULL,
	[HOSTNAME] [nvarchar](30) NOT NULL,
	[OS] [nvarchar](50) NOT NULL,
	[MACADDRESS] [nvarchar](18) NOT NULL,
	[IPADDRESS] [nvarchar](16) NOT NULL,
 CONSTRAINT [PK_SignLog] PRIMARY KEY CLUSTERED 
(
	[SIGNINSEQ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 85, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UseLog]    Script Date: 2024-08-19 오후 7:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UseLog](
	[SEQ] [bigint] IDENTITY(1,1) NOT NULL,
	[VENDORCODE] [varchar](10) NULL,
	[PLANTCODE] [varchar](4) NULL,
	[SIGNINSEQ] [int] NULL,
	[METHODNAME] [varchar](50) NULL,
	[QUERYID] [varchar](500) NULL,
	[STARTDTTM] [datetime] NULL,
	[ENDDTTM] [datetime] NULL,
	[USEDATE]  AS (CONVERT([date],[STARTDTTM],(0))),
 CONSTRAINT [PK_UseLog] PRIMARY KEY CLUSTERED 
(
	[SEQ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[ABC]    Script Date: 2024-08-19 오후 7:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[ABC]
	@STARTDTTM		datetime,
	@ENDDTTM		datetime
AS
--SELECT METADB.dbo.fnGetCodeMasterValue('C$PLANTCODE', A.PLANTCODE) AS PLANTCODE
--	 , dbo.fnGetDateString(A.STARTDTTM, 0) DDATE
--	 , COUNT(A.SEQ) CNT
--FROM dbo.UseLog A WITH(NOLOCK)
--WHERE A.VENDORCODE != '' AND A.PLANTCODE != ''
--AND A.USEDATE BETWEEN @STARTDTTM AND @ENDDTTM
--GROUP BY A.PLANTCODE, dbo.fnGetDateString(A.STARTDTTM, 0)
--ORDER BY dbo.fnGetDateString(A.STARTDTTM, 0)

SELECT METADB.dbo.fnGetCodeMasterValue('C$VENDORCODE', A.VENDORCODE) AS PLANTCODE
	 --, A.MENUID
	 , dbo.fnGetDateString(A.EXETIME, 0) DDATE
	 , COUNT(A.SEQ) CNT
FROM dbo.MenuExecuteLog A WITH(NOLOCK)
WHERE A.VENDORCODE != '' AND A.PLANTCODE != ''
AND A.EXETIME BETWEEN dbo.fnGetDateString(@STARTDTTM, 0) + ' 00:00:00' AND dbo.fnGetDateString(@ENDDTTM, 0) + ' 23:59:59'
GROUP BY A.VENDORCODE
		--, A.MENUID
		, dbo.fnGetDateString(A.EXETIME, 0)
ORDER BY dbo.fnGetDateString(A.EXETIME, 0)
GO
/****** Object:  StoredProcedure [dbo].[MakeCSharpCode]    Script Date: 2024-08-19 오후 7:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
===================================================================================
 작 성 자: 오인봉
 작 성 일: 2017.07.20
 설    명: Table에 맞는 C# 코드 생성
 샘플실행: EXEC MakeCSharpCode 'CodeMaster'
 변경이력: 2017.07.20 SP최초작성
===================================================================================
*/

CREATE PROCEDURE [dbo].[MakeCSharpCode]
	@TableName				VARCHAR(100),
	@ViewName				VARCHAR(100) = 'viewList'	
AS
IF OBJECT_ID(@TableName) IS NULL
BEGIN
	PRINT '해당 테이블이 존재하지 않습니다.'
	RETURN (0)
END

--저장에서 사용할 ColumnList와 ParamList를 만들어준다.(IDENTITY 열을 빼고 만든다.)
SELECT  '"@' + sc.name + '", ' PARAMNAME
	  , @ViewName + '.InitColumn("' + sc.name + '", "' + ISNULL(CAST(d.value as varchar(500)), '') + '", 90, 0, false, true, DataType.Default, HorzAlign.Default);' INITCOL
	  , @ViewName + '.SetRowCellValue(e.RowHandle, "' + sc.name + '", "");' INITNEWROW
FROM sys.Columns AS sc WITH(NOLOCK)
LEFT JOIN sys.extended_properties AS d WITH(NOLOCK)
ON sc.object_id = d.major_id AND sc.column_id = d.minor_id
WHERE sc.object_id IN (SELECT object_id FROM sys.Tables WHERE Name = @TableName) 
AND sc.is_identity = 0
GO
/****** Object:  StoredProcedure [dbo].[MakeDeleteProcedure]    Script Date: 2024-08-19 오후 7:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*
===================================================================================
 작성자: 오인봉
 작성일: 2017.07.20
 설  명: Delete Procedure 생성
 샘플실행: EXEC MakeDeleteProcedure 'ScreenColumnSet'
 변경이력: 2017.07.20 SP최초작성
===================================================================================
*/ 

CREATE PROCEDURE [dbo].[MakeDeleteProcedure]
	@TableName				VARCHAR(100),
	@ProcedureName			VARCHAR(100) = ''
AS

DECLARE	@query				VARCHAR(MAX),
		@schema				VARCHAR(50),
		@ParamTypeList		VARCHAR(MAX),
		@ColumnList			VARCHAR(MAX),
		@ParamList			VARCHAR(MAX),
		@WhereCondition		VARCHAR(MAX),
		@SetList			VARCHAR(MAX),
		@index_id			INT,
		@rowCnt				INT

IF NOT EXISTS (SELECT object_id FROM sys.Tables WHERE Name = @TableName)
BEGIN
	PRINT '해당 테이블이 존재하지 않습니다!'
	RETURN(0)
END

IF @ProcedureName = ''
	SET @ProcedureName = @TableName + '_Delete'

SELECT @schema = name 
FROM sys.schemas
WHERE schema_id = (SELECT schema_id FROM sys.Tables WHERE name = @TableName)


--삭제는 ColumnList와 ParamList가 필요없음


--PRIMARY KEY Index를 변수에 저장한다.
SELECT @index_id = index_id
FROM sys.indexes AS sc
WHERE object_id IN (SELECT object_id FROM sys.Tables
					WHERE Name = @TableName) AND is_primary_key = 1

SELECT @rowCnt = COUNT(column_id)
FROM sys.Columns AS sc
WHERE object_id IN (SELECT object_id FROM sys.Tables
					WHERE Name = @TableName) AND column_id IN (SELECT colid FROM sysIndexkeys
															   WHERE id = (SELECT object_id FROM sys.indexes AS sc
																		   WHERE object_id IN (SELECT object_id FROM sys.Tables
																							   WHERE Name = @TableName AND is_primary_key = 1 and indid = @index_id)))


--SP Parameter에 사용할 Param 명과 Param Type을 만들어준다.
SELECT  @ParamTypeList = ISNULL(@ParamTypeList, '') + sc.Name + ' ' + 
		CASE (SELECT name FROM sys.types WHERE system_type_id = sc.system_type_id AND user_type_id = sc.user_type_id)
		WHEN 'CHAR' THEN  (SELECT name FROM sys.types WHERE system_type_id = sc.system_type_id AND user_type_id = sc.user_type_id) + '(' + cast(sc.max_length as varchar(4)) + ')' + CASE WHEN (@rowCnt > ROW_NUMBER() OVER(ORDER BY sc.column_id)) THEN (',' + CHAR(10) + '	@') ELSE '' END
		WHEN 'VARCHAR' THEN  (SELECT name FROM sys.types WHERE system_type_id = sc.system_type_id AND user_type_id = sc.user_type_id) + '(' + cast(sc.max_length as varchar(4)) + ')' + CASE WHEN (@rowCnt > ROW_NUMBER() OVER(ORDER BY sc.column_id)) THEN (',' + CHAR(10) + '	@') ELSE '' END
		WHEN 'VARBINARY' THEN  (SELECT name FROM sys.types WHERE system_type_id = sc.system_type_id AND user_type_id = sc.user_type_id) + '(' + cast(sc.max_length as varchar(4)) + ')' + CASE WHEN (@rowCnt > ROW_NUMBER() OVER(ORDER BY sc.column_id)) THEN (',' + CHAR(10) + '	@') ELSE '' END
		WHEN 'NCHAR' THEN  (SELECT name FROM sys.types WHERE system_type_id = sc.system_type_id AND user_type_id = sc.user_type_id) + '(' + cast(sc.max_length/2 as varchar(4)) + ')' + CASE WHEN (@rowCnt > ROW_NUMBER() OVER(ORDER BY sc.column_id)) THEN (',' + CHAR(10) + '	@') ELSE '' END
		WHEN 'NVARCHAR' THEN  (SELECT name FROM sys.types WHERE system_type_id = sc.system_type_id AND user_type_id = sc.user_type_id) + '(' + cast(sc.max_length/2 as varchar(4)) + ')' + CASE WHEN (@rowCnt > ROW_NUMBER() OVER(ORDER BY sc.column_id)) THEN (',' + CHAR(10) + '	@') ELSE '' END
		WHEN 'DECIMAL' THEN  (SELECT name FROM sys.types WHERE system_type_id = sc.system_type_id AND user_type_id = sc.user_type_id) + '(' + cast(sc.precision as varchar(4)) + ', ' + cast(sc.scale as varchar(4)) + ')' + CASE WHEN (@rowCnt > ROW_NUMBER() OVER(ORDER BY sc.column_id)) THEN (',' + CHAR(10) + '	@') ELSE '' END
		WHEN 'NUMERIC' THEN  (SELECT name FROM sys.types WHERE system_type_id = sc.system_type_id AND user_type_id = sc.user_type_id) + '(' + cast(sc.precision as varchar(4)) + ', ' + cast(sc.scale as varchar(4)) + ')' + CASE WHEN (@rowCnt > ROW_NUMBER() OVER(ORDER BY sc.column_id)) THEN (',' + CHAR(10) + '	@') ELSE '' END
		ELSE (SELECT name FROM sys.types WHERE system_type_id = sc.system_type_id AND user_type_id = sc.user_type_id) + CASE WHEN (@rowCnt > sc.column_id) THEN (',' + CHAR(10) + '	@') ELSE '' END
		END
FROM sys.Columns AS sc
WHERE object_id IN (SELECT object_id FROM sys.Tables WHERE Name = @TableName)
	AND column_id IN (SELECT colid FROM sysIndexkeys	
					  WHERE id = (SELECT object_id FROM sys.indexes AS sc
								  WHERE object_id IN (SELECT object_id FROM sys.Tables
													  WHERE Name = @TableName AND is_primary_key = 1 AND indid = @index_id)))

--WHERE 절을 만들어 준다.
SELECT  @WhereCondition = ISNULL(@WhereCondition, '') + sc.Name + ' = @' + sc.Name + 
		CASE WHEN (@rowCnt > ROW_NUMBER() OVER(ORDER BY sc.column_id)) THEN ' AND ' ELSE '' END
FROM sys.Columns AS sc
WHERE object_id IN (SELECT object_id FROM sys.Tables WHERE Name = @TableName)
	AND column_id IN (SELECT colid FROM sysIndexkeys	
					  WHERE id = (SELECT object_id FROM sys.indexes AS sc
								  WHERE object_id IN (SELECT object_id FROM sys.Tables
													  WHERE Name = @TableName AND is_primary_key = 1 AND indid = @index_id)))

--실제 수행할 PROCEDURE를 만든다.
SET @query = '/* ' + CHAR(10)
SET @query = @query + '=============================================================================================='+ CHAR(10)
SET @query = @query + ' 작 성 자 : ' + CHAR(10)
SET @query = @query + ' 작 성 일 : ' + CONVERT(VARCHAR(20), GETDATE(), 120) + CHAR(10)
SET @query = @query + ' 설    명 : ' + @TableName + ' Table 삭제' + CHAR(10)
SET @query = @query + ' 샘플실행 : EXEC ' + @schema + '.' + @ProcedureName + CHAR(10) + CHAR(10)
SET @query = @query + ' 변경이력 : ' + CHAR(10)
SET @query = @query + '=============================================================================================='+ CHAR(10)
SET @query = @query + '*/ '+ CHAR(10)
SET @query = @query + 'CREATE PROC ' + @schema + '.' + @ProcedureName + CHAR(10)
SET @query = @query + '	@' + @ParamTypeList + CHAR(10)
SET @query = @query + 'AS' + CHAR(10)
SET @query = @query + 'BEGIN TRY' + CHAR(10)
SET @query = @query + '	BEGIN TRANSACTION' + CHAR(10) + CHAR(10)
SET @query = @query + '		DELETE FROM ' + @schema + '.' + @TableName + CHAR(10)
SET @query = @query + '		WHERE ' + @WhereCondition + CHAR(10) + CHAR(10)
SET @query = @query + '	COMMIT TRANSACTION' + CHAR(10)
SET @query = @query + 'END TRY' + CHAR(10)
SET @query = @query + 'BEGIN CATCH' + CHAR(10)
SET @query = @query + '	DECLARE @ErrorMessage NVARCHAR(4000) ' + CHAR(10)
SET @query = @query + '	DECLARE @ErrorSeverity INT' + CHAR(10)
SET @query = @query + '	DECLARE @ErrorState INT' + CHAR(10)
SET @query = @query + '	SELECT @ErrorMessage = ''' + @schema + '.' + @ProcedureName + ' : '' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() ' + CHAR(10)
SET @query = @query + '	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) ' + CHAR(10)
SET @query = @query + '	IF @@TRANCOUNT > 0' + CHAR(10)
SET @query = @query + '		ROLLBACK TRANSACTION;' + CHAR(10)
SET @query = @query + 'END CATCH' + CHAR(10)

PRINT @query


GO
/****** Object:  StoredProcedure [dbo].[MakeMergeSaveProcedure]    Script Date: 2024-08-19 오후 7:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*
===================================================================================
 작 성 자: 오인봉
 작 성 일: 2015.11.20
 설    명: Merge Save Procedure 생성
 샘플실행: EXEC MakeMergeSaveProcedure 'TableName'
 변경이력: 2015.11.20 SP최초작성
===================================================================================
*/

CREATE PROCEDURE [dbo].[MakeMergeSaveProcedure]
	@TableName				VARCHAR(100),
	@ProcedureName			VARCHAR(100) = ''
AS

DECLARE @query				VARCHAR(MAX),
		@schema				VARCHAR(50),
		@ParamTypeList		VARCHAR(MAX),
		@ColumnList			VARCHAR(MAX),
		@ParamList			VARCHAR(MAX),
		@WhereCondition		VARCHAR(MAX),
		@MergeWhereCondition VARCHAR(MAX),
		@SetList			VARCHAR(MAX),
		@index_id			INT,
		@rowCnt				INT

IF NOT EXISTS(SELECT object_id FROM sys.Tables WHERE Name = @TableName)
BEGIN
	PRINT '해당 테이블이 존재하지 않습니다.'
	RETURN (0)
END

IF @ProcedureName = ''
	SET @ProcedureName = @TableName + '_Save'

SELECT @schema = name FROM sys.schemas
WHERE schema_id = (SELECT schema_id FROM sys.Tables WHERE name = @TableName)


--저장에서 사용할 ColumnList와 ParamList를 만들어준다.(IDENTITY 열을 빼고 만든다.)
SELECT  @ColumnList = COALESCE(@ColumnList +', ', '') + sc.Name,
		@ParamList = COALESCE(@ParamList +', @', '') + sc.Name
FROM sys.Columns AS sc
WHERE object_id IN (SELECT object_id FROM sys.Tables WHERE Name = @TableName) 
	AND is_identity = 0

--SP Parameter에 사용할 Param 명과 Param Type을 만들어준다.
SELECT  @ParamTypeList = ISNULL(@ParamTypeList, '') + sc.Name + ' ' + 
		CASE (SELECT name FROM sys.types WHERE system_type_id = sc.system_type_id AND user_type_id = sc.user_type_id)
		WHEN 'CHAR' THEN  (SELECT name FROM sys.types WHERE system_type_id = sc.system_type_id AND user_type_id = sc.user_type_id) + '(' + cast(sc.max_length as varchar(4)) + ')' + CASE WHEN (@@ROWCOUNT > ROW_NUMBER() OVER(ORDER BY sc.column_id)) THEN (',' + CHAR(10) + '	@') ELSE '' END
		WHEN 'VARCHAR' THEN  (SELECT name FROM sys.types WHERE system_type_id = sc.system_type_id AND user_type_id = sc.user_type_id) + '(' + cast(sc.max_length as varchar(4)) + ')' + CASE WHEN (@@ROWCOUNT > ROW_NUMBER() OVER(ORDER BY sc.column_id)) THEN (',' + CHAR(10) + '	@') ELSE '' END
		WHEN 'VARBINARY' THEN  (SELECT name FROM sys.types WHERE system_type_id = sc.system_type_id AND user_type_id = sc.user_type_id) + '(' + cast(sc.max_length as varchar(4)) + ')' + CASE WHEN (@@ROWCOUNT > ROW_NUMBER() OVER(ORDER BY sc.column_id)) THEN (',' + CHAR(10) + '	@') ELSE '' END
		WHEN 'NCHAR' THEN  (SELECT name FROM sys.types WHERE system_type_id = sc.system_type_id AND user_type_id = sc.user_type_id) + '(' + cast(sc.max_length/2 as varchar(4)) + ')' + CASE WHEN (@@ROWCOUNT > ROW_NUMBER() OVER(ORDER BY sc.column_id)) THEN (',' + CHAR(10) + '	@') ELSE '' END
		WHEN 'NVARCHAR' THEN  (SELECT name FROM sys.types WHERE system_type_id = sc.system_type_id AND user_type_id = sc.user_type_id) + '(' + cast(sc.max_length/2 as varchar(4)) + ')' + CASE WHEN (@@ROWCOUNT > ROW_NUMBER() OVER(ORDER BY sc.column_id)) THEN (',' + CHAR(10) + '	@') ELSE '' END
		WHEN 'DECIMAL' THEN  (SELECT name FROM sys.types WHERE system_type_id = sc.system_type_id AND user_type_id = sc.user_type_id) + '(' + cast(sc.precision as varchar(4)) + ', ' + cast(sc.scale as varchar(4)) + ')' + CASE WHEN (@@ROWCOUNT > ROW_NUMBER() OVER(ORDER BY sc.column_id)) THEN (',' + CHAR(10) + '	@') ELSE '' END
		WHEN 'NUMERIC' THEN  (SELECT name FROM sys.types WHERE system_type_id = sc.system_type_id AND user_type_id = sc.user_type_id) + '(' + cast(sc.precision as varchar(4)) + ', ' + cast(sc.scale as varchar(4)) + ')' + CASE WHEN (@@ROWCOUNT > ROW_NUMBER() OVER(ORDER BY sc.column_id)) THEN (',' + CHAR(10) + '	@') ELSE '' END
		WHEN 'DATETIME' THEN  (SELECT name FROM sys.types WHERE system_type_id = sc.system_type_id AND user_type_id = sc.user_type_id) + CASE WHEN (@@ROWCOUNT > ROW_NUMBER() OVER(ORDER BY sc.column_id)) THEN (',' + CHAR(10) + '	@') ELSE '' END
		ELSE (SELECT name FROM sys.types WHERE system_type_id = sc.system_type_id AND user_type_id = sc.user_type_id) + CASE WHEN (@@ROWCOUNT > sc.column_id) THEN (',' + CHAR(10) + '	@') ELSE '' END
		END
FROM sys.Columns AS sc
WHERE object_id IN (SELECT object_id FROM sys.Tables WHERE Name = @TableName) 
	AND is_identity = 0

SELECT @rowCnt = COUNT(column_id)
FROM sys.Columns AS sc
WHERE object_id IN (SELECT object_id FROM sys.Tables WHERE Name = @TableName) 
	AND column_id NOT IN (SELECT colid FROM sysIndexkeys 
						  WHERE id = (SELECT object_id FROM sys.indexes AS sc
									  WHERE object_id IN (SELECT object_id FROM sys.Tables
									 					  WHERE Name = @TableName AND is_primary_key = 1)))

--UPDATE 문에서 사용할 SET 절을 만들어준다.
SELECT  @SetList =  ISNULL(@SetList, '') + sc.Name + ' = @' + sc.Name + 
		CASE WHEN (@rowCnt > ROW_NUMBER() OVER(ORDER BY sc.column_id)) THEN (CHAR(10) + '		  , ') ELSE '' END
FROM sys.Columns AS sc
WHERE object_id IN (SELECT object_id FROM sys.Tables
					WHERE Name = @TableName) AND column_id NOT IN (SELECT colid FROM sysIndexkeys
																   WHERE id = (SELECT object_id FROM sys.indexes AS sc
																			   WHERE object_id IN (SELECT object_id FROM sys.Tables
																								   WHERE Name = @TableName AND is_primary_key = 1)))

--PRIMARY KEY Index를 변수에 저장한다.
SELECT @index_id = index_id
FROM sys.indexes AS sc
WHERE object_id IN (SELECT object_id FROM sys.Tables
					WHERE Name = @TableName) AND is_primary_key = 1

SELECT @rowCnt = COUNT(column_id)
FROM sys.Columns AS sc
WHERE object_id IN (SELECT object_id FROM sys.Tables
					WHERE Name = @TableName) AND column_id IN (SELECT colid FROM sysIndexkeys
															   WHERE id = (SELECT object_id FROM sys.indexes AS sc
																		   WHERE object_id IN (SELECT object_id FROM sys.Tables
																							   WHERE Name = @TableName AND is_primary_key = 1 and indid = @index_id)))

--WHERE 절을 만들어 준다.
SELECT  @WhereCondition = ISNULL(@WhereCondition, '') + sc.Name + ' = @' + sc.Name + 
		CASE WHEN (@rowCnt > ROW_NUMBER() OVER(ORDER BY sc.column_id)) THEN ' AND ' ELSE '' END
FROM sys.Columns AS sc
WHERE object_id IN (SELECT object_id FROM sys.Tables
					WHERE Name = @TableName) AND column_id IN (SELECT colid FROM sysIndexkeys
															   WHERE id = (SELECT object_id FROM sys.indexes AS sc
																		   WHERE object_id IN (SELECT object_id FROM sys.Tables
																							   WHERE Name = @TableName AND is_primary_key = 1 and indid = @index_id)))

SELECT  @MergeWhereCondition = ISNULL(@MergeWhereCondition, '') + 'A.' + sc.Name + ' = @' + sc.Name + 
		CASE WHEN (@rowCnt > ROW_NUMBER() OVER(ORDER BY sc.column_id)) THEN ' AND ' ELSE '' END
FROM sys.Columns AS sc
WHERE object_id IN (SELECT object_id FROM sys.Tables
					WHERE Name = @TableName) AND column_id IN (SELECT colid FROM sysIndexkeys
															   WHERE id = (SELECT object_id FROM sys.indexes AS sc
																		   WHERE object_id IN (SELECT object_id FROM sys.Tables
																							   WHERE Name = @TableName AND is_primary_key = 1 and indid = @index_id)))

--실제 수행할 PROCEDURE 를 만든다.
SET @query = '/* '+ CHAR(10)
SET @query = @query + '=============================================================================================='+ CHAR(10)
SET @query = @query + ' 작 성 자 : ' + CHAR(10)
SET @query = @query + ' 작 성 일 : ' + CONVERT(varchar(20), GETDATE(), 120) + CHAR(10)
SET @query = @query + ' 설    명 : ' + @TableName + ' Table 저장 ' + CHAR(10)
SET @query = @query + ' 샘플실행 : EXEC ' + @schema + '.' + @ProcedureName + CHAR(10) + CHAR(10)
SET @query = @query + ' 변경이력 : ' + CHAR(10)
SET @query = @query + '=============================================================================================='+ CHAR(10)
SET @query = @query + '*/ '+ CHAR(10)
SET @query = @query + 'CREATE PROCEDURE ' + @schema + '.' + @ProcedureName + CHAR(10)
SET @query = @query + '	@' + @ParamTypeList + CHAR(10)
SET @query = @query + 'AS' + CHAR(10)
SET @query = @query + 'BEGIN TRY' + CHAR(10)
SET @query = @query + '	BEGIN TRANSACTION' + CHAR(10)
SET @query = @query + '	MERGE ' + @schema + '.' + @TableName + ' AS A' + CHAR(10)
SET @query = @query + '	USING (SELECT COUNT(1) CNT FROM ' + @schema + '.' + @TableName + ' WITH(NOLOCK)' + CHAR(10)
SET @query = @query + '	WHERE ' + @WhereCondition + ') B' + CHAR(10)
SET @query = @query + '	ON B.CNT >= 0' + CHAR(10)
SET @query = @query + '	AND ' + @MergeWhereCondition + CHAR(10)
SET @query = @query + '	WHEN MATCHED THEN' + CHAR(10)
SET @query = @query + '		UPDATE ' + CHAR(10)
SET @query = @query + '		SET ' + @SetList + CHAR(10)
SET @query = @query + '	WHEN NOT MATCHED THEN' + CHAR(10)
SET @query = @query + '		INSERT ( ' + @ColumnList + ' ) ' + CHAR(10)
SET @query = @query + '		VALUES ( @' + @ParamList + ' ) ;' + CHAR(10)
SET @query = @query + '	COMMIT TRANSACTION' + CHAR(10)
SET @query = @query + 'END TRY' + CHAR(10)
SET @query = @query + 'BEGIN CATCH' + CHAR(10)
SET @query = @query + '	DECLARE @ErrorMessage NVARCHAR(4000) ' + CHAR(10)
SET @query = @query + '	DECLARE @ErrorSeverity INT' + CHAR(10)
SET @query = @query + '	DECLARE @ErrorState INT' + CHAR(10)
SET @query = @query + '	SELECT @ErrorMessage = ''' + @schema + '.' + @ProcedureName + ' : '' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() ' + CHAR(10)
SET @query = @query + '	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) ' + CHAR(10)
SET @query = @query + '	IF @@TRANCOUNT > 0' + CHAR(10)
SET @query = @query + '		ROLLBACK TRANSACTION;' + CHAR(10)
SET @query = @query + 'END CATCH' + CHAR(10)

PRINT @query

GO
/****** Object:  StoredProcedure [dbo].[MakeSaveProcedure]    Script Date: 2024-08-19 오후 7:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*
===================================================================================
 작 성 자: 오인봉
 작 성 일: 2017.07.20
 설    명: Save Procedure 생성
 샘플실행: EXEC MakeSaveProcedure 'ScreenColumnSet'
 변경이력: 2017.07.20 SP최초작성
===================================================================================
*/

CREATE PROCEDURE [dbo].[MakeSaveProcedure]
	@TableName				VARCHAR(100),
	@ProcedureName			VARCHAR(100) = ''	
AS

DECLARE @query				VARCHAR(MAX),
		@schema				VARCHAR(50),
		@ParamTypeList		VARCHAR(MAX),
		@ColumnList			VARCHAR(MAX),
		@ParamList			VARCHAR(MAX),
		@WhereCondition		VARCHAR(MAX),
		@SetList			VARCHAR(MAX),
		@index_id			INT,
		@rowCnt				INT

IF NOT EXISTS(SELECT object_id FROM sys.Tables WHERE Name = @TableName)
BEGIN
	PRINT '해당 테이블이 존재하지 않습니다.'
	RETURN (0)
END


IF @ProcedureName = ''
	SET @ProcedureName = @TableName + '_Save'

SELECT @schema = name FROM sys.schemas
WHERE schema_id = (SELECT schema_id FROM sys.Tables WHERE name = @TableName)


--저장에서 사용할 ColumnList와 ParamList를 만들어준다.(IDENTITY 열을 빼고 만든다.)
SELECT  @ColumnList = COALESCE(@ColumnList +', ', '') + sc.Name,
		@ParamList = COALESCE(@ParamList +', @', '') + sc.Name
FROM sys.Columns AS sc
WHERE object_id IN (SELECT object_id FROM sys.Tables WHERE Name = @TableName) 
	AND is_identity = 0

--SP Parameter에 사용할 Param 명과 Param Type을 만들어준다.
SELECT  @ParamTypeList = ISNULL(@ParamTypeList, '') + sc.Name + ' ' + 
		CASE (SELECT name FROM sys.types WHERE system_type_id = sc.system_type_id AND user_type_id = sc.user_type_id)
		WHEN 'CHAR' THEN  (SELECT name FROM sys.types WHERE system_type_id = sc.system_type_id AND user_type_id = sc.user_type_id) + '(' + cast(sc.max_length as varchar(4)) + ')' + CASE WHEN (@@ROWCOUNT > ROW_NUMBER() OVER(ORDER BY sc.column_id)) THEN (',' + CHAR(10) + '	@') ELSE '' END
		WHEN 'VARCHAR' THEN  (SELECT name FROM sys.types WHERE system_type_id = sc.system_type_id AND user_type_id = sc.user_type_id) + '(' + cast(sc.max_length as varchar(4)) + ')' + CASE WHEN (@@ROWCOUNT > ROW_NUMBER() OVER(ORDER BY sc.column_id)) THEN (',' + CHAR(10) + '	@') ELSE '' END
		WHEN 'VARBINARY' THEN  (SELECT name FROM sys.types WHERE system_type_id = sc.system_type_id AND user_type_id = sc.user_type_id) + '(' + cast(sc.max_length as varchar(4)) + ')' + CASE WHEN (@@ROWCOUNT > ROW_NUMBER() OVER(ORDER BY sc.column_id)) THEN (',' + CHAR(10) + '	@') ELSE '' END
		WHEN 'NCHAR' THEN  (SELECT name FROM sys.types WHERE system_type_id = sc.system_type_id AND user_type_id = sc.user_type_id) + '(' + cast(sc.max_length/2 as varchar(4)) + ')' + CASE WHEN (@@ROWCOUNT > ROW_NUMBER() OVER(ORDER BY sc.column_id)) THEN (',' + CHAR(10) + '	@') ELSE '' END
		WHEN 'NVARCHAR' THEN  (SELECT name FROM sys.types WHERE system_type_id = sc.system_type_id AND user_type_id = sc.user_type_id) + '(' + cast(sc.max_length/2 as varchar(4)) + ')' + CASE WHEN (@@ROWCOUNT > ROW_NUMBER() OVER(ORDER BY sc.column_id)) THEN (',' + CHAR(10) + '	@') ELSE '' END
		WHEN 'DECIMAL' THEN  (SELECT name FROM sys.types WHERE system_type_id = sc.system_type_id AND user_type_id = sc.user_type_id) + '(' + cast(sc.precision as varchar(4)) + ', ' + cast(sc.scale as varchar(4)) + ')' + CASE WHEN (@@ROWCOUNT > ROW_NUMBER() OVER(ORDER BY sc.column_id)) THEN (',' + CHAR(10) + '	@') ELSE '' END
		WHEN 'NUMERIC' THEN  (SELECT name FROM sys.types WHERE system_type_id = sc.system_type_id AND user_type_id = sc.user_type_id) + '(' + cast(sc.precision as varchar(4)) + ', ' + cast(sc.scale as varchar(4)) + ')' + CASE WHEN (@@ROWCOUNT > ROW_NUMBER() OVER(ORDER BY sc.column_id)) THEN (',' + CHAR(10) + '	@') ELSE '' END
		WHEN 'DATETIME' THEN  (SELECT name FROM sys.types WHERE system_type_id = sc.system_type_id AND user_type_id = sc.user_type_id) + CASE WHEN (@@ROWCOUNT > ROW_NUMBER() OVER(ORDER BY sc.column_id)) THEN (',' + CHAR(10) + '	@') ELSE '' END
		ELSE (SELECT name FROM sys.types WHERE system_type_id = sc.system_type_id AND user_type_id = sc.user_type_id) + CASE WHEN (@@ROWCOUNT > sc.column_id) THEN (',' + CHAR(10) + '	@') ELSE  '' END
		END
FROM sys.Columns AS sc
WHERE object_id IN (SELECT object_id FROM sys.Tables WHERE Name = @TableName) 
	AND is_identity = 0

SELECT @rowCnt = COUNT(column_id)
FROM sys.Columns AS sc
WHERE object_id IN (SELECT object_id FROM sys.Tables WHERE Name = @TableName) 
	AND column_id NOT IN (SELECT colid FROM sysIndexkeys 
						  WHERE id = (SELECT object_id FROM sys.indexes AS sc
									  WHERE object_id IN (SELECT object_id FROM sys.Tables
									 					  WHERE Name = @TableName AND is_primary_key = 1)))

--UPDATE 문에서 사용할 SET 절을 만들어준다.
SELECT  @SetList =  ISNULL(@SetList, '') + sc.Name + ' = @' + sc.Name + 
		CASE WHEN (@rowCnt > ROW_NUMBER() OVER(ORDER BY sc.column_id)) THEN (CHAR(10) + '		  , ') ELSE '' END
FROM sys.Columns AS sc
WHERE object_id IN (SELECT object_id FROM sys.Tables
					WHERE Name = @TableName) AND column_id NOT IN (SELECT colid FROM sysIndexkeys
																   WHERE id = (SELECT object_id FROM sys.indexes AS sc
																			   WHERE object_id IN (SELECT object_id FROM sys.Tables
																								   WHERE Name = @TableName AND is_primary_key = 1)))

--PRIMARY KEY Index를 변수에 저장한다.
SELECT @index_id = index_id
FROM sys.indexes AS sc
WHERE object_id IN (SELECT object_id FROM sys.Tables
					WHERE Name = @TableName) AND is_primary_key = 1

SELECT @rowCnt = COUNT(column_id)
FROM sys.Columns AS sc
WHERE object_id IN (SELECT object_id FROM sys.Tables
					WHERE Name = @TableName) AND column_id IN (SELECT colid FROM sysIndexkeys
															   WHERE id = (SELECT object_id FROM sys.indexes AS sc
																		   WHERE object_id IN (SELECT object_id FROM sys.Tables
																							   WHERE Name = @TableName AND is_primary_key = 1 and indid = @index_id)))

--WHERE 절을 만들어 준다.
SELECT  @WhereCondition = ISNULL(@WhereCondition, '') + sc.Name + ' = @' + sc.Name + 
		CASE WHEN (@rowCnt > ROW_NUMBER() OVER(ORDER BY sc.column_id)) THEN ' AND ' ELSE '' END
FROM sys.Columns AS sc
WHERE object_id IN (SELECT object_id FROM sys.Tables
					WHERE Name = @TableName) AND column_id IN (SELECT colid FROM sysIndexkeys
															   WHERE id = (SELECT object_id FROM sys.indexes AS sc
																		   WHERE object_id IN (SELECT object_id FROM sys.Tables
																							   WHERE Name = @TableName AND is_primary_key = 1 and indid = @index_id)))

--실제 수행할 PROCEDURE 를 만든다.
SET @query = '/* '+ CHAR(10)
SET @query = @query + '=============================================================================================='+ CHAR(10)
SET @query = @query + ' 작 성 자 : ' + CHAR(10)
SET @query = @query + ' 작 성 일 : ' + CONVERT(varchar(20), GETDATE(), 120) + CHAR(10)
SET @query = @query + ' 설    명 : ' + @TableName + ' Table 저장 ' + CHAR(10)
SET @query = @query + ' 샘플실행 : EXEC ' + @schema + '.' + @ProcedureName + CHAR(10) + CHAR(10)
SET @query = @query + ' 변경이력 : ' + CHAR(10)
SET @query = @query + '=============================================================================================='+ CHAR(10)
SET @query = @query + '*/ '+ CHAR(10)
SET @query = @query + 'CREATE PROCEDURE ' + @schema + '.' + @ProcedureName + CHAR(10)
SET @query = @query + '	@' + @ParamTypeList + CHAR(10)
SET @query = @query + 'AS' + CHAR(10)
SET @query = @query + 'BEGIN TRY' + CHAR(10)
SET @query = @query + '	BEGIN TRANSACTION' + CHAR(10)
SET @query = @query + '	IF NOT EXISTS (SELECT 1 FROM ' + @schema + '.' + @TableName + ' WITH(NOLOCK) WHERE ' + @WhereCondition + ') '+ CHAR(10)
SET @query = @query + '	BEGIN ' + CHAR(10)
SET @query = @query + '		INSERT INTO ' + @schema + '.' + @TableName + ' ( ' + @ColumnList + ') ' + CHAR(10)
SET @query = @query + '		VALUES ( @' + @ParamList + ' ) ' + CHAR(10)
SET @query = @query + '	END ' + CHAR(10)
SET @query = @query + '	ELSE ' + CHAR(10)
SET @query = @query + '	BEGIN ' + CHAR(10)
SET @query = @query + '		UPDATE ' + @schema + '.' + @TableName + CHAR(10)
SET @query = @query + '		SET ' + @SetList + CHAR(10)
SET @query = @query + '		WHERE ' + @WhereCondition + CHAR(10)
SET @query = @query + '	END ' + CHAR(10)
SET @query = @query + '	COMMIT TRANSACTION' + CHAR(10)
SET @query = @query + 'END TRY' + CHAR(10)
SET @query = @query + 'BEGIN CATCH' + CHAR(10)
SET @query = @query + '	DECLARE @ErrorMessage NVARCHAR(4000) ' + CHAR(10)
SET @query = @query + '	DECLARE @ErrorSeverity INT' + CHAR(10)
SET @query = @query + '	DECLARE @ErrorState INT' + CHAR(10)
SET @query = @query + '	SELECT @ErrorMessage = ''' + @schema + '.' + @ProcedureName + ' : '' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() ' + CHAR(10)
SET @query = @query + '	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) ' + CHAR(10)
SET @query = @query + '	IF @@TRANCOUNT > 0' + CHAR(10)
SET @query = @query + '		ROLLBACK TRANSACTION;' + CHAR(10)
SET @query = @query + 'END CATCH' + CHAR(10)

PRINT @query


GO
/****** Object:  StoredProcedure [dbo].[MakeSelectProcedure]    Script Date: 2024-08-19 오후 7:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*
===================================================================================
 작 성 자: 오인봉
 작 성 일: 2017.07.20
 설    명: Select Procedure 생성
 샘플실행: EXEC dbo.MakeSelectProcedure 'TableName'
 변경이력: 2017.07.20 SP최초작성
===================================================================================
*/

CREATE PROCEDURE [dbo].[MakeSelectProcedure]
	@TableName				VARCHAR(100),
	@ProcedureName			VARCHAR(100) = ''		
AS

DECLARE @query				VARCHAR(MAX),
		@schema				VARCHAR(50),
		@ParamTypeList		VARCHAR(MAX),
		@ColumnList			VARCHAR(MAX),
		@ParamList			VARCHAR(MAX),
		@WhereCondition		VARCHAR(MAX),
		@SetList			VARCHAR(MAX),
		@index_id			INT,
		@rowCnt				INT,
		@WhereList			VARCHAR(MAX),
		@object_id			VARCHAR(100)


IF NOT EXISTS(SELECT object_id FROM sys.Tables WHERE Name = @TableName)
BEGIN
	PRINT '해당 테이블이 존재하지 않습니다.'
	RETURN (0)
END

IF @ProcedureName = ''
	SET @ProcedureName = @TableName + '_Select'


SELECT @schema = name FROM sys.schemas
WHERE schema_id = (SELECT schema_id FROM sys.Tables
WHERE name = @TableName)

SELECT @object_id = object_id FROM sys.Tables where name = @TableName 


--저장에서 사용할 ColumnList와 ParamList를 만들어준다.(IDENTITY 열을 빼고 만든다.)
SELECT	@ColumnList = COALESCE(@ColumnList + '	 , ', '') + 'A.'+ sc.Name + CHAR(10),
		@WhereList = COALESCE(@WhereList +' = '''' AND ', '') + 'A.'+ sc.Name
FROM sys.Columns AS sc
WHERE object_id = @object_id
	AND is_identity = 0

--SP Parameter에 사용할 Param 명과 Param Type을 만들어준다.
SELECT	@ParamTypeList = ISNULL(@ParamTypeList, '') + sc.Name + ' ' + 
		CASE (SELECT name FROM sys.types WHERE system_type_id = sc.system_type_id AND user_type_id = sc.user_type_id)
		WHEN 'char' THEN  (SELECT name FROM sys.types WHERE system_type_id = sc.system_type_id AND user_type_id = sc.user_type_id) + '(' + cast(sc.max_length as varchar(4)) + ')' + CASE WHEN (@@ROWCOUNT > ROW_NUMBER() OVER(ORDER BY sc.column_id)) THEN (',' + CHAR(10) + '	@') ELSE '' END
		WHEN 'varchar' THEN  (SELECT name FROM sys.types WHERE system_type_id = sc.system_type_id AND user_type_id = sc.user_type_id) + '(' + cast(sc.max_length as varchar(4)) + ')' + CASE WHEN (@@ROWCOUNT > ROW_NUMBER() OVER(ORDER BY sc.column_id)) THEN (',' + CHAR(10) + '	@') ELSE '' END
		WHEN 'varbinary' THEN  (SELECT name FROM sys.types WHERE system_type_id = sc.system_type_id AND user_type_id = sc.user_type_id) + '(' + cast(sc.max_length as varchar(4)) + ')' + CASE WHEN (@@ROWCOUNT > ROW_NUMBER() OVER(ORDER BY sc.column_id)) THEN (',' + CHAR(10) + '	@') ELSE '' END
		WHEN 'nchar' THEN  (SELECT name FROM sys.types WHERE system_type_id = sc.system_type_id AND user_type_id = sc.user_type_id) + '(' + cast(sc.max_length/2 as varchar(4)) + ')' + CASE WHEN (@@ROWCOUNT > ROW_NUMBER() OVER(ORDER BY sc.column_id)) THEN (',' + CHAR(10) + '	@') ELSE '' END
		WHEN 'nvarchar' THEN  (SELECT name FROM sys.types WHERE system_type_id = sc.system_type_id AND user_type_id = sc.user_type_id) + '(' + cast(sc.max_length/2 as varchar(4)) + ')' + CASE WHEN (@@ROWCOUNT > ROW_NUMBER() OVER(ORDER BY sc.column_id)) THEN (',' + CHAR(10) + '	@') ELSE '' END
		WHEN 'decimal' THEN  (SELECT name FROM sys.types WHERE system_type_id = sc.system_type_id AND user_type_id = sc.user_type_id) + '(' + cast(sc.precision as varchar(4)) + ', ' + cast(sc.scale as varchar(4)) + ')' + CASE WHEN (@@ROWCOUNT > ROW_NUMBER() OVER(ORDER BY sc.column_id)) THEN (',' + CHAR(10) + '	@') ELSE '' END
		WHEN 'numeric' THEN  (SELECT name FROM sys.types WHERE system_type_id = sc.system_type_id AND user_type_id = sc.user_type_id) + '(' + cast(sc.precision as varchar(4)) + ', ' + cast(sc.scale as varchar(4)) + ')' + CASE WHEN (@@ROWCOUNT > ROW_NUMBER() OVER(ORDER BY sc.column_id)) THEN (',' + CHAR(10) + '	@') ELSE '' END
		WHEN 'datetime' THEN  (SELECT name FROM sys.types WHERE system_type_id = sc.system_type_id AND user_type_id = sc.user_type_id) + CASE WHEN (@@ROWCOUNT > ROW_NUMBER() OVER(ORDER BY sc.column_id)) THEN (',' + CHAR(10) + '	@') ELSE '' END
		ELSE (SELECT name FROM sys.types WHERE system_type_id = sc.system_type_id AND user_type_id = sc.user_type_id) + CASE WHEN (@@ROWCOUNT > sc.column_id) THEN (',' + CHAR(10) + '	@') ELSE '' END
		END
FROM sys.Columns AS sc
WHERE object_id = @object_id
	AND is_identity = 0

SELECT @rowCnt = COUNT(column_id)
FROM sys.Columns AS sc
WHERE object_id = @object_id
	AND column_id NOT IN (SELECT colid FROM sysIndexkeys
						  WHERE id = (SELECT object_id FROM sys.indexes AS sc
									  WHERE object_id IN (SELECT object_id FROM sys.Tables
														  WHERE Name = @TableName AND is_primary_key = 1)))


--PRIMARY KEY Index를 변수에 저장한다.
SELECT @index_id = index_id
FROM sys.indexes AS sc
WHERE object_id = @object_id
	AND is_primary_key = 1


----WHERE 절을 만들어 준다.
SELECT  @WhereCondition = ISNULL(@WhereCondition, '') + 'A.' + sc.Name + ' = @' + sc.Name + 
		CASE WHEN (@rowCnt > ROW_NUMBER() OVER(ORDER BY sc.column_id)) THEN ' AND ' ELSE '' END
FROM sys.Columns AS sc
WHERE object_id = @object_id
AND column_id IN (SELECT colid FROM sysIndexkeys
				  WHERE id = (SELECT object_id FROM sys.indexes AS sc
								WHERE object_id IN ( SELECT object_id FROM sys.Tables 
													 WHERE Name = @TableName AND is_primary_key = 1 AND indid = @index_id
												   )
							 )
				 )



--실제 수행할 PROCEDURE 를 만든다.
SET @query = '/* '+ CHAR(10)
SET @query = @query + '=============================================================================================='+ CHAR(10)
SET @query = @query + ' 작 성 자 : ' + CHAR(10)
SET @query = @query + ' 작 성 일 : ' + CONVERT(varchar(20), GETDATE(), 120) + CHAR(10)
SET @query = @query + ' 설    명 : ' + @TableName + 'Table 조회 ' + CHAR(10)
SET @query = @query + ' 샘플실행 : EXEC ' + @schema + '.' +  @ProcedureName + CHAR(10) + CHAR(10)
SET @query = @query + ' 변경이력 : ' + CHAR(10)
SET @query = @query + '=============================================================================================='+ CHAR(10)
SET @query = @query + '*/ '+ CHAR(10)
SET @query = @query + 'CREATE PROCEDURE ' + @schema + '.' +  @ProcedureName + CHAR(10)
SET @query = @query + '	@' + @ParamTypeList + CHAR(10)
SET @query = @query + 'AS' + CHAR(10)

SET @query = @query + 'SELECT ' + @ColumnList 
SET @query = @query + '	 , ISNULL(A.UPDTTM, A.INITDTTM) CHANGEDTTM ' + CHAR(10)
SET @query = @query + '	 , ISNULL(A.UPBY, A.INITBY) CHANGEBY ' + CHAR(10)
SET @query = @query + 'FROM ' + @schema + '.' + @TableName + ' A WITH(NOLOCK) ' + CHAR(10)
SET @query = @query + 'WHERE ' + substring(@WhereCondition,1,len(@WhereCondition)-3) + CHAR(10)

PRINT @query


GO
/****** Object:  StoredProcedure [dbo].[MenuExecuteLog_Save]    Script Date: 2024-08-19 오후 7:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===============================================
-- 작성자: 오인봉
-- 작성일: 2017.01.09
-- 설   명: Menu Execute Log 저장
-- 샘플실행: EXEC MenuExecuteLog_Save '', '', '', '2017-11-03' 0
-- 변경이력: 
-- 2017.01.09 SP최초작성
-- 
-- ===============================================
CREATE Procedure [dbo].[MenuExecuteLog_Save]
	@VENDORCODE		varchar(10),
	@PLANTCODE		varchar(4),
	@MENUID			varchar(40),
	@STARTDTTM		datetime,
    @SIGNINSEQ		bigint
AS	
BEGIN TRY
	IF @SIGNINSEQ < 1 RETURN

	BEGIN TRANSACTION
		INSERT INTO [dbo].[MenuExecuteLog]
				( VENDORCODE,
				  PLANTCODE,
				  MENUID, 
				  EXETIME, 
				  SIGNINSEQ )
		VALUES
				( @VENDORCODE,
				  @PLANTCODE,
				  @MENUID,
				  @STARTDTTM,
				  @SIGNINSEQ )
	
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.MenuExecuteLog_Save : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH




GO
/****** Object:  StoredProcedure [dbo].[MenuExecuteLog_Select]    Script Date: 2024-08-19 오후 7:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2016-04-29 10:59:44
 설    명 : MenuExecuteLog Table 조회 
 샘플실행 : EXEC dbo.MenuExecuteLog_Select '7256', ''

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[MenuExecuteLog_Select]
	@SIGNINSEQ varchar(30),
	@OPERATION varchar(200)
AS
DECLARE @query NVARCHAR(MAX)

SET @query = N''
SET @query = @query + N'
WITH MenuLog
AS (
SELECT A.SEQ
	 , A.VENDORCODE
	 , A.PLANTCODE
	 , A.MENUID
	 , A.EXETIME
	 , ISNULL((SELECT MIN(EXETIME) FROM dbo.MenuExecuteLog WITH(NOLOCK) WHERE MENUID = A.MENUID AND SEQ > A.SEQ AND SIGNINSEQ = A.SIGNINSEQ), GETDATE()) ENDTIME
	 , A.SIGNINSEQ	   
FROM MenuExecuteLog A WITH(NOLOCK)
WHERE SIGNINSEQ = ' + @SIGNINSEQ + '  
)
SELECT A.SIGNINSEQ
	 , A.VENDORCODE
	 , A.PLANTCODE
	 , A.MENUID
	 , B.MENUNAME
	 , D.POPNAME
	 , A.EXETIME
	 , D.OPERATION
	 , CASE WHEN D.OPERATION IN (''SAVE'', ''DELETE'', ''UPLOAD'', ''INSPECT'', ''INSPECTDELETE'', ''DEFECT'') 
	 		THEN 1 ELSE 0 END OPERATIONTYPE
	 , ROUND(CAST(DATEDIFF(millisecond, D.STARTDTTM, D.ENDDTTM) as float) / 1000, 3) INTERVAL
	 , ISNULL(D.STARTDTTM, A.EXETIME) STARTDTTM
	 , ISNULL(D.ENDDTTM, GETDATE()) ENDDTTM
	 , DENSE_RANK() OVER (ORDER BY ISNULL(D.STARTDTTM, A.EXETIME)) USESEQ
FROM MenuLog A WITH(NOLOCK)
LEFT JOIN dbo.MenuMaster B WITH(NOLOCK)
ON A.MENUID = B.MENUID
LEFT JOIN dbo.OperationLog D WITH(NOLOCK)
ON A.SIGNINSEQ = D.SIGNINSEQ
AND A.MENUID = D.MENUID
AND D.STARTDTTM >= A.EXETIME
AND D.ENDDTTM <= A.ENDTIME
WHERE 1 = 1 
AND D.OPERATION IS NOT NULL '

IF @OPERATION <> N''
	SET @query = @query + N'
		AND D.OPERATION IN ( ' + dbo.fnGetListParam(@OPERATION) + ' ) '

SET @query = @query + N'
ORDER BY A.EXETIME DESC, D.STARTDTTM DESC '

--PRINT, 실행
PRINT @query
EXECUTE sp_executesql @query


GO
/****** Object:  StoredProcedure [dbo].[MenuOprationLog_Select]    Script Date: 2024-08-19 오후 7:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2018-01-21 10:54:58
 설    명 : Menu Execute Log Table 조회 
 샘플실행 : EXEC dbo.MenuOprationLog_Select '', '', '2019-04-03', '2019-04-04', '', '', ''

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[MenuOprationLog_Select]
	@USERID			varchar(50),
	@USERNAME		nvarchar(40),
	@STARTTIME		datetime,
	@ENDTIME		datetime,
	@MENUID  		varchar(12),
	@MENUNAME  		nvarchar(50),
	@OPERATION		varchar(200),
	@VENDORCODE		VARCHAR(20) = ''
AS
DECLARE @query NVARCHAR(MAX)

SET @query = N''
SET @query = @query + N'
WITH MenuLog
AS (
SELECT A.SEQ
	 , A.VENDORCODE
	 , A.PLANTCODE
	 , A.MENUID
	 , A.EXETIME
	 , ISNULL((SELECT MIN(EXETIME) FROM dbo.MenuExecuteLog WITH(NOLOCK) WHERE MENUID = A.MENUID AND SEQ > A.SEQ AND SIGNINSEQ = A.SIGNINSEQ), GETDATE()) ENDTIME
	 , A.SIGNINSEQ	   
FROM MenuExecuteLog A WITH(NOLOCK)
WHERE 1 = 1
AND EXETIME BETWEEN ''' + dbo.fnGetDateString(@STARTTIME, 0) + '00:00:00'' AND ''' + dbo.fnGetDateString(@ENDTIME, 0) + '23:59:59'' 
), LASTUPDATE
AS
(
	SELECT MAX(CHANGEDTTM) UPDATEDTTM FROM FILEDB.dbo.EBAPDeployHistory WITH(NOLOCK)-- WHERE ISESSENTIAL = 1
)
SELECT A.SIGNINSEQ
	 , A.VENDORCODE
	 , A.PLANTCODE
	 , E.USERID
	 , F.USERNAME
	 , F.DEPTNAME
	 , A.MENUID
	 , B.MENUNAME
	 , D.POPNAME
	 , D.OPERATION
	 --, A.EXETIME
	 --, A.ENDTIME
	 , CASE WHEN D.OPERATION IN (''SAVE'', ''DELETE'', ''UPLOAD'', ''INSPECT'', ''INSPECTDELETE'', ''DEFECT'', ''CONFIRM'') 
	 		THEN 1 ELSE 0 END OPERATIONTYPE
	 , ROUND(CAST(DATEDIFF(millisecond, D.STARTDTTM, D.ENDDTTM) as float) / 1000, 3) INTERVAL
	 , ISNULL(D.STARTDTTM, A.EXETIME) STARTDTTM
	 , ISNULL(D.ENDDTTM, GETDATE()) ENDDTTM
	 , DENSE_RANK() OVER (PARTITION BY A.SIGNINSEQ ORDER BY A.SIGNINSEQ, ISNULL(D.STARTDTTM, A.EXETIME)) USESEQ
	 , E.SIGNINTIME, E.SIGNOFFTIME
	 , E.HOSTNAME
	 , E.IPADDRESS
	 , CASE WHEN E.SIGNINTIME > (SELECT UPDATEDTTM FROM LASTUPDATE) THEN ''Y'' ELSE '''' END LASTFLAG
FROM MenuLog A WITH(NOLOCK)
LEFT JOIN dbo.MenuMaster B WITH(NOLOCK)
ON A.MENUID = B.MENUID
LEFT JOIN dbo.OperationLog D WITH(NOLOCK)
ON A.SIGNINSEQ = D.SIGNINSEQ
AND A.MENUID = D.MENUID
AND D.STARTDTTM >= A.EXETIME
AND D.ENDDTTM <= A.ENDTIME
LEFT JOIN dbo.SignLog  E WITH(NOLOCK)
ON A.SIGNINSEQ = E.SIGNINSEQ
LEFT JOIN dbo.UserInfo F WITH(NOLOCK)
ON E.USERID = F.USERID
WHERE 1 = 1 
AND D.OPERATION IS NOT NULL '

IF @VENDORCODE <> N''
	SET @query = @query + N'
AND A.VENDORCODE = ''' + @VENDORCODE + ''' '

IF @USERID <> N''
	SET @query = @query + N'
AND E.USERID LIKE ''' + @USERID + '%'' '

IF @USERNAME <> N''
	SET @query = @query + N'
AND F.USERNAME LIKE ''' + @USERNAME + '%'' '

IF @MENUID <> N''
	SET @query = @query + N'
AND A.MENUID LIKE ''' + @MENUID + '%'' '

IF @MENUNAME <> N''
	SET @query = @query + N'
AND B.MENUNAME LIKE ''' + @MENUNAME + '%'' '

IF @OPERATION <> N''
	SET @query = @query + N'
AND D.OPERATION IN ( ' + dbo.fnGetListParam(@OPERATION) + ' ) '

SET @query = @query + N'
ORDER BY A.SIGNINSEQ DESC, A.EXETIME DESC, D.STARTDTTM DESC  '

--PRINT, 실행
PRINT @query
EXECUTE sp_executesql @query


GO
/****** Object:  StoredProcedure [dbo].[OperationLog_Save]    Script Date: 2024-08-19 오후 7:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2017-03-21 13:14:53
 설    명 : OperationLog Table 저장 
 샘플실행 : EXEC dbo.OperationLog_Save '', '', '', '', '', ''

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[OperationLog_Save]
	@MENUID nvarchar(20),
	@POPNAME varchar(50),
	@OPERATION nvarchar(50),
	@SIGNINSEQ int,
	@STARTDTTM datetime,
	@ENDDTTM datetime
AS
BEGIN TRY
	IF @SIGNINSEQ < 1 RETURN

	IF @OPERATION IN ('LOAD', 'LINK') RETURN

	IF @MENUID = 'TSM0109' AND @OPERATION = 'SAVE' RETURN

	BEGIN TRANSACTION

		INSERT INTO dbo.OperationLog ( MENUID, POPNAME, OPERATION, SIGNINSEQ, STARTDTTM, ENDDTTM) 
		VALUES ( @MENUID, @POPNAME, @OPERATION, @SIGNINSEQ, @STARTDTTM, @ENDDTTM ) 
	
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.OperationLog_Save : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH



GO
/****** Object:  StoredProcedure [dbo].[Schedule_Delete]    Script Date: 2024-08-19 오후 7:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2019-02-25 15:59:37
 설    명 : Schedule Table 삭제
 샘플실행 : EXEC dbo.Schedule_Delete 0

 변경이력 : 
==============================================================================================
*/ 
CREATE PROC [dbo].[Schedule_Delete]
	@SEQ int
AS
BEGIN TRY
	BEGIN TRANSACTION

		DELETE FROM dbo.Schedule
		WHERE SEQ = @SEQ

	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.Schedule_Delete : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH

GO
/****** Object:  StoredProcedure [dbo].[Schedule_Save]    Script Date: 2024-08-19 오후 7:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2019-02-25 15:57:38
 설    명 : Schedule Table 저장 
 샘플실행 : EXEC dbo.Schedule_Save

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[Schedule_Save]
	@SEQ int,
	@SUBJECT varchar(200),
	@CONTENTS varchar(1000),
	@INWORKER varchar(200),
	@STARTDATE date,
	@STARTTIME time,
	@ENDTIME time,
	@CHANGEBY varchar(50)
AS
BEGIN TRY
	BEGIN TRANSACTION
	IF NOT EXISTS (SELECT 1 FROM dbo.Schedule WITH(NOLOCK) WHERE SEQ = @SEQ) 
	BEGIN 
		INSERT INTO dbo.Schedule ( SUBJECT, CONTENTS, INWORKER, STARTDATE, STARTTIME, ENDTIME, CHANGEBY, CHANGEDTTM) 
		VALUES ( @SUBJECT, @CONTENTS, @INWORKER, @STARTDATE, @STARTTIME, @ENDTIME, @CHANGEBY, GETDATE() ) 
	END 
	ELSE 
	BEGIN 
		UPDATE dbo.Schedule
		SET SUBJECT = @SUBJECT
		  , CONTENTS = @CONTENTS
		  , INWORKER = @INWORKER
		  , STARTDATE = @STARTDATE
		  , STARTTIME = @STARTTIME
		  , ENDTIME = @ENDTIME
		  , CHANGEBY = @CHANGEBY
		  , CHANGEDTTM = GETDATE()
		WHERE SEQ = @SEQ
	END 
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.Schedule_Save : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH

GO
/****** Object:  StoredProcedure [dbo].[Schedule_Select]    Script Date: 2024-08-19 오후 7:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Schedule_Select]
	@STARTDTTM datetime,
	@ENDDTTM datetime
AS
DECLARE @query NVARCHAR(MAX)

SET @query = N''
SET @query = @query + N'
SELECT A.SEQ
	 , A.SUBJECT
	 , A.CONTENTS
	 , A.INWORKER
	 , A.STARTDATE
	 , A.STARTTIME
	 , A.ENDTIME
	 , A.CHANGEBY
	 , A.CHANGEDTTM
FROM dbo.Schedule A WITH(NOLOCK) 
WHERE 1 = 1 '

IF @STARTDTTM <> N'' AND @ENDDTTM <> N''
    SET @query = @query + N'
AND A.STARTDATE BETWEEN ''' + dbo.fnGetDateString(@STARTDTTM, 0) + ''' AND ''' + dbo.fnGetDateString(@ENDDTTM, 0) + ''' '

PRINT(@query)
EXEC(@query)
GO
/****** Object:  StoredProcedure [dbo].[SignLog_Save]    Script Date: 2024-08-19 오후 7:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===============================================
-- 작성자: 오인봉
-- 작성일: 2017.08.06
-- 설   명: Sign LOG 저장
-- 샘플실행: EXEC SignLog_Save 4, '', '', '', '', 'MES.NET', '', '', 0
-- 변경이력: 
-- 2017.08.06 SP최초작성
-- 
-- ===============================================
CREATE PROC [dbo].[SignLog_Save]
	@ORIGINALSEQ bigint,
	@VENDORCODE	nvarchar(10),
	@PLANTCODE  varchar(20),
	@USERID		varchar(50),
	@HOSTNAME	nvarchar(30),
	@OS			nvarchar(50),
	@MACADDRESS nvarchar(18),
	@IPADDRESS	nvarchar(15)
AS
IF @ORIGINALSEQ < 0 
BEGIN
	SELECT 0
	RETURN
END

IF @USERID = 'system'
BEGIN
	SELECT 0
	RETURN
END

IF @ORIGINALSEQ = 0			--신규등록이라면
BEGIN
	UPDATE dbo.SignLog
	SET SIGNOFFTIME = GETDATE()
	WHERE USERID = @USERID
	AND IPADDRESS = @IPADDRESS
	AND SIGNOFFTIME IS NULL

	--EXEC IAMDB.SSI.Employees_System_Info_SP @USERID, @VENDORCODE, '', '', '', '', @PLANTCODE, 'O', '', '', '', '', '', '', '', 'OkLogin'
	--EXEC IAMDB.SSI.Employees_System_Info_SP 'Z2180142', '0000000001', '', '', '', '', '1031', 'O', '', '', '', '', '', '', '', 'OkLogin'

	DECLARE @SIGNINSEQ bigint
	
	INSERT INTO dbo.SignLog 
			( VENDORCODE, PLANTCODE, USERID, SIGNINTIME, HOSTNAME, OS, MACADDRESS, IPADDRESS )
	VALUES
			( @VENDORCODE, @PLANTCODE, @USERID, GETDATE(), @HOSTNAME, @OS, @MACADDRESS, @IPADDRESS );

	SET @SIGNINSEQ = SCOPE_IDENTITY();
	
	SELECT @SIGNINSEQ
END
ELSE
BEGIN
	UPDATE dbo.SignLog
	SET SIGNOFFTIME = GETDATE()
	WHERE SIGNINSEQ = @ORIGINALSEQ

	SELECT 0
END

GO
/****** Object:  StoredProcedure [dbo].[SignLog_Select]    Script Date: 2024-08-19 오후 7:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2014-01-21 10:54:58
 설    명 : SignLogTable 조회 
 샘플실행 : EXEC dbo.SignLog_Select '', '', '2019-02-14', '2019-02-15', ''

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[SignLog_Select]
	@USERID			varchar(50),
	@USERNAME		nvarchar(40),
	@STARTTIME		datetime,
	@ENDTIME		datetime,
	@HOSTNAME		nvarchar(60)
AS
DECLARE @query NVARCHAR(MAX)

SET @query = N''
SET @query = @query + N'
WITH MENU
AS
(
	SELECT SIGNINSEQ, MAX(EXETIME) EXETIME FROM dbo.MenuExecuteLog WITH(NOLOCK)
	GROUP BY SIGNINSEQ
), LASTUPDATE
AS
(
	SELECT MAX(CHANGEDTTM) UPDATEDTTM FROM FILEDB.dbo.EBAPDeployHistory WITH(NOLOCK)
)
SELECT  A.SIGNINSEQ,
		A.USERID, 
		B.USERNAME,
		B.GRADENAME,
		B.DEPTNAME,
		A.SIGNINTIME, 
		ISNULL(A.SIGNOFFTIME, GETDATE()) SIGNOFFTIME, 
		--COALESCE((SELECT MAX(EXETIME) FROM dbo.MenuExecuteLog WITH(NOLOCK) WHERE SIGNINSEQ = A.SIGNINSEQ), A.SIGNOFFTIME, GETDATE()) LASTMENUEXETIME,
		COALESCE(C.EXETIME, A.SIGNOFFTIME, GETDATE()) LASTMENUEXETIME,
		DATEDIFF(MINUTE, A.SIGNINTIME, ISNULL(A.SIGNOFFTIME, GETDATE())) DUEMINUTE,
		CASE WHEN A.SIGNOFFTIME IS NULL THEN ''ON'' ELSE ''OFF'' END LOGONSTATUS,
		A.HOSTNAME, 
		A.OS, 
		A.MACADDRESS, 
		A.IPADDRESS, 
		A.VENDORCODE, 
		A.PLANTCODE,
		CASE WHEN A.SIGNINTIME > (SELECT UPDATEDTTM FROM LASTUPDATE) THEN ''Y'' ELSE '''' END LASTFLAG
FROM dbo.SignLog AS A WITH(NOLOCK)
LEFT JOIN dbo.UserInfo AS B WITH(NOLOCK)
ON A.USERID = B.USERID 
LEFT JOIN MENU C WITH(NOLOCK)
ON A.SIGNINSEQ = C.SIGNINSEQ
WHERE 1 = 1 '

IF @USERID <> N''
	SET @query = @query + N'
AND A.USERID LIKE ''' + @USERID + '%'' '

IF @USERNAME <> N''
	SET @query = @query + N'
AND B.USERNAME LIKE ''' + @USERNAME + '%'' '

IF @STARTTIME <> N'' AND @ENDTIME <> N''
	SET @query = @query + N'
AND A.SIGNINTIME BETWEEN ''' + CONVERT(VARCHAR, @STARTTIME, 121) + ''' AND ''' + CONVERT(VARCHAR, @ENDTIME, 121) + ''' '

IF @HOSTNAME <> N''
	SET @query = @query + N'
AND A.HOSTNAME LIKE ''' + @HOSTNAME + '%'' '


SET @query = @query + N'
ORDER BY A.SIGNINSEQ DESC '


--PRINT, 실행
PRINT @query
EXECUTE sp_executesql @query


GO
/****** Object:  StoredProcedure [dbo].[UseLog_Save]    Script Date: 2024-08-19 오후 7:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2016-05-25 10:20:54
 설    명 : UseLog Table 저장 
 샘플실행 : EXEC dbo.UseLog_Save

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[UseLog_Save]
	@VENDORCODE	nvarchar(10),
	@PLANTCODE varchar(4),
	@SIGNINSEQ int,
	@METHODNAME varchar(50),
	@QUERYID varchar(500),
	@STARTDTTM datetime,
	@ENDDTTM datetime
AS
BEGIN TRY
	IF @SIGNINSEQ < 1 RETURN

	BEGIN TRANSACTION
			
		INSERT INTO dbo.UseLog ( VENDORCODE, PLANTCODE, SIGNINSEQ, METHODNAME, QUERYID, STARTDTTM, ENDDTTM) 
		VALUES ( @VENDORCODE, @PLANTCODE, @SIGNINSEQ, @METHODNAME, @QUERYID, @STARTDTTM, @ENDDTTM ) 

	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.UseLog_Save : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH

GO
/****** Object:  StoredProcedure [dbo].[UseLog_Select]    Script Date: 2024-08-19 오후 7:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UseLog_Select]
	@METHODNAME varchar(50),
	@QUERYID varchar(80),
	@STARTDTTM datetime,
	@ENDDTTM datetime
AS
DECLARE @query NVARCHAR(MAX)

SET @query = N''
SET @query = @query + N'
SELECT  A.VENDORCODE,
		A.PLANTCODE,
		B.USERID,
		C.USERNAME,
		A.METHODNAME, 
		A.QUERYID, 
		A.STARTDTTM, 
		A.ENDDTTM, 
		ROUND(CAST(DATEDIFF(millisecond, A.STARTDTTM, A.ENDDTTM) as float) / 1000, 3) INTERVAL
FROM dbo.UseLog A WITH(NOLOCK) 
LEFT JOIN dbo.SignLog B WITH(NOLOCK)
ON A.SIGNINSEQ = B.SignInSeq
LEFT JOIN dbo.UserInfo C WITH(NOLOCK)
ON B.USERID = C.USERID
WHERE 1 = 1 
AND B.USERID IS NOT NULL'

IF @METHODNAME <> N''
	SET @query = @query + N'
AND A.METHODNAME LIKE ''' + @METHODNAME + '%'' '

IF @QUERYID <> N''
	SET @query = @query + N'
AND A.QUERYID LIKE ''' + @QUERYID + '%'' '

IF @STARTDTTM <> N'' AND @ENDDTTM <> N''
	SET @query = @query + N'
AND A.USEDATE BETWEEN ''' + dbo.fnGetDateString(@STARTDTTM, 120) + ''' AND ''' + dbo.fnGetDateString(@ENDDTTM, 120) + ''' '

SET @query = @query + N'
ORDER BY SEQ DESC '


--PRINT, 실행
PRINT @query
EXECUTE sp_executesql @query



GO
/****** Object:  DdlTrigger [DatabaseTriggerLog]    Script Date: 2024-08-19 오후 7:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE TRIGGER [DatabaseTriggerLog]
ON DATABASE 
FOR DDL_DATABASE_LEVEL_EVENTS 
AS 
BEGIN
    SET NOCOUNT ON;

    DECLARE @data XML;
    DECLARE @schema sysname;
    DECLARE @object sysname;
    DECLARE @objecType nvarchar(50);
	DECLARE @eventType sysname;
	DECLARE @TSQL nvarchar(max);
	
    SET @data = EVENTDATA();
    SET @eventType = @data.value('(/EVENT_INSTANCE/EventType)[1]', 'sysname');
    SET @schema = @data.value('(/EVENT_INSTANCE/SchemaName)[1]', 'sysname');
    SET @object = @data.value('(/EVENT_INSTANCE/ObjectName)[1]', 'sysname');
	SET @objecType = @data.value('(/EVENT_INSTANCE/ObjectType)[1]', 'nvarchar(50)');
	SET @TSQL = @data.value('(/EVENT_INSTANCE/TSQLCommand)[1]', 'nvarchar(max)');


    IF @object IS NOT NULL
        PRINT '  [' + @eventType + '] ::::: ' + @schema + '.' + @object;
    ELSE
        PRINT '  [' + @eventType + '] ::::: ' + @schema;

    IF @eventType IS NULL
        PRINT CONVERT(nvarchar(max), @data);

    INSERT [LOGDB].[dbo].[DatabaseLog] 
        (
        [PostTime], 
        [DatabaseUser], 
        [Event], 
		[Database],
        [Schema], 
        [Object], 
		[ObjectType],
        [TSQL]
        ) 
    VALUES 
        (
        GETDATE(), 
        CONVERT(sysname, CURRENT_USER), 
        @eventType, 
		DB_NAME(),
        CONVERT(sysname, @schema), 
        CONVERT(sysname, @object), 
		@objecType,
        @TSQL
        );
END;
GO
ENABLE TRIGGER [DatabaseTriggerLog] ON DATABASE
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SEQ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DatabaseLog', @level2type=N'COLUMN',@level2name=N'DatabaseLogID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'실행시간' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DatabaseLog', @level2type=N'COLUMN',@level2name=N'PostTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'DB 사용자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DatabaseLog', @level2type=N'COLUMN',@level2name=N'DatabaseUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'이벤트' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DatabaseLog', @level2type=N'COLUMN',@level2name=N'Event'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'스키마' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DatabaseLog', @level2type=N'COLUMN',@level2name=N'Schema'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'오브젝트' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DatabaseLog', @level2type=N'COLUMN',@level2name=N'Object'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'오브젝트형식' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DatabaseLog', @level2type=N'COLUMN',@level2name=N'ObjectType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SQL문' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DatabaseLog', @level2type=N'COLUMN',@level2name=N'TSQL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SEQ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MenuExecuteLog', @level2type=N'COLUMN',@level2name=N'SEQ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'업체' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MenuExecuteLog', @level2type=N'COLUMN',@level2name=N'VENDORCODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'사업장' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MenuExecuteLog', @level2type=N'COLUMN',@level2name=N'PLANTCODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'메뉴ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MenuExecuteLog', @level2type=N'COLUMN',@level2name=N'MENUID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'실행시간' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MenuExecuteLog', @level2type=N'COLUMN',@level2name=N'EXETIME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'로그인SEQ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MenuExecuteLog', @level2type=N'COLUMN',@level2name=N'SIGNINSEQ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SEQ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OperationLog', @level2type=N'COLUMN',@level2name=N'SEQ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'메뉴 IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OperationLog', @level2type=N'COLUMN',@level2name=N'MENUID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'팝업창' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OperationLog', @level2type=N'COLUMN',@level2name=N'POPNAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'작업' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OperationLog', @level2type=N'COLUMN',@level2name=N'OPERATION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'로그인SEQ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OperationLog', @level2type=N'COLUMN',@level2name=N'SIGNINSEQ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'시작시간' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OperationLog', @level2type=N'COLUMN',@level2name=N'STARTDTTM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'종료시간' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OperationLog', @level2type=N'COLUMN',@level2name=N'ENDDTTM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SEQ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SignLog', @level2type=N'COLUMN',@level2name=N'SIGNINSEQ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'업체' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SignLog', @level2type=N'COLUMN',@level2name=N'VENDORCODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'사업장' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SignLog', @level2type=N'COLUMN',@level2name=N'PLANTCODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'사용자ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SignLog', @level2type=N'COLUMN',@level2name=N'USERID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'로그인시간' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SignLog', @level2type=N'COLUMN',@level2name=N'SIGNINTIME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'로그아웃시간' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SignLog', @level2type=N'COLUMN',@level2name=N'SIGNOFFTIME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PC 명' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SignLog', @level2type=N'COLUMN',@level2name=N'HOSTNAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'운영체제' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SignLog', @level2type=N'COLUMN',@level2name=N'OS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'MAC' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SignLog', @level2type=N'COLUMN',@level2name=N'MACADDRESS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SignLog', @level2type=N'COLUMN',@level2name=N'IPADDRESS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SEQ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UseLog', @level2type=N'COLUMN',@level2name=N'SEQ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'업체' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UseLog', @level2type=N'COLUMN',@level2name=N'VENDORCODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'사업장' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UseLog', @level2type=N'COLUMN',@level2name=N'PLANTCODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'로그인SEQ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UseLog', @level2type=N'COLUMN',@level2name=N'SIGNINSEQ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'사용 Method' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UseLog', @level2type=N'COLUMN',@level2name=N'METHODNAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'쿼리 ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UseLog', @level2type=N'COLUMN',@level2name=N'QUERYID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'시작시간' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UseLog', @level2type=N'COLUMN',@level2name=N'STARTDTTM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'종료시간' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UseLog', @level2type=N'COLUMN',@level2name=N'ENDDTTM'
GO
