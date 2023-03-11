using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private Player player;
    
    private void Update()
    {
        
    
        if (player.IsDetectable())
        {
            // Chase Player
        }
        else
        {
            // Idle
        }
    }
}
