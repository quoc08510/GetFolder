using GiaoDien.Log;

namespace GiaoDien.Helper;

public static class TreeViewHelper
{
    private static readonly MyLogger myLogger = new MyLogger();
    public static void AddImageList(this TreeView treeView, string imagePath, string imageName)
    {
        var imageList = new ImageList();
        Image image = Image.FromFile(imagePath);
        imageList.Images.Add(imageName, image);
        DrawImage(imageList, treeView);
    }
    private static void DrawImage(ImageList imageList, TreeView treeView)
    {
        Point destPt = new Point(6, 0);
        Size size = new Size(22, 16);
        treeView.ImageList = new ImageList();
        treeView.ImageList.ImageSize = size;
        foreach (var imgKey in imageList.Images.Keys)
        {
            Bitmap bmp = new Bitmap(size.Width, size.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.DrawImage(imageList.Images[imgKey], destPt);
            g.Dispose();
            treeView.ImageList.Images.Add(imgKey, (Image)bmp);
        }
    }
    public static List<TreeNode> GetAllCheckedNodes(this TreeView treeView)
    {
        var checkedPath = new List<TreeNode>();
        foreach (TreeNode rootNode in treeView.Nodes)
        {
            if(rootNode.Checked) checkedPath.Add(rootNode);
            GetCheckedNodesRecursive(rootNode, checkedPath);
        }
        return checkedPath;
    }
    private static void GetCheckedNodesRecursive(TreeNode treeNode, List<TreeNode> checkedNodes)
    {
        foreach (TreeNode childNode in treeNode.Nodes)
        {
            if (childNode.Checked)
            {
                checkedNodes.Add(childNode);
            }
            GetCheckedNodesRecursive(childNode, checkedNodes);
        }
    }
    public static void ChangeCheckedParrentNode(this TreeNode parrentNode)
    {
        foreach (TreeNode childNode in parrentNode.Nodes)
        {
            childNode.Checked = parrentNode.Checked;
            ChangeCheckedParrentNode(childNode);
        }
    }
    public static void AddTreeNode(this TreeNode node, string path)
    {
        try
        {
            myLogger.Info($"Start Add Child Folder {Path.GetFileName(path)}");
            if (node.Nodes.Count != 0 && node.Nodes != null) return;
            foreach (var childPath in Directory.GetDirectories(path))
            {
                var nameFile = Path.GetFileName(childPath);
                TreeNode newNode = new TreeNode(nameFile, imageIndex: 0, selectedImageIndex: 0);
                newNode.Name = childPath;
                newNode.Checked = node.Checked;
                node.Nodes.Add(newNode);
            }
        }
        catch (UnauthorizedAccessException ex)
        {
            myLogger.Error(ex.Message);
        }
    }
}
