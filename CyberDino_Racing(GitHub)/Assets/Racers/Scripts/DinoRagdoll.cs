using UnityEngine;
using System.Collections;

public class DinoRagdoll : MonoBehaviour {

	public GameObject ragdoll;
	public GameObject newRagdoll;

	public void GoRagdoll() {
		if(true) {

			// Modified by Sam
			rigidbody.constraints = RigidbodyConstraints.FreezeAll;
			transform.collider.enabled = false;
			SkinnedMeshRenderer theMesh = transform.gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
			theMesh.enabled = false;

			// Instantiate ragdoll
			newRagdoll = Instantiate(ragdoll, transform.position, transform.rotation) as GameObject;
			
			// Copy bone transforms to ragdoll
			CopyTransforms(transform, newRagdoll.transform);

			// DO NOT destroy the dinosaur game object!
			//Destroy(this.gameObject);
		}
	}

	// Added by Sam
	public void ResetRacer()
	{
		rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
		transform.collider.enabled = true;
		SkinnedMeshRenderer theMesh = transform.gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
		theMesh.enabled = true;
		ColorLerpClass theLerp = transform.gameObject.GetComponent<ColorLerpClass>();
		theLerp.lerping = false;
		Destroy(newRagdoll);
	}

	void CopyTransforms(Transform src, Transform dst) {
		dst.position = src.position;
		dst.rotation = src.rotation;
		dst.gameObject.SetActive(src.gameObject.activeSelf);
		
		foreach(Transform child in dst) {
			
			// match the transform with the same name
			var curSrc = src.Find(child.name);
			
			if (curSrc != null) 
				CopyTransforms(curSrc, child);
		}
	}

}
