USE [METADB]
GO
/****** Object:  Synonym [dbo].[SignLog]    Script Date: 2024-08-19 오후 7:14:40 ******/
CREATE SYNONYM [dbo].[SignLog] FOR [LOGDB].[dbo].[SignLog]
GO
/****** Object:  UserDefinedFunction [dbo].[fnCalDate]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 
==============================================================================================
 작 성 자 : 오인봉
 작 성 일 : 2017-08-04 15:06:20
 설    명 : 빈 날짜 반환 & DATETIME을 STRING으로 변환하는 함수
 샘플실행 : SELECT dbo.fnCalDate(2947, 'DT')

 변경이력 : 
==============================================================================================
*/ 

CREATE FUNCTION [dbo].[fnCalDate]
(
	@time				int,
	@gubun				char(2)	= 'DT'	--M : 분, H : 시, D : 일
)	
RETURNS NVARCHAR(30)
AS
BEGIN
	DECLARE @resultstring NVARCHAR(30),
			@orgStyle int,
			@DAY int,
			@HOUR int,
			@MINUTE int
	
	IF @gubun = 'DT'
	BEGIN
		SET @DAY = @time / 24
		SET @HOUR = @time - (@DAY * 24)

		SET @resultstring = FORMAT(@DAY, '00') + '일 ' + FORMAT(@HOUR, '00') + '시간'
	END

	IF @gubun = 'HM'
	BEGIN
		SET @HOUR = @time / 60
		SET @MINUTE = @time - (@HOUR * 60)

		SET @resultstring = FORMAT(@HOUR, '00') + '시간 ' + FORMAT(@MINUTE, '00') + '분'
	END
	
	RETURN @resultstring
END

GO
/****** Object:  UserDefinedFunction [dbo].[fnGetCodeMasterValue]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===============================================
-- 작성자: 오인봉
-- 작성일: 2017.08.04
-- 설   명: 코드마스터 DisplayValue 반환 함수
-- 샘플실행: SELECT dbo.fnGetCodeMasterValue('C$GBM', '0000000001')
-- 변경이력: 
-- 2017.08.04 SP최초작성
-- ===============================================
CREATE FUNCTION [dbo].[fnGetCodeMasterValue]
(
	@PCODEVALUE nvarchar(40),
	@CODEVALUE nvarchar(40)
)
RETURNS NVARCHAR(60)
AS
BEGIN
	DECLARE @DISPLAYVALUE nvarchar(60)
	
	SELECT DISTINCT @DISPLAYVALUE = ISNULL(DISPLAYVALUE, '') 
	FROM dbo.CodeMaster WITH(NOLOCK)
	WHERE PCODEVALUE = @PCODEVALUE AND CODEVALUE = @CODEVALUE
	
	IF @@ROWCOUNT = 0
		SET @DISPLAYVALUE = @CODEVALUE
	
	RETURN @DISPLAYVALUE
END
GO
/****** Object:  UserDefinedFunction [dbo].[fnGetDateString]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 
==============================================================================================
 작 성 자 : 오인봉
 작 성 일 : 2017-08-04 15:06:20
 설    명 : 빈 날짜 반환 & DATETIME을 STRING으로 변환하는 함수
 샘플실행 : SELECT dbo.fnGetDateString(GETDATE(), 0)

 변경이력 : 
==============================================================================================
*/ 

CREATE FUNCTION [dbo].[fnGetDateString]
(
	@DateValue			DATETIME,
	@style				int
)	
RETURNS NVARCHAR(30)
AS
BEGIN
	DECLARE @stringDate NVARCHAR(30),
			@orgStyle int

	SET @orgStyle = @style;

	IF @style = 0
		SET @style = 120;

	SET @stringDate = ''
	
	IF @DateValue IS NOT NULL
		SET @stringDate = SUBSTRING(REPLACE(CONVERT(VARCHAR, @DateValue, @style), '1900-01-01 00:00:00', ''), 0, CASE WHEN @orgStyle = 0 THEN 12 ELSE 30 END)
		
	RETURN @stringDate
END

GO
/****** Object:  UserDefinedFunction [dbo].[fnGetListParam]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 
==============================================================================================
 작 성 자 : 오인봉
 작 성 일 : 2017-08-03 13:51:58
 설    명 : SELECT IN 에서 사용할 Parameter를 반환하는 함수
 샘플실행 : SELECT dbo.fnGetListParam('1,2,3,4,5,6,7,8,9')

 변경이력 : 
==============================================================================================
*/ 

CREATE FUNCTION [dbo].[fnGetListParam]
(
	@param			NVARCHAR(MAX)
)
RETURNS NVARCHAR(MAX)
	
AS

BEGIN
	DECLARE @params NVARCHAR(MAX)
	
	SET @params = '''' + REPLACE(REPLACE(@param, ' ', ''), ',', ''',''') + ''''
	
	RETURN @params
END

GO
/****** Object:  UserDefinedFunction [dbo].[fnGetListParamTable]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 
==============================================================================================
 작 성 자 : 오인봉
 작 성 일 : 2017-08-23 10:51:58
 설    명 : SELECT IN 에서 사용할 Parameter를 반환하는 테이블 함수
 샘플실행 : SELECT * FROM dbo.fnGetListParamTable('1, 2, 3, 4, 5, 6, 7, 8, 9')

 변경이력 : 
==============================================================================================
*/ 

CREATE FUNCTION [dbo].[fnGetListParamTable]
(
	@param			NVARCHAR(MAX)
)
RETURNS @paramTable TABLE (Data NVARCHAR(100))
	
AS

BEGIN
	DECLARE @paramLength	INT,
			@vCurrent		SMALLINT,
			@vNext			SMALLINT

	SET @vCurrent = 1
	SET @vNext = 0
	SET @param = REPLACE(@param, ' ', '')
	SET @paramLength = LEN(@param)
	
	WHILE(@paramLength > 0)
	BEGIN
		SELECT @vNext = CHARINDEX(',', @param, @vCurrent)
		
		IF @vNext = 0
		BEGIN
			INSERT INTO @paramTable ( Data )
			SELECT SUBSTRING(@param, @vCurrent, @paramLength - @vCurrent + 1)
			BREAK
		END
		ELSE
		BEGIN
			INSERT INTO @paramTable ( Data )
			SELECT SUBSTRING(@param, @vCurrent, @vNext - @vCurrent)
		END
		
		SET @vNext = 0
		SELECT @vNext = CHARINDEX(',', @param, @vCurrent)
		
		IF @vNext = 0
		BEGIN
			INSERT INTO @paramTable ( Data )
			SELECT SUBSTRING(@param, @vCurrent, @paramLength - @vCurrent + 1)
			BREAK
		END
		ELSE
		BEGIN
			SET @vCurrent = @vNext + 1
		END
	END
	RETURN
END

GO
/****** Object:  UserDefinedFunction [dbo].[fnGetLocale]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===============================================
-- 작성자: 오인봉
-- 작성일: 2017.09.24
-- 설   명: 다국어 반환 함수
-- 샘플실행: SELECT dbo.fnGetLocale('ko-KR', 'ChangeDttm')
-- 변경이력: 
-- 2017.09.24 SP최초작성
-- ===============================================

CREATE FUNCTION [dbo].[fnGetLocale]
(
	@LANGUAGE varchar(10),
	@ENUMCLASS	nvarchar(200)
)
RETURNS nvarchar(400)	
AS
BEGIN
	DECLARE @LOCALEMASTER nvarchar(400)	

	SELECT @LOCALEMASTER = CASE WHEN @LANGUAGE = 'ko-KR' THEN KOKR
							    WHEN @LANGUAGE = 'en-US' THEN ENUS
						   ELSE ZHCHS END
	FROM dbo.LocaleMaster WITH(NOLOCK)
	WHERE ENUMCLASS = @ENUMCLASS
	
	IF @@ROWCOUNT = 0
		SET @LOCALEMASTER = ''

	RETURN @LOCALEMASTER
END
GO
/****** Object:  UserDefinedFunction [dbo].[fnGetLocaleMessage]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===============================================
-- 작성자: 오인봉
-- 작성일: 2017.09.24
-- 설   명: 다국어 반환 함수
-- 샘플실행: SELECT dbo.fnGetLocaleMessage('ko-kr', 'DO_Save')
-- 변경이력: 
-- 2017.09.24 SP최초작성
-- ===============================================

CREATE FUNCTION [dbo].[fnGetLocaleMessage]
(
	@LANGUAGE varchar(10),
	@ENUMCLASS	nvarchar(200)
)
RETURNS nvarchar(400)	
AS
BEGIN
	DECLARE @LOCALEMASTER nvarchar(400)	

	SELECT @LOCALEMASTER = CASE WHEN @LANGUAGE = 'ko-kr' THEN KOKR
							    WHEN @LANGUAGE = 'en-us' THEN ENUS
						   ELSE ZHCHS END
	FROM dbo.LocaleMessageMaster WITH(NOLOCK)
	WHERE ENUMCLASS = @ENUMCLASS
	
	IF @@ROWCOUNT = 0
		SET @LOCALEMASTER = ''

	RETURN @LOCALEMASTER
END
GO
/****** Object:  UserDefinedFunction [dbo].[fnGetUserName]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===============================================
-- 작성자: 오인봉
-- 작성일: 2017.11.24
-- 설   명: 사원명 반환 함수
-- 샘플실행: SELECT dbo.fnGetUserName('AA')
-- 변경이력: 
-- 2017.11.24 SP최초작성
-- ===============================================

CREATE FUNCTION [dbo].[fnGetUserName]
(
	@USERID	varchar(40)
)
RETURNS varchar(50)	
AS
BEGIN
	DECLARE @USERNAME varchar(40)	

	SELECT @USERNAME = ISNULL(RTRIM(USERNAME), '')
	FROM dbo.UserInfo WITH(NOLOCK)
	WHERE USERID = @USERID
	AND USEFLAG = 1
	
	--IF @USERNAME IS NULL OR @USERNAME = ''
	--	SET @USERNAME = '퇴사자'

	IF @@ROWCOUNT = 0
		SET @USERNAME = '퇴사자'

	RETURN @USERNAME
END


GO
/****** Object:  UserDefinedFunction [dbo].[fnN2H]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/* 
==============================================================================================
 작 성 자 : 오인봉
 작 성 일 : 2024-01-15 15:06:20
 설    명 : 숫자를 금액(한글)으로 변환하는 함수
 샘플실행 : SELECT dbo.fnN2H(2558442947)

 변경이력 : 
==============================================================================================
*/ 
CREATE FUNCTION [dbo].[fnN2H]
(
	@NUMBER	bigint
)	
RETURNS NVARCHAR(50)
AS
BEGIN
	DECLARE @V_AMT varchar(50)
		  , @V_NUM_LEN tinyint
		  , @V_NUM_IDX tinyint
		  , @V_CNT int
		  , @V_NUM_CHAR varchar(30)
		  , @V_LEN VARCHAR(1)
		  , @V_EXIST varchar(1)
		  , @V_HAN_AMT nvarchar(50)

	SET @V_HAN_AMT = ''
	SET @V_AMT = CAST(@NUMBER AS VARCHAR)
	
	IF @V_AMT = '' return ''
	IF @V_AMT = '0' return '영'
	IF @NUMBER < 0 SET @V_HAN_AMT = '-'

	SET @V_NUM_CHAR = @NUMBER;
	SET @V_NUM_LEN = LEN(@NUMBER);
	SET @V_CNT = 1;

	WHILE(@V_CNT <= @V_NUM_LEN)
	BEGIN
		SET @V_LEN = SUBSTRING(@V_NUM_CHAR, @V_CNT, 1);
		BEGIN
			IF @V_LEN = '0' SET @V_HAN_AMT = CONCAT(@V_HAN_AMT, '')
			IF @V_LEN = '1' SET @V_HAN_AMT = CONCAT(@V_HAN_AMT, '일')
			IF @V_LEN = '2' SET @V_HAN_AMT = CONCAT(@V_HAN_AMT, '이')
			IF @V_LEN = '3' SET @V_HAN_AMT = CONCAT(@V_HAN_AMT, '삼')
			IF @V_LEN = '4' SET @V_HAN_AMT = CONCAT(@V_HAN_AMT, '사')
			IF @V_LEN = '5' SET @V_HAN_AMT = CONCAT(@V_HAN_AMT, '오')
			IF @V_LEN = '6' SET @V_HAN_AMT = CONCAT(@V_HAN_AMT, '육')
			IF @V_LEN = '7' SET @V_HAN_AMT = CONCAT(@V_HAN_AMT, '칠')
			IF @V_LEN = '8' SET @V_HAN_AMT = CONCAT(@V_HAN_AMT, '팔')
			IF @V_LEN = '9' SET @V_HAN_AMT = CONCAT(@V_HAN_AMT, '구')

			SET @V_EXIST = '1'
		END

		SET @V_NUM_IDX = @V_NUM_LEN + 1 - @V_CNT;

		IF @V_NUM_IDX = 1 SET @V_HAN_AMT = CONCAT(@V_HAN_AMT, '')
		ELSE IF @V_NUM_IDX = 5 AND @V_EXIST = '1' SET @V_HAN_AMT = CONCAT(@V_HAN_AMT, '만 ')
		ELSE IF @V_NUM_IDX = 9 AND @V_EXIST = '1' SET @V_HAN_AMT = CONCAT(@V_HAN_AMT, '억 ')
		ELSE IF @V_NUM_IDX = 13 AND @V_EXIST = '1' SET @V_HAN_AMT = CONCAT(@V_HAN_AMT, '조 ')
		ELSE IF @V_NUM_IDX = 17 AND @V_EXIST = '1' SET @V_HAN_AMT = CONCAT(@V_HAN_AMT, '경 ')
		ELSE
		BEGIN
			IF @V_LEN <> 0
			BEGIN
				IF (@V_NUM_IDX % 4) = 0  SET @V_HAN_AMT = CONCAT(@V_HAN_AMT, '천')
				IF (@V_NUM_IDX % 4) = 1  SET @V_HAN_AMT = CONCAT(@V_HAN_AMT, '')
				IF (@V_NUM_IDX % 4) = 2  SET @V_HAN_AMT = CONCAT(@V_HAN_AMT, '십')
				IF (@V_NUM_IDX % 4) = 3  SET @V_HAN_AMT = CONCAT(@V_HAN_AMT, '백')
			END
		END

		IF @V_NUM_IDX IN (1, 5, 9, 13, 17) SET @V_EXIST = ''
		SET @V_CNT = @V_CNT + 1
	END
	
	RETURN @V_HAN_AMT
END

GO
/****** Object:  UserDefinedFunction [dbo].[LPAD]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===============================================
-- 작성자: 오인봉
-- 작성일: 2017.08.04
-- 설   명: 자리수 맞추는 함수
-- 샘플실행: SELECT dbo.LPAD(123, 5, '0')
-- 변경이력: 
-- 2017.08.04 SP최초작성
-- ===============================================
CREATE FUNCTION [dbo].[LPAD]
(
	@CLOP varchar(50),
	@LENGTH int,
	@PADCLOP varchar(50)
)
RETURNS VARCHAR(50)
AS
BEGIN
	DECLARE @rVAL varchar(50)

	SET @rVAL = RIGHT(REPLICATE(@PADCLOP, @LENGTH) + cast(@CLOP as varchar), @LENGTH)
	
	IF @@ROWCOUNT = 0
		SET @rVAL = ''
	
	RETURN @rVAL
END
GO
/****** Object:  Table [dbo].[MenuMaster]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuMaster](
	[MENUID] [varchar](40) NOT NULL,
	[MENUNAME_LANG] [nvarchar](100) NULL,
	[MENUNAME] [nvarchar](50) NOT NULL,
	[LVL] [smallint] NOT NULL,
	[IDX] [smallint] NOT NULL,
	[PARENTMENUID] [varchar](50) NULL,
	[SCREENID] [varchar](20) NULL,
	[IMAGEIDX] [smallint] NULL,
	[SELECTIMAGEIDX] [smallint] NULL,
	[USEVENDORCODE] [varchar](200) NULL,
	[USEPLANTCODE] [varchar](100) NULL,
	[ISCOMMON] [bit] NULL,
	[ISMULTIEXECUTE] [bit] NULL,
	[ISBEGINGROUP] [bit] NULL,
	[DESCRIPTION] [nvarchar](300) NULL,
	[USEFLAG] [bit] NULL,
	[INITDTTM] [datetime] NULL,
	[INITBY] [nvarchar](50) NULL,
	[UPDTTM] [datetime] NULL,
	[UPBY] [nvarchar](50) NULL,
 CONSTRAINT [PK_MenuMaster] PRIMARY KEY CLUSTERED 
(
	[MENUID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[fnGetChildMenu]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[fnGetChildMenu]
(
	@MENUID			VARCHAR(40)
)
RETURNS TABLE
AS
RETURN
(
	WITH MENU AS
	(
		SELECT A.MENUID
			 , A.MENUNAME
			 , A.PARENTMENUID
			 , A.LVL
			 , A.IDX
		FROM MenuMaster AS A
		WHERE 1 = 1
		AND A.MENUID = @MENUID
		UNION ALL
		SELECT A.MENUID
			 , A.MENUNAME
			 , A.PARENTMENUID
			 , A.LVL
			 , A.IDX
		FROM MenuMaster AS A
		JOIN MENU B
		ON A.PARENTMENUID = B.MENUID
	)
	SELECT DISTINCT MENUID FROM MENU
);
GO
/****** Object:  UserDefinedFunction [dbo].[fnGetParentMenu]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[fnGetParentMenu]
(
	@MENUNAME			NVARCHAR(MAX)
)
RETURNS TABLE
AS
RETURN
(
	WITH MENU AS
	(
		SELECT A.MENUID
			 , A.MENUNAME
			 , A.PARENTMENUID
			 , A.LVL
			 , A.IDX
		FROM MenuMaster AS A
		WHERE 1 = 1
		AND A.PARENTMENUID <> ''
		AND A.MENUNAME LIKE @MENUNAME + '%'
		UNION ALL
		SELECT A.MENUID
			 , A.MENUNAME
			 , A.PARENTMENUID
			 , A.LVL
			 , A.IDX
		FROM MenuMaster AS A
		JOIN MENU B
		ON A.MENUID = B.PARENTMENUID
	)
	SELECT DISTINCT MENUID FROM MENU
);
GO
/****** Object:  UserDefinedFunction [dbo].[fnGetDateList]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* 
==============================================================================================
 작 성 자 : 오인봉
 작 성 일 : 2024-06-23 10:51:58
 설    명 : 시작일자와 종료일자 사이의 일자를 반환하는 테이블 함수
 샘플실행 : SELECT * FROM dbo.fnGetDateList('2024-01-01', '2024-03-01')

 변경이력 : 
==============================================================================================
*/ 
CREATE FUNCTION [dbo].[fnGetDateList]
(
	@STARTDATE datetime,
	@ENDDATE datetime
)
RETURNS TABLE
AS
RETURN
(
	SELECT CAST(DATEADD(d, number, @STARTDATE) AS DATE) DATES
	FROM master.dbo.spt_values
	WHERE type = 'P'
	AND number <= DATEDIFF(d, @STARTDATE, @ENDDATE)
);
GO
/****** Object:  Table [dbo].[AuthGroup]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuthGroup](
	[AUTHTYPE] [varchar](10) NULL,
	[GROUPCODE] [nvarchar](20) NOT NULL,
	[GROUPNAME] [nvarchar](50) NULL,
	[CHECKPROCESS] [bit] NULL,
	[RESTRICTIONFLAG] [bit] NULL,
	[DESCRIPTION] [nvarchar](100) NULL,
	[INITDTTM] [datetime] NULL,
	[INITBY] [nvarchar](50) NULL,
	[UPDTTM] [datetime] NULL,
	[UPBY] [nvarchar](50) NULL,
 CONSTRAINT [PK_AuthGroup] PRIMARY KEY CLUSTERED 
(
	[GROUPCODE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuthGroupMenu]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuthGroupMenu](
	[GROUPCODE] [nvarchar](20) NOT NULL,
	[MENUID] [varchar](40) NOT NULL,
	[AUTHORITY] [nvarchar](30) NULL,
	[INITDTTM] [datetime] NULL,
	[INITBY] [nvarchar](50) NULL,
	[UPDTTM] [datetime] NULL,
	[UPBY] [nvarchar](50) NULL,
 CONSTRAINT [PK_AuthGroupMenu] PRIMARY KEY CLUSTERED 
(
	[GROUPCODE] ASC,
	[MENUID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuthGroupUser]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuthGroupUser](
	[GROUPCODE] [nvarchar](20) NOT NULL,
	[USERID] [nvarchar](50) NOT NULL,
	[EXPIREDATE] [datetime] NOT NULL,
	[ISDELEGATE] [bit] NULL,
	[INITDTTM] [datetime] NULL,
	[INITBY] [nvarchar](50) NULL,
	[UPDTTM] [datetime] NULL,
	[UPBY] [nvarchar](50) NULL,
 CONSTRAINT [PK_AuthGroupUser] PRIMARY KEY CLUSTERED 
(
	[GROUPCODE] ASC,
	[USERID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Calendar]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Calendar](
	[CALN_DATE] [datetime] NULL,
	[YR] [smallint] NULL,
	[YR_HF] [varchar](6) NULL,
	[YR_QTR] [varchar](6) NULL,
	[YR_MONTH] [varchar](6) NULL,
	[YR_WEEK_ORDB] [varchar](50) NULL,
	[YR_PARTIAL_WEEK_ORDB] [varchar](50) NULL,
	[YR_WEEK] [varchar](6) NULL,
	[WEEK_YR] [varchar](4) NULL,
	[WEEK_MONTH] [varchar](6) NULL,
	[WEEK_ORDB] [varchar](2) NULL,
	[PARTIAL_WEEK] [varchar](6) NULL,
	[PARTIAL_WEEK_ORDB] [varchar](2) NULL,
	[ISO_WEEK] [varchar](6) NULL,
	[ISO_WEEK_YR] [varchar](4) NULL,
	[ISO_WEEK_MONTH] [varchar](6) NULL,
	[ISO_WEEK_ORDB] [varchar](2) NULL,
	[ISO_PARTIAL_WEEK] [varchar](6) NULL,
	[ISO_PARTIAL_WEEK_ORDB] [varchar](2) NULL,
	[DAY_CODE] [varchar](3) NULL,
	[WEEK_LOC] [float] NULL,
	[PARTIAL_WEEK_LOC] [float] NULL,
	[WEEK_MONTH_LOC] [float] NULL,
	[WEEK_SEQ] [int] NULL,
	[PARTIAL_WEEK_SEQ] [int] NULL,
	[WEEK_MONTH_SEQ] [int] NULL,
	[QTR_ORDB] [varchar](2) NULL,
	[CALN_DATE_SEQ] [int] NULL,
	[CALN_DATE_STRING] [varchar](8) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CodeInfo]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CodeInfo](
	[CODEVALUE] [nvarchar](20) NOT NULL,
	[DISPLAYVALUE] [nvarchar](30) NOT NULL,
	[KEY1USE] [bit] NULL,
	[KEY1CAPTION] [varchar](50) NULL,
	[KEY2USE] [bit] NULL,
	[KEY2CAPTION] [varchar](50) NULL,
	[KEY3USE] [bit] NULL,
	[KEY3CAPTION] [varchar](50) NULL,
	[FIELD1USE] [bit] NULL,
	[FIELD1CAPTION] [varchar](50) NULL,
	[FIELD2USE] [bit] NULL,
	[FIELD2CAPTION] [varchar](50) NULL,
	[FIELD3USE] [bit] NULL,
	[FIELD3CAPTION] [varchar](50) NULL,
	[FIELD4USE] [bit] NULL,
	[FIELD4CAPTION] [varchar](50) NULL,
	[USEFLAG] [bit] NULL,
	[INITDTTM] [datetime] NULL,
	[INITBY] [nvarchar](50) NULL,
	[UPDTTM] [datetime] NULL,
	[UPBY] [nvarchar](50) NULL,
 CONSTRAINT [PK_CodeInfo] PRIMARY KEY CLUSTERED 
(
	[CODEVALUE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CodeMaster]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CodeMaster](
	[CODEVALUE] [nvarchar](40) NOT NULL,
	[DISPLAYVALUE] [nvarchar](80) NOT NULL,
	[PCODEVALUE] [nvarchar](40) NOT NULL,
	[IDX] [smallint] NOT NULL,
	[REF1] [nvarchar](40) NULL,
	[REF2] [nvarchar](20) NULL,
	[REF3] [nvarchar](20) NULL,
	[USEFLAG] [bit] NULL,
	[INITDTTM] [datetime] NULL,
	[INITBY] [nvarchar](50) NULL,
	[UPDTTM] [datetime] NULL,
	[UPBY] [nvarchar](50) NULL,
 CONSTRAINT [PK_CodeMaster] PRIMARY KEY CLUSTERED 
(
	[CODEVALUE] ASC,
	[PCODEVALUE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FavoritesMenu]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FavoritesMenu](
	[USERID] [nvarchar](50) NOT NULL,
	[MENUID] [nvarchar](10) NOT NULL,
	[INITDTTM] [datetime] NULL,
	[INITBY] [nvarchar](50) NULL,
	[UPDTTM] [datetime] NULL,
	[UPBY] [nvarchar](50) NULL,
 CONSTRAINT [PK_FavoritesMenu] PRIMARY KEY CLUSTERED 
(
	[USERID] ASC,
	[MENUID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FTPFileInfo]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FTPFileInfo](
	[FTPID] [nvarchar](50) NOT NULL,
	[UIID] [nvarchar](30) NOT NULL,
	[FTPKEY] [nvarchar](20) NOT NULL,
	[FTPKEY2] [nvarchar](20) NOT NULL,
	[FILENAME] [nvarchar](80) NOT NULL,
	[FILEPATH] [nvarchar](150) NULL,
	[SERVERFILENAME]  AS (((([FTPKEY]+'_')+[FTPKEY2])+'_')+[FILENAME]),
	[IDX] [smallint] NULL,
	[SIZE] [int] NULL,
	[INITDTTM] [datetime] NULL,
	[INITBY] [nvarchar](50) NULL,
	[UPDTTM] [datetime] NULL,
	[UPBY] [nvarchar](50) NULL,
 CONSTRAINT [PK_FTPFileInfo] PRIMARY KEY CLUSTERED 
(
	[FTPID] ASC,
	[UIID] ASC,
	[FTPKEY] ASC,
	[FTPKEY2] ASC,
	[FILENAME] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FTPInfo]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FTPInfo](
	[FTPID] [nvarchar](50) NOT NULL,
	[FTPSERVERPATH] [nvarchar](50) NULL,
	[FTPPORT] [varchar](4) NULL,
	[FTPUSERID] [nvarchar](50) NULL,
	[FTPPWD] [nvarchar](50) NULL,
	[LIMITSIZE] [int] NULL,
	[DIRECTORYPATH] [nvarchar](50) NULL,
	[INITDTTM] [datetime] NULL,
	[INITBY] [nvarchar](50) NULL,
	[UPDTTM] [datetime] NULL,
	[UPBY] [nvarchar](50) NULL,
 CONSTRAINT [PK_FTPInfo] PRIMARY KEY CLUSTERED 
(
	[FTPID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HtmlContentsMaster]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HtmlContentsMaster](
	[HTMLID] [varchar](20) NOT NULL,
	[GBN] [varchar](1) NULL,
	[CONTENTS] [nvarchar](max) NULL,
	[INITDTTM] [datetime] NULL,
	[INITBY] [nvarchar](50) NULL,
	[UPDTTM] [datetime] NULL,
	[UPBY] [nvarchar](50) NULL,
 CONSTRAINT [PK_HtmlContentsMaster] PRIMARY KEY CLUSTERED 
(
	[HTMLID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IssueList]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IssueList](
	[Seq] [bigint] IDENTITY(1,1) NOT NULL,
	[Project] [nvarchar](20) NOT NULL,
	[WorkType] [nchar](2) NOT NULL,
	[ObjType] [nchar](2) NOT NULL,
	[RegDate] [datetime] NOT NULL,
	[RegWorker] [nvarchar](50) NOT NULL,
	[IssueTitle] [nvarchar](150) NOT NULL,
	[IssueDetail] [nvarchar](1000) NOT NULL,
	[RequestDate] [datetime] NOT NULL,
	[CompletePlanDate] [datetime] NOT NULL,
	[IssueStatus] [char](1) NOT NULL,
	[Worker] [nvarchar](50) NOT NULL,
	[CompleteDetail] [nvarchar](400) NOT NULL,
	[CompleteDate] [datetime] NOT NULL,
	[ReleaseDate] [datetime] NOT NULL,
	[LCategory] [nvarchar](30) NOT NULL,
	[MCategory] [nvarchar](30) NOT NULL,
	[MenuName] [nvarchar](30) NOT NULL,
	[Priority] [char](1) NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_IssueList] PRIMARY KEY CLUSTERED 
(
	[Seq] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LinkMenu]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LinkMenu](
	[MENUID] [varchar](40) NOT NULL,
	[MENUNAME] [nvarchar](50) NOT NULL,
	[LVL] [smallint] NOT NULL,
	[IDX] [smallint] NOT NULL,
	[LINKURL] [varchar](300) NULL,
	[DESCRIPTION] [nvarchar](300) NULL,
	[USEFLAG] [bit] NULL,
	[LINKTYPE] [varchar](1) NULL,
	[ISBEGINGROUP] [bit] NULL,
	[INITDTTM] [datetime] NULL,
	[INITBY] [nvarchar](50) NULL,
	[UPDTTM] [datetime] NULL,
	[UPBY] [nvarchar](50) NULL,
 CONSTRAINT [PK_LinkMenu] PRIMARY KEY CLUSTERED 
(
	[MENUID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LocaleMaster]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LocaleMaster](
	[STRINGID] [int] IDENTITY(1,1) NOT NULL,
	[KOKR] [nvarchar](200) NULL,
	[ENUS] [nvarchar](200) NULL,
	[ZHCHS] [nvarchar](200) NULL,
	[ENUMCLASS] [nvarchar](100) NULL,
	[ISEXPORT] [bit] NULL,
	[INITDTTM] [datetime] NULL,
	[INITBY] [nvarchar](50) NULL,
	[UPDTTM] [datetime] NULL,
	[UPBY] [nvarchar](50) NULL,
 CONSTRAINT [PK_LocaleMaster] PRIMARY KEY CLUSTERED 
(
	[STRINGID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LocaleMessageMaster]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LocaleMessageMaster](
	[MESSAGEID] [bigint] IDENTITY(1,1) NOT NULL,
	[KOKR] [nvarchar](500) NULL,
	[ENUS] [nvarchar](500) NULL,
	[ZHCHS] [nvarchar](500) NULL,
	[ENUMCLASS] [nvarchar](100) NULL,
	[ISEXPORT] [bit] NULL,
	[INITDTTM] [datetime] NULL,
	[INITBY] [nvarchar](50) NULL,
	[UPDTTM] [datetime] NULL,
	[UPBY] [nvarchar](50) NULL,
 CONSTRAINT [PK_LocaleMessageMaster] PRIMARY KEY CLUSTERED 
(
	[MESSAGEID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MonitoringInfo]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonitoringInfo](
	[REGIONCODE] [varchar](4) NOT NULL,
	[PRODUCTCODE] [varchar](4) NOT NULL,
	[IFMODULE] [varchar](4) NOT NULL,
	[SERVERIP] [varchar](30) NOT NULL,
	[ERRORWARNINGLIMIT] [smallint] NULL,
	[WAITWARNINGLIMIT] [smallint] NULL,
	[SERVERNAME] [varchar](20) NULL,
	[PORT] [varchar](4) NULL,
	[DBNAME] [nvarchar](20) NOT NULL,
	[DBUSER] [nvarchar](20) NULL,
	[DBPWD] [nvarchar](20) NULL,
	[ERRSQL] [varchar](8000) NULL,
	[WAITSQL] [varchar](8000) NULL,
	[WORKDATE] [datetime] NULL,
 CONSTRAINT [PK_MonitoringInfo] PRIMARY KEY CLUSTERED 
(
	[REGIONCODE] ASC,
	[PRODUCTCODE] ASC,
	[IFMODULE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MyMenu]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MyMenu](
	[USERID] [nvarchar](50) NOT NULL,
	[MENUID] [nvarchar](10) NOT NULL,
	[GUBUN] [varchar](1) NOT NULL,
	[IPADDRESS] [varchar](30) NOT NULL,
	[INITDTTM] [datetime] NULL,
	[INITBY] [nvarchar](50) NULL,
	[UPDTTM] [datetime] NULL,
	[UPBY] [nvarchar](50) NULL,
 CONSTRAINT [PK_MyMenu] PRIMARY KEY CLUSTERED 
(
	[USERID] ASC,
	[MENUID] ASC,
	[GUBUN] ASC,
	[IPADDRESS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notify]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notify](
	[SEQ] [int] IDENTITY(1,1) NOT NULL,
	[TYPE] [varchar](2) NOT NULL,
	[SUBJECT] [nvarchar](100) NOT NULL,
	[CONTENTS] [nvarchar](2000) NOT NULL,
	[PRIORITY] [varchar](2) NOT NULL,
	[EXPIREDATE] [date] NOT NULL,
	[INITDTTM] [datetime] NULL,
	[INITBY] [nvarchar](50) NULL,
	[UPDTTM] [datetime] NULL,
	[UPBY] [nvarchar](50) NULL,
 CONSTRAINT [PK_Communicate] PRIMARY KEY CLUSTERED 
(
	[SEQ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NotifyConfirm]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NotifyConfirm](
	[SEQ] [bigint] IDENTITY(1,1) NOT NULL,
	[NOTIFYSEQ] [bigint] NULL,
	[USERID] [varchar](30) NULL,
	[CONFIRMVALUE] [varchar](300) NULL,
	[CHANGEDTTM] [datetime] NULL,
 CONSTRAINT [PK_NotifyConfirm] PRIMARY KEY CLUSTERED 
(
	[SEQ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlantAuth]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlantAuth](
	[PLANTCODE] [varchar](4) NOT NULL,
	[USERID] [nvarchar](50) NOT NULL,
	[EXPIREDATE] [datetime] NOT NULL,
	[ISDELEGATE] [bit] NULL,
	[INITDTTM] [datetime] NULL,
	[INITBY] [nvarchar](50) NULL,
	[UPDTTM] [datetime] NULL,
	[UPBY] [nvarchar](50) NULL,
 CONSTRAINT [PK_PlantAuth] PRIMARY KEY CLUSTERED 
(
	[PLANTCODE] ASC,
	[USERID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Plants]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Plants](
	[VENDORCODE] [nvarchar](10) NOT NULL,
	[PLANTCODE] [nvarchar](10) NOT NULL,
	[DESCRIPTION] [nvarchar](50) NULL,
	[COMPANY] [nvarchar](10) NULL,
	[BASISSTARTTIME] [nvarchar](8) NULL,
	[IDX] [smallint] NULL,
	[INITDTTM] [datetime] NULL,
	[INITBY] [nvarchar](50) NULL,
	[UPDTTM] [datetime] NULL,
	[UPBY] [nvarchar](50) NULL,
 CONSTRAINT [PK_Plants] PRIMARY KEY CLUSTERED 
(
	[VENDORCODE] ASC,
	[PLANTCODE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QueryMaster]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QueryMaster](
	[SQLGROUP] [varchar](30) NOT NULL,
	[QUERYID] [varchar](80) NOT NULL,
	[SUBJECT] [nvarchar](100) NULL,
	[QUERYTYPE] [varchar](20) NULL,
	[QUERYTEXT] [nvarchar](max) NULL,
	[DBID] [varchar](20) NULL,
	[IDX] [smallint] NOT NULL,
	[INITDTTM] [datetime] NULL,
	[INITBY] [nvarchar](50) NULL,
	[UPDTTM] [datetime] NULL,
	[UPBY] [nvarchar](50) NULL,
 CONSTRAINT [PK_QueryMaster] PRIMARY KEY CLUSTERED 
(
	[QUERYID] ASC,
	[IDX] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ScreenColumnSet]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ScreenColumnSet](
	[SCREENID] [nvarchar](20) NOT NULL,
	[GRIDNAME] [varchar](50) NOT NULL,
	[IDX] [int] NOT NULL,
	[FIELDNAME] [varchar](50) NOT NULL,
	[CAPTION] [nvarchar](100) NULL,
	[WIDTH] [int] NULL,
	[MAXLENGTH] [int] NULL,
	[DECIMALPLACE] [int] NULL,
	[ALLOWEDIT] [bit] NULL,
	[VISIBLE] [bit] NULL,
	[DATATYPE] [varchar](30) NULL,
	[HORIZONALIGN] [varchar](30) NULL,
	[INITDTTM] [datetime] NULL,
	[INITBY] [nvarchar](50) NULL,
	[UPDTTM] [datetime] NULL,
	[UPBY] [nvarchar](50) NULL,
 CONSTRAINT [PK_MenuColumnSet] PRIMARY KEY CLUSTERED 
(
	[SCREENID] ASC,
	[GRIDNAME] ASC,
	[FIELDNAME] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ScreenColumnSetDetail]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ScreenColumnSetDetail](
	[SCREENID] [nvarchar](20) NOT NULL,
	[GRIDNAME] [varchar](50) NOT NULL,
	[USESELECTCOLUMN] [bit] NULL,
	[KEYCOLUMNS] [varchar](150) NULL,
	[MANDATORYCOLUMNS] [varchar](150) NULL,
	[NEWROWENABLECOLUMNS] [varchar](150) NULL,
	[NEWROWCOPYCOLUMNS] [varchar](150) NULL,
	[INITDTTM] [datetime] NULL,
	[INITBY] [nvarchar](50) NULL,
	[UPDTTM] [datetime] NULL,
	[UPBY] [nvarchar](50) NULL,
 CONSTRAINT [PK_MenuColumnSetDetail] PRIMARY KEY CLUSTERED 
(
	[SCREENID] ASC,
	[GRIDNAME] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ScreenMaster]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ScreenMaster](
	[SCREENID] [varchar](20) NOT NULL,
	[SCREENNAME] [nvarchar](50) NULL,
	[DLLNAME] [nvarchar](50) NULL,
	[CLASSNAME] [nvarchar](70) NULL,
	[HELPURL] [nvarchar](200) NULL,
	[DESCRIPTION] [nvarchar](100) NULL,
	[INITDTTM] [datetime] NULL,
	[INITBY] [nvarchar](50) NULL,
	[UPDTTM] [datetime] NULL,
	[UPBY] [nvarchar](50) NULL,
 CONSTRAINT [PK_ScreenMaster] PRIMARY KEY CLUSTERED 
(
	[SCREENID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TableList]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TableList](
	[Seq] [bigint] IDENTITY(1,1) NOT NULL,
	[server_id] [int] NOT NULL,
	[database_id] [int] NOT NULL,
	[schema_id] [int] NOT NULL,
	[table_id] [int] NOT NULL,
	[TableName] [nvarchar](70) NOT NULL,
	[UseUI] [varchar](100) NOT NULL,
	[Storage] [varchar](100) NOT NULL,
	[Func] [char](1) NOT NULL,
	[LifeCycle] [varchar](10) NOT NULL,
	[Worker] [nvarchar](50) NOT NULL,
	[Description] [varchar](500) NOT NULL,
 CONSTRAINT [PK_TableList] PRIMARY KEY CLUSTERED 
(
	[Seq] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 85, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserCell]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserCell](
	[USERID] [nvarchar](50) NOT NULL,
	[VENDORCODE] [varchar](10) NULL,
	[PLANTCODE] [varchar](4) NULL,
	[LINE] [varchar](2) NULL,
	[CELL] [varchar](4) NULL,
	[STATIONGROUP] [varchar](4) NULL,
	[IPADDRESS] [varchar](30) NOT NULL,
	[INITDTTM] [datetime] NULL,
	[INITBY] [nvarchar](50) NULL,
	[UPDTTM] [datetime] NULL,
	[UPBY] [nvarchar](50) NULL,
 CONSTRAINT [PK_UserCell_1] PRIMARY KEY CLUSTERED 
(
	[USERID] ASC,
	[IPADDRESS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserInfo]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInfo](
	[USERID] [nvarchar](50) NOT NULL,
	[USERNAME] [nvarchar](40) NOT NULL,
	[EMPNO] [nvarchar](30) NULL,
	[GRADECODE] [nvarchar](10) NULL,
	[GRADENAME] [nvarchar](40) NULL,
	[PWD] [nvarchar](100) NULL,
	[DEPTCODE] [nvarchar](10) NULL,
	[DEPTNAME] [nvarchar](40) NULL,
	[WORK] [nvarchar](40) NULL,
	[PHONE] [nvarchar](20) NULL,
	[OFFICEPHONE] [nvarchar](20) NULL,
	[CELLPHONE] [nvarchar](20) NULL,
	[EMAILADDRESS] [nvarchar](100) NULL,
	[USEFLAG] [bit] NULL,
	[LOCKFLAG] [bit] NULL,
	[ADMINFLAG] [bit] NULL,
	[SSOFLAG] [bit] NULL,
	[EXTFLAG] [bit] NULL,
	[EPID] [nvarchar](50) NULL,
	[GTPSID] [varchar](100) NULL,
	[LOGINID] [varchar](50) NULL,
	[INITDTTM] [datetime] NULL,
	[INITBY] [nvarchar](50) NULL,
	[UPDTTM] [datetime] NULL,
	[UPBY] [nvarchar](50) NULL,
 CONSTRAINT [PK_UserInfo] PRIMARY KEY CLUSTERED 
(
	[USERID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserMonitoringInfo]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserMonitoringInfo](
	[USERID] [varchar](10) NOT NULL,
	[REGIONCODE] [varchar](4) NOT NULL,
	[PRODUCTCODE] [varchar](4) NOT NULL,
	[IFMODULE] [varchar](4) NOT NULL,
	[SERVERIP] [varchar](15) NOT NULL,
	[SERVERNAME] [nvarchar](20) NOT NULL,
	[DBNAME] [nvarchar](20) NOT NULL,
	[MONITORINGFG] [varchar](1) NOT NULL,
	[WARNINGLEVEL] [smallint] NOT NULL,
	[WORKDATE] [datetime] NOT NULL,
 CONSTRAINT [PK_UserMonitoringInfo] PRIMARY KEY CLUSTERED 
(
	[USERID] ASC,
	[REGIONCODE] ASC,
	[PRODUCTCODE] ASC,
	[IFMODULE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserToken]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserToken](
	[USERID] [nvarchar](50) NOT NULL,
	[TOKENID] [varchar](40) NOT NULL,
	[TOKENCNT] [int] NULL,
	[CHANGEDTTM] [datetime] NULL,
 CONSTRAINT [PK_UserToken] PRIMARY KEY CLUSTERED 
(
	[USERID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VendorAuth]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VendorAuth](
	[VENDORCODE] [nvarchar](10) NOT NULL,
	[USERID] [nvarchar](50) NOT NULL,
	[EXPIREDATE] [datetime] NOT NULL,
	[ISDELEGATE] [bit] NULL,
	[INITDTTM] [datetime] NULL,
	[INITBY] [nvarchar](50) NULL,
	[UPDTTM] [datetime] NULL,
	[UPBY] [nvarchar](50) NULL,
 CONSTRAINT [PK_VendorUser] PRIMARY KEY CLUSTERED 
(
	[VENDORCODE] ASC,
	[USERID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AuthGroupUser] ADD  CONSTRAINT [DF_AuthGroupUser_EXPIREDATE]  DEFAULT (getdate()+(180)) FOR [EXPIREDATE]
GO
ALTER TABLE [dbo].[PlantAuth] ADD  CONSTRAINT [DF_PlantAuth_EXPIREDATE]  DEFAULT (getdate()+(180)) FOR [EXPIREDATE]
GO
ALTER TABLE [dbo].[VendorAuth] ADD  CONSTRAINT [DF_VendorUser_EXPIREDATE]  DEFAULT (getdate()+(180)) FOR [EXPIREDATE]
GO
/****** Object:  StoredProcedure [dbo].[AssemblyDeployHistory_Save]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===============================================
-- 작성자: 오인봉
-- 작성일: 2017.01.09
-- 설   명: AssemblyDistribution Log 저장
-- 샘플실행: EXEC AssemblyDeployHistory_Save '', 0, '', '', '', 0, '11.94.', 'inbong.oh'
-- 변경이력: 
-- 2017.01.09 SP최초작성
-- 
-- ===============================================
CREATE PROC [dbo].[AssemblyDeployHistory_Save]
	@ASSEMBLYID NVARCHAR(30),
	@VERSION NVARCHAR(50),
	@SIZE INT,
	@FILECONTENT VARBINARY(MAX) = NULL,
	@REASON NVARCHAR(300),
	@ISESSENTIAL BIT,
	@IPADDRESS NVARCHAR(20),
	@CHANGEBY nvarchar(50)
AS
IF EXISTS (SELECT 1 FROM FILEDB.dbo.FileContent WITH(NOLOCK) WHERE FILEID = @ASSEMBLYID)
BEGIN
	UPDATE FILEDB.dbo.FileContent
	SET FILECONTENT = @FILECONTENT,
		[VERSION] = @VERSION,
		UPDTTM = GETDATE(),
		UPBY = @CHANGEBY
	WHERE FILEID = @ASSEMBLYID
END
ELSE
BEGIN
	INSERT INTO FILEDB.dbo.FileContent
	        ( FILEID, [VERSION], FILECONTENT, INITDTTM, INITBY )
	VALUES  ( @ASSEMBLYID, @VERSION, @FILECONTENT, GETDATE(), @CHANGEBY ) 
END

UPDATE FILEDB.dbo.EBAPFileMaster
	SET FILEVERSION = @VERSION,
		DEPLOYCOUNT = ISNULL(DEPLOYCOUNT, 0) + 1,
		LASTUPDTTM = GETDATE()
	WHERE FILEID = @ASSEMBLYID

INSERT INTO FILEDB.dbo.EBAPDeployHistory
		(FILEID, 
		 [VERSION], 
		 SIZE,
		 REASON, 
		 ISESSENTIAL, 
		 IPADDRESS,
		 CHANGEDTTM,
		 CHANGEBY )
VALUES  (@ASSEMBLYID,
         @VERSION,
         @SIZE,
         @REASON,
         @ISESSENTIAL,
         @IPADDRESS,
		 GETDATE(),
		 @CHANGEBY )


GO
/****** Object:  StoredProcedure [dbo].[AssemblyDeployHistory_Select]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===============================================
-- 작성자: 오인봉
-- 작성일: 2017.07.31
-- 설   명: Assembly 배포 이력 조회
-- 샘플실행: EXEC AssemblyDeployHistory_Select ''
-- 변경이력: 
-- 2017.01.09 SP최초작성
-- 
-- ===============================================
CREATE Procedure [dbo].[AssemblyDeployHistory_Select]
	@ASSEMBLYID varchar(10)
AS
DECLARE @query NVARCHAR(MAX)

SET @query = N''
SET @query = @query + N'
SELECT A.FILEID ASSEMBLYID
	 , B.FILENAME ASSEMBLYNAME
	 , A.VERSION
	 --, CAST((A.SIZE / 1000) as varchar) + ''KB'' SIZE
	 , CONCAT(FORMAT(A.SIZE / 1000, ''#,#''), '' KB'') SIZE
	 , A.REASON
	 , A.ISESSENTIAL
	 , dbo.fnGetUserName(A.CHANGEBY) AS DEPLOYWORKER
	 , A.IPADDRESS
	 , A.CHANGEDTTM 
FROM FILEDB.dbo.EBAPDeployHistory AS A WITH(NOLOCK)
JOIN FILEDB.dbo.EBAPFileMaster AS B WITH(NOLOCK) 
ON A.FILEID = B.FILEID  
WHERE 1 = 1 '

IF @ASSEMBLYID <> ''
	SET @query = @query + 'AND A.FILEID = ''' + @ASSEMBLYID + ''' ' + CHAR(10)
	
SET @query = @query + 'ORDER BY A.CHANGEDTTM DESC '

PRINT @query
EXECUTE sp_executesql @query

GO
/****** Object:  StoredProcedure [dbo].[AssemblyDownloadList_Select]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===============================================
-- 작성자: 오인봉
-- 작성일: 2017.12.30
-- 설   명: Assembly Download List 조회
-- 샘플실행: EXEC AssemblyDownloadList_Select 'system'
-- 변경이력: 
-- 2017.12.30 SP최초작성
-- 
-- ===============================================
CREATE PROC [dbo].[AssemblyDownloadList_Select]
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
/****** Object:  StoredProcedure [dbo].[AssemblyFileContent_Get]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===============================================
-- 작성자: 오인봉
-- 작성일: 2017.12.30
-- 설   명: Assembly File Content 가져오기
-- 샘플실행: EXEC AssemblyFileContent_Get ''
-- 변경이력: 
-- 2017.12.30 SP최초작성
-- 
-- ===============================================
CREATE PROC [dbo].[AssemblyFileContent_Get]
	@ASSEMBLYID varchar(30)
AS
SELECT FILECONTENT AS ASSEMBLYFILECONTENT
FROM FILEDB.dbo.FileContent WITH(NOLOCK)
WHERE FILEID = @ASSEMBLYID


GO
/****** Object:  StoredProcedure [dbo].[AssemblyID_Get]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===============================================
-- 작성자: 오인봉
-- 작성일: 2017.11.24
-- 설   명: Assembly ID 가져오기
-- 샘플실행: EXEC AssemblyID_Get
-- 변경이력: 
-- 2017.01.09 SP최초작성
-- 
-- ===============================================
CREATE Procedure [dbo].[AssemblyID_Get]
AS
SELECT FILEID AS CODEVALUE, FILEID + ' : ' + [FILENAME] AS DISPLAYVALUE 
FROM FILEDB.dbo.EBAPFileMaster WITH(NOLOCK)

GO
/****** Object:  StoredProcedure [dbo].[AssemblyMaster_Delete]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 
==============================================================================================
 작 성 자 : 오인봉
 작 성 일 : 2017.11.24 09:42:49
 설    명 : Assembly 마스터 삭제
 샘플실행 : EXEC dbo.AssemblyMaster_Delete ''

 변경이력 : 
==============================================================================================
*/ 
CREATE PROC [dbo].[AssemblyMaster_Delete]
	@ASSEMBLYID nvarchar(30)
AS
BEGIN TRY
	BEGIN TRANSACTION

		DELETE FROM FILEDB.dbo.EBAPFileMaster
		WHERE FILEID = @ASSEMBLYID

	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.AssemblyMaster_Delete : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	
	ROLLBACK TRANSACTION;
END CATCH

GO
/****** Object:  StoredProcedure [dbo].[AssemblyMaster_Save]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2016.02.25 09:59:58
 설    명 : AssemblyMaster Table 저장 
 샘플실행 : EXEC dbo.AssemblyMaster_Save '', '', '', '', ''

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[AssemblyMaster_Save]
	@ASSEMBLYID nvarchar(30),
	@ASSEMBLYNAME nvarchar(100),
	@ISCOMMON bit,
	@DESCRIPTION nvarchar(200),
	@CHANGEBY nvarchar(50)
AS
BEGIN TRY
	BEGIN TRANSACTION

	IF @ASSEMBLYID IS NULL OR @ASSEMBLYID = ''
	BEGIN
		DECLARE @serial int
	
		SELECT @serial = ISNULL(RIGHT(MAX(FILEID), 4), 0) + 1  FROM FILEDB.dbo.EBAPFileMaster WITH(NOLOCK)
	
		SET @ASSEMBLYID = 'ASM' + FORMAT(@serial, '0000')
	END

	IF NOT EXISTS (SELECT 1 FROM FILEDB.dbo.EBAPFileMaster WITH(NOLOCK) WHERE FILEID = @ASSEMBLYID) 
	BEGIN 
		INSERT INTO FILEDB.dbo.EBAPFileMaster ( FILEID, [FILENAME], ISCOMMON, [DESCRIPTION], INITDTTM, INITBY ) 
		VALUES ( @ASSEMBLYID, @ASSEMBLYNAME, @ISCOMMON, @DESCRIPTION, GETDATE(), @CHANGEBY ) 
	END 
	ELSE 
	BEGIN 
		UPDATE FILEDB.dbo.EBAPFileMaster
		SET [FILENAME] = @ASSEMBLYNAME
		  , ISCOMMON = @ISCOMMON
		  , [DESCRIPTION] = @DESCRIPTION
		  , UPDTTM = GETDATE()
		  , UPBY = @CHANGEBY
		WHERE FILEID = @ASSEMBLYID
	END 

	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.AssemblyMaster_Save : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH

GO
/****** Object:  StoredProcedure [dbo].[AssemblyMaster_Select]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===============================================
-- 작성자: 오인봉
-- 작성일: 2017.01.09
-- 설   명: Assembly Master 조회
-- 샘플실행: EXEC AssemblyMaster_Select ''
-- 변경이력: 
-- 2017.01.09 SP최초작성
-- 
-- ===============================================
CREATE Procedure [dbo].[AssemblyMaster_Select]
	@ASSEMBLYNAME nvarchar(100)
AS
SELECT A.FILEID ASSEMBLYID, 
	   A.[FILENAME] ASSEMBLYNAME, 
	   A.FILEVERSION ASSEMBLYVERSION, 
	   A.DEPLOYCOUNT, 
	   A.LASTUPDTTM,
	   A.ISCOMMON, 
	   A.[DESCRIPTION], 
	   ISNULL(A.UPDTTM, A.INITDTTM) CHANGEDTTM,
	   dbo.fnGetUserName(ISNULL(A.UPBY, A.INITBY)) CHANGEBY
FROM FILEDB.dbo.EBAPFileMaster AS A WITH(NOLOCK) 
WHERE 1 = 1 
AND A.[FILENAME] LIKE @ASSEMBLYNAME + '%' 
ORDER BY A.ISCOMMON DESC, A.FILEID


GO
/****** Object:  StoredProcedure [dbo].[AuthGroup_Delete]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 
==============================================================================================
 작 성 자 : 오인봉
 작 성 일 : 2017-06-19 08:42:09
 설    명 : AuthGroup Table 삭제
 샘플실행 : EXEC dbo.AuthGroup_Delete ''

 변경이력 : 
==============================================================================================
*/ 
CREATE PROC [dbo].[AuthGroup_Delete]
	@GROUPCODE nvarchar(40)
AS
BEGIN TRY
	BEGIN TRANSACTION
		DELETE FROM dbo.AuthGroup
		WHERE GROUPCODE = @GROUPCODE

		DELETE FROM dbo.AuthGroupUser
		WHERE GROUPCODE = @GROUPCODE

		DELETE FROM dbo.AuthGroupMenu
		WHERE GROUPCODE = @GROUPCODE
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.AuthGroup_Delete : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH


GO
/****** Object:  StoredProcedure [dbo].[AuthGroup_Save]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2017-02-06 11:22:43
 설    명 : AuthGroup Table 저장 
 샘플실행 : EXEC dbo.AuthGroup_Save

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[AuthGroup_Save]
	@GROUPCODE nvarchar(40),
	@GROUPNAME nvarchar(100),
	@CHECKPROCESS bit,
	@RESTRICTIONFLAG bit,
	@DESCRIPTION nvarchar(200),
	@CHANGEBY nvarchar(100),
	@AUTHTYPE VARCHAR(10) = ''
AS
BEGIN TRY
	BEGIN TRANSACTION
	IF NOT EXISTS (SELECT 1 FROM dbo.AuthGroup WITH(NOLOCK) WHERE GROUPCODE = @GROUPCODE) 
	BEGIN 
		INSERT INTO dbo.AuthGroup ( AUTHTYPE, GROUPCODE, GROUPNAME, CHECKPROCESS, RESTRICTIONFLAG, DESCRIPTION, INITDTTM, INITBY ) 
		VALUES ( @AUTHTYPE, @GROUPCODE, @GROUPNAME, @CHECKPROCESS, @RESTRICTIONFLAG, @DESCRIPTION, GETDATE(), @CHANGEBY ) 
	END 
	ELSE 
	BEGIN 
		UPDATE dbo.AuthGroup
		SET AUTHTYPE = @AUTHTYPE
		  , GROUPNAME = @GROUPNAME
		  , CHECKPROCESS = @CHECKPROCESS
		  , RESTRICTIONFLAG = @RESTRICTIONFLAG
		  , DESCRIPTION = @DESCRIPTION
		  , UPDTTM = GETDATE()
		  , UPBY = @CHANGEBY
		WHERE GROUPCODE = @GROUPCODE
	END 

	IF NOT EXISTS (SELECT 1 FROM AuthGroupUser WITH(NOLOCK) WHERE GROUPCODE = @GROUPCODE AND USERID = 'system')
	BEGIN
		INSERT INTO AuthGroupUser ( GROUPCODE, USERID, EXPIREDATE, ISDELEGATE, INITDTTM, INITBY ) 
		SELECT @GROUPCODE, USERID, '2050-12-31', 1, GETDATE(),  @CHANGEBY
		FROM dbo.UserInfo WITH(NOLOCK)
		WHERE 1 = 1
		AND ADMINFLAG = 1
		AND USERID NOT IN (SELECT USERID FROM dbo.AuthGroupUser WITH(NOLOCK) WHERE GROUPCODE = @GROUPCODE)
	END

	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.AuthGroup_Save : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH


GO
/****** Object:  StoredProcedure [dbo].[AuthGroup_Select]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 
==============================================================================================
-- 작 성 자: 오인봉
-- 작 성 일: 2017.12.28
-- 설    명: 권한 그룹 조회
-- 샘플실행: EXEC AuthGroup_Select 'system', '', 0, ''
-- 변경이력: 
-- 2017.12.28 SP최초작성
-- 
==============================================================================================
*/ 
CREATE PROC [dbo].[AuthGroup_Select]
	@USERID nvarchar(50),
	@GROUPNAME nvarchar(50) = '',
	@RESTRICTIONFLAG bit = 0,
	@AUTHTYPE VARCHAR(10) = ''
AS
SELECT A.AUTHTYPE,
	   A.GROUPCODE, 
       A.GROUPNAME, 
	   A.CHECKPROCESS, 
	   A.RESTRICTIONFLAG, 
	   A.[DESCRIPTION], 
	   ISNULL(A.UPDTTM, A.INITDTTM) CHANGEDTTM,
	   dbo.fnGetUserName(ISNULL(A.UPBY, A.INITBY)) CHANGEBY 
FROM dbo.AuthGroup A WITH(NOLOCK)
WHERE 1 = 1
AND A.GROUPNAME LIKE @GROUPNAME + '%'
AND A.GROUPCODE IN (SELECT GROUPCODE FROM dbo.AuthGroupUser WITH(NOLOCK) WHERE USERID = @USERID AND ISDELEGATE = 1)
AND A.AUTHTYPE LIKE @AUTHTYPE + '%'
AND A.RESTRICTIONFLAG = @RESTRICTIONFLAG
ORDER BY CASE WHEN A.GROUPCODE = 'ADMIN' THEN 1 ELSE 2 END, A.GROUPCODE, A.RESTRICTIONFLAG, A.GROUPNAME


GO
/****** Object:  StoredProcedure [dbo].[AuthGroupMenu_Save]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2016-02-06 11:49:01
 설    명 : AuthGroupMenu Table 저장 
 샘플실행 : EXEC dbo.AuthGroupMenu_Save

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[AuthGroupMenu_Save]
	@ISAUTH			BIT,
	@GROUPCODE nvarchar(20),
	@MENUID nvarchar(10),
	@SELECTAUTH bit,
	@NEWAUTH bit,
	@SAVEAUTH bit,
	@DELAUTH bit,
	@CHANGEBY nvarchar(50)
AS
BEGIN TRY
	BEGIN TRANSACTION
	IF @ISAUTH = 1
	BEGIN
		DECLARE @AUTHORITY VARCHAR(100)

		SET @AUTHORITY = CASE WHEN @SELECTAUTH = 1 THEN '1' ELSE '0' END + '/' + CASE WHEN @NEWAUTH = 1 THEN '1' ELSE '0' END + '/' + 
							CASE WHEN @SAVEAUTH = 1 THEN '1' ELSE '0' END + '/' + CASE WHEN @DELAUTH = 1 THEN '1' ELSE '0' END

		IF NOT EXISTS (SELECT 1 FROM dbo.AuthGroupMenu WITH(NOLOCK) WHERE GROUPCODE = @GROUPCODE AND MENUID = @MENUID) 
		BEGIN 
			INSERT INTO dbo.AuthGroupMenu ( GROUPCODE, MENUID, AUTHORITY, INITDTTM, INITBY ) 
			VALUES ( @GROUPCODE, @MENUID, @AUTHORITY, GETDATE(), @CHANGEBY ) 
		END 
		ELSE 
		BEGIN 
			UPDATE dbo.AuthGroupMenu
			SET AUTHORITY = @AUTHORITY
			  , UPDTTM = GETDATE()
			  , UPBY = @CHANGEBY
			WHERE GROUPCODE = @GROUPCODE AND MENUID = @MENUID
		END 
	END
	ELSE
	BEGIN
		DELETE FROM dbo.AuthGroupMenu
		WHERE GROUPCODE = @GROUPCODE AND MENUID = @MENUID
	END
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.AuthGroupMenu_Save : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH




GO
/****** Object:  StoredProcedure [dbo].[AuthGroupMenu_Select]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===============================================
-- 작성자: 오인봉
-- 작성일: 2017.12.28
-- 설   명: 권한 그룹 메뉴 조회
-- 샘플실행: EXEC AuthGroupMenu_Select 'AUTH001'
-- 변경이력: 
-- 2017.01.09 SP최초작성
-- 
-- ===============================================
CREATE PROC [dbo].[AuthGroupMenu_Select]
	@GROUPCODE NVARCHAR(20)
AS
SELECT  --CAST(ISNULL(SUBSTRING(B.AUTHORITY, 1, 1), 0) AS BIT) AS ISAUTH
		CAST(CASE WHEN B.AUTHORITY IS NULL THEN 0 ELSE 1 END AS BIT) AS ISAUTH
      , @GROUPCODE GROUPCODE
	  ,	A.MENUID
	  ,	A.MENUNAME
	  ,	A.PARENTMENUID
	  , CAST(ISNULL(SUBSTRING(B.AUTHORITY, 1, 1), 0) AS BIT) AS SELECTAUTH
	  , CAST(ISNULL(SUBSTRING(B.AUTHORITY, 3, 1), 0) AS BIT) AS NEWAUTH
	  , CAST(ISNULL(SUBSTRING(B.AUTHORITY, 5, 1), 0) AS BIT) AS SAVEAUTH
	  , CAST(ISNULL(SUBSTRING(B.AUTHORITY, 7, 1), 0) AS BIT) AS DELAUTH
	  , ISNULL(B.UPDTTM, B.INITDTTM) CHANGEDTTM
	  , ISNULL(B.UPBY, B.INITBY) CHANGEBY
FROM dbo.MenuMaster A WITH (NOLOCK)
LEFT JOIN (SELECT GROUPCODE, MENUID, AUTHORITY, INITDTTM, UPDTTM, INITBY, UPBY  FROM dbo.AuthGroupMenu WITH (NOLOCK)
					WHERE GROUPCODE = @GROUPCODE) B
ON A.MENUID = B.MENUID
ORDER BY LVL, IDX

GO
/****** Object:  StoredProcedure [dbo].[AuthGroupUser_Delete]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 
==============================================================================================
 작 성 자 : 오인봉
 작 성 일 : 2011-01-05 08:43:43
 설    명 : AuthGroupUser Table 삭제
 샘플실행 : EXEC dbo.AuthGroupUser_Delete '', ''

 변경이력 : 
==============================================================================================
*/ 
CREATE PROC [dbo].[AuthGroupUser_Delete]
	@GROUPCODE nvarchar(40),
	@USERID varchar(50)
AS
BEGIN TRY
	BEGIN TRANSACTION

		DELETE FROM dbo.AuthGroupUser
		WHERE GROUPCODE = @GROUPCODE AND USERID = @USERID

	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.AuthGroupUser_Delete : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH

GO
/****** Object:  StoredProcedure [dbo].[AuthGroupUser_Save]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2016-02-06 11:34:59
 설    명 : AuthGroupUser Table 저장 
 샘플실행 : EXEC dbo.AuthGroupUser_Save

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[AuthGroupUser_Save]
	@GROUPCODE nvarchar(20),
	@USERID nvarchar(50),
	@ISDELEGATE bit,
	@EXPIREDATE datetime,
	@CHANGEBY nvarchar(50)
AS
BEGIN TRY
	BEGIN TRANSACTION
	
	--SET @EXPIREDATE = '2050-12-31'
	--IF @ISDELEGATE = 0
	--BEGIN
	--	DELETE FROM dbo.AuthGroupUser 
	--	WHERE GROUPCODE = 'AUTH001' AND USERID = @USERID
	--END

	--IF @ISDELEGATE = 1
	--BEGIN
	--	IF NOT EXISTS (SELECT 1 FROM dbo.AuthGroupUser WITH(NOLOCK) WHERE GROUPCODE = 'AUTH001' AND USERID = @USERID) 
	--	BEGIN 
	--		INSERT INTO dbo.AuthGroupUser ( GROUPCODE, USERID, EXPIREDATE, ISDELEGATE, INITDTTM, INITBY ) 
	--		VALUES ( 'AUTH001', @USERID, @EXPIREDATE, CASE WHEN @USERID = 'system' THEN 1 ELSE 0 END, GETDATE(), @CHANGEBY ) 
	--	END 
	--END

	IF NOT EXISTS (SELECT 1 FROM dbo.AuthGroupUser WITH(NOLOCK) WHERE GROUPCODE = @GROUPCODE AND USERID = @USERID) 
	BEGIN 
		INSERT INTO dbo.AuthGroupUser ( GROUPCODE, USERID, EXPIREDATE, ISDELEGATE, INITDTTM, INITBY ) 
		VALUES ( @GROUPCODE, @USERID, @EXPIREDATE, @ISDELEGATE, GETDATE(), @CHANGEBY ) 
	END 
	ELSE 
	BEGIN 
		UPDATE dbo.AuthGroupUser
		SET EXPIREDATE = @EXPIREDATE
		  , ISDELEGATE = @ISDELEGATE
		  , UPDTTM = GETDATE()
		  , UPBY = @CHANGEBY
		WHERE GROUPCODE = @GROUPCODE AND USERID = @USERID
	END 
	COMMIT TRANSACTION

	exec dbo.VendorPlantAuth_Batch
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.AuthGroupUser_Save : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH

GO
/****** Object:  StoredProcedure [dbo].[AuthGroupUser_Select]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 
==============================================================================================
 작 성 자: 오인봉
 작 성 일: 2017.12.28
 설    명: 권한 그룹 사용자 조회
 샘플실행: EXEC AuthGroupUser_Select 'ADMIN'
 
 변경이력: 

==============================================================================================
*/ 
CREATE PROC [dbo].[AuthGroupUser_Select]
	@GROUPCODE NVARCHAR(20),
	@USERNAME NVARCHAR(40) = ''
AS
SELECT ISNULL(B.GROUPCODE, '') AS GROUPCODE,
		RTRIM(A.USERID) AS USERID,
		RTRIM(A.USERNAME) AS USERNAME,
		RTRIM(A.DEPTNAME) AS DEPTNAME,
		B.EXPIREDATE,
		B.ISDELEGATE,
		ISNULL(B.UPDTTM, B.INITDTTM) CHANGEDTTM,
	    dbo.fnGetUserName(ISNULL(B.UPBY, B.INITBY)) CHANGEBY 
FROM dbo.UserInfo A WITH (NOLOCK)
JOIN dbo.AuthGroupUser B WITH (NOLOCK)
ON A.USERID = B.USERID
WHERE B.GROUPCODE = @GROUPCODE
AND A.USERNAME LIKE @USERNAME + '%'

GO
/****** Object:  StoredProcedure [dbo].[AuthGroupUser180_Delete]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/* 
==============================================================================================
 작 성 자 : 오인봉
 작 성 일 : 2017-07-23 15:40:01
 설    명 : 최종 로그인 일자 180 넘는 사용자 권한 삭제
 샘플실행 : EXEC dbo.AuthGroupUser180_Delete 180

 변경이력 : 
==============================================================================================
*/ 

CREATE PROCEDURE [dbo].[AuthGroupUser180_Delete]
	@DATECOUNT			INT
AS

BEGIN TRY
	BEGIN TRANSACTION
	
		DELETE FROM dbo.AuthGroupUser
		WHERE USERID IN (
			SELECT A.USERID
			--, A.LASTLOGIN
			--, B.USERNAME
			--, DATEDIFF(DD, A.LASTLOGIN, GETDATE()) LASTDATE
			--, B.EMAILADDRESS
			FROM (
			
				SELECT USERID, MAX(SIGNINTIME) LASTLOGIN FROM dbo.SignLog
				GROUP BY USERID
			) A
			JOIN dbo.UserInfo B
			ON A.USERID = B.USERID
			WHERE 1 = 1
			AND DATEDIFF(DD, A.LASTLOGIN, GETDATE()) > @DATECOUNT
		)
		AND GROUPCODE <> 'COMMON'

	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.AuthGroupUser180_Delete : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH



GO
/****** Object:  StoredProcedure [dbo].[CodeMaster_Delete]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 
==============================================================================================
 작 성 자 : 오인봉
 작 성 일 : 2017-07-23 15:40:01
 설    명 : 공통코드관리 대분류 삭제
 샘플실행 : EXEC dbo.CodeMaster_Delete ''

 변경이력 : 
==============================================================================================
*/ 

CREATE PROCEDURE [dbo].[CodeMaster_Delete]
	@CODEVALUE			VARCHAR(40)
AS

BEGIN TRY
	BEGIN TRANSACTION
		DELETE FROM dbo.CodeMaster
		WHERE CODEVALUE = @CODEVALUE		
				
		--하위 코드 삭제
		DELETE FROM dbo.CodeMaster
		WHERE PCODEVALUE = @CODEVALUE
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.CodeMaster_Delete : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH


GO
/****** Object:  StoredProcedure [dbo].[CodeMaster_Get]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===============================================
-- 작성자: 오인봉
-- 작성일: 2017.08.04
-- 설   명: Code Master 조회
-- 샘플실행: EXEC CodeMaster_Get 'C$VendorCode', ''
-- 변경이력: 
-- 2017.08.04 SP최초작성
-- 
-- ===============================================
CREATE PROC [dbo].[CodeMaster_Get]
	@PCODEVALUE NVARCHAR(40),
	@CODEVALUE NVARCHAR(40),
	@INCLUDEDISPLAY VARCHAR(1) = 'N'
AS
DECLARE @query nvarchar(MAX)

SET @query = N''
SET @query = @query + '
	SELECT  A.CODEVALUE, '

IF @INCLUDEDISPLAY = 'N'
	SET @query = @query + '			RTRIM(A.DISPLAYVALUE) AS DISPLAYVALUE '
ELSE
	SET @query = @query + '			RTRIM(A.CODEVALUE) + '' : '' + RTRIM(A.DISPLAYVALUE) AS DISPLAYVALUE '

SET @query = @query + '	
	FROM dbo.CodeMaster A WITH(NOLOCK)
	WHERE 1 = 1 
	AND A.USEFLAG = 1'

IF @PCODEVALUE <> N''
	SET @query = @query + N'
		AND A.PCODEVALUE = ''' + @PCODEVALUE + ''' '

IF @CODEVALUE <> N''
	SET @query = @query + N'
	AND A.CODEVALUE = ''' + @CODEVALUE + ''' '

SET @query = @query + N'
	ORDER BY A.IDX '

PRINT @query

EXEC(@query)



GO
/****** Object:  StoredProcedure [dbo].[CodeMaster_Save]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2015-12-11 14:36:21
 설    명 : CodeMaster Table 저장 
 샘플실행 : EXEC dbo.CodeMaster_Save

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[CodeMaster_Save]
	@CODEVALUE nvarchar(40),
	@DISPLAYVALUE nvarchar(80),
	@IDX smallint,
	@CHANGEBY nvarchar(50)
AS
BEGIN TRY
	BEGIN TRANSACTION
	IF NOT EXISTS (SELECT 1 FROM dbo.CodeMaster WITH(NOLOCK) WHERE CODEVALUE = @CODEVALUE AND PCODEVALUE = 'P') 
	BEGIN 
		INSERT INTO dbo.CodeMaster ( CODEVALUE, DISPLAYVALUE, PCODEVALUE, IDX, REF1, REF2, REF3, USEFLAG, INITDTTM, INITBY ) 
		VALUES ( @CODEVALUE, @DISPLAYVALUE, 'P', @IDX, '', '', '', 1, GETDATE(), @CHANGEBY  ) 
	END 
	ELSE 
	BEGIN 
		UPDATE dbo.CodeMaster
		SET DISPLAYVALUE = @DISPLAYVALUE
		  , IDX = @IDX
		  , UPDTTM = GETDATE()
		  , UPBY = @CHANGEBY
		WHERE CODEVALUE = @CODEVALUE AND PCODEVALUE = 'P'
	END 
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.CodeMaster_Save : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH


GO
/****** Object:  StoredProcedure [dbo].[CodeMaster_Select]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2015-12-11 14:17:15
 설    명 : CodeMasterTable 조회 
 샘플실행 : EXEC dbo.CodeMaster_Select ''

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[CodeMaster_Select]
	@DISPLAYVALUE nvarchar(80)
AS

DECLARE @query NVARCHAR(MAX)

SET @query = N''
SET @query = @query + N'
	SELECT  CODEVALUE,
			DISPLAYVALUE,
			IDX,
			ISNULL(UPDTTM, INITDTTM) CHANGEDTTM,
			ISNULL(UPBY, INITBY) CHANGEBY
	FROM dbo.CodeMaster WITH(NOLOCK) 
	WHERE PCODEVALUE = ''P'' '

--조회조건
IF @DisplayValue <> N''
	SET @query = @query + N'
		AND DISPLAYVALUE LIKE ''%' + @DISPLAYVALUE + '%'' '

--PRINT, 실행
PRINT @query
EXECUTE sp_executesql @query



GO
/****** Object:  StoredProcedure [dbo].[CodeMasterDetail_Delete]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 
==============================================================================================
 작 성 자 : 오인봉
 작 성 일 : 2010-07-23 17:13:36
 설    명 : 공통코드관리 소분류 삭제
 샘플실행 : EXEC dbo.CodeMasterDetail_Delete

 변경이력 : 
==============================================================================================
*/ 

CREATE PROCEDURE [dbo].[CodeMasterDetail_Delete]
	@CODEVALUE				NVARCHAR(40),
	@PCODEVALUE				NVARCHAR(40)	
AS

BEGIN TRY
	BEGIN TRANSACTION
		DELETE FROM dbo.CodeMaster
		WHERE CODEVALUE = @CODEVALUE AND PCODEVALUE = @PCODEVALUE
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.CodeMasterDetail_Delete : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH


GO
/****** Object:  StoredProcedure [dbo].[CodeMasterDetail_Save]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2015-12-11 14:46:46
 설    명 : CodeMaster Table 저장 
 샘플실행 : EXEC dbo.CodeMasterDetail_Save

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[CodeMasterDetail_Save]
	@CODEVALUE nvarchar(40),
	@DISPLAYVALUE nvarchar(80),
	@PCODEVALUE nvarchar(40),
	@IDX smallint,
	@REF1 nvarchar(40),
	@REF2 nvarchar(20),
	@REF3 nvarchar(20),
	@USEFLAG bit,
	@CHANGEBY nvarchar(50)
AS
BEGIN TRY
	BEGIN TRANSACTION
	IF NOT EXISTS (SELECT 1 FROM dbo.CodeMaster WITH(NOLOCK) WHERE CODEVALUE = @CODEVALUE AND PCODEVALUE = @PCODEVALUE) 
	BEGIN 
		INSERT INTO dbo.CodeMaster ( CODEVALUE, DISPLAYVALUE, PCODEVALUE, IDX, REF1, REF2, REF3, USEFLAG, INITDTTM, INITBY ) 
		VALUES ( @CODEVALUE, @DISPLAYVALUE, @PCODEVALUE, @IDX, @REF1, @REF2, @REF3, @USEFLAG, GETDATE(), @CHANGEBY ) 

		IF @PCODEVALUE IN ('C$VENDORCODE', 'C$PLANTCODE')
		BEGIN
			EXEC dbo.VendorPlantAuth_Batch
		END
	END 
	ELSE 
	BEGIN 
		UPDATE dbo.CodeMaster
		SET DISPLAYVALUE = @DISPLAYVALUE
		  , IDX = @IDX
		  , REF1 = @REF1
		  , REF2 = @REF2
		  , REF3 = @REF3
		  , USEFLAG = @USEFLAG
		  , UPDTTM = GETDATE()
		  , UPBY = @CHANGEBY
		WHERE CODEVALUE = @CODEVALUE AND PCODEVALUE = @PCODEVALUE
	END 
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.CodeMasterDetail_Save : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH


GO
/****** Object:  StoredProcedure [dbo].[CodeMasterDetail_Select]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2015-12-11 14:25:59
 설    명 : CodeMasterTable 조회 
 샘플실행 : EXEC dbo.CodeMasterDetail_Select

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[CodeMasterDetail_Select]
	@PCODEVALUE nvarchar(40)
AS
SELECT  CODEVALUE, 
		DISPLAYVALUE, 
		PCODEVALUE, 
		IDX, 
		REF1, 
		REF2, 
		REF3, 
		USEFLAG, 
		ISNULL(UPDTTM, INITDTTM) CHANGEDTTM,
		ISNULL(UPBY, INITBY) CHANGEBY
FROM dbo.CodeMaster WITH(NOLOCK) 
WHERE PCODEVALUE = @PCODEVALUE 
ORDER BY IDX



GO
/****** Object:  StoredProcedure [dbo].[CurrentUserInfo_Save]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 
==============================================================================================
 작 성 자 : 오인봉
 작 성 일 : 2015-12-28 15:42:50
 설    명 : 현재 사용자 정보 수정
 샘플실행 : EXEC CurrentUserInfo_Save

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[CurrentUserInfo_Save]
	@USERID nvarchar(50),
	@USERNAME nvarchar(40),
	@DEPTCODE nvarchar(10),
	@DEPTNAME nvarchar(40),
	@WORK nvarchar(40),
	@PHONE nvarchar(20),
	@OFFICEPHONE nvarchar(20),
	@CELLPHONE nvarchar(20),
	@EMAILADDRESS nvarchar(50),
	@PASSWORD nvarchar(60),
	@CHANGEBY nvarchar(50)
AS
BEGIN TRY
	BEGIN TRANSACTION
	IF NOT EXISTS (SELECT 1 FROM dbo.UserInfo WITH(NOLOCK) WHERE USERID = @USERID) 
	BEGIN 
		INSERT INTO dbo.UserInfo ( USERID, USERNAME, PWD, DEPTCODE, DEPTNAME, WORK, PHONE, OFFICEPHONE, CELLPHONE, EMAILADDRESS, INITDTTM, INITBY ) 
		VALUES ( @USERID, @USERNAME, @PASSWORD, @DEPTCODE, @DEPTNAME, @WORK, @PHONE, @OFFICEPHONE, @CELLPHONE, @EMAILADDRESS, GETDATE(), @CHANGEBY ) 
	END 
	ELSE 
	BEGIN 
		UPDATE dbo.UserInfo
		SET USERNAME = @USERNAME, 
			DEPTCODE = @DEPTCODE, 
			DEPTNAME = @DEPTNAME, 
			WORK = @WORK, 
			PHONE = @PHONE, 
			OFFICEPHONE = @OFFICEPHONE, 
			CELLPHONE = @CELLPHONE, 
			EMAILADDRESS = @EMAILADDRESS, 
			UPDTTM = GETDATE(), 
			UPBY = @CHANGEBY
		WHERE USERID = @USERID
	END 
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.CurrentUserInfo_Save : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH



GO
/****** Object:  StoredProcedure [dbo].[CurrentUserInfo_Select]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 
==============================================================================================
 작 성 자 : 오인봉
 작 성 일 : 2010-12-28 15:42:50
 설    명 : UserInfoTable 조회
 샘플실행 : EXEC CurrentUserInfo_Select 'system'

 변경이력 : 
==============================================================================================
*/ 
CREATE PROC [dbo].[CurrentUserInfo_Select]
	@USERID varchar(50)
AS
DECLARE @LASTVENDOR VARCHAR(20),
		@LASTIP VARCHAR(30),
		@MSGKEY VARCHAR(150)

SET @LASTVENDOR = ''
SET @LASTIP = ''
SET @MSGKEY = ''

SELECT TOP 1 @LASTVENDOR = VENDORCODE, @LASTIP = IPADDRESS FROM dbo.SignLog WITH(NOLOCK)
WHERE USERID = @USERID
ORDER BY SIGNINTIME DESC

SELECT @MSGKEY = TOKENID FROM dbo.UserToken WITH(NOLOCK)
WHERE USERID = @USERID

SELECT USERID, USERNAME, PWD, DEPTCODE, DEPTNAME, WORK, 
PHONE, OFFICEPHONE, CELLPHONE, EMAILADDRESS, 
USEFLAG, LOCKFLAG, ADMINFLAG, ISNULL(SSOFLAG, 0) SSOFLAG, @MSGKEY MSGKEY,
ISNULL(UPDTTM, INITDTTM) CHANGEDTTM,
ISNULL(UPBY, INITBY) CHANGEBY
FROM dbo.UserInfo WITH(NOLOCK) 
WHERE USERID = @USERID

SELECT A.GROUPCODE, B.GROUPNAME, B.RESTRICTIONFLAG, B.[DESCRIPTION], A.[EXPIREDATE], A.ISDELEGATE
FROM dbo.AuthGroupUser AS A WITH(NOLOCK) 
JOIN dbo.AuthGroup AS B WITH(NOLOCK) 
ON A.GROUPCODE = B.GROUPCODE
WHERE USERID = @USERID
ORDER BY B.RESTRICTIONFLAG

SELECT DISTINCT A.MENUID AS CODEVALUE, A.MENUID + ' : ' + B.MENUNAME + '(' + A.IPADDRESS + ')' AS DISPLAYVALUE 
FROM dbo.MyMenu A WITH(NOLOCK)
JOIN dbo.MenuMaster B WITH(NOLOCK)
ON A.MENUID = B.MENUID
WHERE 1 = 1
AND A.USERID = @USERID
AND A.GUBUN = 'S'

--SELECT MENUID AS CODEVALUE, MENUID + ' : ' + MENUNAME AS DISPLAYVALUE 
--FROM dbo.MenuMaster WITH(NOLOCK)
--WHERE MENUID IN (SELECT * FROM dbo.fnGetListParamTable(@STARTMENU))

SELECT DISTINCT A.MENUID AS CODEVALUE, A.MENUID + ' : ' + B.MENUNAME + '(' + A.IPADDRESS + ')' AS DISPLAYVALUE 
FROM dbo.MyMenu A WITH(NOLOCK)
JOIN dbo.MenuMaster B WITH(NOLOCK)
ON A.MENUID = B.MENUID
WHERE 1 = 1
AND A.USERID = @USERID
AND A.GUBUN = 'F'

--SELECT A.MENUID AS CODEVALUE, A.MENUID + ' : ' + B.MENUNAME AS DISPLAYVALUE 
--FROM dbo.FavoritesMenu AS A WITH(NOLOCK)
--JOIN dbo.MenuMaster AS B WITH(NOLOCK)
--ON A.MENUID = B.MENUID
--WHERE A.USERID = @USERID

SELECT DISTINCT A.MENUID AS CODEVALUE, A.MENUID + ' : ' + B.MENUNAME + '(' + A.IPADDRESS + ')' AS DISPLAYVALUE 
FROM dbo.MyMenu A WITH(NOLOCK)
JOIN dbo.MenuMaster B WITH(NOLOCK)
ON A.MENUID = B.MENUID
WHERE 1 = 1
AND A.USERID = @USERID
AND A.GUBUN = 'T'

--SELECT MENUID AS CODEVALUE, MENUID + ' : ' + MENUNAME AS DISPLAYVALUE 
--FROM dbo.MenuMaster WITH(NOLOCK)
--WHERE MENUID IN (SELECT * FROM dbo.fnGetListParamTable(@SHORTCUT))

SELECT VENDORCODE, B.DISPLAYVALUE VENDORNAME, A.EXPIREDATE, ISDELEGATE
FROM dbo.VendorAuth A WITH(NOLOCK)
JOIN dbo.CodeMaster B WITH(NOLOCK)
ON B.PCODEVALUE = 'C$VENDORCODE'
AND A.VENDORCODE = B.CODEVALUE
WHERE A.USERID = @USERID
GO
/****** Object:  StoredProcedure [dbo].[DatabaseID_Get]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===============================================
-- 작성자: 오인봉
-- 작성일: 2017.11.25
-- 설   명: Database ID 가져오기
-- 샘플실행: EXEC DatabaseID_Get 0
-- 변경이력: 
-- 2017.01.09 SP최초작성
-- 
-- ===============================================
CREATE Procedure [dbo].[DatabaseID_Get]
	@server_id INT
AS
DECLARE @query varchar(MAX),
		@servername	varchar(200)	

SELECT @servername = name
FROM sys.servers
WHERE server_id = @server_id

SET @query = 'SELECT database_id AS CODEVALUE, name AS DISPLAYVALUE ' + CHAR(10)
SET @query = @query + 'FROM [' + @servername + '].master.sys.databases WITH(NOLOCK)
WHERE 1 = 1
AND database_id > 4 '

PRINT @query
EXEC (@query)


GO
/****** Object:  StoredProcedure [dbo].[DatabaseLog_Select]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2016-07-14 13:10:51
 설    명 : DatabaseLogTable 조회 
 샘플실행 : EXEC dbo.DatabaseLog_Select 0 , 7, '', '', ''

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[DatabaseLog_Select]
	@SERVER_ID INT,
	@DATABASE_ID INT,
	@EVENT sysname,
	@OBJECT sysname,
	@OBJECTTYPE nvarchar(50)
AS
DECLARE @query			NVARCHAR(MAX),
		@servername		VARCHAR(200)
		--@databasename	VARCHAR(200),
		--@tablename		VARCHAR(200),
		--@ParmDefinition NVARCHAR(500)	

SELECT @servername = name
FROM sys.servers
WHERE server_id = @SERVER_ID

--SET @ParmDefinition = N'@v_databasename varchar(200) OUTPUT';
--SET @query = N'
--SELECT @v_databasename = name
--		FROM [' + @serverName + '].master.sys.databases
--WHERE database_id = ' +  CAST(@DATABASE_ID AS VARCHAR(10))

--EXECUTE sp_executesql @query, @ParmDefinition, @v_databasename = @databasename OUT

SET @query = N''
SET @query = @query + N'
SELECT  DATABASELOGID, 
	EVENT, 
	[Database],
	[SCHEMA], 
	OBJECT,
	OBJECTTYPE, 
	TSQL,
	POSTTIME
FROM [' + @servername + '].[LOGDB].dbo.DatabaseLog A WITH(NOLOCK) 
WHERE 1 = 1 
AND [Database] = ''' + DB_NAME(@database_id) + ''' '

IF @EVENT <> N''
	SET @query = @query + N'
AND A.EVENT = ''' + @EVENT + ''' '

IF @OBJECT <> N''
	SET @query = @query + N'
AND A.OBJECT = ''' + @OBJECT + ''' '

IF @OBJECTTYPE <> N''
	SET @query = @query + N'
AND A.OBJECTTYPE = ''' + @OBJECTTYPE + ''' '

SET @query = @query + N'
ORDER BY A.DATABASELOGID '


--PRINT, 실행
PRINT @query
EXECUTE sp_executesql @query

GO
/****** Object:  StoredProcedure [dbo].[DatabaseLogEvent_Get]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===============================================
-- 작성자: 오인봉
-- 작성일: 2017.11.25
-- 설   명: Table ID 가져오기
-- 샘플실행: EXEC DatabaseLogEvent_Get 0, 8
-- 변경이력: 
-- 2017.01.09 SP최초작성
-- 
-- ===============================================
CREATE Procedure [dbo].[DatabaseLogEvent_Get]
	@server_id INT,
	@database_id INT
AS
DECLARE @query nvarchar(MAX),
		@serverName VARCHAR(200)
		--@databasename	VARCHAR(200),
		--@ParmDefinition NVARCHAR(500)

SELECT @serverName = name
FROM sys.servers
WHERE server_id = @server_id

--SET @ParmDefinition = N'@v_databasename varchar(200) OUTPUT';
--SET @query = N'
--SELECT @v_databasename = name
--		FROM [' + @serverName + '].master.sys.databases
--WHERE database_id = ' +  CAST(@database_id AS VARCHAR(10))
							
--EXECUTE sp_executesql @query, @ParmDefinition, @v_databasename = @databasename OUT

SET @query = ''

SET @query = 'SELECT DISTINCT Event AS CODEVALUE, Event AS DISPLAYVALUE ' + CHAR(10)
SET @query = @query + 'FROM [' + @servername + '].[LOGDB].dbo.DatabaseLog WITH(NOLOCK)
WHERE 1 = 1 
AND [Database] = ''' + DB_NAME(@database_id) + ''' '

PRINT @query
EXEC (@query)

GO
/****** Object:  StoredProcedure [dbo].[DatabaseLogObject_Get]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===============================================
-- 작성자: 오인봉
-- 작성일: 2017.11.25
-- 설   명: Table ID 가져오기
-- 샘플실행: EXEC DatabaseLogObject_Get 0, 8
-- 변경이력: 
-- 2017.01.09 SP최초작성
-- 
-- ===============================================
CREATE Procedure [dbo].[DatabaseLogObject_Get]
	@server_id INT,
	@database_id INT
AS
DECLARE @query nvarchar(MAX),
		@serverName VARCHAR(200)
--		@databasename	VARCHAR(200),
--		@ParmDefinition NVARCHAR(500)

SELECT @serverName = name
FROM sys.servers
WHERE server_id = @server_id

--SET @ParmDefinition = N'@v_databasename varchar(200) OUTPUT';
--SET @query = N'
--SELECT @v_databasename = name
--		FROM [' + @serverName + '].master.sys.databases
--WHERE database_id = ' +  CAST(@database_id AS VARCHAR(10))
							
--EXECUTE sp_executesql @query, @ParmDefinition, @v_databasename = @databasename OUT

SET @query = ''

SET @query = '
SELECT DISTINCT Object AS CODEVALUE, Object AS DISPLAYVALUE 
FROM [' + @servername + '].[LOGDB].dbo.DatabaseLog WITH(NOLOCK)
WHERE 1 = 1 
AND [Database] = ''' + DB_NAME(@database_id) + ''' '

PRINT @query
EXEC (@query)


GO
/****** Object:  StoredProcedure [dbo].[DatabaseLogObjectType_Get]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===============================================
-- 작성자: 오인봉
-- 작성일: 2017.05.18
-- 설   명: Object Type ID 가져오기
-- 샘플실행: EXEC DatabaseLogObjectType_Get 0, 7
-- 변경이력: 
-- 2017.01.09 SP최초작성
-- 
-- ===============================================
CREATE Procedure [dbo].[DatabaseLogObjectType_Get]
	@server_id INT,
	@database_id INT
AS
DECLARE @query nvarchar(MAX),
		@serverName VARCHAR(200)
--		@databasename	VARCHAR(200),
--		@ParmDefinition NVARCHAR(500)

SELECT @serverName = name
FROM sys.servers
WHERE server_id = @server_id

--SET @ParmDefinition = N'@v_databasename varchar(200) OUTPUT';
--SET @query = N'
--SELECT @v_databasename = name
--		FROM [' + @serverName + '].master.sys.databases
--WHERE database_id = ' +  CAST(@database_id AS VARCHAR(10))
							
--EXECUTE sp_executesql @query, @ParmDefinition, @v_databasename = @databasename OUT

SET @query = ''

SET @query = '
SELECT DISTINCT ObjectType AS CODEVALUE, ObjectType AS DISPLAYVALUE 
FROM [' + @servername + '].[LOGDB].dbo.DatabaseLog WITH(NOLOCK)
WHERE 1 = 1 
AND [Database] = ''' + DB_NAME(@database_id) + ''' '

PRINT @query
EXEC (@query)


GO
/****** Object:  StoredProcedure [dbo].[DatabaseLogTSQL_Get]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===============================================
-- 작성자: 오인봉
-- 작성일: 2017.05.18
-- 설   명: T-SQL ID 가져오기
-- 샘플실행: EXEC DatabaseLogTSQL_Get 0, 5, 1
-- 변경이력: 
-- 2017.01.09 SP최초작성
-- 
-- ===============================================
CREATE Procedure [dbo].[DatabaseLogTSQL_Get]
	@server_id INT,
	@database_id INT,
	@DatabaseLogId int
AS
DECLARE @query nvarchar(MAX),
		@serverName VARCHAR(200)
		--@databasename	VARCHAR(200),
		--@ParmDefinition NVARCHAR(500)

SELECT @serverName = name
FROM sys.servers
WHERE server_id = @server_id

--SET @ParmDefinition = N'@v_databasename varchar(200) OUTPUT';
--SET @query = N'
--SELECT @v_databasename = name
--		FROM [' + @serverName + '].master.sys.databases
--WHERE database_id = ' +  CAST(@database_id AS VARCHAR(10))
							
--EXECUTE sp_executesql @query, @ParmDefinition, @v_databasename = @databasename OUT

SET @query = ''

SET @query = 'SELECT TSQL ' + CHAR(10)
SET @query = @query + 'FROM [' + @servername + '].[LOGDB].dbo.DatabaseLog WITH(NOLOCK)
WHERE 1 = 1 AND DatabaseLogId = ' + cast(@DatabaseLogId as varchar) + ' 
AND [Database] = ''' + DB_NAME(@database_id) + ''' '

PRINT @query
EXEC (@query)


GO
/****** Object:  StoredProcedure [dbo].[DB_Monitoring]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* 
==============================================================================================
 작 성 자 : 노호성
 작 성 일 : 2022-03-21 
 설    명 : DB 모니터링
 샘플실행 : 
 
 EXEC dbo.DB_Monitoring 'SP'
 EXEC dbo.DB_Monitoring 'TEXT', 150
 EXEC dbo.DB_Monitoring 'CPU'
 EXEC dbo.DB_Monitoring 'Memory'
 EXEC dbo.DB_Monitoring 'SP'

 변경이력 : 
==============================================================================================
*/ 
CREATE PROC [dbo].[DB_Monitoring]
	@Option VARCHAR(20),
	@VALUE1 INT = 0
AS
SET NOCOUNT ON

DECLARE @SPID INT

IF @Option = 'Monitoring' GOTO _Monitoring
IF @Option = 'TEXT' GOTO _TEXT
IF @Option = 'CPU' GOTO _CPU
IF @Option = 'Memory' GOTO _Memory
IF @Option = 'SP' GOTO _SP

RETURN -1


_Monitoring:

	DECLARE @sp_who2 TABLE (
		SPID INT,
		Status VARCHAR(255),
		Login  VARCHAR(255),
		HostName  VARCHAR(255),
		BlkBy  VARCHAR(255),
		DBName  VARCHAR(255),
		Command VARCHAR(255),
		CPUTime INT,
		DiskIO INT,
		LastBatch VARCHAR(255),
		ProgramName VARCHAR(255),
		SPID2 INT,
		REQUESTID INT
		)

	DECLARE @sp_who3 TABLE (
		SPID INT,
		Status VARCHAR(255),
		Login  VARCHAR(255),
		HostName  VARCHAR(255),
		BlkBy  VARCHAR(255),
		DBName  VARCHAR(255),
		Command VARCHAR(255),
		CPUTime INT,
		DiskIO INT,
		LastBatch VARCHAR(255),
		ProgramName VARCHAR(255),
		SPID2 INT,
		REQUESTID INT,
		DENFLG CHAR(1)
		)

	INSERT INTO @sp_who2 EXEC sp_who2

	--INSERT INTO @sp_who3
	--SELECT *, CASE WHEN EXISTS(SELECT * FROM @sp_who2 C WHERE CONVERT(VARCHAR(20), A.SPID) = C.BlkBy AND CONVERT(VARCHAR(20), C.SPID) <> C.BlkBy) THEN 'Y' ELSE 'N' END FROM @sp_who2 A 

	INSERT INTO @sp_who3
	SELECT *, 'N' FROM @sp_who2 A 

	SET @SPID = @@SPID

	SELECT C.client_net_address IP, A.*
	FROM @sp_who3 A LEFT JOIN sys.dm_exec_connections AS C on A.SPID = c.session_id
	WHERE 1=1 -- DBName = 'TAVISDB' 
	  AND Status NOT IN ('sleeping', 'DORMANT')
	  AND C.net_transport = 'TCP' 
	  AND A.SPID <> @SPID
	ORDER BY CPUTime DESC

RETURN 0;


_TEXT:
	dbcc inputbuffer(@VALUE1)
RETURN 0;


_CPU:
	declare @ms_now bigint

	select @ms_now = ms_ticks from sys. dm_os_sys_info ;

	select TOP 50 record_id ID ,
		   dateadd (ms , - 1 * ( @ms_now - [timestamp] ), GetDate ()) as ID2 ,
		   SQLProcessUtilization AS SQL ,
		   100 - ( SystemIdle + SQLProcessUtilization) as NOTSQL ,
		   100 - SystemIdle as TOTAL
	from (
		   select
				 record .value ( '(./Record/@id)[1]', 'int') as record_id ,
				 record .value ( '(./Record/SchedulerMonitorEvent/SystemHealth/SystemIdle)[1]' , 'int' ) as SystemIdle ,
				 record .value ( '(./Record/SchedulerMonitorEvent/SystemHealth/ProcessUtilization)[1]' , 'int' ) as SQLProcessUtilization ,
				 [timestamp]
		   from (
				 select timestamp , convert ( xml, record) as record
				 from sys . dm_os_ring_buffers
				 where ring_buffer_type = N'RING_BUFFER_SCHEDULER_MONITOR'
				 and record like '%<SystemHealth>%'
		   ) as x
	) as y
	order by record_id DESC

RETURN 0

_Memory:
	SELECT 1 AS ID,
		   total_page_file_kb / 1024 AS Total_Memory,
		   available_page_file_kb / 1024 AS FreeSpace_Memory,
		   (total_page_file_kb - available_page_file_kb) / 1024 AS Use_Memory
		   --(available_page_file_kb / 1024 * 100) / (total_page_file_kb / 1024),
		   --((total_page_file_kb - available_page_file_kb) / 1024 * 100) / (total_page_file_kb / 1024)
		FROM SYS.dm_os_sys_memory

RETURN 0

_SP:
	SELECT TOP 50 SP, TOT / 1000000.0 AS [TOT], (TOT / CNT) / 1000000.0 AS [AVG], CNT FROM (
			SELECT SP, SUM(total_elapsed_time) [TOT], SUM(execution_count) [CNT]  FROM (
					SELECT d.object_id, d.database_id, OBJECT_NAME(object_id, database_id) AS SP,   
						d.total_elapsed_time,   d.execution_count  
					FROM sys.dm_exec_procedure_stats AS d 
				) A
			GROUP BY A.SP
		) A
		WHERE ISNULL(SP, '') <> ''
		ORDER BY [AVG] DESC
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[FavoritesMenu_Delete]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2017-11-18 14:06:53
 설    명 : FavoritesMenu Table 삭제
 샘플실행 : EXEC dbo.FavoritesMenu_Delete

 변경이력 : 
==============================================================================================
*/ 
CREATE PROC [dbo].[FavoritesMenu_Delete]
	@USERID nvarchar(50),
	@MENUID nvarchar(10)
AS
BEGIN TRY
	BEGIN TRANSACTION

		DELETE FROM dbo.FavoritesMenu
		WHERE USERID = @USERID AND MENUID = @MENUID

	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.FavoritesMenu_Delete : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH


GO
/****** Object:  StoredProcedure [dbo].[FavoritesMenu_Save]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2017-10-25 13:07:03
 설    명 : FavoritesMenu Table 저장 
 샘플실행 : EXEC dbo.FavoritesMenu_Save '', ''

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[FavoritesMenu_Save]
	@USERID nvarchar(50),
	@MENUID nvarchar(10)
AS
BEGIN TRY
	BEGIN TRANSACTION
	IF NOT EXISTS (SELECT 1 FROM dbo.FavoritesMenu WITH(NOLOCK) WHERE USERID = @USERID AND MENUID = @MENUID) 
	BEGIN 
		INSERT INTO dbo.FavoritesMenu ( USERID, MENUID, INITDTTM, INITBY ) 
		VALUES ( @USERID, @MENUID, GETDATE(), @USERID ) 
	END 
	ELSE 
	BEGIN 
		UPDATE dbo.FavoritesMenu
		SET UPDTTM = GETDATE()
		  , UPBY = @USERID
		WHERE USERID = @USERID AND MENUID = @MENUID
	END 
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.FavoritesMenu_Save : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[FTPFileInfo_Delete]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2016-05-30 14:32:53
 설    명 : FTPFileInfo Table 삭제
 샘플실행 : EXEC dbo.FTPFileInfo_Delete

 변경이력 : 
==============================================================================================
*/ 
CREATE PROC [dbo].[FTPFileInfo_Delete]
	@FTPID nvarchar(50),
	@UIID nvarchar(30),
	@FTPKEY nvarchar(20),
	@FTPKEY2 nvarchar(20),
	@FILENAME nvarchar(80)
AS
BEGIN TRY
	BEGIN TRANSACTION
		DELETE FROM dbo.FTPFileInfo
		WHERE FTPID = @FTPID AND UIID = @UIID AND FTPKEY = @FTPKEY AND FTPKEY2 = @FTPKEY2 AND FILENAME = @FILENAME
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.FTPFileInfo_Delete : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH


GO
/****** Object:  StoredProcedure [dbo].[FTPFileInfo_Save]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2016-05-30 14:33:19
 설    명 : FTPFileInfo Table 저장 
 샘플실행 : EXEC dbo.FTPFileInfo_Save

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[FTPFileInfo_Save]
    @FTPID nvarchar(50),
	@UIID nvarchar(30),
	@FTPKEY nvarchar(20),
	@FTPKEY2 nvarchar(20),
	@FILENAME nvarchar(80),
	@FILEPATH nvarchar(150),
	@IDX smallint,
	@SIZE int,
	@CHANGEBY nvarchar(50)
AS
BEGIN TRY
	BEGIN TRANSACTION
	IF NOT EXISTS (SELECT 1 FROM dbo.FTPFileInfo WITH(NOLOCK) WHERE FTPID = @FTPID AND UIID = @UIID AND FTPKEY = @FTPKEY AND FTPKEY2 = @FTPKEY2 AND [FILENAME] = @FILENAME) 
	BEGIN 
		INSERT INTO dbo.FTPFileInfo ( FTPID, UIID, FTPKEY, FTPKEY2, [FILENAME], FILEPATH, IDX, SIZE, INITDTTM, INITBY ) 
		VALUES ( @FTPID, @UIID, @FTPKEY, @FTPKEY2, @FILENAME, @FILEPATH, @IDX, @SIZE, GETDATE(), @CHANGEBY ) 
	END 
	ELSE 
	BEGIN 
		UPDATE dbo.FTPFileInfo
		SET FILEPATH = @FILEPATH
		  , IDX = @IDX
		  , SIZE = @SIZE
		  , UPDTTM = GETDATE()
		  , UPBY = @CHANGEBY
		WHERE FTPID = @FTPID AND UIID = @UIID AND FTPKEY = @FTPKEY AND FTPKEY2 = @FTPKEY2 AND [FILENAME] = @FILENAME
	END 
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.FTPFileInfo_Save : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH


GO
/****** Object:  StoredProcedure [dbo].[FTPFileInfo_Select]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2016-05-30 14:27:03
 설    명 : FTPFileInfoTable 조회 
 샘플실행 : EXEC dbo.FTPFileInfo_Select '', '', '', ''

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[FTPFileInfo_Select]
	@FTPID nvarchar(50),
	@UIID nvarchar(30),
	@FTPKEY nvarchar(20),
	@FTPKEY2 nvarchar(20)
AS
SELECT  A.FTPID,
        A.UIID, 
		A.FTPKEY, 
		A.FTPKEY2, 
		'' FILEMODIFIEDDATE,
		A.FILEPATH,
		A.FILENAME, 
		A.SERVERFILENAME, 
		A.IDX, 
		A.SIZE, 
		ISNULL(A.UPBY, A.INITBY) CHANGEBY 
FROM dbo.FTPFileInfo A WITH(NOLOCK) 
WHERE A.FTPID = @FTPID AND A.UIID = @UIID AND A.FTPKEY = @FTPKEY AND A.FTPKEY2 = @FTPKEY2


GO
/****** Object:  StoredProcedure [dbo].[FTPInfo_Delete]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2016-05-25 15:24:50
 설    명 : FTPInfo Table 삭제
 샘플실행 : EXEC dbo.FTPInfo_Delete ''

 변경이력 : 
==============================================================================================
*/ 
CREATE PROC [dbo].[FTPInfo_Delete]
	@FTPID nvarchar(50)
AS
BEGIN TRY
	BEGIN TRANSACTION
		DELETE FROM dbo.FTPInfo
		WHERE FTPID = @FTPID
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.FTPInfo_Select : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH


GO
/****** Object:  StoredProcedure [dbo].[FTPInfo_Get]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2016-05-25 15:22:44
 설    명 : FTPInfoTable 조회 
 샘플실행 : EXEC dbo.FTPInfo_Get 'EBAP'

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[FTPInfo_Get]
	@FTPID nvarchar(50)
AS
SELECT  FTPID, 
	FTPSERVERPATH, 
	FTPPORT,
	FTPUSERID, 
	FTPPWD, 
	LIMITSIZE, 
	DIRECTORYPATH
FROM dbo.FTPInfo WITH(NOLOCK) 
WHERE 1 = 1
AND FTPID = @FTPID

GO
/****** Object:  StoredProcedure [dbo].[FTPInfo_Save]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2016-05-25 15:25:28
 설    명 : FTPInfo Table 저장 
 샘플실행 : EXEC dbo.FTPInfo_Save '', '', '', '', '', '', '', ''

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[FTPInfo_Save]
	@FTPID nvarchar(50),
	@FTPSERVERPATH nvarchar(50),
	@FTPPORT varchar(4),
	@FTPUSERID nvarchar(50),
	@FTPPWD nvarchar(50),
	@LIMITSIZE int,
	@DIRECTORYPATH nvarchar(50),
	@CHANGEBY nvarchar(50)
AS
BEGIN TRY
	BEGIN TRANSACTION
	IF NOT EXISTS (SELECT 1 FROM dbo.FTPInfo WITH(NOLOCK) WHERE FTPID = @FTPID) 
	BEGIN 
		INSERT INTO dbo.FTPInfo ( FTPID, FTPSERVERPATH, FTPPORT, FTPUSERID, FTPPWD, LIMITSIZE, DIRECTORYPATH, INITDTTM, INITBY ) 
		VALUES ( @FTPID, @FTPSERVERPATH, @FTPPORT, @FTPUSERID, @FTPPWD, @LIMITSIZE, @DIRECTORYPATH, GETDATE(), @CHANGEBY ) 
	END 
	ELSE 
	BEGIN 
		UPDATE dbo.FTPInfo
		SET FTPSERVERPATH = @FTPSERVERPATH
		  , FTPPORT = @FTPPORT
		  , FTPUSERID = @FTPUSERID
		  , FTPPWD = @FTPPWD
		  , LIMITSIZE = @LIMITSIZE
		  , DIRECTORYPATH = @DIRECTORYPATH
		  , UPDTTM = GETDATE()
		  , UPBY = @CHANGEBY
		WHERE FTPID = @FTPID
	END 
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.FTPInfo_Save : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH

GO
/****** Object:  StoredProcedure [dbo].[FTPInfo_Select]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2016-05-25 15:22:44
 설    명 : FTPInfoTable 조회 
 샘플실행 : EXEC dbo.FTPInfo_Select ''

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[FTPInfo_Select]
	@FTPID nvarchar(50)
AS
SELECT  FTPID, 
	FTPSERVERPATH, 
	FTPPORT,
	FTPUSERID, 
	FTPPWD, 
	LIMITSIZE, 
	DIRECTORYPATH, 
	ISNULL(UPDTTM, INITDTTM) CHANGEDTTM, 
	dbo.fnGetUserName(ISNULL(UPBY, INITBY)) CHANGEBY
FROM dbo.FTPInfo WITH(NOLOCK) 
WHERE 1 = 1
AND FTPID LIKE @FTPID + '%'


GO
/****** Object:  StoredProcedure [dbo].[HtmlContents_Get]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* 
==============================================================================================
 작 성 자 : 오인봉
 작 성 일 : 2018-02-14 10:22:27
 설    명 : HtmlContentsMasterTable 조회 
 샘플실행 : EXEC dbo.HtmlContents_Get 'RACB001'

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[HtmlContents_Get]
	@HTMLID varchar(20)
AS
DECLARE @query NVARCHAR(MAX)

SET @query = N''
SET @query = @query + N'
SELECT A.CONTENTS
FROM dbo.HtmlContentsMaster A WITH(NOLOCK) 
WHERE 1 = 1 '


IF @HTMLID <> N''
	SET @query = @query + N'
AND A.HTMLID = ''' + @HTMLID + ''' '

--PRINT, 실행
PRINT @query
EXECUTE sp_executesql @query
GO
/****** Object:  StoredProcedure [dbo].[HtmlContentsMaster_Delete]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* 
==============================================================================================
 작 성 자 : 오인봉
 작 성 일 : 2018-02-14 10:23:37
 설    명 : HtmlContentsMaster Table 삭제
 샘플실행 : EXEC dbo.HtmlContentsMaster_Delete ''

 변경이력 : 
==============================================================================================
*/ 
CREATE PROC [dbo].[HtmlContentsMaster_Delete]
	@HTMLID varchar(20)
AS
BEGIN TRY
	BEGIN TRANSACTION

		DELETE FROM dbo.HtmlContentsMaster
		WHERE HTMLID = @HTMLID

	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.HtmlContentsMaster_Delete : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH


GO
/****** Object:  StoredProcedure [dbo].[HtmlContentsMaster_Save]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* 
==============================================================================================
 작 성 자 : 오인봉
 작 성 일 : 2018-02-14 10:23:26
 설    명 : HtmlContentsMaster Table 저장 
 샘플실행 : EXEC dbo.HtmlContentsMaster_Save '', '', '', ''

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[HtmlContentsMaster_Save]
	@HTMLID varchar(20),
	@GBN varchar(1),
	@CONTENTS nvarchar(max),
	@CHANGEBY nvarchar(50)
AS
BEGIN TRY
	BEGIN TRANSACTION
	IF NOT EXISTS (SELECT 1 FROM dbo.HtmlContentsMaster WITH(NOLOCK) WHERE HTMLID = @HTMLID) 
	BEGIN 
		INSERT INTO dbo.HtmlContentsMaster ( HTMLID, GBN, CONTENTS, INITDTTM, INITBY ) 
		VALUES ( @HTMLID, @GBN, @CONTENTS, GETDATE(), @CHANGEBY ) 
	END 
	ELSE 
	BEGIN 
		UPDATE dbo.HtmlContentsMaster
		SET GBN = @GBN
		  , CONTENTS = @CONTENTS
		  , UPDTTM = GETDATE()
		  , UPBY = @CHANGEBY
		WHERE HTMLID = @HTMLID
	END 
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.HtmlContentsMaster_Save : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH


GO
/****** Object:  StoredProcedure [dbo].[HtmlContentsMaster_Select]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* 
==============================================================================================
 작 성 자 : 오인봉
 작 성 일 : 2018-02-14 10:22:27
 설    명 : HtmlContentsMasterTable 조회 
 샘플실행 : EXEC dbo.HtmlContentsMaster_Select '', ''

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[HtmlContentsMaster_Select]
	@HTMLID varchar(20),
	@GBN varchar(1)
AS
DECLARE @query NVARCHAR(MAX)

SET @query = N''
SET @query = @query + N'
SELECT A.HTMLID
	 , A.GBN
	 , A.CONTENTS
	 , ISNULL(A.UPDTTM, A.INITDTTM) CHANGEDTTM 
	 , ISNULL(A.UPBY, A.INITBY) CHANGEBY 
FROM dbo.HtmlContentsMaster A WITH(NOLOCK) 
WHERE 1 = 1 '


IF @HTMLID <> N''
	SET @query = @query + N'
		AND A.HTMLID LIKE ''' + @HTMLID + '%'' '

IF @GBN <> N''
	SET @query = @query + N'
		AND A.GBN = ''' + @GBN + ''' '

--PRINT, 실행
PRINT @query
EXECUTE sp_executesql @query
GO
/****** Object:  StoredProcedure [dbo].[IssueList_Delete]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2011-08-12 14:56:56
 설    명 : IssueList Table 삭제
 샘플실행 : EXEC dbo.IssueList_Delete

 변경이력 : 
==============================================================================================
*/ 
CREATE PROC [dbo].[IssueList_Delete]
	@Seq bigint
AS
BEGIN TRY
	BEGIN TRANSACTION
		DELETE FROM dbo.IssueList
		WHERE Seq = @Seq
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.IssueList_Delete : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH

GO
/****** Object:  StoredProcedure [dbo].[IssueList_Save]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2011-08-12 14:56:07
 설    명 : IssueList Table 저장 
 샘플실행 : EXEC dbo.IssueList_Save

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[IssueList_Save]
	@Seq bigint,
	@Project nvarchar(40),
	@WorkType nchar(4),
	@ObjType nchar(4),
	@RegDate datetime,
	@RegWorker nvarchar(100),
	@IssueTitle nvarchar(300),
	@IssueDetail nvarchar(2000),
	@RequestDate datetime,
	@CompletePlanDate datetime,
	@IssueStatus char(1),
	@Worker nvarchar(100),
	@CompleteDetail nvarchar(800),
	@CompleteDate datetime,
	@ReleaseDate datetime,
	@LCategory nvarchar(60),
	@MCategory nvarchar(60),
	@MenuName nvarchar(60),
	@Priority char(1)
AS
BEGIN TRY
	BEGIN TRANSACTION
	IF NOT EXISTS (SELECT 1 FROM dbo.IssueList WITH(NOLOCK) WHERE Seq = @Seq) 
	BEGIN 
		INSERT INTO dbo.IssueList ( Project, WorkType, ObjType, RegDate, RegWorker, IssueTitle, IssueDetail, RequestDate, CompletePlanDate, IssueStatus, Worker, CompleteDetail, CompleteDate, ReleaseDate, LCategory, MCategory, MenuName, Priority, UpdateDate) 
		VALUES ( @Project, @WorkType, @ObjType, @RegDate, @RegWorker, @IssueTitle, @IssueDetail, @RequestDate, @CompletePlanDate, @IssueStatus, @Worker, @CompleteDetail, @CompleteDate, @ReleaseDate, @LCategory, @MCategory, @MenuName, @Priority, GETDATE() ) 
	END 
	ELSE 
	BEGIN 
		UPDATE dbo.IssueList
			SET Project = @Project, 
			WorkType = @WorkType, 
			ObjType = @ObjType, 
			RegDate = @RegDate, 
			RegWorker = @RegWorker, 
			IssueTitle = @IssueTitle, 
			IssueDetail = @IssueDetail, 
			RequestDate = @RequestDate, 
			CompletePlanDate = @CompletePlanDate, 
			IssueStatus = @IssueStatus, 
			Worker = @Worker, 
			CompleteDetail = @CompleteDetail, 
			CompleteDate = @CompleteDate, 
			ReleaseDate = @ReleaseDate, 
			LCategory = @LCategory, 
			MCategory = @MCategory, 
			MenuName = @MenuName, 
			Priority = @Priority, 
			UpdateDate = GETDATE()
		WHERE Seq = @Seq
	END 
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.IssueList_Save : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH



GO
/****** Object:  StoredProcedure [dbo].[IssueList_Select]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2011-08-12 11:39:31
 설    명 : IssueListTable 조회 
 샘플실행 : EXEC dbo.IssueList_Select

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[IssueList_Select]
	
AS
SELECT Seq,  Project, 
WorkType, 
dbo.fnGetCodeMasterValue('WorkType', WorkType) AS WorkTypeName,
ObjType, 
dbo.fnGetCodeMasterValue('ObjType', ObjType) AS ObjTypeName,
RegDate, 
RegWorker, 
IssueTitle, 
IssueDetail, 
RequestDate, 
CompletePlanDate, 
IssueStatus, 
dbo.fnGetCodeMasterValue('IssueStatus', IssueStatus) AS IssueStatusName,
Worker, 
CompleteDetail, 
CompleteDate, 
YEAR(CompleteDate) AS CompleteYear,
MONTH(CompleteDate) AS CompleteMonth,
DAY(CompleteDate) AS CompleteDay,
ReleaseDate, 
LCategory, 
MCategory, 
MenuName, 
Priority, 1 AS RowCnt
FROM dbo.IssueList WITH(NOLOCK) 



GO
/****** Object:  StoredProcedure [dbo].[LinkMenu_Delete]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2022-01-21 08:57:35
 설    명 : LinkMenu Table 삭제
 샘플실행 : EXEC dbo.LinkMenu_Delete ''

 변경이력 : 
==============================================================================================
*/ 
CREATE PROC [dbo].[LinkMenu_Delete]
	@MENUID varchar(40)
AS
BEGIN TRY
	BEGIN TRANSACTION

		DELETE FROM dbo.LinkMenu
		WHERE MENUID = @MENUID

	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.LinkMenu_Delete : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[LinkMenu_Get]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===============================================
-- 작성자: 오인봉
-- 작성일: 2018.08.04
-- 설   명: Link Menu 조회
-- 샘플실행: EXEC LinkMenu_Get
-- 변경이력: 
-- 2017.08.04 SP최초작성
-- 
-- ===============================================
CREATE PROC [dbo].[LinkMenu_Get]
AS
DECLARE @query nvarchar(MAX)

SET @query = N''
SET @query = @query + '
SELECT A.MENUID
	 , A.MENUNAME
	 , A.LINKURL
	 , A.LINKTYPE
	 , A.ISBEGINGROUP
FROM dbo.LinkMenu A WITH(NOLOCK)
WHERE 1 = 1 
AND A.USEFLAG = 1'

SET @query = @query + N'
ORDER BY A.IDX '

PRINT @query

EXEC(@query)



GO
/****** Object:  StoredProcedure [dbo].[LinkMenu_Save]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2022-01-21 08:56:32
 설    명 : LinkMenu Table 저장 
 샘플실행 : EXEC dbo.LinkMenu_Save

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[LinkMenu_Save]
	@MENUID varchar(40),
	@MENUNAME nvarchar(50),
	@LVL smallint,
	@IDX smallint,
	@LINKURL varchar(300),
	@DESCRIPTION nvarchar(300),
	@USEFLAG bit,
	@LINKTYPE varchar(1),
	@ISBEGINGROUP bit,
	@CHANGEBY nvarchar(50)
AS
BEGIN TRY
	BEGIN TRANSACTION
	IF NOT EXISTS (SELECT 1 FROM dbo.LinkMenu WITH(NOLOCK) WHERE MENUID = @MENUID) 
	BEGIN 
		INSERT INTO dbo.LinkMenu ( MENUID, MENUNAME, LVL, IDX, LINKURL, DESCRIPTION, USEFLAG, LINKTYPE, ISBEGINGROUP, INITDTTM, INITBY) 
		VALUES ( @MENUID, @MENUNAME, @LVL, @IDX, @LINKURL, @DESCRIPTION, @USEFLAG, @LINKTYPE, @ISBEGINGROUP, GETDATE(), @CHANGEBY ) 
	END 
	ELSE 
	BEGIN 
		UPDATE dbo.LinkMenu
		SET MENUNAME = @MENUNAME
		  , LVL = @LVL
		  , IDX = @IDX
		  , LINKURL = @LINKURL
		  , DESCRIPTION = @DESCRIPTION
		  , USEFLAG = @USEFLAG
		  , LINKTYPE = @LINKTYPE
		  , ISBEGINGROUP = @ISBEGINGROUP
		  , UPDTTM = GETDATE()
		  , UPBY = @CHANGEBY
		WHERE MENUID = @MENUID
	END 
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.LinkMenu_Save : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[LinkMenu_Select]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2022-01-21 08:54:19
 설    명 : LinkMenuTable 조회 
 샘플실행 : EXEC dbo.LinkMenu_Select ''

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[LinkMenu_Select]
	@MENUNAME nvarchar(50)
AS
DECLARE @query NVARCHAR(MAX)

SET @query = N''
SET @query = @query + N'
SELECT A.MENUID
	 , A.MENUNAME
	 , A.LVL
	 , A.IDX
	 , A.LINKURL
	 , A.DESCRIPTION
	 , A.USEFLAG
	 , A.LINKTYPE
	 , A.ISBEGINGROUP
	 , ISNULL(A.UPDTTM, A.INITDTTM) CHANGEDTTM 
	 , ISNULL(A.UPBY, A.INITBY) CHANGEBY 
FROM dbo.LinkMenu A WITH(NOLOCK) 
WHERE 1 = 1 '

--조회조건
IF @MENUNAME <> N''
	SET @query = @query + N'
AND MENUNAME LIKE ''%' + @MENUNAME + '%'' '

--PRINT, 실행
PRINT @query
EXECUTE sp_executesql @query

GO
/****** Object:  StoredProcedure [dbo].[LocaleMaster_Delete]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2016-02-12 16:58:24
 설    명 : LocaleMaster Table 삭제
 샘플실행 : EXEC dbo.LocaleMaster_Delete 0

 변경이력 : 
==============================================================================================
*/ 
CREATE PROC [dbo].[LocaleMaster_Delete]
	@STRINGID bigint
AS
BEGIN TRY
	BEGIN TRANSACTION
		DELETE FROM dbo.LocaleMaster
		WHERE STRINGID = @STRINGID
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.LocaleMaster_Delete : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH


GO
/****** Object:  StoredProcedure [dbo].[LocaleMaster_Get]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===============================================
-- 작성자: 오인봉
-- 작성일: 2017.03.15
-- 설   명: Locale Master 가져오기
-- 샘플실행: EXEC LocaleMaster_Get 'ko-KR'
-- 변경이력: 
-- 2017.03.15 SP최초작성
-- 
-- ===============================================
CREATE PROC [dbo].[LocaleMaster_Get]
	@LOCALE nvarchar(20)
AS
DECLARE @query nvarchar(MAX)

SET @query = N''
--SET @query = @query + N'
--SELECT STRINGID, ENUMCLASS, ' + REPLACE(@Locale, '-', '') + ' AS [' + @Locale + '] FROM dbo.LocaleMaster WITH(NOLOCK) 
--WHERE ISEXPORT = 1 '

SET @query = @query + N'
SELECT STRINGID, ENUMCLASS, KOKR AS [ko-KR], ENUS AS [en-US] FROM dbo.LocaleMaster WITH(NOLOCK) 
WHERE ISEXPORT = 1 '

PRINT @query
EXEC(@query)

GO
/****** Object:  StoredProcedure [dbo].[LocaleMaster_Save]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2016-02-12 16:39:43
 설    명 : LocaleMaster Table 저장 
 샘플실행 : EXEC dbo.LocaleMaster_Save

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[LocaleMaster_Save]
	@KOKR nvarchar(200),
	@ENUS nvarchar(200),
	@ZHCHS nvarchar(200),
	@ENUMCLASS nvarchar(100),
	@ISEXPORT bit,
	@CHANGEBY nvarchar(50)
AS
BEGIN TRY
	BEGIN TRANSACTION
	IF NOT EXISTS (SELECT 1 FROM dbo.LocaleMaster WITH(NOLOCK) WHERE ENUMCLASS = @ENUMCLASS) 
	BEGIN 
		INSERT INTO dbo.LocaleMaster ( KOKR, ENUS, ZHCHS, ENUMCLASS, ISEXPORT, INITDTTM, INITBY ) 
		VALUES ( @KOKR, @ENUS, @ZHCHS, @ENUMCLASS, @ISEXPORT, GETDATE(), @CHANGEBY ) 
	END 
	ELSE 
	BEGIN 
		UPDATE dbo.LocaleMaster
		SET KOKR = @KOKR
		  , ENUS = @ENUS
		  , ZHCHS = @ZHCHS
		  , ENUMCLASS = @ENUMCLASS
		  , ISEXPORT = @ISEXPORT
		  , UPDTTM = GETDATE()
		  , UPBY = @CHANGEBY
		WHERE ENUMCLASS = @ENUMCLASS
	END 
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.LocaleMaster_Save : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH


GO
/****** Object:  StoredProcedure [dbo].[LocaleMaster_Select]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 
==============================================================================================
 작 성 자 : 오인봉
 작 성 일 : 2010-11-24 16:09:35
 설    명 : 다국어 사전 조회 
 샘플실행 : EXEC dbo.LocaleMaster_Select ''

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[LocaleMaster_Select]
	@KOKR nvarchar(1000)
AS
SELECT  STRINGID, 
		KOKR, 
		ENUS, 
		ZHCHS, 
		ENUMCLASS, 
		ISEXPORT, 
		ISNULL(UPDTTM, INITDTTM) CHANGEDTTM,
	    dbo.fnGetUserName(ISNULL(UPBY, INITBY)) CHANGEBY 
FROM dbo.LocaleMaster WITH(NOLOCK) 
WHERE KOKR LIKE '%' +  @KOKR + '%'



GO
/****** Object:  StoredProcedure [dbo].[LocaleMessageMaster_Delete]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 
==============================================================================================
 작 성 자 : 오인봉
 작 성 일 : 2010-11-25 08:05:58
 설    명 : 다국어 메시지 마스터 삭제
 샘플실행 : EXEC dbo.LocaleMessageMaster_Delete 0

 변경이력 : 
==============================================================================================
*/ 
CREATE PROC [dbo].[LocaleMessageMaster_Delete]
	@MessageID bigint
AS
BEGIN TRY
	BEGIN TRANSACTION
		DELETE FROM dbo.LocaleMessageMaster
		WHERE MessageID = @MessageID
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.LocaleMessageMaster_Delete : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH


GO
/****** Object:  StoredProcedure [dbo].[LocaleMessageMaster_Get]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===============================================
-- 작성자: 오인봉
-- 작성일: 2017.03.15
-- 설   명: 다국어 Message Master 가져오기
-- 샘플실행: EXEC LocaleMessageMaster_Get 'ko-KR'
-- 변경이력: 
-- 2017.03.15 SP최초작성
-- 
-- ===============================================
CREATE PROC [dbo].[LocaleMessageMaster_Get]
	@LOCALE nvarchar(20)
AS
DECLARE @query nvarchar(MAX)

SET @query = N''
--SET @query = @query + N'
--SELECT MESSAGEID, ENUMCLASS, ' + REPLACE(@LOCALE, '-', '') + ' AS [' + @LOCALE + '] FROM dbo.LocaleMessageMaster WITH(NOLOCK) 
--WHERE ISEXPORT = 1 '

SET @query = @query + N'
SELECT MESSAGEID, ENUMCLASS, KOKR AS [ko-KR], ENUS AS [en-US] FROM dbo.LocaleMessageMaster WITH(NOLOCK) 
WHERE ISEXPORT = 1 '

PRINT @query
EXEC(@query)

GO
/****** Object:  StoredProcedure [dbo].[LocaleMessageMaster_Save]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2016-02-12 16:39:43
 설    명 : LocaleMessageMaster Table 저장 
 샘플실행 : EXEC dbo.LocaleMessageMaster_Save

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[LocaleMessageMaster_Save]
	@KOKR nvarchar(200),
	@ENUS nvarchar(200),
	@ZHCHS nvarchar(200),
	@ENUMCLASS nvarchar(100),
	@ISEXPORT bit,
	@CHANGEBY nvarchar(50)
AS
BEGIN TRY
	BEGIN TRANSACTION
	IF NOT EXISTS (SELECT 1 FROM dbo.LocaleMessageMaster WITH(NOLOCK) WHERE ENUMCLASS = @ENUMCLASS) 
	BEGIN 
		INSERT INTO dbo.LocaleMessageMaster ( KOKR, ENUS, ZHCHS, ENUMCLASS, ISEXPORT, INITDTTM, INITBY ) 
		VALUES ( @KOKR, @ENUS, @ZHCHS, @ENUMCLASS, @ISEXPORT, GETDATE(), @CHANGEBY ) 
	END 
	ELSE 
	BEGIN 
		UPDATE dbo.LocaleMessageMaster
		SET KOKR = @KOKR
		  , ENUS = @ENUS
		  , ZHCHS = @ZHCHS
		  , ENUMCLASS = @ENUMCLASS
		  , ISEXPORT = @ISEXPORT
		  , UPDTTM = GETDATE()
		  , UPBY = @CHANGEBY
		WHERE ENUMCLASS = @ENUMCLASS
	END
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.LocaleMessageMaster_Save : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH


GO
/****** Object:  StoredProcedure [dbo].[LocaleMessageMaster_Select]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 
==============================================================================================
 작 성 자 : 오인봉
 작 성 일 : 2010-11-24 16:09:35
 설    명 : 다국어 사전 조회 
 샘플실행 : EXEC dbo.LocaleMessageMaster_Select ''

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[LocaleMessageMaster_Select]
	@KOKR nvarchar(1000)
AS
SELECT  MESSAGEID, 
		KOKR, 
		ENUS, 
		ZHCHS, 
		ENUMCLASS, 
		ISEXPORT, 
		ISNULL(UPDTTM, INITDTTM) CHANGEDTTM,
	    dbo.fnGetUserName(ISNULL(UPBY, INITBY)) CHANGEBY
FROM dbo.LocaleMessageMaster WITH(NOLOCK) 
WHERE KOKR LIKE '%' +  @KOKR + '%'




GO
/****** Object:  StoredProcedure [dbo].[MakeCSharpCode]    Script Date: 2024-08-19 오후 7:14:40 ******/
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
/****** Object:  StoredProcedure [dbo].[MakeDeleteProcedure]    Script Date: 2024-08-19 오후 7:14:40 ******/
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
/****** Object:  StoredProcedure [dbo].[MakeMergeSaveProcedure]    Script Date: 2024-08-19 오후 7:14:40 ******/
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
/****** Object:  StoredProcedure [dbo].[MakeSaveProcedure]    Script Date: 2024-08-19 오후 7:14:40 ******/
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
/****** Object:  StoredProcedure [dbo].[MakeSelectProcedure]    Script Date: 2024-08-19 오후 7:14:40 ******/
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
/****** Object:  StoredProcedure [dbo].[MenuAuth_Get]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ===============================================
-- 작성자: 오인봉
-- 작성일: 2017.01.09
-- 설   명: 사용자 권한 MENU 조회
-- 샘플실행: EXEC MenuAuth_Get 'system', '0000000001', '1031'
-- 변경이력: 
-- 2017.01.09 SP최초작성
-- 
-- ===============================================
CREATE PROC [dbo].[MenuAuth_Get]
	@USERID				varchar(50),
	@USEVENDORCODE		nvarchar(50),
	@USEPLANTCODE		nvarchar(100)
AS
DECLARE @query nvarchar(max)--,
		--@Restrictions varchar(200)

--SELECT @Restrictions = COALESCE(@Restrictions + ',', '') + A.GROUPCODE 
--FROM dbo.AuthGroupUser AS A WITH(NOLOCK)
--JOIN dbo.AuthGroup AS B WITH(NOLOCK)
--ON A.GROUPCODE = B.GROUPCODE
--WHERE A.USERID = @USERID AND B.RESTRICTIONFLAG = 1

--IF @@ROWCOUNT = 0
--	SET @Restrictions = ''

SET @query = N''
SET @query = @query + N'
SELECT DISTINCT 1 AS FAVORITES, A.MENUID, B.MENUNAME, B.PARENTMENUID, C.DLLNAME, C.CLASSNAME, 
	C.HELPURL, B.IMAGEIDX, B.SELECTIMAGEIDX, B.LVL, B.IDX,
	--MAX(cast(SUBSTRING(A.AUTHORITY, 1, 1) as int)) AS SELECTAUTH, 
	--MAX(cast(SUBSTRING(A.AUTHORITY, 3, 1) as int)) AS NEWAUTH, 
	--MAX(cast(SUBSTRING(A.AUTHORITY, 5, 1) as int)) AS SAVEAUTH, 
	--MAX(cast(SUBSTRING(A.AUTHORITY, 7, 1) as int)) AS DELAUTH, 
	B.ISCOMMON ,
	B.ISMULTIEXECUTE ,
	B.ISBEGINGROUP,
	B.SCREENID
FROM dbo.AuthGroupMenu AS A WITH(NOLOCK) 
JOIN dbo.MenuMaster AS B WITH(NOLOCK)
ON A.MENUID = B.MENUID 
AND B.USEFLAG = 1
LEFT JOIN dbo.ScreenMaster AS C WITH(NOLOCK)
ON B.SCREENID = C.SCREENID
WHERE A.GROUPCODE IN (SELECT GROUPCODE FROM AuthGroupUser WHERE USERID IN ( ''' + @USERID + ''' )  AND [EXPIREDATE] > GETDATE() ) 
AND ( CHARINDEX(''' + @USEVENDORCODE + ''', B.USEVENDORCODE) > 0 OR B.USEVENDORCODE = '''' )
AND ( CHARINDEX(''' + @USEPLANTCODE + ''', B.USEPLANTCODE) > 0 OR B.USEPLANTCODE = '''' )
--GROUP BY A.MENUID, B.MENUNAME, B.PARENTMENUID, C.DLLNAME, C.CLASSNAME,  
--C.HELPURL, B.IMAGEIDX, B.SELECTIMAGEIDX, B.LVL, B.IDX, B.ISCOMMON, B.SCREENID ' + CHAR(10)

IF EXISTS (SELECT 1 FROM dbo.MyMenu A WITH(NOLOCK) WHERE A.USERID = @USERID AND A.GUBUN = 'F')
BEGIN
	SET @query = @query + 'UNION' + CHAR(10)
	SET @query = @query + 'SELECT 0 AS FAVORITES, ''FAVORITES'', ''즐겨찾기 메뉴'', '''', '''', '''', '''', 4, 4, 0, 0, 0, 0, 0, ''''  ' + CHAR(10)
	SET @query = @query + 'UNION ' + CHAR(10)
	SET @query = @query + 'SELECT DISTINCT 0 AS FAVORITES, A.MENUID + ''_FA'', B.MENUNAME, ''FAVORITES'', D.DLLNAME, D.CLASSNAME,   ' + CHAR(10)
	SET @query = @query + 'D.HELPURL, 4, 4, 1, 1, --0, 0, 0, 0, ' + CHAR(10)
	--SET @query = @query + 'MAX(cast(SUBSTRING(E.AUTHORITY, 1, 1) as int)) AS SELECTAUTH, ' + CHAR(10)
	--SET @query = @query + 'MAX(cast(SUBSTRING(E.AUTHORITY, 3, 1) as int)) AS NEWAUTH, ' + CHAR(10)
	--SET @query = @query + 'MAX(cast(SUBSTRING(E.AUTHORITY, 5, 1) as int)) AS SAVEAUTH, ' + CHAR(10)
	--SET @query = @query + 'MAX(cast(SUBSTRING(E.AUTHORITY, 7, 1) as int)) AS DELAUTH, ' + CHAR(10)
	SET @query = @query + 'B.ISCOMMON, B.ISMULTIEXECUTE, B.ISBEGINGROUP, B.SCREENID ' + CHAR(10)
	SET @query = @query + 'FROM dbo.MyMenu AS A WITH(NOLOCK) ' + CHAR(10)
	SET @query = @query + 'JOIN dbo.MenuMaster AS B WITH(NOLOCK) ON A.GUBUN = ''F'' AND A.MENUID = B.MENUID AND B.USEFLAG = 1 ' + CHAR(10)
	SET @query = @query + 'LEFT JOIN dbo.ScreenMaster AS D WITH(NOLOCK) ' + CHAR(10)
	SET @query = @query + 'ON B.SCREENID = D.SCREENID ' + CHAR(10)
	SET @query = @query + 'JOIN dbo.AuthGroupMenu AS C WITH(NOLOCK) ON B.MENUID = C.MENUID ' + CHAR(10)
	SET @query = @query + 'AND C.GROUPCODE IN ( SELECT GROUPCODE FROM dbo.AuthGroupUser WHERE USERID = ''' + @USERID + ''' AND [EXPIREDATE] > GETDATE() ) ' + CHAR(10)
	--SET @query = @query + 'JOIN dbo.AuthGroupMenu AS E WITH(NOLOCK) ' + CHAR(10)
	--SET @query = @query + 'ON E.GROUPCODE = C.GROUPCODE AND E.MENUID = C.MENUID' + CHAR(10)
	SET @query = @query + 'WHERE A.USERID = ''' + @USERID + ''' ' + CHAR(10)
	SET @query = @query + 'AND ( CHARINDEX(''' + @USEVENDORCODE + ''', B.USEVENDORCODE) > 0 OR B.USEVENDORCODE = '''' ) ' + CHAR(10)
	SET @query = @query + 'AND ( CHARINDEX(''' + @USEPLANTCODE + ''', B.USEPLANTCODE) > 0 OR B.USEPLANTCODE = '''' ) ' + CHAR(10)
	--SET @query = @query + 'GROUP BY A.MENUID, B.MENUNAME, D.DLLNAME, D.CLASSNAME, D.HELPURL, B.ISCOMMON, B.SCREENID ' + CHAR(10)
END

SET @query = @query + 'ORDER BY FAVORITES, LVL, IDX '

PRINT @query
EXEC(@query)

--SELECT @Restrictions AS RESTRICTIONS

SELECT ISNULL(STUFF((SELECT ',' + A.GROUPCODE 
						FROM dbo.AuthGroupUser AS A WITH(NOLOCK)
						JOIN dbo.AuthGroup AS B WITH(NOLOCK)
						ON A.GROUPCODE = B.GROUPCODE
						WHERE A.USERID = @USERID AND B.RESTRICTIONFLAG = 1 
					FOR XML PATH ('')
					), 1, 1, ''), '') AS RESTRICTIONS

SELECT ISNULL(STUFF((SELECT ',' + A.MENUID FROM dbo.MyMenu A WITH(NOLOCK)
						JOIN dbo.MenuMaster B WITH(NOLOCK)
						ON A.MENUID = B.MENUID
						WHERE A.USERID = @USERID
						AND A.GUBUN = 'T' 
						AND ( CHARINDEX(@USEPLANTCODE, B.USEPLANTCODE) > 0 OR B.USEPLANTCODE = '' )
						FOR XML PATH ('')
					), 1, 1, ''), '') AS SHORTCUTMENUS

GO
/****** Object:  StoredProcedure [dbo].[MenuMaster_Delete]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* 
==============================================================================================
 작 성 자 : 오인봉
 작 성 일 : 2016-12-30 15:34:25
 설    명 : MenuMaster Table 삭제
 샘플실행 : EXEC dbo.MenuMaster_Delete ''

 변경이력 : 2018-02-20 하위 메뉴 재귀쿼리 사용하여 삭제
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[MenuMaster_Delete]
	@MENUID varchar(40)
AS
BEGIN TRY
	
	BEGIN TRANSACTION
		DELETE FROM dbo.MenuMaster WHERE MENUID = @MENUID	
		OR MENUID IN (SELECT MENUID FROM dbo.fnGetChildMenu(@MENUID) )

		DELETE FROM dbo.AuthGroupMenu
		WHERE MENUID NOT IN (SELECT MENUID FROM dbo.MenuMaster WITH(NOLOCK))
		
		DELETE FROM dbo.MyMenu
		WHERE MENUID NOT IN (SELECT MENUID FROM dbo.MenuMaster WITH(NOLOCK))

	COMMIT TRANSACTION

END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.MenuMaster_Delete : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH



GO
/****** Object:  StoredProcedure [dbo].[MenuMaster_Save]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* 
==============================================================================================
 작 성 자 : 오인봉
 작 성 일 : 2010-12-30 15:34:25
 설    명 : MenuMaster Table 저장 
 샘플실행 : EXEC dbo.MenuMaster_Save

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[MenuMaster_Save]
	@MENUID VARCHAR(40),
	@MENUNAME_LANG NVARCHAR(50),
	@MENUNAME NVARCHAR(50),
	@LVL SMALLINT,
	@IDX SMALLINT,
	@PARENTMENUID VARCHAR(40),
	@SCREENID VARCHAR(20),
	@IMAGEIDX SMALLINT,
	@SELECTIMAGEIDX SMALLINT,
	@ISCOMMON BIT,
	@ISMULTIEXECUTE BIT = 0,
	@ISBEGINGROUP BIT = 0,
	@DESCRIPTION NVARCHAR(300),
	@USEFLAG BIT,
	@USEVENDORCODE VARCHAR(200),
	@USEPLANTCODE VARCHAR(100),
	@CHANGEBY NVARCHAR(30)
AS
BEGIN TRY
	IF @MENUID = '' RETURN

	BEGIN TRANSACTION
	IF NOT EXISTS (SELECT 1 FROM dbo.MenuMaster WITH(NOLOCK) WHERE MENUID = @MENUID) 
	BEGIN 
		INSERT INTO dbo.MenuMaster ( MENUID, MENUNAME, MENUNAME_LANG, LVL, IDX, PARENTMENUID, SCREENID, IMAGEIDX, SELECTIMAGEIDX, ISCOMMON, ISMULTIEXECUTE, ISBEGINGROUP, [DESCRIPTION], USEFLAG, USEVENDORCODE, USEPLANTCODE, INITDTTM, INITBY) 
		VALUES ( @MENUID, @MENUNAME, @MENUNAME_LANG, @LVL, @IDX, @PARENTMENUID, @SCREENID, @IMAGEIDX, @SELECTIMAGEIDX, @ISCOMMON, @ISMULTIEXECUTE, @ISBEGINGROUP, @DESCRIPTION, @USEFLAG, @USEVENDORCODE, @USEPLANTCODE, GETDATE(), @CHANGEBY ) 
	END 
	ELSE 
	BEGIN 
		UPDATE dbo.MenuMaster
			SET MENUNAME = @MENUNAME, 
				MENUNAME_LANG = @MENUNAME_LANG,
				LVL = @LVL, 
				IDX = @IDX, 
				PARENTMENUID = @PARENTMENUID, 
				SCREENID = @SCREENID,
				IMAGEIDX = @IMAGEIDX, 
				SELECTIMAGEIDX = @SELECTIMAGEIDX, 
				ISCOMMON = @ISCOMMON, 
				ISMULTIEXECUTE = @ISMULTIEXECUTE,
				ISBEGINGROUP = @ISBEGINGROUP,
				[DESCRIPTION] = @DESCRIPTION, 				
				USEFLAG = @USEFLAG, 
				USEVENDORCODE = @USEVENDORCODE,
				USEPLANTCODE = @USEPLANTCODE,
				UPDTTM = GETDATE(), 
				UPBY = @CHANGEBY
		WHERE MENUID = @MENUID
	END 
	
	IF NOT EXISTS (SELECT 1 FROM AuthGroupMenu WITH(NOLOCK) WHERE MENUID = @MENUID AND GROUPCODE = 'ADMIN')
	BEGIN
		INSERT INTO dbo.AuthGroupMenu ( GROUPCODE, MENUID, AUTHORITY, INITDTTM, INITBY) 
		SELECT 'ADMIN', MENUID, '1/1/1/1', GETDATE(), @CHANGEBY 
		FROM dbo.MenuMaster WITH(NOLOCK) WHERE MENUID = @MENUID
	END

	IF NOT EXISTS (SELECT 1 FROM AuthGroupMenu WITH(NOLOCK) WHERE MENUID = @MENUID AND GROUPCODE = 'Z00000001')
	BEGIN
		INSERT INTO dbo.AuthGroupMenu ( GROUPCODE, MENUID, AUTHORITY, INITDTTM, INITBY) 
		SELECT 'Z00000001', MENUID, '1/0/0/0', GETDATE(), @CHANGEBY 
		FROM dbo.MenuMaster WITH(NOLOCK) WHERE MENUID = @MENUID
	END

	COMMIT TRANSACTION

	--EXEC DJDEV1.META_EBAP.dbo.MenuMaster_Save @MENUID, @MENUNAME_LANG, @MENUNAME, @LVL, @IDX, @PARENTMENUID, @SCREENID, @IMAGEIDX, @SELECTIMAGEIDX,
	--										@ISCOMMON, @ISMULTIEXECUTE, @ISBEGINGROUP, @DESCRIPTION, @USEFLAG, @USEVENDORCODE, @USEPLANTCODE, @CHANGEBY
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.MenuMaster_Save : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH




GO
/****** Object:  StoredProcedure [dbo].[MenuMaster_Select]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ===============================================
-- 작성자: 오인봉
-- 작성일: 2017.01.09
-- 설   명: System Program 조회
-- 샘플실행: EXEC MenuMaster_Select 'ko-KR', ''
-- 변경이력: 
-- 2017.01.09 SP최초작성
-- 
-- ===============================================
CREATE PROC [dbo].[MenuMaster_Select]
	@LANGUAGE varchar(10),
	@MENUNAME nvarchar(100)
AS
SELECT A.MENUID, 
	   --A.MENUNAME,	
	   --ISNULL(dbo.fnGetLocale(@LANGUAGE, A.MENUNAME_LANG), A.MENUNAME) MENUNAME_LANG, 
	   A.MENUNAME_LANG,
	   CASE WHEN ISNULL(A.MENUNAME_LANG, '') = '' THEN A.MENUNAME ELSE dbo.fnGetLocale(@LANGUAGE, A.MENUNAME_LANG) END MENUNAME,
	   A.LVL, 
	   A.IDX, 
	   A.PARENTMENUID,
	   ISNULL(A.SCREENID, '') SCREENID,
	   ISNULL(B.SCREENNAME, '') SCREENNAME,
	   ISNULL(B.DLLNAME, '') DLLNAME,
	   ISNULL(B.CLASSNAME, '') CLASSNAME, 
	   ISNULL(B.HELPURL, '') HELPURL,
	   A.IMAGEIDX, 
	   A.SELECTIMAGEIDX, 
	   A.USEVENDORCODE,
	   A.USEPLANTCODE,
	   --CASE WHEN A.USEGBM = '' THEN NULL ELSE A.USEGBM END USEGBM,
	   --CASE WHEN A.USEORGANIZATIONID = '' THEN NULL ELSE A.USEORGANIZATIONID END USEORGANIZATIONID,
	   A.[DESCRIPTION], 
	   A.ISCOMMON, 
	   A.ISMULTIEXECUTE,
	   A.ISBEGINGROUP,
	   A.USEFLAG, 
	   ISNULL(A.UPDTTM, A.INITDTTM) CHANGEDTTM,
	   ISNULL(A.UPBY, A.INITBY) CHANGEBY
FROM dbo.MenuMaster AS A WITH(NOLOCK) 
LEFT JOIN dbo.ScreenMaster AS B WITH(NOLOCK)
ON A.SCREENID = B.SCREENID
WHERE 1 = 1
AND MENUID IN (SELECT MENUID FROM dbo.fnGetParentMenu(@MENUNAME))
ORDER BY LVL, IDX




GO
/****** Object:  StoredProcedure [dbo].[MonitoringList_Select]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 
==============================================================================================
 작 성 자: 오인봉
 작 성 일: 2018.07.05
 설    명: 모니터링 대상 조회
 샘플실행: EXEC dbo.MonitoringList_Select '0020'
 
 변경이력: 

==============================================================================================
*/ 
CREATE PROC [dbo].[MonitoringList_Select]
	@REGIONCODE varchar(4)
AS
WITH LIST
AS
(	
	SELECT REGIONCODE, PRODUCTCODE, IFMODULE
	FROM dbo.UserMonitoringinfo WITH(NOLOCK)
	WHERE 1 = 1 
	--AND USERID = 'LEESH'
	AND MONITORINGFG = 'T'
)
SELECT B.DISPLAYVALUE REGIONNAME
	 --, A.PRODUCTCODE
	 , C.DISPLAYVALUE PRODUCTNAME
	 , A.IFMODULE
	 , D.DISPLAYVALUE IFMODULENAME
	 , A.SERVERNAME
	 , A.DBNAME
	 , A.ERRSQL
	 , A.WAITSQL
	 , 0 ERRCOUNT
	 , 0 WAITCOUNT
	 , A.ERRORWARNINGLIMIT
	 , A.WAITWARNINGLIMIT
	 --, A.REGIONCODE
FROM dbo.Monitoringinfo A WITH(NOLOCK)
JOIN dbo.CodeMaster B WITH(NOLOCK)
ON B.PCODEVALUE = 'M$REGION'
AND A.REGIONCODE = B.CODEVALUE
JOIN dbo.CodeMaster C WITH(NOLOCK)
ON C.PCODEVALUE = 'M$PRODUCT'
AND A.PRODUCTCODE = C.CODEVALUE
JOIN dbo.CodeMaster D WITH(NOLOCK)
ON D.PCODEVALUE = 'M$IFMODULES'
AND A.IFMODULE = D.CODEVALUE
JOIN LIST E
ON A.REGIONCODE = E.REGIONCODE
AND A.PRODUCTCODE = E.PRODUCTCODE
AND A.IFMODULE = E.IFMODULE
WHERE 1 = 1 
AND A.REGIONCODE = @REGIONCODE
AND A.IFMODULE NOT IN ( 9110 )
GO
/****** Object:  StoredProcedure [dbo].[MyMenu_Delete]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2018-03-14 13:49:05
 설    명 : MyMenu Table 삭제
 샘플실행 : EXEC dbo.MyMenu_Delete

 변경이력 : 
==============================================================================================
*/ 
CREATE PROC [dbo].[MyMenu_Delete]
	@USERID nvarchar(50),
	@MENUID nvarchar(10),
	@GUBUN varchar(1),
	@IPADDRESS varchar(30) = ''
AS
BEGIN TRY
	BEGIN TRANSACTION

		DELETE FROM dbo.MyMenu
		WHERE USERID = @USERID AND MENUID = @MENUID AND GUBUN = @GUBUN AND IPADDRESS = @IPADDRESS

	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.MyMenu_Delete : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH

GO
/****** Object:  StoredProcedure [dbo].[MyMenu_Get]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* 
==============================================================================================
 작 성 자 : 오인봉
 작 성 일 : 2018-03-14 14:27:01
 설    명 : MyMenuTable 조회 
 샘플실행 : EXEC dbo.MyMenu_Get 'system', 'S'

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[MyMenu_Get]
	@USERID nvarchar(50),
	@GUBUN varchar(1)
AS
SELECT STUFF((SELECT ','+ MENUID FROM dbo.MyMenu WITH(NOLOCK) WHERE USERID = @USERID AND GUBUN = @GUBUN FOR XML PATH ('')), 1, 1, '') AS MENUID
GO
/****** Object:  StoredProcedure [dbo].[MyMenu_Save]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* 
==============================================================================================
 작 성 자 : 오인봉
 작 성 일 : 2018-03-14 13:47:49
 설    명 : MyMenu Table 저장 
 샘플실행 : EXEC dbo.MyMenu_Save '', '', ''

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[MyMenu_Save]
	@USERID nvarchar(50),
	@MENUID nvarchar(10),
	@IPADDRESS varchar(30),
	@GUBUN varchar(1)
AS
BEGIN TRY
	BEGIN TRANSACTION
	IF NOT EXISTS (SELECT 1 FROM dbo.MyMenu WITH(NOLOCK) WHERE USERID = @USERID AND MENUID = @MENUID AND GUBUN = @GUBUN AND IPADDRESS = @IPADDRESS) 
	BEGIN 
		INSERT INTO dbo.MyMenu ( USERID, MENUID, GUBUN, IPADDRESS, INITDTTM, INITBY ) 
		VALUES ( @USERID, @MENUID, @GUBUN, @IPADDRESS, GETDATE(), @USERID ) 
	END 
	ELSE 
	BEGIN 
		UPDATE dbo.MyMenu
		SET UPDTTM = GETDATE()
		  , UPBY = @USERID
		WHERE USERID = @USERID AND MENUID = @MENUID AND GUBUN = @GUBUN
	END 
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.MyMenu_Save : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH

GO
/****** Object:  StoredProcedure [dbo].[MyMenu_Select]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* 
==============================================================================================
 작 성 자 : 오인봉
 작 성 일 : 2018-03-14 14:33:15
 설    명 : MyMenuTable 조회 
 샘플실행 : EXEC dbo.MyMenu_Select 'di0601', 'F'

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[MyMenu_Select]
	@USERID nvarchar(50),
	@GUBUN varchar(1)
AS
SELECT DISTINCT A.USERID
	 , A.MENUID
	 , B.MENUNAME
	 , C.DLLNAME
	 , C.CLASSNAME
	 , A.GUBUN
	 , CASE WHEN @GUBUN = 'F' THEN '' ELSE RTRIM(A.IPADDRESS) END IPADDRESS
	 --, ISNULL(A.UPDTTM, A.INITDTTM) CHANGEDTTM 
	 --, ISNULL(A.UPBY, A.INITBY) CHANGEBY 
FROM dbo.MyMenu A WITH(NOLOCK) 
JOIN dbo.MenuMaster B WITH(NOLOCK)
ON A.MENUID = B.MENUID
JOIN dbo.ScreenMaster C WITH(NOLOCK)
ON B.SCREENID = C.SCREENID
WHERE A.USERID = @USERID AND A.GUBUN = @GUBUN 

GO
/****** Object:  StoredProcedure [dbo].[Notify_Delete]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2017-11-25 08:50:07
 설    명 : Notify Table 삭제
 샘플실행 : EXEC dbo.Notify_Delete 0

 변경이력 : 
==============================================================================================
*/ 
CREATE PROC [dbo].[Notify_Delete]
	@SEQ int
AS
BEGIN TRY
	BEGIN TRANSACTION

		DELETE FROM dbo.Notify
		WHERE SEQ = @SEQ

	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.Notify_Delete : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH



GO
/****** Object:  StoredProcedure [dbo].[Notify_Save]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2017-11-25 08:48:37
 설    명 : 공지사항 저장 
 샘플실행 : EXEC dbo.Notify_Save

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[Notify_Save]
	@SEQ int,
	@TYPE varchar(2),
	@SUBJECT nvarchar(100),
	@CONTENTS nvarchar(2000),
	@PRIORITY varchar(2),
	@EXPIREDATE date,
	@CHANGEBY nvarchar(50)
AS
BEGIN TRY
	BEGIN TRANSACTION
	IF NOT EXISTS (SELECT 1 FROM dbo.Notify WITH(NOLOCK) WHERE SEQ = @SEQ) 
	BEGIN 
		INSERT INTO dbo.Notify ( [TYPE], [SUBJECT], CONTENTS, [PRIORITY], [EXPIREDATE], INITDTTM, INITBY ) 
		VALUES ( @TYPE, @SUBJECT, @CONTENTS, @PRIORITY, @EXPIREDATE, GETDATE(), @CHANGEBY ) 
	END 
	ELSE 
	BEGIN 
		UPDATE dbo.Notify
		SET [TYPE] = @TYPE
		  , [SUBJECT] = @SUBJECT
		  , CONTENTS = @CONTENTS
		  , [PRIORITY] = @PRIORITY
		  , [EXPIREDATE] = @EXPIREDATE
		  , UPDTTM = GETDATE()
		  , UPBY = @CHANGEBY
		WHERE SEQ = @SEQ
	END 
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.Notify_Save : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH

GO
/****** Object:  StoredProcedure [dbo].[Notify_Select]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2017-11-25 08:41:44
 설    명 : 공지사항 조회 
 샘플실행 : EXEC dbo.Notify_Select  '', '', 1, 'system', 'a'

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[Notify_Select]
	@TYPE varchar(2),
	@SUBJECT nvarchar(100),
	@ISADMIN bit,
	@USERID VARCHAR(30) = '',
	@EPID VARCHAR(50) = ''
AS
DECLARE @query NVARCHAR(MAX)

IF @EPID <> ''
BEGIN
	SET @USERID = ''

	SELECT @USERID = USERID FROM dbo.UserToken WHERE TOKENID = @EPID
END

IF @USERID = ''
	SET @ISADMIN = 0
ELSE
BEGIN
	SELECT @ISADMIN = ISNULL(ADMINFLAG, 0)  FROM dbo.UserInfo WITH(NOLOCK) WHERE USERID = @USERID
END


SET @query = N''
SET @query = @query + N'
SELECT A.SEQ
	 , A.TYPE
	 , A.SUBJECT
	 , A.CONTENTS
	 , A.PRIORITY
	 , A.EXPIREDATE
	 , ISNULL(A.UPDTTM, A.INITDTTM) CHANGEDTTM 
	 , dbo.fnGetUserName(ISNULL(A.UPBY, A.INITBY)) CHANGEBY 
FROM dbo.Notify A WITH(NOLOCK) 
WHERE 1 = 1 '

IF @TYPE <> N''
	SET @query = @query + N'
AND A.TYPE = ''' + @TYPE + ''' '

IF @SUBJECT <> N''
	SET @query = @query + N'
AND A.SUBJECT LIKE ''%' + @SUBJECT + '%'' '

IF @ISADMIN <> 1
	SET @query = @query + N'
AND EXPIREDATE > GETDATE() '

IF @USERID <> N''
	SET @query = @query + N'
AND A.SEQ NOT IN (SELECT NOTIFYSEQ FROM dbo.NotifyConfirm WITH(NOLOCK) WHERE USERID = ''' + @USERID + ''' ) '

SET @query = @query + N'
ORDER BY A.[EXPIREDATE] DESC, A.SEQ DESC '

--PRINT, 실행
PRINT @query
EXECUTE sp_executesql @query


GO
/****** Object:  StoredProcedure [dbo].[NotifyConfirm_Save]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2020-11-23 17:34:02
 설    명 : NotifyConfirm Table 저장 
 샘플실행 : EXEC dbo.NotifyConfirm_Save

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[NotifyConfirm_Save]
	@NOTIFYSEQ bigint,
	@USERID varchar(30),
	@CONFIRMVALUE varchar(300)
AS
BEGIN TRY
	BEGIN TRANSACTION

	IF NOT EXISTS (SELECT 1 FROM dbo.NotifyConfirm WITH(NOLOCK) WHERE NOTIFYSEQ = @NOTIFYSEQ AND USERID = @USERID) 
	BEGIN 
		INSERT INTO dbo.NotifyConfirm ( NOTIFYSEQ, USERID, CONFIRMVALUE, CHANGEDTTM) 
		VALUES ( @NOTIFYSEQ, @USERID, @CONFIRMVALUE, GETDATE() ) 
	END 

	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.NotifyConfirm_Save : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH

GO
/****** Object:  StoredProcedure [dbo].[PlantAuth_Delete]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2018-03-21 13:15:16
 설    명 : PlantAuth Table 삭제
 샘플실행 : EXEC dbo.PlantAuth_Delete '', ''

 변경이력 : 
==============================================================================================
*/ 
CREATE PROC [dbo].[PlantAuth_Delete]
	@PLANTCODE varchar(4),
	@USERID nvarchar(50)
AS
BEGIN TRY
	BEGIN TRANSACTION

		DELETE FROM dbo.PlantAuth
		WHERE PLANTCODE = @PLANTCODE AND USERID = @USERID

	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.PlantAuth_Delete : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH

GO
/****** Object:  StoredProcedure [dbo].[PlantAuth_Get]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ===============================================
-- 작성자: 오인봉
-- 작성일: 2016.01.18
-- 설   명: Code Master 조회
-- 샘플실행: EXEC PlantAuth_Get 'system'
-- 변경이력: 
-- 2016.01.18 SP최초작성
-- 
-- ===============================================
CREATE PROC [dbo].[PlantAuth_Get]
	@USERID nvarchar(50)
AS
SELECT A.CODEVALUE
	 , A.DISPLAYVALUE
FROM dbo.CodeMaster A WITH(NOLOCK) 
WHERE 1 = 1
AND A.USEFLAG = 1
AND A.PCODEVALUE = 'C$PLANTCODE'
AND A.CODEVALUE IN ( SELECT PLANTCODE FROM dbo.PlantAuth WITH(NOLOCK) WHERE USERID = @USERID  )

GO
/****** Object:  StoredProcedure [dbo].[PlantAuth_Save]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2018-03-21 13:10:01
 설    명 : PlantAuth Table 저장 
 샘플실행 : EXEC dbo.PlantAuth_Save

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[PlantAuth_Save]
	@PLANTCODE varchar(4),
	@USERID nvarchar(50),
	@EXPIREDATE datetime,
	@ISDELEGATE bit,
	@CHANGEBY nvarchar(50)
AS
BEGIN TRY
	BEGIN TRANSACTION

	--IF @ISDELEGATE = 0
	--BEGIN
	--	DELETE FROM dbo.AuthGroupUser 
	--	WHERE GROUPCODE = 'AUTH002' AND USERID = @USERID
	--END
	--SET @EXPIREDATE = '2050-12-31'

	IF @ISDELEGATE = 1
	BEGIN
		IF NOT EXISTS (SELECT 1 FROM dbo.AuthGroupUser WITH(NOLOCK) WHERE GROUPCODE = 'AUTH001' AND USERID = @USERID) 
		BEGIN 
			INSERT INTO dbo.AuthGroupUser ( GROUPCODE, USERID, EXPIREDATE, ISDELEGATE, INITDTTM, INITBY ) 
			VALUES ( 'AUTH001', @USERID, @EXPIREDATE, CASE WHEN @USERID = 'system' THEN 1 ELSE 0 END, GETDATE(), @CHANGEBY ) 
		END 
	END

	IF NOT EXISTS (SELECT 1 FROM dbo.PlantAuth WITH(NOLOCK) WHERE PLANTCODE = @PLANTCODE AND USERID = @USERID) 
	BEGIN 
		INSERT INTO dbo.PlantAuth ( PLANTCODE, USERID, [EXPIREDATE], ISDELEGATE, INITDTTM, INITBY ) 
		VALUES ( @PLANTCODE, @USERID, @EXPIREDATE, @ISDELEGATE, GETDATE(), @CHANGEBY ) 
	END 
	ELSE 
	BEGIN 
		UPDATE dbo.PlantAuth
		SET [EXPIREDATE] = @EXPIREDATE
		  , ISDELEGATE = @ISDELEGATE
		  , UPDTTM = GETDATE()
		  , UPBY = @CHANGEBY
		WHERE PLANTCODE = @PLANTCODE AND USERID = @USERID
	END 
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.PlantAuth_Save : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH

GO
/****** Object:  StoredProcedure [dbo].[PlantAuth_Select]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* 
==============================================================================================
 작 성 자 : 오인봉
 작 성 일 : 2018-03-21 09:38:14
 설    명 : PlantAuth Table 조회 
 샘플실행 : EXEC dbo.PlantAuth_Select '1031', ''

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[PlantAuth_Select]
	@PLANTCODE varchar(4),
	@USERNAME varchar(50) = ''
AS
SELECT A.PLANTCODE
	 , A.USERID
	 , B.USERNAME
	 , B.DEPTNAME
	 , A.EXPIREDATE
	 , A.ISDELEGATE
	 , ISNULL(A.UPDTTM, A.INITDTTM) CHANGEDTTM 
	 , ISNULL(A.UPBY, A.INITBY) CHANGEBY 
FROM dbo.PlantAuth A WITH(NOLOCK) 
JOIN dbo.UserInfo B WITH(NOLOCK)
ON A.USERID = B.USERID
WHERE A.PLANTCODE = @PLANTCODE
AND B.USERNAME LIKE @USERNAME + '%'


GO
/****** Object:  StoredProcedure [dbo].[PlantList_Select]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* 
==============================================================================================
 작 성 자 : 오인봉
 작 성 일 : 2018-02-08 17:45:58
 설    명 : CodeMasterTable 조회 
 샘플실행 : EXEC dbo.PlantList_Select '', '', 'system'

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[PlantList_Select]
	@CODEVALUE nvarchar(20),
	@DISPLAYVALUE nvarchar(50),
	@USERID varchar(50) = ''
AS
SELECT A.CODEVALUE
	 , A.DISPLAYVALUE
	 , ISNULL(A.UPDTTM, A.INITDTTM) CHANGEDTTM 
	 , ISNULL(A.UPBY, A.INITBY) CHANGEBY 
FROM dbo.CodeMaster A WITH(NOLOCK) 
WHERE 1 = 1
AND A.USEFLAG = 1
AND A.PCODEVALUE = 'C$PLANTCODE'
AND A.CODEVALUE LIKE @CODEVALUE + '%'
AND A.DISPLAYVALUE LIKE  '%' + @DISPLAYVALUE + '%'
--AND A.CODEVALUE IN ( SELECT VENDORCODE FROM dbo.VendorAuth WITH(NOLOCK) WHERE USERID = @USERID AND ISDELEGATE = 1 )

GO
/****** Object:  StoredProcedure [dbo].[PopLanguageMaster_Select]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* 
==============================================================================================
 작 성 자 : 오인봉
 작 성 일 : 2010-11-24 16:09:35
 설    명 : 다국어 사전 조회 
 샘플실행 : EXEC dbo.PopLanguageMaster_Select '', ''

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[PopLanguageMaster_Select]
	@ID varchar(200),
	@CAPTION nvarchar(1000)
AS
SELECT  STRINGID, 
		KOKR, 
		ENUS, 
		ZHCHS, 
		ENUMCLASS
FROM dbo.LocaleMaster WITH(NOLOCK) 
WHERE (KOKR LIKE '%' +  @CAPTION + '%' OR ENUS LIKE '%' +  @CAPTION + '%')
AND ENUMCLASS LIKE @ID + '%'




GO
/****** Object:  StoredProcedure [dbo].[QueryMaster_Copy]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2018-02-20 14:36:21
 설    명 : 쿼리 마스터 복사
 샘플실행 : EXEC dbo.QueryMaster_Copy @SQLGROUP		= 'ADM.Common'
								    , @UINAME		= 'Notify'
								    , @SUBJECT		= '공지사항'
								    , @CHGSQLGROUP	= 'ADM.Common'
								    , @CHGUINAME	= 'Notify222'
								    , @CHGSUBJECT	= '공지사항222'
									, @DBID			= 'RACB'

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[QueryMaster_Copy]
	@SQLGROUP nvarchar(30),
	@UINAME nvarchar(40),
	@SUBJECT nvarchar(200),
	@CHGSQLGROUP nvarchar(30),
	@CHGUINAME nvarchar(40),
	@CHGSUBJECT nvarchar(200),
	@DBID varchar(20)
AS
BEGIN TRY
	BEGIN TRANSACTION
	
	INSERT dbo.QueryMaster ( SQLGROUP, QUERYID, SUBJECT, QUERYTYPE, QUERYTEXT, DBID, IDX, INITDTTM, INITBY ) 
	SELECT REPLACE(SQLGROUP, @SQLGROUP, @CHGSQLGROUP)
		 , REPLACE(REPLACE(QUERYID, @SQLGROUP, @CHGSQLGROUP), @UINAME, @CHGUINAME)
		 , REPLACE(SUBJECT, @SUBJECT, @CHGSUBJECT)
		 , QUERYTYPE
		 , REPLACE(QUERYTEXT, @UINAME, @CHGUINAME)
		 , @DBID
		 , IDX
		 , GETDATE()
		 , INITBY
	FROM QueryMaster WITH(NOLOCK)
	WHERE QUERYID LIKE @SQLGROUP + '.' + @UINAME + '%'

	--SELECT * FROM QueryMaster WITH(NOLOCK)
	--WHERE QUERYID LIKE @SQLGROUP + '.' + @UINAME + '%'

	--SELECT * FROM QueryMaster WITH(NOLOCK)
	--WHERE QUERYID LIKE @CHGSQLGROUP + '.' + @CHGUINAME + '%'

	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.QueryMaster_Copy : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH


GO
/****** Object:  StoredProcedure [dbo].[QueryMaster_CopyData_Select]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2016-04-29 10:59:44
 설    명 : QueryMasterTable 조회 
 샘플실행 : EXEC dbo.QueryMaster_CopyData_Select   @SQLGROUP		= 'ADM.Management'
												 , @UINAME			= 'CodeMaster'
												 , @SUBJECT			= '코드 마스터'
												 , @CHGSQLGROUP		= 'RACBS.Management'
												 , @CHGUINAME		= 'CodeMaster2222'
												 , @CHGSUBJECT		= 'ABC 마스터222'
												 , @DBID			= 'RACB'

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[QueryMaster_CopyData_Select]
	@SQLGROUP nvarchar(30),
	@UINAME nvarchar(40),
	@SUBJECT nvarchar(200),
	@CHGSQLGROUP nvarchar(30),
	@CHGUINAME nvarchar(40),
	@CHGSUBJECT nvarchar(200),
	@DBID varchar(20)
AS
SELECT REPLACE(REPLACE(A.QUERYID, @SQLGROUP, @CHGSQLGROUP), @UINAME, @CHGUINAME) QUERYID
	, REPLACE(A.SUBJECT, @SUBJECT, @CHGSUBJECT)  DESCRIPTION
	, A.QUERYTYPE
	, REPLACE(A.QUERYTEXT, @UINAME, @CHGUINAME) QUERYTEXT
	, A.IDX
	, CASE WHEN B.IDX IS NULL THEN 0 ELSE 1 END CHECKDUP
	, GETDATE() CHANGEDTTM
	, A.INITBY CHANGEBY
	, @SQLGROUP SQLGROUP
	, @UINAME UINAME
	, @SUBJECT SUBJECT
	, @CHGSQLGROUP CHGSQLGROUP
	, @CHGUINAME CHGUINAME
	, @CHGSUBJECT CHGSUBJECT
	, @DBID DBID
FROM dbo.QueryMaster A WITH(NOLOCK)
LEFT JOIN dbo.QueryMaster B WITH(NOLOCK)
ON B.QUERYID = REPLACE(REPLACE(A.QUERYID, @SQLGROUP, @CHGSQLGROUP), @UINAME, @CHGUINAME)
WHERE 1 = 1 
AND A.QUERYID LIKE @SQLGROUP + '.' + @UINAME + '%'



GO
/****** Object:  StoredProcedure [dbo].[QueryMaster_CopySource_Select]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2016-04-29 10:59:44
 설    명 : QueryMasterTable 조회 
 샘플실행 : EXEC dbo.QueryMaster_CopySource_Select @SQLGROUP = 'ADM.Management'
												 , @UINAME = 'QueryMaster'

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[QueryMaster_CopySource_Select]
	@SQLGROUP nvarchar(30),
	@UINAME nvarchar(40)
AS

SELECT  SQLGROUP, 
QUERYID, 
SUBJECT, 
QUERYTYPE, 
QUERYTEXT,
[DBID],
IDX, 
ISNULL(UPDTTM, INITDTTM) CHANGEDTTM, 
ISNULL(UPBY, INITBY) CHANGEBY 
FROM dbo.QueryMaster WITH(NOLOCK) 
WHERE 1 = 1 
AND QUERYID LIKE @SQLGROUP + '.' + @UINAME + '%'
GO
/****** Object:  StoredProcedure [dbo].[QueryMaster_Delete]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2017-05-17 09:35:51
 설    명 : QueryMaster Table 삭제
 샘플실행 : EXEC dbo.QueryMaster_Delete '', 0

 변경이력 : 
==============================================================================================
*/ 
CREATE PROC [dbo].[QueryMaster_Delete]
	@QUERYID varchar(80),
	@IDX smallint
AS
BEGIN TRY
	BEGIN TRANSACTION
		DELETE FROM dbo.QueryMaster
		WHERE QUERYID = @QUERYID AND IDX = @IDX
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.QueryMaster_Delete : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH



GO
/****** Object:  StoredProcedure [dbo].[QueryMaster_Get]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2016-05-04 15:39:27
 설    명 : QueryMasterTable 조회 
 샘플실행 : EXEC dbo.QueryMaster_Get ''

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[QueryMaster_Get]
	@QUERYID varchar(80)
AS
SELECT  SQLGROUP, 
QUERYID, 
SUBJECT, 
QUERYTYPE, 
QUERYTEXT, 
DBID, 
IDX, 
ISNULL(UPDTTM, INITDTTM) CHANGEDTTM, 
ISNULL(UPBY, INITBY) CHANGEBY 
FROM dbo.QueryMaster WITH(NOLOCK) 
WHERE QUERYID = @QUERYID




GO
/****** Object:  StoredProcedure [dbo].[QueryMaster_Save]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2016-04-29 16:00:12
 설    명 : QueryMaster Table 저장 
 샘플실행 : EXEC dbo.QueryMaster_Save

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[QueryMaster_Save]
	@SQLGROUP varchar(30),
	@QUERYID varchar(80),
	@SUBJECT nvarchar(100),
	@QUERYTYPE varchar(20),
	@QUERYTEXT nvarchar(max),
	@DBID varchar(20),
	@IDX smallint,
	@CHANGEBY nvarchar(50)
AS
BEGIN TRY
	BEGIN TRANSACTION
	IF NOT EXISTS (SELECT 1 FROM dbo.QueryMaster WITH(NOLOCK) WHERE QUERYID = @QUERYID AND IDX = @IDX) 
	BEGIN 
		INSERT INTO dbo.QueryMaster ( SQLGROUP, QUERYID, SUBJECT, QUERYTYPE, QUERYTEXT, DBID, IDX, INITDTTM, INITBY ) 
		VALUES ( @SQLGROUP, @QUERYID, @SUBJECT, @QUERYTYPE, @QUERYTEXT, @DBID, @IDX, GETDATE(), @CHANGEBY ) 
	END 
	ELSE 
	BEGIN 
		UPDATE dbo.QueryMaster
		SET SQLGROUP = @SQLGROUP
		  , [SUBJECT] = @SUBJECT
		  , QUERYTYPE = @QUERYTYPE
		  , QUERYTEXT = @QUERYTEXT
		  , [DBID] = @DBID
		  , UPDTTM = GETDATE()
		  , UPBY = @CHANGEBY
		WHERE QUERYID = @QUERYID AND IDX = @IDX
	END 
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.QueryMaster_Save : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH




GO
/****** Object:  StoredProcedure [dbo].[QueryMaster_Select]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2016-04-29 10:59:44
 설    명 : QueryMasterTable 조회 
 샘플실행 : EXEC dbo.QueryMaster_Select '', '', ''

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[QueryMaster_Select]
	@SQLGROUP varchar(30),
	@QUERYID varchar(80),
	@SUBJECT nvarchar(100)
AS
DECLARE @query NVARCHAR(MAX)

SET @query = N''
SET @query = @query + N'
	SELECT  SQLGROUP, 
	QUERYID, 
	SUBJECT, 
	QUERYTYPE, 
	QUERYTEXT,
	[DBID],
	IDX, 
	ISNULL(UPDTTM, INITDTTM) CHANGEDTTM, 
	ISNULL(UPBY, INITBY) CHANGEBY 
	FROM dbo.QueryMaster WITH(NOLOCK) 
	WHERE 1 = 1 '

IF @QUERYID <> N''
	SET @query = @query + N'
		AND QUERYID LIKE ''%' + @QUERYID + '%'' '

IF @SQLGROUP <> N''
	SET @query = @query + N'
		AND SQLGROUP LIKE ''%' + @SQLGROUP + '%'' '

IF @SUBJECT <> N''
	SET @query = @query + N'
		AND SUBJECT LIKE ''%' + @SUBJECT + '%'' '

--PRINT, 실행
PRINT @query
EXECUTE sp_executesql @query




GO
/****** Object:  StoredProcedure [dbo].[ScreenColumnSet_Delete]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2017-05-20 11:18:18
 설    명 : ScreenColumnSet Table 삭제
 샘플실행 : EXEC dbo.ScreenColumnSet_Delete '', '', ''

 변경이력 : 
==============================================================================================
*/ 
CREATE PROC [dbo].[ScreenColumnSet_Delete]
	@SCREENID nvarchar(20),
	@GRIDNAME varchar(50),
	@FIELDNAME varchar(50)
AS
BEGIN TRY
	BEGIN TRANSACTION
		DELETE FROM dbo.ScreenColumnSet
		WHERE SCREENID = @SCREENID AND GRIDNAME = @GRIDNAME AND FIELDNAME = @FIELDNAME
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.ScreenColumnSet_Delete : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH



GO
/****** Object:  StoredProcedure [dbo].[ScreenColumnSet_Save]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2017-05-20 11:14:45
 설    명 : ScreenColumnSet Table 저장 
 샘플실행 : EXEC dbo.ScreenColumnSet_Save

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[ScreenColumnSet_Save]
	@SCREENID nvarchar(20),
	@GRIDNAME varchar(50),
	@IDX int,
	@FIELDNAME varchar(50),
	@CAPTION nvarchar(100),
	@WIDTH int,
	@MAXLENGTH int,
	@DECIMALPLACE int,
	@ALLOWEDIT bit,
	@VISIBLE bit,
	@DATATYPE varchar(30),
	@HORIZONALIGN varchar(30),
	@CHANGEBY nvarchar(50)
AS
BEGIN TRY
	BEGIN TRANSACTION
	IF NOT EXISTS (SELECT 1 FROM dbo.ScreenColumnSet WITH(NOLOCK) WHERE SCREENID = @SCREENID AND GRIDNAME = @GRIDNAME AND FIELDNAME = @FIELDNAME) 
	BEGIN 
		INSERT INTO dbo.ScreenColumnSet ( SCREENID, GRIDNAME, IDX, FIELDNAME, CAPTION, WIDTH, MAXLENGTH, DECIMALPLACE, ALLOWEDIT, VISIBLE, DATATYPE, HORIZONALIGN, INITDTTM, INITBY ) 
		VALUES ( @SCREENID, @GRIDNAME, @IDX, @FIELDNAME, @CAPTION, @WIDTH, @MAXLENGTH, @DECIMALPLACE, @ALLOWEDIT, @VISIBLE, @DATATYPE, @HORIZONALIGN, GETDATE(), @CHANGEBY ) 
	END 
	ELSE 
	BEGIN 
		UPDATE dbo.ScreenColumnSet
		SET IDX = @IDX
		  , CAPTION = @CAPTION
		  , WIDTH = @WIDTH
		  , MAXLENGTH = @MAXLENGTH
		  , DECIMALPLACE = @DECIMALPLACE
		  , ALLOWEDIT = @ALLOWEDIT
		  , VISIBLE = @VISIBLE
		  , DATATYPE = @DATATYPE
		  , HORIZONALIGN = @HORIZONALIGN
		  , UPDTTM = GETDATE()
		  , UPBY = @CHANGEBY
		WHERE SCREENID = @SCREENID AND GRIDNAME = @GRIDNAME AND FIELDNAME = @FIELDNAME
	END 
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.ScreenColumnSet_Save : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH



GO
/****** Object:  StoredProcedure [dbo].[ScreenColumnSet_Select]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ===============================================
-- 작성자: 오인봉
-- 작성일: 2017.05.20
-- 설   명: 메뉴별 컬럼 셋팅 메뉴 조회
-- 샘플실행: EXEC ScreenColumnSet_Select ''
-- 변경이력: 
-- 2017.05.20 SP최초작성
-- 
-- ===============================================
CREATE PROC [dbo].[ScreenColumnSet_Select]
	@SCREENID nvarchar(20)
AS
DECLARE @query NVARCHAR(MAX)

SET @query = N''
SET @query = @query + N'
SELECT A.SCREENID
     , B.SCREENNAME
	 , A.GRIDNAME
	 , A.IDX
	 , A.FIELDNAME
	 , A.CAPTION
	 , A.WIDTH
	 , A.MAXLENGTH
	 , A.DECIMALPLACE
	 , A.ALLOWEDIT
	 , A.VISIBLE
	 , A.DATATYPE
	 , A.HORIZONALIGN
	 , ISNULL(A.UPDTTM, A.INITDTTM) CHANGEDTTM
	 , ISNULL(A.UPBY, A.INITBY) CHANGEBY
FROM dbo.ScreenColumnSet A WITH(NOLOCK)
JOIN dbo.ScreenMaster B WITH(NOLOCK)
ON A.SCREENID = B.SCREENID
WHERE 1 = 1 '

IF @SCREENID <> N''
	SET @query = @query + N'
		AND A.SCREENID = ''' + @SCREENID + ''' '

SET @query = @query + N'
		ORDER BY A.SCREENID, A.IDX '

--PRINT, 실행
PRINT @query
EXECUTE sp_executesql @query


GO
/****** Object:  StoredProcedure [dbo].[ScreenColumnSetDetail_Save]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2017-05-22 10:35:59
 설    명 : MenuColumnSetDetail Table 저장 
 샘플실행 : EXEC dbo.ScreenColumnSetDetail_Save

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[ScreenColumnSetDetail_Save]
	@SCREENID nvarchar(20),
	@GRIDNAME varchar(50),
	@USESELECTCOLUMN bit,
	@KEYCOLUMNS varchar(150),
	@MANDATORYCOLUMNS varchar(150),
	@NEWROWENABLECOLUMNS varchar(150),
	@NEWROWCOPYCOLUMNS varchar(150),
	@CHANGEBY nvarchar(50)
AS
BEGIN TRY
	BEGIN TRANSACTION
	IF NOT EXISTS (SELECT 1 FROM dbo.ScreenColumnSetDetail WITH(NOLOCK) WHERE SCREENID = @SCREENID AND GRIDNAME = @GRIDNAME) 
	BEGIN 
		INSERT INTO dbo.ScreenColumnSetDetail ( SCREENID, GRIDNAME, USESELECTCOLUMN, KEYCOLUMNS, MANDATORYCOLUMNS, NEWROWENABLECOLUMNS, NEWROWCOPYCOLUMNS, INITDTTM, INITBY ) 
		VALUES ( @SCREENID, @GRIDNAME, @USESELECTCOLUMN, @KEYCOLUMNS, @MANDATORYCOLUMNS, @NEWROWENABLECOLUMNS, @NEWROWCOPYCOLUMNS, GETDATE(), @CHANGEBY ) 
	END 
	ELSE 
	BEGIN 
		UPDATE dbo.ScreenColumnSetDetail
		SET USESELECTCOLUMN = @USESELECTCOLUMN
		  , KEYCOLUMNS = @KEYCOLUMNS
		  , MANDATORYCOLUMNS = @MANDATORYCOLUMNS
		  , NEWROWENABLECOLUMNS = @NEWROWENABLECOLUMNS
		  , NEWROWCOPYCOLUMNS = @NEWROWCOPYCOLUMNS
		  , UPDTTM = GETDATE()
		  , UPBY = @CHANGEBY
		WHERE SCREENID = @SCREENID AND GRIDNAME = @GRIDNAME
	END 
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.ScreenColumnSetDetail_Save : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH



GO
/****** Object:  StoredProcedure [dbo].[ScreenColumnSetDetail_Select]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ===============================================
-- 작성자: 오인봉
-- 작성일: 2017.05.20
-- 설   명: 메뉴별 컬럼 셋팅 메뉴 조회
-- 샘플실행: EXEC ScreenColumnSetDetail_Select '', ''
-- 변경이력: 
-- 2017.05.20 SP최초작성
-- 
-- ===============================================
CREATE PROC [dbo].[ScreenColumnSetDetail_Select]
	@SCREENID nvarchar(20),
	@GRIDNAME varchar(50)
AS
DECLARE @query NVARCHAR(MAX)

SET @query = N''
SET @query = @query + N'
SELECT A.SCREENID
     , A.GRIDNAME
	 , A.USESELECTCOLUMN
	 , A.KEYCOLUMNS
	 , A.MANDATORYCOLUMNS
	 , A.NEWROWENABLECOLUMNS
	 , A.NEWROWCOPYCOLUMNS
	 , ISNULL(A.UPDTTM, A.INITDTTM) CHANGEDTTM
	 , ISNULL(A.UPBY, A.INITBY) CHANGEBY
FROM dbo.ScreenColumnSetDetail A WITH(NOLOCK)
WHERE 1 = 1 '

IF @SCREENID <> N''
	SET @query = @query + N'
		AND A.SCREENID = ''' + @SCREENID + ''' '

IF @GRIDNAME <> N''
	SET @query = @query + N'
		AND A.GRIDNAME = ''' + @GRIDNAME + ''' '

SET @query = @query + N'
		ORDER BY A.SCREENID '

--PRINT, 실행
PRINT @query
EXECUTE sp_executesql @query


GO
/****** Object:  StoredProcedure [dbo].[ScreenColumnSetInfo_Get]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ===============================================
-- 작성자: 오인봉
-- 작성일: 2017.05.20
-- 설   명: 메뉴별 컬럼 셋팅 정보 가져오기
-- 샘플실행: EXEC ScreenColumnSetInfo_Get 'SCRN00002', 'viewMaster'
-- 변경이력: 
-- 2017.05.20 SP최초작성
-- 
-- ===============================================
CREATE PROC [dbo].[ScreenColumnSetInfo_Get]
	@SCREENID nvarchar(20),
	@GRIDNAME varchar(50)
AS
SELECT DISTINCT A.SCREENID
     , B.MENUNAME
	 , A.GRIDNAME
	 , A.IDX
	 , A.FIELDNAME
	 , A.CAPTION
	 , A.WIDTH
	 , A.MAXLENGTH
	 , A.DECIMALPLACE
	 , A.ALLOWEDIT
	 , A.VISIBLE
	 , A.DATATYPE
	 , A.HORIZONALIGN
	 , ISNULL(A.UPDTTM, A.INITDTTM) CHANGEDTTM
	 , ISNULL(A.UPBY, A.INITBY) CHANGEBY
FROM dbo.ScreenColumnSet A WITH(NOLOCK)
JOIN dbo.MenuMaster B WITH(NOLOCK)
ON A.SCREENID = B.SCREENID
WHERE 1 = 1 
AND A.SCREENID = @SCREENID
AND A.GRIDNAME = @GRIDNAME
ORDER BY A.SCREENID, A.IDX


SELECT SCREENID, GRIDNAME, USESELECTCOLUMN, KEYCOLUMNS, MANDATORYCOLUMNS, NEWROWENABLECOLUMNS, NEWROWCOPYCOLUMNS 
FROM dbo.ScreenColumnSetDetail
WHERE 1 = 1
AND SCREENID = @SCREENID
AND GRIDNAME = @GRIDNAME

GO
/****** Object:  StoredProcedure [dbo].[ScreenColumnSetMenu_Select]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ===============================================
-- 작성자: 오인봉
-- 작성일: 2017.05.20
-- 설   명: 메뉴별 컬럼 셋팅 메뉴 조회
-- 샘플실행: EXEC ScreenColumnSetMenu_Select '', ''
-- 변경이력: 
-- 2017.05.20 SP최초작성
-- 
-- ===============================================
CREATE PROC [dbo].[ScreenColumnSetMenu_Select]
	@SCREENID nvarchar(20),
	@SCREENNAME nvarchar(30)
AS
DECLARE @query NVARCHAR(MAX)

SET @query = N''
SET @query = @query + N'
SELECT DISTINCT A.MENUID
	 , A.MENUNAME
	 , A.LVL
	 , A.IDX
	 , A.PARENTMENUID
	 , B.SCREENID
	 , B.SCREENNAME
	 , B.CLASSNAME
	 , cast(CASE WHEN C.SCREENID IS NULL THEN 0 ELSE 1 END as bit) USESET
FROM   dbo.MenuMaster A WITH(NOLOCK)
LEFT JOIN dbo.ScreenMaster B WITH(NOLOCK)
ON A.SCREENID = B.SCREENID
LEFT JOIN dbo.ScreenColumnSet C WITH(NOLOCK)
ON A.SCREENID = C.SCREENID
WHERE 1 = 1 '

IF @SCREENID <> N''
	SET @query = @query + N'
		AND B.SCREENID LIKE ''' + @SCREENID + '%'' '

IF @SCREENNAME <> N''
	SET @query = @query + N'
		AND B.SCREENNAME LIKE ''' + @SCREENNAME + '%'' '

SET @query = @query + N'
		ORDER BY A.LVL, A.IDX '


--PRINT, 실행
PRINT @query
EXECUTE sp_executesql @query




GO
/****** Object:  StoredProcedure [dbo].[ScreenMaster_Delete]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2017-07-05 16:04:18
 설    명 : ScreenMaster Table 삭제
 샘플실행 : EXEC dbo.ScreenMaster_Delete ''

 변경이력 : 
==============================================================================================
*/ 
CREATE PROC [dbo].[ScreenMaster_Delete]
	@SCREENID varchar(20)
AS
BEGIN TRY
	BEGIN TRANSACTION

		DELETE FROM dbo.ScreenMaster
		WHERE SCREENID = @SCREENID

		DELETE FROM dbo.ScreenColumnSet
		WHERE SCREENID = @SCREENID

		DELETE FROM dbo.ScreenColumnSetDetail
		WHERE SCREENID = @SCREENID

	COMMIT TRANSACTION

END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.ScreenMaster_Delete : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH



GO
/****** Object:  StoredProcedure [dbo].[ScreenMaster_Save]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2017-07-05 16:03:29
 설    명 : ScreenMaster Table 저장 
 샘플실행 : EXEC dbo.ScreenMaster_Save '', '', '', '', '', '', ''

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[ScreenMaster_Save]
	@SCREENID varchar(20),
	@SCREENNAME nvarchar(50),
	@DLLNAME nvarchar(50),
	@CLASSNAME nvarchar(70),
	@HELPURL nvarchar(200),
	@DESCRIPTION nvarchar(100),
	@CHANGEBY nvarchar(50)
AS
BEGIN TRY
	BEGIN TRANSACTION

	IF @SCREENID IS NULL OR @SCREENID = ''
	BEGIN
		DECLARE @serial int

		--SET @serial = NEXT VALUE FOR dbo.SCREENID_SEQ
	
		SELECT @serial = RIGHT(ISNULL(MAX(SCREENID), 0), 5) + 1  FROM dbo.ScreenMaster WITH(NOLOCK)
	
		SET @SCREENID = 'SCRN' + FORMAT(@serial, '00000')
	END

	IF NOT EXISTS (SELECT 1 FROM dbo.ScreenMaster WITH(NOLOCK) WHERE SCREENID = @SCREENID) 
	BEGIN 
		INSERT INTO dbo.ScreenMaster ( SCREENID, SCREENNAME, DLLNAME, CLASSNAME, HELPURL, DESCRIPTION, INITDTTM, INITBY ) 
		VALUES ( @SCREENID, @SCREENNAME, @DLLNAME, @CLASSNAME, @HELPURL, @DESCRIPTION, GETDATE(), @CHANGEBY ) 
	END 
	ELSE 
	BEGIN 
		UPDATE dbo.ScreenMaster
		SET SCREENNAME = @SCREENNAME
		  , DLLNAME = @DLLNAME
		  , CLASSNAME = @CLASSNAME
		  , HELPURL = @HELPURL
		  , DESCRIPTION = @DESCRIPTION
		  , UPDTTM = GETDATE()
		  , UPBY = @CHANGEBY
		WHERE SCREENID = @SCREENID
	END 
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.ScreenMaster_Save : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH



GO
/****** Object:  StoredProcedure [dbo].[ScreenMaster_Select]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2017-07-05 15:59:21
 설    명 : ScreenMasterTable 조회 
 샘플실행 : EXEC dbo.ScreenMaster_Select '', '', '', '', ''

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[ScreenMaster_Select]
	@SCREENID varchar(20),
	@SCREENNAME nvarchar(50),
	@DLLNAME nvarchar(50),
	@CLASSNAME nvarchar(70),
	@DESCRIPTION nvarchar(100)
AS
DECLARE @query NVARCHAR(MAX)

SET @query = N''
SET @query = @query + N'
SELECT  SCREENID, 
		SCREENNAME, 
		DLLNAME, 
		CLASSNAME, 
		HELPURL,
		DESCRIPTION, 
		ISNULL(UPDTTM, INITDTTM) CHANGEDTTM, 
		ISNULL(UPBY, INITBY) CHANGEBY 
FROM dbo.ScreenMaster WITH(NOLOCK) 
WHERE 1 = 1 '

IF @SCREENID <> N''
	SET @query = @query + N'
		AND SCREENID LIKE ''' + @SCREENID + '%'' '

IF @SCREENNAME <> N''
	SET @query = @query + N'
		AND SCREENNAME LIKE ''' + @SCREENNAME + '%'' '

IF @DLLNAME <> N''
	SET @query = @query + N'
		AND DLLNAME LIKE ''%' + @DLLNAME + '%'' '

IF @CLASSNAME <> N''
	SET @query = @query + N'
		AND CLASSNAME LIKE ''%' + @CLASSNAME + '%'' '

IF @DESCRIPTION <> N''
	SET @query = @query + N'
		AND DESCRIPTION LIKE ''%' + @DESCRIPTION + '%'' '

--PRINT, 실행
PRINT @query
EXECUTE sp_executesql @query



GO
/****** Object:  StoredProcedure [dbo].[ServerID_Get]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ===============================================
-- 작성자: 오인봉
-- 작성일: 2017.12.07
-- 설   명: Server ID 가져오기
-- 샘플실행: EXEC ServerID_Get
-- 변경이력: 
-- 2017.12.07 SP최초작성
-- 
-- ===============================================
CREATE Procedure [dbo].[ServerID_Get]
AS
SELECT server_id AS CODEVALUE, 'SVR-MSNIB' AS DISPLAYVALUE
FROM sys.servers WITH(NOLOCK)
WHERE provider = 'SQLNCLI'
AND server_id = 0


GO
/****** Object:  StoredProcedure [dbo].[TableID_Get]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ===============================================
-- 작성자: 오인봉
-- 작성일: 2017.11.25
-- 설   명: Table ID 가져오기
-- 샘플실행: EXEC TableID_Get 0, 7
-- 변경이력: 
-- 2017.01.09 SP최초작성
-- 
-- ===============================================
CREATE Procedure [dbo].[TableID_Get]
	@server_id INT,
	@database_id INT
AS
DECLARE @query nvarchar(MAX),
		@serverName VARCHAR(200),
		@databasename	VARCHAR(200),
		@ParmDefinition NVARCHAR(500)

SELECT @serverName = name
FROM sys.servers
WHERE server_id = @server_id

SET @ParmDefinition = N'@v_databasename varchar(200) OUTPUT';
SET @query = N'
SELECT @v_databasename = name
		FROM [' + @serverName + '].master.sys.databases
WHERE database_id = ' +  CAST(@database_id AS VARCHAR(10))
							
EXECUTE sp_executesql @query, @ParmDefinition, @v_databasename = @databasename OUT

SET @query = ''

SET @query = '
SELECT st.object_id AS CODEVALUE
	 , ss.name + ''.'' + st.name AS DISPLAYVALUE
	 , ISNULL(tl.Description, cast(ep.value as varchar)) DESCRIPTION 
FROM [' + @servername + '].' + @databasename + '.sys.tables AS st WITH(NOLOCK)
JOIN [' + @servername + '].' + @databasename + '.sys.schemas AS ss WITH(NOLOCK)
ON st.schema_id = ss.schema_id
LEFT JOIN [' + @servername + '].' + @databasename + '.sys.extended_properties as ep WITH(NOLOCK)
ON ep.minor_id = 0 AND ep.major_id = st.object_id
LEFT JOIN [' + @servername + '].METADB.dbo.TableList as tl WITH(NOLOCK)
ON tl.table_id = st.object_id
WHERE st.name <> ''sysdiagrams''
ORDER BY st.name'

PRINT @query
EXEC (@query)




GO
/****** Object:  StoredProcedure [dbo].[TableInfo_Get]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ===============================================
-- 작성자: 오인봉
-- 작성일: 2017.11.25
-- 설   명: Table Column 가져오기
-- 샘플실행: EXEC TableInfo_Get 0, 16, 654013461
-- 변경이력: 
-- 2017.01.09 SP최초작성
-- 
-- ===============================================
CREATE Procedure [dbo].[TableInfo_Get]
	@server_id INT,
	@database_id INT,
	@table_id INT	
AS
DECLARE @query			NVARCHAR(MAX),
		@servername		VARCHAR(200) ,
		@databasename	VARCHAR(200),
		@tablename		VARCHAR(200),
		@ParmDefinition NVARCHAR(500)	

SELECT @servername = name
FROM sys.servers
WHERE server_id = @server_id

--SELECT @databasename = name
--FROM sys.databases
--WHERE database_id = @database_id

SET @ParmDefinition = N'@v_databasename varchar(200) OUTPUT';
SET @query = N'
SELECT @v_databasename = name
		FROM [' + @serverName + '].master.sys.databases
WHERE database_id = ' +  CAST(@database_id AS VARCHAR(10))
							
EXECUTE sp_executesql @query, @ParmDefinition, @v_databasename = @databasename OUT

SET @query = ''


SET @query = '
SELECT DISTINCT A.column_id 
			  , CASE WHEN C.key_ordinal IS NULL THEN '''' ELSE ''Y'' END key_ordinal
			  , A.name AS ColumnName
			  , B.name + CASE WHEN B.is_user_defined = 1 THEN '' : '' + E.name ELSE '''' END AS TypeName
    		  , A.max_length AS [Length]
			  , A.is_nullable
			  , A.is_identity
			  , value AS [Description] 
FROM [' + @servername + '].' + @databasename + '.sys.columns AS A WITH(NOLOCK)
JOIN [' + @servername + '].' + @databasename + '.sys.types AS B WITH(NOLOCK)
ON A.user_type_id = B.user_type_id
LEFT JOIN [' + @servername + '].' + @databasename + '.sys.index_columns AS C WITH(NOLOCK)
ON A.object_id = C.object_id AND A.column_id = C.column_id
LEFT JOIN [' + @servername + '].' + @databasename + '.sys.extended_properties AS D WITH(NOLOCK)
ON A.object_id = D.major_id AND A.column_id = D.minor_id
LEFT JOIN [' + @servername + '].' + @databasename + '.sys.types E
ON E.user_type_id = B.system_type_id
WHERE A.object_id  = ' + CAST(@table_id AS VARCHAR(10)) 
SET @query = @query + '
ORDER BY A.column_id ' + CHAR(10)

SET @query = @query + '
SELECT si.name, si.type_desc, si.is_unique, 
si.is_primary_key, si.fill_factor ' + CHAR(10)
SET @query = @query + 'FROM [' + @servername + '].' + @databasename + '.sys.indexes AS si WITH(NOLOCK)
WHERE si.name <> '''' AND si.object_id  = ' + CAST(@table_id AS VARCHAR(10)) + CHAR(10) + CHAR(10)




DECLARE @ParamDefinition nvarchar(500),
		@paramQuery NVARCHAR(1000)
		
	SET @ParamDefinition = N'@v_tableName varchar(100) OUTPUT';
	SET @paramQuery = N'
	SELECT @v_tableName = ss.name + ''.'' + A.name
			FROM [' + @servername + '].' + @databasename + N'.sys.tables AS A WITH(NOLOCK)
			JOIN [' + @servername + '].' + @databasename + N'.sys.schemas AS ss WITH(NOLOCK)
			ON A.schema_id = ss.schema_id
	WHERE A.object_id = ' + CAST(@table_id AS VARCHAR(10))
								
EXECUTE sp_executesql @paramQuery, @ParamDefinition, @v_tableName = @tablename OUT


SET @query = @query + 'SELECT TOP 10 * FROM [' + @servername + '].' + @databasename + '.' + @tablename + ' WITH(NOLOCK)'


PRINT @query
EXEC (@query)


GO
/****** Object:  StoredProcedure [dbo].[TableList_Save]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* 
==============================================================================================
 작 성 자 : 오인봉
 작 성 일 : 2010-11-25 10:47:00
 설    명 : 테이블 리스트 저장 
 샘플실행 : EXEC dbo.TableList_Save

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[TableList_Save]
	@Seq BIGINT,
	@serverid int,
	@databaseid int,
	@schemaid int,
	@tableid INT,
	@tablename nvarchar(70),
	@UseUI varchar(100),
	@Storage varchar(100),
	@Func char(1),
	@LifeCycle varchar(10),
	@Worker varchar(50),
	@Description varchar(500)
AS
BEGIN TRY
	BEGIN TRANSACTION
	IF NOT EXISTS (SELECT 1 FROM dbo.TableList WITH(NOLOCK) WHERE Seq = @Seq) 
	BEGIN 
		INSERT INTO dbo.TableList ( server_id, database_id, schema_id, table_id, TableName, UseUI, Storage, Func, LifeCycle, Worker, Description) 
		VALUES ( @serverid, @databaseid, @schemaid, @tableid, @tablename, @UseUI, @Storage, @Func, @LifeCycle, @Worker, @Description ) 
	END 
	ELSE 
	BEGIN 
		UPDATE dbo.TableList
			SET server_id = @serverid,
				database_id = @databaseid, 
				schema_id = @schemaid, 
				table_id = @tableid,
				tablename = @TableName, 
				UseUI = @UseUI, 
				Storage = @Storage, 
				Func = @Func, 
				LifeCycle = @LifeCycle, 
				Worker = @Worker, 
				Description = @Description
		WHERE Seq = @Seq
	END 
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.TableList_Save : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH



GO
/****** Object:  StoredProcedure [dbo].[TableList_Select]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* 
==============================================================================================
 작 성 자 : 오인봉
 작 성 일 : 2010-11-25 09:06:02
 설    명 : 사용자 테이블 조회 
 샘플실행 : EXEC dbo.TableList_Select 0, 1

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[TableList_Select]
	@server_id INT,
	@database_id INT
AS
DECLARE @query nvarchar(MAX),
		@serverName VARCHAR(200),
		@server varchar(20),
		@databasename	VARCHAR(200),
		@ParmDefinition NVARCHAR(500)
		
SELECT @serverName = name
FROM sys.servers
WHERE server_id = @server_id

SET @ParmDefinition = N'@v_databasename varchar(200) OUTPUT';
SET @query = N'
SELECT @v_databasename = name
		FROM [' + @serverName + '].master.sys.databases
WHERE database_id = ' +  CAST(@database_id AS VARCHAR(10))
							
EXECUTE sp_executesql @query, @ParmDefinition, @v_databasename = @databasename OUT

SET @server = 'SVR-MSNIB'
SET @query = ''

--SELECT @databasename = name
--FROM sys.databases
--WHERE database_id = @database_id

SET @query = '
SELECT tl.SEQ SEQ
	 , tl.SERVER_ID SERVERID
	 , ''[' + @server + ']'' AS SERVERNAME
	 , tl.DATABASE_ID DATABASEID
	 , ''' + @DatabaseName + ''' AS DATABASENAME
	 , tl.SCHEMA_ID SCHEMAID
	 , ss.NAME SCHEMANAME
	 , tl.TABLE_ID TABLEID
	 , isnull(st.name, tl.TABLENAME) TABLENAME
	 , st.create_date AS CREATEDATE
	 , tl.USEUI
	 , tl.STORAGE
	 , tl.FUNC
	 , tl.LIFECYCLE
	 , tl.[DESCRIPTION]
	 , tl.WORKER
	 , CASE WHEN st.name IS NULL THEN ''삭제됨'' ELSE '''' END AS TABLESTATUS  
FROM dbo.TableList AS tl WITH(NOLOCK)
LEFT JOIN [' + @serverName + '].' + @databasename + '.sys.schemas AS ss WITH(NOLOCK)
ON tl.schema_id = ss.schema_id 
LEFT JOIN [' + @serverName + '].' + @databasename + '.sys.tables AS st WITH(NOLOCK)
ON tl.table_id = st.object_id
WHERE server_id = ' + CAST(@server_id AS VARCHAR(10)) + '
AND database_id = ' + CAST(@database_id AS VARCHAR(10)) + '
UNION ALL
SELECT 0 AS Seq, ' + CAST(@server_id AS VARCHAR(10)) + ' AS server_id, ''[' + @server + ']'' as servername, ' + CAST(@database_id AS VARCHAR(10)) + ' AS database_id, ''' + @DatabaseName + ''' AS databasename,
st.schema_id,
ss.name AS schema_name,
st.object_id AS table_id,
st.name COLLATE Korean_Wansung_CI_AS AS tablename,
st.create_date AS createdate,
'''', '''', '''', '''', ISNULL(ep.value, ''''), '''', '''' 
FROM [' + @serverName + '].' + @databasename + '.sys.tables AS st WITH(NOLOCK) 
JOIN [' + @serverName + '].' + @databasename + '.sys.schemas AS ss WITH(NOLOCK)
ON st.schema_id = ss.schema_id and st.name <> ''sysdiagrams''
LEFT JOIN [' + @serverName + '].' + @databasename + '.sys.extended_properties AS ep WITH(NOLOCK)
ON ep.minor_id = 0 AND ep.major_id = st.object_id
WHERE st.object_id NOT IN (SELECT table_id FROM dbo.TableList WITH(NOLOCK) WHERE server_id = ' + CAST(@server_id AS VARCHAR(10)) + ' AND database_id = ' + CAST(@database_id AS VARCHAR(10)) + ') 
ORDER BY TableStatus, TableName'

PRINT @query

EXECUTE sp_executesql @query




GO
/****** Object:  StoredProcedure [dbo].[UsePlant_Get]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ===============================================
-- 작성자: 오인봉
-- 작성일: 2017.06.30
-- 설   명: USE Plant 가져오기
-- 샘플실행: EXEC UsePlant_Get ''
-- 변경이력: 
-- 2017.06.30 SP최초작성
-- 
-- ===============================================
CREATE PROC [dbo].[UsePlant_Get]
	@VENDORCODE	nvarchar(50)
AS
SELECT A.CODEVALUE
	 , A.DISPLAYVALUE
	 , A.IDX
	 , A.USEFLAG 
FROM dbo.CodeMaster A WITH(NOLOCK)
WHERE A.PCODEVALUE = 'C$PLANTCODE'
ORDER BY A.IDX



GO
/****** Object:  StoredProcedure [dbo].[UserCell_Save]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2018-09-12 18:09:47
 설    명 : UserCell Table 저장 
 샘플실행 : EXEC dbo.UserCell_Save

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[UserCell_Save]
	@USERID nvarchar(50),
	@VENDORCODE varchar(10),
	@PLANTCODE varchar(4),
	@LINE varchar(2),
	@CELL varchar(4),
	@STATIONGROUP varchar(4),
	@IPADDRESS	VARCHAR(30) = ''
AS
BEGIN TRY
	BEGIN TRANSACTION
	IF NOT EXISTS (SELECT 1 FROM dbo.UserCell WITH(NOLOCK) WHERE USERID = @USERID AND IPADDRESS = @IPADDRESS) 
	BEGIN 
		INSERT INTO dbo.UserCell ( USERID, VENDORCODE, PLANTCODE, LINE, CELL, STATIONGROUP, IPADDRESS, INITDTTM, INITBY ) 
		VALUES ( @USERID, @VENDORCODE, @PLANTCODE, @LINE, @CELL, @STATIONGROUP, @IPADDRESS, GETDATE(), @USERID ) 
	END 
	ELSE 
	BEGIN 
		UPDATE dbo.UserCell
		SET VENDORCODE = @VENDORCODE
		  , PLANTCODE = @PLANTCODE
		  , LINE = @LINE
		  , CELL = @CELL
		  , STATIONGROUP = @STATIONGROUP
		  , UPDTTM = GETDATE()
		  , UPBY = @USERID
		WHERE USERID = @USERID AND IPADDRESS = @IPADDRESS
	END 
	COMMIT TRANSACTION

	EXEC dbo.UserToken_Save @USERID
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.UserCell_Save : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH

GO
/****** Object:  StoredProcedure [dbo].[UserCell_Select]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2018-09-12 18:05:37
 설    명 : UserCellTable 조회 
 샘플실행 : EXEC dbo.UserCell_Select 'system'

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[UserCell_Select]
	@USERID nvarchar(50),
	@IPADDRESS varchar(50) = ''
AS
SELECT A.USERID
	 , A.VENDORCODE
	 , A.PLANTCODE
	 , A.LINE
	 , A.CELL
	 , A.STATIONGROUP
	 , ISNULL(A.UPDTTM, A.INITDTTM) CHANGEDTTM 
	 , ISNULL(A.UPBY, A.INITBY) CHANGEBY 
FROM dbo.UserCell A WITH(NOLOCK) 
WHERE A.USERID = @USERID 
AND IPADDRESS LIKE @IPADDRESS + '%'

GO
/****** Object:  StoredProcedure [dbo].[UserInfo_ChangePassword]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* 
==============================================================================================
 작 성 자 : 오인봉
 작 성 일 : 2017-06-08 15:42:50
 설    명 : 사용자 비밀번호 수정
 샘플실행 : EXEC UserInfo_ChangePassword 'system', '11111', '', '', 'aaaa'

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[UserInfo_ChangePassword]
	@USERID varchar(50),
	@NEWPASSWORD nvarchar(60),
	@SHAPASSWORD nvarchar(200) = '',
	@ENUSERID nvarchar(200) = '',
	@EPID VARCHAR(50) = ''
AS
BEGIN TRY

	IF @EPID <> ''
	BEGIN
		SET @USERID = ''

		SELECT @USERID = ISNULL(USERID, '') FROM dbo.UserToken WITH(NOLOCK) WHERE TOKENID = @EPID
	END

	SELECT 1 FROM dbo.UserInfo WITH(NOLOCK)
	WHERE USERID = @USERID

	IF @@ROWCOUNT < 1
		RETURN -1

	BEGIN TRANSACTION

	UPDATE dbo.UserInfo
	SET --PWD = CASE WHEN SSOFLAG = 1 THEN PWD ELSE @NEWPASSWORD END,
		PWD = @SHAPASSWORD,
		UPDTTM = GETDATE(),
		UPBY = @USERID
	WHERE USERID = @USERID

	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.UserInfo_ChangePassword : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH





GO
/****** Object:  StoredProcedure [dbo].[UserInfo_Get]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* 
==============================================================================================
 작 성 자 : 오인봉
 작 성 일 : 2017-06-23 15:42:50
 설    명 : UserInfoTable 조회
 샘플실행 : EXEC UserInfo_Get '' , ''

 변경이력 : 
==============================================================================================
*/ 
CREATE PROC [dbo].[UserInfo_Get]
	@USERID varchar(50),
	@USERNAME varchar(40)
AS

DECLARE @query NVARCHAR(MAX)

SET @query = N''
SET @query = @query + N'
SELECT A.USERID USERID
	 , A.USERNAME USERNAME
	 , A.LOGINID
	 , ISNULL(A.GRADECODE, '''') GRADECODE
	 , ISNULL(A.GRADENAME, '''') GRADENAME
	 , ISNULL(A.DEPTCODE, '''') DEPTCODE
	 , ISNULL(A.DEPTNAME, '''') DEPTNAME
	 , A.EMAILADDRESS
FROM dbo.UserInfo A WITH(NOLOCK)
WHERE 1 = 1 
AND A.USEFLAG = 1 '

IF @USERID <> ''
	SET @query = @query + '
AND A.USERID = ''' + @USERID + ''' '
	
IF @UserName <> ''
	SET @query = @query + '
AND A.USERNAME LIKE ''' + @UserName + '%'' '

--PRINT, 실행
PRINT @query
EXECUTE sp_executesql @query



GO
/****** Object:  StoredProcedure [dbo].[UserInfo_Save]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2016-02-09 10:20:46
 설    명 : UserInfo Table 저장 
 샘플실행 : EXEC dbo.UserInfo_Save

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[UserInfo_Save]
	@USERID nvarchar(50),
	@USERNAME nvarchar(40),
	@EMPNO nvarchar(30),
	@GRADECODE nvarchar(10),
	@GRADENAME nvarchar(40),
	@DEPTCODE nvarchar(10),
	@DEPTNAME nvarchar(40),
	@WORK nvarchar(40),
	@PHONE nvarchar(20),
	@OFFICEPHONE nvarchar(20),
	@CELLPHONE nvarchar(20),
	@EMAILADDRESS nvarchar(50),
	@USEFLAG bit,
	@LOCKFLAG bit,
	@ADMINFLAG bit,
	@EXTFLAG bit,
	@CHANGEBY nvarchar(50)
AS
BEGIN TRY
	DECLARE @PWD NVARCHAR(200)
	SET @PWD = '77e6464d27a9d57d48c0ce478c2e96c5afeddd8240b489f523c0f786e19a34bc'  --기본 비밀번호(123456)

	BEGIN TRANSACTION
	IF NOT EXISTS (SELECT 1 FROM dbo.UserInfo WITH(NOLOCK) WHERE USERID = @USERID) 
	BEGIN 
		INSERT INTO dbo.UserInfo ( USERID, EPID, USERNAME, EMPNO, GRADECODE, GRADENAME, PWD, DEPTCODE, DEPTNAME, WORK, PHONE, OFFICEPHONE, CELLPHONE, EMAILADDRESS, USEFLAG, LOCKFLAG, ADMINFLAG, SSOFLAG, EXTFLAG, INITDTTM, INITBY ) 
		VALUES ( @USERID, REPLACE(CONVERT(VARCHAR(40), NEWID()), '-', ''), @USERNAME, @EMPNO, @GRADECODE, @GRADENAME, @PWD, @DEPTCODE, @DEPTNAME, @WORK, @PHONE, @OFFICEPHONE, @CELLPHONE, @EMAILADDRESS, @USEFLAG, @LOCKFLAG, @ADMINFLAG, 0, @EXTFLAG, GETDATE(), @CHANGEBY ) 
				
		DECLARE @EXPDATE date;
		
		SET @EXPDATE = DATEADD(year, 10, GETDATE());

		EXEC dbo.AuthGroupUser_Save 'COMMON', @USERID, 0, @EXPDATE, @CHANGEBY;

		EXEC dbo.PlantAuth_Save '0001', @USERID, @EXPDATE, 0, @CHANGEBY;
	END 
	ELSE 
	BEGIN 
		UPDATE dbo.UserInfo
		SET USERNAME = @USERNAME, 
		    EMPNO = @EMPNO,
			GRADECODE = @GRADECODE,
			GRADENAME = @GRADENAME, 
			DEPTNAME = @DEPTNAME, 
			DEPTCODE = @DEPTCODE, 
			WORK = @WORK, 
			PHONE = @PHONE, 
			OFFICEPHONE = @OFFICEPHONE, 
			CELLPHONE = @CELLPHONE, 
			EMAILADDRESS = @EMAILADDRESS, 
			USEFLAG = @USEFLAG, 
			LOCKFLAG = @LOCKFLAG, 
			ADMINFLAG = @ADMINFLAG, 
			EXTFLAG = @EXTFLAG,
			UPDTTM = GETDATE(), 
			UPBY = @CHANGEBY
		WHERE USERID = @USERID
	END 
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.UserInfo_Save : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH





GO
/****** Object:  StoredProcedure [dbo].[UserInfo_Select]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* 
==============================================================================================
 작 성 자 : 오인봉
 작 성 일 : 2017-06-23 15:42:50
 설    명 : UserInfoTable 조회
 샘플실행 : EXEC UserInfo_Select '' , '', 0

 변경이력 : 
==============================================================================================
*/ 
CREATE PROC [dbo].[UserInfo_Select]
	@USERID nvarchar(30),
	@USERNAME nvarchar(40),
	@SSOFLAG varchar(1) = ''
AS
DECLARE @query NVARCHAR(MAX)

SET @query = N''
SET @query = @query + N'
WITH LASTLOGINTIME
AS
(
	SELECT USERID, MAX(SIGNINTIME) LASTTIME, COUNT(USERID) CNT
	FROM dbo.SignLog WITH(NOLOCK)
	GROUP BY USERID
)
SELECT A.EPID
	 , A.USERID
	 , A.USERNAME
	 , A.EMPNO
	 , A.PWD
	 , A.GRADECODE
	 , A.GRADENAME
	 , A.DEPTCODE
	 , A.DEPTNAME
	 , A.WORK
	 , A.PHONE
	 , A.OFFICEPHONE
	 , A.CELLPHONE
	 , A.EMAILADDRESS
	 , A.USEFLAG
	 , ISNULL(A.LOCKFLAG, 0) LOCKFLAG
	 , ISNULL(A.ADMINFLAG, 0) ADMINFLAG
	 , A.SSOFLAG
	 , ISNULL(A.EXTFLAG, 0) EXTFLAG
	 , C.TOKENID ENUSERID
	 , B.LASTTIME
	 , B.CNT
	 , ISNULL(A.UPDTTM, A.INITDTTM) CHANGEDTTM
	 , ISNULL(A.UPBY, A.INITBY) CHANGEBY 
FROM dbo.UserInfo A WITH(NOLOCK)
LEFT JOIN LASTLOGINTIME B
ON A.USERID = B.USERID
LEFT JOIN dbo.UserToken C WITH(NOLOCK)
ON A.USERID = C.USERID
WHERE 1 = 1 '

IF @USERID <> N''
	SET @query = @query + '
AND A.USERID LIKE ''' + @USERID + '%'' '
	
IF @USERNAME <> N''
	SET @query = @query + '
AND A.USERNAME LIKE ''' + @USERNAME + '%'' '

IF @SSOFLAG <> N''
	SET @query = @query + '
AND A.SSOFLAG = ' + @SSOFLAG + ' '

--PRINT, 실행
PRINT @query
EXECUTE sp_executesql @query




GO
/****** Object:  StoredProcedure [dbo].[UserMenuAuth_Check]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ===============================================
-- 작성자: 오인봉
-- 작성일: 2017.05.19
-- 설   명: 사용자 MENU 권한 실시간 CHECK
-- 샘플실행: EXEC UserMenuAuth_Check 'SYS04', 'inbong.oh'
-- 변경이력: 
-- 2017.05.19 SP최초작성
-- 
-- ===============================================
CREATE PROC [dbo].[UserMenuAuth_Check]
	@MENUID NVARCHAR(20),
	@USERID varchar(50)
AS
SELECT A.MENUID
	 , MAX(cast(SUBSTRING(A.AUTHORITY, 1, 1) as int)) AS SELECTAUTH
	 , MAX(cast(SUBSTRING(A.AUTHORITY, 3, 1) as int)) AS NEWAUTH
	 , MAX(cast(SUBSTRING(A.AUTHORITY, 5, 1) as int)) AS SAVEAUTH
	 , MAX(cast(SUBSTRING(A.AUTHORITY, 7, 1) as int)) AS DELAUTH
FROM dbo.AuthGroupMenu AS A WITH(NOLOCK) 
WHERE A.GROUPCODE IN (SELECT GROUPCODE FROM AuthGroupUser WHERE USERID IN ( @USERID )  AND [EXPIREDATE] > GETDATE() ) 
AND A.MENUID = REPLACE(@MENUID, '_FA', '')
GROUP BY A.MENUID




GO
/****** Object:  StoredProcedure [dbo].[UserSignOn]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ===============================================
-- 작성자: 오인봉
-- 작성일: 2017.08.04
-- 설   명: 사용자 Sign ON 처리
-- 샘플실행: EXEC UserSignOn '', '', 'system'
-- 변경이력: 
-- 2017.01.09 SP최초작성
-- 
-- ===============================================
CREATE PROC [dbo].[UserSignOn]
	@VENDORCODE nvarchar(40),
	@PLANTCODE nvarchar(20),
	@USERID nvarchar(50)
AS
DECLARE @EPID VARCHAR(40)

exec dbo.UserToken_Save @USERID

SELECT @EPID =  TOKENID 
FROM dbo.UserToken WITH(NOLOCK)
WHERE USERID = @USERID;
--IF @VENDORCODE = ''
--	SET @VENDORCODE = '';

--IF @PLANTCODE = ''
--	SET @PLANTCODE = '';

WITH LASTLOG
AS
(
	SELECT L.USERID
		 , L.SIGNINTIME LASTSIGNINTIME
		 , L.SIGNOFFTIME LASTSIGNOFFTIME
		 , L.IPADDRESS LASTSIGNIP
	FROM dbo.SignLog AS L WITH(NOLOCK)
	WHERE L.USERID = @USERID
	AND L.SIGNOFFTIME IS NOT NULL
	AND L.SIGNINTIME = ( SELECT MAX(SIGNINTIME) 
						 FROM dbo.SignLog WITH(NOLOCK) 
						 WHERE USERID = L.USERID AND SIGNOFFTIME IS NOT NULL 
					   )
)
SELECT @EPID EPID
	 , A.LOGINID
     , A.USERID
	 , A.USERNAME
	 , A.EMPNO
	 , A.PWD
	 , A.GRADECODE
	 , A.GRADENAME
	 , A.DEPTCODE
	 , A.DEPTNAME
	 , @VENDORCODE AS VENDORCODE
	 , dbo.fnGetCodeMasterValue('C$VENDORCODE', @VENDORCODE) AS VENDORNAME
	 , @PLANTCODE AS PLANTCODE
	 , ISNULL(( SELECT DESCRIPTION FROM dbo.Plants WHERE VENDORCODE = @VENDORCODE AND PLANTCODE = @PLANTCODE ), '') AS PLANTNAME
	 , A.PHONE
	 , A.OFFICEPHONE
	 , A.CELLPHONE
	 , A.EMAILADDRESS
	 , A.USEFLAG
	 , A.LOCKFLAG
	 , A.ADMINFLAG
	 , A.SSOFLAG
	 , A.EXTFLAG
	 , A.GTPSID
	 , ISNULL(B.LASTSIGNINTIME, GETDATE()) LASTSIGNINTIME
	 , B.LASTSIGNOFFTIME
	 , B.LASTSIGNIP
FROM dbo.UserInfo AS A WITH(NOLOCK)
LEFT JOIN LASTLOG AS B
ON A.USERID = B.USERID
WHERE A.USEFLAG = 1 
AND A.USERID = @USERID



GO
/****** Object:  StoredProcedure [dbo].[UserToken_Save]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2022-10-12 08:07:01
 설    명 : UserToken Table 저장 
 샘플실행 : EXEC dbo.UserToken_Save 'system'

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[UserToken_Save]
	@USERID nvarchar(50)
AS
BEGIN TRY
	DECLARE @EPID VARCHAR(40)
	SET @EPID = REPLACE(CONVERT(VARCHAR(40), NEWID()), '-', '')

	BEGIN TRANSACTION
	IF NOT EXISTS (SELECT 1 FROM dbo.UserToken WITH(NOLOCK) WHERE USERID = @USERID) 
	BEGIN 
		INSERT INTO dbo.UserToken ( USERID, TOKENID, TOKENCNT, CHANGEDTTM) 
		VALUES ( UPPER(@USERID), @EPID, 1, GETDATE() ) 
	END 
	ELSE 
	BEGIN 
		UPDATE dbo.UserToken
		SET TOKENID = @EPID
		  , TOKENCNT = TOKENCNT + 1
		  , CHANGEDTTM = GETDATE()
		WHERE USERID = @USERID
	END 
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.UserToken_Save : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[UseVendor_Get]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ===============================================
-- 작성자: 오인봉
-- 작성일: 2017.06.30
-- 설   명: USE GBM 가져오기
-- 샘플실행: EXEC UseVendor_Get
-- 변경이력: 
-- 2017.12.30 SP최초작성
-- 
-- ===============================================
CREATE PROC [dbo].[UseVendor_Get]
AS
SELECT A.CODEVALUE
	 , A.DISPLAYVALUE
	 , A.IDX
	 , A.USEFLAG 
FROM dbo.CodeMaster A WITH(NOLOCK)
WHERE A.PCODEVALUE = 'C$VENDORCODE'
ORDER BY A.IDX

GO
/****** Object:  StoredProcedure [dbo].[VendorAuth_Delete]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* 
==============================================================================================
 작 성 자 : 오인봉
 작 성 일 : 2018-02-09 09:40:12
 설    명 : VendorAuth Table 삭제
 샘플실행 : EXEC dbo.VendorAuth_Delete '', ''

 변경이력 : 
==============================================================================================
*/ 
CREATE PROC [dbo].[VendorAuth_Delete]
	@VENDORCODE nvarchar(10),
	@USERID nvarchar(50)
AS
BEGIN TRY
	BEGIN TRANSACTION

		DELETE FROM dbo.VendorAuth
		WHERE VENDORCODE = @VENDORCODE AND USERID = @USERID

	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.VendorAuth_Delete : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH


GO
/****** Object:  StoredProcedure [dbo].[VendorAuth_Get]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* 
==============================================================================================
 작 성 자 : 오인봉
 작 성 일 : 2018-02-09 09:38:14
 설    명 : VendorAuth 가져오기
 샘플실행 : EXEC dbo.VendorAuth_Get 'system'

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[VendorAuth_Get]
	@USERID nvarchar(50)
AS
SELECT A.CODEVALUE
	 , A.DISPLAYVALUE
FROM dbo.CodeMaster A WITH(NOLOCK) 
WHERE 1 = 1
AND A.USEFLAG = 1
AND A.PCODEVALUE = 'C$VENDORCODE'
AND A.USEFLAG = 1
--AND A.CODEVALUE = '0000000001'
AND A.CODEVALUE IN ( SELECT VENDORCODE FROM dbo.VendorAuth WITH(NOLOCK) WHERE USERID = @USERID  )
ORDER BY A.IDX
GO
/****** Object:  StoredProcedure [dbo].[VendorAuth_Save]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* 
==============================================================================================
 작 성 자 : 오인봉
 작 성 일 : 2018-02-09 09:39:18
 설    명 : VendorAuth Table 저장 
 샘플실행 : EXEC dbo.VendorAuth_Save

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[VendorAuth_Save]
	@VENDORCODE nvarchar(10),
	@USERID nvarchar(50),
	@EXPIREDATE datetime,
	@ISDELEGATE bit,
	@CHANGEBY nvarchar(50)
AS
BEGIN TRY
	BEGIN TRANSACTION

	--IF @ISDELEGATE = 0
	--BEGIN
	--	DELETE FROM dbo.AuthGroupUser 
	--	WHERE GROUPCODE = 'AUTH002' AND USERID = @USERID
	--END
	--SET @EXPIREDATE = '2050-12-31'

	IF @ISDELEGATE = 1
	BEGIN
		IF NOT EXISTS (SELECT 1 FROM dbo.AuthGroupUser WITH(NOLOCK) WHERE GROUPCODE = 'AUTH001' AND USERID = @USERID) 
		BEGIN 
			INSERT INTO dbo.AuthGroupUser ( GROUPCODE, USERID, EXPIREDATE, ISDELEGATE, INITDTTM, INITBY ) 
			VALUES ( 'AUTH001', @USERID, @EXPIREDATE, CASE WHEN @USERID = 'system' THEN 1 ELSE 0 END, GETDATE(), @CHANGEBY ) 
		END 
	END
	IF NOT EXISTS (SELECT 1 FROM dbo.VendorAuth WITH(NOLOCK) WHERE VENDORCODE = @VENDORCODE AND USERID = @USERID) 
	BEGIN 
		INSERT INTO dbo.VendorAuth ( VENDORCODE, USERID, [EXPIREDATE], ISDELEGATE, INITDTTM, INITBY ) 
		VALUES ( @VENDORCODE, @USERID, @EXPIREDATE, @ISDELEGATE, GETDATE(), @CHANGEBY ) 
	END 
	ELSE 
	BEGIN 
		UPDATE dbo.VendorAuth
		SET [EXPIREDATE] = @EXPIREDATE
		  , ISDELEGATE = @ISDELEGATE
		  , UPDTTM = GETDATE()
		  , UPBY = @CHANGEBY
		WHERE VENDORCODE = @VENDORCODE AND USERID = @USERID
	END 
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) 
	DECLARE @ErrorSeverity INT
	DECLARE @ErrorState INT
	SELECT @ErrorMessage = 'dbo.VendorAuth_Save : ' + ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE() 
	RAISERROR ( @ErrorMessage, @ErrorSeverity, @ErrorState ) 
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
END CATCH


GO
/****** Object:  StoredProcedure [dbo].[VendorAuth_Select]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* 
==============================================================================================
 작 성 자 : 오인봉
 작 성 일 : 2018-02-09 09:38:14
 설    명 : VendorAuthTable 조회 
 샘플실행 : EXEC dbo.VendorAuth_Select '0000000001', ''

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[VendorAuth_Select]
	@VENDORCODE nvarchar(10),
	@USERNAME varchar(50) = ''
AS
SELECT A.VENDORCODE
	 , A.USERID
	 , B.USERNAME
	 , B.DEPTNAME
	 , A.EXPIREDATE
	 , A.ISDELEGATE
	 , ISNULL(A.UPDTTM, A.INITDTTM) CHANGEDTTM 
	 , ISNULL(A.UPBY, A.INITBY) CHANGEBY 
FROM dbo.VendorAuth A WITH(NOLOCK) 
JOIN dbo.UserInfo B WITH(NOLOCK)
ON A.USERID = B.USERID
WHERE A.VENDORCODE = @VENDORCODE
AND B.USERNAME LIKE @USERNAME + '%'


GO
/****** Object:  StoredProcedure [dbo].[VendorList_Select]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* 
==============================================================================================
 작 성 자 : 오인봉
 작 성 일 : 2018-02-08 17:45:58
 설    명 : CodeMasterTable 조회 
 샘플실행 : EXEC dbo.VendorList_Select '', '', 'system'

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[VendorList_Select]
	@CODEVALUE nvarchar(20),
	@DISPLAYVALUE nvarchar(50),
	@USERID varchar(50) = ''
AS
SELECT A.CODEVALUE
	 , A.DISPLAYVALUE
	 , ISNULL(A.UPDTTM, A.INITDTTM) CHANGEDTTM 
	 , ISNULL(A.UPBY, A.INITBY) CHANGEBY 
FROM dbo.CodeMaster A WITH(NOLOCK) 
WHERE 1 = 1
AND A.USEFLAG = 1
AND A.PCODEVALUE = 'C$VENDORCODE'
AND A.CODEVALUE LIKE @CODEVALUE + '%'
AND A.DISPLAYVALUE LIKE  @DISPLAYVALUE + '%'
AND A.CODEVALUE IN ( SELECT VENDORCODE FROM dbo.VendorAuth WITH(NOLOCK) WHERE USERID = @USERID AND ISDELEGATE = 1 )
ORDER BY A.IDX

GO
/****** Object:  StoredProcedure [dbo].[VendorPlantAuth_Batch]    Script Date: 2024-08-19 오후 7:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* 
==============================================================================================
 작 성 자 : 
 작 성 일 : 2017-10-25 13:07:03
 설    명 : 업체, 사업장 권한 일괄 Table 저장 
 샘플실행 : EXEC dbo.VendorPlantAuth_Batch

 변경이력 : 
==============================================================================================
*/ 
CREATE PROCEDURE [dbo].[VendorPlantAuth_Batch]
AS
INSERT INTO VendorAuth (VENDORCODE, USERID, EXPIREDATE, ISDELEGATE, INITDTTM, INITBY)
SELECT A.CODEVALUE, B.USERID, '2050-12-31', 1, GETDATE(), 'system'
FROM dbo.CodeMaster A WITH(NOLOCK)
JOIN dbo.UserInfo B WITH(NOLOCK)
ON B.ADMINFLAG = 1
WHERE A.PCODEVALUE = 'C$VENDORCODE'
AND A.USEFLAG = 1
--AND A.CODEVALUE IN ('0000176997')
AND B.USERID NOT IN (SELECT USERID FROM dbo.VendorAuth WITH(NOLOCK) WHERE VENDORCODE = A.CODEVALUE)


INSERT INTO PlantAuth (PLANTCODE, USERID, EXPIREDATE, ISDELEGATE, INITDTTM, INITBY)
SELECT A.CODEVALUE, B.USERID, '2050-12-31', 1, GETDATE(), 'system'
FROM dbo.CodeMaster A WITH(NOLOCK)
JOIN dbo.UserInfo B WITH(NOLOCK)
ON B.ADMINFLAG = 1
WHERE A.PCODEVALUE = 'C$PLANTCODE'
AND A.USEFLAG = 1
--AND A.CODEVALUE IN ('0000176997')
AND B.USERID NOT IN (SELECT USERID FROM dbo.PlantAuth WITH(NOLOCK) WHERE PLANTCODE = A.CODEVALUE)
GO
/****** Object:  DdlTrigger [DatabaseTriggerLog]    Script Date: 2024-08-19 오후 7:14:40 ******/
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'권한 Group Code' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuthGroup', @level2type=N'COLUMN',@level2name=N'GROUPCODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'권한 그룹 명' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuthGroup', @level2type=N'COLUMN',@level2name=N'GROUPNAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'공정 체크' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuthGroup', @level2type=N'COLUMN',@level2name=N'CHECKPROCESS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'예외 여부' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuthGroup', @level2type=N'COLUMN',@level2name=N'RESTRICTIONFLAG'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'설명' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuthGroup', @level2type=N'COLUMN',@level2name=N'DESCRIPTION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록일' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuthGroup', @level2type=N'COLUMN',@level2name=N'INITDTTM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuthGroup', @level2type=N'COLUMN',@level2name=N'INITBY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'변경일' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuthGroup', @level2type=N'COLUMN',@level2name=N'UPDTTM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'변경자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuthGroup', @level2type=N'COLUMN',@level2name=N'UPBY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'권한 Group Code' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuthGroupMenu', @level2type=N'COLUMN',@level2name=N'GROUPCODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'MENU ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuthGroupMenu', @level2type=N'COLUMN',@level2name=N'MENUID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'권한(조회/신규/저장/삭제)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuthGroupMenu', @level2type=N'COLUMN',@level2name=N'AUTHORITY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록일' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuthGroupMenu', @level2type=N'COLUMN',@level2name=N'INITDTTM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuthGroupMenu', @level2type=N'COLUMN',@level2name=N'INITBY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'변경일' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuthGroupMenu', @level2type=N'COLUMN',@level2name=N'UPDTTM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'변경자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuthGroupMenu', @level2type=N'COLUMN',@level2name=N'UPBY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'권한 Group Code' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuthGroupUser', @level2type=N'COLUMN',@level2name=N'GROUPCODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'사용자 ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuthGroupUser', @level2type=N'COLUMN',@level2name=N'USERID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'만료일자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuthGroupUser', @level2type=N'COLUMN',@level2name=N'EXPIREDATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'권한위임' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuthGroupUser', @level2type=N'COLUMN',@level2name=N'ISDELEGATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록일' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuthGroupUser', @level2type=N'COLUMN',@level2name=N'INITDTTM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuthGroupUser', @level2type=N'COLUMN',@level2name=N'INITBY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'변경일' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuthGroupUser', @level2type=N'COLUMN',@level2name=N'UPDTTM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'변경자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuthGroupUser', @level2type=N'COLUMN',@level2name=N'UPBY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'CODE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CodeInfo', @level2type=N'COLUMN',@level2name=N'CODEVALUE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'CODE 설명' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CodeInfo', @level2type=N'COLUMN',@level2name=N'DISPLAYVALUE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'KEY1 사용 여부' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CodeInfo', @level2type=N'COLUMN',@level2name=N'KEY1USE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'KEY1 헤더 텍스트' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CodeInfo', @level2type=N'COLUMN',@level2name=N'KEY1CAPTION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'KEY2 사용 여부' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CodeInfo', @level2type=N'COLUMN',@level2name=N'KEY2USE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'KEY2 헤더 텍스트' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CodeInfo', @level2type=N'COLUMN',@level2name=N'KEY2CAPTION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'KEY3 사용 여부' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CodeInfo', @level2type=N'COLUMN',@level2name=N'KEY3USE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'KEY3 헤더 텍스트' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CodeInfo', @level2type=N'COLUMN',@level2name=N'KEY3CAPTION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FIELD1 사용여부' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CodeInfo', @level2type=N'COLUMN',@level2name=N'FIELD1USE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FIELD1 헤더 텍스트' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CodeInfo', @level2type=N'COLUMN',@level2name=N'FIELD1CAPTION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FIELD1 사용여부' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CodeInfo', @level2type=N'COLUMN',@level2name=N'FIELD2USE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FIELD1 헤더 텍스트' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CodeInfo', @level2type=N'COLUMN',@level2name=N'FIELD2CAPTION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FIELD1 사용여부' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CodeInfo', @level2type=N'COLUMN',@level2name=N'FIELD3USE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FIELD1 헤더 텍스트' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CodeInfo', @level2type=N'COLUMN',@level2name=N'FIELD3CAPTION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FIELD1 사용여부' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CodeInfo', @level2type=N'COLUMN',@level2name=N'FIELD4USE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FIELD1 헤더 텍스트' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CodeInfo', @level2type=N'COLUMN',@level2name=N'FIELD4CAPTION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'사용여부' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CodeInfo', @level2type=N'COLUMN',@level2name=N'USEFLAG'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록일' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CodeInfo', @level2type=N'COLUMN',@level2name=N'INITDTTM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CodeInfo', @level2type=N'COLUMN',@level2name=N'INITBY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'변경일' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CodeInfo', @level2type=N'COLUMN',@level2name=N'UPDTTM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'변경자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CodeInfo', @level2type=N'COLUMN',@level2name=N'UPBY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록일' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FTPInfo', @level2type=N'COLUMN',@level2name=N'INITDTTM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FTPInfo', @level2type=N'COLUMN',@level2name=N'INITBY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'변경일' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FTPInfo', @level2type=N'COLUMN',@level2name=N'UPDTTM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'변경자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FTPInfo', @level2type=N'COLUMN',@level2name=N'UPBY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'HtmlContentsMaster', @level2type=N'COLUMN',@level2name=N'HTMLID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A : 결재, M : 메일' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'HtmlContentsMaster', @level2type=N'COLUMN',@level2name=N'GBN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'내용' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'HtmlContentsMaster', @level2type=N'COLUMN',@level2name=N'CONTENTS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록일' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'HtmlContentsMaster', @level2type=N'COLUMN',@level2name=N'INITDTTM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'HtmlContentsMaster', @level2type=N'COLUMN',@level2name=N'INITBY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'변경일' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'HtmlContentsMaster', @level2type=N'COLUMN',@level2name=N'UPDTTM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'변경자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'HtmlContentsMaster', @level2type=N'COLUMN',@level2name=N'UPBY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'MENU ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LinkMenu', @level2type=N'COLUMN',@level2name=N'MENUID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'MENU 명' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LinkMenu', @level2type=N'COLUMN',@level2name=N'MENUNAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'LEVEL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LinkMenu', @level2type=N'COLUMN',@level2name=N'LVL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'INDEX' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LinkMenu', @level2type=N'COLUMN',@level2name=N'IDX'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'링크 URL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LinkMenu', @level2type=N'COLUMN',@level2name=N'LINKURL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'설명' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LinkMenu', @level2type=N'COLUMN',@level2name=N'DESCRIPTION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'사용유무' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LinkMenu', @level2type=N'COLUMN',@level2name=N'USEFLAG'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록일' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LinkMenu', @level2type=N'COLUMN',@level2name=N'INITDTTM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LinkMenu', @level2type=N'COLUMN',@level2name=N'INITBY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'변경일' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LinkMenu', @level2type=N'COLUMN',@level2name=N'UPDTTM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'변경자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LinkMenu', @level2type=N'COLUMN',@level2name=N'UPBY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'MENU ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MenuMaster', @level2type=N'COLUMN',@level2name=N'MENUID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'MENU 명(다국어)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MenuMaster', @level2type=N'COLUMN',@level2name=N'MENUNAME_LANG'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'MENU 명' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MenuMaster', @level2type=N'COLUMN',@level2name=N'MENUNAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'LEVEL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MenuMaster', @level2type=N'COLUMN',@level2name=N'LVL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'INDEX' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MenuMaster', @level2type=N'COLUMN',@level2name=N'IDX'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'부모 MENU ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MenuMaster', @level2type=N'COLUMN',@level2name=N'PARENTMENUID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'스크린 ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MenuMaster', @level2type=N'COLUMN',@level2name=N'SCREENID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Image' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MenuMaster', @level2type=N'COLUMN',@level2name=N'IMAGEIDX'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'선택 Image' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MenuMaster', @level2type=N'COLUMN',@level2name=N'SELECTIMAGEIDX'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'사용 GBM' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MenuMaster', @level2type=N'COLUMN',@level2name=N'USEVENDORCODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'사용 ORGANIZATIONID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MenuMaster', @level2type=N'COLUMN',@level2name=N'USEPLANTCODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'공통사용 여부(PLANT 사용 안함)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MenuMaster', @level2type=N'COLUMN',@level2name=N'ISCOMMON'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'설명' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MenuMaster', @level2type=N'COLUMN',@level2name=N'DESCRIPTION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'사용유무' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MenuMaster', @level2type=N'COLUMN',@level2name=N'USEFLAG'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록일' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MenuMaster', @level2type=N'COLUMN',@level2name=N'INITDTTM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MenuMaster', @level2type=N'COLUMN',@level2name=N'INITBY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'변경일' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MenuMaster', @level2type=N'COLUMN',@level2name=N'UPDTTM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'변경자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MenuMaster', @level2type=N'COLUMN',@level2name=N'UPBY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'사용자 ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MyMenu', @level2type=N'COLUMN',@level2name=N'USERID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'메뉴 ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MyMenu', @level2type=N'COLUMN',@level2name=N'MENUID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'F : 즐겨찾기, S : 시작, T : 숏컷' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MyMenu', @level2type=N'COLUMN',@level2name=N'GUBUN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록일' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MyMenu', @level2type=N'COLUMN',@level2name=N'INITDTTM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MyMenu', @level2type=N'COLUMN',@level2name=N'INITBY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'변경일' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MyMenu', @level2type=N'COLUMN',@level2name=N'UPDTTM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'변경자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MyMenu', @level2type=N'COLUMN',@level2name=N'UPBY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SEQ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Notify', @level2type=N'COLUMN',@level2name=N'SEQ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'공지구분' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Notify', @level2type=N'COLUMN',@level2name=N'TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'제목' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Notify', @level2type=N'COLUMN',@level2name=N'SUBJECT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'내용' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Notify', @level2type=N'COLUMN',@level2name=N'CONTENTS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'중요도' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Notify', @level2type=N'COLUMN',@level2name=N'PRIORITY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'공지종료일자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Notify', @level2type=N'COLUMN',@level2name=N'EXPIREDATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록일' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Notify', @level2type=N'COLUMN',@level2name=N'INITDTTM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Notify', @level2type=N'COLUMN',@level2name=N'INITBY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'변경일' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Notify', @level2type=N'COLUMN',@level2name=N'UPDTTM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'변경자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Notify', @level2type=N'COLUMN',@level2name=N'UPBY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'공지사항 SEQ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NotifyConfirm', @level2type=N'COLUMN',@level2name=N'NOTIFYSEQ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'확인 사용자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NotifyConfirm', @level2type=N'COLUMN',@level2name=N'USERID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'확인 메시지' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NotifyConfirm', @level2type=N'COLUMN',@level2name=N'CONFIRMVALUE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록일' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NotifyConfirm', @level2type=N'COLUMN',@level2name=N'CHANGEDTTM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'사업장 코드' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PlantAuth', @level2type=N'COLUMN',@level2name=N'PLANTCODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'사용자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PlantAuth', @level2type=N'COLUMN',@level2name=N'USERID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'만료일자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PlantAuth', @level2type=N'COLUMN',@level2name=N'EXPIREDATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'권한위임' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PlantAuth', @level2type=N'COLUMN',@level2name=N'ISDELEGATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록일' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PlantAuth', @level2type=N'COLUMN',@level2name=N'INITDTTM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PlantAuth', @level2type=N'COLUMN',@level2name=N'INITBY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'변경일' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PlantAuth', @level2type=N'COLUMN',@level2name=N'UPDTTM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'변경자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PlantAuth', @level2type=N'COLUMN',@level2name=N'UPBY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SQL 그룹' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'QueryMaster', @level2type=N'COLUMN',@level2name=N'SQLGROUP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'쿼리ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'QueryMaster', @level2type=N'COLUMN',@level2name=N'QUERYID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'쿼리 설명' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'QueryMaster', @level2type=N'COLUMN',@level2name=N'SUBJECT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'쿼리 구분(SP,TEXT...)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'QueryMaster', @level2type=N'COLUMN',@level2name=N'QUERYTYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'쿼리 문자열' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'QueryMaster', @level2type=N'COLUMN',@level2name=N'QUERYTEXT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Connection String 연결 ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'QueryMaster', @level2type=N'COLUMN',@level2name=N'DBID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'INDEX' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'QueryMaster', @level2type=N'COLUMN',@level2name=N'IDX'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록일' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'QueryMaster', @level2type=N'COLUMN',@level2name=N'INITDTTM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'QueryMaster', @level2type=N'COLUMN',@level2name=N'INITBY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'변경일' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'QueryMaster', @level2type=N'COLUMN',@level2name=N'UPDTTM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'변경자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'QueryMaster', @level2type=N'COLUMN',@level2name=N'UPBY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SCREEN ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ScreenColumnSet', @level2type=N'COLUMN',@level2name=N'SCREENID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Grid 명' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ScreenColumnSet', @level2type=N'COLUMN',@level2name=N'GRIDNAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Column Field 명' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ScreenColumnSet', @level2type=N'COLUMN',@level2name=N'FIELDNAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Column Header Text' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ScreenColumnSet', @level2type=N'COLUMN',@level2name=N'CAPTION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Column 너비' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ScreenColumnSet', @level2type=N'COLUMN',@level2name=N'WIDTH'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Data의 최대 길이, 0이면 설정 안 함' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ScreenColumnSet', @level2type=N'COLUMN',@level2name=N'MAXLENGTH'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'소숫점 길이 수, 기본값 0' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ScreenColumnSet', @level2type=N'COLUMN',@level2name=N'DECIMALPLACE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Column Cell 수정 여부' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ScreenColumnSet', @level2type=N'COLUMN',@level2name=N'ALLOWEDIT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Column 숨김/보임 여부' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ScreenColumnSet', @level2type=N'COLUMN',@level2name=N'VISIBLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Column DataType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ScreenColumnSet', @level2type=N'COLUMN',@level2name=N'DATATYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Column Cell 정렬' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ScreenColumnSet', @level2type=N'COLUMN',@level2name=N'HORIZONALIGN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록일' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ScreenColumnSet', @level2type=N'COLUMN',@level2name=N'INITDTTM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ScreenColumnSet', @level2type=N'COLUMN',@level2name=N'INITBY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'변경일' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ScreenColumnSet', @level2type=N'COLUMN',@level2name=N'UPDTTM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'변경자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ScreenColumnSet', @level2type=N'COLUMN',@level2name=N'UPBY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SCREEN ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ScreenColumnSetDetail', @level2type=N'COLUMN',@level2name=N'SCREENID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Grid 명' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ScreenColumnSetDetail', @level2type=N'COLUMN',@level2name=N'GRIDNAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'[선택] 컬럼 사용 여부' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ScreenColumnSetDetail', @level2type=N'COLUMN',@level2name=N'USESELECTCOLUMN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primary Key 컬럼' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ScreenColumnSetDetail', @level2type=N'COLUMN',@level2name=N'KEYCOLUMNS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'필수입력항목 컬럼' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ScreenColumnSetDetail', @level2type=N'COLUMN',@level2name=N'MANDATORYCOLUMNS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'신규 Row의 Enable 컬럼' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ScreenColumnSetDetail', @level2type=N'COLUMN',@level2name=N'NEWROWENABLECOLUMNS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'신규 Row 생성 시 이전 컬럼의 값을 복사할 컬럼' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ScreenColumnSetDetail', @level2type=N'COLUMN',@level2name=N'NEWROWCOPYCOLUMNS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록일' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ScreenColumnSetDetail', @level2type=N'COLUMN',@level2name=N'INITDTTM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ScreenColumnSetDetail', @level2type=N'COLUMN',@level2name=N'INITBY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'변경일' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ScreenColumnSetDetail', @level2type=N'COLUMN',@level2name=N'UPDTTM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'변경자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ScreenColumnSetDetail', @level2type=N'COLUMN',@level2name=N'UPBY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'스크린 ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ScreenMaster', @level2type=N'COLUMN',@level2name=N'SCREENID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'스크린 명' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ScreenMaster', @level2type=N'COLUMN',@level2name=N'SCREENNAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'DLL 경로' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ScreenMaster', @level2type=N'COLUMN',@level2name=N'DLLNAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Class 전체 이름' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ScreenMaster', @level2type=N'COLUMN',@level2name=N'CLASSNAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'도움말 경로' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ScreenMaster', @level2type=N'COLUMN',@level2name=N'HELPURL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'설명' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ScreenMaster', @level2type=N'COLUMN',@level2name=N'DESCRIPTION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록일' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ScreenMaster', @level2type=N'COLUMN',@level2name=N'INITDTTM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ScreenMaster', @level2type=N'COLUMN',@level2name=N'INITBY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'변경일' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ScreenMaster', @level2type=N'COLUMN',@level2name=N'UPDTTM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'변경자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ScreenMaster', @level2type=N'COLUMN',@level2name=N'UPBY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'사용자 ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'USERID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'사용자 명' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'USERNAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'사번' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'EMPNO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'직급코드' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'GRADECODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'직급명' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'GRADENAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'비밀번호' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'PWD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'부서코드' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'DEPTCODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'부서명' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'DEPTNAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'담당업무' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'WORK'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'전화번호' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'PHONE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'사무실 전화번호' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'OFFICEPHONE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'핸드폰 전화번호' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'CELLPHONE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'이메일 주소' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'EMAILADDRESS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'사용유무' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'USEFLAG'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'잠금유무' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'LOCKFLAG'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'관리자여부' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'ADMINFLAG'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Knox 사용여부' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'SSOFLAG'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'외주 사용자 여부' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'EXTFLAG'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'EPID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'EPID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Login ID(Knox ID)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'LOGINID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록일' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'INITDTTM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'INITBY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'변경일' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'UPDTTM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'변경자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'UPBY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'사용자 ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserToken', @level2type=N'COLUMN',@level2name=N'USERID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록일' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserToken', @level2type=N'COLUMN',@level2name=N'CHANGEDTTM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'업체코드' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VendorAuth', @level2type=N'COLUMN',@level2name=N'VENDORCODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'사용자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VendorAuth', @level2type=N'COLUMN',@level2name=N'USERID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'만료일자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VendorAuth', @level2type=N'COLUMN',@level2name=N'EXPIREDATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'권한위임' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VendorAuth', @level2type=N'COLUMN',@level2name=N'ISDELEGATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록일' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VendorAuth', @level2type=N'COLUMN',@level2name=N'INITDTTM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'등록자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VendorAuth', @level2type=N'COLUMN',@level2name=N'INITBY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'변경일' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VendorAuth', @level2type=N'COLUMN',@level2name=N'UPDTTM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'변경자' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VendorAuth', @level2type=N'COLUMN',@level2name=N'UPBY'
GO
