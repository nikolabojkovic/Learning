using System;
using System.Collections.Generic;
using Xunit;

namespace BuildOrder.DFS
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
                new string[] { "F", "B" },
                new string[] { "B", "D" },
                new string[] { "F", "A" },
                new string[] { "D", "C" }
            };

            Solution solution = new Solution(projects, dependencies);

            // Act
            Stack<Project> order = solution.FindOrder();

            // Assert
            Assert.Equal("F", order.Pop().Name);
            Assert.Equal("E", order.Pop().Name);
            Assert.Equal("A", order.Pop().Name);
            Assert.Equal("B", order.Pop().Name);
            Assert.Equal("D", order.Pop().Name);
            Assert.Equal("C", order.Pop().Name);
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
            Stack<Project> order = solution.FindOrder();

            // Assert
            Assert.Equal("F", order.Pop().Name);
            Assert.Equal("E", order.Pop().Name);
            Assert.Equal("C", order.Pop().Name);
            Assert.Equal("B", order.Pop().Name);
            Assert.Equal("A", order.Pop().Name);
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
            Stack<Project> order = solution.FindOrder();

            // Assert
            Assert.Null(order);
        }
    }

    public class Solution
    {
        private readonly Project[] _projects;
        private readonly string[][] _dependencies;

        public Solution(Project[] projects, string[][] dependencies)
        {
            _projects = projects;
            _dependencies = dependencies;
        }

        public Stack<Project> FindOrder()
        {
            Graph graph = BuildGraph();
            return OrderProjects(graph.Nodes);
        }

        public Stack<Project> OrderProjects(List<Project> projects)
        {
            Stack<Project> order = new Stack<Project>();

            foreach(Project project in projects)
            {
                if (project.State == ProjectState.NotVisited)
                {
                    if (!DoDFS(project, order))
                        return null;
                }
            }

            return order;
        }

        private bool DoDFS(Project project, Stack<Project> order)
        {
            if (project.State == ProjectState.Visiting)
                return false; // cycle

            if (project.State == ProjectState.NotVisited)
            {
                project.State = ProjectState.Visiting;
                foreach(Project child in project.Children)
                {
                    if (!DoDFS(child, order))
                        return false;
                }

                project.State = ProjectState.Visited;
                order.Push(project);
            }

            return true;
        }

        private Graph BuildGraph()
        {
            Graph graph = new Graph();

            foreach(Project project in _projects)
                graph.CreateNode(project.Name);

            foreach(string[] dependency in _dependencies)
            {
                string first = dependency[0];
                string second = dependency[1];
                graph.AddEdge(first, second);
            }

            return graph;
        }
    }

    public class Graph
    {
        private Dictionary<string, Project> _map = new Dictionary<string, Project>();

        public List<Project> Nodes = new List<Project>();

        public Project CreateNode(string name)
        {
            if (!_map.ContainsKey(name))
            {
                Project project = new Project(name);
                Nodes.Add(project);
                _map.Add(project.Name, project);
            }

            return _map[name];
        }

        public void AddEdge(string startName, string endName)
        {
            Project start = CreateNode(startName);
            Project end = CreateNode(endName);
            start.AddNaigbor(end);
        }
    }

    public class Project
    {
        private HashSet<string> _map = new HashSet<string>();

        public Project(string name)
        {
            Name = name;
        }

        public List<Project> Children { get; } = new List<Project>();
        public string Name { get; }
        public ProjectState State { get; set; }

        public void AddNaigbor(Project node)
        {
            if (!_map.Contains(node.Name))
            {
                Children.Add(node);
                _map.Add(node.Name);
            }
        }
    }

    public enum ProjectState
    {
        NotVisited,
        Visiting,
        Visited
    }
}