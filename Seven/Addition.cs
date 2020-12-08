using System;
using System.Collections.Generic;
using System.IO;

namespace AlgorithmsLabs.Seven
{
    internal class Node
    {
        public int key;
        public Node parent;
        public Node left;
        public Node right;

        public Node(int Key)
        {
            key = Key;
            left = null;
            right = null;
            parent = null;
        }
    }

    internal class Tree
    {
        public Node root;

        public void SmallLeftRotation(Node node)
        {
            if (node == null)
            {
                return;
            }
            if (node == root)
            {
                node = root;
                root = node.right;
                Node ls = node.right?.left ?? null;
                node.right = ls;
                root.left = node;

                if (ls != null)
                {
                    ls.parent = node;
                }

                root.parent = null;
                node.parent = root;
            }
            else
            {
                Node b = node.right;
                node.right = b?.left ?? null;
                b.left = node;

                b.parent = node.parent;
                node.parent = b;
                if (node.right != null)
                {
                    node.right.parent = node;
                }

                if (b.parent.left == node)
                {
                    b.parent.left = b;
                }
                else
                {
                    b.parent.right = b;
                }
            }
        }

        public void SmallRightRotation(Node node)
        {
            if (node == null)
            {
                return;
            }
            if (node == root)
            {
                node = root;
                root = node.left;
                Node rs = node.left?.right ?? null;
                node.left = rs;
                root.right = node;
                if (rs != null)
                {
                    rs.parent = node;
                }

                root.parent = null;
                node.parent = root;
            }
            else
            {
                Node b = node.left;
                node.left = b?.right ?? null;
                b.right = node;

                b.parent = node.parent;
                node.parent = b;
                if (node.left != null)
                {
                    node.left.parent = node;
                }

                if (b.parent.left == node)
                {
                    b.parent.left = b;
                }
                else
                {
                    b.parent.right = b;
                }
            }
        }

        public void BigLeftRotation(Node node)
        {
            SmallRightRotation(node.right);
            SmallLeftRotation(node);
        }

        public void BigRightRotation(Node node)
        {
            SmallLeftRotation(node.left);
            SmallRightRotation(node);
        }

        public void LogTree(StreamWriter outputFile)
        {
            Queue<Node> myQueue = new Queue<Node>();
            myQueue.Enqueue(root);
            Node node;
            int i = 2;
            while (myQueue.Count != 0)
            {
                outputFile.WriteLine();
                node = myQueue.Dequeue();
                outputFile.Write($"{node.key} ");
                if (node.left != null)
                {
                    myQueue.Enqueue(node.left);
                    outputFile.Write($"{i} ");
                    i++;
                }
                else
                {
                    outputFile.Write($"0 ");
                }

                if (node.right != null)
                {
                    myQueue.Enqueue(node.right);
                    outputFile.Write($"{i}");
                    i++;
                }
                else
                {
                    outputFile.Write($"0");
                }
            }
        }

        public int GetBalance(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            return GetHeight(node.right) - GetHeight(node.left);
        }

        public int GetHeight(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            return Math.Max(GetHeight(node.left), GetHeight(node.right)) + 1;
        }

        public void Insert(Node node)
        {
            if (root == null)
            {
                root = node;
                return;
            }

            Node curNode = root;
            while (true)
            {
                if (curNode.key > node.key)
                {
                    if (curNode.left == null)
                    {
                        curNode.left = node;
                        node.parent = curNode;
                        break;
                    }
                    else
                    {
                        curNode = curNode.left;
                    }
                }
                else
                {
                    if (curNode.right == null)
                    {
                        curNode.right = node;
                        node.parent = curNode;
                        break;
                    }
                    else
                    {
                        curNode = curNode.right;
                    }
                }
            }
            curNode = node.parent;

            while (curNode != null)
            {
                int b = GetBalance(curNode);
                if (b > 1)
                {
                    if (GetBalance(curNode.right) < 0)
                    {
                        BigLeftRotation(curNode);
                    }
                    else
                    {
                        SmallLeftRotation(curNode);
                    }

                    }
                else if (b < -1)
                {
                    if (GetBalance(curNode.left) > 0)
                    {
                        BigRightRotation(curNode);
                    }
                    else
                    {
                        SmallRightRotation(curNode);
                    }
                }

                curNode = curNode.parent;
            }
        }
    }

    internal class AVLCommands
    {
        private static void Main()
        {
            StreamReader inputFile = new StreamReader("addition.in");
            int nodeCount = Int32.Parse(inputFile.ReadLine());
            string[] input;
            int left;
            int right;
            int[] parents = new int[nodeCount + 1];
            Node[] nodes = new Node[nodeCount + 1];
            Node node;
            Tree tree = new Tree();

            if (nodeCount != 0)
            {
                input = inputFile.ReadLine().Split();
                left = Int32.Parse(input[1]);
                right = Int32.Parse(input[2]);

                node = new Node(Int32.Parse(input[0]));

                tree.root = node;

                parents[left] = -1;
                parents[right] = 1;
                nodes[1] = node;
            }
            for (int i = 2; i < nodeCount + 1; i++)
            {
                input = inputFile.ReadLine().Split();
                left = Int32.Parse(input[1]);
                right = Int32.Parse(input[2]);

                node = new Node(Int32.Parse(input[0]));

                if (parents[i] < 0)
                {
                    nodes[(-1) * parents[i]].left = node;
                    node.parent = nodes[(-1) * parents[i]];
                }
                else
                {
                    nodes[parents[i]].right = node;
                    node.parent = nodes[parents[i]];
                }

                nodes[i] = node;
                parents[left] = -i;
                parents[right] = i;
            }

            int newNodeKey = Int32.Parse(inputFile.ReadLine());
            Node newNode = new Node(newNodeKey);
            tree.Insert(newNode);

            StreamWriter outputFile = new StreamWriter("addition.out");
            outputFile.Write(nodeCount + 1);
            tree.LogTree(outputFile);
            outputFile.Close();
            inputFile.Close();
        }
    }
}