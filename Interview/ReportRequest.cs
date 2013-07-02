using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Diagnostics;

namespace Interview
{
    class ReportRequest
    {
        private string _XMLPath, _ReportPath, _TargetElement;
        private bool _includeSubDirectories;

        public ReportRequest(string xmlPath, string reportPath, bool includeSubDirs, string targetElement)
        {
            _XMLPath = xmlPath;
            _ReportPath = reportPath;
            _includeSubDirectories = includeSubDirs;
            _TargetElement = targetElement;
        }

        /// <summary>
        /// Add all XML Files in the path specified.  If includeSubDirs = true, recursively call this
        /// method to add files to the List.
        /// </summary>
        /// <returns>List of strings that are paths to XML Files</returns>
        /// 
        public List<String> getFiles()
        {
            return this.getFiles(_XMLPath, _includeSubDirectories);
        }

        /// <summary>
        /// This actually does the work of getFiles().  This will search for XML piles in the specified path.
        /// It will do so recursively if includeSubDirectories = true.
        /// </summary>
        /// <param name="path">Folder path to look for XML files in</param>
        /// <param name="includeSubDirs">Include Sub Directories?</param>
        /// <returns>List of strings that are file paths to XML files</returns>
        private List<String> getFiles(string path, bool includeSubDirs)
        {
            List<string> files = new List<string>();
            ///Loop through all files in current directory
            ///
            try
            {
                foreach (string file in Directory.GetFiles(path))
                {
                    ///If the file is an XML file, add it to the list of files
                    if (Path.GetExtension(file).ToUpper() == ".XML")
                    {
                        files.Add(file);
                    }
                }
                ///If includeSubDirs is true, recursively call this, and add the List generated to this level's list.
                if (includeSubDirs)
                {
                    foreach (string directory in Directory.GetDirectories(path))
                    {
                        files.AddRange(this.getFiles(directory, includeSubDirs));
                    }
                }
                
            }
            catch (DirectoryNotFoundException ex)
            {
                throw new DirectoryNotFoundException(ex.Message.ToString());
            }
            
            return files;
        }

        /// <summary>
        ///   This loops through each XML file found in getFiles.  With each file, it runs and XPath query
        ///   to see if the target Element exists.  If it does, it increments the count of the ReportResult, and adds
        ///   that ReportResult to the List.
        /// </summary>
        /// <returns>A List of ReportResults, which contains the file path, root element, and target Element count</returns>
        public List<ReportResult> findTarget()
        {
            List<ReportResult> reportData = new List<ReportResult>();
            List<String> files = new List<String>();
            ReportResult result;
            XPathDocument xpDoc;
            XPathNavigator xNavigator;
            XPathNodeIterator xIterator;
            XmlDocument xdoc;
            string token = "//" + _TargetElement;
            ///Loop through all XML files found in getFiles()
            ///Open the XML file, get the Root node.
            ///After that, use XPath to find all XMLElements that match the token specified in the UI.
            ///For every instance found, increment the counter for the result element.
            ///As long as 1 or more instances of the XMLElement are found, add it to the result list.
            ///
            files.AddRange(getFiles());
            foreach (string file in files)
            {
                xpDoc = new XPathDocument(file);
                xdoc = new XmlDocument();
                try
                {
                    xdoc.Load(file);
                    result = new ReportResult(file, xdoc.DocumentElement.Name);
                    xNavigator = xpDoc.CreateNavigator();
                    xIterator = xNavigator.Select(token);
                    while (xIterator.MoveNext())
                    {
                        result.incrementCount();
                    }
                    if (result.nodeCount > 0)
                    {
                        reportData.Add(result);
                    }
                }
                catch (XmlException ex)
                {
                    System.Diagnostics.EventLog eventLog = new System.Diagnostics.EventLog();
                    if (!System.Diagnostics.EventLog.SourceExists("Interview"))
                        System.Diagnostics.EventLog.CreateEventSource(
                           "Interview", "Application");

                    eventLog.Source = "Interview";
                    eventLog.WriteEntry("XMLException: "+ex.Message.ToString());
                }
                catch (XPathException ex)
                {
                    System.Diagnostics.EventLog eventLog = new System.Diagnostics.EventLog();
                    if (!System.Diagnostics.EventLog.SourceExists("Interview"))
                        System.Diagnostics.EventLog.CreateEventSource(
                           "Interview", "Application");

                    eventLog.Source = "Interview";
                    eventLog.WriteEntry("XPathException: "+ex.Message.ToString());
                }
                catch (FileNotFoundException ex)
                {
                    System.Diagnostics.EventLog eventLog = new System.Diagnostics.EventLog();
                    if (!System.Diagnostics.EventLog.SourceExists("Interview"))
                        System.Diagnostics.EventLog.CreateEventSource(
                           "Interview", "Application");

                    eventLog.Source = "Interview";
                    eventLog.WriteEntry("FileNotFoundException: "+ex.Message.ToString());
                }
                catch (Exception ex)
                {
                    throw new Exception("Exception Occured: "+ex.Message.ToString());
                }

                
            }
            return reportData;
        }

        /// <summary>
        /// This generates the report.  It writes the results of findTarget to the ReportPath in a file called Results.txt.
        /// </summary>
        public void GenerateReport()
        {
            String filename = _ReportPath+"\\Results.txt";
            StreamWriter output = new StreamWriter(filename,false);
            List<ReportResult> results = new List<ReportResult>();
            results.AddRange(findTarget());
            try
            {
                output.Flush();
                foreach (ReportResult r in results)
                {
                    output.WriteLine("Path: {0} \t RootNode: {1} \t Count: {2}", r.filePath, r.rootNodeName, r.nodeCount);
                }
            }
            catch (EndOfStreamException ex)
            {
                throw new EndOfStreamException("End of Stream Exception: " + ex.Message.ToString());
            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException("File Not Found: "+ex.Message.ToString());
            }
            finally
            {
                output.Close();
            }
        }
    }
}
