DROP TABLE Afspraak;
DROP TABLE Werknemer;
DROP TABLE Bedrijf;
DROP TABLE Bezoeker;


CREATE TABLE Bedrijf (
    bedrijfId int IDENTITY,
    naam varchar(255) not null,
    btwNummer varchar(255) not null,
    email varchar(255) not null,
    adres varchar(255) not null,
    telefoon varchar(255) not null,

    actief bit not null DEFAULT 1,
    PRIMARY KEY (bedrijfId),
);

CREATE TABLE Werknemer (
    werknemerId int IDENTITY,
    voornaam varchar(255)  not null,
    achternaam varchar(255) not null,
    email varchar(255) not null,
    functie varchar(255) not null,
    bedrijfId int,

    actief bit not null DEFAULT 1,
    PRIMARY KEY (werknemerId),
    FOREIGN KEY (bedrijfId) REFERENCES Bedrijf(bedrijfId)
);

CREATE TABLE Bezoeker (
    bezoekerId int IDENTITY,
    voornaam varchar(255)  not null,
    achternaam varchar(255) not null,
    email varchar(255) not null,
    bedrijf varchar(255) not null,
    nummerplaat varchar(255) null,
    aanwezig bit not null,

    PRIMARY KEY (bezoekerId),
);

CREATE TABLE Afspraak (
    afspraakId int IDENTITY,
    startTijd Datetime not null,
    eindTijd Datetime null,

    werknemerId int,
    bezoekerId int,

    PRIMARY KEY (afspraakId),
    FOREIGN KEY (werknemerId) REFERENCES Werknemer(werknemerId),
    FOREIGN KEY (bezoekerId) REFERENCES Bezoeker(bezoekerId)
);



INSERT INTO Bedrijf (naam, btwNummer, email, adres, telefoon, actief) VALUES ('Browsebug', '87-076-9983', 'cwycliff0@creativecommons.org', '4 Charing Cross Place', '112-968-1694', '1');
INSERT INTO Bedrijf (naam, btwNummer, email, adres, telefoon, actief) VALUES ('Tagcat', '11-600-7808', 'gfivey1@youku.com', '92 Hallows Trail', '993-390-0114', '1');
INSERT INTO Bedrijf (naam, btwNummer, email, adres, telefoon, actief) VALUES ('Devshare', '29-883-0208', 'jthornton2@miitbeian.gov.cn', '535 Merrick Plaza', '428-430-2592', '1');
INSERT INTO Bedrijf (naam, btwNummer, email, adres, telefoon, actief) VALUES ('Topiczoom', '15-760-6867', 'powain3@theguardian.com', '53002 Anzinger Way', '905-315-4223', '1');
INSERT INTO Bedrijf (naam, btwNummer, email, adres, telefoon, actief) VALUES ('Agivu', '03-009-2880', 'rochterlony4@opensource.org', '94734 Tomscot Hill', '499-799-8648', '1');
INSERT INTO Bedrijf (naam, btwNummer, email, adres, telefoon, actief) VALUES ('Tazz', '76-206-8779', 'lgiorgini5@prlog.org', '73 Monument Park', '664-724-1506', '1');
INSERT INTO Bedrijf (naam, btwNummer, email, adres, telefoon, actief) VALUES ('Divape', '29-471-9174', 'abazire6@cyberchimps.com', '87643 Leroy Terrace', '308-981-6230', '1');
INSERT INTO Bedrijf (naam, btwNummer, email, adres, telefoon, actief) VALUES ('Voonyx', '22-059-4053', 'kbrendel7@mediafire.com', '72 Crescent Oaks Avenue', '982-785-2997', '1');
INSERT INTO Bedrijf (naam, btwNummer, email, adres, telefoon, actief) VALUES ('LiveZ', '10-668-8679', 'kattride8@dell.com', '26 Carey Road', '945-767-4057', '1');
INSERT INTO Bedrijf (naam, btwNummer, email, adres, telefoon, actief) VALUES ('Livepath', '62-271-4783', 'hglidder9@chronoengine.com', '09 Golf View Plaza', '159-650-0462', '1');


INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId, actief) VALUES ('Donald', 'OConnell', 'Donald.OConnell@email.com', 'SH_CLERK', '7', '1');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId, actief) VALUES ('Douglas', 'Grant', 'Douglas.Grant@email.com', 'SH_CLERK', '10', '1');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId, actief) VALUES ('Jennifer', 'Whalen', 'Jennifer.Whalen@email.com', 'AD_ASST', '4', '1');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId, actief) VALUES ('Michael', 'Hartstein', 'Michael.Hartstein@email.com', 'MK_MAN', '5', '1');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId, actief) VALUES ('Pat', 'Fay', 'Pat.Fay@email.com', 'MK_REP', '8', '1');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId, actief) VALUES ('Susan', 'Mavris', 'Susan.Mavris@email.com', 'HR_REP', '1', '1');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId, actief) VALUES ('Hermann', 'Baer', 'Hermann.Baer@email.com', 'PR_REP', '9', '1');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId, actief) VALUES ('Shelley', 'Higgins', 'Shelley.Higgins@email.com', 'AC_MGR', '4', '1');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId, actief) VALUES ('William', 'Gietz', 'William.Gietz@email.com', 'AC_ACCOUNT', '10', '1');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId, actief) VALUES ('Steven', 'King', 'Steven.King@email.com', 'AD_PRES', '10', '1');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId, actief) VALUES ('Neena', 'Kochhar', 'Neena.Kochhar@email.com', 'AD_VP', '4', '1');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId, actief) VALUES ('Lex', 'De Haan', 'Lex.DeHaan@email.com', 'AD_VP', '5', '1');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId, actief) VALUES ('Alexander', 'Hunold', 'Alexander.Hunold@email.com', 'IT_PROG', '4', '1');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId, actief) VALUES ('Bruce', 'Ernst', 'Bruce.Ernst@email.com', 'IT_PROG', '10', '1');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId, actief) VALUES ('David', 'Austin', 'David.Austin@email.com', 'IT_PROG', '7', '1');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId, actief) VALUES ('Valli', 'Pataballa', 'Valli.Pataballa@email.com', 'IT_PROG', '1', '1');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId, actief) VALUES ('Diana', 'Lorentz', 'Diana.Lorentz@email.com', 'IT_PROG', '5', '1');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId, actief) VALUES ('Nancy', 'Greenberg', 'Nancy.Greenberg@email.com', 'FI_MGR', '5', '1');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId, actief) VALUES ('Daniel', 'Faviet', 'Daniel.Faviet@email.com', 'FI_ACCOUNT', '7', '1');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId, actief) VALUES ('John', 'Chen', 'John.Chen@email.com', 'FI_ACCOUNT', '7', '1');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId, actief) VALUES ('Ismael', 'Sciarra', 'Ismael.Sciarra@email.com', 'FI_ACCOUNT', '6', '1');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId, actief) VALUES ('Jose Manuel', 'Urman', 'JoseManuel.Urman@email.com', 'FI_ACCOUNT', '5', '1');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId, actief) VALUES ('Luis', 'Popp', 'Luis.Popp@email.com', 'FI_ACCOUNT', '1', '1');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId, actief) VALUES ('Den', 'Raphaely', 'Den.Raphaely@email.com', 'PU_MAN', '7', '1');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId, actief) VALUES ('Alexander', 'Khoo', 'Alexander.Khoo@email.com', 'PU_CLERK', '8', '1');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId, actief) VALUES ('Shelli', 'Baida', 'Shelli.Baida@email.com', 'PU_CLERK', '6', '1');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId, actief) VALUES ('Sigal', 'Tobias', 'Sigal.Tobias@email.com', 'PU_CLERK', '6', '1');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId, actief) VALUES ('Guy', 'Himuro', 'Guy.Himuro@email.com', 'PU_CLERK', '4', '1');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId, actief) VALUES ('Karen', 'Colmenares', 'Karen.Colmenares@email.com', 'PU_CLERK', '9', '1');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId, actief) VALUES ('Matthew', 'Weiss', 'Matthew.Weiss@email.com', 'ST_MAN', '5', '1');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId, actief) VALUES ('Adam', 'Fripp', 'Adam.Fripp@email.com', 'ST_MAN', '3', '1');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId, actief) VALUES ('Payam', 'Kaufling', 'Payam.Kaufling@email.com', 'ST_MAN', '7', '1');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId, actief) VALUES ('Shanta', 'Vollman', 'Shanta.Vollman@email.com', 'ST_MAN', '5', '1');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId, actief) VALUES ('Kevin', 'Mourgos', 'Kevin.Mourgos@email.com', 'ST_MAN', '4', '1');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId, actief) VALUES ('Julia', 'Nayer', 'Julia.Nayer@email.com', 'ST_CLERK', '7', '1');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId, actief) VALUES ('Irene', 'Mikkilineni', 'Irene.Mikkilineni@email.com', 'ST_CLERK', '6', '1');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId, actief) VALUES ('James', 'Landry', 'James.Landry@email.com', 'ST_CLERK', '9', '1');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId, actief) VALUES ('Steven', 'Markle', 'Steven.Markle@email.com', 'ST_CLERK', '10', '1');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId, actief) VALUES ('Laura', 'Bissot', 'Laura.Bissot@email.com', 'ST_CLERK', '9', '1');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId, actief) VALUES ('Mozhe', 'Atkinson', 'Mozhe.Atkinson@email.com', 'ST_CLERK', '4', '1');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId, actief) VALUES ('James', 'Marlow', 'James.Marlow@email.com', 'ST_CLERK', '6', '1');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId, actief) VALUES ('TJ', 'Olson', 'TJ.Olson@email.com', 'ST_CLERK', '5', '1');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId, actief) VALUES ('Jason', 'Mallin', 'Jason.Mallin@email.com', 'ST_CLERK', '8', '1');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId, actief) VALUES ('Michael', 'Rogers', 'Michael.Rogers@email.com', 'ST_CLERK', '10', '1');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId, actief) VALUES ('Ki', 'Gee', 'Ki.Gee@email.com', 'ST_CLERK', '2', '1');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId, actief) VALUES ('Hazel', 'Philtanker', 'Hazel.Philtanker@email.com', 'ST_CLERK', '6', '1');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId, actief) VALUES ('Renske', 'Ladwig', 'Renske.Ladwig@email.com', 'ST_CLERK', '7', '1');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId, actief) VALUES ('Stephen', 'Stiles', 'Stephen.Stiles@email.com', 'ST_CLERK', '9', '1');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId, actief) VALUES ('John', 'Seo', 'John.Seo@email.com', 'ST_CLERK', '6', '1');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId, actief) VALUES ('Joshua', 'Patel', 'Joshua.Patel@email.com', 'ST_CLERK', '8', '1');


INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Donald', 'OConnell', 'Donald.OConnell@email.com', 'Oleon', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Douglas', 'Grant', 'Douglas.Grant@email.com', 'Remotive', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Jennifer', 'Whalen', 'Jennifer.Whalen@email.com', 'Ineo Fenol', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Michael', 'Hartstein', 'Michael.Hartstein@email.com', 'Aligist Bruggeman', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Pat', 'Fay', 'Pat.Fay@email.com', 'Vpk', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Susan', 'Mavris', 'Susan.Mavris@email.com', 'LLh', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Hermann', 'Baer', 'Hermann.Baer@email.com', 'LLh', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Shelley', 'Higgins', 'Shelley.Higgins@email.com', 'SidMar', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('William', 'Gietz', 'William.Gietz@email.com', 'Remotive', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Steven', 'King', 'Steven.King@email.com', 'SidMar', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Neena', 'Kochhar', 'Neena.Kochhar@email.com', 'Oleon', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Lex', 'De Haan', 'Lex.DeHaan@email.com', 'Remotive', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Alexander', 'Hunold', 'Alexander.Hunold@email.com', 'Vpk', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Bruce', 'Ernst', 'Bruce.Ernst@email.com', 'SidMar', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('David', 'Austin', 'David.Austin@email.com', 'Stora Enzo', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Valli', 'Pataballa', 'Valli.Pataballa@email.com', 'Oleon', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Diana', 'Lorentz', 'Diana.Lorentz@email.com', 'Vpk', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Nancy', 'Greenberg', 'Nancy.Greenberg@email.com', 'Stora Enzo', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Daniel', 'Faviet', 'Daniel.Faviet@email.com', 'Aligist Bruggeman', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('John', 'Chen', 'John.Chen@email.com', 'Vpk', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Ismael', 'Sciarra', 'Ismael.Sciarra@email.com', 'Remotive', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Jose Manuel', 'Urman', 'JoseManuel.Urman@email.com', 'Remotive', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Luis', 'Popp', 'Luis.Popp@email.com', 'LLh', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Den', 'Raphaely', 'Den.Raphaely@email.com', 'Vpk', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Alexander', 'Khoo', 'Alexander.Khoo@email.com', 'Stora Enzo', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Shelli', 'Baida', 'Shelli.Baida@email.com', 'SidMar', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Sigal', 'Tobias', 'Sigal.Tobias@email.com', 'Oleon', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Guy', 'Himuro', 'Guy.Himuro@email.com', 'Remotive', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Karen', 'Colmenares', 'Karen.Colmenares@email.com', 'Aligist Bruggeman', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Matthew', 'Weiss', 'Matthew.Weiss@email.com', 'Remotive', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Adam', 'Fripp', 'Adam.Fripp@email.com', 'Vpk', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Payam', 'Kaufling', 'Payam.Kaufling@email.com', 'Stora Enzo', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Shanta', 'Vollman', 'Shanta.Vollman@email.com', 'Remotive', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Kevin', 'Mourgos', 'Kevin.Mourgos@email.com', 'Remotive', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Julia', 'Nayer', 'Julia.Nayer@email.com', 'Vpk', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Irene', 'Mikkilineni', 'Irene.Mikkilineni@email.com', 'Oleon', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('James', 'Landry', 'James.Landry@email.com', 'Remotive', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Steven', 'Markle', 'Steven.Markle@email.com', 'Stora Enzo', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Laura', 'Bissot', 'Laura.Bissot@email.com', 'Aligist Bruggeman', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Mozhe', 'Atkinson', 'Mozhe.Atkinson@email.com', 'Stora Enzo', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('James', 'Marlow', 'James.Marlow@email.com', 'Oleon', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('TJ', 'Olson', 'TJ.Olson@email.com', 'Vpk', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Jason', 'Mallin', 'Jason.Mallin@email.com', 'Remotive', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Michael', 'Rogers', 'Michael.Rogers@email.com', 'LLh', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Ki', 'Gee', 'Ki.Gee@email.com', 'Vpk', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Hazel', 'Philtanker', 'Hazel.Philtanker@email.com', 'Oleon', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Renske', 'Ladwig', 'Renske.Ladwig@email.com', 'Vpk', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Stephen', 'Stiles', 'Stephen.Stiles@email.com', 'Stora Enzo', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('John', 'Seo', 'John.Seo@email.com', 'Vpk', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Joshua', 'Patel', 'Joshua.Patel@email.com', 'SidMar', '0', '');


INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-07-01 14:17:00', '2023-07-01 12:36:00', '11', '33');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-07-02 08:04:00', '2023-07-02 09:21:00', '7', '8');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-05-09 13:40:00', '2023-05-09 16:47:00', '10', '9');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-02-20 12:34:00', '2023-02-20 12:58:00', '7', '13');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-10-09 16:22:00', '2023-10-09 08:48:00', '10', '15');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-06-12 15:39:00', '2023-06-12 13:33:00', '5', '20');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-05-25 08:05:00', '2023-05-25 15:09:00', '10', '2');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-02-02 16:12:00', '2023-02-02 16:26:00', '5', '43');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-07-06 14:19:00', '2023-07-06 11:48:00', '5', '6');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-04-25 13:45:00', '2023-04-25 15:22:00', '4', '9');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-10-15 12:00:00', '2023-10-15 15:22:00', '2', '42');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-10-12 12:34:00', '2023-10-12 10:15:00', '9', '46');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-05-14 11:50:00', '2023-05-14 08:44:00', '1', '28');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-07-02 15:18:00', '2023-07-02 16:35:00', '2', '47');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-01-13 16:46:00', '2023-01-13 08:31:00', '4', '37');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-01-18 13:12:00', '2023-01-18 12:32:00', '4', '3');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-09-01 09:37:00', '2023-09-01 12:52:00', '10', '47');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-10-24 13:48:00', '2023-10-24 16:48:00', '11', '23');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-02-07 11:16:00', '2023-02-07 11:33:00', '8', '2');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-10-11 15:18:00', '2023-10-11 11:36:00', '8', '13');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-10-21 08:41:00', '2023-10-21 15:25:00', '10', '26');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-01-14 09:58:00', '2023-01-14 16:25:00', '10', '6');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-09-07 14:39:00', '2023-09-07 15:12:00', '10', '49');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-06-20 15:50:00', '2023-06-20 12:54:00', '3', '28');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-06-23 12:45:00', '2023-06-23 14:34:00', '2', '24');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-04-02 11:23:00', '2023-04-02 10:29:00', '2', '26');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-10-01 09:05:00', '2023-10-01 13:14:00', '3', '45');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-06-06 08:14:00', '2023-06-06 13:36:00', '5', '32');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-05-02 08:26:00', '2023-05-02 12:49:00', '11', '46');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-08-13 08:59:00', '2023-08-13 14:08:00', '10', '9');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-11-13 13:25:00', '2023-11-13 16:46:00', '3', '46');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-07-01 10:54:00', '2023-07-01 14:31:00', '10', '35');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-02-12 08:32:00', '2023-02-12 14:27:00', '9', '26');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-09-20 08:05:00', '2023-09-20 12:59:00', '11', '25');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-02-05 16:02:00', '2023-02-05 09:53:00', '8', '26');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-10-15 09:42:00', '2023-10-15 10:57:00', '1', '22');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-10-04 12:35:00', '2023-10-04 13:56:00', '7', '18');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-09-08 13:52:00', '2023-09-08 12:40:00', '9', '15');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-04-24 11:07:00', '2023-04-24 10:24:00', '11', '23');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-05-24 11:52:00', '2023-05-24 13:28:00', '4', '18');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-06-05 09:39:00', '2023-06-05 10:18:00', '1', '8');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-06-17 11:22:00', '2023-06-17 16:48:00', '2', '27');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-03-09 13:51:00', '2023-03-09 11:54:00', '1', '43');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-04-21 09:50:00', '2023-04-21 13:09:00', '11', '33');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-11-13 11:44:00', '2023-11-13 16:36:00', '8', '1');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-07-06 13:05:00', '2023-07-06 16:05:00', '6', '20');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-10-04 13:35:00', '2023-10-04 16:40:00', '3', '7');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-02-18 11:10:00', '2023-02-18 13:47:00', '7', '27');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-07-22 15:46:00', '2023-07-22 11:42:00', '3', '8');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-03-10 08:27:00', '2023-03-10 13:12:00', '7', '23');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-11-13 12:48:00', '2023-11-13 14:09:00', '10', '3');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-06-21 12:41:00', '2023-06-21 09:03:00', '8', '28');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-05-04 13:50:00', '2023-05-04 10:50:00', '10', '24');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-11-04 09:10:00', '2023-11-04 09:03:00', '8', '30');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-05-25 10:56:00', '2023-05-25 08:00:00', '10', '48');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-07-09 11:13:00', '2023-07-09 08:28:00', '5', '15');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-08-22 16:19:00', '2023-08-22 08:12:00', '4', '3');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-11-16 10:08:00', '2023-11-16 11:26:00', '2', '17');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-02-03 16:08:00', '2023-02-03 08:12:00', '5', '17');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-03-11 14:25:00', '2023-03-11 16:49:00', '5', '44');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-05-21 11:18:00', '2023-05-21 08:06:00', '10', '24');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-11-07 15:22:00', '2023-11-07 09:38:00', '11', '42');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-03-15 08:02:00', '2023-03-15 14:54:00', '7', '27');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-09-25 08:05:00', '2023-09-25 12:49:00', '1', '21');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-10-01 12:00:00', '2023-10-01 11:55:00', '1', '37');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-05-21 08:44:00', '2023-05-21 11:07:00', '9', '46');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-06-22 10:34:00', '2023-06-22 14:30:00', '2', '27');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-06-06 15:55:00', '2023-06-06 15:28:00', '4', '49');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-10-06 10:08:00', '2023-10-06 14:46:00', '10', '23');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-07-02 14:17:00', '2023-07-02 08:16:00', '7', '13');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-02-09 13:10:00', '2023-02-09 10:11:00', '11', '8');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-01-12 15:14:00', '2023-01-12 14:29:00', '2', '8');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-01-13 08:09:00', '2023-01-13 13:17:00', '5', '11');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-07-21 12:39:00', '2023-07-21 12:00:00', '1', '46');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-02-01 11:36:00', '2023-02-01 09:41:00', '11', '47');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-05-15 08:56:00', '2023-05-15 12:51:00', '8', '33');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-01-08 15:51:00', '2023-01-08 09:57:00', '1', '10');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-01-12 10:42:00', '2023-01-12 09:32:00', '7', '12');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-04-06 14:35:00', '2023-04-06 16:11:00', '10', '23');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-06-04 14:39:00', '2023-06-04 08:53:00', '5', '4');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-05-13 16:15:00', '2023-05-13 08:30:00', '3', '39');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-04-14 12:01:00', '2023-04-14 09:54:00', '2', '24');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-03-09 12:21:00', '2023-03-09 11:04:00', '8', '39');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-02-09 08:01:00', '2023-02-09 15:56:00', '5', '41');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-04-01 15:02:00', '2023-04-01 08:48:00', '2', '16');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-10-12 14:53:00', '2023-10-12 13:51:00', '7', '40');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-02-17 15:05:00', '2023-02-17 08:46:00', '2', '32');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-10-10 09:01:00', '2023-10-10 15:55:00', '1', '42');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-01-18 13:33:00', '2023-01-18 09:58:00', '3', '32');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-05-02 08:19:00', '2023-05-02 12:07:00', '6', '20');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-08-17 13:36:00', '2023-08-17 11:29:00', '9', '38');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-07-07 11:25:00', '2023-07-07 08:27:00', '8', '47');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-06-19 09:00:00', '2023-06-19 13:50:00', '5', '29');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-01-17 11:09:00', '2023-01-17 12:48:00', '3', '21');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-07-06 14:35:00', '2023-07-06 13:54:00', '8', '29');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-02-07 15:07:00', '2023-02-07 14:46:00', '5', '24');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-07-25 16:38:00', '2023-07-25 16:14:00', '9', '4');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-08-11 13:48:00', '2023-08-11 09:07:00', '4', '41');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-07-16 10:43:00', '2023-07-16 15:32:00', '8', '2');
INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId ) VALUES ('2023-03-07 14:44:00', '2023-03-07 11:53:00', '1', '25');
