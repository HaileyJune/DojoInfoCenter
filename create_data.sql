use DojoInfoCenter;

SET FOREIGN_KEY_CHECKS = 0;
TRUNCATE TABLE dojoinfocenter.locations;
SET FOREIGN_KEY_CHECKS = 1;

SET @dttm = NOW();
INSERT INTO dojoinfocenter.locations (LocationName, CreatedAt, UpdatedAt) 
		VALUES 
			('Mean', @dttm, @dttm), 
			('BreakoutRoom', @dttm, @dttm), 
			('Alumni', @dttm, @dttm), 
			('Python', @dttm, @dttm), 
			('NorthWomens', @dttm, @dttm), 
			('NorthMens', @dttm, @dttm), 
			('Info', @dttm, @dttm), 
			('PingPong', @dttm, @dttm), 
			('Kitchen', @dttm, @dttm), 
			('Presentation', @dttm, @dttm), 
			('Couch', @dttm, @dttm), 
			('TeachersLounge', @dttm, @dttm), 
			('SouthMens', @dttm, @dttm), 
			('SouthWomens', @dttm, @dttm), 
			('WebFund', @dttm, @dttm), 
			('CSharp', @dttm, @dttm), 
			('FlexSpace', @dttm, @dttm);

SELECT * FROM dojoinfocenter.locations;