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
