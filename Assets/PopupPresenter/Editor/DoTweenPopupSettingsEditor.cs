using UnityEngine;
using System.Collections;
using UnityEditor;

namespace SquareDino.Popups
{
    [CustomPropertyDrawer(typeof(DoTweenPopupSettings))]
    public class DoTweenPopupSettingsDrawer : PropertyDrawer
    {
        private DoTweenPopupSettings _doTweenPopupSettings;
        private float ySpace;
        private bool showMoveSettings;
        private bool showRotateSettings;
    
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
    
            ySpace = 5f;
    
            EditorGUIUtility.labelWidth = 0.01f;
            Label(new Vector2(10, ySpace) + position.position, "Duration");
            EditorGUI.PropertyField(new Rect(new Vector2(15, ySpace += 15) + position.position, new Vector2(50, 20)),
                property.FindPropertyRelative("duration"));
    
            ySpace += 35;
            
            Label(new Vector2(10, ySpace) + position.position, "Move Settings" , true);
            ySpace += 15;
    
            Label(new Vector2(20, ySpace) + position.position, "MoveOffset");
            ySpace += 15;
    
            if (property.FindPropertyRelative("moveOffsetRandomOptions").enumValueIndex == 0)
            {
                EditorGUIUtility.labelWidth = 0.01f;
                EditorGUI.PropertyField(new Rect(new Vector2(25, ySpace) + position.position, new Vector2(300, 10)),
                    property.FindPropertyRelative("moveOffset"));
                EditorGUI.PropertyField(new Rect(new Vector2(325, ySpace) + position.position, new Vector2(20, 10)),
                    property.FindPropertyRelative("moveOffsetRandomOptions"));
            }
            else
            {
                EditorGUIUtility.labelWidth = 0.01f;
                EditorGUI.PropertyField(new Rect(new Vector2(325, ySpace) + position.position, new Vector2(20, 10)),
                    property.FindPropertyRelative("moveOffsetRandomOptions"));
                EditorGUI.PropertyField(new Rect(new Vector2(25, ySpace) + position.position, new Vector2(300, 10)),
                    property.FindPropertyRelative("minMoveOffset"));
                EditorGUI.PropertyField(new Rect(new Vector2(25, ySpace += 20) + position.position, new Vector2(300, 10)),
                    property.FindPropertyRelative("maxMoveOffset"));
            }
    
            Label(new Vector2(25, ySpace += 20) + position.position, "Move Duration");
            EditorGUI.PropertyField(new Rect(new Vector2(25, ySpace += 15) + position.position, new Vector2(150, 20)),
                property.FindPropertyRelative("moveDuration"));
    
            Label(new Vector2(175, ySpace - 15) + position.position, "Move Curve");
            EditorGUI.PropertyField(new Rect(new Vector2(175, ySpace) + position.position, new Vector2(150, 18)),
                property.FindPropertyRelative("moveCurve"));
    
            ySpace += 35;
            Label(new Vector2(10, ySpace) + position.position, "Rotate Settings" , true);
            ySpace += 15;
            Label(new Vector2(20, ySpace) + position.position, "RotateOffset");
            ySpace += 15;
            
            EditorGUIUtility.labelWidth = 0.01f;
            EditorGUI.PropertyField(new Rect(new Vector2(25, ySpace) + position.position, new Vector2(300, 20)),
                property.FindPropertyRelative("rotateOffset"));
    
            Label(new Vector2(25, ySpace += 20) + position.position, "Rotate Duration");
            EditorGUI.PropertyField(new Rect(new Vector2(25, ySpace += 15) + position.position, new Vector2(150, 20)),
                property.FindPropertyRelative("rotateDuration"));
    
            Label(new Vector2(175, ySpace - 15) + position.position, "Rotate Curve");
            EditorGUI.PropertyField(new Rect(new Vector2(175, ySpace) + position.position, new Vector2(150, 18)),
                property.FindPropertyRelative("rotateCurve"));
            
            ySpace += 35;
            Label(new Vector2(10, ySpace) + position.position, "Scale Settings" , true);
            ySpace += 15;
            Label(new Vector2(20, ySpace) + position.position, "Scale Factor");
            ySpace += 15;
    
            if (property.FindPropertyRelative("scaleOptions").enumValueIndex == 0)
            {
                EditorGUIUtility.labelWidth = 0.01f;
                EditorGUI.PropertyField(new Rect(new Vector2(25, ySpace) + position.position, new Vector2(300, 20)),
                    property.FindPropertyRelative("minScaleFactor"));
                EditorGUI.PropertyField(new Rect(new Vector2(325, ySpace) + position.position, new Vector2(20, 10)),
                    property.FindPropertyRelative("scaleOptions"));
            }
            else
            {
                EditorGUIUtility.labelWidth = 0.01f;
                EditorGUI.PropertyField(new Rect(new Vector2(325, ySpace) + position.position, new Vector2(20, 10)),
                    property.FindPropertyRelative("scaleOptions"));
                EditorGUI.PropertyField(new Rect(new Vector2(25, ySpace) + position.position, new Vector2(150, 20)),
                    property.FindPropertyRelative("minScaleFactor"));
                EditorGUI.PropertyField(new Rect(new Vector2(175, ySpace) + position.position, new Vector2(150, 20)),
                    property.FindPropertyRelative("maxScaleFactor"));
            }
            
            Label(new Vector2(25, ySpace += 20) + position.position, "Scale Duration");
            EditorGUI.PropertyField(new Rect(new Vector2(25, ySpace += 15) + position.position, new Vector2(150, 20)),
                property.FindPropertyRelative("scaleDuration"));
    
            Label(new Vector2(175, ySpace - 15) + position.position, "Scale Curve");
            EditorGUI.PropertyField(new Rect(new Vector2(175, ySpace) + position.position, new Vector2(150, 18)),
                property.FindPropertyRelative("scaleCurve"));
            
            ySpace += 35;
            Label(new Vector2(10, ySpace) + position.position, "Color Settings" , true);
            
            Label(new Vector2(25, ySpace += 15) + position.position, "Color Over Lifetime");
            EditorGUI.PropertyField(new Rect(new Vector2(25, ySpace += 15) + position.position, new Vector2(300, 20)),
                property.FindPropertyRelative("colorOverLifeTime"));
    
            EditorGUI.EndProperty();
        }
    
        private void Label(Vector2 position, string labelText, bool isBold = false)
        {
            EditorGUI.LabelField(new Rect(position, new Vector2(200, 15)), labelText, isBold ? EditorStyles.boldLabel : GUIStyle.none);
        }
        
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return ySpace * 1.1f;
        }
    }
}