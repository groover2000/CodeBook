using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

string imagesFolder = Path.Combine(Environment.CurrentDirectory, "images");

IEnumerable<string> images = Directory.EnumerateFiles(imagesFolder);

foreach(string imgPath in images)
{
    string thumbNailPath = Path.Combine(Environment.CurrentDirectory, "images", Path.GetFileNameWithoutExtension(imgPath) + "-thumbnail" + Path.GetExtension(imgPath));

    using (Image image = Image.Load(imgPath))
    {
        image.Mutate(x => x.Resize(image.Width / 10, image.Height / 10));
        image.Mutate(x => x.Grayscale());
        image.Save(thumbNailPath);
    }
}

Console.WriteLine("Image processing complete. View the images folder.");