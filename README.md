# The Sims1 Legacy Collection Cheat Unlocker

**This has been archived in favor of: https://github.com/FaithBeam/Sims1LegacyCollectionHacks**

This unlocks debug mode cheats for The Sims 1 Legacy Collection. Click here for a list of cheats available: https://github.com/FaithBeam/The-Sims1-Legacy-Collection-Cheat-Unlocker/wiki

![image](https://github.com/user-attachments/assets/3b5d128a-fa9b-4bd4-9de1-eca7cd3ac2c6)

## Requirements

* Steam version of Sims 1 Legacy Collection
* This does **not** work for the EA version

## How to Patch

Video instructions: https://youtu.be/4ueyrQ3eLJo

1. Download [Steamless](https://github.com/atom0s/Steamless)
2. Extract .zip and run Steamless.exe
3. Select Sims.exe to unpack
4. Click Unpack File
5. Close Steamless
6. Optionally rename Sims.exe to Sims.exe.bak
7. Rename Sims.unpacked.exe to Sims.exe so when you run Sims from Steam, it chooses the correct Sims.exe
8. Download the latest [Sims1-Legacy-Collection-Debug-Cheat-Unlocker](https://github.com/FaithBeam/The-Sims1-Legacy-Collection-Cheat-Unlocker/releases)
9. Unzip the archive
10. Run Sims1-Legacy-Collection-Debug-Cheat-Unlocker.exe
11. Select the unpacked Sims.exe which should be Sims.exe at this point
12. Click Patch

### Linux How to Patch Notes

* Install Bottles or whatever to run Windows applications.
* Create a bottle to run Steamless
* Configure the bottle to show dotfiles
* Run Steamless within the created bottle

Video instructions: https://www.youtube.com/watch?v=KTQTk3mUCWA

### MacOs How to Patch Notes

Run Steamless with Kegworks Winery, Codeweavers Crossover, or Whiskey

Before step 10 run this command in terminal. Change the path to match new versions:
```bash
sudo xattr -r -d com.apple.quarantine ~/Downloads/Sims1-LC-Debug-Cheat-Unlocker.1.0.2+macOS.x64
```

### Notes

If the Patch button is grayed out, it means the program could not find the proper data to modify. Make sure you ran 
Steamless beforehand.

## How to Un-Patch

1. Run Sims1-Legacy-Collection-Debug-Cheat-Unlocker.exe
2. Select your Sims.exe
3. Click UnPatch

## Why do I need to run Steamless?

A portion of the Sims.exe provided by Steam is encrypted/packed which makes patching difficult or impossible. Steamless decrypts this 
data and allows for mod authors/hackers to tinker with the executable.

In the future I'll see if I can unpack the Sims.exe myself without Steamless.

## Build

You need .NET 9 SDK to build.

```bash
git clone https://github.com/FaithBeam/The-Sims1-Legacy-Collection-Cheat-Unlocker
cd The-Sims1-Legacy-Collection-Cheat-Unlocker
dotnet publish Sims1-Legacy-Collection-Debug-Cheat-Unlocker/Sims1-Legacy-Collection-Debug-Cheat-Unlocker.csproj -c Release -o artifacts -p:VersionPrefix=${{ env.PACK_VER }} -p:PublishSingleFile=true -p:SelfContained=true -p:DebugType=embedded -p:IncludeNativeLibrariesForSelfExtract=true -p:EnableCompressionInSingleFile=true -p:PublishTrimmed=true -p:RuntimeIdentifier=win-x64
````

The executable is in the bin folder.
