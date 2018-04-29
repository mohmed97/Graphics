using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour {
    public Text CountText;
    private int count;
    public Text WinText;
    static int lastx;
    static int lastz;
    // Use this for initialization
    void Start () {
        count = 0;
        SetCountText();
        WinText.text = "";
    }
	
	// Update is called once per frame
	void Update () {
        /*int X, Z;
        GameObject prefab = Resources.Load("Skeleton@Skin") as GameObject;
        X = (int) this.transform.position.x ;
        Z = (int)this.transform.position.z;
        //if(lastx==X)a3mliha el condition w eno yabtaal ya3mlo create
        if (X % 50 == 0|| Z % 50 == 0)//tashtaghal 3la el ksoor w gheery rakm 50
        {
            for (int i = 1; i <= 3; i++){
                GameObject go = Instantiate(prefab);
                go.transform.position = this.transform.position + new Vector3(2 * i, 0, 30);
            }
        }*/
	}
    void SetCountText()
    {
        CountText.text = "Count: " + count.ToString(); //count ++ w nafs el satr fel 7eta bta3t die 
        if (count>=12)//lama yawsal el score ely e7na 3yzino
        {
            WinText.text = "Open the door";
        }
    }
}
