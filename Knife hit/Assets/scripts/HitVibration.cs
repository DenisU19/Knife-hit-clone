using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitVibration : MonoBehaviour, IHited
{
    [SerializeField]
    private KnifeSpawner _knifeSpawn;
    [SerializeField]
    private KnifeHitDetector _knifeHitDetector;
    [SerializeField]
    private long _VibrationTime;

    private void Awake()
    {
        _knifeSpawn.OnKnifeSpawned.AddListener(GetCurrentKnifeHitDetector);
    }

    private void OnDisable()
    {
        _knifeSpawn.OnKnifeSpawned.RemoveListener(GetCurrentKnifeHitDetector);
        _knifeHitDetector.OnKnifeHeated.RemoveListener(KnifeHitVibrate);
        _knifeHitDetector.OnGameFailed.RemoveListener(KnifeHitVibrate);

    }
    void Start()
    {
        Vibration.Init();
    }

    public void GetCurrentKnifeHitDetector(KnifeHitDetector knifeHitDetector)
    {
        _knifeHitDetector = knifeHitDetector;
        _knifeHitDetector.OnKnifeHeated.AddListener(KnifeHitVibrate);
        _knifeHitDetector.OnGameFailed.AddListener(KnifeHitVibrate);
    }
    public void KnifeHitVibrate()
    {
        Debug.Log("Vibration");
        Vibration.Vibrate(_VibrationTime);
    }


}
