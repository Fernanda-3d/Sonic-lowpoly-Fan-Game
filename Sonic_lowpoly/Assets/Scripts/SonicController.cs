using UnityEngine;

public class SonicController : MonoBehaviour
{

    private Rigidbody _rigidbody;
    private Animator _animator;
    private float speedMultiplier = 8;
    //private float jumpForce = 8;
    private bool jump;
    //private bool roll;
    private bool isGrounded;
    private float horizontalInput;
    private float verticalInput;
    public int forceConst = 10;
    public AudioSource jumpSound;
    public ParticleSystem smoke;
    public AudioSource spring;
    public AudioClip springSound;
    public AudioSource hit;
    public AudioClip hitSound;
    public AudioSource finishSound;
    public AudioClip finish;

  

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
        verticalInput = Input.GetAxis("Vertical");
        
       

        //Face Forward

        transform.forward = new Vector3(-(Mathf.Abs(horizontalInput) * 0), 0, horizontalInput);
        

        // transform.forward = new Vector3(-(Mathf.Abs(horizontalInput) - 1), 0, horizontalInput);



        // Move Animation
        _animator.SetFloat("Speed", horizontalInput);
        _animator.SetFloat("SpeedVertical", verticalInput);


        //Set Animator IsGrounded
        _animator.SetBool("IsGrounded", isGrounded);

       
        //Jump
        if (Input.GetKeyUp(KeyCode.Space) && isGrounded)
        {
            jump = true;
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
            _rigidbody.AddForce(0, forceConst, 0, ForceMode.Impulse);
           

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

        if (other.gameObject.tag == "smokeplay")
        {
            // Instantiate(smoke, new Vector3(115, 9, -2), Quaternion.identity);
            //Instantiate(smoke, here.transform.position, Quaternion.identity);            
            smoke.Play();
            hit.PlayOneShot(hitSound); 
         
        } 

        if (other.gameObject.tag == "kill_trigger")
        {

            Debug.Log("I'm killing the enemy");

        }

        if (other.gameObject.tag == "finishSound")
        {
           finishSound.PlayOneShot(finish);

        }

        if (other.gameObject.tag == "high_jump")
        {
            jump = false;
            spring.PlayOneShot(springSound);
            _rigidbody.velocity = new Vector3 (0f,0f,0f);
            _rigidbody.AddForce(0, forceConst * 2, 0, ForceMode.Impulse);           
        }

       
        if (other.gameObject.tag == "kill_trigger")
        {
            _animator.SetBool("JumpFall", true);
           
        }
                        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "kill_trigger")
        {
            _animator.SetBool("JumpFall", false);

        }

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
