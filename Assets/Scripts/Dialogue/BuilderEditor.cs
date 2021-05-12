using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
[CustomEditor(typeof(DialogueSettings))]
public class BuilderEditor : Editor {
    public override void OnInspectorGUI() {
        DrawDefaultInspector();

        DialogueSettings ds = (DialogueSettings)target;

        Languages l = new Languages();
        l.portuguese = ds.sentence;

        Sentences s = new Sentences();
        s.profile = ds.speakerSprite;
        s.sentence = l;

        if(GUILayout.Button("Create Dialogue")) {
            if(ds.sentence != null) {
                ds.dialogues.Add(s);
                ds.speakerSprite = null;
                ds.sentence = "";
            }
        }
    }
}
#endif