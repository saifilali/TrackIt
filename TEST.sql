--USE STRDMS_ALI
--ALTER TABLE tbleFaxContactDetails
--DROP CONSTRAINT FK_tbleFaxContactDetails_tblAttachmentMaster;

--DROP TABLE tblattachmentmaster

--select * INTO STRDMS_ALI.dbo.tblattachmentmaster from STRDMS_READONLY.dbo.tblAttachmentMaster
												   
--IF COL_LENGTH('tblattachmentmaster', 'IsGoodPath') IS NULL
--BEGIN
--    ALTER TABLE tblattachmentmaster
--    ADD [IsGoodPath] TINYINT NULL DEFAULT 0
--END
--GO

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


select AttachmentMasterID,AttachmentTypeID,AssociatedSourceID,FilePath,IsOnCloud,IsGoodPath,ModifiedDate from tblAttachmentMaster where IsGoodPath = 0 and AttachmentTypeID = 1618 order by CreatedDate asc			--BAD FOLDER STRUCTURE		
select AttachmentMasterID,AttachmentTypeID,AssociatedSourceID,FilePath,IsOnCloud,IsGoodPath,ModifiedDate  from tblAttachmentMaster where IsGoodPath = 1 and AttachmentTypeID = 1618 order by CreatedDate asc			--GOOD FOLDER STRUCTURE
select AttachmentMasterID,AttachmentTypeID,AssociatedSourceID,FilePath,IsOnCloud,IsGoodPath,ModifiedDate from tblAttachmentMaster where IsGoodPath = 2 and AttachmentTypeID = 1618 order by CreatedDate asc			--FILE NOT FOUND FROM CODE	
select AttachmentMasterID,AttachmentTypeID,AssociatedSourceID,FilePath,IsOnCloud,IsGoodPath,ModifiedDate  from tblAttachmentMaster where IsGoodPath = 4 and AttachmentTypeID = 1618 order by CreatedDate asc			--MISPLACED FOLDER STRUCTURE

select AttachmentMasterID,AttachmentTypeID,AssociatedSourceID,FilePath,IsOnCloud,IsGoodPath,ModifiedDate from tblAttachmentMaster where IsGoodPath = 3 and AttachmentTypeID = 1618 order by CreatedDate asc			--FILE NOT FOUND FROM DB	
select AttachmentMasterID,AttachmentTypeID,AssociatedSourceID,FilePath,IsOnCloud,IsGoodPath,ModifiedDate  from tblAttachmentMaster where IsGoodPath is null and AttachmentTypeID = 1618 order by CreatedDate asc		--UNTOUCHED


-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


select
(select count(*) from tblAttachmentMaster where AttachmentTypeID = 1618 and IsGoodPath is null and IsOnCloud != 1 and CreatedDate >= '2016-1-1 00:00:00.000' and CreatedDate < '2016-7-1 00:00:00.000') as 'TotalFilesRemaining',
(select count(*) from tblAttachmentMaster where AttachmentTypeID = 1618 and (IsGoodPath is not null and IsGoodPath != 3 and IsGoodPath != 5) and CreatedDate >= '2016-1-1 00:00:00.000' and CreatedDate < '2016-7-1 00:00:00.000') as 'TotalFilesAlreadyProcessed',
(select count(*) from tblAttachmentMaster where AttachmentTypeID = 1618 and IsGoodPath = 0 and IsOnCloud != 1 and CreatedDate >= '2016-1-1 00:00:00.000' and CreatedDate < '2016-7-1 00:00:00.000') as 'TotalConflictedFilesFound',
(select count(*) from tblAttachmentMaster where AttachmentTypeID = 1618 and IsGoodPath = 1 and CreatedDate >= '2016-1-1 00:00:00.000' and CreatedDate < '2016-7-1 00:00:00.000') as 'TotalNotConflictedFilesFound',
(select count(*) from tblAttachmentMaster where AttachmentTypeID = 1618 and IsGoodPath = 2 and CreatedDate >= '2016-1-1 00:00:00.000' and CreatedDate < '2016-7-1 00:00:00.000') as 'TotalFilesNotFound',
(select count(*) from tblAttachmentMaster where AttachmentTypeID = 1618 and IsGoodPath = 3 and CreatedDate >= '2016-1-1 00:00:00.000' and CreatedDate < '2016-7-1 00:00:00.000') as 'TotalFilesNotFoundFromDB',
(select count(*) from tblAttachmentMaster where AttachmentTypeID = 1618 and IsGoodPath = 4 and CreatedDate >= '2016-1-1 00:00:00.000' and CreatedDate < '2016-7-1 00:00:00.000') as 'TotalMisplacedFilesFound',
(select count(*) from tblAttachmentMaster where AttachmentTypeID = 1618 and IsGoodPath = 5 and CreatedDate >= '2016-1-1 00:00:00.000' and CreatedDate < '2016-7-1 00:00:00.000') as 'TotalFilesWithoutAssociatedRecordFromDB'


-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


select top 50 * from tblattachmentmaster where AttachmentTypeID = 1618
and FilePath not like '%https://%' 
and AttachmentMasterID > -1
and IsGoodPath is null
and IsOnCloud != 1 
and CreatedDate >= '2016-1-1 00:00:00.000'
and CreatedDate < '2016-7-1 00:00:00.000'
order by AttachmentMasterID asc

select * from tblSalesFrontCounter where SalesFrontCounterID = 2497323
select top 5000 AttachmentMasterID, FilePath,IsOnCloud,IsGoodPath,ModifiedDate, * from tblAttachmentMaster where IsGoodPath = 1 order by CreatedDate desc
select count(*) from tblAttachmentMaster where AttachmentTypeID != 1618 and IsGoodPath is null
select count(*) from tblAttachmentMaster where AttachmentTypeID = 1618 and IsGoodPath is null
select (select count(*) from tblAttachmentMaster where AttachmentTypeID = 1618 and IsGoodPath is null) - (select count(*) from tblAttachmentMaster where AttachmentTypeID != 1618 and IsGoodPath is null)
select count(*) from tblAttachmentMaster where IsOnCloud = 1
select * from tblAttachmentMaster where FilePath not like '%.com/ATHENA/PHOENIXATTACH/FRONTCOUNTER/%/%/%/%/%/%' and IsGoodPath = 1
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

SELECT * FROM   
(
    SELECT 
        ISNULL(isGoodPath,123) AS isGoodPath
        ,AttachmentMasterID
       ,R1.Description
        ,AttachmentTypeID
             
    FROM 
       dbo.tblAttachmentMaster AM
          INNER JOIN dbo.tblReferenceMapping R1 ON R1.ReferenceMappingID = AM.AttachmentTypeID WHERE AM.CreatedDate < '2019-12-1 00:00:00.000'
) t 
PIVOT(
    COUNT(AttachmentMasterID) 
    FOR isGoodPath IN ([0],[1],[2],[3],[4],[5],[123])
) AS pivot_table;
