
Everything done in this guide can be found in the Quick Start Guide Sample Folder.
The Quick Start Guide tries to focus on the development by sticking to best practices, but at the same time to not over-engineer in an early stage.

---
#### What are we going to implement in this guide (time ~2h)
	(needed to have a simple loop)
-  a simple player with planar movement and an isometric camera view *(~ 20min)*
-  a player health controller with damage event and UI Feedback *(~ 40min)*
-  spawning some enemies that move towards and pass the player *(~ 50min)*
#### Bonus implementations (time ~2h)
	(needed for better testing and iterating)
-  a skill to deal damage to enemies around the player with UI feedback *(~ 30min)*
-  a game controller with start-, game- and end-state and UI *(~ 40min)*
-  audio options and some sounds *(~ 20min)*

![[game-gif.mp4]]

---
## Lets get started

##### 0. Setup

- for the purpose of this guide we create a ScriptableObject called GameData, which holds all the relevant variables and events and other references that are shared between features for this prototype
```csharp
[CreateAssetMenu(fileName = "GameData", menuName = "GameData")]
public class GameData : ScriptableObject  
{

}
```
- We can remove the CreateAssetMenu after we created an asset in the project, because we only need one GameData asset.
- Almost every script we write will have a reference to this GameData
-  We also need to create a new Scene

##### 1. Player, Movement and Camera

-  for that we can use our sample player, but its also possible to use your own character controller
	-  drag and drop the isometric camera prefab from PrototypingToolkit/Cameras/IsometricCamera into your player
	-  adjust the target of the camera, so that it sits at the right position of your character
	-  adjust cinemachine settings as you like
-  set up an InputActionMap with WASD for the movement
-  for the settings of the player we create some [[Variables]] like currentSpeed and maxSpeed
	-  right-click in the project Create/PrototypingToolkit/Variables/FloatVariable and call it properly
	-  reference it in the GameData and access it with Get() and Set(value)
-  give the player a ground that moves with it
-  make sure your player has a collider for later steps and that the tag is set to "Player"

Your project, scene and player should look something like this by now:
![[Pasted image 20230812103858.png]]

##### 2. Player Health Controller with damage event

- first we need to create another [[Variables|FloatVariable]] like movementSpeed and call it "PlayerHealth_FloatVariable" and set the startValue to 100
- then we add a hud canvas with two simple images
	- one as background in dark
	- and one as the player health bar in red and set the Image Type to "Filled"
- then we also create a HealthBarUIController that will hold the GameData and will set the fill of the image when the player health is changed
- for that we need to create an EmptyEvent
	- right-click in the project Create/PrototypingToolkit/Events/EmptyEvent
	- call it "PlayerHealthChanged_EmptyEvent" and add it to the "PlayerHealth_FloatVariable"
```csharp
public class HealthBarUIController : MonoBehaviour  
{  
    [Header("Game Data")]  
    [SerializeField] private GameData gameData;  
      
    [Header("Internal Refs")]  
    [SerializeField] private Image bar;  
      
    [Header("Debug")]  
    [SerializeField] private float targetFillAmount;  
  
    private void OnEnable()  
    {  
	    gameData.PlayerHealth.OnCurrentChanged
	    .Register(OnPlayerHealthChanged);  
          
        OnPlayerHealthChanged();  
    }  
  
    private void OnDisable()  
    {  
	    gameData.PlayerHealth.OnCurrentChanged
	    .Unregister(OnPlayerHealthChanged); 
    }  
  
    private void OnPlayerHealthChanged()  
    {  
        targetFillAmount =
        gameData.PlayerCurrentHealth.Get() / gameData.PlayerCurrentHealth.StartValue;  
        bar.fillAmount = targetFillAmount;  
    }  
}
```

- For the player to take damage we add an OnTriggerEnter method to the collider of the player and raise a "DealDamageToPlayer_EmptyEvent"
```csharp
public class Damageable : MonoBehaviour  
{  
    [Header("Data")]  
    [SerializeField] private GameData gameData;  
  
    private void OnTriggerEnter(Collider other)  
    {  
        if (other.CompareTag("Player")) return;  
          
        gameData.DealDamageToPlayer.Raise();  
    }  
}
```

- and than we add a HealthController to the player which handles the "DealDamageToPlayer_EmptyEvent"
	-  subtracts the damage amount from the players health
	-  and send an event if the player has no health (GameOver_EmptyEvent)
```csharp
public class HealthController : MonoBehaviour  
{  
    [Header("Data")]  
    [SerializeField] private GameData gameData;  
  
    private void OnEnable()  
    {  
        gameData.DealDamageToPlayer.Register(OnDamageToPlayer);  
    }  
  
    private void OnDisable()  
    {  
        gameData.DealDamageToPlayer.Unregister(OnDamageToPlayer);  
    }  
  
    private void OnDamageToPlayer()  
    {  
        gameData.PlayerCurrentHealth.AddToCurrent(- 10); 
  
        if (gameData.PlayerCurrentHealth.Get() <= 0)  
        {  
            gameData.GameOver.Raise();  
        }  
    }  
}
```

- for testing purposes we add a button the GameData to see if everything is working at runtime
```csharp
[ButtonMethod]  
private void DamagePlayerTest()  
{  
    DealDamageToPlayer.Raise();  
}
```

##### 3. Enemies and EnemySpawner

- for the enemies we copy the model and collider of the player and create a new prefab with new material colors
	- we create some [[Variables]] for the enemy like movementSpeed and damage
	- and we let the enemies walk towards and pass the player in its Update method
	- we also need the initialPlayerPosition for that 
		- we can do this by adding the Player Transform to the GameData on the players Awake and access it in the enemies OnEnable
		  (this way enemies will not directly reference the player)

- now lets create the EnemySpawner which will sit inside the player
	- for that we create some new [[Variables]] like spawnRadius, deSpawnRadius and spawnRate
		-  deSpawnRadius should be bigger than spawnRadius
	- than we create enemies at a random position based on the spawnRadius during a coroutine based on the spawnRate
	- we add a collider that will handle the despawning in OnTriggerExit
	- **important:** since the spawner is part of the player it also needs to have the "Player" tag

And that is it for the basic loop, the game is now playable.

---
## Lets add more

##### 1. A skill to deal damage to enemies with UI feedback

-  for this we create a new prefab that sits inside the player
	- it need a Rigidbody (because it handles its own collisions with the enemies) and the "Player" tag so that it does not collide with the player
	- it needs a collider in a child and some sort of visual in our case its a sprite on the ground
		- the collider will destroy enemies in OnTriggerEnter
	- we also need a new inputAction to use the skill, so it needs to be added to the InputActionMap
	- and we add some [[Variables]] to the GameData for settings like coolDown and curCoolDown
It could look like this:
```csharp
public class DamageSkillController : MonoBehaviour  
{  
   [Header("Data")]  
   [SerializeField] private GameData gameData;  
     
   [Header("Internal Ref")]  
   [SerializeField] private GameObject damageCollider;  
     
   [Header("Debug")]  
   [SerializeField] private bool isPressed;  
  
   private void OnEnable()  
   {  
      gameData.SkillInput.action.Enable();  
        
      gameData.SkillInput.action.started += OnSkillInput;  
      gameData.SkillInput.action.canceled += OnSkillInput;  
  
      damageCollider.SetActive(false);  
   }  
  
   private void OnDisable()  
   {  
      gameData.SkillInput.action.started -= OnSkillInput;  
      gameData.SkillInput.action.canceled -= OnSkillInput;  
        
      gameData.SkillInput.action.Disable();  
   }  
     
   private void OnSkillInput(InputAction.CallbackContext context)  
   {  
      isPressed = context.started;  
   }  
  
   private void Update()  
   {  
      if (gameData.CurCoolDown.Get() > 0)  
      {  
         gameData.CurCoolDown.AddToCurrent(- Time.deltaTime);  
      }  
      else if (isPressed)  
      {  
         DoSkill();  
      }  
   }  
  
   private void DoSkill()  
   {  
      if (!(gameData.CurCoolDown.Get() <= 0)) return;  
  
      StartCoroutine(DealDamage());  
   }  
  
   private IEnumerator DealDamage()  
   {  
      damageCollider.SetActive(true);  
      RefreshCoolDown();  
  
      yield return new WaitForSeconds(gameData.SkillActiveTime.Get());  
        
      damageCollider.SetActive(false);  
   }  
  
   private void RefreshCoolDown()  
   {  
      gameData.CurCoolDown.Set(gameData.SkillCoolDown.Get());  
   }  
}
```

- next we need another filled image in our hud that will indicate weather our skill is on coolDown or not
	- for that we check in the Update method if the curCoolDown is lower or the same as the coolDown and set the fillAmount respectively
##### 2. GameController with UI

- for this we need a GameController inheriting form [[State Logic#3. Create a new StateMachine|StateMachine]]
	- it need the StartState GameState and EndState
	- will instantiate them initialize with the StartState and will then react to events in order to trigger state transitions
	- it will hold all the necessary scene references in order to give them to the states
	- these states will than handle logic in their Enter and Exit methods in order to represent the state properly
- we also need two new canvases
	- a start canvas which will have some Information about the rules and a start button
	- a end canvas with a restart button
	- the buttons will trigger events which will be handled by the GameController
- we also need a container for the enemies that can be cleared on state transitions
The GameController could look like this:
```csharp
[DefaultExecutionOrder(-10)]  
public class GameController : StateMachine  
{  
   [Header("Data")]  
   [SerializeField] private GameData gameData;  
     
   [Header("Scene Refs")]  
   [SerializeField] private GameObject player;  
   [SerializeField] private EnemyContainerController enemyContainerController;  
     
   [SerializeField] private GameObject hud;  
   [SerializeField] private GameObject startScreen;  
   [SerializeField] private GameObject endScreen;  
  
   private StartState startState;  
   private GameState gameState;  
   private EndState endState;  
     
   private void Awake()  
   {  
      player.SetActive(false);  
      enemyContainerController.gameObject.SetActive(false);  
      hud.SetActive(false);  
      endScreen.SetActive(false);  
        
      gameData.ReStart.Register(EnterStartState);  
      gameData.GameStart.Register(EnterGameState);  
      gameData.GameOver.Register(EnterEndState);  
  
      startState = new StartState(gameData, startScreen);  
      gameState = new GameState(gameData, player,
							      enemyContainerController, hud, startScreen);  
      endState = new EndState(gameData, endScreen);  
        
      Initialize(startState);  
   }  
     
   [ButtonMethod]  
   private void EnterStartState()  
   {  
      if (currentStateSO.Get() is not StartState) TransitionTo(startState);  
   }  
  
   [ButtonMethod]  
   private void EnterGameState()  
   {  
      if (currentStateSO.Get() is not GameState) TransitionTo(gameState);  
   }  
  
   [ButtonMethod]  
   private void EnterEndState()  
   {  
      if (currentStateSO.Get() is not EndState) TransitionTo(endState);  
   }  
}
```

##### 3. Sounds and audio options

- for that we to get some Sounds
	- we can take some free sounds from [Kenny](https://www.kenney.nl/assets/impact-sounds)
	- we create a sound for
		- the start button
		- the dealDamageToPlayer event 
		- for the skill
		- and for game over
	- for that we need three things
		- Add an AudioManager to your scene
			- PrototypingToolkit/Audio/Prefabs/AudioManager
			- also right-click in the hierarchy under PrototypingToolkit/AudioManager
		- create [[Audio Event Data]] for each Sound
			- set the corresponding mixer group
			- add the audio files to the Audio Clips List
			- adjust Volume and pitch
		- there a two ways to raise audio events with audio event data
			- either in the [[Audio Event Data#3b. Raise Audio Events via Inspector|inspector]] with unity events and the [[Audio Data#Play AudioEvent|Play AudioEvent]]
			- or via code by referencing the audio event data, raising it and sending the sound with it
	- as an example we can create an empty GameObject add a EmptyEventListener and react to the "DealDamageToPlayer_EmptyEvent" and add the [[Audio Data#Play AudioEvent|Play AudioEvent]] and our created [[Audio Event Data]] with the corresponding sound(s)![[Pasted image 20230812175748.png]]
	- a more convenient way would be to raise them where they happen (for example in the HealthController)
	```csharp
	private void OnDamageToPlayer()  
	{  
	    gameData.PlayerHealth.AddToCurrent(-gameData.EnemyDamage.Get());  
	    gameData.AudioData.PlayAudioEvent.Raise(gameData.BumpSound);  
  
	    if (gameData.PlayerHealth.Get() <= 0)  
	    {  
	        gameData.GameOver.Raise();  
	        gameData.AudioData.PlayAudioEvent.Raise(gameData.GameOverSound);  
	    }  
	}
	```

- another thing we need to do is add a Audio Options 
	- for that we need two things
	- we need to add an Audio_slider to our start canvas
		- PrototypingToolkit/Options/Audio/Prefabs/Audio_Slider
		- reference the Sound_VolumeFloatVariable
	- and we have to add the AudioSettingsManager to our scene
		- PrototypingToolkit/Audio/Prefabs/AudioSettingsManager
		- also right-click in the hierarchy under PrototypingToolkit/AudioSettingsManager

And that is it now we have a prototype on which we can iterate on.

---
##### Now its your turn:
	add some extras to learn more about PTK, and improve your playtesting environment:
-  Add a timer and an indicator that shows how many enemies you have surpassed
-  Add an Input rebind menu for the player controls
-  Add another skill (a dash perhaps)
-  Add a progression which changes the enemy spawn rate over time
-  Try out different cameras and see how gameplay changes