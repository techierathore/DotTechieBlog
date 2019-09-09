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


'*************Next Deployment ***************'

INSERT INTO `TechieBlog`.`UserEvents`
(`LogoIconPath`,`EventTitle`,`SessionTitle`,`EventUrl`,`EventDate`,`Type`,`UserID`)
VALUES
('',
'Learn DevOps, Blockchain, Cloud computing, C# and Angular',
'C# And Careers in IT',
'https://www.c-sharpcorner.com/events/learn-devops-blockchain-cloud-computing-c-sharp-and-angular',
'2019-08-31',
'Event',1);

INSERT INTO TechieBlog.UserEvents
(LogoIconPath,EventTitle,SessionTitle ,EventUrl,EventDate,Type,UserID)
VALUES
('','Global Xamarin Summit', 'RealmDb with Xamarin.Forms' ,'https://www.monkeyfest.io/blog','2017-09-23','Event',1);

INSERT INTO TechieBlog.UserEvents
(LogoIconPath,EventTitle,SessionTitle,EventUrl,EventDate,Type,UserID)
VALUES
('','Chandigarh DevCon19','.NET Everywhere','https://chandigarh.c-sharpcorner.com/','2019-06-15','Event',1);

INSERT INTO TechieBlog.UserEvents
(LogoIconPath,EventTitle,SessionTitle,EventUrl,EventDate,Type,UserID)
VALUES
('','.NET Conf 2019 Noida','Highlights of .NET Conference','https://www.meetup.com/XamTechies/events/264555829','2019-09-28','Event',1);