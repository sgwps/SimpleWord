import requests
from bs4 import BeautifulSoup
import csv

arrsoup = []
b = "abcdefghijklmnopqrstuvyxyz"

for i in range(0, 26):
    URL = f"https://en.wikipedia.org/wiki/ISO_639:{b[i]}"
    r = requests.get(URL)
    arrsoup.append(BeautifulSoup(r.content, 'html5lib'))

res = list()

for i in range(0, 26):
    table = arrsoup[i].find_all('table')[0]
    rows = table.find_all('tr')
    for row in rows:
        row = row.find_all(['th', 'td'])
        temp = list()
        for elem in row:
            if elem.find_all('a'):
                temp.append(elem.find_all('a')[0].contents[0])
            else:
                if elem.contents:
                    temp.append(elem.contents[0])
                else:
                    temp.append("")
        # res.append(row[0].find_all('a')[0].contents[0])
        res.append(temp)

with open('res.csv', 'w', newline='') as csvfile:
    writer = csv.writer(csvfile, delimiter=',', quoting=csv.QUOTE_MINIMAL)
    for row in res:
        writer.writerow(row)