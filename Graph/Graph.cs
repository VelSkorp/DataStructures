using System.Collections.Generic;

namespace Graph
{
    class Graph
    {
        public List<GraphVertex> Vertices { get; }
        public Graph()
        {
            Vertices = new List<GraphVertex>();
        }
        public void AddVertex(string vertexName)
        {
            Vertices.Add(new GraphVertex(vertexName));
        }
        public GraphVertex FindVertex(string vertexName)
        {
            foreach (var vertex in Vertices)
                if (vertex.Name==vertexName)
                    return vertex;
            return null;
        }
        public void AddEdge(string firstName,string secondName,int weight)
        {
            var v1 = FindVertex(firstName);
            var v2 = FindVertex(secondName);
            if (v1 != null && v2 == null)
            {
                v1.AddEdge(v2, weight);
                v2.AddEdge(v1, weight);
            }
        }
    }
}