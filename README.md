# CS-GO-Aimbot-ESP
Research project into how hackers cheat in online games

As a CS:GO player my friends and I are constantly frustrated by the amount of hackers in the game, but as a coder I'm curious as to how they acheieve this programatically, so built my own as a reasearch project into how aimbots/esp hacks work.

There are two builds:
1. A winforms version that uses a directx library for drawing over the game.
2. A WPF version that uses built-in drawing functions to draw over the game.
3. libSodium - A from scratch rewrite using the best parts of the two above projects and better code practices.

Main features are:
1. Aimbot (can aim at different parts of the player skeleton, within an adjustable fov and with adjustable aimspeed etc to look more realistic/human like)
2. ESP (draw box/circle around players through walls.
3. Recoil/Spray pattern compensation.
4. Trigger bot (fire as player passes through crosshair)

The code in the first two projects is messy but works, the libsodium rewrite is much more readable so I would only recommend looking at the first two projects as a reference in how my coding style has changed over time.

Not for use online, you will get banned and rightly so.
Many bots were harmed in the making of this app.
