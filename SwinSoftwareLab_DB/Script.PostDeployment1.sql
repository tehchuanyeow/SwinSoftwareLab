/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
IF '$(LoadTestData)' = 'true'

BEGIN
DELETE FROM Students;
DELETE FROM Modules;


INSERT INTO Students(ID, FirstName, LastName) VALUES
('s1404326303', 'Kandace', 'Wyett'),
('s0852437381', 'Kellby', 'Grayshan'),
('s5332613405', 'Lula', 'Darnborough');

INSERT INTO Modules(MacAddress, IssueDate, ID) VALUES
('4B-9C-6D-09-C0-C3', '11/01/2017', 's1404326303'),
('76-37-47-F0-2D-98', '5/14/2018', 's0852437381'),
('51-7E-BA-E5-15-F6', '8/09/2018', 's5332613405');

END;