using UnityEngine;
using System.Collections;

public class Const_Script : MonoBehaviour {
	const byte CAM_HEIGHT = 9, CAM_DEPTH = 10;
	const int RUN_SPEED = -1075;
	const byte NORM_WALL_SPAWN = 5, SIDE_WALL_SPAWN = 8, BRIDGE_WALL_SPAWN = 10;
	const byte BARRICADE = 0, CRATE = 1, BALL = 2, LOG = 3, SKELETON = 4, FALLEN_TREE = 5;
	const byte FIREBALL = 0, ICE_CUBE = 1, THUNDER_CONE = 3;
	const float obstacle1PositionX = 5.625f, obstacle2PositionX = 1.8f;

	public static float RunningSpeed
	{
		get
		{ return RUN_SPEED; }
	}
	/**************************************/
	public static byte Fireball
	{
		get
		{ return FIREBALL; }
	}
	public static byte IceCube
	{
		get
		{ return ICE_CUBE; }
	}
	public static byte ThunderCone
	{
		get
		{ return THUNDER_CONE; }
	}
	/**************************************/
	public static byte NormalWallSpawn
	{
		get
		{ return NORM_WALL_SPAWN; }
	}
	public static byte SideWallSpawn
	{
		get
		{ return SIDE_WALL_SPAWN; }
	}

	public static byte CameraHeight
	{
		get
		{ return CAM_HEIGHT; }
	}
	public static byte CameraDepth
	{
		get
		{ return CAM_DEPTH; }
	}
	public static byte BridgeWallSpawn
	{
		get
		{ return BRIDGE_WALL_SPAWN; }
	}

	public static float Barricade
	{
		get
		{ return BARRICADE; }
	}
	public static byte Crate
	{
		get
		{ return CRATE; }
	}
	public static byte Ball
	{
		get
		{ return BALL; }
	}
	public static byte Log
	{
		get
		{ return LOG; }
	}

	public static byte Skeleton
	{
		get
		{ return SKELETON; }
	}
	public static byte FallenTree
	{
		get
		{ return FALLEN_TREE; }
	}
	public static float Obstacle1PositionX
	{
		get
		{ return obstacle1PositionX; }
	}
	public static float Obstacle2PositionX
	{
		get
		{ return obstacle2PositionX; }
	}
}
