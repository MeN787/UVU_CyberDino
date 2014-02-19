using UnityEngine;
using System.Collections;

public class UserControl : MonoBehaviour {

	private DinoMoveScript move;

	// Added by Sam
	private WeaponControlClass weapons;
	private VFXControlClass vfx;
	private RacerHealthClass racerHealth;
	private DustEffectClass dust;

	// Use this for initialization
	void Start () {
		move = this.gameObject.GetComponent<DinoMoveScript>();

		// Added by Sam
		weapons = GetComponentInChildren<WeaponControlClass>();
		vfx = GetComponentInChildren<VFXControlClass>();
		racerHealth = GetComponentInChildren<RacerHealthClass>();
		racerHealth.TheRagdoll = this.GetComponent<DinoRagdoll>();
		dust = GetComponentInChildren<DustEffectClass>();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		move.h = Input.GetAxis("Horizontal");				
		move.v = Input.GetAxis("Vertical");
		if(Input.GetButton("Jump"))
		{
			move.jumper = true;
		}
		else
		{
			move.jumper = false;
		}

//		if(Input.GetKeyDown(KeyCode.F))
//		{
//			this.GetComponent<DinoRagdoll>().GoRagdoll();
//		}


		// Added by Sam
		dust.RunDust(move.v);

		if(Input.GetKeyUp(KeyCode.F))
		{
			if(!racerHealth.IsRagdoll)
			{
				this.GetComponent<DinoRagdoll>().GoRagdoll();
				racerHealth.IsRagdoll = true;
			}
			else
			{
				this.GetComponent<DinoRagdoll>().ResetRacer();
				racerHealth.IsRagdoll = false;
			}
		}
		
		if(Input.GetKeyUp(KeyCode.T))
		{
			vfx.UseTurbo();
		}
		if(Input.GetKeyUp(KeyCode.Alpha1))
		{
			weapons.Switch();
		}
		if(Input.GetKeyUp(KeyCode.R))
		{
			racerHealth.UseRespawn(gameObject);
		}
		if(Input.GetKey(KeyCode.Q))
		{
			switch(weapons.CurrentWeapon.name.ToString())
			{
			case "Laser_VFX":
				weapons.Laser.FireLaser();
				break;
			case "MachineGun_Gun":
				weapons.OldMachineGun.FireFunc();
				break;
			case "PlayerMissileLauncher":
				weapons.MissileLauncher.FireFunc();
				break;
			default:
				break;
			}
		}
		else
		{
			weapons.Laser.Line.enabled = false;
		}

	}

	void OnTriggerEnter(Collider other){
		
		string theTag = other.gameObject.tag.ToString();
		
		switch(theTag)
		{
		case "Weapon":
//			Debug.Log (this + " has been hit with a weapon!");
			break;
//		case "DirectionCheck":
//			if(!InTurnArea)
//			{
//				InTurnArea = true;
//			}
//			else
//			{
//				InTurnArea = false;
//			}
//			break;
		default:
			break;
		}
		
	}

}
