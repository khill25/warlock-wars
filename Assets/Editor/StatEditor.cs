using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using Warlock;

[CustomEditor(typeof(Stat))]
public class StatEditor : Editor {

	public override void OnInspectorGUI(){
		serializedObject.Update();

		SerializedProperty name = serializedObject.FindProperty("Name");
		SerializedProperty value = serializedObject.FindProperty("Value");
		SerializedProperty statType = serializedObject.FindProperty("StatType");

		EditorGUILayout.PropertyField(name);
		EditorGUILayout.PropertyField(value);
		EditorGUILayout.PropertyField(statType);

		serializedObject.ApplyModifiedProperties();

	}


}

[CustomEditor(typeof(Card))]
[CanEditMultipleObjects]
public class CardEditor : Editor {

	public override void OnInspectorGUI(){
		//base.OnInspectorGUI();
		DrawDefaultInspector();
	}

}
//
//	Card t;
//	SerializedObject GetTarget;
//	SerializedProperty ThisList;
//	int ListSize;
//	
//	void OnEnable(){
//		t = (Card)target;
//		GetTarget = new SerializedObject(t);
//		ThisList = GetTarget.FindProperty("Stats"); // Find the List in our script and create a refrence of it
//	}
//	
//	public override void OnInspectorGUI(){
//		//Update our list
//		
//		GetTarget.Update();
//		
//
//		EditorGUILayout.LabelField("Stat Count");
//		ListSize = ThisList.arraySize;
//		ListSize = EditorGUILayout.IntField ("Count", ListSize);
//		
//		if(ListSize != ThisList.arraySize){
//			while(ListSize > ThisList.arraySize){
//				ThisList.InsertArrayElementAtIndex(ThisList.arraySize);
//			}
//			while(ListSize < ThisList.arraySize){
//				ThisList.DeleteArrayElementAtIndex(ThisList.arraySize - 1);
//			}
//		}
//		
//		if(GUILayout.Button("New Stat")){
//			t.Stats.Add(new Warlock.Stat());
//		}
//		//Display our list to the inspector window
//		for(int i = 0; i < ThisList.arraySize; i++){
//			SerializedProperty MyListRef = ThisList.GetArrayElementAtIndex(i);
//			SerializedProperty name = MyListRef.FindPropertyRelative("Name");
//			SerializedProperty value = MyListRef.FindPropertyRelative("Value");
//			SerializedProperty statType = MyListRef.FindPropertyRelative("StatType");
//
//			EditorGUILayout.PropertyField(name);
//			EditorGUILayout.PropertyField(value);
//			EditorGUILayout.PropertyField(statType);
//		}
//	
//		//Apply the changes to our list
//		GetTarget.ApplyModifiedProperties();
//	}
//}