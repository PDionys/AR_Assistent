using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToCameraCloud : MonoBehaviour
{
	private void Update()
	{
		transform.LookAt(Camera.main.transform);

		Vector3 eulerAngels = transform.eulerAngles;
		transform.rotation = Quaternion.Euler(0, eulerAngels.y, 0);
	}
}
