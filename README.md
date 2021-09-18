# 🚀 Rocket Network
**Rocket Network** allows Rocket League players to play LAN matches over the Internet.

# Why did you make it?
I don't live in Europe, yet my country's ISPs are all routed through Europe.
This leads some players, like my friends, to get a latency between 60ms and 120ms.
At the same time, when playing in local servers, they could get 10ms pings.
We all just wanted to play a private match with normal latency, and Rocket League has a LAN Match option...

# How did you make it?
Analyzed their packets, while finding someone who already did the exact same thing in a small piece of code.
Then, I took their code and improved it by updating it to the latest protocol.
After a few weeks I rewrote that part of the code, keeping most of the important things in it intact.

# Is it legal?
*It is legal* to capture and reverse enginneer the packets under the current (and past) law in my country.
It *may* not be EULA-compliant to use this software, so you should always check for that.

# Why is it open source?
Originally, it was not. 
I decided to release it since it's one of the projects I loved most.
I ceased using (and developing) it a long time ago, and it's a shame to not enrich others with this idea.
Also, I really couldn't found a large enough audience for it to be worth developing any longer.

# What is RNAU?
RNAU is a small utility I included with **Rocket Network** to make it auto-update.
It's probably not the best of codes, but it's simple and works.
I learned *a lot* by making it.

# Issues
- The current `PacketFaker.cs` may be outdated, since there might have been a lot of changes to the Rocket League protocol.
- I didn't really touch this code since October 2019, when I was much less of a programmer.
- It requires WinPCap to function.
- It uses WinForms. WinForms are just yuck. I love them though. 🤷‍♂️
- There's `NetworkSimulator.cs` which should replace `PacketFaker` in the future. That future never arrived.

# Future Plans
There are no future plans for **Rocket Network** currently.

# But I want to contribute!
Awesome! I'll be happy to merge pull requests to this repository, if the code added is of a high quality.
I even had some ideas I might be willing to share - and maybe even implement myself - if there's a big enough audience, and/or enough contributors.

<sup>Hey, if you're the guy who made the original code for the PacketFaker, please message me. I can't find it or remember where I got it from.</sup>
