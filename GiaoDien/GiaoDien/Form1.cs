using GiaoDien.Class;
using System.ComponentModel;

namespace GiaoDien;

public partial class Form1 : Form
{
    public List<Folder> folders = new List<Folder>();

    public Form1()
    {
        InitializeComponent();
        GetDrives();
        CreatePanelSelectFolder();
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

    public void CreateViewFolder(int xLocation, int yLocation, string nameFolder, string path, bool isChoice = false)
    {
        var checkBox = new CheckBox();
        checkBox.Checked = isChoice;
        checkBox.AutoSize = true;
        checkBox.Location = new Point(xLocation, yLocation);

        var label = new Label();
        label.AutoSize = true;
        label.Text = nameFolder;
        label.Name = path;
        label.Location = new Point(xLocation + 20, yLocation);
        label.Click += Click_Folder;

        pn_SelectFolder.Controls.Add(checkBox);
        pn_SelectFolder.Controls.Add(label);
    }

    private Folder GetFolderByPath(List<Folder> childrens, string path)
    {
        if (childrens is null || childrens.Count == 0) return null;
        var folder = childrens.Where(x => x.Path.Equals(path)).FirstOrDefault();
        if (folder != null) return folder;
        foreach(var child in childrens)
        {
            folder = GetFolderByPath(child.Childrens, path);
            if(folder  != null) return folder;
        }
        return null;
    }


    private void Click_Folder(object? sender, EventArgs e)
    {
        var label = sender as Label;
        var path = label.Name;
        var folder = GetFolderByPath(folders, path);
        if (folder == null) return;
        folder.Childrens = new();
        foreach (var child in Directory.GetDirectories(path))
        {
            var parrent = new Folder();
            parrent.Path = child;
            parrent.Childrens = new();
            folder.Childrens.Add(parrent);
        }
        CreatePanelSelectFolder();
    }

    public void CreatePanelSelectFolder()
    {
        pn_SelectFolder.Controls.Clear();
        int xLocation = 20;
        int yLocation = 20;
        foreach (var path in folders)
        {
            var name = Path.GetPathRoot(path.Path);
            CreateViewFolder(xLocation, yLocation, name, path.Path, path.IsChoice);
            yLocation += 30;
            yLocation = ReadChildrenFolder(xLocation, yLocation, path.Childrens);
        }
    }

    public int ReadChildrenFolder(int xLocation, int yLocation, List<Folder> children)
    {
        if (children is null || children.Count == 0) return yLocation;
        xLocation += 30;
        foreach (var child in children)
        {
            var childName = Path.GetFileNameWithoutExtension(child.Path);
            CreateViewFolder(xLocation, yLocation, childName, child.Path, child.IsChoice);
            yLocation += 30;
            yLocation = ReadChildrenFolder(xLocation, yLocation, child.Childrens);
        }
        return yLocation;
    }
}