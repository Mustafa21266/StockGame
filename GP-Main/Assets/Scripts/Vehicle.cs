using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    private Animator anim;
    private float force = 1f;
    public float speed = 5f;

    public List<GameObject> pathTargets;
    public GameObject target;
    public Rigidbody rb;

    private CharacterController controller;

    private int currentTargetIndex = 0;

    private GameObject targetTemp;

    public bool isAllowedToMove = true;

    public GameObject preFab;

    private bool stopTemp = false;

    public float rt;

    public string positionOfObject;
    // Start is called before the first frame update
    void Start()
    {
        var newVehicle = Instantiate(preFab, gameObject.transform.position, Quaternion.identity);
        newVehicle.transform.Rotate(0.0f, rt, 0.0f, Space.Self);
        //newVehicle.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = this.activeNote.GetComponent<Note>().title;
        newVehicle.transform.SetParent(gameObject.transform);
        anim = gameObject.transform.GetChild(gameObject.transform.childCount - 1).GetComponent<Animator>();
        //controller = GetComponent<CharacterController>();
        rb = gameObject.transform.GetChild(gameObject.transform.childCount - 1).GetComponent<Rigidbody>();
        for (var i =0 ; i < gameObject.transform.childCount - 1; i++)
        {
            pathTargets.Add(gameObject.transform.GetChild(i).gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {

        //StartCoroutine(changeIdleAnimation());
        if (pathTargets.Count > 0 && isAllowedToMove)
        {
            
            StartCoroutine(moveNPC());
        }

        //transform.position.Set(transform.position.x,transform.position.y,GameObject.FindGameObjectWithTag("Player").transform.position.z - 10);

    }
    IEnumerator moveNPC()
    {
        yield return new WaitForSeconds(1f);
        //Debug.Log(pathTargets.Count);
        //Debug.Log(Vector3.Distance(transform.position,targetTemp.transform.position));
        //Debug.Log(currentTargetIndex);

        if (currentTargetIndex < pathTargets.Count)
        {
            targetTemp = pathTargets[currentTargetIndex];
            if (!isThere() && !stopTemp && isAllowedToMove)
            {
                move();

            }
            else if (isThere() && !stopTemp && isAllowedToMove) 
            {
                Vector3 f = new Vector3(0f, -90, 0f);
                f = Vector3.ClampMagnitude(f, 0.3f);
                gameObject.transform.GetChild(gameObject.transform.childCount - 1).Rotate(0.0f, -180, 0.0f, Space.Self);
                if (currentTargetIndex == pathTargets.Count - 1)
                {
                    Destroy(gameObject.transform.GetChild(gameObject.transform.childCount - 1).gameObject);
                    stopTemp = true;
                   yield return new WaitForSeconds(30f);
                    var newVehicle = Instantiate(preFab, gameObject.transform.position, Quaternion.identity);
                    newVehicle.transform.Rotate(0.0f, rt, 0.0f, Space.Self);
                    //newVehicle.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = this.activeNote.GetComponent<Note>().title;
                    newVehicle.transform.SetParent(gameObject.transform);
                    anim = gameObject.transform.GetChild(gameObject.transform.childCount - 1).GetComponent<Animator>();
                    //controller = GetComponent<CharacterController>();
                    rb = gameObject.transform.GetChild(gameObject.transform.childCount - 1).GetComponent<Rigidbody>();
                    currentTargetIndex = 0;
                    stopTemp = false;
                }
                else {
                    currentTargetIndex = currentTargetIndex + 1;
                }
                //currentTargetIndex = currentTargetIndex == pathTargets.Count - 1 ? 0 : currentTargetIndex + 1;
                //Quaternion targetRotation = Quaternion.LookRotation(f.normalized);
                //targetRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 180 * Time.fixedDeltaTime);
                //yield return new WaitForSeconds(30f);
                /*//yield return new WaitForSeconds(10f);
                //currentTargetIndex = currentTargetIndex + 1;
                if (anim.GetBool("isWalking"))
                {
                    anim.SetBool("isWalking", false);

                    if (gameObject.GetComponent<AudioSource>().isPlaying)
                    {
                        gameObject.GetComponent<AudioSource>().Stop();
                    }
                    System.Random rand = new System.Random();
                    var moveOrNot = rand.Next(0, 2);
                    Debug.Log(moveOrNot);
                    if (moveOrNot == 0)
                    {

                    }
                    else
                    {
                        anim.Play("Talking_On_Phone_Idle");
                        yield return new WaitForSeconds(50f);
                        anim.Play("Idle");
                        if (anim.GetBool("isTalkingOnPhone"))
                        {
                            //anim.SetBool("isTalkingOnPhone", true);
                            yield return new WaitForSeconds(50f);
                        }
                    }
                    yield return new WaitForSeconds(10f);
                    
                    anim.SetBool("isTalkingOnPhone", false);
                }*/
            }
        }
        else
        {
            currentTargetIndex = 0;
        }
        // if(currentTargetIndex != pathTargets.Count - 1){ -2.93   7.715   -5   -15   80  67.219

        // }else {

        // }


        // if(pathTargets.Count != 0 && currentTargetIndex < pathTargets.Count){

        //     if(transform.position.x - targetTemp.transform.position.x <= 1){
        //         if(currentTargetIndex == 0){

        //         currentTargetIndex = 1;
        //         } else {
        //         currentTargetIndex = 0;

        //         }
        //     }
        //     // rb.AddForce(f * force * Time.deltaTime,ForceMode.Impulse);
        // }
        //     // Debug.Log(f);

        // //currentTargetIndex = Random.Range(0, pathTargets.Count);
        // if(currentTargetIndex <= pathTargets.Count){

        // }
        //Vector3 move = transform.right * 1 + transform.forward * 1;
        // if(controller.detectCollisions){
        //     move = transform.right * Random.Range(-1,2) + transform.forward * Random.Range(-1,2);
        // }


        // //f = f.normalized;
        // f = f * force * Time.deltaTime;



    }
    // private void OnCollisionEnter(Collision other) {
    //     Debug.Log("Collided");
    //     Vector3 move = transform.right * Random.Range(-1,2) + transform.forward * Random.Range(-1,2);
    //     transform.RotateAround(transform.position, new Vector3(0f,0f,0f),90f);
    //     rb.AddForce(move * force * Time.deltaTime,ForceMode.Impulse);
    // }
    bool isThere()
    {
        return !stopTemp && Vector3.Distance(gameObject.transform.GetChild(gameObject.transform.childCount - 1).transform.position, targetTemp.transform.position) <= 2 ? true : false;
    }
    void move()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Talking_On_Phone_Idle"))
        {
            anim.SetBool("isWalking", true);
            /*gameObject.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("Audio/NPC_Walking_Audio", typeof(AudioClip));
            if (!gameObject.GetComponent<AudioSource>().isPlaying)
            {
                gameObject.GetComponent<AudioSource>().Play();
            }*/
            Vector3 f = targetTemp.transform.position - gameObject.transform.GetChild(gameObject.transform.childCount - 1).transform.position;
            f = Vector3.ClampMagnitude(f, 0.3f);
            //Debug.Log(f.y);
            //controller.Move(f * speed * Time.deltaTime);  
            rb.MovePosition(gameObject.transform.GetChild(gameObject.transform.childCount - 1).transform.position + f * 100f* Time.fixedDeltaTime);

            if (positionOfObject == "Forward")
            {
                /*f = targetTemp.transform.position - gameObject.transform.GetChild(gameObject.transform.childCount - 1).transform.position;
                f = Vector3.ClampMagnitude(f, 0.3f);*/
                //rb.MovePosition(gameObject.transform.GetChild(gameObject.transform.childCount - 1).transform.position + * 100f * Time.fixedDeltaTime);
            }

           /*if (positionOfObject == "Left") {
               rb.AddForce(transform.right * 20f, ForceMode.Acceleration);
           } else if (positionOfObject == "Right") {
               rb.AddForce(-transform.right * 20f, ForceMode.Acceleration);
           } else if (positionOfObject == "Forward") {
               rb.MovePosition(new Vector3(gameObject.transform.GetChild(gameObject.transform.childCount - 1).transform.position.x, gameObject.transform.GetChild(gameObject.transform.childCount - 1).transform.position.y, gameObject.transform.GetChild(gameObject.transform.childCount - 1).transform.position.z + 10f) * 10f * Time.fixedDeltaTime);
              // rb.AddForce(-.forward * 200f);
           }*/
           Quaternion targetRotation = Quaternion.LookRotation(f.normalized);
            //Debug.Log(targetRotation);
            targetRotation = Quaternion.RotateTowards(gameObject.transform.GetChild(gameObject.transform.childCount - 1).transform.rotation, targetRotation, 180 * Time.fixedDeltaTime);
            //rb.MoveRotation(targetRotation);
            // targetRotation.x = 0f;
            //transform.Rotate(Vector3.up * 100f * Time.deltaTime);
        }
    }
    
}
