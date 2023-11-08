using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2DFollow : MonoBehaviour
{
	public Transform target;
	
	public Vector3 offset = new Vector3(10f, 0f, -10f);
	
	[Range(1, 10)]
	public float smoothing = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	private void FixedUpdate()
	{
		Vector3 targetPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.fixedDeltaTime);
        transform.position = smoothPosition;
	}
}
