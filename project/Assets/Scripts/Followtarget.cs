using UnityEngine;
using System.Collections;

public class Followtarget : MonoBehaviour {
    private Transform player;
    public float smoothing = 3;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
	}
	
	// Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPos = player.position + new Vector3(0, 3, -10);
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothing * Time.deltaTime);
	}
}
