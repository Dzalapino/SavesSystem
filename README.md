# SavesSystem
Saves system made in the Unity 3D game engine

First you will be prompted to type UserName. You can pick one of the existing in the Saves folder or choose a new one.
If you will choose a new one you will be asked if you want to create a new player.
After clicking start button you will be able to walk to the 2 vendors. 
If you will come close to one of them they will be highlighted in yellow. Then you will be able to click left mouse button to gain:
Experience - from the vendor on the left,
Income - from the vendor on the right.
To see your stats click the button on the top right corner with the question mark.
If you click it you will be able to overwrite the save with the new data or reload last saved data.
You can choose the cloud storage too but it is currently mocked so it will only be visible from the unity editor in console.
Quit button will probably work only if used in the builded executable.

If it comes to serialization currently in scripts is used the JSON method but there is also the XML serialization option.
To try the XML serialization go to the Assets/Scripts/Utilities/LocalStorage.cs and replace line 8 with the:
private static readonly IDataSerializer dataSerializer = new XmlDataSerializer();
and then in the line 47 replace ".json" with ".xml"