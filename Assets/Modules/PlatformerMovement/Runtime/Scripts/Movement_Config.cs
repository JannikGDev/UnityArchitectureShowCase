using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Systems/Movement/Config")]
public class Movement_Config : ScriptableObject
{
    [Header("Run")]
    [SerializeField]
    public bool enableMoveInput;

    [SerializeField] public float runAccel = 1;

    [SerializeField] public float runDeAccel = 1;

    [SerializeField] public float runTopSpeed = 5;
    
    [Range(-1,2)]
    [SerializeField] public float runVelPower = 1;

    [Header("Jump")]
    [SerializeField]
    public bool enableJump;
    
    [SerializeField] 
    public float jumpForce;
  
    [Header("Gravity")]
    [SerializeField]
    public bool enableGravity;
    
    [SerializeField] 
    public float gravityForce;
    
    [SerializeField] 
    public Vector2 gravityDirection;

    [Header("Ground Detection")] 
    [SerializeField]
    public float Skin;
    
    [SerializeField]
    public float GroundTolerance;

}
