using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomPositionItem : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();
    public List<GameObject> randomPosition = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < items.Count; i++)
        {
            int rand = Random.Range(0, randomPosition.Count);
            items[i].transform.position = randomPosition[rand].transform.position;
            randomPosition.RemoveAt(rand);
        }
      /*  rand = Random.Range(0, randomPosition.Count);
        item2.transform.position = randomPosition[rand].transform.position;*/

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
