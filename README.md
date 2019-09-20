# Dead by Daylight Perk Background Tool
[![Build status](https://ci.appveyor.com/api/projects/status/mmwyqjfhildiv0vb/branch/master?svg=true)](https://ci.appveyor.com/project/secretdataz/dbdultrararemaker/branch/master)

Utility program to apply a background image to Dead by Daylight perk icons in bulk.

## Adding more perks
Information of chapters(paragraphs will also be called chapters here) and perks is stored in two files.
* Perks.json
    This file stores a JSON array of perk information including file name and the perk's actual display name.
```json
  {
    "PerkName": "calmSpirit", <---- iconPerks_calmSpirit.png becomes calmSpirit
    "DisplayName": "Calm Spirit" <---- Actual name
  }
```
* Chapters.json
    This file stores data about a chapter including, name, release order, BHVR's codename, and its associated perks in JSON format.
    You can add more chapter by appending the JSON array in the file.
    For example,
```json
  {
    "Path": "Qatar", <---- Subfolder for the chapter's perk. Also BHVR's codename.
    "DisplayName": "STRANGER THINGS", <---- Actual name
    "Number": 17, <---- Display order in the program
    "Perks": [ <---- Perk names from Perks.json
      "babysitter",
      "betterTogether",
      "camaraderie",
      "cruelConfinement",
      "fixated",
      "innerStrength",
      "mindBreaker",
      "secondWind",
      "surge"
    ]
  }
```

## License
See [LICENSE.md](LICENSE.md)

## Disclaimer
DBDPerkBackgroundTool isn't endorsed by any of it's content sources or Behaviour Interactive and doesn't reflect the views or opinions of them or anyone officially involved in producing or managing Dead by Daylight. Dead by Daylight is a trademark of Behaviour Interactive Inc.
