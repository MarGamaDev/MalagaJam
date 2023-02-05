using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTrees : MonoBehaviour
{
    [SerializeField] private SpriteRenderer oldTree, newTree;

    public void DoTheThing()
    {
        StartCoroutine(FadeTreesInAndOut());
    }

    public IEnumerator FadeTreesInAndOut()
    {
        float opacity = 0;

        while (opacity < 1)
        {
            oldTree.color = new Color(1, 1, 1, 1 -opacity);
            newTree.color = new Color(1, 1, 1, opacity);
            opacity += Time.deltaTime / 2;
            yield return null;
        }

        GameManager.Instance.EndGame();
    }
}
