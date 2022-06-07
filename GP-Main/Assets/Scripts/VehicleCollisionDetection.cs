using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleCollisionDetection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var tagArray = new List<string>() { "Player", "Male NPC", "Female NPC", "Vehicle" };
        gameObject.transform.parent.GetComponent<Vehicle>().isAllowedToMove = true;
        for (var i =0; i < tagArray.Count;i++) {
            if (Vector3.Distance(gameObject.transform.position, GameObject.FindGameObjectWithTag(tagArray[i]).transform.position) <= 20)
            {
                gameObject.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("Audio/Car_horn_sound", typeof(AudioClip));
                if (!gameObject.GetComponent<AudioSource>().isPlaying)
                {
                    gameObject.GetComponent<AudioSource>().Play();
                }
                gameObject.transform.parent.GetComponent<Vehicle>().isAllowedToMove = false;
                return;
            }
            
        }
    }
    /*void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerMovement playerMovement))
        {
            
        }
        if (collision.gameObject.CompareTag("Male NPC"))
        {
            gameObject.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("Audio/Car_horn_sound", typeof(AudioClip));
            if (!gameObject.GetComponent<AudioSource>().isPlaying)
            {
                gameObject.GetComponent<AudioSource>().Play();
            }
            gameObject.transform.parent.GetComponent<Vehicle>().isAllowedToMove = false;
        }
        if (collision.gameObject.CompareTag("Female NPC"))
        {
            gameObject.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("Audio/Car_horn_sound", typeof(AudioClip));
            if (!gameObject.GetComponent<AudioSource>().isPlaying)
            {
                gameObject.GetComponent<AudioSource>().Play();
            }
            gameObject.transform.parent.GetComponent<Vehicle>().isAllowedToMove = false;
        }
        if (collision.gameObject.CompareTag("Vehicle"))
        {
            gameObject.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("Audio/Car_horn_sound", typeof(AudioClip));
            if (!gameObject.GetComponent<AudioSource>().isPlaying)
            {
                gameObject.GetComponent<AudioSource>().Play();
            }
            gameObject.transform.parent.GetComponent<Vehicle>().isAllowedToMove = false;
        }
        //gameObject.transform.parent.GetComponent<Vehicle>().isAllowedToMove = false;
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerMovement playerMovement))
        {
            gameObject.transform.parent.GetComponent<Vehicle>().isAllowedToMove = true;
        }
        if (collision.gameObject.CompareTag("Male NPC"))
        {
            gameObject.transform.parent.GetComponent<Vehicle>().isAllowedToMove = true;
        }
        if (collision.gameObject.CompareTag("Female NPC"))
        {
            gameObject.transform.parent.GetComponent<Vehicle>().isAllowedToMove = true;
        }
        if (collision.gameObject.CompareTag("Vehicle"))
        {
            gameObject.transform.parent.GetComponent<Vehicle>().isAllowedToMove = true;
        }
    }*/
}
