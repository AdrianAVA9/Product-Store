using ProductStore.Dtos;
using System;
using System.Configuration;
using System.IO;
using System.Web;

namespace ProductStore.WebApi.Helper
{
    public class CreatePicture
    {
        private string SERVER_PATH_FOLDER { get; set; }

        public CreatePicture()
        {
            SERVER_PATH_FOLDER = ConfigurationManager.AppSettings["UPLOAD_DIR"];
        }

        public string Create(Picture picture)
        {
            if (picture == null) return null;

            if (picture.IsExtensionAllowed())
            {
                var filename = Guid.NewGuid() + picture.Extension;
                var path = GetRouteCompleted(filename);

                File.WriteAllBytes(path, picture.Image);

                return filename;
            }

            return null;
        }

        private string GetRouteCompleted(string pictureName)
        {
            var route = HttpContext.Current.Server.MapPath(SERVER_PATH_FOLDER);
            var routeCompleted = string.Concat(route, "/", pictureName);

            return routeCompleted;
        }
    }
}