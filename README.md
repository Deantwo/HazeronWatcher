HazeronWatcher
==============

Online players monitor for [Shores of Hazeron](https://www.hazeron.com/).

Introduction
==============

My name is **Deantwo** and here in another one of my little C# programs.<br>
I only used about two days on this, so it is nothing major.<br>
I was inspired a lot by the contact window used in EVE Online, so I can't take total credit for the idea.

What is it
==============

**HazeronWatcher** is a simple little program written in C# that monitors the [Players Online](https://www.hazeron.com/playerson.php) webpage.<br>
It shows all online avatars in a list and then allows adding them to watch groups with custom colors and custom online notification sounds.

Requirements
==============

- .Net Framework 4.7.2<br>
(Standard on windows)
- Internet connection<br>
(access to [playerson](https://www.hazeron.com/playerson.php))

How to use
==============

**Adding offline avatars:**

1. Go to the [avatar list](https://www.hazeron.com/EmpireStandings/Avatars.php) on [www.Hazeron.com](https://www.hazeron.com)
2. Get the ID of the avatar
3. Start **HazeronWatcher** (if you hadn't already)
4. Click the *Add avatar via ID* button above the watchlist
5. Enter the avatar's ID
6. Click OK

**Custom notification sound:**

1. Open HazeronWatcher's AppData folder<br>
*File -> Open AppData Folder*<br>
Windows: ```%USERPROFILE%\AppData\Roaming\HazeronWatcher```
2. Move or copy the desired .wav file to the folder

Features
==============

- List all online avatars
- List all recently online avatars
- Create watch groups and add avatars to them
- Get notifications when selected avatars come online
- Customizable notification sounds
- Writing of notes for avatars

Planned
==============

- Add empires to watch groups
- Add empire flags
- Merging of characters/alts into one

Want to help
==============

I'd love some feedback and maybe some ideas.

Links
==============

- [GitHub](https://github.com/Deantwo/HazeronWatcher)
- [Hazeron Forum Thread](https://www.hazeron.com/mybb/showthread.php?tid=25)
