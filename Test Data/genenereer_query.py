from hashlib import new
import pandas as pd
import random


NEW_QUERY = "new_query.sql"

werknemers = pd.read_csv("dummydata_werknemers.csv")
bedrijven = pd.read_csv("dummydata_bedrijven.csv")
afspraken = pd.read_csv("dummydata_afspraken.csv")



with open(NEW_QUERY, "w") as new_file:
    new_file.truncate(0)
    with open("query.sql", "r") as file:
        for line in file.readlines():
            new_file.write(line)
        file.close()
    
    new_file.write("\n")
    new_file.write("\n")
    for row in bedrijven.iterrows():
        r = row[1]
        insert_query = f"INSERT INTO Bedrijf (Naam, btwNummer, Email, Adres, Telefoon) VALUES ('{r[1]}', 'BE 0202.239.951', '{r[3]}', '{r[4]}', '0487788759');"

        new_file.write(insert_query)
        new_file.write("\n")

    new_file.write("\n")
    new_file.write("\n")
    for row in werknemers.iterrows():
        r = row[1]
        email = f"{r[1]}.{r[2]}@email.com".replace(" ", "")
        insert_query = f"INSERT INTO Werknemer (Voornaam, Achternaam, Email, Functie, BedrijfId) VALUES ('{r[1]}', '{r[2]}', '{email}', '{r[4]}', '{r[5]}');"

        new_file.write(insert_query)
        new_file.write("\n")

    new_file.write("\n")
    new_file.write("\n")
    for row in afspraken.iterrows():
        r = row[1]
        randomIndex = random.randint(0, len(bedrijven))
        bedrijfNaamArr = bedrijven[bedrijven["BedrijfId"] == randomIndex]["Naam"]
        bedrijfNaam = ""

        print(bedrijfNaam)
        insert_query = f"INSERT INTO Afspraak ( Email, StartTijd, EindTijd, WerknemerId ) VALUES ('{r[1]}', '{r[2]}', '{bedrijfNaam}', '{r[3]}', '{r[4]}', '{r[5]}', '{r[7]}');"

        new_file.write(insert_query)
        new_file.write("\n")

    new_file.close()


