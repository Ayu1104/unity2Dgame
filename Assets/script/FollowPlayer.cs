using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

    // Use this for initialization
    public Transform player;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void LateUpdate()
    {
        Vector3 v3= player.position;
        transform.position = new Vector3(v3.x, v3.y, transform.position.z);
    }
}
