using System;
using System.IO;

namespace AlgorithmsLabs.Fifth
{
    class BST
    {
        public class Node
        {
            public long Key { get; set; }
            public Node Parent { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(long key, Node parent)
            {
                Parent = parent;
                Key = key;
                Left = null;
                Right = null;
            }
        }

        private Node _root;

        public BST()
        {
            _root = null;
        }

        public Node Search(long key)
        {
            Node nowNode = _root;
            while (nowNode != null)
            {
                if (nowNode.Key == key)
                {
                    break;
                }

                if (nowNode.Key < key)
                {
                    nowNode = nowNode.Right;
                }
                else
                {
                    nowNode = nowNode.Left;
                }
            }

            return nowNode;
        }


        public Node Next(long key)
        {
            Node current = _root;
            Node result = null;
            while (current != null)
            {
                if (current.Key > key)
                {
                    result = current;
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }

            return result;
        }

        public Node Prev(long key)
        {
            Node current = _root;
            Node result = null;
            while (current != null)
            {
                if (current.Key < key)
                {
                    result = current;
                    current = current.Right;
                }
                else
                {
                    current = current.Left;
                }
            }

            return result;
        }

        public void Insert(long key)
        {
            Node newNode = new Node(key, null);
            Node nowNode = _root;
            while (nowNode != null)
            {
                newNode.Parent = nowNode;
                if (nowNode.Key > newNode.Key)
                {
                    nowNode = nowNode.Left;
                } else if (nowNode.Key < newNode.Key)
                {
                    nowNode = nowNode.Right;
                }
                else
                {
                    return;
                }
            }

            if (newNode.Parent == null)
            {
                _root = newNode;
            } else if (newNode.Parent.Key > newNode.Key)
            {
                newNode.Parent.Left = newNode;
            } else if (newNode.Parent.Key < newNode.Key)
            {
                newNode.Parent.Right = newNode;
            }
        }

        public void Remove(long key)
        {
            Node nowNode = Search(key);
            if (nowNode == null)
            {
                return;
            }

            Node parentNode = nowNode.Parent;

            if (nowNode.Left == null && nowNode.Right == null)
            {
                if (parentNode == null) {
                    _root = null;
                } else 
                if (parentNode.Left == nowNode)
                {
                    parentNode.Left = null;
                }
                else
                {
                    parentNode.Right = null;
                }
                nowNode.Parent = null;
            }
            else if (nowNode.Right == null)
            {
                if (parentNode == null)
                {
                    _root = nowNode.Left;
                } else 
                if (parentNode.Left == nowNode)
                {
                    parentNode.Left = nowNode.Left;
                }
                else
                {
                    parentNode.Right = nowNode.Left;
                }
                nowNode.Left.Parent = parentNode;
            }
            else if (nowNode.Left == null)
            {
                if (parentNode == null)
                {
                    _root = nowNode.Right;
                }
                else if (parentNode.Left == nowNode)
                {
                    parentNode.Left = nowNode.Right;
                }
                else
                {
                    parentNode.Right = nowNode.Right;
                }
                nowNode.Right.Parent = parentNode;
            }
            else
            {
                Node newNode = Next(nowNode.Key);

                if (newNode.Parent.Left == newNode)
                {
                    newNode.Parent.Left = newNode.Right;
                    if (newNode.Right != null)
                    {
                        newNode.Right.Parent = newNode.Parent;
                    }
                }
                else
                {
                    newNode.Parent.Right = newNode.Right;
                    if (newNode.Right != null)
                    {
                        newNode.Right.Parent = newNode.Parent;
                    }
                }

                nowNode.Key = newNode.Key;
            }
        }
    }

    class BSTCommands
    {
        static void Main(string[] args)
        {
            using (StreamReader inputFile = new StreamReader("bstsimple.in"))
            {
                using (StreamWriter outputFile = new StreamWriter("bstsimple.out"))
                {
                    string[] command;
                    BST myTree = new BST();
                    while (true)
                    {
                        command = inputFile.ReadLine()?.Trim().Split();
                        if (command == null)
                        {
                            break;
                        }
                        switch (command[0])
                        {
                            case "insert":
                                myTree.Insert(Int64.Parse(command[1]));
                                break;
                            case "delete":
                                myTree.Remove(Int64.Parse(command[1]));
                                break;
                            case "exists":
                                outputFile.WriteLine(myTree.Search(Int64.Parse(command[1])) != null ? "true" : "false");
                                break;
                            case "next":
                                outputFile.WriteLine(myTree.Next(Int64.Parse(command[1]))?.Key.ToString() ?? "none");
                                break;
                            case "prev":
                                outputFile.WriteLine(myTree.Prev(Int64.Parse(command[1]))?.Key.ToString() ?? "none");
                                break;
                        }
                    }

                }
            }
        }
    }
}