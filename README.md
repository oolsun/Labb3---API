Anrop till Swagger: 

GET/persons: 

Execute

Microsoft.EntityFrameworkCore.Database.Command[20101]<br>
      Executed DbCommand (24ms) [Parameters=[], CommandType='Text', CommandTimeout='30']<br>
      SELECT [p].[PersonId], [p].[PersonName], [p].[PhoneNumber]<br>
      FROM [Persons] AS [p]<br><br>


GET/persons/{personId}/interests: 

personId: 1<br>
Execute

Microsoft.EntityFrameworkCore.Database.Command[20101]<br>
      Executed DbCommand (18ms) [Parameters=[@__p_0='?' (DbType = Int32)], CommandType='Text', CommandTimeout='30']<br>
      SELECT TOP(1) [p].[PersonId], [p].[PersonName], [p].[PhoneNumber]<br>
      FROM [Persons] AS [p]<br>
      WHERE [p].[PersonId] = @__p_0<br>

Microsoft.EntityFrameworkCore.Database.Command[20101]<br>
      Executed DbCommand (3ms) [Parameters=[@__personId_0='?' (DbType = Int32)], CommandType='Text', CommandTimeout='30']<br>
      SELECT [i0].[InterestId], [i0].[InterestDescription], [i0].[InterestName]<br>
      FROM [InterestLists] AS [i]<br>
      INNER JOIN [Interests] AS [i0] ON [i].[FK_InterestId] = [i0].[InterestId]<br>
      WHERE [i].[FK_PersonId] = @__personId_0<br><br>


GET/persons/{personId}/links: 

personId: 1 <br>
Execute

Microsoft.EntityFrameworkCore.Database.Command[20101]<br>
      Executed DbCommand (2ms) [Parameters=[@__p_0='?' (DbType = Int32)], CommandType='Text', CommandTimeout='30']<br>
      SELECT TOP(1) [p].[PersonId], [p].[PersonName], [p].[PhoneNumber]<br>
      FROM [Persons] AS [p]<br>
      WHERE [p].[PersonId] = @__p_0<br>

Microsoft.EntityFrameworkCore.Database.Command[20101]<br>
      Executed DbCommand (2ms) [Parameters=[@__personId_0='?' (DbType = Int32)], CommandType='Text', CommandTimeout='30']<br>
      SELECT [l].[LinkId], [l].[LinkName], [l].[LinkUrl]<br>
      FROM [InterestLists] AS [i]<br>
      LEFT JOIN [Links] AS [l] ON [i].[FK_LinkId] = [l].[LinkId]<br>
      WHERE [i].[FK_PersonId] = @__personId_0 AND [l].[LinkId] IS NOT NULL<br><br>


POST/persons/{personId}/interests: 

personId: 2<br>
interestId: 0 (den ändras automatiskt till nästa lediga)<br>
interestName: "Kurragömma"<br>
interestDescription: "Försök att hitta mig"<br>
Execute

Microsoft.EntityFrameworkCore.Database.Command[20101]<br>
      Executed DbCommand (2ms) [Parameters=[@__p_0='?' (DbType = Int32)], CommandType='Text', CommandTimeout='30']<br>
      SELECT TOP(1) [p].[PersonId], [p].[PersonName], [p].[PhoneNumber]<br>
      FROM [Persons] AS [p]<br>
      WHERE [p].[PersonId] = @__p_0<br>
      
Microsoft.EntityFrameworkCore.Database.Command[20101]<br>
      Executed DbCommand (1ms) [Parameters=[@__newInterest_InterestName_0='?' (Size = 4000)], CommandType='Text', CommandTimeout='30']<br>
      SELECT TOP(1) [i].[InterestId], [i].[InterestDescription], [i].[InterestName]<br>
      FROM [Interests] AS [i]<br>
      WHERE [i].[InterestName] = @__newInterest_InterestName_0<br>
      
Microsoft.EntityFrameworkCore.Database.Command[20101]<br>
      Executed DbCommand (2ms) [Parameters=[@p0='?' (Size = 4000), @p1='?' (Size = 4000)], CommandType='Text', CommandTimeout='30']<br>
      SET IMPLICIT_TRANSACTIONS OFF;<br>
      SET NOCOUNT ON;<br>
      INSERT INTO [Interests] ([InterestDescription], [InterestName])<br>
      OUTPUT INSERTED.[InterestId]<br>
      VALUES (@p0, @p1);<br>
      
Microsoft.EntityFrameworkCore.Database.Command[20101]<br>
      Executed DbCommand (2ms) [Parameters=[@p0='?' (DbType = Int32), @p1='?' (DbType = Int32), @p2='?' (DbType = Int32)], CommandType='Text', CommandTimeout='30']<br>
      SET IMPLICIT_TRANSACTIONS OFF;<br>
      SET NOCOUNT ON;<br>
      INSERT INTO [InterestLists] ([FK_InterestId], [FK_LinkId], [FK_PersonId])<br>
      OUTPUT INSERTED.[InterestListId]<br>
      VALUES (@p0, @p1, @p2);<br><br><br>


POST/persons/{personId}/interests/{interestId}/links: 

personId: 1<br>
interestId: 1<br>
linkId: 0 (ändras automatiskt till nästa lediga)<br>
linkName: "Klubbhuset"<br>
linkUrl: "https://klubbhuset.com/sv-se/"<br>
Execute

Microsoft.EntityFrameworkCore.Database.Command[20101]<br>
      Executed DbCommand (2ms) [Parameters=[@__p_0='?' (DbType = Int32)], CommandType='Text', CommandTimeout='30']<br>
      SELECT TOP(1) [p].[PersonId], [p].[PersonName], [p].[PhoneNumber]<br>
      FROM [Persons] AS [p]<br>
      WHERE [p].[PersonId] = @__p_0<br>
      
Microsoft.EntityFrameworkCore.Database.Command[20101]<br>
      Executed DbCommand (1ms) [Parameters=[@__p_0='?' (DbType = Int32)], CommandType='Text', CommandTimeout='30']<br>
      SELECT TOP(1) [i].[InterestId], [i].[InterestDescription], [i].[InterestName]<br>
      FROM [Interests] AS [i]<br>
      WHERE [i].[InterestId] = @__p_0<br>
      
Microsoft.EntityFrameworkCore.Database.Command[20101]<br>
      Executed DbCommand (2ms) [Parameters=[@p0='?' (Size = 4000), @p1='?' (Size = 4000)], CommandType='Text', CommandTimeout='30']<br>
      SET IMPLICIT_TRANSACTIONS OFF;<br>
      SET NOCOUNT ON;<br>
      INSERT INTO [Links] ([LinkName], [LinkUrl])<br>
      OUTPUT INSERTED.[LinkId]<br>
      VALUES (@p0, @p1);<br>
      
Microsoft.EntityFrameworkCore.Database.Command[20101]<br>
      Executed DbCommand (2ms) [Parameters=[@p0='?' (DbType = Int32), @p1='?' (DbType = Int32), @p2='?' (DbType = Int32)], CommandType='Text', CommandTimeout='30']<br>
      SET IMPLICIT_TRANSACTIONS OFF;<br>
      SET NOCOUNT ON;<br>
      INSERT INTO [InterestLists] ([FK_InterestId], [FK_LinkId], [FK_PersonId])<br>
      OUTPUT INSERTED.[InterestListId]<br>
      VALUES (@p0, @p1, @p2);
