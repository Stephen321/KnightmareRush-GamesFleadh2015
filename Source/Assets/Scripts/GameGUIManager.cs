using UnityEngine;
using System.Collections;

public class GameGUIManger : MonoBehaviour {
	public Texture2D aTexture;
	public Rect textureCrop = new Rect( 0, 0, 0.26f, 0.25f );
	Vector2 position = new Vector2( 720, 10 );
	public Transform player;


	bool active;
	float timer;
	const float displayDuration = 2.5f;
	int kill, magicKill, collectible;
	int rewardCollectible, rewardCollectableCount,
	rewardDistance,rewardDistanceCount, 
	rewardKill, rewardKillCount, 
	rewardMagicKill,rewardMagicKillCount;

	// Use this for initialization
	void Start () {
		kill =0;
		magicKill = 0;
		collectible = 0;

		rewardCollectible = 5;
		rewardCollectableCount = 0;
		rewardDistance = -200;
		rewardDistanceCount = 0; 
		rewardKill = 5;
		rewardKillCount= 0;
		rewardMagicKill = 5;
		rewardMagicKillCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(active == true){
			timer += Time.deltaTime;
			if(timer > displayDuration){
				active = false;
				timer = 0;
				if(rewardCollectableCount < 3 && collectible > rewardCollectible ){
					rewardCollectableCount ++;
					rewardCollectible *= 5;
				}
				else if(rewardDistanceCount < 3 && player.position.z < rewardDistance ){
					rewardDistanceCount ++;
					rewardDistance *= 5;
				}
				else if(rewardKillCount < 3 && kill > rewardKill ){
					rewardKillCount ++;
					rewardKill *= 3;
				}
				else if(rewardMagicKillCount < 3 && magicKill > rewardMagicKill ){
					rewardMagicKillCount ++;
					rewardMagicKill *= 3;
				}
			}
		}
		else if(rewardCollectableCount < 3 && collectible > rewardCollectible ){
			active = true; 
			textureCrop = new Rect( 0.255f * rewardCollectableCount, 0, 0.26f, 0.25f);
		}
		else if(rewardDistanceCount < 3 && player.position.z < rewardDistance ){
			active = true;
			textureCrop = new Rect( 0.255f * rewardDistanceCount, 0.246f , 0.26f, 0.25f);
		}
		else if(rewardKillCount < 3 && kill > rewardKill ){
			active = true; 
			textureCrop = new Rect( 0.255f * rewardKillCount,  0.492f, 0.26f, 0.25f);
		}
		else if(rewardMagicKillCount < 3 && magicKill > rewardMagicKill ){
			active = true;
			textureCrop = new Rect( 0.255f * rewardMagicKillCount, 0.738f, 0.26f, 0.25f);
		}
	}


	void OnGUI() {
		if(active == true){
			GUI.BeginGroup( new Rect( position.x, position.y, aTexture.width * textureCrop.width, aTexture.height * textureCrop.height ) );
			GUI.DrawTexture( new Rect( -aTexture.width * textureCrop.x, -aTexture.height * textureCrop.y, aTexture.width, aTexture.height ), aTexture );
			GUI.EndGroup();
		}
	}
}
