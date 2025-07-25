using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental._02_DataTypes.Delegates
{
    public class Photo
    {
        public static Photo Load(string path)
        {
            Console.WriteLine("Loading the photo");
            return new Photo();
        }

        public  void Save()
        {
            Console.WriteLine("Saving the Photo");
        }
    }

    public class PhotoFilters
    {
        public void ApplyBrightness(Photo photo)
        {
            Console.WriteLine("Applying Brightness");
        }

        public void ApplyContrast(Photo photo)
        {
            Console.WriteLine("Apply Contrast");
        }

        public void Resize(Photo photo)
        {
            Console.WriteLine("Resize photo");
        }
    }

    public class PhotoProcessor
    {
        //Action<T>
        //Func<T> 
        public delegate void PhotoFilterHandler(Photo photo);

        public void Process(string path, PhotoFilterHandler filterHandler)
        {
            var photo = Photo.Load(path);

            filterHandler(photo);

            photo.Save();
        }
    }

    [TestFixture]
    public class DelegateTest
    {
        [Test]
        public void PhotoProcessorTest()
        {
            var processor = new PhotoProcessor();
            var filters = new PhotoFilters();
            PhotoProcessor.PhotoFilterHandler filterHandler = filters.ApplyBrightness;
            filterHandler += filters.ApplyContrast;
            filterHandler += filters.Resize;
            filterHandler+= RemoveRedEye;

            processor.Process("abc.jpg", filterHandler);

        }

        void RemoveRedEye(Photo photo)
        {
            Console.WriteLine("Remove Red Eye");
        }

    }
}
