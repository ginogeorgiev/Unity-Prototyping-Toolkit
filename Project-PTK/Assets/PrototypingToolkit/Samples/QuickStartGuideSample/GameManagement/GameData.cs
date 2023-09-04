using MyBox;
using PrototypingToolkit.Audio;
using PrototypingToolkit.Core;
using PrototypingToolkit.Core.PrimitiveTypes;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PrototypingToolkit.Samples.QuickStartGuideSample.GameManagement
{
    public class GameData : ScriptableObject
    {
        [Header("Game Data")]
        [SerializeField] private EmptyEvent gameStart;
        [SerializeField] private EmptyEvent gameOver;
        [SerializeField] private EmptyEvent reStart;

        public EmptyEvent GameStart => gameStart;
        public EmptyEvent GameOver => gameOver;
        public EmptyEvent ReStart => reStart;

        [Header("Player Data")]
        [BetterTooltip("Will set itself")]
        [SerializeField] private Transform playerTransform;
        
        [SerializeField] private FloatVariable playerMaxMovementSpeed;
        [SerializeField] private FloatVariable playerCurrentMovementSpeed;
        [SerializeField] private InputActionReference playerMovementInput;
        
        [SerializeField] private FloatVariable playerHealth;

        public Transform PlayerTransform
        {
            get => playerTransform;
            set => playerTransform = value;
        }

        public FloatVariable PlayerMaxMovementSpeed => playerMaxMovementSpeed;
        public FloatVariable PlayerCurrentMovementSpeed => playerCurrentMovementSpeed;
        public InputActionReference PlayerMovementInput => playerMovementInput;

        public FloatVariable PlayerHealth => playerHealth;
        
        [ButtonMethod]
        private void DamagePlayerTest()
        {
            DealDamageToPlayer.Raise();
        }
        
        [Header("Damage Data")]
        [SerializeField] private EmptyEvent dealDamageToPlayer;

        public EmptyEvent DealDamageToPlayer => dealDamageToPlayer;
        
        [Header("Enemy Data")]
        [BetterTooltip("Will set itself")]
        [SerializeField] private Transform enemyContainer;
        
        [SerializeField] private FloatVariable enemyMovementSpeed;
        [SerializeField] private FloatVariable enemyDamage;
        [SerializeField] private FloatVariable spawnRadius;
        [SerializeField] private FloatVariable deSpawnRadius;
        [SerializeField] private FloatVariable spawnRate;

        public Transform EnemyContainer
        {
            get => enemyContainer;
            set => enemyContainer = value;
        }

        public FloatVariable EnemyMovementSpeed => enemyMovementSpeed;
        public FloatVariable EnemyDamage => enemyDamage;
        public FloatVariable SpawnRadius => spawnRadius;
        public FloatVariable DeSpawnRadius => deSpawnRadius;
        public FloatVariable SpawnRate => spawnRate;
        
        [Header("Player Skill")]
        [SerializeField] private FloatVariable skillCoolDown;
        [SerializeField] private FloatVariable curCoolDown;
        [SerializeField] private FloatVariable skillActiveTime;
        [SerializeField] private InputActionReference skillInput;

        public FloatVariable SkillCoolDown => skillCoolDown;
        public FloatVariable CurCoolDown => curCoolDown;
        public FloatVariable SkillActiveTime => skillActiveTime;
        public InputActionReference SkillInput => skillInput;
        
        [Header("Audio Data")]
        [SerializeField] private AudioData audioData;
        
        [SerializeField] private AudioEventData bumpSound;
        [SerializeField] private AudioEventData gameOverSound;
        [SerializeField] private AudioEventData skillSound;

        public AudioData AudioData => audioData;
        
        public AudioEventData BumpSound => bumpSound;
        public AudioEventData GameOverSound => gameOverSound;
        public AudioEventData SkillSound => skillSound;
    }
}
