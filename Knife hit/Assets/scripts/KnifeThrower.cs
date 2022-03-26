using UnityEngine;

public class KnifeThrower : MonoBehaviour
{
    [SerializeField]
    private PlayerInputHandler _playerInputHandler;
    [SerializeField]
    private float forcePower;

    private GameObject _currentKnife;

    public void OnEnable()
    {
        _playerInputHandler.OnTouched.AddListener(ThrowKnife);
    }
    public void OnDisable()
    {
        _playerInputHandler.OnTouched.RemoveListener(ThrowKnife);
    }
    public void GetCurrentKnife(GameObject currentKnife)
    {
        _currentKnife = currentKnife;
    }
    public void ThrowKnife()
    {
        _currentKnife.GetComponent<Rigidbody2D>().AddForce(Vector2.up * forcePower, ForceMode2D.Impulse);
    }
}
