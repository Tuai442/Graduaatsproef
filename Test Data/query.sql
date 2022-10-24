DROP TABLE Werknemers;
DROP TABLE Bedrijven;
DROP TABLE Afspraken;

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
