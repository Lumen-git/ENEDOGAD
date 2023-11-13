using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosterSpawningScript : MonoBehaviour
{

    private string[] folders = {
        "PostersSmall",
        "PostersLarge/Adversary",
        "PostersLarge/Companion/Common",
        "PostersLarge/NoiseEntropyChaos"
    };

    [SerializeField] GameObject posterLarge;
    [SerializeField] GameObject posterSmall1;
    [SerializeField] GameObject posterSmall2;

    void Awake()
    {
        int largePosterProbability = Random.Range(1,5);
        int largePosterKind = Random.Range(1,10);
        int smallPosterProbability = Random.Range(1,11);
        int smallPosterSide = Random.Range(0,2);

        if (largePosterProbability == 1){

            SpriteRenderer posterTarget = posterLarge.GetComponent<SpriteRenderer>();
            Object[] posterList;

            if (largePosterKind <= 4){
                posterList = Resources.LoadAll(folders[3], typeof(Texture2D));
            } else if (largePosterKind <= 8){
                posterList = Resources.LoadAll(folders[2], typeof(Texture2D));
            } else {
                posterList = Resources.LoadAll(folders[1], typeof(Texture2D));
            }

            Texture2D randomTex = (Texture2D)posterList[Random.Range(0, posterList.Length)];

            posterTarget.sprite= Sprite.Create(randomTex, new Rect(0.0f, 0.0f, randomTex.width, randomTex.height), new Vector2(0.5f, 0.5f));

            Resources.UnloadUnusedAssets();
        }

        if (smallPosterProbability == 1){

            Object[] posterList = Resources.LoadAll(folders[0], typeof(Texture2D));
            Texture2D randomTex = (Texture2D)posterList[Random.Range(0, posterList.Length)];
            SpriteRenderer posterTarget;

            if (smallPosterSide == 0){

                posterTarget = posterSmall1.GetComponent<SpriteRenderer>();

            } else {

                posterTarget = posterSmall2.GetComponent<SpriteRenderer>();

            }

            posterTarget.sprite= Sprite.Create(randomTex, new Rect(0.0f, 0.0f, randomTex.width, randomTex.height), new Vector2(0.5f, 0.5f));

            Resources.UnloadUnusedAssets();
        }  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
