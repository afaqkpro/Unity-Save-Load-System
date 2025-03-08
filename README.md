# Unity Save/Load System

This Unity project provides a simple save/load system for storing and retrieving the player's data, including position, rotation, and health. The system is triggered by pressing specific keys to save and load the game state.

## Features
- Save the player's position, rotation, and health.
- Load the saved player data, restoring position, rotation, and health.
- Keyboard input (`O` for saving, `P` for loading).
- Uses JSON format to save game data.

## How to Use

1. **Install the Input System:**
   - Open **Package Manager** in Unity (`Window > Package Manager`).
   - Search for and install the **Input System** package.

2. **Import Scripts:**
   - Import the following C# scripts into your Unity project:
     - `PlayerSaveData.cs`
     - `SaveData.cs`
     - `SaveGameManager.cs`

3. **Assign the PlayerSaveData Script:**
   - Attach the `PlayerSaveData` script to your player GameObject.
   - In the Unity Inspector, assign the `Healthcontroller` component to the `healthController` field of the `PlayerSaveData` script.

4. **How to Save and Load:**
   - **Press `O`** to save the current game state (position, rotation, health).
   - **Press `P`** to load the saved game state and restore the player's position, rotation, and health.

## How It Works

- **Saving**: 
  When you press the `O` key, the player's position, rotation, and health are saved to a JSON file (`SaveGame.sav`) in the application's persistent data directory. The game state is serialized into JSON format and written to this file.

- **Loading**: 
  When you press the `P` key, the game loads the saved data from the JSON file. The player's position, rotation, and health are restored to the state they were in when the game was last saved.

- **File Location**: 
  The saved game data is stored in the following directory:
  ```
  Application.persistentDataPath + "/SaveData/SaveGame.sav"
  ```

## Notes
- The `SaveGame.sav` file is created and updated each time you save the game.
- If no save file exists, the game will display an error when trying to load.
