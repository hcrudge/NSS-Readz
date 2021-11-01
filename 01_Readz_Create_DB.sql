USE [master]


IF db_id('Readz') IS NOT NULL
	DROP DATABASE [Readz];
GO

CREATE DATABASE [Readz];
GO

USE [Readz];
GO


DROP TABLE IF EXISTS [UserProfile];
DROP TABLE IF EXISTS [Post];
DROP TABLE IF EXISTS [Tag];
DROP TABLE IF EXISTS [PostTag];
DROP TABLE IF EXISTS [Comment];
DROP TABLE IF EXISTS [Reaction];
DROP TABLE IF EXISTS [PostReaction];

GO


CREATE TABLE [UserProfile] (
  [Id] integer PRIMARY KEY IDENTITY,
  [UserName] nvarchar(50) NOT NULL,
  [Email] nvarchar(255) NOT NULL,
  [FirebaseUserID] nvarchar(255) NOT NULL,
  [ImageLocation] nvarchar(255) NOT NULL

)

CREATE TABLE [Post] (
  [Id] integer PRIMARY KEY IDENTITY,
  [PostTitle] nvarchar(255) NOT NULL,
  [ReviewContent] nvarchar(1000) NOT NULL,
  [BookTitle] nvarchar(255) NOT NULL,
  [BookAuthor] nvarchar(255) NOT NULL,
  [BookCover] nvarchar(1000) NOT NULL,
  [BookSynopsis] nvarchar(2000) NOT NULL,
  [PublishedOn] datetime,
  [UserProfileId] integer NOT NULL,

  CONSTRAINT [FK_Post_UserProfile] FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([Id])
)

CREATE TABLE [Tag] (
  [Id] int PRIMARY KEY IDENTITY,
  [Name] nvarchar(255) NOT NULL
)

CREATE TABLE [PostTag] (
  [Id] integer PRIMARY KEY IDENTITY,
  [PostId] integer NOT NULL,
  [TagId] integer NOT NULL,

  CONSTRAINT [FK_PostTag_Post] FOREIGN KEY ([PostId]) REFERENCES [Post] ([Id]),
  CONSTRAINT [FK_PostTag_Tag] FOREIGN KEY ([TagId]) REFERENCES [Tag] ([Id])
)

CREATE TABLE [Comment] (
  [Id] integer PRIMARY KEY IDENTITY,
  [PostId] integer NOT NULL,
  [UserProfileId] integer NOT NULL,
  [Subject] nvarchar(255) NOT NULL,
  [Content] nvarchar(255) NOT NULL,
  [CreateDateTime] datetime NOT NULL,

  CONSTRAINT [FK_Comment_Post] FOREIGN KEY ([PostId]) REFERENCES [Post] ([Id]),
  CONSTRAINT [FK_Comment_UserProfile] FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([Id])

)


CREATE TABLE [Reaction] (
  [Id] integer PRIMARY KEY IDENTITY,
  [Name] nvarchar(255) NOT NULL,
  [Image] nvarchar(255) NOT NULL
)


CREATE TABLE [PostReaction] (
  [Id] integer PRIMARY KEY IDENTITY,
  [PostId] integer NOT NULL,
  [ReactionId] integer NOT NULL,
  [UserProfileId] integer NOT NULL,

  CONSTRAINT [FK_PostReaction_Post] FOREIGN KEY ([PostId]) REFERENCES [Post] ([Id]),
  CONSTRAINT [FK_PostReaction_Reaction] FOREIGN KEY ([ReactionId]) REFERENCES [Reaction] ([Id]),
  CONSTRAINT [FK_PostReaction_UserProfile] FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([Id])
 
)


ALTER TABLE PostTag DROP CONSTRAINT FK_PostTag_Tag
ALTER TABLE PostTag ADD CONSTRAINT FK_PostTag_Tag FOREIGN KEY (TagId) REFERENCES Tag(Id) ON DELETE CASCADE;

ALTER TABLE PostTag DROP CONSTRAINT FK_PostTag_Post
ALTER TABLE PostTag ADD CONSTRAINT FK_PostTag_Post FOREIGN KEY (PostId) REFERENCES Post(Id) ON DELETE CASCADE;

ALTER TABLE Comment DROP CONSTRAINT FK_Comment_Post
ALTER TABLE Comment ADD CONSTRAINT FK_Comment_Post FOREIGN KEY (PostId) REFERENCES Post(Id) ON DELETE CASCADE;

ALTER TABLE PostReaction DROP CONSTRAINT FK_PostReaction_Post
ALTER TABLE PostReaction ADD CONSTRAINT FK_PostReaction_Post FOREIGN KEY (PostId) REFERENCES Post(Id) ON DELETE CASCADE;

GO
