using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : HeroUnitBase {
    //[SerializeField] private AudioClip _someSound;
    
    void Start() {
        // Example usage of a static system
        //AudioSystem.Instance.PlaySound(_someSound);
    }
    
    public override void ExecuteMove() {

        base.ExecuteMove(); // Call this to clean up the move
    }
    

}
