using UnityEngine;

[CreateAssetMenu(fileName = "AppleBonus", menuName = "CreateAppleBonus")]
public class AppleBonusInfo : ScriptableObject
{
    [SerializeField]
    private GameObject _appleBonus;
    [SerializeField]
    private float _bonusChance;

    public GameObject appleBonus => _appleBonus;
    public float bonusChance => _bonusChance;
}
