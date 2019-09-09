USE  `TechieBlog` ;

CREATE TABLE `BlogComment` (
  `CommentID` bigint(20) NOT NULL AUTO_INCREMENT,
  `PostID` bigint(20) NOT NULL,
  `GivenOn` datetime NOT NULL,
  `GivenBy` varchar(350) NOT NULL,
  `Email` varchar(350) NOT NULL,
  `Comment` varchar(850) NOT NULL,
  `Published` tinyint(1) NOT NULL,
  `ParentCommentID` bigint(20) NOT NULL,
  PRIMARY KEY (`CommentID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE `BlogImage` (
  `BlogImageID` bigint(20) NOT NULL AUTO_INCREMENT,
  `ImageName` varchar(150) DEFAULT NULL,
  `ImagePath` varchar(550) NOT NULL,
  `Size` int(11) DEFAULT NULL,
  `CreatedTime` datetime NOT NULL,
  `UserID` bigint(20) NOT NULL,
  PRIMARY KEY (`BlogImageID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE `BlogUser` (
  `UserID` bigint(20) NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(250) NOT NULL,
  `LastName` varchar(250) DEFAULT NULL,
  `EmailID` varchar(550) NOT NULL,
  `LoginPassword` varchar(20) NOT NULL,
  `Role` varchar(25) NOT NULL,
  `CreatedTime` datetime,
  `UpdatedTime` datetime,
  `LastLogin` datetime DEFAULT NULL,
  PRIMARY KEY (`UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE `Post` (
  `PostID` bigint(20) NOT NULL AUTO_INCREMENT,
  `Title` varchar(550) NOT NULL,
  `Abstract` varchar(550) DEFAULT NULL,
  `PostContent` longtext NOT NULL,
  `CreatedOn` datetime,
  `UpdatedOn` datetime,
  `UserID` bigint(20) NOT NULL,
  `Tags` varchar(550) NOT NULL,
  `FeaturedImage` varchar(550) NOT NULL,
  `Published` tinyint(1) NOT NULL,
  PRIMARY KEY (`PostID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE `Tag` (
  `TagID` bigint(20) NOT NULL AUTO_INCREMENT,
  `TagName` varchar(150) NOT NULL,
  PRIMARY KEY (`TagID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE `UserSettings` (
  `SettingsID` int(11) NOT NULL AUTO_INCREMENT,
  `HomeImage` varchar(350) DEFAULT NULL,
  `HomeImageText` varchar(250) DEFAULT NULL,
  `NumberOfLastPost` tinyint(4) DEFAULT NULL,
  `NumberOfCategory` tinyint(4) DEFAULT NULL,
  `PostNumberInPage` tinyint(4) DEFAULT NULL,
  `NumberOfTopPost` tinyint(4) DEFAULT NULL,
  `UpdatedTime` datetime DEFAULT NULL,
  `UserID` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`SettingsID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE `Widgets` (
  `WidgetID` int(11) NOT NULL AUTO_INCREMENT,
  `WidgetName` varchar(150) NOT NULL,
  `WidgetContent` varchar(550) NOT NULL,
  `UpdatedTime` datetime,
  `UserID` bigint(20) NOT NULL,
  PRIMARY KEY (`WidgetID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

ALTER TABLE TechieBlog.UserSettings
DROP COLUMN NumberOfTopPost,
DROP COLUMN PostNumberInPage,
CHANGE COLUMN UpdatedTime EventDate DATETIME NULL DEFAULT NULL AFTER EventUrl,
CHANGE COLUMN SettingsID EventID BIGINT(20) NOT NULL AUTO_INCREMENT,
CHANGE COLUMN HomeImage LogoIconPath VARCHAR(350) NULL DEFAULT NULL ,
CHANGE COLUMN HomeImageText EventTitle VARCHAR(350) NULL DEFAULT NULL ,
ADD COLUMN SessionTitle VARCHAR(350) NULL AFTER EventTitle,
CHANGE COLUMN NumberOfLastPost EventUrl VARCHAR(350) NULL DEFAULT NULL ,
CHANGE COLUMN NumberOfCategory Type VARCHAR(50) NULL DEFAULT NULL , RENAME TO TechieBlog.UserEvents ;


