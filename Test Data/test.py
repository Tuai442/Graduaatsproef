import pandas as pd

bedrijven = pd.read_csv("dummydata_bedrijven.csv")
afspraken = pd.read_csv("dummydata_afspraken.csv")
bezoekers = pd.read_csv("dummydata_bezoeker.csv")
werknemers = pd.read_csv("dummydata_werknemers.csv")

niew_afspr = pd.DataFrame()

niew_afspr["BezoekerVoornaam"] = afspraken["BezoekerVoornaam"]
niew_afspr["BezoekerAchternaam"] = afspraken["BezoekerAchternaam"]

niew_afspr["WerknemerVoornaam"] = werknemers["BezoekerAchtenaam"]
niew_afspr["WerknemerAchternaam"] = werknemers["BezoekerVoornaam"]

for row in bezoekers.iteritems():
    niew_afspr["BezoekerVoornaam"] = row["voornaam"]
    niew_afspr["BezoekerEmail"] = f"{row['voornaam']}.{row['achternaam']}@email.com"

for row in werknemers.iterrows():
    niew_afspr["WerknemerEmail"] = f"{row['voornaam']}.{row['achternaam']}@email.com"


print(niew_afspr)