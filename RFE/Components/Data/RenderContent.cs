using Microsoft.AspNetCore.Components;

namespace RFE.Components.Pages;

class RenderContent
{
    private Home _home;

    public RenderContent(Home home)
    {
        _home = home;
    }

    public RenderFragment RenderSubFolders(List<Home.FileSystemItem> subItems) => builder =>
    {
        foreach (var subItem in subItems)
        {
            builder.OpenElement(0, "li");
            builder.AddAttribute(1, "class", "list-group-item text-white border-0 border-bottom border-secondary");
            builder.AddAttribute(2, "style", "cursor: pointer; background-color: transparent;");
            builder.AddAttribute(3, "onclick", EventCallback.Factory.Create(_home, () => _home._handledatacontent.ToggleFolder(subItem)));

            if (subItem.IsDirectory)
            {
                builder.OpenElement(4, "i");
                builder.AddAttribute(5, "class", $"bi {(subItem.IsExpanded ? "bi-caret-down-fill" : "bi-caret-right-fill")}");
                builder.CloseElement();

                builder.OpenElement(6, "i");
                builder.AddAttribute(7, "class", "bi bi-folder-fill text-warning");
                builder.AddAttribute(8, "style", "margin-left: 0.5em; user-select: none");
                builder.CloseElement();

                builder.AddContent(9, subItem.Name);
            }
            else
            {
                builder.OpenElement(10, "i");
                builder.AddAttribute(11, "class", "bi bi-file-earmark-text");
                builder.CloseElement();

                builder.AddContent(12, subItem.Name);
            }

            builder.CloseElement();

            if (subItem.IsExpanded && subItem.SubItems.Any())
            {
                builder.OpenElement(13, "ul");
                builder.AddAttribute(14, "class", "list-group ms-3");
                builder.AddContent(15, RenderSubFolders(subItem.SubItems));
                builder.CloseElement();
            }
        }
    };
}