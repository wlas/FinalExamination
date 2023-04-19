# 7. В подключенном MySQL репозитории создать базу данных “Друзья человека” 

CREATE DATABASE humanFriends;
USE humanFriends;
 
 
# 8. Создать таблицы с иерархией из диаграммы в БД
 
CREATE TABLE humanFriend
(
   id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(30),
    birthday DATE,
    command VARCHAR(60),
    typeOfAnimal VARCHAR (30)
);

CREATE TABLE homeAnimal
(
   id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(30),
    birthday DATE,
    command VARCHAR(60),
    species VARCHAR (30)
);

CREATE TABLE packAnimal
(
   id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(30),
    birthday DATE,
    command VARCHAR(60),
    loadCapacity INT,
    species VARCHAR (30)
);

CREATE TABLE cat
(
   id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(30),
    birthday DATE,
    command VARCHAR(60),
    species VARCHAR (30)
);  

CREATE TABLE dog
(
   id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(30),
    birthday DATE,
    command VARCHAR(60),
    species VARCHAR (30),
    pedigree VARCHAR (50)
);  

CREATE TABLE hamster
(
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(30),
    birthday DATE,
    command VARCHAR(60),
    species VARCHAR (30)
); 
 
CREATE TABLE horse
(
   id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(30),
    birthday DATE,
    command VARCHAR(60),
    loadCapacity INT,
    species VARCHAR (30)
);

CREATE TABLE camel
(
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(30),
    birthday DATE,
    command VARCHAR(60),
    loadCapacity INT,
    numberOfHumps INT
);

CREATE TABLE donkey
(
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(30),
    birthday DATE,
    command VARCHAR(60),
    loadCapacity INT,
    species VARCHAR (30)
);


# 9. Заполнить низкоуровневые таблицы именами(животных), командами которые они выполняют и датами рождения

INSERT INTO cat (name, birthday, command, species)
VALUES
    ("Барсик", "2023-01-15", "ко мне","Мейн-кун"),
    ("Верон", "2023-02-01", "лежать","Манчкин"),
    ("Рыжик", "2023-03-10", "сидеть","Бурма"),
    ("Сметана", "2023-04-08", "лежать","Шартрез"),
    ("Тигр", "2023-02-11", "ко мне","Сфинкс");

SELECT * FROM cat;

INSERT INTO dog (name, birthday, command, species, pedigree)
VALUES
    ("Шарик", "2023-02-15", "дай лапу","Мопс", "Свидетельство E8L345"),
    ("Злой", "2023-01-01", "охранять","Овчарка", "без родословной"),
    ("Быстрий", "2023-04-10", "сидеть","Доберман", "Свидетельство  754561У"),
    ("Бим", "2023-03-08", "апорт","Алабай", "без родословной "),
    ("Мухтар", "2023-01-11", "служить","Бигль", "без родословной "),
    ("Лота", "2023-04-11", "искать","Такса", "без родословной ");

SELECT * FROM dog;

INSERT INTO hamster (name, birthday, command, species)
VALUES
   ("Хома", "2020-04-15", "кушать","Сирийский"),
    ("Пушистик", "2021-11-01", "ко мне","Китайскийн"),
    ("Круглый", "2018-05-10", "бежать","Кэмпбелла"),
    ("Тото", "2023-02-07", "лежать","Китайский");

SELECT * FROM hamster;  

INSERT INTO horse (name, birthday, command, loadCapacity, species)
VALUES
    ("Быстрый", "2020-05-16", "ап", 200,  "тяжеловоз"),
    ("Черный", "2021-12-01", "назад", 120, "Першерон"),
    ("Бунт", "2018-07-10", "на место", 130, "Рысак"),
    ("Машка", "2023-01-07", "поехали", 200, "Шайр");

SELECT * FROM horse;  

INSERT INTO camel (name, birthday, command, loadCapacity, numberOfHumps)
VALUES
    ("Горбун", "2020-06-15", "вези", 200,  1),
    ("Дружок", "2021-12-10", "стой", 220, 2),
    ("Кеша", "2018-07-07", "вези", 220, 2);

SELECT * FROM camel;  

INSERT INTO donkey (name, birthday, command, loadCapacity, species)
VALUES
   ("Алдар", "2020-01-16", "поехали", 70,  "Абиссинский"),
    ("Гопал", "2021-10-01", "стой", 90, "Алжирский"),
    ("Садко", "2018-09-05", "стой", 90, "Анатолийский"),
    ("Оссиан", "2022-12-07", "поехали", 130, "Мамонт");

SELECT * FROM donkey;  


# 10. Удалив из таблицы верблюдов, т.к. верблюдов решили перевезти в другой питомник на зимовку. 


DELETE FROM camel;
SELECT * FROM camel; 


# Объединить таблицы лошади, и ослы в одну таблицу

CREATE TABLE packAnimalNew
(
   id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(30),
    command VARCHAR(60),
    birthday DATE,
    species VARCHAR (30),
    loadCapacity INT,
    typeOfAnimal VARCHAR (30)
);

INSERT into packAnimalNew (name, birthday, command, species, loadCapacity, typeOfAnimal )
SELECT  name, 
        birthday,
        command,
        species,
        loadCapacity,
        "donkey"
FROM donkey 
UNION
SELECT  name, 
        birthday,
        command,
        species,
        loadCapacity,
        "horse"
FROM horse;

SELECT * FROM packAnimalNew;


#  11. Создать новую таблицу “молодые животные” в которую попадут все
# животные старше 1 года, но младше 3 лет и в отдельном столбце с точностью
# до месяца подсчитать возраст животных в новой таблице

CREATE TABLE youngAnimal
(
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(30),
    command VARCHAR(60),
    birthday DATE,
    species VARCHAR (30),
    typeOfAnimal VARCHAR (30),
    age INT
);

INSERT into youngAnimal (name, birthday, command, species, typeOfAnimal, age)
SELECT  name, 
        birthday,
       command,
        species,
        "cat",
        TIMESTAMPDIFF(MONTH, birthday, CURRENT_DATE) 
FROM cat
WHERE TIMESTAMPDIFF(MONTH, birthday, CURRENT_DATE)  > 12 AND TIMESTAMPDIFF(MONTH, birthday, CURRENT_DATE)  < 36
UNION
SELECT  name, 
        birthday,
        command,
        species,
        "dog",
       TIMESTAMPDIFF(MONTH, birthday, CURRENT_DATE)
FROM dog 
WHERE TIMESTAMPDIFF(MONTH, birthday, CURRENT_DATE)  > 12 AND TIMESTAMPDIFF(MONTH, birthday, CURRENT_DATE)  < 36
UNION
SELECT  name, 
        birthday,
        command,
        species,
        "hamster",
        TIMESTAMPDIFF(MONTH, birthday, CURRENT_DATE) AS age
FROM hamster 
WHERE TIMESTAMPDIFF(MONTH, birthday, CURRENT_DATE)  > 12 AND TIMESTAMPDIFF(MONTH, birthday, CURRENT_DATE)  < 36
UNION
SELECT  name, 
        birthday,
        command,
        species,
        typeOfAnimal,
        TIMESTAMPDIFF(MONTH, birthday, CURRENT_DATE) 
FROM packAnimalNew
WHERE TIMESTAMPDIFF(MONTH, birthday, CURRENT_DATE)  > 12 AND TIMESTAMPDIFF(MONTH, birthday, CURRENT_DATE)  < 36;
   
select * from youngAnimal;


# 12. Объединить все таблицы в одну, при этом сохраняя поля, указывающие на
# прошлую принадлежность к старым таблицам.

INSERT INTO humanFriend (name, Command, birthday, typeOfAnimal)
SELECT  name, 
        command,
        birthday,
        "cat" 
FROM cat
UNION 
SELECT  name, 
        command, 
        birthday,
        "dog"
FROM dog 
UNION
SELECT  name, 
        command, 
        birthday,
        "hamster" 
FROM hamster 
UNION 
SELECT  name, 
        command, 
        birthday,
        "horse" 
FROM horse
UNION 
SELECT  name, 
        command, 
        birthday,
       "donkey"
FROM donkey;

SELECT * FROM humanFriend;