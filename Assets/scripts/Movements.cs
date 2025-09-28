using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Movements: MonoBehaviour
    
{
    private Rigidbody2D _rb;
    public Transform groundchecker;
    public LayerMask groundlayer;
    private Animator _animator;
    private SpikeScripts _spike;
    public ParticleSystem footsteps;

    public float radius=0.2f;
    public float speed=5f;
    public float horizontal;
    public float jump = 5f;
    private bool _jumptocontrol;
    public int triplejump;
    private bool isfacingRight=true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spike = GetComponent<SpikeScripts>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!_spike.isalive) return;

        horizontal = Input.GetAxis("Horizontal");
        if (groundCheck())//return type
        {
            triplejump= 0;
        }
       
        if (triplejump <2&&Input.GetKeyDown(KeyCode.Space))
        {
            
            
                _jumptocontrol = true;
            
        }
        UpdateAnimation();
        flipplayer();
        
        

    }
    private void FixedUpdate()//this is when using physic
    {
        if(!_spike.isalive) return;
        _rb.linearVelocity = new Vector2(horizontal * speed, _rb.linearVelocity.y);
        if (_jumptocontrol)
        {
            Letjump();//function declaraction
            
        }

    }
    void Letjump()//this is function declaraction
    {

        _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, jump);
        triplejump = triplejump + 1;
        _jumptocontrol = false;
        footsteps.Play();
    }
    bool groundCheck()//this is return type
    {
        bool groundCheck = Physics2D.OverlapCircle(groundchecker.position, radius, groundlayer);//on Colloder2D can use var
        //other type; return Physics2D.OverlapCircle(groundchecker.position,radius,groundlayer);
        return groundCheck;
    }
    void UpdateAnimation()
    {
        if (_rb.linearVelocity.x ==0)
        {
            _animator.SetBool("running", false);
        }
        else
        {
            _animator.SetBool("running", true);
        }
        if (_rb.linearVelocity.y > 0 && !groundCheck())
        {
            _animator.SetBool("jump", true);
            _animator.SetBool("fall", false);
        }
        if (_rb.linearVelocity.y < 0 && !groundCheck())
        {
            _animator.SetBool("fall",true);
            _animator.SetBool("jump", false);
        }
        if (_rb.linearVelocity.y == 0 && groundCheck())
        {
            _animator.SetBool("jump", false);
            _animator.SetBool("fall", false);
        }
    }
    void flipplayer()
    {
        if (_rb.linearVelocity.x > 0)
        {
            if (!isfacingRight)
            {
                footsteps.Play();
            }
            transform.localScale= new Vector3(1, 1, 1);
            isfacingRight = true;
        }
        if (_rb.linearVelocity.x < 0)
        {
            if (isfacingRight)
            {
                footsteps.Play();
            }
            transform.localScale=new Vector3(-1, 1, 1);
            isfacingRight = false;
        }
    }

}
