SET IDENTITY_INSERT [dbo].[Classrooms] ON
GO
INSERT INTO [dbo].[Classrooms] ([id_classroom], [number], [people_capacity], [id_department]) VALUES (N'1', N'У2.719', N'20', N'1')
GO
GO
INSERT INTO [dbo].[Classrooms] ([id_classroom], [number], [people_capacity], [id_department]) VALUES (N'2', N'У2.712', N'45', N'1')
GO
GO
INSERT INTO [dbo].[Classrooms] ([id_classroom], [number], [people_capacity], [id_department]) VALUES (N'3', N'У2.617', N'60', N'1')
GO
GO
INSERT INTO [dbo].[Classrooms] ([id_classroom], [number], [people_capacity], [id_department]) VALUES (N'4', N'У2.618', N'60', N'1')
GO
GO
SET IDENTITY_INSERT [dbo].[Classrooms] OFF
GO

SET IDENTITY_INSERT [dbo].[Departments] ON
GO
INSERT INTO [dbo].[Departments] ([id_department], [name], [abbreviation], [id_faculty]) VALUES (N'1', N'Программная инженерия и информационные технологии', N'ПИИТУ', N'1')
GO
GO
INSERT INTO [dbo].[Departments] ([id_department], [name], [abbreviation], [id_faculty]) VALUES (N'2', N'Охрана труда и окружающей среды', N'ОТИОС', N'2')
GO
GO
INSERT INTO [dbo].[Departments] ([id_department], [name], [abbreviation], [id_faculty]) VALUES (N'3', N'Гуманитарных наук', N'ГН', N'3')
GO
GO
INSERT INTO [dbo].[Departments] ([id_department], [name], [abbreviation], [id_faculty]) VALUES (N'4', N'Физическое воспитание', N'ФВ', N'4')
GO
GO
SET IDENTITY_INSERT [dbo].[Departments] OFF
GO

SET IDENTITY_INSERT [dbo].[Faculties] ON
GO
INSERT INTO [dbo].[Faculties] ([id_faculty], [name], [abbreviation]) VALUES (N'1', N'Компьютерные науки', N'КН')
GO
GO
INSERT INTO [dbo].[Faculties] ([id_faculty], [name], [abbreviation]) VALUES (N'2', N'Механико-технологический', N'МТ')
GO
GO
INSERT INTO [dbo].[Faculties] ([id_faculty], [name], [abbreviation]) VALUES (N'3', N'Международного образования', N'МО')
GO
GO
INSERT INTO [dbo].[Faculties] ([id_faculty], [name], [abbreviation]) VALUES (N'4', N'Социально-гуманитарных технологий', N'СГТ')
GO
GO
SET IDENTITY_INSERT [dbo].[Faculties] OFF
GO

SET IDENTITY_INSERT [dbo].[Students_group] ON
GO
INSERT INTO [dbo].[Students_group] ([id_students_group], [name], [people_amount], [id_department]) VALUES (N'1', N'КН-33Г', N'21', N'1')
GO
GO
SET IDENTITY_INSERT [dbo].[Students_group] OFF
GO

SET IDENTITY_INSERT [dbo].[Students_group_load] ON
GO
INSERT INTO [dbo].[Students_group_load] ([id_students_group_load], [hours], [id_students_group], [id_subject]) VALUES (N'2', N'24', N'1', N'1')
GO
GO
INSERT INTO [dbo].[Students_group_load] ([id_students_group_load], [hours], [id_students_group], [id_subject]) VALUES (N'3', N'16', N'1', N'2')
GO
GO
INSERT INTO [dbo].[Students_group_load] ([id_students_group_load], [hours], [id_students_group], [id_subject]) VALUES (N'4', N'8', N'1', N'3')
GO
GO
INSERT INTO [dbo].[Students_group_load] ([id_students_group_load], [hours], [id_students_group], [id_subject]) VALUES (N'5', N'8', N'1', N'4')
GO
GO
INSERT INTO [dbo].[Students_group_load] ([id_students_group_load], [hours], [id_students_group], [id_subject]) VALUES (N'6', N'24', N'1', N'5')
GO
GO
INSERT INTO [dbo].[Students_group_load] ([id_students_group_load], [hours], [id_students_group], [id_subject]) VALUES (N'7', N'16', N'1', N'6')
GO
GO
INSERT INTO [dbo].[Students_group_load] ([id_students_group_load], [hours], [id_students_group], [id_subject]) VALUES (N'8', N'16', N'1', N'7')
GO
GO
INSERT INTO [dbo].[Students_group_load] ([id_students_group_load], [hours], [id_students_group], [id_subject]) VALUES (N'9', N'8', N'1', N'8')
GO
GO
INSERT INTO [dbo].[Students_group_load] ([id_students_group_load], [hours], [id_students_group], [id_subject]) VALUES (N'10', N'16', N'1', N'9')
GO
GO
INSERT INTO [dbo].[Students_group_load] ([id_students_group_load], [hours], [id_students_group], [id_subject]) VALUES (N'11', N'8', N'1', N'10')
GO
GO
INSERT INTO [dbo].[Students_group_load] ([id_students_group_load], [hours], [id_students_group], [id_subject]) VALUES (N'12', N'16', N'1', N'11')
GO
GO
INSERT INTO [dbo].[Students_group_load] ([id_students_group_load], [hours], [id_students_group], [id_subject]) VALUES (N'13', N'8', N'1', N'12')
GO
GO
INSERT INTO [dbo].[Students_group_load] ([id_students_group_load], [hours], [id_students_group], [id_subject]) VALUES (N'14', N'4', N'1', N'13')
GO
GO
INSERT INTO [dbo].[Students_group_load] ([id_students_group_load], [hours], [id_students_group], [id_subject]) VALUES (N'15', N'4', N'1', N'14')
GO
GO
INSERT INTO [dbo].[Students_group_load] ([id_students_group_load], [hours], [id_students_group], [id_subject]) VALUES (N'16', N'4', N'1', N'15')
GO
GO
INSERT INTO [dbo].[Students_group_load] ([id_students_group_load], [hours], [id_students_group], [id_subject]) VALUES (N'17', N'4', N'1', N'16')
GO
GO
INSERT INTO [dbo].[Students_group_load] ([id_students_group_load], [hours], [id_students_group], [id_subject]) VALUES (N'18', N'8', N'1', N'17')
GO
GO
INSERT INTO [dbo].[Students_group_load] ([id_students_group_load], [hours], [id_students_group], [id_subject]) VALUES (N'19', N'16', N'1', N'18')
GO
GO
SET IDENTITY_INSERT [dbo].[Students_group_load] OFF
GO

SET IDENTITY_INSERT [dbo].[Subjects] ON
GO
INSERT INTO [dbo].[Subjects] ([id_subject], [name], [type], [id_department]) VALUES (N'1', N'Численные методы', N'Лекция', N'1')
GO
GO
INSERT INTO [dbo].[Subjects] ([id_subject], [name], [type], [id_department]) VALUES (N'2', N'Численные методы', N'Лабораторная работа', N'1')
GO
GO
INSERT INTO [dbo].[Subjects] ([id_subject], [name], [type], [id_department]) VALUES (N'3', N'Экология', N'Лекция', N'1')
GO
GO
INSERT INTO [dbo].[Subjects] ([id_subject], [name], [type], [id_department]) VALUES (N'4', N'Экология', N'Лабораторная работа', N'1')
GO
GO
INSERT INTO [dbo].[Subjects] ([id_subject], [name], [type], [id_department]) VALUES (N'5', N'Организация компьютерных сетей', N'Лекция', N'1')
GO
GO
INSERT INTO [dbo].[Subjects] ([id_subject], [name], [type], [id_department]) VALUES (N'6', N'Организация компьютерных сетей', N'Лабораторная работа', N'1')
GO
GO
INSERT INTO [dbo].[Subjects] ([id_subject], [name], [type], [id_department]) VALUES (N'7', N'Исследование операций', N'Лекция', N'1')
GO
GO
INSERT INTO [dbo].[Subjects] ([id_subject], [name], [type], [id_department]) VALUES (N'8', N'Исследование операций', N'Лабораторная работа', N'1')
GO
GO
INSERT INTO [dbo].[Subjects] ([id_subject], [name], [type], [id_department]) VALUES (N'9', N'Менеджмент программного обеспечения', N'Лекция', N'1')
GO
GO
INSERT INTO [dbo].[Subjects] ([id_subject], [name], [type], [id_department]) VALUES (N'10', N'Менеджмент программного обеспечения', N'Практика', N'1')
GO
GO
INSERT INTO [dbo].[Subjects] ([id_subject], [name], [type], [id_department]) VALUES (N'11', N'Конструирование программного обепечения', N'Лекция', N'1')
GO
GO
INSERT INTO [dbo].[Subjects] ([id_subject], [name], [type], [id_department]) VALUES (N'12', N'Конструирование программного обепечения', N'Лабораторная работа', N'1')
GO
GO
INSERT INTO [dbo].[Subjects] ([id_subject], [name], [type], [id_department]) VALUES (N'13', N'Охрана труда', N'Лекция', N'2')
GO
GO
INSERT INTO [dbo].[Subjects] ([id_subject], [name], [type], [id_department]) VALUES (N'14', N'Охрана труда', N'Практика', N'2')
GO
GO
INSERT INTO [dbo].[Subjects] ([id_subject], [name], [type], [id_department]) VALUES (N'15', N'Безопасность жизнедеятельности', N'Лекция', N'2')
GO
GO
INSERT INTO [dbo].[Subjects] ([id_subject], [name], [type], [id_department]) VALUES (N'16', N'Безопасность жизнедеятельности', N'Практика', N'2')
GO
GO
INSERT INTO [dbo].[Subjects] ([id_subject], [name], [type], [id_department]) VALUES (N'17', N'Украинский язык', N'Практика', N'3')
GO
GO
INSERT INTO [dbo].[Subjects] ([id_subject], [name], [type], [id_department]) VALUES (N'18', N'Физическая культура', N'Практика', N'4')
GO
GO
SET IDENTITY_INSERT [dbo].[Subjects] OFF
GO

SET IDENTITY_INSERT [dbo].[Teacher_load] ON
GO
INSERT INTO [dbo].[Teacher_load] ([id_teacher_load], [id_teacher], [id_subject]) VALUES (N'1', N'2', N'1')
GO
GO
INSERT INTO [dbo].[Teacher_load] ([id_teacher_load], [id_teacher], [id_subject]) VALUES (N'2', N'2', N'2')
GO
GO
INSERT INTO [dbo].[Teacher_load] ([id_teacher_load], [id_teacher], [id_subject]) VALUES (N'3', N'4', N'2')
GO
GO
INSERT INTO [dbo].[Teacher_load] ([id_teacher_load], [id_teacher], [id_subject]) VALUES (N'4', N'5', N'7')
GO
GO
INSERT INTO [dbo].[Teacher_load] ([id_teacher_load], [id_teacher], [id_subject]) VALUES (N'5', N'5', N'8')
GO
GO
INSERT INTO [dbo].[Teacher_load] ([id_teacher_load], [id_teacher], [id_subject]) VALUES (N'6', N'5', N'9')
GO
GO
INSERT INTO [dbo].[Teacher_load] ([id_teacher_load], [id_teacher], [id_subject]) VALUES (N'7', N'5', N'10')
GO
GO
INSERT INTO [dbo].[Teacher_load] ([id_teacher_load], [id_teacher], [id_subject]) VALUES (N'8', N'8', N'11')
GO
GO
INSERT INTO [dbo].[Teacher_load] ([id_teacher_load], [id_teacher], [id_subject]) VALUES (N'9', N'8', N'12')
GO
GO
INSERT INTO [dbo].[Teacher_load] ([id_teacher_load], [id_teacher], [id_subject]) VALUES (N'10', N'6', N'12')
GO
GO
INSERT INTO [dbo].[Teacher_load] ([id_teacher_load], [id_teacher], [id_subject]) VALUES (N'11', N'13', N'12')
GO
GO
INSERT INTO [dbo].[Teacher_load] ([id_teacher_load], [id_teacher], [id_subject]) VALUES (N'12', N'12', N'12')
GO
GO
INSERT INTO [dbo].[Teacher_load] ([id_teacher_load], [id_teacher], [id_subject]) VALUES (N'13', N'11', N'3')
GO
GO
INSERT INTO [dbo].[Teacher_load] ([id_teacher_load], [id_teacher], [id_subject]) VALUES (N'14', N'11', N'4')
GO
GO
INSERT INTO [dbo].[Teacher_load] ([id_teacher_load], [id_teacher], [id_subject]) VALUES (N'15', N'9', N'13')
GO
GO
INSERT INTO [dbo].[Teacher_load] ([id_teacher_load], [id_teacher], [id_subject]) VALUES (N'16', N'10', N'14')
GO
GO
INSERT INTO [dbo].[Teacher_load] ([id_teacher_load], [id_teacher], [id_subject]) VALUES (N'17', N'9', N'15')
GO
GO
INSERT INTO [dbo].[Teacher_load] ([id_teacher_load], [id_teacher], [id_subject]) VALUES (N'18', N'10', N'16')
GO
GO
INSERT INTO [dbo].[Teacher_load] ([id_teacher_load], [id_teacher], [id_subject]) VALUES (N'19', N'14', N'17')
GO
GO
INSERT INTO [dbo].[Teacher_load] ([id_teacher_load], [id_teacher], [id_subject]) VALUES (N'20', N'15', N'18')
GO
GO
SET IDENTITY_INSERT [dbo].[Teacher_load] OFF
GO

SET IDENTITY_INSERT [dbo].[Teachers] ON
GO
INSERT INTO [dbo].[Teachers] ([id_teacher], [surname], [name], [patronymic], [working_position], [regalia], [id_department]) VALUES (N'2', N'Гужва', N'Виктор', N'Алексеевич', N'Профессор ', N'к.т.н.', N'1')
GO
GO
INSERT INTO [dbo].[Teachers] ([id_teacher], [surname], [name], [patronymic], [working_position], [regalia], [id_department]) VALUES (N'4', N'Лисицкий', N'Василий', N'Лаврентьевич', N'Доцент', N'к.т.н.', N'1')
GO
GO
INSERT INTO [dbo].[Teachers] ([id_teacher], [surname], [name], [patronymic], [working_position], [regalia], [id_department]) VALUES (N'5', N'Стратиенко', N'Наталия', N'Константиновна', N'Доцент', N'к.т.н.', N'1')
GO
GO
INSERT INTO [dbo].[Teachers] ([id_teacher], [surname], [name], [patronymic], [working_position], [regalia], [id_department]) VALUES (N'6', N'Орехов', N'Сергей', N'Валерьевич', N'Доцент', N'к.т.н.', N'1')
GO
GO
INSERT INTO [dbo].[Teachers] ([id_teacher], [surname], [name], [patronymic], [working_position], [regalia], [id_department]) VALUES (N'7', N'Воловщиков', N'Валерий', N'Юрьевич', N'Доцент', N'к.т.н.', N'1')
GO
GO
INSERT INTO [dbo].[Teachers] ([id_teacher], [surname], [name], [patronymic], [working_position], [regalia], [id_department]) VALUES (N'8', N'Двухглавов', N'Дмитрий', N'Эдуардович', N'Доцент', N'к.т.н.', N'1')
GO
GO
INSERT INTO [dbo].[Teachers] ([id_teacher], [surname], [name], [patronymic], [working_position], [regalia], [id_department]) VALUES (N'9', N'Макаренко', N'Виктория', N'Васильевна', N'Профессор', N'д.г.н.', N'2')
GO
GO
INSERT INTO [dbo].[Teachers] ([id_teacher], [surname], [name], [patronymic], [working_position], [regalia], [id_department]) VALUES (N'10', N'Евтушенко', N'Наталья', N'Сергеевна', N'Ассистент', N'к.г.н.', N'2')
GO
GO
INSERT INTO [dbo].[Teachers] ([id_teacher], [surname], [name], [patronymic], [working_position], [regalia], [id_department]) VALUES (N'11', N'Козулья', N'Татьяна', N'Владимировна', N'Профессор', N'к.т.н.', N'1')
GO
GO
INSERT INTO [dbo].[Teachers] ([id_teacher], [surname], [name], [patronymic], [working_position], [regalia], [id_department]) VALUES (N'12', N'Шевченко', N'Сергей', N'Васильевич', N'Профессор', N'д.т.н.', N'1')
GO
GO
INSERT INTO [dbo].[Teachers] ([id_teacher], [surname], [name], [patronymic], [working_position], [regalia], [id_department]) VALUES (N'13', N'Шматко', N'Александр', N'Витальевич', N'Доцент', N'к.т.н.', N'1')
GO
GO
INSERT INTO [dbo].[Teachers] ([id_teacher], [surname], [name], [patronymic], [working_position], [regalia], [id_department]) VALUES (N'14', N'Шокуров', N'Александр', N'Владимирович', N'Доцент', N'к.г.н.', N'3')
GO
GO
INSERT INTO [dbo].[Teachers] ([id_teacher], [surname], [name], [patronymic], [working_position], [regalia], [id_department]) VALUES (N'15', N'Афанасьева', N'Елена', N'Николаевна', N'Старший преподаватель', null, N'4')
GO
GO
SET IDENTITY_INSERT [dbo].[Teachers] OFF
GO