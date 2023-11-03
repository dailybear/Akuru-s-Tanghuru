using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

namespace Modules.Util
{
    public class UITextFontSetter
    {
        // ��Ʈ ��� ����
        public const string PATH_FONT_TEXTMESHPRO_MALGUNBD = "Assets/TextMesh Pro/Fonts/MALGUNBD SDF.asset";

        [MenuItem("CustomMenu/ChangeTextMeshPro(���� Scene �� TextMeshProUGUI ��Ʈ�� MALGUNBD ��Ʈ�� ��ü��)")]
        public static void ChangeFontInTexMeshPro()
        {
            GameObject[] rootObj = GetSceneRootObjects();

            for (int i = 0; i < rootObj.Length; i++)
            {
                GameObject gbj = (GameObject)rootObj[i] as GameObject;
                Component[] com = gbj.transform.GetComponentsInChildren(typeof(TextMeshProUGUI), true);
                foreach (TextMeshProUGUI txt in com)
                {
                    txt.font = AssetDatabase.LoadAssetAtPath<TMP_FontAsset>(PATH_FONT_TEXTMESHPRO_MALGUNBD);
                }
            }
        }

        /// <summary>
        /// ��� �ֻ��� Root�� GameObject�� �޾ƿ�
        /// </summary>
        /// <returns></returns>
        private static GameObject[] GetSceneRootObjects()
        {
            Scene currentScene = SceneManager.GetActiveScene();

            return currentScene.GetRootGameObjects();
        }
    }
}
