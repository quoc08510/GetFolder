namespace GiaoDien.Class;

public class Folder
{
    public string Path { get; set; }
    public bool IsChoice { get; set; }
    public List<Folder> Childrens { get; set; }
}