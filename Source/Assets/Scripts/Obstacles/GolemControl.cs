using UnityEngine;
using System.Collections;

public class GolemControl : MonoBehaviour {
	bool canShoot, canFight, inFightStance, frozen, alive;
	byte lives;

	public GameObject cannonBall;
	public Transform spawnPos;
	public AudioClip shoot, growl;

	//Animators Parameters for more efficient code
	int ready2shoot = Animator.StringToHash("PlayerOnSight");
	int punch = Animator.StringToHash("Attack");
	int die = Animator.StringToHash("Died");

	int firedStateHash = Animator.StringToHash("Base Layer.Fired");
	int fightStateHash = Animator.StringToHash("Base Layer.FightStance");

	Animator anim;

	// Use this for initialization
	void Start () {
		canShoot = false;
		canFight = false;
		inFightStance = false;
		frozen = false;
		alive = true;

		lives = 3;
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (frozen == false && alive == true)
		{
			Vector3 playerPositon = GameObject.FindGameObjectWithTag("Player").transform.position;

			if (canFight == false)
			{
				if(playerPositon.z < transform.position.z + 65 && canShoot == false) {
					anim.SetTrigger(ready2shoot);
					canShoot = true;
				}
				else if (canShoot == true)
				{
					AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
					if (stateInfo.fullPathHash == firedStateHash)
					{
						GetComponent<AudioSource>().clip = shoot;
						GetComponent<AudioSource>().pitch = Random.Range(0.9f,1.1f);
						GetComponent<AudioSource>().Play();

						GameObject cannonBallClone = (GameObject)Instantiate(cannonBall, spawnPos.position, Quaternion.identity);
						cannonBallClone.GetComponent<Rigidbody>().AddForce(0,60000,75000);
						canFight = true;
					}
				}
			}
			else
			{
				if (inFightStance == false)
				{
					AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
					if (stateInfo.fullPathHash == fightStateHash)
					{
						inFightStance = true;
					}
				}
				else if (playerPositon.z < transform.position.z + 10)
				{
					anim.SetTrigger(punch);
					inFightStance = false;
				}
			}
		}
	}

	void PlayAudio()
	{
		GetComponent<AudioSource> ().clip = growl;
		GetComponent<AudioSource>().pitch = Random.Range(0.8f,1.1f);
		GetComponent<AudioSource>().Play ();
	}

	void OnCollisionEnter (Collision colInfo) 
	{
		if (colInfo.collider.tag == "Psword" ||colInfo.collider.tag == "FireSpell" || colInfo.collider.tag == "ThunderSpell")
		{
			lives--;
			if (lives == 0)
			{
				GameManager.Kills++;
				anim.SetTrigger(die);
				GetComponent<Rigidbody>().Sleep();
				GetComponent<Rigidbody>().detectCollisions = false;
			}
		}
		if (colInfo.collider.tag == "IceSpell")
		{
			frozen = true;
			anim.enabled = false;
		}
	}
}
