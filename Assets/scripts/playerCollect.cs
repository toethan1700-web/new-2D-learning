using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class playerCollect : MonoBehaviour
{
    public int fruitcollect = 0;
    public TextMeshProUGUI fruitText;
    public AudioClip collectClip;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("fruits")) return;
        fruitcollect++;
        Destroy(other.gameObject);
        fruitText.text = fruitcollect.ToString();
        AudioManager.Instance.PlaySFX(collectClip);
    }
}

