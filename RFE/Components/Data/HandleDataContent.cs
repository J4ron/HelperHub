namespace RFE.Components.Pages;

class HandleDataContent
{
    private Home _home;

    public HandleDataContent(Home home)
    {
        _home = home;
    }

    public void LoadFolderItems(string path)
    {
        try
        {
            var directoryItems = Directory.GetFileSystemEntries(path);
            _home.RootFolderItems = directoryItems.Select(item => new Home.FileSystemItem
            {
                Path = item,
                Name = Path.GetFileName(item),
                IsDirectory = Directory.Exists(item),
                SubItems = new List<Home.FileSystemItem>()
            }).ToList();

            _home.RootFolderItems = _home.RootFolderItems.OrderBy(item => item.IsDirectory ? 0 : 1).ToList();
        }
        catch (Exception ex)
        {
            _home.FileContent = $"Error loading directory: {ex.Message}";
        }
    }

    public void ToggleFolder(Home.FileSystemItem item)
    {
        if (item.IsDirectory)
        {
            if (!item.IsExpanded)
            {
                if (!item.SubItems.Any())
                {
                    LoadSubItems(item);
                }
            }
            item.IsExpanded = !item.IsExpanded;
        }
        else
        {
            LoadFileContent(item);
        }
    }

    protected void LoadSubItems(Home.FileSystemItem folderItem)
    {
        try
        {
            var subItems = Directory.GetFileSystemEntries(folderItem.Path);
            folderItem.SubItems = subItems.Select(subItem => new Home.FileSystemItem
            {
                Path = subItem,
                Name = Path.GetFileName(subItem),
                IsDirectory = Directory.Exists(subItem),
                SubItems = new List<Home.FileSystemItem>()
            }).ToList();

            folderItem.SubItems = folderItem.SubItems.OrderBy(item => item.IsDirectory ? 0 : 1).ToList();
        }
        catch (Exception ex)
        {
            _home.FileContent = $"Error loading subfolder: {ex.Message}";
        }
    }

    protected void LoadFileContent(Home.FileSystemItem item)
    {
        try
        {
            _home.CurrentFilePath = item.Path;

            if (_home.IsImageFile(item.Path))
            {
                _home.FileContent = null;
            }
            else
            {
                _home.FileContent = File.ReadAllText(item.Path);
            }
        }
        catch (Exception ex)
        {
            _home.FileContent = $"Error loading file: {ex.Message}";
        }
    }
}