using UnityEngine;
using System.Collections;

public class SkeletonAnimation : MonoBehaviour {
	Animator anim;
	bool dead;
	bool frozen;
	bool playerBehind;

	int slashHash = Animator.StringToHash("Slash");
	int stabHash = Animator.StringToHash("Stab");
	int hurtHash = Animator.StringToHash("Hurt");

	int idleStateHash = Animator.StringToHash("Base Layer.Idle");
	int hurtStateHash = Animator.StringToHash("Base Layer.Hurt");

	bool playedDeathClip;

	public AudioClip cowered, boneBreaking, deathFalling;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();

		frozen = false;
		playerBehind = false;
		playedDeathClip = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(frozen == false && playedDeathClip == false)
		{
			Vector3 position = GameObject.FindWithTag("Player").transform.position;

			if(position.z < transform.position.z + 10 && position.z > this.transform.position.z){
				AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
				if (stateInfo.fullPathHash == idleStateHash)
				{
					if (Random.Range(1,3) == 1)
						anim.SetTrigger(slashHash);
					else
						anim.SetTrigger(stabHash);
				}
			}
			else if (position.z <= this.transform.position.z - this.GetComponent<Collider>().bounds.size.z && playerBehind == false)
			{
				playerBehind = true;
				GetComponent<AudioSource>().clip = cowered;
				GetComponent<AudioSource>().pitch = Random.Range(0.9f,1.1f);
				GetComponent<AudioSource>().Play();
			}
			if (dead == true)
			{
				AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
				if (stateInfo.fullPathHash == hurtStateHash)
				{
					GetComponent<AudioSource>().clip = deathFalling;
					GetComponent<AudioSource>().pitch = Random.Range(0.9f,1.1f);
					GetComponent<AudioSource>().Play();
					playedDeathClip = true;
				}
			}
		}
		else if (frozen == true && dead == true)
		{
			GetComponent<Rigidbody>().Sleep();
			GetComponent<Rigidbody>().detectCollisions = false;
			GetComponent<Rigidbody>().useGravity = false;
		}
	}

	void PlayAudio()
	{
		GetComponent<AudioSource> ().clip = boneBreaking;
		GetComponent<AudioSource>().pitch = Random.Range(0.9f,1.1f);
		GetComponent<AudioSource>().volume = 1;
		GetComponent<AudioSource>().Play ();
	}

	void OnCollisionEnter (Collision colInfo) 
	{
		if(colInfo.collider.tag == "Player"){
			GetComponent<Rigidbody>().AddForce(0,0,-20000);
		}
		if (colInfo.collider.tag == "Psword" || colInfo.collider.tag == "FireSpell" || colInfo.collider.tag == "ThunderSpell")
		{
			PlayAudio();

			anim.SetTrigger(hurtHash);
			GetComponent<Rigidbody>().Sleep();
			GetComponent<Rigidbody>().detectCollisions = false;
			GetComponent<Rigidbody>().useGravity = false;
			dead = true;

			GameManager.Kills++;
		}
		if (colInfo.collider.tag == "IceSpell")
		{
			PlayAudio();
			frozen = true;
		}
	}
}
