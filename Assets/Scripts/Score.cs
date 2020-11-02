using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class Score : MonoBehaviour
{
    private static int _score = 100;
    private static TextMeshProUGUI _textMeshProComponent;

    public static int SubstractScore { set { _score -= value; } }

    private void Awake()
    {
        _textMeshProComponent = GetComponent<TextMeshProUGUI>();
    }

    public static void UpdateScore()
    {
        Debug.Log(_score);
        _textMeshProComponent.text = _score.ToString();
    }

    public static void ResetScore()
    {
        _score = 100;
    }
}
