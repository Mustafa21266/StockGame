using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
public class Newspaper : MonoBehaviour
{
    public delegate void NotifyClosenessToNewspaper(GameObject nearNewspaper);
    public static event NotifyClosenessToNewspaper onNotifyClosenessToNewspaper;

    public Sprite sprite;
    public Material material;

    public GameObject attatchedObject;

    public bool isRead = false;


    private void Awake() {
         this.attatchedObject = gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate() {
        // activate the effect when the player got close to the newspaper
        if(Vector3.Distance(gameObject.transform.position , GameObject.FindGameObjectWithTag("Player").transform.position) <= 5 && !GameObject.FindObjectOfType<DialogueSystemController>().isConversationActive){
            if(onNotifyClosenessToNewspaper != null && !isRead){
                onNotifyClosenessToNewspaper(gameObject);
                Behaviour halo = (Behaviour) gameObject.transform.parent.transform.GetChild(0).GetComponent("Halo");
                halo.enabled = true; // false
                
                //gameObject.GetComponent<Halo>();
            }
        }
    }
    public void disableEffects(){
        // disbale the effect after collect the newspaper
        gameObject.transform.parent.GetChild(0).gameObject.SetActive(false);
        Behaviour halo = (Behaviour) gameObject.transform.parent.transform.GetChild(0).GetComponent("Halo");
        halo.enabled = false; // false
    }
    public void changeNewspaperSprite(Sprite newSprite, Material newMaterial){
        // changing the current newspaper
        this.sprite = newSprite;
        this.material = newMaterial;
        Debug.Log(newSprite);
        // new Shader()
        gameObject.transform.GetComponent<MeshRenderer>().material = newMaterial;

    }
}
