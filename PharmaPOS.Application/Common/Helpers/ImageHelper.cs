namespace PharmaPOS.Application.Common.Helpers;

public static class ImageHelper
{
    public static (int width, int height) GetImageDimensions(string path)
    {
        try
        {
            if (!File.Exists(path)) return (0, 0);

            using var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            using var reader = new BinaryReader(fileStream);
            
            var header = reader.ReadBytes(8);
            if (header.Length < 8) return (0, 0);

            // Check PNG: 89 50 4E 47 0D 0A 1A 0A
            if (header[0] == 0x89 && header[1] == 0x50 && header[2] == 0x4E && header[3] == 0x47)
            {
                fileStream.Position = 16;
                var widthBytes = reader.ReadBytes(4);
                var heightBytes = reader.ReadBytes(4);
                Array.Reverse(widthBytes); // big-endian
                Array.Reverse(heightBytes);
                var width = BitConverter.ToInt32(widthBytes, 0);
                var height = BitConverter.ToInt32(heightBytes, 0);
                return (width, height);
            }

            // Check GIF: GIF87a or GIF89a
            if (header[0] == 'G' && header[1] == 'I' && header[2] == 'F')
            {
                fileStream.Position = 6;
                int width = reader.ReadUInt16();
                int height = reader.ReadUInt16();
                return (width, height);
            }

            // Check JPEG: FF D8
            if (header[0] == 0xFF && header[1] == 0xD8)
            {
                fileStream.Position = 2;
                while (fileStream.Position < fileStream.Length)
                {
                    var marker = reader.ReadByte();
                    while (marker == 0xFF && fileStream.Position < fileStream.Length)
                    {
                        marker = reader.ReadByte();
                    }

                    if (marker is 0xD9 or 0xDA) // EOI or SOS
                    {
                        break;
                    }

                    var lenBytes = reader.ReadBytes(2);
                    if (lenBytes.Length < 2) break;
                    Array.Reverse(lenBytes);
                    var length = BitConverter.ToUInt16(lenBytes, 0);

                    if (marker is 0xC0 or 0xC1 or 0xC2 or 0xC3 or >= 0xC5 and <= 0xC7 or >= 0xC9 and <= 0xCB or >= 0xCD and <= 0xCF)
                    {
                        fileStream.Position += 1; // skip precision
                        var hBytes = reader.ReadBytes(2);
                        var wBytes = reader.ReadBytes(2);
                        Array.Reverse(hBytes);
                        Array.Reverse(wBytes);
                        int height = BitConverter.ToUInt16(hBytes, 0);
                        int width = BitConverter.ToUInt16(wBytes, 0);
                        return (width, height);
                    }

                    fileStream.Position += (length - 2);
                }
            }
        }
        catch
        {
            // ignored
        }
        return (0, 0);
    }
}
