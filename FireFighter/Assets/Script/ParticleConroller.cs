using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleConroller : MonoBehaviour
{
    public FireManager fireManager;
    public void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("FirePoint"))
        {
            int _firePointNumber = other.GetComponent<FirePoint>().firePointNumber;
            fireManager.DestroyFire(_firePointNumber);
        }
        
    }

    
}
