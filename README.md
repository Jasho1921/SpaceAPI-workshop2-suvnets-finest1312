# SpaceAPI-workshop2-suvnets-finest1312
### API:er

> GET /api/space/satellite/{city}.jpg

> GET /api/space/satellite/all

> GET /api/space/funfact/{planet}

> GET /api/space/solarsystem/{planet}

> GET /api/space/weather


### JSON
/satellite/{city} OBS ENDAST METADATA, GÅR EJ RETURNERA JPG I JSON FORMAT
{

  "city": "Stockholm",

  "imageType": "satellite",

  "format": "jpg",

  "resolution": "1920x1080",

  "takenFrom": "Low Earth Orbit"

}


/satellite/all
{

   "satellites": [

   {

      "city": "Borås",

      "imageUrl": "/api/space/satellite/Boras.jpg

   },

   {

     "city": "Göteborg",

     "imageUrl": "/api/space/satellite/Goteborg.jpg"

   },
   {

     "city": "Stockholm",

     "imageUrl": "api/space/satellite/Stockholm.jpg"

   }

 ]

}

/funfact/{planet}
{

  "planet": "Mars",

  "funFact": "Mars har det största berget i hela solsystemet, Olympus Mons."

}

/solarsystem/{planet}
{

  "planet": "Jupiter",

  "type": "Gasjätte",

  "moons": 95,

  "diameterKm": 139820,

  "distanceFromSunKm": 778500000,

  "hasRings": true

}

/weather
{

  "weather": "Fint väder i rymden!"
  
}
