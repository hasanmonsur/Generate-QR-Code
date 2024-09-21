namespace QRCodeGen.Interfaces
{
    public interface IQRCodeService
    {
        byte[] GenerateQRCode(string text, int width = 250, int height = 250);
    }
}