/*
Navicat SQL Server Data Transfer

Source Server         : localhost MS SQL
Source Server Version : 120000
Source Host           : localhost:1433
Source Database       : lst
Source Schema         : dbo

Target Server Type    : SQL Server
Target Server Version : 120000
File Encoding         : 65001

Date: 2016-06-04 18:24:02
*/


-- ----------------------------
-- Table structure for __MigrationHistory
-- ----------------------------
DROP TABLE [dbo].[__MigrationHistory]
GO
CREATE TABLE [dbo].[__MigrationHistory] (
[MigrationId] nvarchar(150) NOT NULL ,
[ContextKey] nvarchar(300) NOT NULL ,
[Model] varbinary(MAX) NOT NULL ,
[ProductVersion] nvarchar(32) NOT NULL 
)


GO

-- ----------------------------
-- Table structure for Classrooms
-- ----------------------------
DROP TABLE [dbo].[Classrooms]
GO
CREATE TABLE [dbo].[Classrooms] (
[id_classroom] int NOT NULL IDENTITY(1,1) ,
[number] nvarchar(20) NOT NULL ,
[people_capacity] int NOT NULL ,
[id_department] int NOT NULL 
)


GO

-- ----------------------------
-- Table structure for Departments
-- ----------------------------
DROP TABLE [dbo].[Departments]
GO
CREATE TABLE [dbo].[Departments] (
[id_department] int NOT NULL IDENTITY(1,1) ,
[name] nvarchar(100) NOT NULL ,
[abbreviation] nvarchar(10) NOT NULL ,
[id_faculty] int NOT NULL 
)


GO

-- ----------------------------
-- Table structure for Faculties
-- ----------------------------
DROP TABLE [dbo].[Faculties]
GO
CREATE TABLE [dbo].[Faculties] (
[id_faculty] int NOT NULL IDENTITY(1,1) ,
[name] nvarchar(100) NOT NULL ,
[abbreviation] nvarchar(10) NOT NULL 
)


GO

-- ----------------------------
-- Table structure for Lessons
-- ----------------------------
DROP TABLE [dbo].[Lessons]
GO
CREATE TABLE [dbo].[Lessons] (
[id_lesson] int NOT NULL IDENTITY(1,1) ,
[week_count] int NOT NULL ,
[lesson_count] int NOT NULL ,
[id_students_group_load] int NOT NULL ,
[id_teacher_load] int NOT NULL ,
[id_classroom] int NOT NULL 
)


GO

-- ----------------------------
-- Table structure for Localization
-- ----------------------------
DROP TABLE [dbo].[Localization]
GO
CREATE TABLE [dbo].[Localization] (
[id_localization] int NOT NULL ,
[name] varchar(255) NULL ,
[language] varchar(10) NULL ,
[text] nvarchar(MAX) NULL 
)


GO

-- ----------------------------
-- Table structure for Localizations
-- ----------------------------
DROP TABLE [dbo].[Localizations]
GO
CREATE TABLE [dbo].[Localizations] (
[id_localization] int NOT NULL IDENTITY(1,1) ,
[name] nvarchar(MAX) NOT NULL ,
[language] nvarchar(MAX) NOT NULL ,
[text] nvarchar(MAX) NOT NULL 
)


GO

-- ----------------------------
-- Table structure for Students_group
-- ----------------------------
DROP TABLE [dbo].[Students_group]
GO
CREATE TABLE [dbo].[Students_group] (
[id_students_group] int NOT NULL IDENTITY(1,1) ,
[name] nvarchar(20) NOT NULL ,
[people_amount] int NOT NULL ,
[id_department] int NOT NULL 
)


GO

-- ----------------------------
-- Table structure for Students_group_load
-- ----------------------------
DROP TABLE [dbo].[Students_group_load]
GO
CREATE TABLE [dbo].[Students_group_load] (
[id_students_group_load] int NOT NULL IDENTITY(1,1) ,
[hours] int NOT NULL ,
[id_students_group] int NOT NULL ,
[id_subject] int NOT NULL 
)


GO

-- ----------------------------
-- Table structure for Subjects
-- ----------------------------
DROP TABLE [dbo].[Subjects]
GO
CREATE TABLE [dbo].[Subjects] (
[id_subject] int NOT NULL IDENTITY(1,1) ,
[name] nvarchar(50) NOT NULL ,
[type] nvarchar(20) NOT NULL ,
[id_department] int NOT NULL 
)


GO

-- ----------------------------
-- Table structure for Teacher_load
-- ----------------------------
DROP TABLE [dbo].[Teacher_load]
GO
CREATE TABLE [dbo].[Teacher_load] (
[id_teacher_load] int NOT NULL IDENTITY(1,1) ,
[id_teacher] int NOT NULL ,
[id_subject] int NOT NULL 
)


GO

-- ----------------------------
-- Table structure for Teachers
-- ----------------------------
DROP TABLE [dbo].[Teachers]
GO
CREATE TABLE [dbo].[Teachers] (
[id_teacher] int NOT NULL IDENTITY(1,1) ,
[surname] nvarchar(20) NOT NULL ,
[name] nvarchar(20) NOT NULL ,
[patronymic] nvarchar(20) NOT NULL ,
[max_hours] int NOT NULL ,
[working_position] nvarchar(20) NOT NULL ,
[regalia] nvarchar(20) NULL ,
[id_department] int NOT NULL 
)


GO

-- ----------------------------
-- Indexes structure for table __MigrationHistory
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table __MigrationHistory
-- ----------------------------
ALTER TABLE [dbo].[__MigrationHistory] ADD PRIMARY KEY ([MigrationId], [ContextKey])
GO

-- ----------------------------
-- Indexes structure for table Localization
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Localization
-- ----------------------------
ALTER TABLE [dbo].[Localization] ADD PRIMARY KEY ([id_localization])
GO

-- ----------------------------
-- Indexes structure for table Localizations
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Localizations
-- ----------------------------
ALTER TABLE [dbo].[Localizations] ADD PRIMARY KEY ([id_localization])
GO
