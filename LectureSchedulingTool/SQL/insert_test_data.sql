INSERT INTO Faculty VALUES ('Информатика и управление', 'ИФ')

INSERT INTO Department VALUES ('Программная инженерия и информационные технологии управления', 'ПИИТУ', 1, (SELECT id_faculty FROM Faculty WHERE abbreviation = 'ИФ'))