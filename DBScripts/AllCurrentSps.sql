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



