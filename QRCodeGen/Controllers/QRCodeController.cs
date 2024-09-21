using Microsoft.AspNetCore.Mvc;
using QRCodeGen.Interfaces;
using QRCodeGen.Services;

namespace QRCodeGen.Controllers
{
    public class QRCodeController : Controller
    {
        private readonly IQRCodeService _qrCodeService;

        public QRCodeController(IQRCodeService qrCodeService)
        {
            _qrCodeService = qrCodeService;
        }

        public IActionResult Generate()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GenerateQRCode(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return BadRequest("Text is required to generate a QR code.");
            }

            var qrCodeImage = _qrCodeService.GenerateQRCode(text);

            // Return the QR code image as a PNG
            return File(qrCodeImage, "image/png");
        }
    }
}
