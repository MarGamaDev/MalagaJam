using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newDialogueObjecy", menuName = "dialogueObject", order = 0)]
public class DialogueObject : ScriptableObject
{
    public List<string> Sentences;
}
