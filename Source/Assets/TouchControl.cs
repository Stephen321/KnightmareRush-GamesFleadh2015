using UnityEngine;
using System.Collections;

public class TouchControl : MonoBehaviour {
	Touch initialTouch = new Touch();
	float distance = 0;
	bool hasSwiped = false;
	
	// Update is called once per frame
	void FixedUpdate () {
		foreach(Touch t in Input.touches)
		{
			if (t.phase == TouchPhase.Began)	//when the user presses their finger 1st time on screen
			{
				initialTouch = t;
			}
			else if (t.phase == TouchPhase.Moved && hasSwiped == false)	//When sliding finger across the screen
			{
				float deltaX = initialTouch.position.x - t.position.x;
				float deltaY = initialTouch.position.y - t.position.y;
				//distance formula
				distance = Mathf.Sqrt((deltaX * deltaX) + (deltaY * deltaY));
				bool swipedSideways = Mathf.Abs(deltaX) > Mathf.Abs(deltaY);

				if (distance > 100)
				{
					if (swipedSideways == true && deltaX > 0)	//swiped Left
					{

					}
					else if (swipedSideways == true && deltaX <= 0)	//swiped Right
					{

					}
					else if (swipedSideways == false && deltaY > 0)	//swiped Down
					{

					}
					else if (swipedSideways == false && deltaY <= 0) //swiped Up
					{

					}
					hasSwiped = true;
				}

				//direction
			}
			else if (t.phase == TouchPhase.Ended)	//When lifted finger off the screen
			{
				initialTouch = new Touch();
				hasSwiped = false;
			}
		}
	}
}
