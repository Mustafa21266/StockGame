using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NPCManager : MonoBehaviour
{
    [SerializeField]
    private List<NPC> npcList;

    private Scene scene;
    // Start is called before the first frame update
    void Start()
    {
        // scene = SceneManager.GetActiveScene();

        NPC newNPC = GameObject.Instantiate(npcList[0]);
        newNPC.transform.SetParent(transform);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
