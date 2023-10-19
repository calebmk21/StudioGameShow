using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class QuizTracker : MonoBehaviour
{
    public struct Question
    {
        public string id;
        public string description;
        public string category;
        public string a1;
        public string a2;
        public string a3;
        public string a4;
        // public bool used;
    }

    [SerializeField] string filepath;
    public static Dictionary<string, Question> QuestionDict = new Dictionary<string, Question>();

    private static HashSet<string> available = new HashSet<string>();

    public static QuizTracker instance = null;

    void ReadStuff()
    {
        StreamReader reader = new StreamReader(filepath);

        bool eof = false;

        string[] titles = reader.ReadLine().Split('\t');


        while (!eof)
        {
            string data = reader.ReadLine();

            if (data == null)
            {
                eof = true;
                break;
            }

            string[] data_parsed = data.Split('\t');

            Question question = new Question();

            try
            {
                question.id = data_parsed[0];
                question.description = data_parsed[1];
                question.category = data_parsed[2];
                question.a1 = data_parsed[3];
                question.a2 = data_parsed[4];
                question.a3 = data_parsed[5];
                question.a4 = data_parsed[6];
                // question.used = false;

                QuestionDict.Add(question.id, question);
                available.Add(question.id);
            } catch
            {
                Debug.Log("Could not parse line!");
            }

        }

        Debug.Log($"Loaded tsv file with {available.Count} entries.");
    }

    public static Question GetRandomQuestion()
    {
        if (available.Count == 0)
        {
            Debug.LogWarning("No new questions remain!");
            Question dummy = new Question();
            dummy.id = "END";
            return dummy;
        }
        string rand_name = available.ToList()[Random.Range(0, available.Count - 1)];

        Question q = QuestionDict[rand_name];

        available.Remove(rand_name);

        Debug.Log($"Returning Question with id {rand_name}");
        return q;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        if (instance != null) Destroy(gameObject);
        else
        {
            instance = this;
            ReadStuff();
            DontDestroyOnLoad(gameObject);
            // Debug.Log(QuestionDict["dummy"].a4);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
