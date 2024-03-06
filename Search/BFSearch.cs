namespace MazeAI;
public static partial class Search
{
    public static bool BFSearch(Space start, Space goal)
    {
        Queue<Space> queue = new Queue<Space>();
        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            var currSpace = queue.Dequeue();

            if (currSpace.Visited)
                continue;

            currSpace.Visited = true;

            if (currSpace == goal)
            {
                currSpace.IsSolution = true;
                return true;
            }

            Space[] spaces = new Space[] { currSpace.Top, currSpace.Left, currSpace.Bottom, currSpace.Right };

            foreach (var item in spaces)
            {
                if (item != null && item.Visited == false)
                {
                    queue.Enqueue(item);
                }
            }
        }

        return false;
    }
}