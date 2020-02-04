using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class countdownTimer : MonoBehaviour
{

    public Text textTimer;

    public Text textDead;

    public Text textSurvival;
    public Button btnTryAgain;
    public Image black;
    public List<Light> lights = new List<Light>();

    private bool finish;

    private bool onceTime;
    private float countDownTimer = 60;

    private float rot = 0;
    private float opacity = 0;
    // Start is called before the first frame update
    void Start()
    {
        finish = false;
        onceTime = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(countDownTimer >=0 && !finish)
            countDownTimer -= Time.deltaTime;
      
        textTimer.text = countDownTimer.ToString("00");

        if (countDownTimer < 20 )
            allLightsRed();

        if (countDownTimer <= 0)
            deadPlayer();

        survivalPlayer();
    }
    private void allLightsRed() {
        foreach (Light light in lights)
        {
            light.color = Color.red;
        }
    }

    private void deadPlayer() {
        // disable movement
        GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = false;

        // rotate player
        if (rot < 90)
            rot += 75 * Time.deltaTime;
        GameObject.Find("FPSController").GetComponent<Transform>().transform.rotation = Quaternion.AngleAxis(rot, Vector3.forward);

        // fade out
        if (rot > 90 && opacity <= 1f)
            opacity += Time.deltaTime;
        black.color = new Color(0, 0, 0, opacity);

        if (opacity >= 1)
        {
            btnTryAgain.GetComponent<Image>().enabled = true;
            btnTryAgain.GetComponentInChildren<Text>().enabled = true;
            textDead.enabled = true;

            GameObject.Find("SoundAudio").GetComponent<AudioSource>().Stop();
            if (!onceTime)
            {
                GameObject.Find("DeadAudio").GetComponent<AudioSource>().Play();
                onceTime = true;
            }
            Cursor.lockState = CursorLockMode.None;            
        }        
    }
    private void survivalPlayer() {
        finish = GameObject.Find("FPSController").GetComponent<playerBehaviour>().getFinishGame();

        if (finish)
        {
            GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = false;

            // fade out
            if (opacity <= 1f)
                opacity += Time.deltaTime;
            black.color = new Color(0, 0, 0, opacity);

            if (opacity >= 1)
            {
                textSurvival.enabled = true;

                GameObject.Find("SoundAudio").GetComponent<AudioSource>().Stop();
                if (!onceTime)
                {
                    GameObject.Find("SurvivalAudio").GetComponent<AudioSource>().Play();
                    onceTime = true;
                }
                
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
}
