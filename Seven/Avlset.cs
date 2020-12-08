using System;
using System.Collections.Generic;
using System.IO;

namespace AlgorithmsLabs.Seven
{
    internal class Node
    {
        public int key;
        public int height;
        public Node[] children;

        public Node(int Key)
        {
            key = Key;
            children = new Node[] {null, null};
            height = 1;
        }

    }

    enum Side
    {
        right = 0,
        left = 1
    };

    internal class Tree
    {
        public Node root;

        public Tree()
        {
            root = null;
        }

        public int CountBalance(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            return (node.children[1] != null ? node.children[1].height : 0) -
                   (node.children[0] != null ? node.children[0].height : 0);
        }

        public void FixHeight(Node node)
        {
            node.height = Math.Max(HeightLeft(node), HeightRight(node))+1;
        }

        public int HeightLeft(Node node)
        {
            return node.children[0] == null ? 0 : node.children[0].height;
        }

        public int HeightRight(Node node)
        {
            return node.children[1] == null ? 0 : node.children[1].height;
        }

        public Node Rotate(Node node, Side side)
        {
            Node second = node.children[side==Side.left ? 1 : 0];
            node.children[side == Side.left ? 1 : 0] = second.children[side == Side.left ? 0 : 1];
            second.children[side == Side.left ? 0 : 1] = node;
            FixHeight(node);
            FixHeight(second);
            return second;
        }

        public Node Balance(Node node)
        {
            FixHeight(node);
            if (CountBalance(node) > 1)
            {
                if (CountBalance(node.children[1]) < 0)
                {
                    node.children[1] = Rotate(node.children[1], Side.right);
                }
                return Rotate(node,Side.left);
                

            }

            if (CountBalance(node) < -1)
            {
                if (CountBalance(node.children[0]) > 0)
                {
                    node.children[0] = Rotate(node.children[0],Side.left);
                }
                return Rotate(node,Side.right);
                
            }

            return node;
        }

        public Node Insert(Node node, int key)
        {
            if (node == null)
            {
                return new Node(key);
            }

            node.children[key < node.key ? 0 : 1] = Insert(node.children[key < node.key ? 0 : 1], key);
            return Balance(node);
        }

        public Node FindMax(Node node)
        {
            return node.children[1] == null ? node : FindMax(node.children[1]);
        }

        public Node Remove(Node node, int key)
        {
            if (node == null)
            {
                return null;
            }

            if (key != node.key)
            {
                node.children[key < node.key ? 0 : 1] = Remove(node.children[key < node.key ? 0 : 1],key);
            }
            else
            {
                if (node.children[0] == null && node.children[1] == null)
                {
                    return null;
                }

                if (node.children[0] == null)
                {
                    node = node.children[1];
                    return Balance(node);
                }

                Node r = FindMax(node.children[0]);
                node.key = r.key;
                node.children[0] = Remove(node.children[0], r.key);
            }

            return Balance(node);
        }

        public Node Search(Node node, int key)
        {
            if (node == null || node.key == key)
            {
                return node;
            }

            return Search(node.children[key < node.key ? 0 : 1], key);
        }

    }

    internal class AVLCommands
    {
        private static void Main()
        {
            StreamReader inputFile = new StreamReader("avlset.in");
            StreamWriter outputFile = new StreamWriter("avlset.out");
            int comCount = Int32.Parse(inputFile.ReadLine());
            string[] com;
            Tree tree = new Tree();
            for (int i = 0; i < comCount; i++)
            {
                com = inputFile.ReadLine().Split();
                int key = Int32.Parse(com[1]);
                if (com[0] == "A")
                {
                    if (tree.Search(tree.root, key) == null)
                    {
                        tree.root = tree.Insert(tree.root, key);
                    }
                    outputFile.WriteLine(tree.CountBalance(tree.root));
                }
                else if (com[0] == "D")
                {
                    if (tree.Search(tree.root, key) != null)
                    {
                        tree.root = tree.Remove(tree.root, key);
                    }
                    outputFile.WriteLine(tree.CountBalance(tree.root));
                }
                else
                {
                    outputFile.WriteLine((tree.Search(tree.root,key)!=null) ? "Y" : "N");
                }
            }

            outputFile.Close();
            inputFile.Close();
        }
    }
}