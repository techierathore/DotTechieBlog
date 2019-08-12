CREATE DATABASE `TechieBlog` /*!40100 DEFAULT CHARACTER SET latin1 */;

CREATE TABLE `BlogComment` (
  `CommentID` bigint(20) NOT NULL AUTO_INCREMENT,
  `PostID` bigint(20) NOT NULL,
  `GivenOn` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `GivenBy` varchar(350) NOT NULL,
  `Email` varchar(350) NOT NULL,
  `Comment` varchar(850) NOT NULL,
  `Published` tinyint(1) NOT NULL,
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
  `CreatedTime` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `UpdatedTime` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `LastLogin` datetime DEFAULT NULL,
  PRIMARY KEY (`UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE `Post` (
  `PostID` bigint(20) NOT NULL AUTO_INCREMENT,
  `Title` varchar(550) NOT NULL,
  `Abstract` varchar(550) DEFAULT NULL,
  `PostContent` longtext NOT NULL,
  `CreatedOn` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `UpdatedOn` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
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
  `UpdatedTime` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `UserID` bigint(20) NOT NULL,
  PRIMARY KEY (`WidgetID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;




