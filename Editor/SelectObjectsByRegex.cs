namespace SelectObjectsByRegex {
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEditor;
	using System.Text.RegularExpressions;
	using System.Linq;

	public class SelectObjectsByRegexWindow: EditorWindow {
		static GameObject activeObject;
		static string pattern = "";

		void OnSelectionChange() {
			var editorEvent = EditorGUIUtility.CommandEvent("ChangeActiveObject");
			editorEvent.type = EventType.Used;
			SendEvent(editorEvent);
		}

		// Use this for initialization
		[MenuItem("GameObject/Select Objects By Regex", false, 20)]
		public static void ShowWindow() {
			activeObject = Selection.activeGameObject;
			EditorWindow.GetWindow(typeof(SelectObjectsByRegexWindow));
		}

		static void SelectWalkdown(GameObject go, ref List<GameObject> selected, ref Regex regex, int depth=0) {
			// Components
			foreach (Component component in go.GetComponents<Component>()) {
				if (regex.Match(component.GetType().ToString()).Success) {
					selected.Add(go);
					break;
				}
			}

			// Children
			var children = go.GetComponentInChildren<Transform>();
			foreach (Transform child in children) {
				SelectWalkdown(child.gameObject, ref selected, ref regex, depth + 1);
			}
		}

		private void OnGUI() {
			activeObject = Selection.activeGameObject;
			EditorGUILayout.LabelField("アクティブなオブジェクト");
			using (new GUILayout.VerticalScope(GUI.skin.box)) {
				EditorGUILayout.LabelField(activeObject ? activeObject.name : "");
			}
			EditorGUILayout.LabelField("アクティブなオブジェクトのコンポーネント");
			using (new GUILayout.VerticalScope(GUI.skin.box)) {
				if (!activeObject) {
					EditorGUILayout.LabelField("");
				} else {
					EditorGUILayout.LabelField(
						string.Join(
							"\n",
							activeObject.GetComponents<Component>()
								.Select(component => component.GetType().ToString()).ToArray()
						),
						GUILayout.ExpandHeight(true)
					);
				}
			}

			pattern = EditorGUILayout.TextField("コンポーネント正規表現", pattern);

			if (GUILayout.Button("Select")) {
				var regex = new Regex(pattern);
				var list = new List<GameObject>();
				SelectWalkdown(activeObject, ref list, ref regex);
				Selection.objects = list.ToArray();
			}
		}
	}
}