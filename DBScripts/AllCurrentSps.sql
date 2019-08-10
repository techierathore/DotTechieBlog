CREATE PROCEDURE `BlogImageInsert`(
	ImageName nvarchar(150),
	ImagePath nvarchar(550),
	Size int,
	CreatedTime datetime,
	UserID bigint
)
BEGIN
INSERT INTO BlogImage
(`ImageName`,`ImagePath`,`Size`,`CreatedTime`,`UserID`)
VALUES
( ImageName,ImagePath,Size,CreatedTime,UserID );
END

CREATE PROCEDURE `BlogUsersInsert`(IN `FirstName` VARCHAR(250), IN `LastName` VARCHAR(250), IN `EmailID` VARCHAR(550), IN `LoginPassword` VARCHAR(20), IN `Role` VARCHAR(25), IN `CreatedTime` DATETIME, IN `UpdatedTime` DATETIME)
    NO SQL
INSERT INTO BlogUser
(`FirstName`,`LastName`,`EmailID`,`LoginPassword`,`Role`,`CreatedTime`,`UpdatedTime`)
VALUES
(FirstName,LastName,EmailID,LoginPassword,Role,CreatedTime,UpdatedTime)

CREATE PROCEDURE `GetAllTags`()
BEGIN
   SELECT `TagID`,`TagName` FROM Tag;
END

CREATE PROCEDURE `GetLoginUser`(	LoginMail nvarchar(550),
	LoginPassword nvarchar(20))
BEGIN
SELECT `UserID`,`FirstName`,`LastName`,`EmailID`,`LoginPassword`,`Role`,`CreatedTime`,`UpdatedTime`,`LastLogin`
FROM BlogUser WHERE EmailID = LoginMail and LoginPassword = LoginPassword;
END

CREATE PROCEDURE `GetUserByEmail`(IN `LoginMail` VARCHAR(550))
    READS SQL DATA
SELECT `UserID`,`FirstName`,`LastName`,`EmailID`,`LoginPassword`,`Role`,`CreatedTime`,`UpdatedTime`,`LastLogin`
FROM BlogUser WHERE EmailID = LoginMail

CREATE PROCEDURE `PostInsert`(
	IN `Title` VARCHAR(550),
    IN `Abstract` VARCHAR(550), 
    IN `PostContent` LONGTEXT, 
    IN `UserID` BIGINT, 
    IN `Tags` VARCHAR(550), 
    IN `FeaturedImage` VARCHAR(550), 
    IN `Published` BOOLEAN)
    MODIFIES SQL DATA
INSERT INTO Post
(
	`Title`,`Abstract`,`PostContent`,`UserID`,`Tags`,`FeaturedImage`,`Published`
)
VALUES
(
	Title,Abstract, PostContent,UserID,Tags,FeaturedImage,Published
)

CREATE PROCEDURE `PostsByUserID`(BlogUserID bigint)
BEGIN
SELECT `PostID`,`Title`,`Abstract`,`PostContent`,`CreatedOn`,`UpdatedOn`,
	`UserID`,`Tags`,`FeaturedImage`,`Published`
FROM Post WHERE `UserID` = BlogUserID;
END

CREATE PROCEDURE `PostSelect`(BlogPostID bigint)
BEGIN

SELECT `PostID`,`Title`,`Abstract`,`PostContent`,`CreatedOn`,`UpdatedOn`,
	`UserID`,`Tags`,`FeaturedImage`,`Published`
FROM Post WHERE `PostID` = BlogPostID;
END

CREATE PROCEDURE `PostUpdate`(
    BlogPostID bigint,
	Title VARCHAR(550),
	Abstract VARCHAR(550),
	PostContent LONGTEXT,
	UserID bigint,
	Tags VARCHAR(550),
	FeaturedImage VARCHAR(550), 
    Published BOOLEAN
)
BEGIN
UPDATE Post
SET `Title` = Title,
    `Abstract` = Abstract,
	`PostContent` = PostContent,
	`UserID` = UserID,
	`Tags` = Tags,
	`FeaturedImage` = FeaturedImage,
	`Published` = Published
WHERE `PostID` = BlogPostID;
END

CREATE PROCEDURE `SelectAllPosts`()
BEGIN

SELECT `PostID`,`Title`,`Abstract`,`PostContent`,`CreatedOn`,`UpdatedOn`,`Published`,
	`Post`.`UserID`,`Tags`,`FeaturedImage` , `BlogUser`.`FirstName` as `BlogWriter`
FROM TechieBlog.Post inner join TechieBlog.BlogUser where `Post`.`UserID` = `BlogUser`.`UserID`;
END

CREATE PROCEDURE `TagInsert`(pTagName nvarchar(150))
BEGIN
INSERT INTO Tag (`TagName`) VALUES (pTagName);
END

CREATE PROCEDURE `TagSelect`(pTagID bigint)
BEGIN
SELECT `TagID`,	`TagName`
FROM Tag WHERE `TagID` = pTagID;
END

CREATE PROCEDURE `TagUpdate`(pTagID bigint,	pTagName nvarchar(150))
BEGIN
UPDATE Tag SET `TagName` = pTagName WHERE `TagID` = pTagID;
END
