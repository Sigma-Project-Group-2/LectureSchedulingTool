CREATE TABLE Secret_code
(
	id_secret_code      int IDENTITY ( 1,1 ) ,
	secret_code         varchar(23) COLLATE Cyrillic_General_CI_AS  NOT NULL ,
)

CREATE TABLE Localizations
(
	id_localization     int IDENTITY ( 1,1 ) ,
	name                varchar(50) COLLATE Cyrillic_General_CI_AS  NOT NULL ,
	language            varchar(10) COLLATE Cyrillic_General_CI_AS  NOT NULL ,
	text                nvarchar(MAX) COLLATE Cyrillic_General_CI_AS  NOT NULL
)

CREATE TABLE Faculties
( 
	id_faculty           int IDENTITY ( 1,1 ) ,
	name                 nvarchar(100) COLLATE Cyrillic_General_CI_AS  NOT NULL ,
	abbreviation         nvarchar(10) COLLATE Cyrillic_General_CI_AS  NOT NULL 
)

CREATE TABLE Departments
( 
	id_department        int IDENTITY ( 1,1 ) ,
	name                 nvarchar(100) COLLATE Cyrillic_General_CI_AS  NOT NULL ,
	abbreviation         nvarchar(10) COLLATE Cyrillic_General_CI_AS  NOT NULL ,
	id_faculty           int  NOT NULL 
)

CREATE TABLE Students_group
( 
	id_students_group    int IDENTITY ( 1,1 ) ,
	name                 nvarchar(20) COLLATE Cyrillic_General_CI_AS  NOT NULL ,
	people_amount        int  NOT NULL ,
	id_department        int  NOT NULL 
)

CREATE TABLE Teachers
( 
	id_teacher           int IDENTITY ( 1,1 ) ,
	surname              nvarchar(20) COLLATE Cyrillic_General_CI_AS  NOT NULL ,
	name                 nvarchar(20) COLLATE Cyrillic_General_CI_AS  NOT NULL ,
	patronymic           nvarchar(20) COLLATE Cyrillic_General_CI_AS  NOT NULL ,
	working_position     nvarchar(30) COLLATE Cyrillic_General_CI_AS  NOT NULL ,
	regalia              nvarchar(20) COLLATE Cyrillic_General_CI_AS  NULL ,
	id_department        int  NOT NULL 
)

CREATE TABLE Subjects
( 
	id_subject           int IDENTITY ( 1,1 ) ,
	name                 nvarchar(50) COLLATE Cyrillic_General_CI_AS  NOT NULL ,
	type                 nvarchar(20) COLLATE Cyrillic_General_CI_AS  NOT NULL ,
	id_department        int  NOT NULL 
)

CREATE TABLE Classrooms
( 
	id_classroom         int IDENTITY ( 1,1 ) ,
	number               nvarchar(20) COLLATE Cyrillic_General_CI_AS  NOT NULL ,
	people_capacity      int  NOT NULL ,
	id_department        int  NOT NULL 
)

CREATE TABLE Students_group_load
( 
	id_students_group_load int IDENTITY ( 1,1 ) ,
	hours                int  NOT NULL ,
	id_students_group    int  NOT NULL ,
	id_subject           int  NOT NULL 
)

CREATE TABLE Teacher_load
( 
	id_teacher_load      int IDENTITY ( 1,1 ) ,
	id_teacher           int  NOT NULL ,
	id_subject           int  NOT NULL 
)

CREATE TABLE Lessons
( 
	id_lesson            int IDENTITY ( 1,1 ) ,
	week_count            int  NOT NULL ,
	lesson_count            int  NOT NULL ,
	id_students_group_load int  NOT NULL ,
	id_teacher_load      int  NOT NULL ,
	id_classroom         int  NOT NULL 
)

ALTER TABLE Faculty
	ADD CONSTRAINT XPKFaculty PRIMARY KEY  CLUSTERED (id_faculty ASC) 

ALTER TABLE Department
	ADD CONSTRAINT XPKDepartment PRIMARY KEY  CLUSTERED (id_department ASC)

ALTER TABLE Students_group
	ADD CONSTRAINT XPKStudents_group PRIMARY KEY  CLUSTERED (id_students_group ASC)

ALTER TABLE Teacher
	ADD CONSTRAINT XPKTeacher PRIMARY KEY  CLUSTERED (id_teacher ASC)

ALTER TABLE Subject
	ADD CONSTRAINT XPKSubject PRIMARY KEY  CLUSTERED (id_subject ASC)

ALTER TABLE Classroom
	ADD CONSTRAINT XPKClassroom PRIMARY KEY  CLUSTERED (id_classroom ASC)
	
ALTER TABLE Students_group_load
	ADD CONSTRAINT XPKStudents_group_load PRIMARY KEY  CLUSTERED (id_students_group_load ASC)

ALTER TABLE Teacher_load
	ADD CONSTRAINT XPKTeacher_load PRIMARY KEY  CLUSTERED (id_teacher_load ASC)

ALTER TABLE Lesson
	ADD CONSTRAINT XPKLesson PRIMARY KEY  CLUSTERED (id_lesson ASC)

ALTER TABLE Department
	ADD CONSTRAINT R_1 FOREIGN KEY (id_faculty) REFERENCES Faculty(id_faculty)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION

ALTER TABLE Students_group
	ADD CONSTRAINT R_2 FOREIGN KEY (id_department) REFERENCES Department(id_department)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION

ALTER TABLE Teacher
	ADD CONSTRAINT R_3 FOREIGN KEY (id_department) REFERENCES Department(id_department)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION

ALTER TABLE Subject
	ADD CONSTRAINT R_4 FOREIGN KEY (id_department) REFERENCES Department(id_department)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION

ALTER TABLE Classroom
	ADD CONSTRAINT R_5 FOREIGN KEY (id_department) REFERENCES Department(id_department)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION

ALTER TABLE Students_group_load
	ADD CONSTRAINT R_6 FOREIGN KEY (id_students_group) REFERENCES Students_group(id_students_group)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION

ALTER TABLE Students_group_load
	ADD CONSTRAINT R_7 FOREIGN KEY (id_subject) REFERENCES Subject(id_subject)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION

ALTER TABLE Teacher_load
	ADD CONSTRAINT R_8 FOREIGN KEY (id_teacher) REFERENCES Teacher(id_teacher)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION

ALTER TABLE Teacher_load
	ADD CONSTRAINT R_9 FOREIGN KEY (id_subject) REFERENCES Subject(id_subject)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION

ALTER TABLE Lesson
	ADD CONSTRAINT R_10 FOREIGN KEY (id_students_group_load) REFERENCES Students_group_load(id_students_group_load)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION

ALTER TABLE Lesson
	ADD CONSTRAINT R_11 FOREIGN KEY (id_teacher_load) REFERENCES Teacher_load(id_teacher_load)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION

ALTER TABLE Lesson
	ADD CONSTRAINT R_12 FOREIGN KEY (id_classroom) REFERENCES Classroom(id_classroom)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION