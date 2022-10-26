import pandas as pd

bedrijven = pd.read_csv("dummydata_bedrijven.csv")
afspraken = pd.read_csv("dummydata_afspraken.csv")
print(bedrijven)
print(afspraken)

merger = pd.DataFrame(pd.merge(afspraken, bedrijven, on="BedrijfId")["BedrijfId"])

print(type(merger))
print(merger.columns)
bedrijfNaam = merger[merger["BedrijfId"] == 1]
print(bedrijfNaam)
