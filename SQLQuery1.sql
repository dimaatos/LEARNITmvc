CREATE DATABASE LEARNIT 

CREATE SCHEMA LearnIt
GO


CREATE TABLE  LearnIt.Field
(
fieldId int NOT NULL
,fieldName nvarchar(50) NOT NULL
,CONSTRAINT PK_fieldId PRIMARY KEY (fieldId)
);

CREATE TABLE  LearnIt.Category
(
categoryId int NOT NULL
,categoryName nvarchar(50) NOT NULL
,fieldId int NOT NULL
,CONSTRAINT PK_categoryId PRIMARY KEY (categoryId)
,CONSTRAINT KF_fieldId FOREIGN KEY (fieldId) REFERENCES LearnIt.Field(fieldId)
);

CREATE TABLE  LearnIt.Subscriber
(
subscriberId int IDENTITY (1,1) NOT NULL
,userName nvarchar(20) NOT NULL
,userEmail nvarchar(50) 
,courseRequest nvarchar(200) 
,CONSTRAINT PK_subscriberId PRIMARY KEY (subscriberId)
);

CREATE TABLE  LearnIt.Photo
(
photoId int IDENTITY (1,1) NOT NULL
,photoName nvarchar(20) NOT NULL
,photoNameOnServer nvarchar(50) 
,CONSTRAINT PK_photoId PRIMARY KEY (photoId)
);


CREATE TABLE  LearnIt.Teacher
(
teacherId int NOT NULL
,teacherName nvarchar(40) NOT NULL
,teacherAbout nvarchar(1000) NOT NULL 
,Education nvarchar(1000) NOT NULL 
,categoryId int NOT NULL
,photoId int NOT NULL
,CONSTRAINT PK_teacherId PRIMARY KEY (teacherId)
);



CREATE TABLE  LearnIt.Course
(
courseId int NOT NULL
,courseName nvarchar(40) NOT NULL
,courseDate datetime NOT NULL  
,courseAbout nvarchar(1000) NOT NULL 
,categoryId int NOT NULL
,teacherId int NOT NULL
,photoId int NOT NULL
,CONSTRAINT PK_courseId PRIMARY KEY (courseId)
,CONSTRAINT FK_categoryId FOREIGN KEY (categoryId) REFERENCES LearnIt.Category(categoryId)
,CONSTRAINT FK_teacherId FOREIGN KEY (teacherId) REFERENCES LearnIt.Teacher(teacherId)
,CONSTRAINT FK_photoId FOREIGN KEY (photoId) REFERENCES LearnIt.Photo(photoId)
);



CREATE TABLE  LearnIt.Subscription
(
subscriptionId int NOT NULL
,subscriberId int NOT NULL
,courseId int NOT NULL
,CONSTRAINT PK_subscriptionId PRIMARY KEY (subscriptionId)
,CONSTRAINT FK_subscriberId FOREIGN KEY (subscriberId) REFERENCES LearnIt.Subscriber(subscriberId)
,CONSTRAINT FK_courseId FOREIGN KEY (courseId) REFERENCES LearnIt.Course(courseId)
);


