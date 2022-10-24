-- DROP TABLE Werknemers;
-- DROP TABLE Bedrijven;
-- DROP TABLE Afspraken;

CREATE TABLE Bedrijven (
    BedrijfId int IDENTITY,
    Naam varchar(255),
    BTW varchar(255),
    Email varchar(255),
    Adres varchar(255),
    Telefoon varchar(255),
    PRIMARY KEY (BedrijfId),
);

CREATE TABLE Werknemers (
    WerknemerId int IDENTITY,
    Voornaam varchar(255),
    Achternaam varchar(255),
    Email varchar(255),
    Functie varchar(255),
    BedrijfId int,
    PRIMARY KEY (WerknemerId),
    FOREIGN KEY (BedrijfId) REFERENCES Bedrijven(BedrijfId)
);



CREATE TABLE Afspraken (
    AfspraakId int IDENTITY,
    VoornaamBezoeker varchar(255),
    AchternaamBezoeker varchar(255),
    Email varchar(255),
    StartTijd Datetime,
    EindTijd Datetime,
    BedrijfId int,
    WerknemerId int,
    PRIMARY KEY (WerknemerId),
    FOREIGN KEY (BedrijfId) REFERENCES Bedrijven(BedrijfId),
    FOREIGN KEY (WerknemerId) REFERENCES Werknemers(WerknemerId)
);


INSERT INTO Bedrijven (Naam, BTW, Email, Adres, Telefoon) VALUES ('1', '87-076-9983', 'cwycliff0@creativecommons.org', '4 Charing Cross Place', '112-968-1694');
INSERT INTO Bedrijven (Naam, BTW, Email, Adres, Telefoon) VALUES ('2', '11-600-7808', 'gfivey1@youku.com', '92 Hallows Trail', '993-390-0114');
INSERT INTO Bedrijven (Naam, BTW, Email, Adres, Telefoon) VALUES ('3', '29-883-0208', 'jthornton2@miitbeian.gov.cn', '535 Merrick Plaza', '428-430-2592');
INSERT INTO Bedrijven (Naam, BTW, Email, Adres, Telefoon) VALUES ('4', '15-760-6867', 'powain3@theguardian.com', '53002 Anzinger Way', '905-315-4223');
INSERT INTO Bedrijven (Naam, BTW, Email, Adres, Telefoon) VALUES ('5', '03-009-2880', 'rochterlony4@opensource.org', '94734 Tomscot Hill', '499-799-8648');
INSERT INTO Bedrijven (Naam, BTW, Email, Adres, Telefoon) VALUES ('6', '76-206-8779', 'lgiorgini5@prlog.org', '73 Monument Park', '664-724-1506');
INSERT INTO Bedrijven (Naam, BTW, Email, Adres, Telefoon) VALUES ('7', '29-471-9174', 'abazire6@cyberchimps.com', '87643 Leroy Terrace', '308-981-6230');
INSERT INTO Bedrijven (Naam, BTW, Email, Adres, Telefoon) VALUES ('8', '22-059-4053', 'kbrendel7@mediafire.com', '72 Crescent Oaks Avenue', '982-785-2997');
INSERT INTO Bedrijven (Naam, BTW, Email, Adres, Telefoon) VALUES ('9', '10-668-8679', 'kattride8@dell.com', '26 Carey Road', '945-767-4057');
INSERT INTO Bedrijven (Naam, BTW, Email, Adres, Telefoon) VALUES ('10', '62-271-4783', 'hglidder9@chronoengine.com', '09 Golf View Plaza', '159-650-0462');


INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Donald', 'OConnell', 'DOCONNEL', 'SH_CLERK', '7');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Douglas', 'Grant', 'DGRANT', 'SH_CLERK', '10');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Jennifer', 'Whalen', 'JWHALEN', 'AD_ASST', '4');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Michael', 'Hartstein', 'MHARTSTE', 'MK_MAN', '5');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Pat', 'Fay', 'PFAY', 'MK_REP', '8');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Susan', 'Mavris', 'SMAVRIS', 'HR_REP', '1');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Hermann', 'Baer', 'HBAER', 'PR_REP', '9');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Shelley', 'Higgins', 'SHIGGINS', 'AC_MGR', '4');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('William', 'Gietz', 'WGIETZ', 'AC_ACCOUNT', '10');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Steven', 'King', 'SKING', 'AD_PRES', '10');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Neena', 'Kochhar', 'NKOCHHAR', 'AD_VP', '4');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Lex', 'De Haan', 'LDEHAAN', 'AD_VP', '5');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Alexander', 'Hunold', 'AHUNOLD', 'IT_PROG', '4');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Bruce', 'Ernst', 'BERNST', 'IT_PROG', '10');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('David', 'Austin', 'DAUSTIN', 'IT_PROG', '7');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Valli', 'Pataballa', 'VPATABAL', 'IT_PROG', '1');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Diana', 'Lorentz', 'DLORENTZ', 'IT_PROG', '5');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Nancy', 'Greenberg', 'NGREENBE', 'FI_MGR', '5');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Daniel', 'Faviet', 'DFAVIET', 'FI_ACCOUNT', '7');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('John', 'Chen', 'JCHEN', 'FI_ACCOUNT', '7');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Ismael', 'Sciarra', 'ISCIARRA', 'FI_ACCOUNT', '6');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Jose Manuel', 'Urman', 'JMURMAN', 'FI_ACCOUNT', '5');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Luis', 'Popp', 'LPOPP', 'FI_ACCOUNT', '1');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Den', 'Raphaely', 'DRAPHEAL', 'PU_MAN', '7');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Alexander', 'Khoo', 'AKHOO', 'PU_CLERK', '8');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Shelli', 'Baida', 'SBAIDA', 'PU_CLERK', '6');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Sigal', 'Tobias', 'STOBIAS', 'PU_CLERK', '6');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Guy', 'Himuro', 'GHIMURO', 'PU_CLERK', '4');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Karen', 'Colmenares', 'KCOLMENA', 'PU_CLERK', '9');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Matthew', 'Weiss', 'MWEISS', 'ST_MAN', '5');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Adam', 'Fripp', 'AFRIPP', 'ST_MAN', '3');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Payam', 'Kaufling', 'PKAUFLIN', 'ST_MAN', '7');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Shanta', 'Vollman', 'SVOLLMAN', 'ST_MAN', '5');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Kevin', 'Mourgos', 'KMOURGOS', 'ST_MAN', '4');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Julia', 'Nayer', 'JNAYER', 'ST_CLERK', '7');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Irene', 'Mikkilineni', 'IMIKKILI', 'ST_CLERK', '6');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('James', 'Landry', 'JLANDRY', 'ST_CLERK', '9');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Steven', 'Markle', 'SMARKLE', 'ST_CLERK', '10');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Laura', 'Bissot', 'LBISSOT', 'ST_CLERK', '9');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Mozhe', 'Atkinson', 'MATKINSO', 'ST_CLERK', '4');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('James', 'Marlow', 'JAMRLOW', 'ST_CLERK', '6');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('TJ', 'Olson', 'TJOLSON', 'ST_CLERK', '5');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Jason', 'Mallin', 'JMALLIN', 'ST_CLERK', '8');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Michael', 'Rogers', 'MROGERS', 'ST_CLERK', '10');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Ki', 'Gee', 'KGEE', 'ST_CLERK', '2');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Hazel', 'Philtanker', 'HPHILTAN', 'ST_CLERK', '6');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Renske', 'Ladwig', 'RLADWIG', 'ST_CLERK', '7');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Stephen', 'Stiles', 'SSTILES', 'ST_CLERK', '9');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('John', 'Seo', 'JSEO', 'ST_CLERK', '6');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Joshua', 'Patel', 'JPATEL', 'ST_CLERK', '8');


INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Neena', 'Neena', 'NKOCHHAR', '2023-07-01 14:17:00', '2023-07-01 12:36:00', '4', '11');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Hermann', 'Hermann', 'HBAER', '2023-07-02 08:04:00', '2023-07-02 09:21:00', '9', '7');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Steven', 'Steven', 'SKING', '2023-05-09 13:40:00', '2023-05-09 16:47:00', '10', '10');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Hermann', 'Hermann', 'HBAER', '2023-02-20 12:34:00', '2023-02-20 12:58:00', '9', '7');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Steven', 'Steven', 'SKING', '2023-10-09 16:22:00', '2023-10-09 08:48:00', '10', '10');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Pat', 'Pat', 'PFAY', '2023-06-12 15:39:00', '2023-06-12 13:33:00', '8', '5');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Steven', 'Steven', 'SKING', '2023-05-25 08:05:00', '2023-05-25 15:09:00', '10', '10');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Pat', 'Pat', 'PFAY', '2023-02-02 16:12:00', '2023-02-02 16:26:00', '8', '5');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Pat', 'Pat', 'PFAY', '2023-07-06 14:19:00', '2023-07-06 11:48:00', '8', '5');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Michael', 'Michael', 'MHARTSTE', '2023-04-25 13:45:00', '2023-04-25 15:22:00', '5', '4');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Douglas', 'Douglas', 'DGRANT', '2023-10-15 12:00:00', '2023-10-15 15:22:00', '10', '2');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('William', 'William', 'WGIETZ', '2023-10-12 12:34:00', '2023-10-12 10:15:00', '10', '9');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Donald', 'Donald', 'DOCONNEL', '2023-05-14 11:50:00', '2023-05-14 08:44:00', '7', '1');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Douglas', 'Douglas', 'DGRANT', '2023-07-02 15:18:00', '2023-07-02 16:35:00', '10', '2');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Michael', 'Michael', 'MHARTSTE', '2023-01-13 16:46:00', '2023-01-13 08:31:00', '5', '4');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Michael', 'Michael', 'MHARTSTE', '2023-01-18 13:12:00', '2023-01-18 12:32:00', '5', '4');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Steven', 'Steven', 'SKING', '2023-09-01 09:37:00', '2023-09-01 12:52:00', '10', '10');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Neena', 'Neena', 'NKOCHHAR', '2023-10-24 13:48:00', '2023-10-24 16:48:00', '4', '11');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Shelley', 'Shelley', 'SHIGGINS', '2023-02-07 11:16:00', '2023-02-07 11:33:00', '4', '8');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Shelley', 'Shelley', 'SHIGGINS', '2023-10-11 15:18:00', '2023-10-11 11:36:00', '4', '8');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Steven', 'Steven', 'SKING', '2023-10-21 08:41:00', '2023-10-21 15:25:00', '10', '10');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Steven', 'Steven', 'SKING', '2023-01-14 09:58:00', '2023-01-14 16:25:00', '10', '10');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Steven', 'Steven', 'SKING', '2023-09-07 14:39:00', '2023-09-07 15:12:00', '10', '10');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Jennifer', 'Jennifer', 'JWHALEN', '2023-06-20 15:50:00', '2023-06-20 12:54:00', '4', '3');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Douglas', 'Douglas', 'DGRANT', '2023-06-23 12:45:00', '2023-06-23 14:34:00', '10', '2');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Douglas', 'Douglas', 'DGRANT', '2023-04-02 11:23:00', '2023-04-02 10:29:00', '10', '2');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Jennifer', 'Jennifer', 'JWHALEN', '2023-10-01 09:05:00', '2023-10-01 13:14:00', '4', '3');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Pat', 'Pat', 'PFAY', '2023-06-06 08:14:00', '2023-06-06 13:36:00', '8', '5');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Neena', 'Neena', 'NKOCHHAR', '2023-05-02 08:26:00', '2023-05-02 12:49:00', '4', '11');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Steven', 'Steven', 'SKING', '2023-08-13 08:59:00', '2023-08-13 14:08:00', '10', '10');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Jennifer', 'Jennifer', 'JWHALEN', '2023-11-13 13:25:00', '2023-11-13 16:46:00', '4', '3');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Steven', 'Steven', 'SKING', '2023-07-01 10:54:00', '2023-07-01 14:31:00', '10', '10');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('William', 'William', 'WGIETZ', '2023-02-12 08:32:00', '2023-02-12 14:27:00', '10', '9');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Neena', 'Neena', 'NKOCHHAR', '2023-09-20 08:05:00', '2023-09-20 12:59:00', '4', '11');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Shelley', 'Shelley', 'SHIGGINS', '2023-02-05 16:02:00', '2023-02-05 09:53:00', '4', '8');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Donald', 'Donald', 'DOCONNEL', '2023-10-15 09:42:00', '2023-10-15 10:57:00', '7', '1');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Hermann', 'Hermann', 'HBAER', '2023-10-04 12:35:00', '2023-10-04 13:56:00', '9', '7');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('William', 'William', 'WGIETZ', '2023-09-08 13:52:00', '2023-09-08 12:40:00', '10', '9');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Neena', 'Neena', 'NKOCHHAR', '2023-04-24 11:07:00', '2023-04-24 10:24:00', '4', '11');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Michael', 'Michael', 'MHARTSTE', '2023-05-24 11:52:00', '2023-05-24 13:28:00', '5', '4');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Donald', 'Donald', 'DOCONNEL', '2023-06-05 09:39:00', '2023-06-05 10:18:00', '7', '1');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Douglas', 'Douglas', 'DGRANT', '2023-06-17 11:22:00', '2023-06-17 16:48:00', '10', '2');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Donald', 'Donald', 'DOCONNEL', '2023-03-09 13:51:00', '2023-03-09 11:54:00', '7', '1');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Neena', 'Neena', 'NKOCHHAR', '2023-04-21 09:50:00', '2023-04-21 13:09:00', '4', '11');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Shelley', 'Shelley', 'SHIGGINS', '2023-11-13 11:44:00', '2023-11-13 16:36:00', '4', '8');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Susan', 'Susan', 'SMAVRIS', '2023-07-06 13:05:00', '2023-07-06 16:05:00', '1', '6');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Jennifer', 'Jennifer', 'JWHALEN', '2023-10-04 13:35:00', '2023-10-04 16:40:00', '4', '3');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Hermann', 'Hermann', 'HBAER', '2023-02-18 11:10:00', '2023-02-18 13:47:00', '9', '7');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Jennifer', 'Jennifer', 'JWHALEN', '2023-07-22 15:46:00', '2023-07-22 11:42:00', '4', '3');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Hermann', 'Hermann', 'HBAER', '2023-03-10 08:27:00', '2023-03-10 13:12:00', '9', '7');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Steven', 'Steven', 'SKING', '2023-11-13 12:48:00', '2023-11-13 14:09:00', '10', '10');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Shelley', 'Shelley', 'SHIGGINS', '2023-06-21 12:41:00', '2023-06-21 09:03:00', '4', '8');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Steven', 'Steven', 'SKING', '2023-05-04 13:50:00', '2023-05-04 10:50:00', '10', '10');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Shelley', 'Shelley', 'SHIGGINS', '2023-11-04 09:10:00', '2023-11-04 09:03:00', '4', '8');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Steven', 'Steven', 'SKING', '2023-05-25 10:56:00', '2023-05-25 08:00:00', '10', '10');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Pat', 'Pat', 'PFAY', '2023-07-09 11:13:00', '2023-07-09 08:28:00', '8', '5');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Michael', 'Michael', 'MHARTSTE', '2023-08-22 16:19:00', '2023-08-22 08:12:00', '5', '4');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Douglas', 'Douglas', 'DGRANT', '2023-11-16 10:08:00', '2023-11-16 11:26:00', '10', '2');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Pat', 'Pat', 'PFAY', '2023-02-03 16:08:00', '2023-02-03 08:12:00', '8', '5');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Pat', 'Pat', 'PFAY', '2023-03-11 14:25:00', '2023-03-11 16:49:00', '8', '5');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Steven', 'Steven', 'SKING', '2023-05-21 11:18:00', '2023-05-21 08:06:00', '10', '10');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Neena', 'Neena', 'NKOCHHAR', '2023-11-07 15:22:00', '2023-11-07 09:38:00', '4', '11');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Hermann', 'Hermann', 'HBAER', '2023-03-15 08:02:00', '2023-03-15 14:54:00', '9', '7');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Donald', 'Donald', 'DOCONNEL', '2023-09-25 08:05:00', '2023-09-25 12:49:00', '7', '1');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Donald', 'Donald', 'DOCONNEL', '2023-10-01 12:00:00', '2023-10-01 11:55:00', '7', '1');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('William', 'William', 'WGIETZ', '2023-05-21 08:44:00', '2023-05-21 11:07:00', '10', '9');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Douglas', 'Douglas', 'DGRANT', '2023-06-22 10:34:00', '2023-06-22 14:30:00', '10', '2');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Michael', 'Michael', 'MHARTSTE', '2023-06-06 15:55:00', '2023-06-06 15:28:00', '5', '4');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Steven', 'Steven', 'SKING', '2023-10-06 10:08:00', '2023-10-06 14:46:00', '10', '10');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Hermann', 'Hermann', 'HBAER', '2023-07-02 14:17:00', '2023-07-02 08:16:00', '9', '7');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Neena', 'Neena', 'NKOCHHAR', '2023-02-09 13:10:00', '2023-02-09 10:11:00', '4', '11');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Douglas', 'Douglas', 'DGRANT', '2023-01-12 15:14:00', '2023-01-12 14:29:00', '10', '2');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Pat', 'Pat', 'PFAY', '2023-01-13 08:09:00', '2023-01-13 13:17:00', '8', '5');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Donald', 'Donald', 'DOCONNEL', '2023-07-21 12:39:00', '2023-07-21 12:00:00', '7', '1');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Neena', 'Neena', 'NKOCHHAR', '2023-02-01 11:36:00', '2023-02-01 09:41:00', '4', '11');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Shelley', 'Shelley', 'SHIGGINS', '2023-05-15 08:56:00', '2023-05-15 12:51:00', '4', '8');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Donald', 'Donald', 'DOCONNEL', '2023-01-08 15:51:00', '2023-01-08 09:57:00', '7', '1');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Hermann', 'Hermann', 'HBAER', '2023-01-12 10:42:00', '2023-01-12 09:32:00', '9', '7');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Steven', 'Steven', 'SKING', '2023-04-06 14:35:00', '2023-04-06 16:11:00', '10', '10');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Pat', 'Pat', 'PFAY', '2023-06-04 14:39:00', '2023-06-04 08:53:00', '8', '5');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Jennifer', 'Jennifer', 'JWHALEN', '2023-05-13 16:15:00', '2023-05-13 08:30:00', '4', '3');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Douglas', 'Douglas', 'DGRANT', '2023-04-14 12:01:00', '2023-04-14 09:54:00', '10', '2');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Shelley', 'Shelley', 'SHIGGINS', '2023-03-09 12:21:00', '2023-03-09 11:04:00', '4', '8');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Pat', 'Pat', 'PFAY', '2023-02-09 08:01:00', '2023-02-09 15:56:00', '8', '5');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Douglas', 'Douglas', 'DGRANT', '2023-04-01 15:02:00', '2023-04-01 08:48:00', '10', '2');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Hermann', 'Hermann', 'HBAER', '2023-10-12 14:53:00', '2023-10-12 13:51:00', '9', '7');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Douglas', 'Douglas', 'DGRANT', '2023-02-17 15:05:00', '2023-02-17 08:46:00', '10', '2');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Donald', 'Donald', 'DOCONNEL', '2023-10-10 09:01:00', '2023-10-10 15:55:00', '7', '1');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Jennifer', 'Jennifer', 'JWHALEN', '2023-01-18 13:33:00', '2023-01-18 09:58:00', '4', '3');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Susan', 'Susan', 'SMAVRIS', '2023-05-02 08:19:00', '2023-05-02 12:07:00', '1', '6');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('William', 'William', 'WGIETZ', '2023-08-17 13:36:00', '2023-08-17 11:29:00', '10', '9');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Shelley', 'Shelley', 'SHIGGINS', '2023-07-07 11:25:00', '2023-07-07 08:27:00', '4', '8');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Pat', 'Pat', 'PFAY', '2023-06-19 09:00:00', '2023-06-19 13:50:00', '8', '5');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Jennifer', 'Jennifer', 'JWHALEN', '2023-01-17 11:09:00', '2023-01-17 12:48:00', '4', '3');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Shelley', 'Shelley', 'SHIGGINS', '2023-07-06 14:35:00', '2023-07-06 13:54:00', '4', '8');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Pat', 'Pat', 'PFAY', '2023-02-07 15:07:00', '2023-02-07 14:46:00', '8', '5');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('William', 'William', 'WGIETZ', '2023-07-25 16:38:00', '2023-07-25 16:14:00', '10', '9');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Michael', 'Michael', 'MHARTSTE', '2023-08-11 13:48:00', '2023-08-11 09:07:00', '5', '4');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Shelley', 'Shelley', 'SHIGGINS', '2023-07-16 10:43:00', '2023-07-16 15:32:00', '4', '8');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, Email, StartTijd, EindTijd, BedrijfId, WerknemerId ) VALUES ('Donald', 'Donald', 'DOCONNEL', '2023-03-07 14:44:00', '2023-03-07 11:53:00', '7', '1');
