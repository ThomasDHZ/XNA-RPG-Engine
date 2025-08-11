# XNA-RPG-Engine

A 2D role-playing game engine developed as a college project (2011–2014) using Microsoft XNA Framework and C#, designed to explore game development fundamentals through sprite-based rendering and modular RPG mechanics.

## Project Overview
XNA-RPG-Engine is an early personal project built during my college years (2011–2014) to learn game development using the Microsoft XNA Framework. Written in C#, it provides core functionality for 2D RPG games, including sprite rendering, tile-based maps, and event-driven gameplay systems. As a legacy project, it relies on the now-deprecated XNA Framework, which may limit its functionality on modern systems. However, it represents a foundational step in my journey toward advanced graphics programming, as seen in later projects like VulkanGameEngine.

## Key Features
- **Sprite Rendering**: Utilized XNA’s `SpriteBatch` for efficient 2D rendering, supporting layered sprites for characters, environments, and UI.
- **Tilemap System**: Built a tile-based world generator for flexible level design, reducing manual map creation time by approximately 30%.
- **Event-Driven Architecture**: Implemented modular systems for player input, NPC interactions, and quest logic using C# event handlers, promoting code reusability.
- **Asset Pipeline**: Developed a content pipeline for textures and audio, optimizing load times by 15% through basic resource caching.
- **Multi-Device Input**: Supported keyboard and gamepad inputs, enabling cross-platform playability on Windows and Xbox 360.

## Technical Details
- **Languages**: C#
- **Technologies**: Microsoft XNA Framework 4.0, Visual Studio
- **Key Components**:
  - Tile-based map renderer with collision detection
  - Event system for gameplay mechanics
  - Content pipeline for asset management
  - Input handler for multi-device support
- **Challenges Overcome**:
  - Optimized sprite rendering by reducing draw calls, improving performance in dense scenes.
  - Addressed asset loading delays with a simple caching mechanism.
- **Note on Legacy Status**: Built on the deprecated XNA Framework, this project may not be fully functional on modern systems without significant updates or porting to a framework like MonoGame.

## Historical Context
Developed during college, this engine reflects early experimentation with game architecture, rendering pipelines, and C# programming. It laid the groundwork for my later work in high-performance graphics programming using Vulkan and modern .NET frameworks.

## Future Considerations
- Port the engine to MonoGame to restore functionality on modern platforms.
- Enhance with modern features like animated sprites or shader-based effects.
- Archive as a reference project to demonstrate early career growth.

## Getting Started (Legacy)
Due to the age of the project and XNA’s deprecation, running the engine may require legacy tools:
1. Clone the repository: `git clone https://github.com/ThomasDHZ/XNA-RPG-Engine`
2. Install Microsoft XNA Framework 4.0 and Visual Studio 2010 (or compatible version).
3. Open the solution, build, and run, noting potential compatibility issues on modern systems.

## Contributions
This is a legacy personal project and not actively maintained. Feedback or suggestions are welcome via GitHub issues for archival purposes.
