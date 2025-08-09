# Goob MRP has been archived
## I can not recommened forking EE in its current state, I recommened forking Wizard's Den, and starting with a clean slate.

<p align="center"> <img alt="Goob Station 14" width="880" height="300" src="https://github.com/Goob-Station/Goob-Station/blob/master/Resources/Textures/Logo/logo.png" /></p>

This is a fork from the primary repo for Einstein Engines.

Space Station 14 is inspired heavily by Space Station 13 and runs on [Robust Toolbox](https://github.com/space-wizards/RobustToolbox), a homegrown engine written in C#.
To prevent people forking RobustToolbox, a "content" pack is loaded by the client and server. This content pack contains everything needed to play the game on one specific server this is the content pack for Goob Station.

## Links

[Goob Station Discord Server](https://discord.gg/goobstation) | [Goob Station Forum](https://forums.goobstation.com/) | [Goob Station Website](https://goobstation.com)

## Documentation/Wiki

The Goob Station [docs site](https://docs.goobstation.com/) has documentation on GS14's content, engine, game design, and more. It also have lots of resources for new contributors to the project.

## Contributing

We are happy to accept contributions from anybody. Get in [Discord](https://discord.gg/goobstation) if you want to help. Feel free to check the [list of issues](https://github.com/Goob-Station/Goob-Station-MRP/issues) that need to be done and anybody can pick them up. Don't be afraid to ask for help either!
While Goob doesn't use the [contribution guidelines,](https://docs.spacestation14.com/en/general-development/codebase-info/pull-request-guidelines.html) you can feel free to if you want to check your stuff.

We are not currently accepting translations of the game on our main repository. If you would like to translate the game into another language consider contributing to our upstreams repo, [Einstein Engines](https://github.com/Simple-Station/Einstein-Engines)

### [Einstein Engines](https://github.com/Simple-Station/Einstein-Engines)

Einstein Engines is a hard fork of [Space Station 14](https://github.com/space-wizards/space-station-14) built around the ideals and design inspirations of the Baystation family of servers from Space Station 13 with a focus on having modular code that anyone can use to make the RP server of their dreams.
Our founding organization is based on a democratic system whereby our mutual contributors and downstreams have a say in what code goes into their own upstream.
If you are a representative of a former downstream of Delta-V, we would like to invite you to contact us for an opportunity to represent your fork in this new upstream.

### EE Links

[Website](https://simplestation.org) | [Discord](https://discord.gg/X4QEXxUrsJ) | [Steam(SSMV Launcher)](https://store.steampowered.com/app/2585480/Space_Station_Multiverse/) | [Steam(WizDen Launcher)](https://store.steampowered.com/app/1255460/Space_Station_14/) | [Standalone](https://spacestationmultiverse.com/downloads/)

### Building

Refer to [the Space Wizards' guide](https://docs.spacestation14.com/en/general-development/setup/setting-up-a-development-environment.html) on setting up a development environment for general information, but keep in mind that Einstein Engines is not the same and many things may not apply.
We provide some scripts shown below to make the job easier.

### Build dependencies

> - Git
> - .NET SDK 9.0.101


### Windows

> 1. Clone this repository
> 2. Run `git submodule update --init --recursive` in a terminal to download the engine
> 3. Run `Scripts/bat/buildAllDebug.bat` after making any changes to the source
> 4. Run `Scripts/bat/runQuickAll.bat` to launch the client and the server
> 5. Connect to localhost in the client and play

### Linux

> 1. Clone this repository
> 2. Run `git submodule update --init --recursive` in a terminal to download the engine
> 3. Run `Scripts/sh/buildAllDebug.sh` after making any changes to the source
> 4. Run `Scripts/sh/runQuickAll.sh` to launch the client and the server
> 5. Connect to localhost in the client and play

### MacOS

> I don't know anybody using MacOS to test this, but it's probably roughly the same steps as Linux

## License

Please read the [LEGAL.md](./LEGAL.md) file for information on the licenses of the code and assets in this repository.
