using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerControlKeyboard : MonoBehaviour {
	public class PlatLanes
	{
		float xPos;
		
		public PlatLanes(float p)
		{
			xPos = p;
		}

		public float PosX
		{
			get
			{ return xPos; }
		}
	}



	public KeyCode moveLeft, moveRight, jump, slice, castSpell;
	public GameObject fireball, iceCube, thunderCone, sliceWave;
	public Transform magicHandPos;
	public UpdateCoinsDisplay coinScript;
	public UpdateDistanceDisplay distanceScript;

	//Animators Parameters for more efficient code
	int jumpHash = Animator.StringToHash("Jump");
	int collideHash = Animator.StringToHash("Collide");
	int dashLeft = Animator.StringToHash("DashLeft");
	int dashRight = Animator.StringToHash("DashRight");
	int sliceHash = Animator.StringToHash("Slice");
	int castSpellHash = Animator.StringToHash("CastSpell");
	int tripHash = Animator.StringToHash("Trip");
	int reviveHash = Animator.StringToHash("Revive");

	//Animators States for more efficient code
	int runStateHash = Animator.StringToHash("Base Layer.Run");

	int lane = 1;
	bool canJump = false, alive = true, dl = false, isOnTopOfObstacle = false;
	float zP = 0, xP = 0, yP = 0, maxHeight, jumpTimer = 0;
	List<PlatLanes> lanes = new List<PlatLanes> (3);
	Animator anim;

	
	//public AudioClip death;
	public AudioClip landing, pain, moan1, moan2, dash;



	void Start () {
		lanes.Add (new PlatLanes (Const_Script.Obstacle1PositionX));//platform.renderer.bounds.size.x / 4));
		lanes.Add (new PlatLanes (0));
		lanes.Add (new PlatLanes (-Const_Script.Obstacle1PositionX));//-platform.renderer.bounds.size.x / 4));

		anim = GetComponent<Animator> ();
		zP = Const_Script.RunningSpeed;
		maxHeight = 3.5f;
	}

	void Dashing()
	{
		if (dl == true)
		{
			dl = false;
			anim.SetBool("LD", dl);
		}
		if (Input.GetKeyDown(moveLeft) == true && lane > 0)	//Input.getKey (checks constantly) getKeyDown (checks once)
		{
			GetComponent<AudioSource>().clip = dash;
			GetComponent<AudioSource>().pitch = Random.Range(0.9f,1.1f);
			GetComponent<AudioSource>().Play();
			lane--;
			GameManager.Dashes++;
			anim.SetTrigger(dashLeft);
			dl = true;
			anim.SetBool("LD", dl);
		}
		else if (Input.GetKeyDown(moveRight) == true && lane < 2)
		{
			GetComponent<AudioSource>().clip = dash;
			GetComponent<AudioSource>().pitch = Random.Range(0.9f,1.1f);
			GetComponent<AudioSource>().Play();
			lane++;
			GameManager.Dashes++;
			anim.SetTrigger(dashRight);
		}
		else
		{
			if (transform.position.x < lanes[lane].PosX - 0.5f || transform.position.x > lanes[lane].PosX + 0.5f)
			{
				if (transform.position.x < lanes[lane].PosX - 0.5f)
					xP = 1750 * Time.deltaTime;
				else if (transform.position.x > lanes[lane].PosX + 0.5f)
					xP = -1750 * Time.deltaTime;
			}
			else
			{
				if (transform.position.x <= lanes[lane].PosX - 0.5 || transform.position.x >= lanes[lane].PosX + 0.5)
				{
					transform.position = new Vector3(lane, transform.position.y, transform.position.z);
				}
				xP = 0;
			}
		}
	}

	void Actions()
	{
		AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
		if (stateInfo.fullPathHash == runStateHash)
		{
			if (Input.GetKeyDown(castSpell) == true && canJump == true && GameManager.Mana >= 25)
			{
				anim.SetTrigger(castSpellHash);
				if (Random.Range(0,2) == 0)
					GetComponent<AudioSource>().clip = moan1;
				else
					GetComponent<AudioSource>().clip = moan2;
				GetComponent<AudioSource>().pitch = Random.Range(0.9f,1.1f);
				GetComponent<AudioSource>().Play();

				if (GameManager.SpellEquiped == Const_Script.Fireball)
				{
					GameManager.ReduceMana();
					Instantiate(fireball, magicHandPos.position + new Vector3(-1, 0, -3.75f), Quaternion.identity);
					Instantiate(fireball, magicHandPos.position + new Vector3(-1, 2, -4), Quaternion.identity);
				}
				else if (GameManager.SpellEquiped == Const_Script.IceCube)
				{
					GameManager.ReduceMana();
					Instantiate(iceCube, magicHandPos.position + new Vector3(-1, 0, -5.5f), Quaternion.identity);
					Instantiate(iceCube, magicHandPos.position + new Vector3(-1, 2, -5.75f), Quaternion.identity);
					Instantiate(iceCube, magicHandPos.position + new Vector3(-1, 4, -6), Quaternion.identity);
				}
				else if (GameManager.SpellEquiped == Const_Script.ThunderCone)
				{
					GameManager.ReduceMana();
					Instantiate(thunderCone, magicHandPos.position + new Vector3(-2, 3, -4), Quaternion.identity);
				}
			}
			
			if (Input.GetKeyDown(slice) == true && canJump == true)
			{
				if (Random.Range(0,2) == 0)
					GetComponent<AudioSource>().clip = moan1;
				else
					GetComponent<AudioSource>().clip = moan2;
				GetComponent<AudioSource>().pitch = Random.Range(0.9f,1.1f);
				GetComponent<AudioSource>().Play();

				anim.SetTrigger(sliceHash);
				Instantiate(sliceWave, magicHandPos.position + new Vector3(-1.35f, 2, 0), sliceWave.transform.rotation);// Quaternion.Inverse(magicHandPos.rotation));
			}
		}
		if (Input.GetKey(jump) == true && canJump == true && stateInfo.fullPathHash == runStateHash)
		{
			if (Random.Range(0,2) == 0)
				GetComponent<AudioSource>().clip = moan1;
			else
				GetComponent<AudioSource>().clip = moan2;
			GetComponent<AudioSource>().pitch = Random.Range(0.9f,1.1f);
			GetComponent<AudioSource>().Play();

			if (jumpTimer >= 0.05f)
			{
				yP = 75 * Time.deltaTime;
				canJump = false;
				GameManager.Jumps++;
				anim.SetTrigger(jumpHash);
			}
		}
		else
		{
			if (transform.position.y > maxHeight/2)
			{
				yP = -75 * Time.deltaTime;
			}
			jumpTimer += Time.deltaTime;
		}
	}

	// Update is called once per frame
	void Update () {
		if (alive == true)
		{
			Dashing();
			Actions();

			if (transform.position.y <= -30) {
				GameManager.TakeDamage(true);
				alive = false;
				anim.SetBool("Alive",alive);
			}


			GetComponent<Rigidbody>().velocity = new Vector3 (xP, GetComponent<Rigidbody>().velocity.y + yP, zP * Time.deltaTime);
			GameManager.Distance = (int)(-GetComponent<Rigidbody>().position.z);
			distanceScript.UpdateDistance();
		}
	}


	void OnCollisionEnter (Collision colInfo) 
	{
		if (colInfo.collider.tag == "Ground" && canJump == false)
		{
			GetComponent<AudioSource>().clip = landing;
			GetComponent<AudioSource>().pitch = Random.Range(0.9f,1.1f);
			GetComponent<AudioSource>().Play();
			
			yP = 0;
			canJump = true;
			isOnTopOfObstacle = false;
			jumpTimer = 0;
		}

		if (colInfo.collider.tag == "TripObstacle" || colInfo.collider.tag == "BackObstacle" && isOnTopOfObstacle == false)
		{
			if (!GameManager.Invincable)
			{
				if (alive == true)
				{
					if ((colInfo.transform.position.y + colInfo.collider.bounds.size.y/2 - 1f) > this.transform.position.y)
					{
						if (GameManager.Lives > 0)
						{
							if (colInfo.transform.position.y + colInfo.collider.bounds.size.y/2 < 4 && colInfo.collider.tag == "TripObstacle")
							{
								GameManager.TakeDamage(false);
								anim.SetTrigger(tripHash);

								if (GameManager.Lives <= 0)
								{
									GameManager.TakeDamage(true);
									//	audio.clip = death;
									alive = false;
									anim.SetBool("Alive",alive);
								}
								colInfo.gameObject.SendMessage("Destroy");
							}
							else
							{
								GameManager.TakeDamage(true);
								zP = 0;
								xP = 0;
								GetComponent<Rigidbody>().velocity = new Vector3 (xP, GetComponent<Rigidbody>().velocity.y, zP * Time.deltaTime);
								alive = false;
								if (colInfo.collider.tag == "TripObstacle")
									anim.SetBool("Alive",alive);
								else
									anim.SetTrigger(collideHash);
								colInfo.gameObject.SendMessage("PlayAudio");
							}
						}
					}
					else
					{
						GetComponent<AudioSource>().pitch = Random.Range(0.9f,1.1f);
						isOnTopOfObstacle = true;
						GetComponent<Rigidbody>().velocity = new Vector3 (GetComponent<Rigidbody>().velocity.x, 0, GetComponent<Rigidbody>().velocity.z);
					}
					GetComponent<AudioSource>().clip = pain;
					GetComponent<AudioSource>().Play();
				}
			}
		}
	}

	void OnTriggerEnter(Collider colInfo)
	{
		if (colInfo.GetComponent<Collider>().tag == "Collectible")
		{
			GameManager.AddCoins(false);
			coinScript.UpdateCoins();
			colInfo.gameObject.SendMessage("PlayAudio");
		}

		if (colInfo.GetComponent<Collider>().tag == "Treasure")
		{
			GameManager.AddCoins(true);
			coinScript.UpdateCoins();
			colInfo.gameObject.SendMessage("PlayAudio");
		}

		if (colInfo.GetComponent<Collider>().tag == "DropZone") {
			this.GetComponent<Collider>().enabled = false;
			anim.SetBool("Alive",false);
			GetComponent<Rigidbody>().velocity = new Vector3 (xP, GetComponent<Rigidbody>().velocity.y + yP, zP * Time.deltaTime);
		}
	}

	public void Revive() {		
		GameManager.Lives = 3;
		zP = Const_Script.RunningSpeed;
		alive = true;
		anim.SetBool ("Alive", true);
		anim.SetTrigger (reviveHash);
		transform.position = new Vector3 (0, 0, transform.position.z + 10);
	}
}
