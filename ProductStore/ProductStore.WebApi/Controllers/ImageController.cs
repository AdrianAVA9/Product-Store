using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace ProductStore.WebApi.Controllers
{
    [RoutePrefix("images")]
    public class ImageController : ApiController
    {
        private string UPLOAD_DIR { get; set; }

        public ImageController()
        {
            UPLOAD_DIR = ConfigurationManager.AppSettings["UPLOAD_DIR"];
        }

        [HttpGet]
        [Route("products")]
        public IHttpActionResult GetImage(string imageId)
        {
            if (imageId == null) NotFound();

            var path = HttpContext.Current.Server.MapPath(UPLOAD_DIR);
            path = path + "/" + imageId;

            if (File.Exists(path))
            {
                var fileStream = File.OpenRead(path);

                var response = new HttpResponseMessage(System.Net.HttpStatusCode.OK)
                {
                    Content = new StreamContent(fileStream)
                };

                response.Content.Headers.ContentType =
                    new MediaTypeHeaderValue("image" + "/" + Path.GetExtension(path).Substring(1));

                return ResponseMessage(response);
            }

            return NotFound();

        }
    }
}
