using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace VentileClient.Utils
{
    public class CompareDirs
    {

        public static bool AreSame(string DirPath1, string DirPath2)
        {
            if (!Directory.Exists(DirPath1) || !Directory.Exists(DirPath2)) return false;

                DirectoryInfo dir1 = new DirectoryInfo(DirPath1);
                DirectoryInfo dir2 = new DirectoryInfo(DirPath2);

                // Take a snapshot of the file system.  
                IEnumerable<FileInfo> list1 = dir1.GetFiles("*.*", SearchOption.AllDirectories);
                IEnumerable<FileInfo> list2 = dir2.GetFiles("*.*", SearchOption.AllDirectories);

                //A custom file comparer defined below  
                FileCompare myFileCompare = new FileCompare();

                // This query determines whether the two folders contain  
                // identical file lists, based on the custom file comparer  
                // that is defined in the FileCompare class.  
                // The query executes immediately because it returns a bool.  
                bool areIdentical = list1.SequenceEqual(list2, myFileCompare);

            return areIdentical;
        }

        public static FileInfo[] NewFiles(string DirPath1, string DirPath2)
        {
            if (!Directory.Exists(DirPath1) || !Directory.Exists(DirPath2)) return null;

            DirectoryInfo dir1 = new DirectoryInfo(DirPath1);
            DirectoryInfo dir2 = new DirectoryInfo(DirPath2);

            // Take a snapshot of the file system.  
            IEnumerable<FileInfo> list1 = dir1.GetFiles("*.*", SearchOption.AllDirectories);
            IEnumerable<FileInfo> list2 = dir2.GetFiles("*.*", SearchOption.AllDirectories);

            //A custom file comparer defined below  
            FileCompare myFileCompare = new FileCompare();
            // Find the set difference between the two folders.  
            // For this example we only check one way.  
            var queryList2Only = (from file in list2 // In list 2, but not list 1
                                  select file).Except(list1, myFileCompare);

            return queryList2Only.ToArray();
        }

        public static FileInfo[] OldFiles(string DirPath1, string DirPath2)
        {
            if (!Directory.Exists(DirPath1) || !Directory.Exists(DirPath2)) return null;

            DirectoryInfo dir1 = new DirectoryInfo(DirPath1);
            DirectoryInfo dir2 = new DirectoryInfo(DirPath2);

            // Take a snapshot of the file system.  
            IEnumerable<FileInfo> list1 = dir1.GetFiles("*.*", SearchOption.AllDirectories);
            IEnumerable<FileInfo> list2 = dir2.GetFiles("*.*", SearchOption.AllDirectories);

            //A custom file comparer defined below  
            FileCompare myFileCompare = new FileCompare();
            // Find the set difference between the two folders.  
            // For this example we only check one way.  
            var queryList1Only = (from file in list1 // In list 1, but not list 2
                                  select file).Except(list2, myFileCompare);

            return queryList1Only.ToArray();
        }
    }

    // This implementation defines a very simple comparison  
    // between two FileInfo objects. It only compares the name  
    // of the files being compared and their length in bytes.  
    class FileCompare : IEqualityComparer<FileInfo>
    {
        public FileCompare() { }

        public bool Equals(FileInfo f1, FileInfo f2)
        {
            return (f1.Name == f2.Name &&
                    f1.Length == f2.Length);
        }

        // Return a hash that reflects the comparison criteria. According to the
        // rules for IEqualityComparer<T>, if Equals is true, then the hash codes must  
        // also be equal. Because equality as defined here is a simple value equality, not  
        // reference identity, it is possible that two or more objects will produce the same  
        // hash code.  
        public int GetHashCode(FileInfo fi)
        {
            string s = $"{fi.Name}{fi.Length}";
            return s.GetHashCode();
        }
    }
}