using UnityEngine;
public class Tutorial : MonoBehaviour
{
    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}