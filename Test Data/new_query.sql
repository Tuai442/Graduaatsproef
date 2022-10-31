DROP TABLE Afspraken;
DROP TABLE Werknemers;
DROP TABLE Bedrijven;

CREATE TABLE Bedrijven (
    BedrijfId int IDENTITY,
    Naam varchar(255) not null,
    BTW varchar(255) not null,
    Email varchar(255) not null,
    Adres varchar(255) not null,
    Telefoon varchar(255) not null,
    PRIMARY KEY (BedrijfId),
);

CREATE TABLE Werknemers (
    WerknemerId int IDENTITY,
    Voornaam varchar(255)  not null,
    Achternaam varchar(255) not null,
    Email varchar(255) not null,
    Functie varchar(255) not null,
    BedrijfId int,
    PRIMARY KEY (WerknemerId),
    FOREIGN KEY (BedrijfId) REFERENCES Bedrijven(BedrijfId)
);



CREATE TABLE Afspraken (
    AfspraakId int IDENTITY,
    VoornaamBezoeker varchar(255) not null,
    AchternaamBezoeker varchar(255) not null,
    BezoekersBedrijfNaam varchar(255) not null,
    Email varchar(255) not null,
    Aanwezig bit not null,

    StartTijd Datetime not null,
    EindTijd Datetime null,

    WerknemerId int,
    PRIMARY KEY (AfspraakId),
    FOREIGN KEY (WerknemerId) REFERENCES Werknemers(WerknemerId)
);


INSERT INTO Bedrijven (Naam, BTW, Email, Adres, Telefoon) VALUES ('Browsebug', '87-076-9983', 'cwycliff0@creativecommons.org', '4 Charing Cross Place', '112-968-1694');
INSERT INTO Bedrijven (Naam, BTW, Email, Adres, Telefoon) VALUES ('Tagcat', '11-600-7808', 'gfivey1@youku.com', '92 Hallows Trail', '993-390-0114');
INSERT INTO Bedrijven (Naam, BTW, Email, Adres, Telefoon) VALUES ('Devshare', '29-883-0208', 'jthornton2@miitbeian.gov.cn', '535 Merrick Plaza', '428-430-2592');
INSERT INTO Bedrijven (Naam, BTW, Email, Adres, Telefoon) VALUES ('Topiczoom', '15-760-6867', 'powain3@theguardian.com', '53002 Anzinger Way', '905-315-4223');
INSERT INTO Bedrijven (Naam, BTW, Email, Adres, Telefoon) VALUES ('Agivu', '03-009-2880', 'rochterlony4@opensource.org', '94734 Tomscot Hill', '499-799-8648');
INSERT INTO Bedrijven (Naam, BTW, Email, Adres, Telefoon) VALUES ('Tazz', '76-206-8779', 'lgiorgini5@prlog.org', '73 Monument Park', '664-724-1506');
INSERT INTO Bedrijven (Naam, BTW, Email, Adres, Telefoon) VALUES ('Divape', '29-471-9174', 'abazire6@cyberchimps.com', '87643 Leroy Terrace', '308-981-6230');
INSERT INTO Bedrijven (Naam, BTW, Email, Adres, Telefoon) VALUES ('Voonyx', '22-059-4053', 'kbrendel7@mediafire.com', '72 Crescent Oaks Avenue', '982-785-2997');
INSERT INTO Bedrijven (Naam, BTW, Email, Adres, Telefoon) VALUES ('LiveZ', '10-668-8679', 'kattride8@dell.com', '26 Carey Road', '945-767-4057');
INSERT INTO Bedrijven (Naam, BTW, Email, Adres, Telefoon) VALUES ('Livepath', '62-271-4783', 'hglidder9@chronoengine.com', '09 Golf View Plaza', '159-650-0462');


INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Donald', 'OConnell', 'Donald.OConnell@email.com', 'SH_CLERK', '7');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Douglas', 'Grant', 'Douglas.Grant@email.com', 'SH_CLERK', '10');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Jennifer', 'Whalen', 'Jennifer.Whalen@email.com', 'AD_ASST', '4');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Michael', 'Hartstein', 'Michael.Hartstein@email.com', 'MK_MAN', '5');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Pat', 'Fay', 'Pat.Fay@email.com', 'MK_REP', '8');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Susan', 'Mavris', 'Susan.Mavris@email.com', 'HR_REP', '1');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Hermann', 'Baer', 'Hermann.Baer@email.com', 'PR_REP', '9');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Shelley', 'Higgins', 'Shelley.Higgins@email.com', 'AC_MGR', '4');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('William', 'Gietz', 'William.Gietz@email.com', 'AC_ACCOUNT', '10');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Steven', 'King', 'Steven.King@email.com', 'AD_PRES', '10');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Neena', 'Kochhar', 'Neena.Kochhar@email.com', 'AD_VP', '4');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Lex', 'De Haan', 'Lex.De Haan@email.com', 'AD_VP', '5');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Alexander', 'Hunold', 'Alexander.Hunold@email.com', 'IT_PROG', '4');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Bruce', 'Ernst', 'Bruce.Ernst@email.com', 'IT_PROG', '10');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('David', 'Austin', 'David.Austin@email.com', 'IT_PROG', '7');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Valli', 'Pataballa', 'Valli.Pataballa@email.com', 'IT_PROG', '1');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Diana', 'Lorentz', 'Diana.Lorentz@email.com', 'IT_PROG', '5');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Nancy', 'Greenberg', 'Nancy.Greenberg@email.com', 'FI_MGR', '5');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Daniel', 'Faviet', 'Daniel.Faviet@email.com', 'FI_ACCOUNT', '7');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('John', 'Chen', 'John.Chen@email.com', 'FI_ACCOUNT', '7');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Ismael', 'Sciarra', 'Ismael.Sciarra@email.com', 'FI_ACCOUNT', '6');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Jose Manuel', 'Urman', 'Jose Manuel.Urman@email.com', 'FI_ACCOUNT', '5');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Luis', 'Popp', 'Luis.Popp@email.com', 'FI_ACCOUNT', '1');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Den', 'Raphaely', 'Den.Raphaely@email.com', 'PU_MAN', '7');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Alexander', 'Khoo', 'Alexander.Khoo@email.com', 'PU_CLERK', '8');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Shelli', 'Baida', 'Shelli.Baida@email.com', 'PU_CLERK', '6');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Sigal', 'Tobias', 'Sigal.Tobias@email.com', 'PU_CLERK', '6');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Guy', 'Himuro', 'Guy.Himuro@email.com', 'PU_CLERK', '4');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Karen', 'Colmenares', 'Karen.Colmenares@email.com', 'PU_CLERK', '9');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Matthew', 'Weiss', 'Matthew.Weiss@email.com', 'ST_MAN', '5');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Adam', 'Fripp', 'Adam.Fripp@email.com', 'ST_MAN', '3');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Payam', 'Kaufling', 'Payam.Kaufling@email.com', 'ST_MAN', '7');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Shanta', 'Vollman', 'Shanta.Vollman@email.com', 'ST_MAN', '5');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Kevin', 'Mourgos', 'Kevin.Mourgos@email.com', 'ST_MAN', '4');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Julia', 'Nayer', 'Julia.Nayer@email.com', 'ST_CLERK', '7');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Irene', 'Mikkilineni', 'Irene.Mikkilineni@email.com', 'ST_CLERK', '6');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('James', 'Landry', 'James.Landry@email.com', 'ST_CLERK', '9');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Steven', 'Markle', 'Steven.Markle@email.com', 'ST_CLERK', '10');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Laura', 'Bissot', 'Laura.Bissot@email.com', 'ST_CLERK', '9');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Mozhe', 'Atkinson', 'Mozhe.Atkinson@email.com', 'ST_CLERK', '4');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('James', 'Marlow', 'James.Marlow@email.com', 'ST_CLERK', '6');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('TJ', 'Olson', 'TJ.Olson@email.com', 'ST_CLERK', '5');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Jason', 'Mallin', 'Jason.Mallin@email.com', 'ST_CLERK', '8');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Michael', 'Rogers', 'Michael.Rogers@email.com', 'ST_CLERK', '10');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Ki', 'Gee', 'Ki.Gee@email.com', 'ST_CLERK', '2');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Hazel', 'Philtanker', 'Hazel.Philtanker@email.com', 'ST_CLERK', '6');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Renske', 'Ladwig', 'Renske.Ladwig@email.com', 'ST_CLERK', '7');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Stephen', 'Stiles', 'Stephen.Stiles@email.com', 'ST_CLERK', '9');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('John', 'Seo', 'John.Seo@email.com', 'ST_CLERK', '6');
INSERT INTO Werknemers (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Joshua', 'Patel', 'Joshua.Patel@email.com', 'ST_CLERK', '8');


INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Neena', 'Neena', 'Livepath', 'Neena.Neena@email.com', 1, '2023-07-01 14:17:00', '2023-07-01 12:36:00', '11');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Hermann', 'Hermann', 'Tazz', 'Hermann.Hermann@email.com', 1, '2023-07-02 08:04:00', '2023-07-02 09:21:00', '7');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Steven', 'Steven', 'Devshare', 'Steven.Steven@email.com', 1, '2023-05-09 13:40:00', '2023-05-09 16:47:00', '10');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Hermann', 'Hermann', 'Browsebug', 'Hermann.Hermann@email.com', 1, '2023-02-20 12:34:00', '2023-02-20 12:58:00', '7');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Steven', 'Steven', 'LiveZ', 'Steven.Steven@email.com', 1, '2023-10-09 16:22:00', '2023-10-09 08:48:00', '10');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Pat', 'Pat', 'Voonyx', 'Pat.Pat@email.com', 1, '2023-06-12 15:39:00', '2023-06-12 13:33:00', '5');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Steven', 'Steven', 'Topiczoom', 'Steven.Steven@email.com', 1, '2023-05-25 08:05:00', '2023-05-25 15:09:00', '10');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Pat', 'Pat', '', 'Pat.Pat@email.com', 1, '2023-02-02 16:12:00', '2023-02-02 16:26:00', '5');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Pat', 'Pat', 'Divape', 'Pat.Pat@email.com', 1, '2023-07-06 14:19:00', '2023-07-06 11:48:00', '5');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Michael', 'Michael', 'Tagcat', 'Michael.Michael@email.com', 1, '2023-04-25 13:45:00', '2023-04-25 15:22:00', '4');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Douglas', 'Douglas', 'Tazz', 'Douglas.Douglas@email.com', 1, '2023-10-15 12:00:00', '2023-10-15 15:22:00', '2');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('William', 'William', 'Topiczoom', 'William.William@email.com', 1, '2023-10-12 12:34:00', '2023-10-12 10:15:00', '9');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Donald', 'Donald', 'Browsebug', 'Donald.Donald@email.com', 1, '2023-05-14 11:50:00', '2023-05-14 08:44:00', '1');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Douglas', 'Douglas', 'Agivu', 'Douglas.Douglas@email.com', 1, '2023-07-02 15:18:00', '2023-07-02 16:35:00', '2');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Michael', 'Michael', 'Livepath', 'Michael.Michael@email.com', 1, '2023-01-13 16:46:00', '2023-01-13 08:31:00', '4');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Michael', 'Michael', 'Tazz', 'Michael.Michael@email.com', 1, '2023-01-18 13:12:00', '2023-01-18 12:32:00', '4');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Steven', 'Steven', 'Livepath', 'Steven.Steven@email.com', 1, '2023-09-01 09:37:00', '2023-09-01 12:52:00', '10');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Neena', 'Neena', 'Devshare', 'Neena.Neena@email.com', 1, '2023-10-24 13:48:00', '2023-10-24 16:48:00', '11');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Shelley', 'Shelley', 'Livepath', 'Shelley.Shelley@email.com', 1, '2023-02-07 11:16:00', '2023-02-07 11:33:00', '8');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Shelley', 'Shelley', 'Voonyx', 'Shelley.Shelley@email.com', 1, '2023-10-11 15:18:00', '2023-10-11 11:36:00', '8');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Steven', 'Steven', 'Browsebug', 'Steven.Steven@email.com', 1, '2023-10-21 08:41:00', '2023-10-21 15:25:00', '10');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Steven', 'Steven', 'Voonyx', 'Steven.Steven@email.com', 1, '2023-01-14 09:58:00', '2023-01-14 16:25:00', '10');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Steven', 'Steven', 'Topiczoom', 'Steven.Steven@email.com', 1, '2023-09-07 14:39:00', '2023-09-07 15:12:00', '10');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Jennifer', 'Jennifer', 'Agivu', 'Jennifer.Jennifer@email.com', 1, '2023-06-20 15:50:00', '2023-06-20 12:54:00', '3');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Douglas', 'Douglas', 'Voonyx', 'Douglas.Douglas@email.com', 1, '2023-06-23 12:45:00', '2023-06-23 14:34:00', '2');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Douglas', 'Douglas', 'Browsebug', 'Douglas.Douglas@email.com', 1, '2023-04-02 11:23:00', '2023-04-02 10:29:00', '2');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Jennifer', 'Jennifer', 'Tagcat', 'Jennifer.Jennifer@email.com', 1, '2023-10-01 09:05:00', '2023-10-01 13:14:00', '3');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Pat', 'Pat', 'Topiczoom', 'Pat.Pat@email.com', 1, '2023-06-06 08:14:00', '2023-06-06 13:36:00', '5');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Neena', 'Neena', 'Devshare', 'Neena.Neena@email.com', 1, '2023-05-02 08:26:00', '2023-05-02 12:49:00', '11');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Steven', 'Steven', 'Voonyx', 'Steven.Steven@email.com', 1, '2023-08-13 08:59:00', '2023-08-13 14:08:00', '10');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Jennifer', 'Jennifer', 'Voonyx', 'Jennifer.Jennifer@email.com', 1, '2023-11-13 13:25:00', '2023-11-13 16:46:00', '3');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Steven', 'Steven', 'Divape', 'Steven.Steven@email.com', 1, '2023-07-01 10:54:00', '2023-07-01 14:31:00', '10');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('William', 'William', 'Divape', 'William.William@email.com', 1, '2023-02-12 08:32:00', '2023-02-12 14:27:00', '9');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Neena', 'Neena', '', 'Neena.Neena@email.com', 1, '2023-09-20 08:05:00', '2023-09-20 12:59:00', '11');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Shelley', 'Shelley', 'Topiczoom', 'Shelley.Shelley@email.com', 1, '2023-02-05 16:02:00', '2023-02-05 09:53:00', '8');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Donald', 'Donald', 'Agivu', 'Donald.Donald@email.com', 1, '2023-10-15 09:42:00', '2023-10-15 10:57:00', '1');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Hermann', 'Hermann', 'Divape', 'Hermann.Hermann@email.com', 1, '2023-10-04 12:35:00', '2023-10-04 13:56:00', '7');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('William', 'William', 'Topiczoom', 'William.William@email.com', 1, '2023-09-08 13:52:00', '2023-09-08 12:40:00', '9');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Neena', 'Neena', 'Devshare', 'Neena.Neena@email.com', 1, '2023-04-24 11:07:00', '2023-04-24 10:24:00', '11');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Michael', 'Michael', 'Livepath', 'Michael.Michael@email.com', 1, '2023-05-24 11:52:00', '2023-05-24 13:28:00', '4');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Donald', 'Donald', 'Livepath', 'Donald.Donald@email.com', 1, '2023-06-05 09:39:00', '2023-06-05 10:18:00', '1');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Douglas', 'Douglas', 'Agivu', 'Douglas.Douglas@email.com', 1, '2023-06-17 11:22:00', '2023-06-17 16:48:00', '2');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Donald', 'Donald', 'Livepath', 'Donald.Donald@email.com', 1, '2023-03-09 13:51:00', '2023-03-09 11:54:00', '1');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Neena', 'Neena', '', 'Neena.Neena@email.com', 1, '2023-04-21 09:50:00', '2023-04-21 13:09:00', '11');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Shelley', 'Shelley', 'Tazz', 'Shelley.Shelley@email.com', 1, '2023-11-13 11:44:00', '2023-11-13 16:36:00', '8');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Susan', 'Susan', 'Voonyx', 'Susan.Susan@email.com', 1, '2023-07-06 13:05:00', '2023-07-06 16:05:00', '6');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Jennifer', 'Jennifer', 'Tagcat', 'Jennifer.Jennifer@email.com', 1, '2023-10-04 13:35:00', '2023-10-04 16:40:00', '3');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Hermann', 'Hermann', 'Voonyx', 'Hermann.Hermann@email.com', 1, '2023-02-18 11:10:00', '2023-02-18 13:47:00', '7');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Jennifer', 'Jennifer', 'Tagcat', 'Jennifer.Jennifer@email.com', 1, '2023-07-22 15:46:00', '2023-07-22 11:42:00', '3');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Hermann', 'Hermann', 'Divape', 'Hermann.Hermann@email.com', 1, '2023-03-10 08:27:00', '2023-03-10 13:12:00', '7');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Steven', 'Steven', 'Divape', 'Steven.Steven@email.com', 1, '2023-11-13 12:48:00', '2023-11-13 14:09:00', '10');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Shelley', 'Shelley', 'Livepath', 'Shelley.Shelley@email.com', 1, '2023-06-21 12:41:00', '2023-06-21 09:03:00', '8');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Steven', 'Steven', '', 'Steven.Steven@email.com', 1, '2023-05-04 13:50:00', '2023-05-04 10:50:00', '10');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Shelley', 'Shelley', 'Devshare', 'Shelley.Shelley@email.com', 1, '2023-11-04 09:10:00', '2023-11-04 09:03:00', '8');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Steven', 'Steven', 'LiveZ', 'Steven.Steven@email.com', 1, '2023-05-25 10:56:00', '2023-05-25 08:00:00', '10');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Pat', 'Pat', 'Divape', 'Pat.Pat@email.com', 1, '2023-07-09 11:13:00', '2023-07-09 08:28:00', '5');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Michael', 'Michael', 'Browsebug', 'Michael.Michael@email.com', 1, '2023-08-22 16:19:00', '2023-08-22 08:12:00', '4');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Douglas', 'Douglas', 'Voonyx', 'Douglas.Douglas@email.com', 1, '2023-11-16 10:08:00', '2023-11-16 11:26:00', '2');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Pat', 'Pat', 'Voonyx', 'Pat.Pat@email.com', 1, '2023-02-03 16:08:00', '2023-02-03 08:12:00', '5');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Pat', 'Pat', 'Divape', 'Pat.Pat@email.com', 1, '2023-03-11 14:25:00', '2023-03-11 16:49:00', '5');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Steven', 'Steven', 'Devshare', 'Steven.Steven@email.com', 1, '2023-05-21 11:18:00', '2023-05-21 08:06:00', '10');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Neena', 'Neena', 'Topiczoom', 'Neena.Neena@email.com', 1, '2023-11-07 15:22:00', '2023-11-07 09:38:00', '11');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Hermann', 'Hermann', 'Tazz', 'Hermann.Hermann@email.com', 1, '2023-03-15 08:02:00', '2023-03-15 14:54:00', '7');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Donald', 'Donald', 'Tagcat', 'Donald.Donald@email.com', 1, '2023-09-25 08:05:00', '2023-09-25 12:49:00', '1');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Donald', 'Donald', 'Browsebug', 'Donald.Donald@email.com', 1, '2023-10-01 12:00:00', '2023-10-01 11:55:00', '1');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('William', 'William', '', 'William.William@email.com', 1, '2023-05-21 08:44:00', '2023-05-21 11:07:00', '9');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Douglas', 'Douglas', 'Topiczoom', 'Douglas.Douglas@email.com', 1, '2023-06-22 10:34:00', '2023-06-22 14:30:00', '2');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Michael', 'Michael', 'Browsebug', 'Michael.Michael@email.com', 1, '2023-06-06 15:55:00', '2023-06-06 15:28:00', '4');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Steven', 'Steven', '', 'Steven.Steven@email.com', 1, '2023-10-06 10:08:00', '2023-10-06 14:46:00', '10');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Hermann', 'Hermann', 'LiveZ', 'Hermann.Hermann@email.com', 1, '2023-07-02 14:17:00', '2023-07-02 08:16:00', '7');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Neena', 'Neena', 'Tagcat', 'Neena.Neena@email.com', 1, '2023-02-09 13:10:00', '2023-02-09 10:11:00', '11');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Douglas', 'Douglas', 'Topiczoom', 'Douglas.Douglas@email.com', 1, '2023-01-12 15:14:00', '2023-01-12 14:29:00', '2');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Pat', 'Pat', 'Devshare', 'Pat.Pat@email.com', 1, '2023-01-13 08:09:00', '2023-01-13 13:17:00', '5');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Donald', 'Donald', 'Divape', 'Donald.Donald@email.com', 1, '2023-07-21 12:39:00', '2023-07-21 12:00:00', '1');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Neena', 'Neena', 'Tagcat', 'Neena.Neena@email.com', 1, '2023-02-01 11:36:00', '2023-02-01 09:41:00', '11');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Shelley', 'Shelley', 'Agivu', 'Shelley.Shelley@email.com', 1, '2023-05-15 08:56:00', '2023-05-15 12:51:00', '8');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Donald', 'Donald', 'Divape', 'Donald.Donald@email.com', 1, '2023-01-08 15:51:00', '2023-01-08 09:57:00', '1');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Hermann', 'Hermann', 'Devshare', 'Hermann.Hermann@email.com', 1, '2023-01-12 10:42:00', '2023-01-12 09:32:00', '7');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Steven', 'Steven', 'Browsebug', 'Steven.Steven@email.com', 1, '2023-04-06 14:35:00', '2023-04-06 16:11:00', '10');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Pat', 'Pat', 'Browsebug', 'Pat.Pat@email.com', 1, '2023-06-04 14:39:00', '2023-06-04 08:53:00', '5');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Jennifer', 'Jennifer', 'Divape', 'Jennifer.Jennifer@email.com', 1, '2023-05-13 16:15:00', '2023-05-13 08:30:00', '3');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Douglas', 'Douglas', 'Browsebug', 'Douglas.Douglas@email.com', 1, '2023-04-14 12:01:00', '2023-04-14 09:54:00', '2');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Shelley', 'Shelley', 'Browsebug', 'Shelley.Shelley@email.com', 1, '2023-03-09 12:21:00', '2023-03-09 11:04:00', '8');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Pat', 'Pat', 'Browsebug', 'Pat.Pat@email.com', 1, '2023-02-09 08:01:00', '2023-02-09 15:56:00', '5');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Douglas', 'Douglas', 'Divape', 'Douglas.Douglas@email.com', 1, '2023-04-01 15:02:00', '2023-04-01 08:48:00', '2');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Hermann', 'Hermann', 'Agivu', 'Hermann.Hermann@email.com', 1, '2023-10-12 14:53:00', '2023-10-12 13:51:00', '7');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Douglas', 'Douglas', 'Divape', 'Douglas.Douglas@email.com', 1, '2023-02-17 15:05:00', '2023-02-17 08:46:00', '2');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Donald', 'Donald', 'Devshare', 'Donald.Donald@email.com', 1, '2023-10-10 09:01:00', '2023-10-10 15:55:00', '1');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Jennifer', 'Jennifer', '', 'Jennifer.Jennifer@email.com', 1, '2023-01-18 13:33:00', '2023-01-18 09:58:00', '3');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Susan', 'Susan', 'Topiczoom', 'Susan.Susan@email.com', 1, '2023-05-02 08:19:00', '2023-05-02 12:07:00', '6');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('William', 'William', 'Browsebug', 'William.William@email.com', 1, '2023-08-17 13:36:00', '2023-08-17 11:29:00', '9');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Shelley', 'Shelley', 'Tagcat', 'Shelley.Shelley@email.com', 1, '2023-07-07 11:25:00', '2023-07-07 08:27:00', '8');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Pat', 'Pat', 'Livepath', 'Pat.Pat@email.com', 1, '2023-06-19 09:00:00', '2023-06-19 13:50:00', '5');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Jennifer', 'Jennifer', '', 'Jennifer.Jennifer@email.com', 1, '2023-01-17 11:09:00', '2023-01-17 12:48:00', '3');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Shelley', 'Shelley', 'Tagcat', 'Shelley.Shelley@email.com', 1, '2023-07-06 14:35:00', '2023-07-06 13:54:00', '8');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Pat', 'Pat', 'Agivu', 'Pat.Pat@email.com', 1, '2023-02-07 15:07:00', '2023-02-07 14:46:00', '5');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('William', 'William', 'Browsebug', 'William.William@email.com', 1, '2023-07-25 16:38:00', '2023-07-25 16:14:00', '9');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Michael', 'Michael', 'Voonyx', 'Michael.Michael@email.com', 1, '2023-08-11 13:48:00', '2023-08-11 09:07:00', '4');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Shelley', 'Shelley', 'Tazz', 'Shelley.Shelley@email.com', 1, '2023-07-16 10:43:00', '2023-07-16 15:32:00', '8');
INSERT INTO Afspraken (VoornaamBezoeker, AchternaamBezoeker, BezoekersBedrijfNaam, Email, Aanwezig, StartTijd, EindTijd, WerknemerId ) VALUES ('Donald', 'Donald', 'Livepath', 'Donald.Donald@email.com', 1, '2023-03-07 14:44:00', '2023-03-07 11:53:00', '1');
