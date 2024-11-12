using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private bool isBlueSide = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            if (isBlueSide)
                GameManager.Instance.BlueSideScored();
            else
                GameManager.Instance.RedSideScored();
        }
    }
}