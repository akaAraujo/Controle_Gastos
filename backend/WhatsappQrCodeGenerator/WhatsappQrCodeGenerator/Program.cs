using System;
using System.IO;
using System.Web;
using QRCoder;

namespace WhatsappQrCodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("GERADOR DE QR CODE PARA WHATSAPP");
            Console.WriteLine("---------------------------------");

            // Solicita o número de telefone
            Console.Write("Digite o número do WhatsApp (Ex: 5511999999999): ");
            string phoneNumber = Console.ReadLine();

            // Solicita a mensagem
            Console.Write("Digite a mensagem que deseja enviar: ");
            string message = Console.ReadLine();

            // Codifica a mensagem para o whatsapp
            string encodedMessage = HttpUtility.UrlEncode(message);


            string whatsappUrl = $"https://wa.me/{phoneNumber}?text={encodedMessage}";

            Console.WriteLine("\nLink gerado:");
            Console.WriteLine(whatsappUrl);

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(whatsappUrl, QRCodeGenerator.ECCLevel.Q);
            PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);

            byte[] qrCodeImage = qrCode.GetGraphic(20);

            // Caminho onde o QR Code é salvo
            string filePath = "qrcode_whatsapp.png";

            File.WriteAllBytes(filePath, qrCodeImage);

            Console.WriteLine($"\nQR Code gerado com sucesso!");
            Console.WriteLine($"Arquivo salvo em: {Path.GetFullPath(filePath)}");

            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();

        }
    }
}