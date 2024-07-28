
using MineField;
using Newtonsoft.Json;

var positions = new Stack<Position>();

void CreatePath(List<List<bool>> map)
{
    for (int i = 0; i < map[0].Count; i++)
    {
        var pathCreated = GetPath(map, xPosition: i, yPosition: 0);
        if (pathCreated)
            break;
        else
            positions.Clear();
    }
}

bool GetPath(List<List<bool>> map, List<List<bool>>? visitedMap = null, int xPosition = 0, int yPosition = 0, Direction? notMoveable = null, List<List<MoveableDirections?>>? moveableDirections = null)
{  
    positions.Push(new Position { X = xPosition, Y = yPosition });   
    if (moveableDirections == null)
    {
        moveableDirections = new();

        for (var i = 0; i < map.Count; i++)
        {
            moveableDirections.Add(new());
            foreach (var val in map[i])
            {
                moveableDirections[i].Add(null);
            }
        }
    }
    if (visitedMap == null)
    {
        visitedMap = new();

        for (var i = 0; i < map.Count; i++)
        {
            visitedMap.Add(new());
            foreach (var val in map[i])
            {
                visitedMap[i].Add(false);
            }
        }
    } 

    if (yPosition >= map.Count || yPosition < 0 || xPosition >= map[0].Count || xPosition < 0 || !map[yPosition][xPosition] || visitedMap[yPosition][xPosition])
        return false;

    if (yPosition == map.Count - 1) return true;

    if (moveableDirections[yPosition][xPosition] == null)
    {
        visitedMap[yPosition][xPosition] = true; 
        bool down = false, up = false, left = false, right = false, upperLeft = false, upperRight = false, lowerLeft = false, lowerRight = false;
        if (notMoveable != Direction.DOWN)
        { 
             down = GetPath(map, visitedMap, xPosition, yPosition + 1, Direction.UP, moveableDirections);
            if (down) return true;
            else positions.Pop();
        }
        if (notMoveable != Direction.UP && yPosition != 0)
        {
             up = GetPath(map, visitedMap, xPosition, yPosition - 1, Direction.DOWN, moveableDirections);
            if (up) return true;
            else positions.Pop();
        }
        if (notMoveable != Direction.LEFT && xPosition != 0)
        {
             left = GetPath(map, visitedMap, xPosition - 1, yPosition, Direction.RIGHT, moveableDirections);
            if (left) return true;
            else positions.Pop();
        }
        if (notMoveable != Direction.RIGHT && xPosition < map[0].Count - 1)
        {
             right = GetPath(map, visitedMap, xPosition + 1, yPosition, Direction.LEFT, moveableDirections);
            if (right) return true;
            else positions.Pop();
        }
        if (notMoveable != Direction.UPPER_LEFT && xPosition != 0 && yPosition != 0)
        {
             upperLeft = GetPath(map, visitedMap, xPosition - 1, yPosition + 1, Direction.LOWER_RIGHT, moveableDirections);
            if (upperLeft) return true;
            else positions.Pop();
        }
        if (notMoveable != Direction.UPPER_RIGHT && xPosition < map[0].Count - 1 && yPosition != 0)
        {
             upperRight = GetPath(map, visitedMap, xPosition + 1, yPosition + 1, Direction.LOWER_LEFT, moveableDirections);
            if (upperRight) return true;
            else positions.Pop();
        }
        if (notMoveable != Direction.LOWER_LEFT && xPosition != 0)
        { 
             lowerLeft = GetPath(map, visitedMap, xPosition - 1, yPosition - 1, Direction.UPPER_RIGHT, moveableDirections);
            if (lowerLeft) return true;
            else positions.Pop();
        }
        if (notMoveable != Direction.LOWER_RIGHT && xPosition < map[0].Count - 1)
        {
             lowerRight = GetPath(map, visitedMap, xPosition + 1, yPosition - 1, Direction.UPPER_LEFT, moveableDirections);
            if (lowerRight) return true;
            else positions.Pop(); 
        }

        var newMoveableDirection = new MoveableDirections
        {
            Down = down,
            Up = up,
            Left = left,
            Right = right,
            UpperLeft = upperLeft,
            UpperRight = upperRight,
            LowerLeft = lowerLeft,
            LowerRight = lowerRight,
        };
        moveableDirections[yPosition][xPosition] = newMoveableDirection;
        visitedMap[yPosition][xPosition] = false;
    }

    var moveableDirection = moveableDirections[yPosition][xPosition]; 
    return moveableDirection.Up || moveableDirection.Down || moveableDirection.Left || moveableDirection.Right || moveableDirection.UpperLeft || moveableDirection.UpperRight
            || moveableDirection.LowerLeft || moveableDirection.LowerRight;
}  

 CreatePath(new List<List<bool>> { 
    new List<bool> { true, true, false, true }, 
    new List<bool> { false, true, true, true },
    new List<bool> { false, true, true, false },
    new List<bool> { false, false, false, true },
    new List<bool> { false, false, true, false },
    new List<bool> { false, true, false, true },
    new List<bool> { true, false, false, true },
});
Console.WriteLine(JsonConvert.SerializeObject(positions));