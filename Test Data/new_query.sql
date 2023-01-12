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
	actief bit not null DEFAULT 1,

    werknemerId int,
    bezoekerId int,

    PRIMARY KEY (afspraakId),
    FOREIGN KEY (werknemerId) REFERENCES Werknemer(werknemerId),
    FOREIGN KEY (bezoekerId) REFERENCES Bezoeker(bezoekerId)
);



INSERT INTO Bedrijf (Naam, btwNummer, Email, Adres, Telefoon) VALUES ('Browsebug', 'BE 0202.239.951', 'cwycliff0@creativecommons.org', '4 Charing Cross Place', '0487788759');
INSERT INTO Bedrijf (Naam, btwNummer, Email, Adres, Telefoon) VALUES ('Tagcat', 'BE 0202.239.951', 'gfivey1@youku.com', '92 Hallows Trail', '0487788759');
INSERT INTO Bedrijf (Naam, btwNummer, Email, Adres, Telefoon) VALUES ('Devshare', 'BE 0202.239.951', 'jthornton2@miitbeian.gov.cn', '535 Merrick Plaza', '0487788759');
INSERT INTO Bedrijf (Naam, btwNummer, Email, Adres, Telefoon) VALUES ('Topiczoom', 'BE 0202.239.951', 'powain3@theguardian.com', '53002 Anzinger Way', '0487788759');
INSERT INTO Bedrijf (Naam, btwNummer, Email, Adres, Telefoon) VALUES ('Agivu', 'BE 0202.239.951', 'rochterlony4@opensource.org', '94734 Tomscot Hill', '0487788759');
INSERT INTO Bedrijf (Naam, btwNummer, Email, Adres, Telefoon) VALUES ('Tazz', 'BE 0202.239.951', 'lgiorgini5@prlog.org', '73 Monument Park', '0487788759');
INSERT INTO Bedrijf (Naam, btwNummer, Email, Adres, Telefoon) VALUES ('Divape', 'BE 0202.239.951', 'abazire6@cyberchimps.com', '87643 Leroy Terrace', '0487788759');
INSERT INTO Bedrijf (Naam, btwNummer, Email, Adres, Telefoon) VALUES ('Voonyx', 'BE 0202.239.951', 'kbrendel7@mediafire.com', '72 Crescent Oaks Avenue', '0487788759');
INSERT INTO Bedrijf (Naam, btwNummer, Email, Adres, Telefoon) VALUES ('LiveZ', 'BE 0202.239.951', 'kattride8@dell.com', '26 Carey Road', '0487788759');
INSERT INTO Bedrijf (Naam, btwNummer, Email, Adres, Telefoon) VALUES ('Livepath', 'BE 0202.239.951', 'hglidder9@chronoengine.com', '09 Golf View Plaza', '0487788759');


INSERT INTO Werknemer (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Donald', 'OConnell', 'Donald.OConnell@email.com', 'SH_CLERK', '7');
INSERT INTO Werknemer (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Douglas', 'Grant', 'Douglas.Grant@email.com', 'SH_CLERK', '10');
INSERT INTO Werknemer (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Jennifer', 'Whalen', 'Jennifer.Whalen@email.com', 'AD_ASST', '4');
INSERT INTO Werknemer (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Michael', 'Hartstein', 'Michael.Hartstein@email.com', 'MK_MAN', '5');
INSERT INTO Werknemer (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Pat', 'Fay', 'Pat.Fay@email.com', 'MK_REP', '8');
INSERT INTO Werknemer (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Susan', 'Mavris', 'Susan.Mavris@email.com', 'HR_REP', '1');
INSERT INTO Werknemer (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Hermann', 'Baer', 'Hermann.Baer@email.com', 'PR_REP', '9');
INSERT INTO Werknemer (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Shelley', 'Higgins', 'Shelley.Higgins@email.com', 'AC_MGR', '4');
INSERT INTO Werknemer (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('William', 'Gietz', 'William.Gietz@email.com', 'AC_ACCOUNT', '10');
INSERT INTO Werknemer (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Steven', 'King', 'Steven.King@email.com', 'AD_PRES', '10');
INSERT INTO Werknemer (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Neena', 'Kochhar', 'Neena.Kochhar@email.com', 'AD_VP', '4');
INSERT INTO Werknemer (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Lex', 'De Haan', 'Lex.DeHaan@email.com', 'AD_VP', '5');
INSERT INTO Werknemer (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Alexander', 'Hunold', 'Alexander.Hunold@email.com', 'IT_PROG', '4');
INSERT INTO Werknemer (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Bruce', 'Ernst', 'Bruce.Ernst@email.com', 'IT_PROG', '10');
INSERT INTO Werknemer (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('David', 'Austin', 'David.Austin@email.com', 'IT_PROG', '7');
INSERT INTO Werknemer (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Valli', 'Pataballa', 'Valli.Pataballa@email.com', 'IT_PROG', '1');
INSERT INTO Werknemer (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Diana', 'Lorentz', 'Diana.Lorentz@email.com', 'IT_PROG', '5');
INSERT INTO Werknemer (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Nancy', 'Greenberg', 'Nancy.Greenberg@email.com', 'FI_MGR', '5');
INSERT INTO Werknemer (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Daniel', 'Faviet', 'Daniel.Faviet@email.com', 'FI_ACCOUNT', '7');
INSERT INTO Werknemer (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('John', 'Chen', 'John.Chen@email.com', 'FI_ACCOUNT', '7');
INSERT INTO Werknemer (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Ismael', 'Sciarra', 'Ismael.Sciarra@email.com', 'FI_ACCOUNT', '6');
INSERT INTO Werknemer (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Jose Manuel', 'Urman', 'JoseManuel.Urman@email.com', 'FI_ACCOUNT', '5');
INSERT INTO Werknemer (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Luis', 'Popp', 'Luis.Popp@email.com', 'FI_ACCOUNT', '1');
INSERT INTO Werknemer (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Den', 'Raphaely', 'Den.Raphaely@email.com', 'PU_MAN', '7');
INSERT INTO Werknemer (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Alexander', 'Khoo', 'Alexander.Khoo@email.com', 'PU_CLERK', '8');
INSERT INTO Werknemer (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Shelli', 'Baida', 'Shelli.Baida@email.com', 'PU_CLERK', '6');
INSERT INTO Werknemer (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Sigal', 'Tobias', 'Sigal.Tobias@email.com', 'PU_CLERK', '6');
INSERT INTO Werknemer (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Guy', 'Himuro', 'Guy.Himuro@email.com', 'PU_CLERK', '4');
INSERT INTO Werknemer (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Karen', 'Colmenares', 'Karen.Colmenares@email.com', 'PU_CLERK', '9');
INSERT INTO Werknemer (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Matthew', 'Weiss', 'Matthew.Weiss@email.com', 'ST_MAN', '5');
INSERT INTO Werknemer (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Adam', 'Fripp', 'Adam.Fripp@email.com', 'ST_MAN', '3');
INSERT INTO Werknemer (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Payam', 'Kaufling', 'Payam.Kaufling@email.com', 'ST_MAN', '7');
INSERT INTO Werknemer (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Shanta', 'Vollman', 'Shanta.Vollman@email.com', 'ST_MAN', '5');
INSERT INTO Werknemer (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Kevin', 'Mourgos', 'Kevin.Mourgos@email.com', 'ST_MAN', '4');
INSERT INTO Werknemer (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Julia', 'Nayer', 'Julia.Nayer@email.com', 'ST_CLERK', '7');
INSERT INTO Werknemer (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Irene', 'Mikkilineni', 'Irene.Mikkilineni@email.com', 'ST_CLERK', '6');
INSERT INTO Werknemer (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('James', 'Landry', 'James.Landry@email.com', 'ST_CLERK', '9');
INSERT INTO Werknemer (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Steven', 'Markle', 'Steven.Markle@email.com', 'ST_CLERK', '10');
INSERT INTO Werknemer (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Laura', 'Bissot', 'Laura.Bissot@email.com', 'ST_CLERK', '9');
INSERT INTO Werknemer (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Mozhe', 'Atkinson', 'Mozhe.Atkinson@email.com', 'ST_CLERK', '4');
INSERT INTO Werknemer (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('James', 'Marlow', 'James.Marlow@email.com', 'ST_CLERK', '6');
INSERT INTO Werknemer (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('TJ', 'Olson', 'TJ.Olson@email.com', 'ST_CLERK', '5');
INSERT INTO Werknemer (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Jason', 'Mallin', 'Jason.Mallin@email.com', 'ST_CLERK', '8');
INSERT INTO Werknemer (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Michael', 'Rogers', 'Michael.Rogers@email.com', 'ST_CLERK', '10');
INSERT INTO Werknemer (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Ki', 'Gee', 'Ki.Gee@email.com', 'ST_CLERK', '2');
INSERT INTO Werknemer (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Hazel', 'Philtanker', 'Hazel.Philtanker@email.com', 'ST_CLERK', '6');
INSERT INTO Werknemer (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Renske', 'Ladwig', 'Renske.Ladwig@email.com', 'ST_CLERK', '7');
INSERT INTO Werknemer (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Stephen', 'Stiles', 'Stephen.Stiles@email.com', 'ST_CLERK', '9');
INSERT INTO Werknemer (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('John', 'Seo', 'John.Seo@email.com', 'ST_CLERK', '6');
INSERT INTO Werknemer (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('Joshua', 'Patel', 'Joshua.Patel@email.com', 'ST_CLERK', '8');

