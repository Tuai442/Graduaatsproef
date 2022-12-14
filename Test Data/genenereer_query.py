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
        insert_query = f"INSERT INTO Bedrijf (naam, btwNummer, email, adres, telefoon, actief) VALUES ('{r[1]}', '{r[2]}', '{r[3]}', '{r[4]}', '{r[5]}', '1');"

        new_file.write(insert_query)
        new_file.write("\n")

    new_file.write("\n")
    new_file.write("\n")
    # Werknemers
    for row in werknemers.iterrows():
        r = row[1]
        vn = r[1].replace(" ", "")
        an = r[2].replace(" ", "")
        email = f"{vn}.{an}@email.com".replace(" ", "")
        insert_query = f"INSERT INTO Werknemer (voornaam, achternaam, email, functie, bedrijfId, actief) VALUES ('{r[1]}', '{r[2]}', '{email}', '{r[4]}', '{r[5]}', '1');"

        new_file.write(insert_query)
        new_file.write("\n")

    new_file.write("\n")
    new_file.write("\n")
    random_bezoeker_bedrijven = ["Remotive", "Oleon", "Vpk", "Stora Enzo", "Ineo Fenol", "LLh", "SidMar", "Aligist Bruggeman"]
    # Bezoekers
    for row in werknemers.iterrows():
        r = row[1]
        vn = r[1].replace(" ", "")
        an = r[2].replace(" ", "")
        email = f"{vn}.{an}@email.com"
        bedrijf = random_bezoeker_bedrijven[random.randint(0, len(random_bezoeker_bedrijven) - 1)]
        insert_query = f"INSERT INTO Bezoeker (voornaam, achternaam, email, bedrijf, aanwezig, nummerplaat) VALUES ('{r[1]}', '{r[2]}', '{email}', '{bedrijf}', '0', '');"

        new_file.write(insert_query)
        new_file.write("\n")

    new_file.write("\n")
    new_file.write("\n")
    bezoekers_aantal = len(werknemers) - 1
    for row in afspraken.iterrows():
        r = row[1]
        vn = r[1].replace(" ", "")
        an = r[2].replace(" ", "")
        email = f"{vn}.{an}@email.com".replace(" ", "")
        random_bezoekers_id = random.randint(1, bezoekers_aantal)
        insert_query = f"INSERT INTO Afspraak (startTijd, eindTijd, werknemerId, bezoekerId )" \
                       f" VALUES ('{r[4]}', '{r[5]}', '{r[7]}', '{random_bezoekers_id}');"

        new_file.write(insert_query)
        new_file.write("\n")

    new_file.close()


