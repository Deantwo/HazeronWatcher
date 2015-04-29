HazeronWatcher
==============

Online players monitor for [Shores of Hazeron](http://hazeron.com/).

Introduction
==============

My name is **Deantwo** and here in another one of my little C# programs.<br>
I only used about two days on this, so it is nothing major.<br>
I was inspired a lot by the contact window used in EVE Online, so I can't take total credit for the idea.

What is it
==============

**HazeronWatcher** is a simple little program written in C# that monitors the [Players Online](http://www.hazeron.com/playerson.html) page.<br>
It shows all players in a list and then allows you to set colors for each of them according to diplomatic relationship.<br>
You can also set a player to "Watch", which will make the program notify you when he/she comes online.

Requirements
==============

- .Net Framework 4.0<br>
(Standard on windows)
- Internet connection<br>
(access to [playerson](http://www.hazeron.com/playerson.html))

How to use
==============

**Adding offline avatars:**

1. Go to the [avatar list](http://www.hazeron.com/EmpireStandings2015/Avatars.html) on [www.Hazeron.com](http://www.Hazeron.com)
2. Get the ID of the avatar
3. Start **HazeronWatcher** (if you hadn't already)
4. Go to *Edit -> Add Player*
5. Enter the avatar's ID
6. Click OK

**Change notification sound:**

1. Open HazeronWatcher's AppData folder<br>
Windows: ```%USERPROFILE%\AppData\Roaming\HazeronWatcher```
2. Move the desired .wav file to the folder
3. Rename the file to ```notification.wav```

Features
==============

- Color code players so you can easily see them on the list (be it friend or foe)
- Get notifications when selected players come online
- Customizable notification sound

Planned
==============

- Hide watch list
- Writing of notes for characters
- Merging of characters/alts into one

Want to help
==============

I'd love some feedback and maybe some ideas.

Links
==============

- [GitHub](https://github.com/Deantwo/HazeronWatcher)
- [Hazeron Forum Thread](http://hazeron.com/phpBB3/viewtopic.php?f=124&t=7642)
