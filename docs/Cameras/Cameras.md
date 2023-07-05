
### Camera Types

The Prototyping Toolkit offers a versatile collection of camera types to enhance your gameplay experiences. Whether you're creating an immersive first-person exploration game, a strategic real-time strategy (RTS) game, or a classic 2D platformer, the toolkit provides a range of camera options to suit your needs.

#### First Person Camera

The First Person Camera provides an immersive perspective that places the viewer directly in the game world. It simulates the feeling of seeing through the eyes of the player, offering a highly engaging and personal experience. This camera type is commonly used in first-person shooters, adventure games, and exploration-based experiences.

#### Third Person Camera

The Third Person Camera offers an external viewpoint positioned behind and slightly above the focal point. It allows players to observe the game world from a different perspective, providing a broader view of the environment. This camera type is often used in action-adventure games, open-world games, and platformers.

#### Isometric Camera

The Isometric Camera provides a distinctive top-down perspective with a fixed 45-degree angle. It offers a unique blend of depth and simplicity, creating a 2.5D effect that is visually appealing. Isometric cameras are commonly used in strategy games, simulation games, and puzzle games.

#### Top-Down Camera

The Top-Down Camera offers a direct overhead view, looking straight down on the game world. It provides a comprehensive view of the environment and allows players to strategize, plan, and navigate with precision. This camera type is popular in strategy games, puzzle games, and top-down shooters.

#### Side Scroller Camera

The Side Scroller Camera is specifically designed for 2D platformers and side-scrolling games. It follows the action horizontally, allowing players to navigate through levels while maintaining a consistent view. This camera type emphasizes horizontal movement and level design, often seen in classic platforming experiences.

#### RTS (Real-Time Strategy) Camera

The RTS Camera is tailored for real-time strategy games, providing a bird's-eye view of the game world. It allows players to oversee and control the gameplay, manage units, and make strategic decisions. This camera type is essential for overseeing large-scale battles, commanding units, and exploring the map.

### How to Use

1. **Drag and drop** the Camera Prefab of your choice into your Scene or Prefab. Make sure to place it where you want the camera to be positioned.

2. **Unpack** the prefab if needed. This step is necessary if you want to modify the camera settings or components directly.

3. **Place the target** at the appropriate position in the Scene hierarchy. The camera will follow and focus on this target. Adjust the target's transform properties to control its position, rotation, and scale.

4. **Adjust the Settings**:
    - For the camera using Cinemachine, you can fine-tune its behavior and properties by modifying the **Cinemachine Settings**. This allows you to control aspects such as camera movement, tracking, and transitions.
    - For the RTS (Real-Time Strategy) camera, you will need to adjust the **RTS_Camera_settings** asset. This asset contains specific settings for the RTS camera, such as zoom levels, rotation limits, and panning speed. You can create a new asset using the "Create Asset" menu (Create/PrototypingToolkit/Cameras/RTS Camera Settings) or make a copy of the existing asset to customize it according to your needs.![[Pasted image 20230705122222.png]]

Feel free to experiment with the camera settings and iterate on them to achieve the desired camera behavior for your game.