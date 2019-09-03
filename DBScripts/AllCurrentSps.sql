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

CREATE PROCEDURE `PostInsert`(IN `Title` VARCHAR(550),IN `Abstract` VARCHAR(550), 
    IN `PostContent` LONGTEXT, IN `UserID` BIGINT, IN `Tags` VARCHAR(550), 
    IN `FeaturedImage` VARCHAR(550), IN `Published` BOOLEAN)
    MODIFIES SQL DATA
INSERT INTO Post
(
	`Title`,`Abstract`,`PostContent`,`UserID`,`Tags`,`FeaturedImage`,`Published`
)
VALUES
(
	Title,Abstract, PostContent,UserID,Tags,FeaturedImage,Published
)

CREATE PROCEDURE `PostUpdate`(
    BlogPostID bigint, Title VARCHAR(550), Abstract VARCHAR(550),
    PostContent LONGTEXT, UserID bigint, Tags VARCHAR(550),
    FeaturedImage VARCHAR(550),UpdatedOn datetime, Published BOOLEAN
)
BEGIN
UPDATE Post
SET `Title` = Title, `Abstract` = Abstract, `PostContent` = PostContent,
	`UserID` = UserID, `Tags` = Tags, `FeaturedImage` = FeaturedImage,
    `UpdatedOn` = UpdatedOn, `Published` = Published
WHERE `PostID` = BlogPostID;
END

CREATE PROCEDURE `SelectAllPosts`()
BEGIN

SELECT `PostID`,`Title`,`Abstract`,`PostContent`,`CreatedOn`,`UpdatedOn`,`Published`,
	`Post`.`UserID`,`Tags`,`FeaturedImage` , `BlogUser`.`FirstName` as `BlogWriter`
FROM TechieBlog.Post inner join TechieBlog.BlogUser where `Post`.`UserID` = `BlogUser`.`UserID`;
END

CREATE PROCEDURE `PostSelect`(BlogPostID bigint)
BEGIN

SELECT `PostID`,`Title`,`Abstract`,`PostContent`,`CreatedOn`,`UpdatedOn`,
	`UserID`,`Tags`,`FeaturedImage`,`Published`
FROM Post WHERE `PostID` = BlogPostID;
END

CREATE PROCEDURE `PostsByUserID`(BlogUserID bigint)
BEGIN
SELECT `PostID`,`Title`,`Abstract`,`PostContent`,`CreatedOn`,`UpdatedOn`,
	`UserID`,`Tags`,`FeaturedImage`,`Published`
FROM Post WHERE `UserID` = BlogUserID;
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

CREATE PROCEDURE `GetPagedBlogList`(aPageSize int, aOffset int)
BEGIN
SELECT `PostID`,`Title`,`Abstract`,`PostContent`,
		(Select count(*) From TechieBlog.BlogComment WHERE TechieBlog.BlogComment.PostID = OutErr.PostID) as `CommentCount`,
		`CreatedOn`,`UpdatedOn`,`Published`,`UserID`,`Tags`,`FeaturedImage`           
FROM TechieBlog.Post OutErr Where OutErr.Published =1
Order By OutErr.PostID DESC LIMIT aPageSize OFFSET aOffset ;
END

CREATE PROCEDURE `GetTheCounts`()
BEGIN
SELECT `PostID`,`Title`,`Abstract`,`PostContent`,
        (Select count(*) From TechieBlog.Post WHERE TechieBlog.Post.Published =1 ) as `BlogCount`, 
		(Select count(*) From TechieBlog.BlogComment) as `CommentCount`,
		`CreatedOn`,`UpdatedOn`,`Published`,`UserID`,`Tags`,`FeaturedImage`           
FROM TechieBlog.Post OutErr Where OutErr.Published =1
Order By OutErr.PostID DESC LIMIT 1 ;
END

CREATE DEFINER=`ForRemote`@`%` PROCEDURE `BlogCommentInsert`(
	pPostID bigint, pGivenOn datetime, pGivenBy varchar(350),
    pEmail varchar(350), pComment varchar(850), pPublish BOOLEAN,
    pParentID bigint
)
BEGIN
INSERT INTO BlogComment
(`PostID`,`GivenOn`,`GivenBy`,`Email`,`Comment`,`Published`,`ParentCommentID`)
VALUES
(pPostID,pGivenOn,pGivenBy,pEmail,pComment,pPublish,pParentID);
END

CREATE PROCEDURE `BlogCommentSelect`(BlogCommentID bigint)
BEGIN
SELECT `CommentID`,`PostID`,`GivenOn`,`GivenBy`,`Email`,`Comment`,`Published`,`ParentCommentID`
FROM BlogComment Where `CommentID` = BlogCommentID;
END

CREATE PROCEDURE `ApproveBlogComment`(BlogCommentID bigint)
BEGIN
UPDATE BlogComment SET	`Published` = 1 WHERE `CommentID` = BlogCommentID;
END

CREATE PROCEDURE `GetPostParentComments`(BlogPostID bigint)
BEGIN
SELECT `CommentID`,`PostID`,`GivenOn`,`GivenBy`,`Email`,`Comment`,`Published`,`ParentCommentID`
FROM BlogComment Where `Published` = 1 AND (`ParentCommentID` is null OR `ParentCommentID` = 0)  AND `PostID` = BlogPostID;
END

CREATE PROCEDURE `GetPostChildComments`(BlogPostID bigint)
BEGIN
SELECT `CommentID`,`PostID`,`GivenOn`,`GivenBy`,`Email`,`Comment`,`Published`,`ParentCommentID`
FROM BlogComment Where `Published` = 1 AND `ParentCommentID` is not null AND `PostID` = BlogPostID;
END

CREATE PROCEDURE `GetPagedUnAppComments`(aPageSize int, aOffset int)
BEGIN
SELECT `CommentID`,`PostID`,`GivenOn`,`GivenBy`,`Email`,`Comment`,`Published`
FROM BlogComment Where `Published` = 0  Order By `CommentID` DESC LIMIT aPageSize OFFSET aOffset ;
END

CREATE PROCEDURE `GetPagedComments`(aPageSize int, aOffset int)
BEGIN
SELECT `CommentID`,`PostID`,`GivenOn`,`GivenBy`,`Email`,`Comment`,`Published`
FROM BlogComment Order By `CommentID` DESC LIMIT aPageSize OFFSET aOffset ;
END

CREATE PROCEDURE `GetAdminCounts`()
BEGIN
SELECT  (Select count(*) From TechieBlog.Post WHERE TechieBlog.Post.Published =1 ) as `BlogCount`, 
		(Select count(*) From TechieBlog.BlogComment) as `CommentCount`,
        (Select count(*) From TechieBlog.Tag) as `TagCount`,
		(Select count(*) From TechieBlog.BlogUser) as `UserCount`,
        (Select count(*) From TechieBlog.BlogComment WHERE TechieBlog.BlogComment.Published =0 ) as `UnAppComments`           
FROM TechieBlog.Post OutErr Where OutErr.Published =1
Order By OutErr.PostID DESC LIMIT 1 ;
END

CREATE PROCEDURE `GetPagedBlogImages`(aPageSize int, aOffset int)
BEGIN
SELECT `BlogImageID`,`ImageName`,`ImagePath`,`Size`,`CreatedTime`,`UserID`
FROM BlogImage Order By `BlogImageID` DESC LIMIT aPageSize OFFSET aOffset ;
END

