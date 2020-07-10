SELECT * FROM   
(
    SELECT 
        ISNULL(isGoodPath,7) AS isGoodPath
        ,AttachmentMasterID
       ,R1.Description
        ,AttachmentTypeID
             
    FROM 
       dbo.tblAttachmentMaster AM
          INNER JOIN dbo.tblReferenceMapping R1 ON R1.ReferenceMappingID = AM.AttachmentTypeID WHERE AM.CreatedDate < '2019-12-1 00:00:00.000'
) t 
PIVOT(
    COUNT(AttachmentMasterID) 
    FOR isGoodPath IN ([0],[1],[2],[3],[4],[5],[6],[7])
) AS pivot_table;