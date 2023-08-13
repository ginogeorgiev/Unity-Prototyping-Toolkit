# List of Modules

| **Modules** | **Description**  |
| ------- | ------------ |
|  |  |
| **Audio** |  |
| - [[Audio Manager]] | Manages audio events and playback. |
| - [[Audio Data]] | Stores audio-related data. |
| - [[Audio Event Data]] | The Data (clips & settings) send with an Audio Event |
|  |  |
| **[[Cameras]]** |  |
| - First Person Camera | Cinemachine with first-person view. |
| - Isometric Camera | Cinemachine with isometric camera perspective |
| - RTS Camera | Cinemachine with Settings for real-time strategy camera view |
| - SideScroller | Cinemachine for side-scrolling camera view |
| - Third Person Camera | Cinemachine for third-person camera view |
| - Top Down Camera | Cinemachine for top-down camera perspective |
|  |  |
| **Options** |  |
| - [[Audio Options]] | Manages audio-related settings. |
| - [[Controls Options]] | Handles control-related settings. |
|  |  |
| **Core** |  |
| - [[Command Logic]] | Implemented pattern to use Commands |
| - [[Domain Logic]] | To categorize events (later more) by features and make them loggable and describable |
| - Editor Tools |  |
| - - Attributes |  |
| - - - [[Better Tooltip]] | Indicates if a Tooltip is there in the inspector |
| - - Extended ScriptableObject Drawer | Makes SOs expandable when referenced in inspector |
| - - [[Tools Menu]] | Add PTK tool menu to create a Feature Folder (later more) |
| - - Extensions |  |
| - - - [[Unity Extensions]] | Some Extensions for Unity Types |
| - - - [[Wait Until UnityEvent]] | Coroutine addition (not yet finished) |
| - - [[Frame Rate Handler]] | Can be used to set frame rate limits |
| - - Menu Names | PTK internal Menu Names for all internal SOs |
| - Events |  |
| - - [[Data Event]] | Are Events that sends data on raise |
| - - [[Empty Event]] | Are simple Events without sending data |
| - - Empty Event Listener | Inspectable Listener for Empty Events |
| - - Event Base | To define Events and reference them under a common type |
| - - [[Event Hub]] | Hub for all events sorted by feature domain |
| - [[Factory]] | Implemented pattern to use Factories |
| - [[Pool]] | Implemented pattern to use Pools |
| - [[Runtime Set]] | Maintains dynamic object sets. |
| - [[Selection]] | Allows to set selections of various types |
| - [[State Logic]] | Implemented pattern to use States and StateMachines |
| - [[Variables]] | Allows to set and share simple Data |
|  |  |
| **[[Script Templates]]** | A List of Script Templates for modification and PTC classes |
|  |  |
| **Samples** | They show how some of the modules can be used or implemented |
|  - Camera Sample |  |
|  - Events Sample |  |
|  - Game Controller Sample |  |
|  - Option Sample |  |
|  - Runtime Set Sample |  |
|  - Sample Player |  |
|  - Empty Scene | A Template Scene, but more important a Scene to switch when pulling with git to prevent problems |
