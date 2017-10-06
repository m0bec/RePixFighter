using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffect : MonoBehaviour {

	private ParticleSystem ps;
 
 
     public void Start() 
     {
         ps = transform.Find("Particle System").GetComponent<ParticleSystem>();
     }
 
     public void Update() 
     {
         if(ps)
         {
             if(!ps.IsAlive())
             {
                 Destroy(this.gameObject);
             }
         }
     }
}
