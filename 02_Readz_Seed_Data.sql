USE [Readz]
GO


SET IDENTITY_INSERT [UserProfile] ON
INSERT INTO [UserProfile] (
	[Id], [UserName], [Email], [FirebaseUserId], [ImageLocation])
VALUES (1, 'hcrudge', 'hcrudge1@gmail.com', 'i4u43wGO8Xfgb9qtOGV7lOwtI8K2','https://180dc.org/wp-content/uploads/2016/08/default-profile-300x284.png' ),
	   (2, 'AA', 'a@a.com', 'CrhvoPKBOBPsSdkNVeFiRuSTCEY2','https://180dc.org/wp-content/uploads/2016/08/default-profile-300x284.png');
SET IDENTITY_INSERT [UserProfile] OFF

SET IDENTITY_INSERT [Post] ON
INSERT INTO [Post] ([Id], [PostTitle], [ReviewContent], [BookTitle], [BookAuthor], [BookCover],[BookSynopsis],[PublishedOn], [UserProfileId])
VALUES (1,'Suspense and Intrigue','A fun read with just the right amount of mystery and good, clean fun.', 'The Tower Treasure','Franklin W. Dixon', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSYxP_ilxwhQQcxKm7MqVLxiEq3kBVMM8Xx6g&usqp=CAU','Frank and Joe Hardy solve their first mystery.','10/20/2021',1),
 (2,'Classic Victorian Romance','Jane Austens most well known romance. Lizzy & Mr. Darcy.', 'Pride & Prejudice','Jane Austen','https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRdN5Xdz0alp8gvC2Au54HxlyjBV_dLsCs2tg&usqp=CAU','Pride meets Prejudice in this classic romance.','10/20/2021',1)
SET IDENTITY_INSERT [Post] OFF

SET IDENTITY_INSERT [Tag] ON
INSERT INTO [Tag] ([Id], [Name])
VALUES (1, 'Fantasy'), (2, 'Fairy Tale'), (3, 'Discovery'), (4, 'Middle Grade Fiction'), (5, 'Mystery'), (6, 'Sherlock'), (7, 'Poetry'), (8, 'Verse');
SET IDENTITY_INSERT [Tag] OFF

SET IDENTITY_INSERT [Reaction] ON
INSERT INTO [Reaction] ([Id],[Name],[Image])
Values ( 1 , 'Theater', 'https://slack-imgs.com/?c=1&o1=gu&url=https%3A%2F%2Fa.slack-edge.com%2Fproduction-standard-emoji-assets%2F13.0%2Fgoogle-small%2F1f3ad%402x.png'), 
( 2 , 'Joy', 'https://a.slack-edge.com/production-standard-emoji-assets/13.0/google-small/1f602@2x.png'),
( 3 , 'PizzaSpin', 'https://emoji.slack-edge.com/T03F2SDTJ/pizzaspin/f536c60be15e719c.gif'),
( 4 , 'BabyYoda', 'https://emoji.slack-edge.com/T03F2SDTJ/baby_yoda_soup/730ab14e55635afd.gif');
SET IDENTITY_INSERT [Reaction] OFF