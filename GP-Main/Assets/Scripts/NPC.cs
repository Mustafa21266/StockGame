using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NPC : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    private float force = 1f;
    public float speed = 5f; 

    public List<GameObject> pathTargets;
    public GameObject target;
    public Rigidbody rb;

    private CharacterController controller;

    private int currentTargetIndex = 0;

    private GameObject targetTemp;
    void Start()
    {
        anim = GetComponent<Animator>();
        //controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        if (gameObject.transform.parent != null) { 
        for(var i = 1; i <  gameObject.transform.parent.childCount; i++){
            pathTargets.Add(gameObject.transform.parent.GetChild(i).gameObject);
        }

        
        }
        //Debug.Log(gameObject.CompareTag("Male NPC - Secretary").ToString() + gameObject.transform.parent.childCount);
        if(gameObject.CompareTag("Female NPC") || gameObject.CompareTag("Male NPC")){
            anim.SetBool("isWalking", false);
            // if(){
            //     anim.SetBool("isBusy", true);
            // }
        }
        if(gameObject.CompareTag("Female NPC - Secretary") || gameObject.CompareTag("Male NPC - Secretary")){
            anim.SetBool("isBusy", true);
        }
        // if(gameObject.transform.parent.childCount == 1 && !gameObject.CompareTag("Female NPC - Secretary")){

        // }else if(gameObject.transform.parent.childCount == 1 && gameObject.CompareTag("Female NPC - Secretary")){
        // }else if(gameObject.transform.parent.childCount == 1 && !gameObject.CompareTag("Male NPC - Secretary")){
        //     anim.SetBool("isWalking", false);
        // }else if(gameObject.transform.parent.childCount == 1 && gameObject.CompareTag("Male NPC - Secretary")){
        //     Debug.Log("SDASDAS");
        // }
        //gameObject.transform.parent.gameObject.transform.GetChild()
        
    }
    private void Update() {
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
        //StartCoroutine(changeIdleAnimation());
        if(pathTargets.Count > 0){
            
            StartCoroutine(moveNPC());
        }
        
        //transform.position.Set(transform.position.x,transform.position.y,GameObject.FindGameObjectWithTag("Player").transform.position.z - 10);
        
    }
    IEnumerator changeIdleAnimation(){
        // yield return new WaitForSeconds(5f);
        // yield return new WaitForSeconds(1f);
        //yield return new WaitForSeconds(1f);
        // var IdleAnim = anim.GetInteger("IdleAnim");
        anim.SetBool("isWalking", false);
        if(gameObject.GetComponent<AudioSource>().isPlaying){
                    gameObject.GetComponent<AudioSource>().Stop();
                }
        yield return new WaitForSeconds(5f);
        
        //anim.SetBool("isWalking", false);
        // Vector3 f = new Vector3(0f,0f,2f);
        // f = f.normalized;
        // f = f * force;
        // rb.AddForce(f * Time.deltaTime,ForceMode.Impulse);

        
        //anim.SetBool("isWalking", true);

        // if(anim.GetBool("isStatic")){
        //     yield return new WaitForSeconds(5f); -25 -20
        //180   20  30
        //     anim.SetBool("isStatic", false);
        // }else {
        //     anim.SetBool("isStatic", true);
        // }
        //anim.SetInteger("IdleAnim", IdleAnim + 1);
    }
IEnumerator moveNPC(){
    yield return new WaitForSeconds(1f);
    //Debug.Log(pathTargets.Count);
    //Debug.Log(Vector3.Distance(transform.position,targetTemp.transform.position));
    //Debug.Log(currentTargetIndex);

    if(currentTargetIndex < pathTargets.Count){
        targetTemp = pathTargets[currentTargetIndex];
        if(!isThere()){
            move();
        }else {
            //yield return new WaitForSeconds(10f);
            //currentTargetIndex = currentTargetIndex + 1;
            if(anim.GetBool("isWalking")){
                anim.SetBool("isWalking", false);
                if(gameObject.GetComponent<AudioSource>().isPlaying){
                    gameObject.GetComponent<AudioSource>().Stop();
                }
                yield return new WaitForSeconds(10f);      
                currentTargetIndex = currentTargetIndex == pathTargets.Count - 1 ? 0 : currentTargetIndex + 1;
        }
        }
    }else {
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
    bool isThere(){
        return Vector3.Distance(transform.position,targetTemp.transform.position) <= 2 ? true : false;
    }
    void move(){
        anim.SetBool("isWalking", true);
        gameObject.GetComponent<AudioSource>().clip =  (AudioClip) Resources.Load("Audio/NPC_Walking_Audio", typeof(AudioClip));
        if(!gameObject.GetComponent<AudioSource>().isPlaying){
            gameObject.GetComponent<AudioSource>().Play();
        }
        Vector3 f =  targetTemp.transform.position - transform.position;
        f =  Vector3.ClampMagnitude(f, 0.3f);
        //Debug.Log(f.y);
        //controller.Move(f * speed * Time.deltaTime);  
        rb.MovePosition(transform.position + f * 20f * Time.fixedDeltaTime);
        Quaternion targetRotation = Quaternion.LookRotation(f.normalized);
        //Debug.Log(targetRotation);
        targetRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 180 * Time.fixedDeltaTime);
        rb.MoveRotation(targetRotation);
        // targetRotation.x = 0f;
        //transform.Rotate(Vector3.up * 100f * Time.deltaTime);
    }
}
