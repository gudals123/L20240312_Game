class Player : GameObject
{
    private int wallX;
    private int wallY;

    public Player()
    {
        shape = 'P';
    }

    public Player(int newX, int newY)
    {
        shape = 'P';
        x = newX;
        y = newY;
    }

    ~Player()
    {

    }

    private int newPlayerX = 0;
    private int newPlayerY = 0;

    public void SetWallPosition(int newX, int newY)
    {
        wallX = newX;
        wallY = newY;
    }

    public override void Start()
    {

    }

    public override void Update()
    {
        newPlayerX = x;
        newPlayerY = y;
        if (Input.GetButton("Up"))
        {
            newPlayerY--;
        }
        else if (Input.GetButton("Down"))
        {
            newPlayerY++;
        }
        else if (Input.GetButton("Left"))
        {
            newPlayerX--;
        }
        else if (Input.GetButton("Right"))
        {
            newPlayerX++;
        }
        else if (Input.GetButton("Quit"))
        {

        }
/*        if (map[y][x] == '*')
        {
            newPlayerX = x;
            newPlayerY = y;

        }*/
        x = Math.Clamp(newPlayerX, 0, 9);
        y = Math.Clamp(newPlayerY, 0, 9);

    }


}

