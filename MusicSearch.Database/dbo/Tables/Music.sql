CREATE TABLE [dbo].[Music] (
    [MusicId] INT            IDENTITY (1, 1) NOT NULL,
    [Name]    NVARCHAR (500) NOT NULL,
    [Artist]  NVARCHAR (500) NULL,
    [Album]   NVARCHAR (500) NULL,
    [Year]    NVARCHAR (500) NULL,
    [Type]    NVARCHAR (50)  NOT NULL,
    CONSTRAINT [PK_Music] PRIMARY KEY CLUSTERED ([MusicId] ASC)
);




GO
CREATE NONCLUSTERED INDEX [NonClusteredIndex-20170924-232442]
    ON [dbo].[Music]([Artist] ASC);


GO
CREATE NONCLUSTERED INDEX [NonClusteredIndex-20170924-232346]
    ON [dbo].[Music]([Name] ASC);

