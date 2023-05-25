using UnityEngine;
using TMPro;
using System.Threading;

/// <summary>
/// This is a Service Locator class which provides access to various game-related services.
/// </summary>
public class GameService : GenericMonoSingleton<GameService>
{
    #region Dependencies

    private PlayerService playerService;
    private EnemyService enemyService;
    private PowerUpService powerUpService;
    private VFXService vfxService;
    private SoundService soundService;
    private UIService uiService;

    #endregion

    #region Prefabs

    [SerializeField] private PlayerView playerPrefab;
    [SerializeField] private EnemyView enemyPrefab;
    [SerializeField] private BulletView playerBulletPrefab;

    #endregion

    #region Scriptable Objects

    [SerializeField] private PlayerScriptableObject playerSO;
    [SerializeField] private EnemyScriptableObject enemySO;
    [SerializeField] private BulletScriptableObject playerBulletSO;
    [SerializeField] private PowerUpScriptableObject powerUpSO;
    [SerializeField] private VFXScriptableObject vfxSO;
    [SerializeField] private SoundScriptableObject soundSO;

    #endregion

    #region Scene References

    [SerializeField] private AudioSource audioEffectSource;
    [SerializeField] private AudioSource backgroundMusicSource;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI healthText;

    #endregion

    private void Start()
    {
        // Initialize all Services.
        playerService = new PlayerService(playerPrefab, playerSO, playerBulletPrefab, playerBulletSO);
        powerUpService = new PowerUpService(powerUpSO);
        enemyService = new EnemyService(enemyPrefab, enemySO);
        soundService = new SoundService(soundSO, audioEffectSource, backgroundMusicSource);
        /*
        vfxService = new VFXService(vfxSO);
        uiService = new UIService(scoreText, healthText);*/
    }

    private void Update()
    {
        powerUpService?.Update();
        enemyService?.Update();
    }

    public PlayerService GetPlayerService() => playerService;

    public EnemyService GetEnemyService() => enemyService;

    public PowerUpService GetPowerUpService() => powerUpService;

    public VFXService GetVFXService() => vfxService;

    public SoundService GetSoundService() => soundService;

    public UIService GetUIService() => uiService;

}
