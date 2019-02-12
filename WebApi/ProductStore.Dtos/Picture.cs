using System.Collections.Generic;

namespace ProductStore.Dtos
{
    public class Picture
    {
        private readonly IList<string> AllowedFilesExtensions = new List<string> { ".png", ".jpg", ".jpeg", ".gif" };
        public string Extension { get; private set; }
        public byte[] Image { get; private set; }

        public Picture(string extension, byte[] image)
        {
            Extension = GetValidFormat(extension.ToLower());
            Image = image;
        }

        public bool IsExtensionAllowed()
        {
            return AllowedFilesExtensions.Contains(Extension);
        }

        private string GetValidFormat(string extension)
        {
            if (extension.IndexOf(".") == 0)
            {
                return extension.Insert(0, ".");
            }

            return extension;
        }
    }
}
