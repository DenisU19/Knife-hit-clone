using UnityEngine;
using UnityEngine.Events;

public class KnifeCounter : MonoBehaviour, IHited
{
    [SerializeField]
    private KnifeSpawner _knifeSpawner;
    [SerializeField]
    private KnifeHitDetector _hitDetector;
    public int _maxKnifeCount { get; private set; }
    public int _usedKnifeCount { get; private set; }

    public UnityEvent OnGameWin;
    private void Awake()
    {
        _knifeSpawner.OnKnifeSpawned.AddListener(GetCurrentKnifeHitDetector);
        GetMaxKnifeCount();
    }

    private void OnDisable()
    {
        _knifeSpawner.OnKnifeSpawned.RemoveListener(GetCurrentKnifeHitDetector);

    }

    public void GetMaxKnifeCount()
    {
        _maxKnifeCount = Random.Range(4, 8);
    }

    public void IncrementUsedKnifes() 
    {
        _usedKnifeCount++;
        CheckWin();
    }

    public void CheckWin()
    {
        if(_maxKnifeCount - _usedKnifeCount != 0)
        {
            return;
        }
        ResetUsedKnifes();
        OnGameWin?.Invoke();
    }

    public void GetCurrentKnifeHitDetector(KnifeHitDetector knifeHitDetector)
    {
        _hitDetector = knifeHitDetector;
        _hitDetector.OnKnifeHeated.AddListener(IncrementUsedKnifes);

    }
    public void ResetUsedKnifes()
    {
        _usedKnifeCount = 0;
    }
}
