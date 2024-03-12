using System.Globalization;

class Engine
{
    public Engine()
    {
        gameObjects = new List<GameObject>();
    }

    ~Engine()
    {

    }

    public List<GameObject> gameObjects;
    public bool isRunning = true;
    public char[,] wallMap; 


    public void Init()
    {
        Input.Init();
        //Load();
    }

    public void LoadScene(string sceneName)
    {
        string dir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        string[] map = File.ReadAllLines(dir + "/data/"+ sceneName);
        //file로 읽어온다

        for (int y = 0; y < map.Length; ++y)
        {
            for (int x = 0; x < map[y].Length; ++x)
            {
                if (map[y][x] == '*')
                {
                    Instantiate(new Wall(x, y));
                }
                else if (map[y][x] == ' ')
                {
                    Instantiate(new Floor(x, y));
                }
                else if (map[y][x] == 'P')
                {
                    Instantiate(new Player(x, y));
                }
                else if (map[y][x] == 'M')
                {
                    Instantiate(new Monster(x, y));
                }
                else if (map[y][x] == 'G')
                {
                    Instantiate(new Goal(x, y));
                }
                //gameObjects.GetType() is Goal
            }
        }

        //Floor->Wall-Goal->Player->Monster
    }
    
    public void Run()
    {
        while (isRunning)
        {
            ProcessInput();
            Update();
            Render();
        }//frame
    }

    public void Term()
    {
        gameObjects.Clear();
    }

    public GameObject Instantiate(GameObject newGameObject)
    {
        gameObjects.Add(newGameObject);
        return newGameObject;
    }

    protected void ProcessInput()
    {
        Input.keyInfo =Console.ReadKey();
    }

    protected void Update() //모든 게임 오브젝트를 업데이트한다.
    {
        foreach (GameObject gameObject in gameObjects)
        {
            gameObject.Update();
         

            //gameObject.SetMap(map);
        }
    }

    protected void Render() //모든 게임 오브젝트를 출력한다.
    {
/*        for(int i = 0; i < gameObjects.Count; i++)
        {
            gameObjects[i].Render();
        }*/
        Console.Clear();
        foreach(GameObject gameObject in gameObjects)
        {
            gameObject.Render();
        }
    }
}

