using System.Collections;
using TMPro;
using UnityEngine;

//Script for ingredients mixing

public class MagicalBoilerRecipes : MonoBehaviour
{
    [Header("Recipe 1 (Ingredients & Result)")]
    public GameObject ingredientA;
    public GameObject ingredientB;
    public GameObject resultPrefab1;

    [Header("Recipe 2 (Ingredients & Result)")]
    public GameObject ingredientC;
    public GameObject ingredientD;
    public GameObject resultPrefab2;

    [Header("Recipe 3 (Ingredients & Result)")]
    public GameObject ingredientE;
    public GameObject ingredientF;
    public GameObject resultPrefab3;

    [Header("Spawn Settings")]
    public Transform spawnPoint; // Where to spawn the result

    public GameObject message;

    [Header("Sound Effects")]
    public AudioSource ingredientAddedSound;
    public AudioSource recipeCompletedSound;
    public AudioSource recipeFailedSound;

   
    // Internal state to track which recipe (if any) is in progress
    private enum RecipeType { None, Recipe1, Recipe2, Recipe3 }
    private RecipeType currentRecipe = RecipeType.None;
    // Records the type (as a string "A", "B", "C", "D"...) of the first ingredient that was added

    private string firstIngredient = "";
    private bool isBusy = false;



    private void OnTriggerEnter(Collider other)
    {
        if (isBusy) return;

        message.SetActive(false);
        // Determine if the colliding object is one of our valid ingredients.
        string ingType = GetIngredientType(other.gameObject);
        ingredientAddedSound.Play();


        // If no recipe has been started yet
        if (currentRecipe == RecipeType.None)
        {
            Debug.Log("NEW RECIPE - 1st object entered, object type: " + ingType);

            // If the object is either A or B, we start Recipe1.
            if (ingType == "A" || ingType == "B")
            {
                currentRecipe = RecipeType.Recipe1;
                firstIngredient = ingType;
            }
            // If it’s C or D, start Recipe2.
            else if (ingType == "C" || ingType == "D")
            {
                currentRecipe = RecipeType.Recipe2;
                firstIngredient = ingType;
            }
            else if (ingType == "E" || ingType == "F")
            {
                currentRecipe = RecipeType.Recipe3;
                firstIngredient = ingType;
            }
            else
            {
                Debug.Log("wrong object entered");
                return;
            }
        }
        else // A recipe is already in progress.
        {
            Debug.Log("ONGOING RECIPE- 2nd object entered, object type: " + ingType + " current recipe: " + currentRecipe);
            if (ingType == null)
            {
                TextMeshPro tmp = message.GetComponent<TextMeshPro>();
                tmp.text = "Incorrect ingredients sequence, restart!";
                message.SetActive(true);
                StartCoroutine(ResetRecipe());
                return;
            }

            // Check if the new ingredient belongs to the active recipe.
            if (currentRecipe == RecipeType.Recipe1)
            {
                if (ingType == "A" || ingType == "B")
                {
                    // Only the complement (A+B or B+A) completes Recipe1.
                    if ((firstIngredient == "A" && ingType == "B") ||
                        (firstIngredient == "B" && ingType == "A"))
                    {

                        //SpawnResult(resultPrefab1);
                        TextMeshPro tmp = message.GetComponent<TextMeshPro>();
                        tmp.text = "Recipe completed!";
                        message.SetActive(true);

                        StartCoroutine(CompletedRecipe(1));

                    }
                    else
                    {
                        TextMeshPro tmp = message.GetComponent<TextMeshPro>();
                        tmp.text = "Incorrect ingredients sequence, restart!";
                        message.SetActive(true);

                        StartCoroutine(ResetRecipe());
                    }
                }
                else // Ingredient from Recipe2 was added during Recipe1.
                {
                    TextMeshPro tmp = message.GetComponent<TextMeshPro>();
                    tmp.text = "Incorrect ingredients sequence, restart!";
                    message.SetActive(true);
                    StartCoroutine(ResetRecipe());
                }
            }
            else if (currentRecipe == RecipeType.Recipe2)
            {
                if (ingType == "C" || ingType == "D")
                {
                    if ((firstIngredient == "C" && ingType == "D") ||
                        (firstIngredient == "D" && ingType == "C"))
                    {
                        TextMeshPro tmp = message.GetComponent<TextMeshPro>();
                        tmp.text = "Recipe completed!";
                        message.SetActive(true);

                        StartCoroutine(CompletedRecipe(2));
                    }
                    else
                    {
                        TextMeshPro tmp = message.GetComponent<TextMeshPro>();
                        tmp.text = "Incorrect ingredients sequence, restart!";
                        message.SetActive(true);
                        StartCoroutine(ResetRecipe());
                    }
                }
                else
                {
                    TextMeshPro tmp = message.GetComponent<TextMeshPro>();
                    tmp.text = "Incorrect ingredients sequence, restart!";
                    message.SetActive(true);
                    StartCoroutine(ResetRecipe());
                }
            }
            if (currentRecipe == RecipeType.Recipe3)
            {
                if (ingType == "E" || ingType == "F")
                {
                    
                    if ((firstIngredient == "E" && ingType == "F") ||
                        (firstIngredient == "F" && ingType == "E"))
                    {

                       
                        TextMeshPro tmp = message.GetComponent<TextMeshPro>();
                        tmp.text = "Recipe completed!";
                        message.SetActive(true);

                        StartCoroutine(CompletedRecipe(3));

                    }
                    else
                    {
                        TextMeshPro tmp = message.GetComponent<TextMeshPro>();
                        tmp.text = "Incorrect ingredients sequence, restart!";
                        message.SetActive(true);

                        StartCoroutine(ResetRecipe());
                    }
                }
                else // Ingredient from another recipe was added
                {
                    TextMeshPro tmp = message.GetComponent<TextMeshPro>();
                    tmp.text = "Incorrect ingredients sequence, restart!";
                    message.SetActive(true);
                    StartCoroutine(ResetRecipe());
                }
            }
        }
    }

    // Returns a string representing the ingredient type ("A", "B", "C", "D", "E" or "F")
    // if the object matches one of the assigned ingredients; otherwise returns null.
    private string GetIngredientType(GameObject obj)
    {
        if (obj == ingredientA)
            return "A";
        if (obj == ingredientB)
            return "B";
        if (obj == ingredientC)
            return "C";
        if (obj == ingredientD)
            return "D";
        if (obj == ingredientE)
            return "E";
        if (obj == ingredientF)
            return "F";
        return null;
    }

    // Spawns the result prefab at the given spawn point.
    private void SpawnResult(GameObject prefab)
    {
        Debug.Log("SpawnResult " + prefab);
        if (prefab != null)
        {
            if (spawnPoint != null)
            {
                Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
            }
            else
            {
                Instantiate(prefab, transform.position, Quaternion.identity);
            }
        }
    }

    private IEnumerator CompletedRecipe(int recipe)
    {
        isBusy = true;
        currentRecipe = RecipeType.None;
        firstIngredient = "";
        
        yield return new WaitForSeconds(2f);

        if (recipe == 1)
        {
            SpawnResult(resultPrefab1);
        }
        else if (recipe == 2)
        {
            SpawnResult(resultPrefab2);
        }
        else if (recipe == 3)
        {
            SpawnResult(resultPrefab3);
        }

        recipeCompletedSound.Play();
        Debug.Log("Reset recipe and completed. current recipe: " + currentRecipe + " first ingredient: " + firstIngredient);
        isBusy = false;
    }


    private IEnumerator ResetRecipe()
    {
        isBusy = true;
        currentRecipe = RecipeType.None;
        firstIngredient = "";
        yield return new WaitForSeconds(2f);

        recipeFailedSound.Play();
        Debug.Log("Reset failed - reset.  current recipe: "+currentRecipe+" first ingredient: "+firstIngredient);
        isBusy=false;


    }
}
