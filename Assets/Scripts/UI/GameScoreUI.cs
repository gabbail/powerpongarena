using UnityEngine;
using UnityEngine.UI;

public class GameScoreUI : MonoBehaviour
{
    [SerializeField] private Text blueSideScore;
    [SerializeField] private Text redSideScore;

    private void Awake()
    {
        blueSideScore.text = "0";
        blueSideScore.text = "0";
    }

    private void Start()
    {
        GameManager.Instance.blueScored += UpdateBlueSideScore;
        GameManager.Instance.redScored += UpdateRedSideScore;
    }

    private void UpdateBlueSideScore(int score)
    {
        blueSideScore.text = score.ToString();
    }

    private void UpdateRedSideScore(int score)
    {
        redSideScore.text = score.ToString();
    }
}