# ScrapMechanicBlueprintImageCreator
Takes images and turns them into blueprints you can then spawn in your Scrap Mechanic World

Scrap Mechanic Blueprint Image Creator (SMBIC)

Installing:
1. Download SMBIC.zip from [releases](https://github.com/Nova1545/ScrapMechanicBlueprintImageCreator/releases/tag/1.0)
2. Unzip SMBIC.zip
3. Run SMBlueprintImageCreator

Normal Use:
1. Select image of choice
2. Pick size (between 0 and 256) for both width and height
3. Click Create!
4. Open Scrap Mechanic and search for the name of the blueprint in your lift

Other Use:
This is in the case where you have installed Scrap Mechanic to somewhere else other than C:\Program Files\Steam\steamapps\common
1. Hit "Set Game Dir" and navigate to where you installed Scrap Mechanic, select its folder and hit ok
2. Select image of choice
3. Pick size (between 0 and 256) for both width and height
4. Click Create!
5. Open Scrap Mechanic and search for the name of the blueprint in your lift

Video: Coming soon

QA:

Q: Why is the size of the blueprinted image limited to 256x256?

A: For some reason anything larger than this and the game simply wont load the blueprint, I dont know why and Ive tried to get around this but have yet to find a way

Q: What is the BlocksCache.json file for?

A: To promote speed and so I dont have to manualy add the blocks the game has, SMBIC will create a json file containing all of the blocks (Wood, Metal, Concreate) with names and UUID's (Way the game and mods identify blocks and parts)

Q: Have a suggestion or having troubles with SMBIC?

A: Create an issue through github with your problem or suggestion

Q: Game update? New Blocks added? Want to use them for the building block of your image?

A: Simply just delete the BlocksCache.json file and restart the SMBIC
