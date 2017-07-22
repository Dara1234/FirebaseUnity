using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class FirebaseUnity : MonoBehaviour {


	Text instruction;
	// Use this for initialization
	void Start () {

		instruction = GetComponent<Text>();
		// Set up the Editor before calling into the realtime database.
		FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://fir-unity-9a087.firebaseio.com/");
		FirebaseApp.Create();
		// Get the root reference location of the database.
		DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
		reference.Child ("users").SetValueAsync ("dara");

		FirebaseDatabase.DefaultInstance
			.GetReference("users")
			.GetValueAsync().ContinueWith(task => {
				if (task.IsFaulted) {
					print("error");
				}
				else if (task.IsCompleted) {
					DataSnapshot snapshot = task.Result;
					print("working");
					print("Value: "+snapshot.Value);
					instruction.text = ""+ snapshot.Value;
				}
			});
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
