/*****************************************************************/
-- Author: SAI PATHA 
-- Create Date: 11/21/2016 
-- Description: JIRA: SNLPROJECT-2085 As a developer I want to create a page with functionalities for Holders to release their Allocated car parking slot,so the Holder access this page to release his/her car parking slot for single (or) multiple days

-- Updated Date:
-- Description:
/*****************************************************************/

CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmpNo] [int] NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[MobileNumber] BIGINT NULL,
	[UserLoginId] [varchar](100) NOT NULL,
	[UserType] [varchar](50) NOT NULL,
	[ParkingSlotNumber] [varchar](50) NULL,
	[Location] [varchar](100) NOT NULL,
	[OperationType] [smallint] NOT NULL  DEFAULT 1,
	UserLoginPassword VARCHAR(20) DEFAULT 'SMPS123$', 
    CONSTRAINT [PK_Users] PRIMARY KEY ([EmpNo]) 
)

GO 




GO 


