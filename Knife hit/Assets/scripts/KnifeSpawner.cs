using UnityEngine;
using UnityEngine.Events;

public class KnifeSpawner : MonoBehaviour
{
    [SerializeField]
    private KnifeHitDetector _knifeHitDetector;
    [SerializeField]
    private KnifeThrower _knifeThrower;
    [SerializeField]
    private GameObject _knifePrefab;
    [SerializeField]
    private GameObject _knifeObject;


    public UnityEvent<KnifeHitDetector> OnKnifeSpawned;
    private void OnDisable()
    {
        _knifeHitDetector.OnKnifeHeated.RemoveListener(SpawnKnife);
    }

    //private void Awake()
    //{
    //    SpawnKnife();
    //}
    public void SpawnKnife()
    {
            _knifeObject = Instantiate(_knifePrefab, transform.position, Quaternion.identity) as GameObject;
            _knifeThrower.GetCurrentKnife(_knifeObject);
            _knifeHitDetector = _knifeObject.GetComponent<KnifeHitDetector>();
            OnKnifeSpawned?.Invoke(_knifeHitDetector);
            _knifeHitDetector.OnKnifeHeated.AddListener(SpawnKnife);
    }
}
