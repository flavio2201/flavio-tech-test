using Repository;

namespace AvatarService;

public class ImageBuilder : IImageBuilder
{
    protected readonly IImagesDB _imagesDB;
    public ImageBuilder(IImagesDB imagesDB)
    {
        _imagesDB = imagesDB;
    }
    public Image GetImage(string userIdentifier)
    {        
        var jsonArray = new List<string>() { "6", "7", "8", "9" };
        var dbArray= new List<string>() { "1", "2", "3", "4","5" };
        var vowels = "aeiou" ;

        if (jsonArray.Any(x => userIdentifier.LastIndexOf(x) > -1))            
            return new Image() { ReturnType="json", Url = $"https://my-json-server.typicode.com/ck-pacificdev/tech-test/images/{userIdentifier[userIdentifier.Length - 1].ToString()}" };
        
        if (dbArray.Any(x => userIdentifier.LastIndexOf(x) > -1))
        {             
            int id = Convert.ToInt32(userIdentifier[userIdentifier.Length - 1].ToString());
            var image  = _imagesDB.GetImageById(id);
            return image;
        }            

        if (userIdentifier.Any(x => vowels.Contains(x)))
            return new Image() { Url = $"https://api.dicebear.com/8.x/pixel-art/png?seed=vowel&size=150" };

        if (userIdentifier.Any(x => !char.IsLetterOrDigit(x)))
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 6);            
            return new Image() { Url = $"https://api.dicebear.com/8.x/pixel-art/png?seed={randomNumber}&size=150" };
        }

        return new Image() { Url = "https://api.dicebear.com/8.x/pixel-art/png?seed=default&size=150" };        
    }
}
