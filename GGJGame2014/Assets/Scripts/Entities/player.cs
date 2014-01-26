using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	private int layer = 10;
	private int halfWidth;
	private int halfHeight;
	private float shipAngle;
	private Vector2 planetPos;

	private enum tools {
		heat,
		bio
	};

	public planet targetPlanet;

	tools currentTool = tools.heat;
	
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


		if (distance > 1 && distance < 240) {

			// Hypotenuse
			float height = (distance - mouse.y);
			float h = Mathf.Sqrt(height * height + mouse.x * mouse.x);

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

		if (Input.GetMouseButtonDown(0)) {
			Debug.Log(layer);
		}

	}
}
