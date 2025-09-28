using System.Collections;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeScripts : MonoBehaviour
{
    public bool isalive = true;
    public float jump = 5f;
    public float respawntime = 4f;
    public int hp = 6;
    public float colortime = 1f;

    private Rigidbody2D _rb;
    private CapsuleCollider2D _col;
    public Transform checkpoint;
    private Animator _anim;
    private SpriteRenderer _sr;
    public GameObject[] HpBar;
    public GameObject gameoverPannel;
    public GameObject victoryPannel;
        

    public CinemachineCamera cameraa;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _col = GetComponent<CapsuleCollider2D>();
        _anim = GetComponent<Animator>();
        _sr = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        UpdateHpbar();
    }
    private void UpdateHpbar()
    {
        foreach (var bar in HpBar)
        {
            bar.SetActive(false);
        }
        for (var i = 0; i < hp; i++)
        {
            HpBar[i].SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("spikes"))
        {
            hp--;
            UpdateHpbar() ;
            StartCoroutine(ColorChange());
            if (hp == 0)
            {
                Die();
            }
        }
        if (other.CompareTag("finish"))
        {
            victoryPannel.SetActive(true);
        }
           
    }
    private IEnumerator ColorChange()
    {
        _sr.color = Color.red;
        yield return new WaitForSeconds(colortime);
        _sr.color = Color.white;
    }
    private void Die()
    {
        gameoverPannel.SetActive(true );
        isalive = false;
        _rb.linearVelocity = new Vector2(0, jump);
        _col.enabled = false;
        cameraa.Follow = null;
        _anim.enabled = false;
        StartCoroutine(RespawnCo());
    }
    private IEnumerator RespawnCo()
    {
        yield return new WaitForSeconds(respawntime);
        transform.position = checkpoint.position;
        _rb.linearVelocity = new Vector2(0, 0);
        _col.enabled = true;
        cameraa.Follow = transform;
        isalive = true;
        _anim.enabled = true;
        hp = 6;
       UpdateHpbar();
    }
    public void Restart()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Nextlevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
