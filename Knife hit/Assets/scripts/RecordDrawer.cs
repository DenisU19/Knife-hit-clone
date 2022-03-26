using UnityEngine;
using UnityEngine.UI;

public class RecordDrawer : MonoBehaviour
{
    [SerializeField]
    private Text _recordText;
    void Start()
    {
        _recordText = GetComponent<Text>();
        _recordText.text = PlayerPrefs.GetInt("NewRecord").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
