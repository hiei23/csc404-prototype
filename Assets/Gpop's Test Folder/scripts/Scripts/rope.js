#pragma strict

function Start () {
	GetComponent.<CharacterJoint>().connectedBody=transform.parent.GetComponent.<Rigidbody>();
}