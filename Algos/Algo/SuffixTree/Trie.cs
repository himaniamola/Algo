using System;

namespace Algos
{
    public class TrieNode
    {
        static readonly int ALPHABET_SIZE = 26;

        public TrieNode[] children = new TrieNode[ALPHABET_SIZE];

        public bool isEndOfWord;

        public TrieNode()
        {
            isEndOfWord = false;
            for (int i = 0; i < ALPHABET_SIZE; i++)
                children[i] = null;
        }
    };

    public class Trie
    {
        // trie node
        static TrieNode root;

        // If not present, inserts key into trie
        // If the key is prefix of trie node,
        // just marks leaf node
        static void Insert(String key)
        {
            int level;
            int length = key.Length;
            int index;

            TrieNode pCrawl = root;

            for (level = 0; level < length; level++)
            {
                index = key[level] - 'a';
                if (pCrawl.children[index] == null)
                    pCrawl.children[index] = new TrieNode();

                pCrawl = pCrawl.children[index];
            }

            // mark last node as leaf
            pCrawl.isEndOfWord = true;
        }

        // Returns true if key
        // presents in trie, else false
        static bool Search(String key)
        {
            int level;
            int length = key.Length;
            int index;
            TrieNode pCrawl = root;

            for (level = 0; level < length; level++)
            {
                index = key[level] - 'a';

                if (pCrawl.children[index] == null)
                    return false;

                pCrawl = pCrawl.children[index];
            }

            return (pCrawl.isEndOfWord);
        }
    }
}
