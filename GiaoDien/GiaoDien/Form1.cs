using GiaoDien.Class;
using GiaoDien.Helper;

namespace GiaoDien;

public partial class Form1 : Form
{
    public List<Folder> folders = new List<Folder>();

    public Form1()
    {
        InitializeComponent();
        GetDrives();
        //CreatePanelSelectFolder();
        CreateTreeView();
    }

    public void GetDrives()
    {
        DriveInfo[] allDrives = DriveInfo.GetDrives();
        foreach (DriveInfo drive in allDrives)
        {
            var parrent = new Folder();
            parrent.Path = drive.Name;
            parrent.Childrens = new();
            folders.Add(parrent);
        }
    }

    public void CreateTreeView()
    {
        tv_TreeFolder.CheckBoxes = true;
        TreeViewHelper.AddImageList(tv_TreeFolder, ImagePath.FolderIcon, nameof(ImagePath.FolderIcon));
        foreach (var parrent in folders)
        {
            TreeNode parrentNode = new TreeNode(parrent.Path, imageIndex: 0, selectedImageIndex: 0);
            parrentNode.Name = parrent.Path;
            tv_TreeFolder.Nodes.Add(parrentNode);
        }
        tv_TreeFolder.NodeMouseClick += Tv_TreeFolder_NodeMouseClick;
        tv_TreeFolder.AfterCheck += Tv_TreeFolder_AfterCheck;
    }

    private void Tv_TreeFolder_AfterCheck(object? sender, TreeViewEventArgs e)
    {
        e.Node.ChangeCheckedParrentNode();
    }

    private void Tv_TreeFolder_NodeMouseClick(object? sender, TreeNodeMouseClickEventArgs e)
    {
        e.Node.AddTreeNode(e.Node.Name);
    }

    private void btn_Scan_Click(object sender, EventArgs e)
    {
        var treeNode = tv_TreeFolder.GetAllCheckedNodes();
        var paths = treeNode.GetFile();
    }
}