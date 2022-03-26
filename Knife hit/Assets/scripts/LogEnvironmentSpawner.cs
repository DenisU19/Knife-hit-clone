using System.Collections.Generic;
using UnityEngine;

public class LogEnvironmentSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _log;
    [SerializeField]
    private GameObject _knifeInLog;
    [SerializeField]
    private List<Transform> EnvironmentCell = new List<Transform>();
    [SerializeField]
    private AppleBonusInfo _appleBonusInfo;

    public GameObject _newLogObject { get; private set; }
    //private void Start()
    //{
    //    CreateNewLog();
    //}
    

    private void CreateAppleBonus()
    {
        int bonusChance = Random.Range(0, 100);
        if (bonusChance > _appleBonusInfo.bonusChance)
        {
            return;
        }
        GameObject _appleBonus = Instantiate(_appleBonusInfo.appleBonus, EnvironmentCell[0].position, Quaternion.identity);
        Quaternion _startBonusRotation = Quaternion.FromToRotation(_appleBonus.transform.up, EnvironmentCell[0].position - transform.position);
        _appleBonus.transform.rotation *= _startBonusRotation;
        _appleBonus.transform.parent = _newLogObject.transform;
    }

    private void CreateKnifesInLog()
    {
        int knifeCount = Random.Range(1, 3);
        for (int i = 1; i <= knifeCount; i++)
        {
            GameObject knifeInLog = Instantiate(_knifeInLog, EnvironmentCell[i].position, Quaternion.identity);
            Quaternion _startKnifeRotation = Quaternion.FromToRotation(knifeInLog.transform.up, transform.position - EnvironmentCell[i].position);
            knifeInLog.transform.rotation *= _startKnifeRotation;
            knifeInLog.transform.parent = _newLogObject.transform;
        }
    }
    public void CreateNewLog()
    {
        MixEnvironmentPlaces();
        _newLogObject = Instantiate(_log, transform.position, Quaternion.identity);
        CreateAppleBonus();
        CreateKnifesInLog();
    }
    private void MixEnvironmentPlaces()
    {
        for (int i = 0; i < EnvironmentCell.Count; i++)
        {
            int randomNumber = Random.Range(0, EnvironmentCell.Count);
            Transform additionalCell = EnvironmentCell[i];
            EnvironmentCell[i] = EnvironmentCell[randomNumber];
            EnvironmentCell[randomNumber] = additionalCell;

        }
    }
}
