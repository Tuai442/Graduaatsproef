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

-- CREATE TABLE Afspraak (
--     afspraakId int IDENTITY,
--     startTijd Datetime not null,
--     eindTijd Datetime null,

--     werknemerId int,
--     bezoekerId int,
--     PRIMARY KEY (afspraakId),
--     FOREIGN KEY (werknemerId) REFERENCES Werknemer(werknemerId),
--     FOREIGN KEY (bezoekerId) REFERENCES Bezoeker(bezoekerId)
-- );


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


