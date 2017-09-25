-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Music_SearchNameAndArtist] 
	-- Add the parameters for the stored procedure here
(
	@Term nvarchar(100)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here


		Select Top 1000 M.Name, M.Artist, MAX(M.MusicId) as MusicId
		From Music M
		Where M.Name LIKE '%'+ @Term +'%' OR M.Artist LIKE '%'+ @Term +'%'
		Group By Name, Artist


END