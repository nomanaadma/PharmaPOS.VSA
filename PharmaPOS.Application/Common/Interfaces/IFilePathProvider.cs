namespace PharmaPOS.Application.Common.Interfaces;

public interface IFilePathProvider
{
	string GetUploadsFilePath(string fileName);
}

