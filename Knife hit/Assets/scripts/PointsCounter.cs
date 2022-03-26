using UnityEngine;
using UnityEngine.UI;

public class PointsCounter : MonoBehaviour, IHited
{
    [SerializeField]
    private KnifeSpawner _knifeSpawner;
    [SerializeField]
    private Text _currentPointsText;
    [SerializeField]
    private Text _recordPointsText;
    [SerializeField]
    private Text _gameOverCurrentPoints;
    [SerializeField]
    private Text _gameOverRecordPoints;
    [SerializeField]
    private Text _AppleBonusText;
    [SerializeField]
    private KnifeHitDetector _knifeHitDetector;
    public int _currentPoint { get; private set; }
    public int _recordPoint { get; private set; }

    public int _appleBonus { get; private set; }

    private void OnEnable()
    {
        _knifeSpawner.OnKnifeSpawned.AddListener(GetCurrentKnifeHitDetector);
    }
    private void OnDisable()
    {
        _knifeSpawner.OnKnifeSpawned.RemoveListener(GetCurrentKnifeHitDetector);
        _knifeHitDetector.OnKnifeHeated.RemoveListener(AddOnePoint);
        _knifeHitDetector.OnBonusCollect.RemoveListener(AddTwoPoints);
        _knifeHitDetector.OnGameFailed.RemoveListener(GetFinishPoint);
    }
    public void AddOnePoint()
    {
        _currentPoint++;
        DrawCurrentCount();
    }
    public void AddTwoPoints()
    {
        _currentPoint += 2;
        _appleBonus++;
        DrawCurrentCount();
    }
    public void GetCurrentKnifeHitDetector(KnifeHitDetector knifeHitDetector)
    {
        _knifeHitDetector = knifeHitDetector;
        _knifeHitDetector.OnKnifeHeated.AddListener(AddOnePoint);
        _knifeHitDetector.OnBonusCollect.AddListener(AddTwoPoints);
        _knifeHitDetector.OnGameFailed.AddListener(GetFinishPoint);

    }
    public void CheckNewRecord()
    {
        if (_currentPoint < _recordPoint)
        {
            return;
        }
        _recordPoint = _currentPoint;
        PlayerPrefs.SetInt("NewRecord", _recordPoint);
        _recordPointsText.text = _recordPoint.ToString();
    }
    public void DrawCurrentCount()
    {
        _currentPointsText.text = _currentPoint.ToString();
        PlayerPrefs.SetInt("Apples", _appleBonus);
        _AppleBonusText.text = _appleBonus.ToString();

    }
    public void GetFinishPoint()
    {
        CheckNewRecord();
        _gameOverCurrentPoints.text = _currentPoint.ToString();
        _gameOverRecordPoints.text = _recordPoint.ToString();
    }
    public void  ResetCurrentPoints()
    {
        _currentPoint = 0;
        _currentPointsText.text = _currentPoint.ToString();
    }
    public void RedrawPoints()
    {
        _recordPointsText.text = PlayerPrefs.GetInt("NewRecord").ToString();
        _AppleBonusText.text = PlayerPrefs.GetInt("Apples").ToString();
    }
}
