using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomizer : MonoBehaviour
{
    [System.Serializable]
    public class Data
    {
        public string name;
        public bool isHere = true;
    }

    [SerializeField] private Data[] _datas;

    // Start is called before the first frame update
    void Start()
    {
        // Put all of the names into a single list
        List<Data> namePool = new List<Data>();
        namePool.AddRange(_datas);

        // This is the final, randomized list of names
        List<Data> randomizedNames = new List<Data>();

        // Keep looping while there are still names in the list
        while (namePool.Count > 0)
        {
            // Pick a random index
            int randomIndex = Random.Range(0, namePool.Count);

            // Add it to the final list
            randomizedNames.Add(namePool[randomIndex]);

            // Remove from our list of names
            namePool.RemoveAt(randomIndex);
        }

        string listOfNames = "";
        foreach (Data data in randomizedNames)
        {
            listOfNames += data.name;
            listOfNames += " ";
        }
        Debug.Log(listOfNames);

        //for (int i = datas.Count - 1; i >= 0; i--)
        //{
        //    if (!datas[i].isHere)
        //    {
        //        datas.RemoveAt(i);
        //    }
        //}

        //string output = string.Empty;
        //for (int i = 0; i < datas.Count; i++)
        //{
        //    output += "\n#" + (i + 1);
        //    output += "\nPresenter: " + datas[i].name;

        //    int nextIndex = (i + 1) % datas.Count;
        //    output += "\nPlaytester: " + datas[nextIndex].name;
        //    output += "\n";
        //}

        //Debug.Log(output);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
