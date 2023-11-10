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

            MeshRenderer meshRenderer = posterLarge.GetComponent<MeshRenderer>();

            if (largePosterKind <= 4){

                Object[] posterList = Resources.LoadAll(folders[3], typeof(Texture2D));
                Texture2D randomTex = (Texture2D)posterList[Random.Range(0, posterList.Length)];

                Material material = new Material(Shader.Find("Standard"));
                material.SetFloat("_Mode", 1);
                material.SetFloat("_Cutoff", 0.5f);

                material.mainTexture = randomTex;
                meshRenderer.material = material;

            } else if (largePosterKind <= 8){

                Object[] posterList = Resources.LoadAll(folders[2], typeof(Texture2D));
                Texture2D randomTex = (Texture2D)posterList[Random.Range(0, posterList.Length)];

                Material material = new Material(Shader.Find("Standard"));
                material.SetFloat("_Mode", 1);
                material.SetFloat("_Cutoff", 0.5f);

            } else {

                Object[] posterList = Resources.LoadAll(folders[1], typeof(Texture2D));
                Texture2D randomTex = (Texture2D)posterList[Random.Range(0, posterList.Length)];

                Material material = new Material(Shader.Find("Standard"));
                material.SetFloat("_Mode", 1);
                material.SetFloat("_Cutoff", 0.5f);


            }
            Resources.UnloadUnusedAssets();

        }

        if (smallPosterProbability == 1){

            Object[] posterList = Resources.LoadAll(folders[0], typeof(Texture2D));
            Texture2D randomTex = (Texture2D)posterList[Random.Range(0, posterList.Length)];

            if (smallPosterSide == 0){

                MeshRenderer meshRenderer = posterSmall1.GetComponent<MeshRenderer>();

                Material material = new Material(Shader.Find("Standard"));
                material.SetInt("_Mode", 1);
                material.SetFloat("_Cutout", 0.5f);
                material.mainTexture = randomTex;
                meshRenderer.material = material;

            } else {

                MeshRenderer meshRenderer = posterSmall2.GetComponent<MeshRenderer>();

                Material material = new Material(Shader.Find("Standard"));
                material.SetInt("_Mode", 1);
                material.SetFloat("_Cutout", 0.5f);
                material.mainTexture = randomTex;
                meshRenderer.material = material;

            }

            Resources.UnloadUnusedAssets();
        }  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
