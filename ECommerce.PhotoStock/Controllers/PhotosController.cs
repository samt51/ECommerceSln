using ECommerce.PhotoStock.Dtos;
using ECommerce.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.PhotoStock.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        [HttpPost]
        public async Task<ResponseDto<PhotoDto>> PhotoSave(IFormFile file, CancellationToken cancellation)
        {
            if (file != null && file.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Photos", file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream, cancellation);
                }

                var returnPath = "Photos/" + file.FileName;

                PhotoDto photo = new() { Url = returnPath };

                return ResponseDto<PhotoDto>.Success(photo);
            }
            return ResponseDto<PhotoDto>.Fail("Photo is null");

        }

        [HttpPost]
        public ResponseDto<PhotoDto> PhotoDelete(string photoUrl)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Photos", photoUrl);

            if (!System.IO.File.Exists(path))
            {
                return ResponseDto<PhotoDto>.Fail("Photo is null");
            }

            System.IO.File.Delete(path);

            return ResponseDto<PhotoDto>.Success();
        }
    }
}
