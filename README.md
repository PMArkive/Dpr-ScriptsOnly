# opendpr

This is a totally reverse engineering recreation of the Pokémon Brilliant Diamond and Shinning Pearl Unity Project.

## Setup

This project is intended to be opened with Unity 2019.4.27f1. It is the Unity version BDSP is built on and will keep issues to a minimum.
To properly set up this project, you must first dump YOUR OWN game of Pokémon Brilliant Diamond (untested on Pokémon Shining Pearl but should theoredically work).
Using that dump, -TODO-

## FAQ

### Is this a "decomp"?

Not quite. There are a few reasons why it's not "technically" a decompilation.
- The game was compiled through IL2CPP, which makes it very difficult to compare the resulting assembly and assure a "matching" decompilation.
- The game uses an SDK that is only given to Nintendo-approved developers, which we do not have access to.
