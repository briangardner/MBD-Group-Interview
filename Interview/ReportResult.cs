using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interview
{
    /// <summary>
    /// This is an individual line in the report file that will contain the Path name, the root node, and the count of the XMLElement
    /// being searched for.
    /// </summary>
    class ReportResult
    {
       /// <summary>
       /// Gets and sets the path of the FileName of the XML file of this result
       /// </summary>
        public string filePath
        {
            get;
            set;
        }
        /// <summary>
        /// Gets and Sets the Root Node Name of this Result.
        /// </summary>
        public string rootNodeName
        {
            get;
            set;
        }
        /// <summary>
        /// Gets and Sets the count of the number of times the Target Node was found.
        /// </summary>
        public int nodeCount
        {
            get;
            set;
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="file">Path of XML file that contains XML Element being searched for</param>
        /// <param name="rootNode">Root node of the XML File above</param>
        /// <param name="count">Number of times the XML Element is found in this file</param>
        public ReportResult(string file, string rootNode, int count)
        {
            filePath = file;
            rootNodeName = rootNode;
            nodeCount = count;
        }

        /// <summary>
        /// Constructor without an initial count.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="rootNode"></param>
        public ReportResult(string file, string rootNode)
        {
            filePath = file;
            rootNodeName = rootNode;
            nodeCount = 0;
        }
        /// <summary>
        /// Increments node count by 1
        /// </summary>
        /// <returns>int</returns>
        public int incrementCount()
        {
            nodeCount = ++nodeCount;
            return nodeCount;
        }

        /// <summary>
        /// Increments node count by amount specified
        /// </summary>
        /// <param name="amount">Amount to increment</param>
        /// <returns>int</returns>
        public int incrementCount(int amount)
        {
            nodeCount = nodeCount + amount;
            return nodeCount;
        }
        /// <summary>
        /// Decrements node count by 1
        /// </summary>
        /// <returns>int</returns>
        public int decrementCount()
        {
            nodeCount = --nodeCount;
            return nodeCount;
        }

        /// <summary>
        /// Decrements node count by amount specified
        /// </summary>
        /// <param name="amount">Amount to decrement</param>
        /// <returns>int</returns>
        public int decrementCount(int amount)
        {
            nodeCount = nodeCount - amount;
            return nodeCount;
        }
    }
}
