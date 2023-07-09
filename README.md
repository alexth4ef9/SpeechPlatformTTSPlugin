# SpeechPlatformTTSPlugin

An ACT plugin to use TTS on Linux.

# Dependencies

- Wineprefix with .NET 4.8 (winetricks dotnet48)

- Runtime: http://web.archive.org/web/20180324173437/https://www.microsoft.com/en-us/download/confirmation.aspx?id=27225

  Depending on winearch x86 or x64.

- SDK: http://web.archive.org/web/20180304124818/https://www.microsoft.com/en-us/download/confirmation.aspx?id=27226

  Depending on winearch x86 or x64. Use default install location.

- TTS Voice: http://web.archive.org/web/20180304122215/https://www.microsoft.com/en-us/download/confirmation.aspx?id=27224

  At least one of the files with TTS in name (e.g. MSSpeech_TTS_en-US_ZiraPro.msi).
 
- NAudio (build for .NET 4.7.2): https://github.com/alexth4ef9/NAudio/releases/download/v2.1.0_net472_wine/NAudio-v2.10_net472_wine.tar.xz

  Unpack to drive_c/Program Files (DLL are in drive_c/Program Files/NAudio/)
 
# Installation

Drop SpeechPlatformTTSPlugin.cs into drive_c/users/< username >/AppData/Roaming/Advanced Combat Tracker/Plugins/

In ACT goto plugin tab, browse for the file and hit Add/Enable Plugin.

# Compiling/Debugging

Windows installation with Visual Studio 2022 is required.
Install the above dependencies and ACT (default location).

Following files are required in SpeechPlatformTTSPlugin/ExternalLibraries:

- C:\Program Files\NAudio\\*.dll
- C:\Program Files\Microsoft SDKs\Speech\v11.0\Assembly\Microsoft.Speech.dll
- C:\Program Files (x86)\Advanced Combat Tracker\Advanced Combat Tracker.exe
 
Insert into SpeechPlatformTTSPlugin\SpeechPlatformTTSPlugin.csproj.user:

    <PropertyGroup Condition="'$(Configuration)|$(Platform)' == 'Debug|AnyCPU'">
        <StartAction>Program</StartAction>
        <StartProgram>C:\Program Files (x86)\Advanced Combat Tracker\Advanced Combat Tracker.exe</StartProgram>
    </PropertyGroup>

In ACT the SpeechPlatformTTSPlugin.dll must be selected as plugin (not SpeechPlatformTTSPlugin.cs).
