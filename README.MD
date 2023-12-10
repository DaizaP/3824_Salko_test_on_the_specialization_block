## Информация о проекте
Необходимо организовать систему учета для питомника, в котором живут
домашние и вьючные животные.

## Задание
1. Используя команду cat в терминале операционной системы Linux, создать
два файла Домашние животные (заполнив файл собаками, кошками,
хомяками) и Вьючные животными (заполнив файл Лошадьми, верблюдами и
ослы), а затем объединить их. Просмотреть содержимое созданного файла.
Переименовать файл, дав ему новое имя (Друзья человека).
```
    1  cat > Pets.txt

    2  cat > "Pack animals.txt"

    3  cat Pets.txt Pack\ animals.txt > Human\ Friends.txt

    4  cat Human\ Friends.txt 
```

2. Создать директорию, переместить файл туда.
```
    6  mkdir animals

    7  mv Human\ Friends.txt animals
```

3. Подключить дополнительный репозиторий MySQL. Установить любой пакет
из этого репозитория.
```
    9  sudo dpkg -i mysql-apt-config_0.8.28-1_all.deb

   10  sudo apt update

   12  sudo apt install mysql-server mysql-client
```


4. Установить и удалить deb-пакет с помощью dpkg.
```
   13  sudo dpkg -i zoom_amd64.deb 

   14  sudo dpkg -r zoom 
```

5. Выложить историю команд в терминале ubuntu
[Ссылка](https://github.com/DaizaP/3824_Salko_test_on_the_specialization_block/blob/57de3669d0664b2bfdabf82c9cb3e79952d092b2/Linux/Task_from_1_to_5.txt)
6. Нарисовать диаграмму, в которой есть класс родительский класс, домашние
животные и вьючные животные, в составы которых в случае домашних
животных войдут классы: собаки, кошки, хомяки, а в класс вьючные животные
войдут: Лошади, верблюды и ослы.
[Ссылка](https://github.com/DaizaP/3824_Salko_test_on_the_specialization_block/blob/57de3669d0664b2bfdabf82c9cb3e79952d092b2/OOP/Diagram/ClassDiagramPet.png)


7. В подключенном MySQL репозитории создать базу данных “Друзья
человека”
```sql
DROP DATABASE IF EXISTS HumanFriends;
CREATE DATABASE HumanFriends;
USE HumanFriends;
```

8. Создать таблицы с иерархией из диаграммы в БД
```sql
DROP TABLE IF EXISTS Animals;
CREATE TABLE Animals (
	id INT AUTO_INCREMENT PRIMARY KEY,
    AnimalClass VARCHAR(50)
);

DROP TABLE IF EXISTS Pets;
CREATE TABLE Pets (
	id INT AUTO_INCREMENT PRIMARY KEY,
    AnimalType VARCHAR(50),
    AnimalClassId INT,
    FOREIGN KEY (AnimalClassId) REFERENCES Animals (id) ON DELETE CASCADE ON UPDATE CASCADE
);

DROP TABLE IF EXISTS PackAnimals;
CREATE TABLE PackAnimals (
	id INT AUTO_INCREMENT PRIMARY KEY,
    AnimalType VARCHAR(50),
    AnimalClassId INT,
    FOREIGN KEY (AnimalClassId) REFERENCES Animals (id) ON DELETE CASCADE ON UPDATE CASCADE
);

DROP TABLE IF EXISTS Dog;
CREATE TABLE Dog (
	id INT AUTO_INCREMENT PRIMARY KEY,
    UUID VARCHAR(50),
    Name VARCHAR(50),
    BirthDate date UNIQUE,
    Commands VARCHAR(120),
    AnimalTypeId INT,
    FOREIGN KEY (AnimalTypeId) REFERENCES Pets (id) ON DELETE CASCADE ON UPDATE CASCADE
);

DROP TABLE IF EXISTS Cat;
CREATE TABLE Cat (
	id INT AUTO_INCREMENT PRIMARY KEY,
    UUID VARCHAR(50),
    Name VARCHAR(50),
    BirthDate date UNIQUE,
    Commands VARCHAR(120),
    AnimalTypeId INT,
    FOREIGN KEY (AnimalTypeId) REFERENCES Pets (id) ON DELETE CASCADE ON UPDATE CASCADE
);

DROP TABLE IF EXISTS Hamster;
CREATE TABLE Hamster (
	id INT AUTO_INCREMENT PRIMARY KEY,
    UUID VARCHAR(50),
    Name VARCHAR(50),
    BirthDate date UNIQUE,
    Commands VARCHAR(120),
    AnimalTypeId INT,
    FOREIGN KEY (AnimalTypeId) REFERENCES Pets (id) ON DELETE CASCADE ON UPDATE CASCADE
);

DROP TABLE IF EXISTS Horse;
CREATE TABLE Horse (
	id INT AUTO_INCREMENT PRIMARY KEY,
    UUID VARCHAR(50),
    Name VARCHAR(50),
    BirthDate date UNIQUE,
    Commands VARCHAR(120),
    AnimalTypeId INT,
    FOREIGN KEY (AnimalTypeId) REFERENCES PackAnimals (id) ON DELETE CASCADE ON UPDATE CASCADE
);

DROP TABLE IF EXISTS Camel;
CREATE TABLE Camel (
	id INT AUTO_INCREMENT PRIMARY KEY,
    UUID VARCHAR(50),
    Name VARCHAR(50),
    BirthDate date UNIQUE,
    Commands VARCHAR(120),
    AnimalTypeId INT,
    FOREIGN KEY (AnimalTypeId) REFERENCES PackAnimals (id) ON DELETE CASCADE ON UPDATE CASCADE
);

DROP TABLE IF EXISTS Donkey;
CREATE TABLE Donkey (
	id INT AUTO_INCREMENT PRIMARY KEY,
    UUID VARCHAR(50),
    Name VARCHAR(50),
    BirthDate date UNIQUE,
    Commands VARCHAR(120),
    AnimalTypeId INT,
    FOREIGN KEY (AnimalTypeId) REFERENCES PackAnimals (id) ON DELETE CASCADE ON UPDATE CASCADE
);
```
9. Заполнить низкоуровневые таблицы именами(животных), командами
которые они выполняют и датами рождения
```sql
INSERT INTO Animals (id, AnimalClass) VALUES 
(1, 'Pets'),
(2, 'PackAnimal');

INSERT INTO Pets (id, AnimalType, AnimalClassId) VALUES 
(1, 'Dog', 1),
(2, 'Cat', 1),
(3, 'Hamster', 1);

INSERT INTO PackAnimals (id, AnimalType, AnimalClassId) VALUES 
(1, 'Horse', 2),
(2, 'Camel', 2),
(3, 'Donkey', 2);

INSERT INTO Dog (id, UUID, Name, BirthDate, Commands, AnimalTypeId) VALUES 
(1, UUID(), 'Reuben', '2020-01-01', 'Sit, Stay, Fetch', 1),
(2, UUID(), 'Norene', '2018-12-10', 'Sit, Paw, Bark', 1),
(3, UUID(), 'Austyn', '2019-11-11', 'Sit, Stay, Roll', 1),
(4, UUID(),'Jordyn', '2020-08-15', 'Sit, Pounce', 1);

INSERT INTO Cat (id, UUID, Name, BirthDate, Commands, AnimalTypeId) VALUES 
(1, UUID(), 'Frederik', '2019-05-15', 'Sit, Pounce', 2),
(2, UUID(), 'Frederick', '2020-02-20', 'Sit, Pounce, Scratch', 2),
(3, UUID(), 'Jaida', '2020-06-30','Meow, Scratch, Jump', 2);

INSERT INTO Hamster (id, UUID, Name, BirthDate, Commands, AnimalTypeId) VALUES 
(1, UUID(), 'Unique', '2021-03-10', 'Roll, Hide', 3),
(2, UUID(), 'Victoria', '2021-08-01', 'Roll, Spin', 3),
(3, UUID(), 'Mireya', '2022-05-23', 'Sit, Stay, Fetch', 3);

INSERT INTO Horse (id, UUID, Name, BirthDate, Commands, AnimalTypeId) VALUES 
(1, UUID(), 'Thunder', '2020-02-02', 'Trot, Canter, Gallop', 1),
(2, UUID(), 'Storm', '2019-11-09', 'Trot, Canter', 1),
(3, UUID(), 'Blaze', '2018-10-11', 'Trot, Jump, Gallop', 1),
(4, UUID(), 'White', '2021-09-15', 'Trot, Canter', 1);

INSERT INTO Camel (id, UUID, Name, BirthDate, Commands, AnimalTypeId) VALUES 
(1, UUID(), 'Sandy', '2019-12-15', 'Walk, Carry Load', 2),
(2, UUID(), 'Dune', '2021-03-22', 'Walk, Sit', 2),
(3, UUID(), 'Sahara', '2029-08-30', 'Walk, Run', 2);

INSERT INTO Donkey (id, UUID, Name, BirthDate, Commands, AnimalTypeId) VALUES 
(1, UUID(), 'Eeyore', '2021-04-11', 'Walk, Carry Load, Bray', 3),
(2, UUID(), 'Burro', '2020-09-02', 'Walk, Bray, Kick', 3),
(3, UUID(), 'Mariya', '2021-04-24', 'Walk, Carry Load, Bray', 3);
```

10. Удалив из таблицы верблюдов, т.к. верблюдов решили перевезти в другой
питомник на зимовку. Объединить таблицы лошади, и ослы в одну таблицу.
```sql
SET SQL_SAFE_UPDATES = 0;
DELETE FROM Camel;
SELECT * FROM Horse 
UNION SELECT * FROM Donkey;
```

11. Создать новую таблицу “молодые животные” в которую попадут все
животные старше 1 года, но младше 3 лет и в отдельном столбце с точностью
до месяца подсчитать возраст животных в новой таблице
```sql
DROP TABLE IF EXISTS TmpAnimals;
CREATE TEMPORARY TABLE TmpAnimals AS
SELECT *, 'Dog' AS TypeAnimals FROM Dog
UNION SELECT *, 'Cat' AS TypeAnimals FROM Cat
UNION SELECT *, 'Hamster' AS TypeAnimals FROM Hamster
UNION SELECT *, 'Horse' AS TypeAnimals FROM Horse
UNION SELECT *, 'Camel' AS TypeAnimals FROM Camel -- тут пусто, но в запросе оставлю. Вдруг верблюды вернутся :)
UNION SELECT *, 'Donkey' AS TypeAnimals FROM Donkey;

DROP TABLE IF EXISTS YoungAnimals;
CREATE TABLE YoungAnimals AS
SELECT id, UUID, Name, BirthDate, Commands, TypeAnimals, 
CONCAT(CAST(TIMESTAMPDIFF(YEAR, BirthDate, NOW()) AS CHAR), 'г.', CAST(MOD(TIMESTAMPDIFF(MONTH, BirthDate, NOW()), 12) AS CHAR), 'м.') AS AgeOld
FROM TmpAnimals
WHERE BirthDate BETWEEN ADDDATE(CURDATE(), INTERVAL -3 YEAR) AND ADDDATE(CURDATE(), INTERVAL -1 YEAR);

DROP TABLE IF EXISTS TmpAnimals;

SELECT * FROM YoungAnimals;
```
12. Объединить все таблицы в одну, при этом сохраняя поля, указывающие на
прошлую принадлежность к старым таблицам.
```sql
SELECT d.id, d.UUID, d.Name, d.BirthDate, d.Commands, d.AnimalTypeId, p.AnimalType, p.AnimalClassId, am.AnimalClass, ya.AgeOld FROM Dog d
LEFT JOIN YoungAnimals ya ON ya.UUID = d.UUID
LEFT JOIN Pets p ON p.id = d.AnimalTypeId
LEFT JOIN Animals am ON am.id = p.AnimalClassId
--
UNION SELECT c.id, c.UUID, c.Name, c.BirthDate, c.Commands, c.AnimalTypeId, p.AnimalType, p.AnimalClassId, am.AnimalClass, ya.AgeOld FROM Cat c
LEFT JOIN YoungAnimals ya ON ya.UUID = c.UUID
LEFT JOIN Pets p ON p.id = c.AnimalTypeId
LEFT JOIN Animals am ON am.id = p.AnimalClassId 
--
UNION SELECT hm.id, hm.UUID, hm.Name, hm.BirthDate, hm.Commands, hm.AnimalTypeId, p.AnimalType, p.AnimalClassId, am.AnimalClass, ya.AgeOld FROM Hamster hm
LEFT JOIN YoungAnimals ya ON ya.UUID = hm.UUID
LEFT JOIN Pets p ON p.id = hm.AnimalTypeId
LEFT JOIN Animals am ON am.id = p.AnimalClassId
--
UNION SELECT hr.id, hr.UUID, hr.Name, hr.BirthDate, hr.Commands, hr.AnimalTypeId, pa.AnimalType, pa.AnimalClassId, am.AnimalClass, ya.AgeOld FROM Horse hr
LEFT JOIN YoungAnimals ya ON ya.UUID = hr.UUID
LEFT JOIN PackAnimals pa ON pa.id = hr.AnimalTypeId
LEFT JOIN Animals am ON am.id = pa.AnimalClassId
--
UNION SELECT cm.id, cm.UUID, cm.Name, cm.BirthDate, cm.Commands, cm.AnimalTypeId, pa.AnimalType, pa.AnimalClassId, am.AnimalClass, ya.AgeOld FROM Camel cm-- тут пусто, но в запросе оставлю. Вдруг верблюды вернутся 
LEFT JOIN YoungAnimals ya ON ya.UUID = cm.UUID
LEFT JOIN PackAnimals pa ON pa.id = cm.AnimalTypeId
LEFT JOIN Animals am ON am.id = pa.AnimalClassId
--
UNION SELECT dn.id, dn.UUID, dn.Name, dn.BirthDate, dn.Commands, dn.AnimalTypeId, pa.AnimalType, pa.AnimalClassId, am.AnimalClass, ya.AgeOld FROM Donkey dn
LEFT JOIN YoungAnimals ya ON ya.UUID = dn.UUID
LEFT JOIN PackAnimals pa ON pa.id = dn.AnimalTypeId
LEFT JOIN Animals am ON am.id = pa.AnimalClassId;
```

13. Создать класс с Инкапсуляцией методов и наследованием по диаграмме.

[Ссылка](https://github.com/DaizaP/3824_Salko_test_on_the_specialization_block/tree/57de3669d0664b2bfdabf82c9cb3e79952d092b2/OOP/Pet/Model)
14. Написать программу, имитирующую работу реестра домашних животных.
В программе должен быть реализован следующий функционал:    
	14.1 Завести новое животное    
	14.2 определять животное в правильный класс    
	14.3 увидеть список команд, которое выполняет животное    
	14.4 обучить животное новым командам    
	14.5 Реализовать навигацию по меню 

[Ссылка](https://github.com/DaizaP/3824_Salko_test_on_the_specialization_block/tree/57de3669d0664b2bfdabf82c9cb3e79952d092b2/OOP/Pet) 
15. Создайте класс Счетчик, у которого есть метод add(), увеличивающий̆
значение внутренней̆ int переменной̆ на 1 при нажатии “Завести новое
животное” Сделайте так, чтобы с объектом такого типа можно было работать в
блоке try-with-resources. Нужно бросить исключение, если работа с объектом
типа счетчик была не в ресурсном try и/или ресурс остался открыт. Значение
считать в ресурсе try, если при заведении животного заполнены все поля.

[Ссылка](https://github.com/DaizaP/3824_Salko_test_on_the_specialization_block/blob/57de3669d0664b2bfdabf82c9cb3e79952d092b2/OOP/Pet/Model/Counter.cs)