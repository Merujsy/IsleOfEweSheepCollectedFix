# Straight to playing

Download the Assembly-CSharp.dll file and replace the original one in your game directory "...\steamapps\common\Isle of Ewe\Isle Of Ewe_Data\Managed".

# Creating the dll yourself

1. Setup Visual Studio
2. Start default console app for C#
3. Use NuGet Package Manager Console to get the required asmResolver dependencies: https://github.com/Washi1337/AsmResolver
```
Install-Package AsmResolver -Version 4.11.2
Install-Package AsmResolver.PE -Version 4.11.2
```

4. Copy code from Program.cs
5. Edit the source and destination paths.
6. Put the #US.bin file where you will generated the new dll.
7. Run the console app (and close the program by pressing "enter")
8. Overwrite the source dll with your newly generated version.

The #US.bin file was generated by reading out the original UserStrings and saving it to a file.
I used a hex editor (plugin in Notepad++) to modify "CollectedSheep" to "SheepCollected".
