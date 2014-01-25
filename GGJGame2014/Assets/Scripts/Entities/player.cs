using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	int layer = 10;
	int halfWidth;
	int halfHeight;
	float shipAngle;
	Vector2 planetPos;
	
	// Use this for initialization
	void Start () {
		halfHeight = Screen.height / 2;
		halfWidth = Screen.width / 2;
		shipAngle = 0;
	}

	// Update is called once per frame
	void Update () {

		// Determine Mouse Position Relative to Planet Core
		Vector3 mouse = Input.mousePosition;
		mouse.x -= halfWidth;
		mouse.y -= halfHeight;
		float distance = Mathf.Sqrt(mouse.y * mouse.y + mouse.x * mouse.x);

		// Hypotenuse
		float height = (distance - mouse.y);
		float h = Mathf.Sqrt(height * height + mouse.x * mouse.x);


		if (distance < 240) {
			// Angle = acos(distance / hypotenuse)
			shipAngle = Mathf.Acos((distance * distance + distance * distance - h * h) / (2 * distance * distance));
			shipAngle = Mathf.Rad2Deg * shipAngle; 

			if (mouse.x > 0) {
				shipAngle *= -1;
			}

			// Set new ship angle
			Quaternion newAngle = Quaternion.Euler(0, 0, shipAngle);
			transform.rotation = Quaternion.Slerp(transform.rotation, newAngle, Time.deltaTime);


			layer = (int) distance / 40;
		} else {
			layer = -1;
		}

	}

	int GetLayer(){
		return layer;
	}
}
