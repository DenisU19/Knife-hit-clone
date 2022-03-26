using UnityEngine;
using UnityEngine.UI;

public class GameOverHandler : MonoBehaviour , IHited
{
    [SerializeField]
    private KnifeCounter _knifeCounter;
    [SerializeField]
    private LogEnvironmentSpawner _logEnvironmentSpawner;
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private KnifeSpawner _knifeSpawner;
    [SerializeField]
    private KnifeHitDetector _hitDetector;
    [SerializeField]
    private GameObject _destructibleTree;

    private Animator _logAnimator;
    public bool _isGameOverPanelActive = true;


    private void OnEnable()
    {
        _knifeSpawner.OnKnifeSpawned.AddListener(GetCurrentKnifeHitDetector);
        _animator = GetComponent<Animator>();
        _logAnimator = _destructibleTree.GetComponent<Animator>();
    }

    private void OnDisable()
    {
        _knifeSpawner.OnKnifeSpawned.RemoveListener(GetCurrentKnifeHitDetector);

    }
    public void ShowGameOverPanel()
    {
        _isGameOverPanelActive = !_isGameOverPanelActive;
        _animator.SetBool("IsGameOver", _isGameOverPanelActive);
        _knifeCounter.ResetUsedKnifes();
    }

    public void GetCurrentKnifeHitDetector(KnifeHitDetector knifeHitDetector)
    {
        _hitDetector = knifeHitDetector;
        _hitDetector.OnGameFailed.AddListener(ShowGameOverPanel);

    }
    public void DestroyLog()
    {
        Destroy(_logEnvironmentSpawner._newLogObject);
    }
    public void StartLogDestoyAnimation()
    {
        _logAnimator.SetTrigger("DestroyLog");
    }
}
