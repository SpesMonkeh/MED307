// Copyright © Christian Holm Christensen
// 10/12/2023

using UnityEngine;

namespace P307.Runtime.Gameplay.Player
{
	[SelectionBase]
	public sealed class PlayerHead : MonoBehaviour
	{
		[Header("Required Objects")]
		[SerializeField] GameObject yRotation;
		[SerializeField] GameObject xRotation;

		[Space(5), Header("Settings")]
		[SerializeField, Min(0)] float xRotationSpeed = 15;
		[SerializeField, Min(0)] float yRotationSpeed = 15;
		[Space(2)]
		[SerializeField, Range(-360, 360)] float xMinRotation = -75f;
		[SerializeField, Range(-360, 360)] float xMaxRotation = 55f;
		[SerializeField, Range(-360, 360)] float yMinRotation = -90f;
		[SerializeField, Range(-360, 360)] float yMaxRotation = 90f;
		
		public void Rotate(Vector2 rotation)
		{
			if (rotation == Vector2.zero)
				return;
			RotateHorizontally(rotation.y);
			RotateVertically(rotation.x);
		}

		void RotateHorizontally(float value)
		{
			if (value is 0)
				return;
			//this.xRotation.transform.Rotate(Vector3.up, value);
			Quaternion rot = this.xRotation.transform.rotation;
			Vector3 eulerRot = rot.eulerAngles;
			
			Vector3 newRot = new Vector3(eulerRot.x + value, eulerRot.y, eulerRot.z);
			newRot.x = Mathf.Clamp(eulerRot.x, this.xMinRotation, this.xMaxRotation);
			
			rot.SetLookRotation(newRot);
		}
 
		void RotateVertically(float value)
		{
			if (value is 0)
				return;
			Quaternion rot = this.yRotation.transform.rotation;
			Vector3 eulerRot = rot.eulerAngles;
			
			Vector3 newRot = new Vector3(eulerRot.x, eulerRot.y + value, eulerRot.z);
			newRot.y = Mathf.Clamp(eulerRot.y, this.yMinRotation, this.yMaxRotation);
			
			rot.SetLookRotation(newRot);
		}
	}
}