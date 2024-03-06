namespace MazeAI;

public static partial class Search
{
    public static bool AStar(Space start, Space goal)
     {
        var queue = new PriorityQueue<Space, float>();
        var dist = new Dictionary<Space, float>();
        var prev = new Dictionary<Space, Space>();

        queue.Enqueue(start, 0);
        dist[start] = 0.0f;

        while (queue.Count > 0)
        {
            var currSpace = queue.Dequeue();

            if (currSpace.Visited)
                continue;

            currSpace.Visited = true;

            if (currSpace == goal)
            {
                currSpace.IsSolution = true;
                break;
            }

            Space[] spaces = new Space[] { currSpace.Top, currSpace.Left, currSpace.Bottom, currSpace.Right };

            foreach (var space in spaces)
            {
                if (space is not null)
                {
                    var newWeight = dist[currSpace] + 1;

                    if (!dist.ContainsKey(space))
                    {
                        dist[space] = float.PositiveInfinity;
                        prev[space] = null!;
                    }

                    if (newWeight < dist[space])
                    {
                        dist[space] = newWeight;
                        prev[space] = currSpace;
                        queue.Enqueue(space, newWeight);
                    }
                }
            }
        }

        var attempt = goal;
        while (attempt != start)
        {
            if (!prev.ContainsKey(attempt))
                return false;

            attempt = prev[attempt];
            attempt.IsSolution = true;
        }

        return true;
    }
}

