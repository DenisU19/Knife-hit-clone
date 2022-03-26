using UnityEngine;
using UnityEngine.Events;

public class KnifeHitDetector : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _knifeRigidbody;
    [SerializeField]
    private BoxCollider2D _knifeCollider;

    private TrailRenderer _trailRenderer;

    public UnityEvent OnKnifeHeated;
    public UnityEvent OnGameFailed;
    public UnityEvent OnBonusCollect;

    public static bool isGameOver { get; private set; }

    private void Start()
    {
        _trailRenderer = GetComponent<TrailRenderer>();
        isGameOver = false;
        Debug.Log(isGameOver);
        _knifeRigidbody = GetComponent<Rigidbody2D>();
        _knifeCollider = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _trailRenderer.enabled = false;
        if(collision.gameObject.tag == "Log")
        {
            _knifeCollider.size = new Vector2(_knifeCollider.size.x, 0.3749899f);
            _knifeCollider.offset = new Vector2(_knifeCollider.offset.x, -0.2923791f);
            _knifeRigidbody.velocity = Vector2.zero;
            transform.parent = collision.transform;
            _knifeRigidbody.bodyType = RigidbodyType2D.Kinematic;
            OnKnifeHeated?.Invoke();
            Destroy(this);
        }
        else if(collision.gameObject.tag == "AppleBonus")
        {
            Destroy(collision.gameObject);
            OnBonusCollect?.Invoke();
        }
        else
        {
            _knifeRigidbody.velocity = Vector2.zero;
            _knifeRigidbody.gravityScale = 2f;
            isGameOver = true;
            OnGameFailed?.Invoke();
            Destroy(this);
            Destroy(gameObject, 1f);
        }
    }
}
