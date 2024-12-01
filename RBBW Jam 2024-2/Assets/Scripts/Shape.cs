using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shapes", menuName = "ScriptableObjects/ShapeScriptableObject", order = 1)]
public class Shape : ScriptableObject
{
    public float speed;
	public enum Type	{Square,Triangle,Hexagon};
    public Type type;
    public Sprite sprite;
    public int health;
}
