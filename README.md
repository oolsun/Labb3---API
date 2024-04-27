Anrop till Swagger: 

GET/persons: 

Execute

Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (24ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT [p].[PersonId], [p].[PersonName], [p].[PhoneNumber]
      FROM [Persons] AS [p]


GET/persons/{personId}/interests: 

personId: 1
Execute

Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (18ms) [Parameters=[@__p_0='?' (DbType = Int32)], CommandType='Text', CommandTimeout='30']
      SELECT TOP(1) [p].[PersonId], [p].[PersonName], [p].[PhoneNumber]
      FROM [Persons] AS [p]
      WHERE [p].[PersonId] = @__p_0

Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (3ms) [Parameters=[@__personId_0='?' (DbType = Int32)], CommandType='Text', CommandTimeout='30']
      SELECT [i0].[InterestId], [i0].[InterestDescription], [i0].[InterestName]
      FROM [InterestLists] AS [i]
      INNER JOIN [Interests] AS [i0] ON [i].[FK_InterestId] = [i0].[InterestId]
      WHERE [i].[FK_PersonId] = @__personId_0


GET/persons/{personId}/links: 

personId: 1 
Execute

Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (2ms) [Parameters=[@__p_0='?' (DbType = Int32)], CommandType='Text', CommandTimeout='30']
      SELECT TOP(1) [p].[PersonId], [p].[PersonName], [p].[PhoneNumber]
      FROM [Persons] AS [p]
      WHERE [p].[PersonId] = @__p_0

Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (2ms) [Parameters=[@__personId_0='?' (DbType = Int32)], CommandType='Text', CommandTimeout='30']
      SELECT [l].[LinkId], [l].[LinkName], [l].[LinkUrl]
      FROM [InterestLists] AS [i]
      LEFT JOIN [Links] AS [l] ON [i].[FK_LinkId] = [l].[LinkId]
      WHERE [i].[FK_PersonId] = @__personId_0 AND [l].[LinkId] IS NOT NULL


POST/persons/{personId}/interests: 

personId: 2
interestId: 0 (den ändras automatiskt till nästa lediga)
interestName: "Kurragömma"
interestDescription: "Försök att hitta mig"
Execute

Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (2ms) [Parameters=[@__p_0='?' (DbType = Int32)], CommandType='Text', CommandTimeout='30']
      SELECT TOP(1) [p].[PersonId], [p].[PersonName], [p].[PhoneNumber]
      FROM [Persons] AS [p]
      WHERE [p].[PersonId] = @__p_0
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (1ms) [Parameters=[@__newInterest_InterestName_0='?' (Size = 4000)], CommandType='Text', CommandTimeout='30']
      SELECT TOP(1) [i].[InterestId], [i].[InterestDescription], [i].[InterestName]
      FROM [Interests] AS [i]
      WHERE [i].[InterestName] = @__newInterest_InterestName_0
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (2ms) [Parameters=[@p0='?' (Size = 4000), @p1='?' (Size = 4000)], CommandType='Text', CommandTimeout='30']
      SET IMPLICIT_TRANSACTIONS OFF;
      SET NOCOUNT ON;
      INSERT INTO [Interests] ([InterestDescription], [InterestName])
      OUTPUT INSERTED.[InterestId]
      VALUES (@p0, @p1);
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (2ms) [Parameters=[@p0='?' (DbType = Int32), @p1='?' (DbType = Int32), @p2='?' (DbType = Int32)], CommandType='Text', CommandTimeout='30']
      SET IMPLICIT_TRANSACTIONS OFF;
      SET NOCOUNT ON;
      INSERT INTO [InterestLists] ([FK_InterestId], [FK_LinkId], [FK_PersonId])
      OUTPUT INSERTED.[InterestListId]
      VALUES (@p0, @p1, @p2);


POST/persons/{personId}/interests/{interestId}/links: 

personId: 1
interestId: 1
linkId: 0 (ändras automatiskt till nästa lediga)
linkName: "Klubbhuset"
linkUrl: "https://klubbhuset.com/sv-se/"
Execute

Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (2ms) [Parameters=[@__p_0='?' (DbType = Int32)], CommandType='Text', CommandTimeout='30']
      SELECT TOP(1) [p].[PersonId], [p].[PersonName], [p].[PhoneNumber]
      FROM [Persons] AS [p]
      WHERE [p].[PersonId] = @__p_0
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (1ms) [Parameters=[@__p_0='?' (DbType = Int32)], CommandType='Text', CommandTimeout='30']
      SELECT TOP(1) [i].[InterestId], [i].[InterestDescription], [i].[InterestName]
      FROM [Interests] AS [i]
      WHERE [i].[InterestId] = @__p_0
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (2ms) [Parameters=[@p0='?' (Size = 4000), @p1='?' (Size = 4000)], CommandType='Text', CommandTimeout='30']
      SET IMPLICIT_TRANSACTIONS OFF;
      SET NOCOUNT ON;
      INSERT INTO [Links] ([LinkName], [LinkUrl])
      OUTPUT INSERTED.[LinkId]
      VALUES (@p0, @p1);
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (2ms) [Parameters=[@p0='?' (DbType = Int32), @p1='?' (DbType = Int32), @p2='?' (DbType = Int32)], CommandType='Text', CommandTimeout='30']
      SET IMPLICIT_TRANSACTIONS OFF;
      SET NOCOUNT ON;
      INSERT INTO [InterestLists] ([FK_InterestId], [FK_LinkId], [FK_PersonId])
      OUTPUT INSERTED.[InterestListId]
      VALUES (@p0, @p1, @p2);
