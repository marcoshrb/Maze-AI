namespace MazeAI;

using System.Collections.Generic;
public static partial class Search
{
    public static bool DFSearch(Space space, Space goal)
    {

        if (space.Visited )
            return false;

        space.Visited = true;

        if (space == goal)
        {
            space.IsSolution = true;
            return true;
        }

        space.IsSolution = (space.Top is not null && space.Top.Visited == false && DFSearch(space.Top, goal))
                        || (space.Bottom != null && space.Bottom.Visited == false && DFSearch(space.Bottom, goal))
                        || (space.Left != null && space.Left.Visited == false && DFSearch(space.Left, goal))
                        || (space.Right != null && space.Right.Visited == false && DFSearch(space.Right, goal));
     
        return space.IsSolution;
    }
}