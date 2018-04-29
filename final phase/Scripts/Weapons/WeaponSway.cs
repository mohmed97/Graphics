using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSway : MonoBehaviour {

    public float amount;
    public float maxamount;
    public float smoothAmount;
    private Vector3 initialPosition;

	void Start () {

        initialPosition = transform.localPosition;
        
		
	}
	
	// Update is called once per frame
	void Update () {

        float movmentX = -Input.GetAxis("Mouse X") + amount;
        float movmentY = -Input.GetAxis("Mouse Y") + amount;
        movmentX = Mathf.Clamp(movmentX, -maxamount, maxamount);
        movmentY = Mathf.Clamp(movmentY, -maxamount, maxamount);

        Vector3 finalPosition = new Vector3(movmentX, movmentY, 0);
        transform.localPosition = Vector3.Lerp(transform.localPosition, finalPosition + initialPosition, Time.deltaTime * smoothAmount);


    }
}
