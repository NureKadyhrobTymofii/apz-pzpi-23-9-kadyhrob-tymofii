using System;

namespace apz_pz1
{
    // Subject
    interface IImage
    {
        void Display();
    }

    // RealSubject
    class RealImage : IImage
    {
        private string fileName;

        public RealImage(string fileName)
        {
            this.fileName = fileName;
            LoadFromDisk();
        }

        private void LoadFromDisk()
        {
            Console.WriteLine("Завантаження з диска: " + fileName);
        }

        public void Display()
        {
            Console.WriteLine("Відображення: " + fileName);
        }
    }

    // Proxy
    class ProxyImage : IImage
    {
        private RealImage realImage;
        private string fileName;

        public ProxyImage(string fileName)
        {
            this.fileName = fileName;
        }

        public void Display()
        {
            if (realImage == null)
            {
                realImage = new RealImage(fileName);
            }
            realImage.Display();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IImage image = new ProxyImage("photo.jpg");

            image.Display();
            Console.WriteLine("-----");
            image.Display();
        }
    }
}
