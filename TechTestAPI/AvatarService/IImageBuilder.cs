namespace AvatarService;
using Repository;

public interface IImageBuilder
{
    Image GetImage(string userIdentifier);
}