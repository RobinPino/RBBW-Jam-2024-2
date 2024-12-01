using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "Sound", menuName = "Effects/Sound", order = 1)]
public class SoundTypeSO : ScriptableObject
{
    [SerializeField] public Sound[] soundVariations;
    public bool loop = false;
    public float delay;
    public Sound GetSound()
    {
        if (soundVariations.Length == 0)
        {
            return null;
        }

        return soundVariations[UnityEngine.Random.Range(0, soundVariations.Length)];
    }
}

#if UNITY_EDITOR
public class SoundSOCreationHelper : MonoBehaviour
{
    [MenuItem("Assets/Create/SoundSO from selection", priority =10)]
    static void CreateSoundFromSelection()
    {
        UnityEngine.Object[] selections = Selection.GetFiltered(typeof(AudioClip), SelectionMode.Assets);
        foreach (AudioClip clip in selections)
        {
            SoundTypeSO so = ScriptableObject.CreateInstance<SoundTypeSO>();
            so.soundVariations = new Sound[1];
            so.soundVariations[0] = new Sound { clip = clip };
            so.soundVariations[0].volume = 1;

            string path = AssetDatabase.GetAssetPath(clip);
            if (path.Contains('.')) // If the path is a file
            {
                path = path.Remove(path.LastIndexOf('/'));
            }

            AssetDatabase.CreateAsset(so, path + "/" + clip.name + ".asset");
            AssetDatabase.SaveAssets();
        }
    }

    [MenuItem("Assets/CreateSoundSO", true)]
    static bool ValidateCreateFromSound()
    {
        return Selection.activeObject is AudioClip;
    }
}

#endif

[Serializable]
public class Sound
{
    public AudioClip clip;
    [Range(0, 1)] public float volume = 1;
}