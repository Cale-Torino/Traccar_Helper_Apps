# server config
base_url = "http://server:8082"
username = "admin"
password = "admin"

# export config
name = "Test export"
description = "my export"
from_date = "2021-04-01" # YYYY-MM-DD
to_date = "2021-05-01"
filename = "april"

# ---------------------------------

# imports
import urllib.request
import json
from datetime import datetime

# ---------------------------------

# login stuff
password_mgr = urllib.request.HTTPPasswordMgrWithDefaultRealm()
password_mgr.add_password(None, base_url, username, password)
handler = urllib.request.HTTPBasicAuthHandler(password_mgr)
opener = urllib.request.build_opener(handler)
opener.open(base_url)
urllib.request.install_opener(opener)

# api call
request_url = f"{base_url}/api/reports/route?_dc=1619800977916&deviceId=1&type=allEvents&from={from_date}T00%3A00%3A00%2B02%3A00&to={to_date}T00%3A00%3A00%2B02%3A00&daily=false&mail=false"
req = urllib.request.urlopen(request_url)
points = json.loads(req.read())

# gpx generation
with open(f'{filename}.gpx', 'w', encoding='utf8') as gpx:

    # header
    gpx.write(r'<?xml version="1.0" encoding="UTF-8" ?>' + "\n")
    gpx.write(r'<gpx version="1.1" creator="{username}" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://www.topografix.com/GPX/1/1" xsi:schemaLocation="http://www.topografix.com/GPX/1/1 http://www.topografix.com/GPX/1/1/gpx.xsd">' + "\n\n")

    # metadata
    gpx.write("<metadata>\n")
    gpx.write(f'    <name>{name}</name>\n')
    gpx.write(f'    <time>{datetime.now()}Z</time>\n')
    gpx.write(f'    <desc>{description} - Start: {from_date} (0:00) - End: {to_date} (0:00)</desc>\n')
    gpx.write("</metadata>\n\n")

    # track
    gpx.write('<trk>\n<trkseg>\n\n')
    for point in points:
        if point["valid"]:
            gpx.write(f'<trkpt lat="{point["latitude"]}" lon="{point["longitude"]}">\n')
            gpx.write(f'    <time>{point["deviceTime"].replace("+00:00", "")}Z</time>\n')
            gpx.write(f'    <speed>{point["speed"]}</speed>\n')
            gpx.write(f'    <course>{point["course"]}</course>\n')
            gpx.write('</trkpt>\n\n')

    # end
    gpx.write('</trkseg>\n</trk>\n')
    gpx.write('</gpx>\n')