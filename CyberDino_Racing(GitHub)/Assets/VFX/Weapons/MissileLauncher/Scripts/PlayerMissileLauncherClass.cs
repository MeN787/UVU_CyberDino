﻿// Name: Samantha Spray
// Project: Cyber-Dino Racing
// Date: 2/6/14

using UnityEngine;
using System.Collections;

public class PlayerMissileLauncherClass : MissileLauncherClass {
	
	void Start(){
		
		RWStart();
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Z)){
			
			FireFunc();
			
		}
	}
}
