using System;
using System.Collections.Generic;
using Xunit;

namespace BuildOrder.Iterative
{
    public class BuildOrderTest
    {
        [Fact]
        public void BuildOrder_ShouldOrderProjects_Example_from_the_book()
        {
            // Arrange
            Project[] projects = new Project[] {
                new Project("A"),
                new Project("B"),
                new Project("C"),
                new Project("D"),
                new Project("E"),
                new Project("F")
            };

            string[][] dependencies = new string[][] {
                new string[] { "A", "B" },
                new string[] { "F", "B"},
                new string[] { "B", "D"},
                new string[] { "F", "A"},
                new string[] { "D", "C"}
            };

            Solution solution = new Solution(projects, dependencies);

            // Act
            Project[] order = solution.FindOrder();

            // Assert
            Assert.Equal("E", order[0].Name);
            Assert.Equal("F", order[1].Name);
            Assert.Equal("A", order[2].Name);
            Assert.Equal("B", order[3].Name);
            Assert.Equal("D", order[4].Name);
            Assert.Equal("C", order[5].Name);
        }

         [Fact]
        public void BuildOrder_ShouldOrderProjects()
        {
            // Arrange
            Project[] projects = new Project[] {
                new Project("A"),
                new Project("B"),
                new Project("C"),
                new Project("E"),
                new Project("F")
            };

            string[][] dependencies = new string[][] {
                new string[] { "E", "B" },
                new string[] { "E", "C"},
                new string[] { "C", "A"},
                new string[] { "F", "C"},
                new string[] { "F", "E"}
            };

            Solution solution = new Solution(projects, dependencies);

            // Act
            Project[] order = solution.FindOrder();

            // Assert
            Assert.Equal("F", order[0].Name);
            Assert.Equal("E", order[1].Name);
            Assert.Equal("B", order[2].Name);
            Assert.Equal("C", order[3].Name);
            Assert.Equal("A", order[4].Name);
        }

        [Fact]
        public void BuildOrder_WithCircularDepenency_ShouldReturnNull()
        {
            // Arrange
            Project[] projects = new Project[] {
                new Project("A"),
                new Project("B"),
                new Project("C"),
                new Project("E"),
                new Project("F")
            };

            string[][] dependencies = new string[][] {
                new string[] { "E", "B" },
                new string[] { "E", "C"},
                new string[] { "C", "A"},
                new string[] { "F", "C"},
                new string[] { "F", "E"},
                new string[] { "B", "F"}
            };

            Solution solution = new Solution(projects, dependencies);

            // Act
            Project[] order = solution.FindOrder();

            // Assert
            Assert.Null(order);
        }
    }

    public class Solution
    {
        public Solution(Project[] projects, string[][] dependencies)
        {
            Projects = projects;
            Dependencies = dependencies;
        }

        public Project[] Projects { get; private set; }
        public string[][] Dependencies { get; private set; }
        
        public Project[] FindOrder()
        {
            Graph graph = BuildGraph(Projects, Dependencies);
            return OrderProjects(graph.Nodes);
        }

        private Graph BuildGraph(Project[] projects, string[][] dependencies)
        {
            Graph graph = new Graph();

            foreach(Project project in projects)
                graph.CreateNode(project.Name);

            foreach(string[] dependency in dependencies)
            {
                string start = dependency[0];
                string end = dependency[1];
                graph.AddEdge(start, end);
            }

            return graph;
        }

        private Project[] OrderProjects(List<Project> projects)
        {
            Project[] order = new Project[projects.Count];
           
            int endOfList = AddNonDependent(projects, order, 0);
            int toBeProcessed = 0;

            while(toBeProcessed < endOfList || endOfList == 0)
            {
                Project current = order[toBeProcessed];

                if (current == null)
                    return null;

                foreach(Project child in current.Children)
                    child.DecrementDependencies();

                endOfList = AddNonDependent(current.Children, order, endOfList);
                toBeProcessed++;
            }

            return order;
        }

        private int AddNonDependent(List<Project> projects, Project[] order, int offset)
        {
            foreach(Project project in projects)
                if (project.NumberOfDependencies == 0)
                {
                    order[offset] = project;
                    offset++;
                }

            return offset;
        }
    }


    public class Graph
    {
        private Dictionary<string, Project> _map = new Dictionary<string, Project>();

        public Project CreateNode(string name)
        {
            if (!_map.ContainsKey(name))
            {
                Project project = new Project(name);
                Nodes.Add(project);
                _map.Add(name, project);
            }

            return _map[name];
        }

        public void AddEdge(string startName, string endName)
        {
            Project start = CreateNode(startName);
            Project end = CreateNode(endName);
            start.AddNeighbor(end);
        }
        
        public List<Project> Nodes { get; } = new List<Project>();
    }

    public class Project
    {
        private HashSet<string> _map = new HashSet<string>();

        public Project(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
        public int NumberOfDependencies { get; private set; }
        public List<Project> Children  { get; } = new List<Project>(); 

        public void AddNeighbor(Project node)
        {
            if (!_map.Contains(node.Name))
            {
                Children.Add(node);
                _map.Add(node.Name);
                node.IncrementDependencies();
            }
        }

        public void IncrementDependencies() => NumberOfDependencies++;
        public void DecrementDependencies() => NumberOfDependencies--;
    }

}
