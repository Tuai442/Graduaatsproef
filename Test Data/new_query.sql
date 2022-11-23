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
    PRIMARY KEY (bedrijfId),
);

CREATE TABLE Werknemer (
    werknemerId int IDENTITY,
    voornaam varchar(255)  not null,
    achternaam varchar(255) not null,
    email varchar(255) not null,
    functie varchar(255) not null,
    bedrijfId int,
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
    aanwezig bit not null
    PRIMARY KEY (bezoekerId),
);

CREATE TABLE Afspraak (
    afspraakId int IDENTITY,
    bezoeker_voornaam varchar(255) not null,
    bezoeker_achternaam varchar(255) not null,
    bezoeker_email varchar(255) not null,

    werknemer_voornaam varchar(255) not null,
    werknemer_achternaam varchar(255) not null,
    werknemer_email varchar(255) not null,

    startTijd Datetime not null,
    eindTijd Datetime null,

    bedrijf varchar(255) not null,
    PRIMARY KEY (afspraakId),

);


--CREATE TABLE Werknemer_Afspraken(
    --WerknemerId int not null
    --AfspraakId int not null
    --FOREIGN KEY (WerknemerId) REFERENCES Werknemers(WerknemerId)
    --FOREIGN KEY (AfspraakId) REFERENCES Afspraken(AfspraakId)
--)

--CREATE TABLE Bezoeker_Afspraken(
    --BezoekerId int not null
    --AfspraakId int not null
    --FOREIGN KEY (BezoekerId) REFERENCES Bezoekers(BezoekerId)
    --FOREIGN KEY (AfspraakId) REFERENCES Afspraken(AfspraakId)
--)


INSERT INTO Bedrijf (naam, btwNummer, email, adres, telefoon) VALUES ('Browsebug', '87-076-9983', 'cwycliff0@creativecommons.org', '4 Charing Cross Place', '112-968-1694');
INSERT INTO Bedrijf (naam, btwNummer, email, adres, telefoon) VALUES ('Tagcat', '11-600-7808', 'gfivey1@youku.com', '92 Hallows Trail', '993-390-0114');
INSERT INTO Bedrijf (naam, btwNummer, email, adres, telefoon) VALUES ('Devshare', '29-883-0208', 'jthornton2@miitbeian.gov.cn', '535 Merrick Plaza', '428-430-2592');
INSERT INTO Bedrijf (naam, btwNummer, email, adres, telefoon) VALUES ('Topiczoom', '15-760-6867', 'powain3@theguardian.com', '53002 Anzinger Way', '905-315-4223');
INSERT INTO Bedrijf (naam, btwNummer, email, adres, telefoon) VALUES ('Agivu', '03-009-2880', 'rochterlony4@opensource.org', '94734 Tomscot Hill', '499-799-8648');
INSERT INTO Bedrijf (naam, btwNummer, email, adres, telefoon) VALUES ('Tazz', '76-206-8779', 'lgiorgini5@prlog.org', '73 Monument Park', '664-724-1506');
INSERT INTO Bedrijf (naam, btwNummer, email, adres, telefoon) VALUES ('Divape', '29-471-9174', 'abazire6@cyberchimps.com', '87643 Leroy Terrace', '308-981-6230');
INSERT INTO Bedrijf (naam, btwNummer, email, adres, telefoon) VALUES ('Voonyx', '22-059-4053', 'kbrendel7@mediafire.com', '72 Crescent Oaks Avenue', '982-785-2997');
INSERT INTO Bedrijf (naam, btwNummer, email, adres, telefoon) VALUES ('LiveZ', '10-668-8679', 'kattride8@dell.com', '26 Carey Road', '945-767-4057');
INSERT INTO Bedrijf (naam, btwNummer, email, adres, telefoon) VALUES ('Livepath', '62-271-4783', 'hglidder9@chronoengine.com', '09 Golf View Plaza', '159-650-0462');


INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId) VALUES ('Donald', 'OConnell', 'Donald.OConnell@email.com', 'SH_CLERK', '7');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId) VALUES ('Douglas', 'Grant', 'Douglas.Grant@email.com', 'SH_CLERK', '10');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId) VALUES ('Jennifer', 'Whalen', 'Jennifer.Whalen@email.com', 'AD_ASST', '4');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId) VALUES ('Michael', 'Hartstein', 'Michael.Hartstein@email.com', 'MK_MAN', '5');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId) VALUES ('Pat', 'Fay', 'Pat.Fay@email.com', 'MK_REP', '8');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId) VALUES ('Susan', 'Mavris', 'Susan.Mavris@email.com', 'HR_REP', '1');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId) VALUES ('Hermann', 'Baer', 'Hermann.Baer@email.com', 'PR_REP', '9');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId) VALUES ('Shelley', 'Higgins', 'Shelley.Higgins@email.com', 'AC_MGR', '4');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId) VALUES ('William', 'Gietz', 'William.Gietz@email.com', 'AC_ACCOUNT', '10');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId) VALUES ('Steven', 'King', 'Steven.King@email.com', 'AD_PRES', '10');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId) VALUES ('Neena', 'Kochhar', 'Neena.Kochhar@email.com', 'AD_VP', '4');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId) VALUES ('Lex', 'De Haan', 'Lex.De Haan@email.com', 'AD_VP', '5');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId) VALUES ('Alexander', 'Hunold', 'Alexander.Hunold@email.com', 'IT_PROG', '4');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId) VALUES ('Bruce', 'Ernst', 'Bruce.Ernst@email.com', 'IT_PROG', '10');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId) VALUES ('David', 'Austin', 'David.Austin@email.com', 'IT_PROG', '7');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId) VALUES ('Valli', 'Pataballa', 'Valli.Pataballa@email.com', 'IT_PROG', '1');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId) VALUES ('Diana', 'Lorentz', 'Diana.Lorentz@email.com', 'IT_PROG', '5');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId) VALUES ('Nancy', 'Greenberg', 'Nancy.Greenberg@email.com', 'FI_MGR', '5');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId) VALUES ('Daniel', 'Faviet', 'Daniel.Faviet@email.com', 'FI_ACCOUNT', '7');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId) VALUES ('John', 'Chen', 'John.Chen@email.com', 'FI_ACCOUNT', '7');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId) VALUES ('Ismael', 'Sciarra', 'Ismael.Sciarra@email.com', 'FI_ACCOUNT', '6');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId) VALUES ('Jose Manuel', 'Urman', 'Jose Manuel.Urman@email.com', 'FI_ACCOUNT', '5');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId) VALUES ('Luis', 'Popp', 'Luis.Popp@email.com', 'FI_ACCOUNT', '1');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId) VALUES ('Den', 'Raphaely', 'Den.Raphaely@email.com', 'PU_MAN', '7');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId) VALUES ('Alexander', 'Khoo', 'Alexander.Khoo@email.com', 'PU_CLERK', '8');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId) VALUES ('Shelli', 'Baida', 'Shelli.Baida@email.com', 'PU_CLERK', '6');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId) VALUES ('Sigal', 'Tobias', 'Sigal.Tobias@email.com', 'PU_CLERK', '6');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId) VALUES ('Guy', 'Himuro', 'Guy.Himuro@email.com', 'PU_CLERK', '4');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId) VALUES ('Karen', 'Colmenares', 'Karen.Colmenares@email.com', 'PU_CLERK', '9');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId) VALUES ('Matthew', 'Weiss', 'Matthew.Weiss@email.com', 'ST_MAN', '5');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId) VALUES ('Adam', 'Fripp', 'Adam.Fripp@email.com', 'ST_MAN', '3');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId) VALUES ('Payam', 'Kaufling', 'Payam.Kaufling@email.com', 'ST_MAN', '7');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId) VALUES ('Shanta', 'Vollman', 'Shanta.Vollman@email.com', 'ST_MAN', '5');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId) VALUES ('Kevin', 'Mourgos', 'Kevin.Mourgos@email.com', 'ST_MAN', '4');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId) VALUES ('Julia', 'Nayer', 'Julia.Nayer@email.com', 'ST_CLERK', '7');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId) VALUES ('Irene', 'Mikkilineni', 'Irene.Mikkilineni@email.com', 'ST_CLERK', '6');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId) VALUES ('James', 'Landry', 'James.Landry@email.com', 'ST_CLERK', '9');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId) VALUES ('Steven', 'Markle', 'Steven.Markle@email.com', 'ST_CLERK', '10');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId) VALUES ('Laura', 'Bissot', 'Laura.Bissot@email.com', 'ST_CLERK', '9');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId) VALUES ('Mozhe', 'Atkinson', 'Mozhe.Atkinson@email.com', 'ST_CLERK', '4');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId) VALUES ('James', 'Marlow', 'James.Marlow@email.com', 'ST_CLERK', '6');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId) VALUES ('TJ', 'Olson', 'TJ.Olson@email.com', 'ST_CLERK', '5');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId) VALUES ('Jason', 'Mallin', 'Jason.Mallin@email.com', 'ST_CLERK', '8');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId) VALUES ('Michael', 'Rogers', 'Michael.Rogers@email.com', 'ST_CLERK', '10');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId) VALUES ('Ki', 'Gee', 'Ki.Gee@email.com', 'ST_CLERK', '2');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId) VALUES ('Hazel', 'Philtanker', 'Hazel.Philtanker@email.com', 'ST_CLERK', '6');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId) VALUES ('Renske', 'Ladwig', 'Renske.Ladwig@email.com', 'ST_CLERK', '7');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId) VALUES ('Stephen', 'Stiles', 'Stephen.Stiles@email.com', 'ST_CLERK', '9');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId) VALUES ('John', 'Seo', 'John.Seo@email.com', 'ST_CLERK', '6');
INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId) VALUES ('Joshua', 'Patel', 'Joshua.Patel@email.com', 'ST_CLERK', '8');


INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Donald', 'OConnell', 'Donald.OConnell@email.com', 'Ineo Fenol', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Douglas', 'Grant', 'Douglas.Grant@email.com', 'Remotive', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Jennifer', 'Whalen', 'Jennifer.Whalen@email.com', 'Remotive', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Michael', 'Hartstein', 'Michael.Hartstein@email.com', 'Aligist Bruggeman', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Pat', 'Fay', 'Pat.Fay@email.com', 'Oleon', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Susan', 'Mavris', 'Susan.Mavris@email.com', 'SidMar', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Hermann', 'Baer', 'Hermann.Baer@email.com', 'LLh', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Shelley', 'Higgins', 'Shelley.Higgins@email.com', 'Oleon', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('William', 'Gietz', 'William.Gietz@email.com', 'Ineo Fenol', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Steven', 'King', 'Steven.King@email.com', 'LLh', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Neena', 'Kochhar', 'Neena.Kochhar@email.com', 'Remotive', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Lex', 'De Haan', 'Lex.De Haan@email.com', 'Stora Enzo', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Alexander', 'Hunold', 'Alexander.Hunold@email.com', 'Oleon', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Bruce', 'Ernst', 'Bruce.Ernst@email.com', 'Aligist Bruggeman', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('David', 'Austin', 'David.Austin@email.com', 'LLh', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Valli', 'Pataballa', 'Valli.Pataballa@email.com', 'Oleon', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Diana', 'Lorentz', 'Diana.Lorentz@email.com', 'Oleon', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Nancy', 'Greenberg', 'Nancy.Greenberg@email.com', 'Vpk', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Daniel', 'Faviet', 'Daniel.Faviet@email.com', 'Remotive', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('John', 'Chen', 'John.Chen@email.com', 'LLh', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Ismael', 'Sciarra', 'Ismael.Sciarra@email.com', 'Remotive', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Jose Manuel', 'Urman', 'Jose Manuel.Urman@email.com', 'Oleon', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Luis', 'Popp', 'Luis.Popp@email.com', 'Vpk', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Den', 'Raphaely', 'Den.Raphaely@email.com', 'Oleon', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Alexander', 'Khoo', 'Alexander.Khoo@email.com', 'Ineo Fenol', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Shelli', 'Baida', 'Shelli.Baida@email.com', 'Vpk', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Sigal', 'Tobias', 'Sigal.Tobias@email.com', 'SidMar', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Guy', 'Himuro', 'Guy.Himuro@email.com', 'LLh', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Karen', 'Colmenares', 'Karen.Colmenares@email.com', 'SidMar', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Matthew', 'Weiss', 'Matthew.Weiss@email.com', 'Stora Enzo', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Adam', 'Fripp', 'Adam.Fripp@email.com', 'Remotive', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Payam', 'Kaufling', 'Payam.Kaufling@email.com', 'SidMar', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Shanta', 'Vollman', 'Shanta.Vollman@email.com', 'Vpk', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Kevin', 'Mourgos', 'Kevin.Mourgos@email.com', 'SidMar', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Julia', 'Nayer', 'Julia.Nayer@email.com', 'LLh', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Irene', 'Mikkilineni', 'Irene.Mikkilineni@email.com', 'Ineo Fenol', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('James', 'Landry', 'James.Landry@email.com', 'Aligist Bruggeman', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Steven', 'Markle', 'Steven.Markle@email.com', 'LLh', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Laura', 'Bissot', 'Laura.Bissot@email.com', 'Stora Enzo', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Mozhe', 'Atkinson', 'Mozhe.Atkinson@email.com', 'Oleon', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('James', 'Marlow', 'James.Marlow@email.com', 'Remotive', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('TJ', 'Olson', 'TJ.Olson@email.com', 'Vpk', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Jason', 'Mallin', 'Jason.Mallin@email.com', 'LLh', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Michael', 'Rogers', 'Michael.Rogers@email.com', 'Oleon', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Ki', 'Gee', 'Ki.Gee@email.com', 'LLh', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Hazel', 'Philtanker', 'Hazel.Philtanker@email.com', 'Stora Enzo', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Renske', 'Ladwig', 'Renske.Ladwig@email.com', 'Stora Enzo', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Stephen', 'Stiles', 'Stephen.Stiles@email.com', 'Ineo Fenol', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('John', 'Seo', 'John.Seo@email.com', 'Remotive', '0', '');
INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('Joshua', 'Patel', 'Joshua.Patel@email.com', 'SidMar', '0', '');

