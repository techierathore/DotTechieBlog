INSERT INTO `TechieBlog`.`BlogUser`
(`FirstName`,`LastName`,`EmailID`,`LoginPassword`,`Role`)
VALUES
('S Ravi','Kumar','TechieRathore@gmail.com','BlogPass','SysAdmin');

INSERT INTO `TechieBlog`.`Post`
(`Title`,`Abstract`,`PostContent`,`CreatedOn`,`UserID`,`Tags`,`FeaturedImage`,`Published`)
VALUES
('First Sample Blog','This is sample blog written to avoid putting null checks at variuous places',
'This is sample blog written to avoid putting null checks at variuous places, Please edit or delete this blog once you have enough blogs written',
CURDATE(),1,'C#, ASP.Net, ASP.Net Core','',1);