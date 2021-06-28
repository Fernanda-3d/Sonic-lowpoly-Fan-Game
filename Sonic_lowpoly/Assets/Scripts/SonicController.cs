using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SonicController : MonoBehaviour
{

    private Rigidbody _rigidbody;
    private Animator _animator;
    private float speedMultiplier = 8;
    //private float jumpForce = 8;
    private bool jump;
    private bool death;
    //private bool roll;
    private bool isGrounded;
    private float horizontalInput;
    //private float verticalInput;
    public int forceConst = 10;
    public int forceJump = 5;
    public AudioSource jumpSound;
    public ParticleSystem smoke;
    public AudioSource spring;
    public AudioClip springSound;
    public AudioSource hit;
    public AudioClip hitSound;
    public AudioSource finishSound;
    public AudioClip finishclip;
    public AudioSource loseSound;
    public AudioClip losering;
    public ParticleSystem ringEffect;
    public AudioSource splashSound;
    public AudioClip splash;
    public ParticleSystem splashEffect;
    public AudioSource testplay;
    public GameObject runeffect;
    public static int theScore;
    public GameObject kill;
    public GameObject die;
    public AudioSource dieSound;
    public AudioClip dieClip;
    public Vector3 startPos;



    // public float rotation_Speed = 0.15f;
    // public float rotateDegreesPerSecond = 180f;


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        //verticalInput = Input.GetAxis("Vertical");

        /* [SerializeField] private Animator sheepAnim;

         //Set a bool stored in the animation to a new value
         sheepAnim.SetBool("isIdle", true);

         //Another way to set the animation playback speed
         sheep.GetComponent<Animator>().speed = 2.5f; */

        if (-_rigidbody.velocity.x > 0.5)
        {
            runeffect.GetComponent<SmokeFollow>().enabled = true;
            runeffect.GetComponent<CameraFollow>().enabled = false;
        }
        
                
        if (-_rigidbody.velocity.x < 0.5) 
        {
            runeffect.GetComponent<SmokeFollow>().enabled = false;
            runeffect.GetComponent<CameraFollow>().enabled = true;
        } 

        
       
        /* if (_rigidbody.velocity.x > 0.5)
         {
             runeffect.GetComponent<SmokeFollow>().enabled = true;
             runeffect.GetComponent<CameraFollow>().enabled = false;
         }
         if (_rigidbody.velocity.x < 0.5)
         {
             runeffect.GetComponent<SmokeFollow>().enabled = false;
             runeffect.GetComponent<CameraFollow>().enabled = true;
         } */

        if (isGrounded == false)
        {
            runeffect.GetComponent<SmokeFollow>().enabled = false;
            runeffect.GetComponent<CameraFollow>().enabled = true;
        }

       

        //Face Forward

        transform.forward = new Vector3(-(Mathf.Abs(horizontalInput) * 0), 0, horizontalInput);
        

        // transform.forward = new Vector3(-(Mathf.Abs(horizontalInput) - 1), 0, horizontalInput);



        // Move Animation
        _animator.SetFloat("Speed", horizontalInput);

        //_animator.SetFloat("SpeedVertical", verticalInput);


        //Set Animator IsGrounded
        _animator.SetBool("IsGrounded", isGrounded);

       
        //Jump
        if (Input.GetKeyUp(KeyCode.Space) && isGrounded)
        {
            jump = true;
            
            // _rigidbody.velocity = Vector3.zero;
            jumpSound.Play();

        }

       


        /*  if (Input.GetButtonDown("Jump") && isGrounded)
           {
               jump = true;
           } */

    }

    

    private void FixedUpdate()
    {
        //Move        
        _rigidbody.velocity = new Vector3(-horizontalInput * speedMultiplier, _rigidbody.velocity.y, 0 * Time.deltaTime);

     

        //IsGrounded

        isGrounded = Physics.OverlapBox(_rigidbody.position, Vector3.one * 0.3f).Length > 2;


        //Jump
        if (jump && isGrounded)
        {
            jump = false;

            this.GetComponent<Rigidbody>().velocity = new Vector3(0, 10.0f, 0);
            // _rigidbody.AddForce(0, forceConst, 0, ForceMode.Impulse);
            
        }

        //Death
        if (death)
        {
            dieSound.PlayOneShot(dieClip);
            death = false;
            ringEffect.Stop();
            this.GetComponent<Rigidbody>().velocity = new Vector3(0, 10.0f, 0);
            //this.GetComponent<BoxCollider>().enabled = false;
            this.GetComponent<SphereCollider>().enabled = false;
            // _rigidbody.AddForce(0, forceConst, 0, ForceMode.Impulse);
            
            

        }

        /*
          if (jump && isGrounded)
        {
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, jumpForce, 0);
            jump = false;
        }
        */
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Respawn")
        {
            Respawn();
        }

        if (other.gameObject.tag == "smokeplay")
        {
            // Instantiate(smoke, new Vector3(115, 9, -2), Quaternion.identity);
            //Instantiate(smoke, here.transform.position, Quaternion.identity);            
            smoke.Play();
            hit.PlayOneShot(hitSound); 
         
        }

        
        if (other.gameObject.tag == "kill_trigger")
        {                    
            loseSound.PlayOneShot(losering);
            ringEffect.Play();
            ScoringSystem.theScore = 0;
                      
        }

        if (other.gameObject.tag == "die" && theScore <= 0)
        {
            _animator.SetBool("Die", true);
            death = true;
            Destroy(kill);
            Destroy(die);
            //GetComponent<UpDown>().enabled = true;

        }

        


        /* if (other.gameObject.tag == "land_collider")
         {
             runeffect.GetComponent<SmokeFollow>().enabled = true;
             runeffect.GetComponent<CameraFollow>().enabled = false;
          } */

        if (other.gameObject.tag == "water")
        {

            splashSound.PlayOneShot(splash);
            splashEffect.Play();
            _animator.SetBool("JumpFall", true);


        }

        if (other.gameObject.tag == "Finish")
        {
           finishSound.PlayOneShot(finishclip);

        }

        if (other.gameObject.tag == "high_jump")
        {

            jump = false;
            spring.PlayOneShot(springSound);
            this.GetComponent<Rigidbody>().velocity = new Vector3(0, 15.0f, 0);


            //_rigidbody.AddForce(0, 8, 0, ForceMode.Impulse);
        }

        
        if (other.gameObject.tag == "kill_trigger")
        {
            _animator.SetBool("JumpFall", true);
           
        }
                        
    }

    private void Respawn()
    {
        SceneManager.LoadScene("SonicScene_Backup");
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "kill_trigger")
        {
            _animator.SetBool("JumpFall", false);
            
        }

       /* if (other.gameObject.tag == "land_collider")
        {
            runeffect.GetComponent<SmokeFollow>().enabled = false;
            runeffect.GetComponent<CameraFollow>().enabled = true;
        } */

    }
}



// Rotate

/* Vector3 rotation_Direction = Vector3.zero;

 if(Input.GetAxis("Horizontal") < 0)
 {
     rotation_Direction = transform.TransformDirection(Vector3.left);
 }

 if (Input.GetAxis("Horizontal") > 0)
 {
     rotation_Direction = transform.TransformDirection(Vector3.right);
 }

 if(rotation_Direction != Vector3.zero)
 {
     transform.rotation = Quaternion.RotateTowards(
         transform.rotation, Quaternion.LookRotation(rotation_Direction),
         rotateDegreesPerSecond * Time.deltaTime);
 } */
