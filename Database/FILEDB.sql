USE [FILEDB]
GO
/****** Object:  Synonym [dbo].[AuthGroupMenu]    Script Date: 2024-08-19 오후 7:11:06 ******/
CREATE SYNONYM [dbo].[AuthGroupMenu] FOR [METADB].[dbo].[AuthGroupMenu]
GO
/****** Object:  Synonym [dbo].[AuthGroupUser]    Script Date: 2024-08-19 오후 7:11:06 ******/
CREATE SYNONYM [dbo].[AuthGroupUser] FOR [METADB].[dbo].[AuthGroupUser]
GO
/****** Object:  Synonym [dbo].[fnGetDateList]    Script Date: 2024-08-19 오후 7:11:06 ******/
CREATE SYNONYM [dbo].[fnGetDateList] FOR [METADB].[dbo].[fnGetDateList]
GO
/****** Object:  Synonym [dbo].[MenuMaster]    Script Date: 2024-08-19 오후 7:11:06 ******/
CREATE SYNONYM [dbo].[MenuMaster] FOR [METADB].[dbo].[MenuMaster]
GO
/****** Object:  Synonym [dbo].[ScreenMaster]    Script Date: 2024-08-19 오후 7:11:06 ******/
CREATE SYNONYM [dbo].[ScreenMaster] FOR [METADB].[dbo].[ScreenMaster]
GO
/****** Object:  Table [dbo].[EBAPDeployHistory]    Script Date: 2024-08-19 오후 7:11:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EBAPDeployHistory](
	[SEQ] [bigint] IDENTITY(1,1) NOT NULL,
	[FILEID] [nvarchar](30) NOT NULL,
	[VERSION] [nvarchar](50) NULL,
	[SIZE] [int] NULL,
	[REASON] [nvarchar](300) NULL,
	[ISESSENTIAL] [bit] NULL,
	[IPADDRESS] [varchar](30) NULL,
	[CHANGEDTTM] [datetime] NULL,
	[CHANGEBY] [varchar](50) NULL,
 CONSTRAINT [PK_EBAPDeployHistory] PRIMARY KEY CLUSTERED 
(
	[SEQ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EBAPFileMaster]    Script Date: 2024-08-19 오후 7:11:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EBAPFileMaster](
	[FILEID] [varchar](50) NOT NULL,
	[FILENAME] [nvarchar](100) NULL,
	[FILEVERSION] [varchar](50) NULL,
	[DEPLOYCOUNT] [int] NULL,
	[ISCOMMON] [bit] NULL,
	[DESCRIPTION] [nvarchar](200) NULL,
	[LASTUPDTTM] [datetime] NULL,
	[INITDTTM] [datetime] NULL,
	[INITBY] [varchar](50) NULL,
	[UPDTTM] [datetime] NULL,
	[UPBY] [varchar](50) NULL,
 CONSTRAINT [PK_EBAPFileMaster] PRIMARY KEY CLUSTERED 
(
	[FILEID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FileContent]    Script Date: 2024-08-19 오후 7:11:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FileContent](
	[FILEID] [varchar](50) NOT NULL,
	[VERSION] [nvarchar](50) NULL,
	[FILECONTENT] [varbinary](max) NULL,
	[INITDTTM] [datetime] NULL,
	[INITBY] [varchar](50) NULL,
	[UPDTTM] [datetime] NULL,
	[UPBY] [varchar](50) NULL,
 CONSTRAINT [PK_FileContent] PRIMARY KEY CLUSTERED 
(
	[FILEID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FileDeployHistory]    Script Date: 2024-08-19 오후 7:11:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FileDeployHistory](
	[SEQ] [bigint] IDENTITY(1,1) NOT NULL,
	[FILEID] [varchar](30) NOT NULL,
	[SIZE] [int] NULL,
	[REASON] [nvarchar](300) NULL,
	[IPADDRESS] [varchar](30) NULL,
	[CHANGEDTTM] [datetime] NULL,
	[CHANGEBY] [varchar](50) NULL,
 CONSTRAINT [PK_FileDeployHistory] PRIMARY KEY CLUSTERED 
(
	[SEQ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FileMaster]    Script Date: 2024-08-19 오후 7:11:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FileMaster](
	[FILEID] [varchar](50) NOT NULL,
	[FILENAME] [nvarchar](100) NULL,
	[FILETYPE] [varchar](4) NULL,
	[DEPLOYCOUNT] [int] NULL,
	[DESCRIPTION] [nvarchar](200) NULL,
	[LASTUPDTTM] [datetime] NULL,
	[INITDTTM] [datetime] NULL,
	[INITBY] [varchar](50) NULL,
	[UPDTTM] [datetime] NULL,
	[UPBY] [varchar](50) NULL,
 CONSTRAINT [PK_FileMaster] PRIMARY KEY CLUSTERED 
(
	[FILEID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[EBAPDeployHistory_Save]    Script Date: 2024-08-19 오후 7:11:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===============================================
-- 작성자: 오인봉
-- 작성일: 2024.01.09
-- 설   명: EBAPDeploy History 저장
-- 샘플실행: EXEC EBAPDeployHistory_Save '', 0, '', '', '', 0, 'inbong.oh', '11.94.'
-- 변경이력: 
-- 2024.01.09 SP최초작성
-- 
-- ===============================================
CREATE PROC [dbo].[EBAPDeployHistory_Save]
	@FILEID NVARCHAR(30),
	@VERSION NVARCHAR(50),
	@SIZE INT,
	@FILECONTENT VARBINARY(MAX) = NULL,
	@REASON NVARCHAR(300),
	@ISESSENTIAL BIT,
	@CHANGEBY nvarchar(50),
	@IPADDRESS NVARCHAR(20)
AS
IF EXISTS (SELECT 1 FROM dbo.FileContent WITH(NOLOCK) WHERE FILEID = @FILEID)
BEGIN
	UPDATE dbo.FileContent
	SET FILECONTENT = @FILECONTENT,
		[VERSION] = @VERSION,
		UPDTTM = GETDATE(),
		UPBY = @CHANGEBY
	WHERE FILEID = @FILEID
END
ELSE
BEGIN
	INSERT INTO dbo.FileContent
	        ( FILEID, [VERSION], FILECONTENT, INITDTTM, INITBY )
	VALUES  ( @FILEID, @VERSION, @FILECONTENT, GETDATE(), @CHANGEBY ) 
END

UPDATE dbo.EBAPFileMaster
SET FILEVERSION = @VERSION,
	DEPLOYCOUNT = ISNULL(DEPLOYCOUNT, 0) + 1,
	LASTUPDTTM = GETDATE()
WHERE FILEID = @FILEID

INSERT INTO dbo.EBAPDeployHistory 
		(FILEID, 
		 [VERSION], 
		 SIZE,
		 REASON, 
		 ISESSENTIAL,
		 IPADDRESS,
		 CHANGEDTTM,
		 CHANGEBY )
VALUES  (@FILEID,
         @VERSION,
         @SIZE,
         @REASON,
         @ISESSENTIAL,
         @IPADDRESS,
		 GETDATE(),
		 @CHANGEBY )


GO
/****** Object:  StoredProcedure [dbo].[EBAPDeployHistory_Select]    Script Date: 2024-08-19 오후 7:11:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===============================================
-- 작성자: 오인봉
-- 작성일: 2024.01.03
-- 설   명: EBAP 배포 이력 조회
-- 샘플실행: EXEC dbo.EBAPDeployHistory_Select ''
-- 변경이력: 
-- 2024.01.03 SP최초작성
-- 
-- ===============================================
CREATE Procedure [dbo].[EBAPDeployHistory_Select]
	@FILEID varchar(10)
AS
DECLARE @query NVARCHAR(MAX)

SET @query = N''
SET @query = @query + N'
SELECT A.FILEID
	 , B.FILENAME
	 , A.VERSION
	 , CONCAT(FORMAT(A.SIZE / 1000, ''#,#''), '' KB'') SIZE
	 , A.REASON
	 , A.ISESSENTIAL
	 , METADB.dbo.fnGetUserName(A.CHANGEBY) AS DEPLOYWORKER
	 , A.IPADDRESS
	 , A.CHANGEDTTM 
FROM dbo.EBAPDeployHistory AS A WITH(NOLOCK)
JOIN dbo.EBAPFileMaster AS B WITH(NOLOCK) 
ON A.FILEID = B.FILEID 
WHERE 1 = 1 '

IF @FILEID <> ''
	SET @query = @query + 'AND A.FILEID = ''' + @FILEID + ''' ' + CHAR(10)
	
SET @query = @query + 'ORDER BY A.CHANGEDTTM DESC '

PRINT @query
EXECUTE sp_executesql @query

GO
/****** Object:  StoredProcedure [dbo].[EBAPDownloadList_Select]    Script Date: 2024-08-19 오후 7:11:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===============================================
-- 작성자: 오인봉
-- 작성일: 2024.01.03
-- 설   명: EBAP Download List 조회
-- 샘플실행: EXEC EBAPDownloadList_Select 'system'
-- 변경이력: 
-- 2024.01.03 SP최초작성
-- 
-- ===============================================
CREATE PROC [dbo].[EBAPDownloadList_Select]
	@USERID varchar(20) = ''
AS
IF @USERID = ''
BEGIN
	SELECT DISTINCT A.FILEID ASSEMBLYID
				 , B.FILENAME ASSEMBLYNAME
				 , A.[VERSION] ASSEMBLYVERSION
				 , B.DEPLOYCOUNT
				 , A.SIZE ASSEMBLYSIZE
				 , A.ISESSENTIAL
				 , A.REASON
	FROM FILEDB.dbo.EBAPDeployHistory AS A WITH(NOLOCK)
	JOIN FILEDB.dbo.EBAPFileMaster AS B WITH(NOLOCK)
	ON A.FILEID = B.FILEID
	JOIN FILEDB.dbo.FileContent AS D WITH(NOLOCK)
	ON A.FILEID = D.FILEID
	WHERE A.CHANGEDTTM = (
							SELECT MAX(CHANGEDTTM) FROM FILEDB.dbo.EBAPDeployHistory WITH(NOLOCK)
							WHERE A.FILEID = FILEID
						 )
END
ELSE
BEGIN
	SELECT DISTINCT A.FILEID ASSEMBLYID
				  , B.[FILENAME] ASSEMBLYNAME
				  , A.[VERSION] ASSEMBLYVERSION
				  , B.DEPLOYCOUNT
				  , A.SIZE ASSEMBLYSIZE
				  , A.ISESSENTIAL
				  , A.REASON
	FROM FILEDB.dbo.EBAPDeployHistory AS A WITH(NOLOCK)
	JOIN FILEDB.dbo.EBAPFileMaster AS B WITH(NOLOCK)
	ON A.FILEID = B.FILEID
	LEFT JOIN dbo.ScreenMaster AS C WITH(NOLOCK)
	ON B.[FILENAME] = C.DLLNAME
	LEFT JOIN dbo.MenuMaster AS M WITH(NOLOCK)
	ON C.SCREENID = M.SCREENID
	JOIN FILEDB.dbo.FileContent AS D WITH(NOLOCK)
	ON B.FILEID = D.FILEID
	WHERE 1 = 1
	AND A.CHANGEDTTM = (SELECT MAX(CHANGEDTTM) FROM FILEDB.dbo.EBAPDeployHistory WITH(NOLOCK)
						  WHERE A.FILEID = FILEID) AND (M.MENUID IN (SELECT MENUID 
																				FROM dbo.AuthGroupMenu A WITH(NOLOCK)
																				JOIN dbo.AuthGroupUser B WITH(NOLOCK)
																				ON A.GROUPCODE = B.GROUPCODE
																				WHERE 1 = 1
																				AND B.USERID = @USERID
																				AND B.[EXPIREDATE] >= GETDATE()
																				)
																OR B.ISCOMMON = 1)
END


GO
/****** Object:  StoredProcedure [dbo].[EBAPFileContent_Get]    Script Date: 2024-08-19 오후 7:11:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===============================================
-- 작성자: 오인봉
-- 작성일: 2024.01.03
-- 설   명: Assembly File Content 가져오기
-- 샘플실행: EXEC EBAPFileContent_Get ''
-- 변경이력: 
-- 2017.12.30 SP최초작성
-- 
-- ===============================================
CREATE PROC [dbo].[EBAPFileContent_Get]
	@FILEID nvarchar(30)
AS
SELECT FILECONTENT
FROM dbo.FileContent WITH(NOLOCK)
WHERE FILEID = @FILEID


GO
/****** Object:  StoredProcedure [dbo].[EBAPFileID_Get]    Script Date: 2024-08-19 오후 7:11:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===============================================
-- 작성자: 오인봉
-- 작성일: 2017.11.24
-- 설   명: EBAP File ID 가져오기
-- 샘플실행: EXEC EBAPFileID_Get
-- 변경이력: 
-- 2017.01.09 SP최초작성
-- 
-- ===============================================
CREATE Procedure [dbo].[EBAPFileID_Get]
AS
SELECT FILEID AS CODEVALUE, FILEID + ' : ' + FILENAME AS DISPLAYVALUE 
FROM dbo.EBAPFileMaster WITH(NOLOCK)

GO
/****** Object:  StoredProcedure [dbo].[EBAPFileMaster_Delete]    Script Date: 2024-08-19 오후 7:11:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 
==============================================================================================
 작 성 자 : 오인봉
 작 성 일 : 2024.01.04 09:42:49
 설    명 : EBAPFileMaster 삭제
 샘플실행 : EXEC dbo.EBAPFileMaster_Delete ''

 변경이력 : 
==============================================================================================
*/ 
CREATE PROC [dbo].[EBAPFileMaster_Delete]
	@FILEID nvarchar(30)
AS
BEGIN TRY
	BEGIN TRANSACTION

		DELETE FROM dbo.EBAPFileMaster
		WHERE FILEID = @FILEID

	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.EBAPFileMaster_Delete : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	
	ROLLBACK TRANSACTION;
END CATCH

GO
/****** Object:  StoredProcedure [dbo].[EBAPFileMaster_Save]    Script Date: 2024-08-19 오후 7:11:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2024.01.01 09:59:58
 설    명 : EBAPFileMaster Table 저장 
 샘플실행 : EXEC dbo.EBAPFileMaster_Save '', '', '', '', ''

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[EBAPFileMaster_Save]
	@FILEID nvarchar(30),
	@FILENAME nvarchar(100),
	@ISCOMMON bit,
	@DESCRIPTION nvarchar(200),
	@CHANGEBY nvarchar(50)
AS
BEGIN TRY
	BEGIN TRANSACTION

	IF @FILEID IS NULL OR @FILEID = ''
	BEGIN
		DECLARE @serial int
	
		SELECT @serial = ISNULL(RIGHT(MAX(FILEID), 4), 0) + 1  FROM dbo.EBAPFileMaster WITH(NOLOCK)
	
		SET @FILEID = 'ASM' + FORMAT(@serial, '0000')
	END

	IF NOT EXISTS (SELECT 1 FROM dbo.EBAPFileMaster WITH(NOLOCK) WHERE FILEID = @FILEID) 
	BEGIN 
		INSERT INTO dbo.EBAPFileMaster ( FILEID, [FILENAME], ISCOMMON, [DESCRIPTION], INITDTTM, INITBY ) 
		VALUES ( @FILEID, @FILENAME, @ISCOMMON, @DESCRIPTION, GETDATE(), @CHANGEBY ) 
	END 
	ELSE 
	BEGIN 
		UPDATE dbo.EBAPFileMaster
		SET [FILENAME] = @FILENAME
		  , ISCOMMON = @ISCOMMON
		  , [DESCRIPTION] = @DESCRIPTION
		  , UPDTTM = GETDATE()
		  , UPBY = @CHANGEBY
		WHERE FILEID = @FILEID
	END 

	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.EBAPFileMaster_Save : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH

GO
/****** Object:  StoredProcedure [dbo].[EBAPFileMaster_Select]    Script Date: 2024-08-19 오후 7:11:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===============================================
-- 작성자: 오인봉
-- 작성일: 2024.01.09
-- 설   명: EBAPFileMaster Table 조회
-- 샘플실행: EXEC dbo.EBAPFileMaster_Select ''
-- 변경이력: 
-- 2017.01.09 SP최초작성
-- 
-- ===============================================
CREATE Procedure [dbo].[EBAPFileMaster_Select]
	@ASSEMBLYNAME nvarchar(100)
AS
SELECT A.FILEID
	 , A.[FILENAME]
	 , A.FILEVERSION
	 , A.DEPLOYCOUNT
	 , A.LASTUPDTTM
	 , A.ISCOMMON
	 , A.DESCRIPTION
	 , ISNULL(A.UPDTTM, A.INITDTTM) CHANGEDTTM
	 , METADB.dbo.fnGetUserName(ISNULL(A.UPBY, A.INITBY)) CHANGEBY
FROM dbo.EBAPFileMaster AS A WITH(NOLOCK) 
WHERE 1 = 1 
AND A.[FILENAME] LIKE @ASSEMBLYNAME + '%' 
ORDER BY A.ISCOMMON DESC, A.FILEID


GO
/****** Object:  StoredProcedure [dbo].[FileContent_Get]    Script Date: 2024-08-19 오후 7:11:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===============================================
-- 작성자: 오인봉
-- 작성일: 2024.01.03
-- 설   명: File Content 가져오기
-- 샘플실행: EXEC dbo.FileContent_Get ''
-- 변경이력: 
-- 2017.12.30 SP최초작성
-- 
-- ===============================================
CREATE PROC [dbo].[FileContent_Get]
	@FILEID nvarchar(30)
AS
SELECT FILECONTENT
FROM dbo.FileContent WITH(NOLOCK)
WHERE FILEID = @FILEID


GO
/****** Object:  StoredProcedure [dbo].[FileDeployHistory_Save]    Script Date: 2024-08-19 오후 7:11:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===============================================
-- 작성자: 오인봉
-- 작성일: 2024.01.09
-- 설   명: File Deploy History 저장
-- 샘플실행: EXEC FileDeployHistory_Save '', 0, '', '', 0, 'inbong.oh', '11.94.'
-- 변경이력: 
-- 2024.01.09 SP최초작성
-- 
-- ===============================================
CREATE PROC [dbo].[FileDeployHistory_Save]
	@FILEID VARCHAR(30),
	@SIZE INT,
	@FILECONTENT VARBINARY(MAX) = NULL,
	@REASON NVARCHAR(300),
	@CHANGEBY nvarchar(50),
	@IPADDRESS VARCHAR(30)
AS
IF EXISTS (SELECT 1 FROM dbo.FileContent WITH(NOLOCK) WHERE FILEID = @FILEID)
BEGIN
	UPDATE dbo.FileContent
	SET FILECONTENT = @FILECONTENT,
		[VERSION] = '',
		UPDTTM = GETDATE(),
		UPBY = @CHANGEBY
	WHERE FILEID = @FILEID
END
ELSE
BEGIN
	INSERT INTO dbo.FileContent
	        ( FILEID, [VERSION], FILECONTENT, INITDTTM, INITBY )
	VALUES  ( @FILEID, '', @FILECONTENT, GETDATE(), @CHANGEBY ) 
END

UPDATE dbo.FileMaster
SET DEPLOYCOUNT = ISNULL(DEPLOYCOUNT, 0) + 1,
	LASTUPDTTM = GETDATE()
WHERE FILEID = @FILEID

INSERT INTO dbo.FileDeployHistory 
		(FILEID, 
		 SIZE,
		 REASON, 
		 IPADDRESS,
		 CHANGEDTTM,
		 CHANGEBY )
VALUES  (@FILEID,
         @SIZE,
         @REASON,
         @IPADDRESS,
		 GETDATE(),
		 @CHANGEBY )


GO
/****** Object:  StoredProcedure [dbo].[FileDeployHistory_Select]    Script Date: 2024-08-19 오후 7:11:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===============================================
-- 작성자: 오인봉
-- 작성일: 2024.01.03
-- 설   명: File 배포 이력 조회
-- 샘플실행: EXEC FileDeployHistory_Select ''
-- 변경이력: 
-- 2024.01.03 SP최초작성
-- 
-- ===============================================
CREATE Procedure [dbo].[FileDeployHistory_Select]
	@FILEID varchar(10)
AS
DECLARE @query NVARCHAR(MAX)

SET @query = N''
SET @query = @query + N'
SELECT A.FILEID
	 , B.FILENAME
	 , CONCAT(FORMAT(A.SIZE / 1000, ''#,#''), '' KB'') SIZE
	 , A.REASON
	 , METADB.dbo.fnGetUserName(A.CHANGEBY) AS DEPLOYWORKER
	 , A.IPADDRESS
	 , A.CHANGEDTTM 
FROM dbo.FileDeployHistory AS A WITH(NOLOCK)
JOIN dbo.FileMaster AS B WITH(NOLOCK) 
ON A.FILEID = B.FILEID 
WHERE 1 = 1 '

IF @FILEID <> ''
	SET @query = @query + 'AND A.FILEID = ''' + @FILEID + ''' ' + CHAR(10)
	
SET @query = @query + 'ORDER BY A.CHANGEDTTM DESC '

PRINT @query
EXECUTE sp_executesql @query

GO
/****** Object:  StoredProcedure [dbo].[FileID_Get]    Script Date: 2024-08-19 오후 7:11:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===============================================
-- 작성자: 오인봉
-- 작성일: 2024.01.04
-- 설   명: File ID 가져오기
-- 샘플실행: EXEC FileID_Get
-- 변경이력: 
-- 2024.01.04 SP최초작성
-- 
-- ===============================================
CREATE Procedure [dbo].[FileID_Get]
AS
SELECT FILEID AS CODEVALUE, [FILENAME] AS DISPLAYVALUE 
FROM dbo.FileMaster WITH(NOLOCK)

GO
/****** Object:  StoredProcedure [dbo].[FileMaster_Delete]    Script Date: 2024-08-19 오후 7:11:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 
==============================================================================================
 작 성 자 : 오인봉
 작 성 일 : 2024.01.04 09:42:49
 설    명 : EBAPFileMaster 삭제
 샘플실행 : EXEC dbo.FileMaster_Delete ''

 변경이력 : 
==============================================================================================
*/ 
CREATE PROC [dbo].[FileMaster_Delete]
	@FILEID nvarchar(30)
AS
BEGIN TRY
	BEGIN TRANSACTION

		DELETE FROM dbo.FileMaster
		WHERE FILEID = @FILEID

		DELETE FROM dbo.FileContent
		WHERE FILEID = @FILEID

	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.FileMaster_Delete : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	
	ROLLBACK TRANSACTION;
END CATCH

GO
/****** Object:  StoredProcedure [dbo].[FileMaster_Save]    Script Date: 2024-08-19 오후 7:11:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2024.01.01 09:59:58
 설    명 : FileMaster Table 저장 
 샘플실행 : EXEC dbo.FileMaster_Save '', '', 'FORM', '', ''

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[FileMaster_Save]
	@FILEID nvarchar(30),
	@FILENAME nvarchar(100),
	@FILETYPE varchar(4),
	@DESCRIPTION nvarchar(200),
	@CHANGEBY nvarchar(50)
AS
BEGIN TRY
	BEGIN TRANSACTION

	IF @FILEID IS NULL OR @FILEID = ''
	BEGIN
		DECLARE @serial int
	
		SELECT @serial = ISNULL(RIGHT(MAX(FILEID), 4), 0) + 1  FROM dbo.FileMaster WITH(NOLOCK) WHERE FILETYPE = @FILETYPE
	
		SET @FILEID = @FILETYPE + FORMAT(@serial, '0000')
	END

	IF NOT EXISTS (SELECT 1 FROM dbo.FileMaster WITH(NOLOCK) WHERE FILEID = @FILEID) 
	BEGIN 
		INSERT INTO dbo.FileMaster ( FILEID, [FILENAME], FILETYPE, DEPLOYCOUNT, [DESCRIPTION], INITDTTM, INITBY ) 
		VALUES ( @FILEID, @FILENAME, @FILETYPE, 0, @DESCRIPTION, GETDATE(), @CHANGEBY ) 
	END 
	ELSE 
	BEGIN 
		UPDATE dbo.FileMaster
		SET [FILENAME] = @FILENAME
		  , [DESCRIPTION] = @DESCRIPTION
		  , FILETYPE = @FILETYPE
		  , UPDTTM = GETDATE()
		  , UPBY = @CHANGEBY
		WHERE FILEID = @FILEID
	END 

	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.FileMaster_Save : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH

GO
/****** Object:  StoredProcedure [dbo].[FileMaster_Select]    Script Date: 2024-08-19 오후 7:11:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===============================================
-- 작성자: 오인봉
-- 작성일: 2024.01.09
-- 설   명: FileMaster Table 조회
-- 샘플실행: EXEC dbo.FileMaster_Select ''
-- 변경이력: 
-- 2017.01.09 SP최초작성
-- 
-- ===============================================
CREATE Procedure [dbo].[FileMaster_Select]
	@FILEYNAME nvarchar(100)
AS
SELECT A.FILEID
	 , A.[FILENAME]
	 , A.FILETYPE
	 , A.DEPLOYCOUNT
	 , A.LASTUPDTTM
	 , A.DESCRIPTION
	 , 'Download' DOWNLOAD
	 , ISNULL(A.UPDTTM, A.INITDTTM) CHANGEDTTM
	 , METADB.dbo.fnGetUserName(ISNULL(A.UPBY, A.INITBY)) CHANGEBY
FROM dbo.FileMaster AS A WITH(NOLOCK) 
WHERE 1 = 1 
AND A.[FILENAME] LIKE @FILEYNAME + '%' 
ORDER BY A.FILEID


GO
/****** Object:  StoredProcedure [dbo].[MakeCSharpCode]    Script Date: 2024-08-19 오후 7:11:06 ******/
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
/****** Object:  DdlTrigger [DatabaseTriggerLog]    Script Date: 2024-08-19 오후 7:11:06 ******/
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'File ID : EX - ASM0001' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EBAPDeployHistory', @level2type=N'COLUMN',@level2name=N'FILEID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'배포 버전' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EBAPDeployHistory', @level2type=N'COLUMN',@level2name=N'VERSION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'배포 크기' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EBAPDeployHistory', @level2type=N'COLUMN',@level2name=N'SIZE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'배포 사유' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EBAPDeployHistory', @level2type=N'COLUMN',@level2name=N'REASON'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'필수 업데이트 여부' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EBAPDeployHistory', @level2type=N'COLUMN',@level2name=N'ISESSENTIAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'배포자 IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EBAPDeployHistory', @level2type=N'COLUMN',@level2name=N'IPADDRESS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록일' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EBAPDeployHistory', @level2type=N'COLUMN',@level2name=N'CHANGEDTTM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EBAPDeployHistory', @level2type=N'COLUMN',@level2name=N'CHANGEBY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'File ID : EX - ASM0001' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EBAPFileMaster', @level2type=N'COLUMN',@level2name=N'FILEID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'File 이름' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EBAPFileMaster', @level2type=N'COLUMN',@level2name=N'FILENAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'File 버전' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EBAPFileMaster', @level2type=N'COLUMN',@level2name=N'FILEVERSION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'배포 횟수' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EBAPFileMaster', @level2type=N'COLUMN',@level2name=N'DEPLOYCOUNT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'공통여부 Flag(1 : 공통, 0 : 개별)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EBAPFileMaster', @level2type=N'COLUMN',@level2name=N'ISCOMMON'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Assembly 설명(해당 업무 상세)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EBAPFileMaster', @level2type=N'COLUMN',@level2name=N'DESCRIPTION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'최종 업로드 일자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EBAPFileMaster', @level2type=N'COLUMN',@level2name=N'LASTUPDTTM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록일' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EBAPFileMaster', @level2type=N'COLUMN',@level2name=N'INITDTTM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EBAPFileMaster', @level2type=N'COLUMN',@level2name=N'INITBY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'변경일' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EBAPFileMaster', @level2type=N'COLUMN',@level2name=N'UPDTTM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'변경자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EBAPFileMaster', @level2type=N'COLUMN',@level2name=N'UPBY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'파일 ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FileContent', @level2type=N'COLUMN',@level2name=N'FILEID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'파일 버전' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FileContent', @level2type=N'COLUMN',@level2name=N'VERSION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'파일 내용' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FileContent', @level2type=N'COLUMN',@level2name=N'FILECONTENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록일' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FileContent', @level2type=N'COLUMN',@level2name=N'INITDTTM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FileContent', @level2type=N'COLUMN',@level2name=N'INITBY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'변경일' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FileContent', @level2type=N'COLUMN',@level2name=N'UPDTTM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'변경자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FileContent', @level2type=N'COLUMN',@level2name=N'UPBY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'File ID : EX - FILE001' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FileDeployHistory', @level2type=N'COLUMN',@level2name=N'FILEID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'배포 크기' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FileDeployHistory', @level2type=N'COLUMN',@level2name=N'SIZE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'배포 사유' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FileDeployHistory', @level2type=N'COLUMN',@level2name=N'REASON'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'배포자 IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FileDeployHistory', @level2type=N'COLUMN',@level2name=N'IPADDRESS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록일' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FileDeployHistory', @level2type=N'COLUMN',@level2name=N'CHANGEDTTM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FileDeployHistory', @level2type=N'COLUMN',@level2name=N'CHANGEBY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'File ID : EX - FILE001' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FileMaster', @level2type=N'COLUMN',@level2name=N'FILEID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'File 이름' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FileMaster', @level2type=N'COLUMN',@level2name=N'FILENAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'배포 횟수' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FileMaster', @level2type=N'COLUMN',@level2name=N'DEPLOYCOUNT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Assembly 설명(해당 업무 상세)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FileMaster', @level2type=N'COLUMN',@level2name=N'DESCRIPTION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'최종 업로드 일자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FileMaster', @level2type=N'COLUMN',@level2name=N'LASTUPDTTM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록일' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FileMaster', @level2type=N'COLUMN',@level2name=N'INITDTTM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FileMaster', @level2type=N'COLUMN',@level2name=N'INITBY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'변경일' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FileMaster', @level2type=N'COLUMN',@level2name=N'UPDTTM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'변경자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FileMaster', @level2type=N'COLUMN',@level2name=N'UPBY'
GO
