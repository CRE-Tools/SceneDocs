using UnityEditor;
using UnityEngine;

namespace PUCPR.SceneDocs.Editor
{
    [CustomEditor(typeof(NoteComponent_Discussion))]
    public class Editor_Discussion : ANoteComponentEditor
    {
        private NoteComponent_Discussion _component;
        private SerializedProperty _comments;

        private Vector2 chatScrollPos;
        private string newComment = "";

        private void OnEnable()
        {
            _component = (NoteComponent_Discussion)target;

            _comments = serializedObject.FindProperty(nameof(_component.comments));
        }

        protected override void DrawInspectorTool()
        {
            if (DrawChatWithScrollView())
            {
                DrawInputTextField();
            }

            serializedObject.ApplyModifiedProperties();
        }

        private bool DrawChatWithScrollView()
        {
            if (_component == null) return false;

            if (_comments == null || _comments.arraySize <= 0)
            {
                EditorGUILayout.LabelField("no comments", EditorStyles.centeredGreyMiniLabel);
                return true;
            }

            chatScrollPos = EditorGUILayout.BeginScrollView(chatScrollPos, EditorStyles.helpBox, GUILayout.MaxHeight(200));

            for (int i = 0; i < _comments.arraySize; i++)
                DrawCommentBubble(_comments.GetArrayElementAtIndex(i).stringValue);

            EditorGUILayout.EndScrollView();
            return true;
        }

        private void DrawCommentBubble(string r)
        {
            string[] p = r.Split('|');
            string u = p.Length > 0 ? p[0] : "?";
            string t = p.Length > 1 ? p[1] : "-";
            string m = p.Length > 2 ? p[2] : r;

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("", GUILayout.Width(20));
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(u, EditorStyles.boldLabel, GUILayout.Width(100));
            EditorGUILayout.LabelField(t, EditorStyles.miniLabel);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.SelectableLabel(m, EditorStyles.wordWrappedLabel, GUILayout.Height(18));
            EditorGUILayout.EndVertical();
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.Space(2);
        }

        private void DrawInputTextField()
        {
            EditorGUILayout.Space(5);
            EditorGUILayout.BeginHorizontal();
            newComment = EditorGUILayout.TextField(
                newComment,
                EditorStyles.textField,
                GUILayout.Height(24));


            using (new EditorGUI.DisabledScope(string.IsNullOrWhiteSpace(newComment)))
            {
                GUI.backgroundColor = new Color(.6f, .9f, .6f);
                if (GUILayout.Button("Send", GUILayout.Width(60), GUILayout.Height(24)))
                {
                    string formatedComment = FormatCommentWithSignature(newComment);
                    PostComment(formatedComment);

                    newComment = "";
                    GUI.FocusControl(null);

                    chatScrollPos.y = float.MaxValue;
                }
            }
            GUI.backgroundColor = Color.white;
            GUILayout.EndHorizontal();
        }

        private string FormatCommentWithSignature(string comment) => 
            $"{Signature()}|{ShortDateTime()}|{comment}";

        private void PostComment(string comment)
        {
            int newIndex = _comments.arraySize;
            _comments.InsertArrayElementAtIndex(newIndex);
            SerializedProperty NewElement = _comments.GetArrayElementAtIndex(newIndex);

            NewElement.stringValue = comment;
        }

        private string Signature() => 
            System.Environment.UserName;

        private string ShortDateTime() => 
            System.DateTime.Now.ToShortDateString();
    }
}