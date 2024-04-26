using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

/// <summary>
/// Developed by Rutherfordum
/// Telegram: https://t.me/Rutherfordum
/// TgChanel: https://t.me/Pro_XR
/// GitHub: https://github.com/Rutherfordum
/// </summary>
namespace AnimatorToolEditor
{
    public class GeneratorClassFromAnimatorControllerEditor
    {
        private static readonly string PATH_TEMPLATE = $"{Application.dataPath}/Editor/AnimatorToolEditor/Template/GeneratedAnimatorClassTemplate";

        [MenuItem("Assets/Generate Class From AnimatorController", false)]
        public static void Generate()
        {
            var animatorController = Selection.activeObject as AnimatorController;
            var selectedFilePath = AssetDatabase.GetAssetPath(Selection.activeObject);
            var generatedFilePath = selectedFilePath.Substring(0, selectedFilePath.LastIndexOf("/")) + "/" + animatorController.name + ".cs";
            var templateFilePath = PATH_TEMPLATE;

            var templateText = File.ReadAllLines(templateFilePath).ToList();

            templateText[2] = templateText[2].Replace("#SCRIPTNAME#", animatorController.name.Replace(" ", ""));
            templateText[6] = templateText[6].Replace("#SCRIPTNAME#", animatorController.name.Replace(" ", ""));

            List<string> codeText = new List<string>();
            AnimatorControllerParameter[] parameters = animatorController.parameters;

            foreach (var parameter in parameters)
            {
                switch (parameter.type)
                {
                    case AnimatorControllerParameterType.Float:
                        codeText.Add($"    public void Set{parameter.name.Replace(" ", "")}(float value) => _animator.SetFloat(\"{parameter.name}\", value);");
                        break;
                    case AnimatorControllerParameterType.Int:
                        codeText.Add($"    public void Set{parameter.name.Replace(" ", "")}(int value) => _animator.SetInteger(\"{parameter.name}\", value);");
                        break;
                    case AnimatorControllerParameterType.Bool:
                        codeText.Add($"    public void Set{parameter.name.Replace(" ", "")}(bool value) => _animator.SetBool(\"{parameter.name}\", value);");
                        break;
                    case AnimatorControllerParameterType.Trigger:
                        codeText.Add($"    public void Set{ parameter.name.Replace(" ", "")}() => _animator.SetTrigger(\"{parameter.name}\");");
                        break;
                }
            }

            templateText.InsertRange(11, codeText);

            File.WriteAllLines(generatedFilePath, templateText);

            AssetDatabase.Refresh();
        }

        [MenuItem("Assets/Generate Class From AnimatorController", true)]
        public static bool CheckValidationAnimatorController()
        {
            return Selection.activeObject is AnimatorController;
        }
    }
}