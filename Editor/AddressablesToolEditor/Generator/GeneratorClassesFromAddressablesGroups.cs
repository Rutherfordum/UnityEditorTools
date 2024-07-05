using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEngine;

/// <summary>
/// Developed by Rutherfordum
/// Telegram: https://t.me/Rutherfordum
/// TgChanel: https://t.me/Pro_XR
/// GitHub: https://github.com/Rutherfordum
/// </summary>
namespace AddressableToolEditor
{
#if UNITY_EDITOR
    public class GeneratorClassesFromAddressablesGroups
    {
        private const string ScriptPath =  "/AddressableAssetsData/AddressablesGroupsData.cs";

        [MenuItem("Tools/Addressables/Generate Classes From Addressables Group")]
        public static void GenerateClassesFromAddressablesGroups()
        {
            var pathScripts = Application.dataPath + ScriptPath;
            var addressableGroups = AddressableAssetSettingsDefaultObject.Settings.groups;
            List<string> codeText = new List<string>();

            codeText.Add($"public static class AddressablesGroupsData");
            codeText.Add("{");

            foreach (var addressableGroup in addressableGroups)
            {
                var className = TrimNonLetterChars(addressableGroup.Name);

                Debug.Log(className);

                codeText.Add($"    public static class {className}");
                codeText.Add("    {");

                foreach (var addressableGroupEntry in addressableGroup.entries)
                {
                    var propertyName = TrimNonLetterChars(addressableGroupEntry.address);
                    codeText.Add($"        public const string {propertyName}Key = \"{addressableGroupEntry.address}\";");
                }

                codeText.Add("    }");
            }

            codeText.Add("}");

            File.WriteAllLines(pathScripts, codeText);
            AssetDatabase.Refresh();
            Selection.activeObject = AssetDatabase.LoadMainAssetAtPath("Assets" + ScriptPath);
        }

        static string TrimNonLetterChars(string value)
        {
            return new string((from c in value
                               where !char.IsPunctuation(c) && !char.IsWhiteSpace(c) && c != '/'
                               select c
                ).ToArray());
        }
    }
#endif
}