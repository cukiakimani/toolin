using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	// Jump Variables 

    [Header("Jump Variables")]
    public float JumpForce = 250f;
    public float WallJumpForce = 500f;
    public float JumpAcceleration = 50f;
    public float MaxJumpHeight = 400f;
    public float JumpBufferTime = 0.3f;
    public float JumpApexSpeedModifier;
    public float InputJumpBufferTime = 0.3f;

    //Move Variables 
    [Header("Move Variables")]
    public float MoveForce = 300f;
    public float MaxMoveSpeed = 1000f;
    public float AirDamping = 1f;
    public float GroundDamping = 2f;
    
    //Sounds 

    [Header("Sounds")]
    public AudioClip[] JumpSounds;
    public AudioClip[] WalkSounds;
    public AudioClip[] EffortSounds;
    private AudioClip JumpSound;
    private AudioClip WalkSound;

    [Space]
    // Should not be edited in inspector

    [HideInInspector]
    public AudioClip _previousEffort;
    
    [HideInInspector]
    public bool DashPriorityUp;
    [HideInInspector]
    public bool ExternalForceApplying;
    [HideInInspector]
    public bool CanHoldJump;
    [HideInInspector]
    public bool HasJumped;

    [HideInInspector]
    public float ExternalForceMaxSpeed,
        PlayerHMoveSpeed, 
        PlayerHExternalSpeed, 
        PlayerRemainderHDashSpeed;
	
    void Start()
    {
	
    }
	
	
    void Update()
    {
	
    }
}
