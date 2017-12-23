using System;
using System.Drawing;

namespace CorporateClash.Core
{
    public class Background
    {
        private static readonly Random Rand = new Random();

        private static readonly string[] Playgrounds = {"TTC", "DD", "DG", "MML", "Brrrgh", "DDL"};

        public static Image ReturnRandomBackground()
        {
            int index = Rand.Next(1, Playgrounds.Length);

            try
            {
                return GetImage(Playgrounds[index]);
            }
            catch (Exception)
            {
                return Properties.Resources.TTC;
            }
        }

        private static Image GetImage(string name)
        {
            try
            {
                return (Image) Properties.Resources.ResourceManager.GetObject(name);
            }
            catch (InvalidCastException e)
            {
                Log.Error($"Tried to retrieve a resource that was not an image. Resource name {name}");
            }

            return default(Image);
        }

        public static Image ReturnBackground(string background)
        {
            try
            {
                return GetImage(background);
            }
            catch (Exception)
            {
                return Properties.Resources.TTC;
            }
        }

        public static Image GetButtonImage(string name, string method)
        {
            method = method.ToLower();
            switch (method)
            {
                case "mouseenter":
                    return GetImage(name + "_h");
                case "mousedown":
                    return GetImage(name + "_d");
                case "mouseup":
                case "mouseleave":
                    return GetImage(name);
                default:
                    return default(Image);
            }
        }
    }
}
