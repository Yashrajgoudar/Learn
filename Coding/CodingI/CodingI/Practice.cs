using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingI
{
    public class Logger
    {
        private static Logger _instance;
        private static readonly object _lock = new object();
        private Logger()
        {
            Console.WriteLine("Logger instance created.");
        }

        public static Logger Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new Logger();
                }
                return _instance;
            }
        }
    }

    public interface IDocument
    {
        void Print();
    }
    public class WordDoc : IDocument
    {
        public void Print()
        {
            Console.WriteLine("Printing Word Document");
        }
    }
    public class PdfDoc : IDocument
    {
        public void Print()
        {
            Console.WriteLine("Printing PDF Document");
        }
    }

    public class DocumentFactory
    {
        public static IDocument GetDoc(string type)
        {
            switch (type.ToLower())
            {
                case "word":
                    return new WordDoc();
                case "pdf":
                    return new PdfDoc();
                default:
                    throw new ArgumentException("Invalid document type");
            }
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            IDocument doc1 = DocumentFactory.GetDoc("word");
            doc1.Print();
        }
    }
}
