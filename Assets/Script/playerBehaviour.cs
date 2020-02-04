using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class playerBehaviour : MonoBehaviour
{
    public Text message;
    private bool energyBlue;
    private bool energyGreen;
    private bool energyLightBlue;
    private bool energyYellow;
    private bool generatorBlue;
    private bool generatorGreen;
    private bool generatorLightBlue;
    private bool generatorYellow;

    private bool generatorsOn;
    private bool exitDoor;

    float rot = 0;
    // Start is called before the first frame update
    void Start()
    {
        energyBlue = false;
        energyGreen = false;
        energyLightBlue = false;
        energyYellow = false;

        generatorsOn = false;
        exitDoor = false;

        generatorBlue = false;
        generatorGreen = false;
        generatorLightBlue = false;
        generatorYellow = false;
    }

    // Update is called once per frame
    void Update()
    {     
        collectAllItems();

    }
    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "energyBlue") 
        {
            energyBlue = true;
            Destroy(hit.gameObject);
            GameObject.Find("CollectItemAudio").GetComponent<AudioSource>().Play();
        }

        if (hit.gameObject.tag == "energyGreen")
        {
            energyGreen = true;
            Destroy(hit.gameObject);

            GameObject.Find("CollectItemAudio").GetComponent<AudioSource>().Play();
        }
        if (hit.gameObject.tag == "energyLightBlue")
        {
            energyLightBlue = true;
            Destroy(hit.gameObject);

            GameObject.Find("CollectItemAudio").GetComponent<AudioSource>().Play();
        }
       

        if (hit.gameObject.tag == "energyYellow")
        {
            energyYellow = true;
            Destroy(hit.gameObject);

            GameObject.Find("CollectItemAudio").GetComponent<AudioSource>().Play();
        }

        

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "generatorLightBlue" && energyLightBlue)
        {
            other.GetComponent<Light>().color = Color.white;
            generatorLightBlue = true;
            if (energyLightBlue)
            {
                GameObject.Find("CollectItemAudio").GetComponent<AudioSource>().Play();
                energyLightBlue = false;
            }
        }
        if (other.gameObject.tag == "generatorBlue" && energyBlue)
        {
            other.GetComponent<Light>().color = Color.white;
            generatorBlue = true;
            if (energyBlue)
            {
                GameObject.Find("CollectItemAudio").GetComponent<AudioSource>().Play();
                energyBlue = false;
            }
        }
        if (other.gameObject.tag == "generatorYellow" && energyYellow)
        {
            other.GetComponent<Light>().color = Color.white;
            generatorYellow = true;
            if (energyYellow)
            {
                GameObject.Find("CollectItemAudio").GetComponent<AudioSource>().Play();
                energyYellow = false;
            }
        }
        if (other.gameObject.tag == "generatorGreen" && energyGreen)
        {
            other.GetComponent<Light>().color = Color.white;
            generatorGreen = true;
            if (energyGreen) 
            {
               GameObject.Find("CollectItemAudio").GetComponent<AudioSource>().Play();
                energyGreen = false;
            }
        }

        if (other.gameObject.tag == "exit")
        {
            if (generatorsOn)
            {
                message.text = "The door is unlocked";
                exitDoor = true;
            }
            else
            {
                message.text = "You have to find all energies and\n put them in the machines with same colour";
            }

            messageManager();
        }
    }
    public void collectAllItems() {
        if (generatorBlue && generatorGreen && generatorLightBlue && generatorYellow)        
            generatorsOn = true;

        if (generatorsOn) {

            GameObject.Find("Point Light (3)").GetComponent<Light>().color = Color.green;
        }
    }

    public bool getFinishGame() {
        return exitDoor;
    }

    public void messageManager() {

        float time = 0f;
        time += Time.deltaTime;
        if (time > 5)
        {
            message.text = "";
            time = 0;
        }
    }
   
    
    
}
