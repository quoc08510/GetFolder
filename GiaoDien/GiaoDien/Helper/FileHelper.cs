namespace GiaoDien.Helper;

public static class FileHelper
{
    public static List<string> GetFile(this List<TreeNode> treeNodes)
    {
        var paths = new List<string>();
        foreach (TreeNode node in treeNodes)
        {
            if (node.Nodes is null || node.Nodes.Count == 0)
            {
                paths.AddRange(GetAllFiles(node.Name));
            }
            else
            {
                paths.AddRange(Directory.GetFiles(node.Name));
            }
        }
        return paths;
    }

    static string[] GetAllFiles(string folderPath)
    {
        string[] files = Directory.GetFiles(folderPath);
        string[] subDirectories = Directory.GetDirectories(folderPath);
        foreach (string subDirectory in subDirectories)
        {
            string[] subFiles = GetAllFiles(subDirectory);
            files = files.Concat(subFiles).ToArray();
        }
        return files;
    }
}
