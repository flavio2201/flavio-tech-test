using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Repository;

public class ImagesDB : IImagesDB
{
    public Image GetImageById(int id)
    {
        string filePath = @"./db.json";
        string jsonContent = File.ReadAllText(filePath);

        // Deserialize JSON to Db object
        var db = JsonSerializer.Deserialize<DBClass>(jsonContent);
        var image = db.Images.Where(x => x.Id == id).SingleOrDefault() ?? new Image();
        return image;
    }
}
